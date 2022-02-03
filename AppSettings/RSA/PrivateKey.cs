using System;

namespace JasonPereira84.AppSettings
{
    public partial class RSA
    {
        public class PrivateKey : _Key
        {
            public String P { get; set; }

            public String Q { get; set; }

            public String DP { get; set; }

            public String DQ { get; set; }

            public String InverseQ { get; set; }

            public String D { get; set; }
        }
    }
}
