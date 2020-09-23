using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    namespace Internal
    {
        internal static partial class Helpers
        {
            public static Boolean None<TSource>(this IEnumerable<TSource> source)
                => !source.Any();

            public static Boolean IsNullOrNone<TSource>(this IEnumerable<TSource> source)
                => source?.None() ?? true;
        }
    }
}
