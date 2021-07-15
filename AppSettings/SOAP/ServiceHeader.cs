using System;

namespace JasonPereira84.AppSettings
{
    namespace SOAP
    {
        public class ServiceHeader
        {
            public Byte[] Seed { get; set; } = default(Byte[]);

            public String EncryptedText { get; set; } = default(String);

            public RSA.PublicKey RSAPublicKey { get; set; } = default(RSA.PublicKey);
        }
    }
}
