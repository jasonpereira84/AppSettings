using System;

namespace JasonPereira84.AppSettings
{
    public class JsonWebToken<TSigningCredentials> : SecurityToken
    {
        public TSigningCredentials SigningCredentials { get; set; }
    }

    public class JsonWebToken
    {
        public class SigningCredentials
        {
            public class RSA<TKey> : SigningCredentials<TKey>
                where TKey : AppSettings.RSA._Key
            { }

            public class RSA
            {
                public class PublicKey : JsonWebToken<RSA<AppSettings.RSA.PublicKey>> { }

                public class PrivateKey : JsonWebToken<RSA<AppSettings.RSA.PrivateKey>> { }
            }
        }
    }
}