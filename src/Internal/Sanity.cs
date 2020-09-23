﻿using System;

namespace JasonPereira84.AppSettings
{
    namespace Internal
    {
        internal static partial class Helpers
        {
            public static Boolean IsNull(this String value)
                => value == null;

            public static Boolean IsEmpty(this String nonNullString)
                => nonNullString.Length.Equals(0);

            public static Boolean IsWhiteSpace(this String nonNullString)
                => nonNullString.Trim().Length.Equals(0);

            public static Boolean IsNullOrEmpty(this String value)
                => value.IsNull() || value.IsEmpty();

            public static Boolean IsEmptyOrWhiteSpace(this String nonNullString)
                => nonNullString.IsEmpty() || nonNullString.IsWhiteSpace();

            public static Boolean IsNullOrEmptyOrWhiteSpace(this String value)
                => String.IsNullOrWhiteSpace(value);

            public static (Boolean IsSane, String Value) EvaluateSanity(this String value,
                String valueIfNull, String valueIfEmpty, String valueIfWhitespace, Boolean dontTrim = false)
                => IsNull(value)
                    ? (false, valueIfNull)
                    : IsEmpty(value)
                        ? (false, valueIfEmpty)
                        : IsWhiteSpace(value)
                            ? (false, valueIfWhitespace)
                            : (true, dontTrim ? value : value.Trim());
            public static (Boolean IsSane, String Value) EvaluateSanity(this String value,
                String valueIfNull, String valueIfEmpty, String valueIfWhitespace, out (Boolean IsSane, String Value) result, Boolean dontTrim = false)
                => result = EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);

            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, Boolean dontTrim = false)
                => EvaluateSanity(value, "NULL", "EMPTY", "WHITESPACE", dontTrim);
            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, out (Boolean IsSane, String Value) result, Boolean dontTrim = false)
                => result = EvaluateSanity(value, dontTrim);

            public static Boolean EvaluateSanity(this String value, String name, out String saneValue, Boolean dontTrim = false)
            {
                var result = EvaluateSanity(value, $"NULL-{name}", $"EMPTY-{name}", $"WHITESPACE-{name}", dontTrim);
                saneValue = result.Value;
                return result.IsSane;
            }

            public static String EvaluateSanity(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                var eval = value.EvaluateSanity(dontTrim);
                return eval.IsSane 
                    ? funcIfTrue.Invoke(eval.Value) 
                    : funcIfFalse.Invoke(eval.Value);
            }

            public static String EvaluateSanity(this String value, Func<String, String> funcIfTrue, Func<String> funcIfFalse, Boolean dontTrim = false)
            {
                var eval = value.EvaluateSanity(dontTrim);
                return eval.IsSane
                    ? funcIfTrue.Invoke(eval.Value)
                    : funcIfFalse.Invoke();
            }

            public static String EvaluateSanity(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                var eval = value.EvaluateSanity(dontTrim);
                return !eval.IsSane 
                    ? String.Empty
                    : funcIfTrue.Invoke(eval.Value);
            }


            public static String SanitizeTo(this String value, String valueIfNull, String valueIfEmpty, String valueIfWhitespace, Boolean dontTrim = false)
                => EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim).Value;

            public static String SanitizeTo(this String value, String valueIfNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
                => String.IsNullOrWhiteSpace(value)
                    ? valueIfNullOrEmptyOrWhiteSpace
                    : dontTrim
                        ? value
                        : value.Trim();

            public static String Sanitize(this String value, Boolean dontTrim = false) => value.SanitizeTo(String.Empty, dontTrim);

            public static String HasValue<T>(this T? t, Func<T, String> funcIfTrue, Func<String> funcIfFalse = default(Func<String>))
                where T : struct
                 => t.HasValue
                     ? funcIfTrue.Invoke(t.Value)
                     : funcIfFalse?.Invoke() ?? String.Empty;
        }
    }
}