using System;
using System.Linq;
using System.Text;

namespace JasonPereira84.AppSettings
{
    using Internal;

    public static partial class Extensions
    {
        public static String HasId(this Credentials credentials, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            => credentials.Id.EvaluateSanity(funcIfTrue, funcIfFalse, dontTrim);
        public static String HasId(this Credentials credentials, Func<String, String> funcIfTrue, Func<String> funcIfFalse, Boolean dontTrim = false)
            => credentials.Id.EvaluateSanity(funcIfTrue, funcIfFalse, dontTrim);
        public static String HasId(this Credentials credentials, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            => credentials.Id.EvaluateSanity(funcIfTrue, dontTrim);

        public static String HasSecret(this Credentials credentials, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean trim = false)
            => credentials.Secret.EvaluateSanity(funcIfTrue, funcIfFalse, !trim);
        public static String HasSecret(this Credentials credentials, Func<String, String> funcIfTrue, Func<String> funcIfFalse, Boolean trim = false)
            => credentials.Secret.EvaluateSanity(funcIfTrue, funcIfFalse, !trim);
        public static String HasSecret(this Credentials credentials, Func<String, String> funcIfTrue, Boolean trim = false)
            => credentials.Secret.EvaluateSanity(funcIfTrue, !trim);
    }
}