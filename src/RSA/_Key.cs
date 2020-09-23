using System;

namespace JasonPereira84.AppSettings
{
    public partial class RSA
    {
        public abstract class _Key
        {
            public String Modulus { get; set; } = default(String);

            public String Exponent { get; set; } = default(String);
        }
    }
}
 