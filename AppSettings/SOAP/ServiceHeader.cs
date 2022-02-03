using System;

namespace JasonPereira84.AppSettings
{
    public partial class SOAP
    {
        public class ServiceHeader
        {
            public Byte[] Seed { get; set; }

            public String EncryptedText { get; set; }

            public RSA.PublicKey RSAPublicKey { get; set; }
        }
    }
}
