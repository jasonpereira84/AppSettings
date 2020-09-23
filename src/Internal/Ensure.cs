using System;

namespace JasonPereira84.AppSettings
{
    namespace Internal
    {
        internal static class Ensure
        {
            private static void _that<TException>(Boolean p, Func<TException> fx)
            where TException : Exception
            { if (!p) throw fx(); }

            public static void That<TException>(Boolean predicate)
                where TException : Exception
                => _that(predicate, () => (TException)Activator.CreateInstance(typeof(TException)));
            public static void That<TException>(Boolean predicate, String message)
                where TException : Exception
                => _that(predicate, () => (TException)Activator.CreateInstance(typeof(TException), new Object[] { message ?? "NULL message" }));

            public static void That(Boolean predicate) => That<Exception>(predicate);
            public static void That(Boolean predicate, String message) => That<Exception>(predicate, message);

            public static class Argument
            {
                public static void Is(Boolean predicate) => _that(predicate, () => new ArgumentException());
                public static void Is(Boolean predicate, String message) => _that(predicate, () => new ArgumentException(message ?? "NULL message"));
                public static void Is(Boolean predicate, String message, String paramName) => _that(predicate, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

                public static TResult Is<T, TResult>(T value, Func<T, (Boolean IsSane, TResult Value)> predicate, String message, String paramName)
                {
                    var eval = predicate.Invoke(value);
                    Is(eval.IsSane, message, paramName);
                    return eval.Value;
                }

                public static T Is<T>(T value, Func<T, Boolean> predicate, String message, String paramName)
                    => Is(value, new Func<T, (Boolean IsSane, T Value)>(t => { var b = predicate.Invoke(t); return b ? (true, t) : (false, t); }), message, paramName);

            }
        }
    }
}
