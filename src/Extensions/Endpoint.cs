using System;
using System.Linq;
using System.Text;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static String HasPort(this Endpoint endpoint, Func<UInt16, String> funcIfTrue, Func<String> funcIfFalse = default(Func<String>))
            => endpoint.Port.HasValue(funcIfTrue, funcIfFalse);

    }
}