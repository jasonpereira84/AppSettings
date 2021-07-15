using System;

namespace JasonPereira84.AppSettings
{
    public partial class RSA
    {
        public class PrivateKey : _Key
        {
            public String P { get; set; } = default(String);

            public String Q { get; set; } = default(String);

            public String DP { get; set; } = default(String);

            public String DQ { get; set; } = default(String);

            public String InverseQ { get; set; } = default(String);

            public String D { get; set; } = default(String);
        }
    }
}
