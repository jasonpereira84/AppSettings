using System;

namespace JasonPereira84.AppSettings
{
    public class JsonWebToken<TSigningCredentials> : _SecurityToken
    {
        public TSigningCredentials SigningCredentials { get; set; } = default(TSigningCredentials);
    }

    public class JsonWebToken
    {
        public class SigningCredentials
        {
            public class RSA<TKey> : _SigningCredentials<TKey>
                where TKey : JasonPereira84.AppSettings.RSA._Key
            { }

            public class RSA
            {
                public class PublicKey : JsonWebToken<RSA<JasonPereira84.AppSettings.RSA.PublicKey>> { }

                public class PrivateKey : JsonWebToken<RSA<JasonPereira84.AppSettings.RSA.PrivateKey>> { }
            }
        }
    }
}