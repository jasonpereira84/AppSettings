using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static String AsXmlString<TKey>(this TKey key, XmlSerializer xmlSerializer)
            where TKey : RSA._Key
        {
            using (var stringWriter = new StringWriter())
            using (var xw = XmlWriter.Create(stringWriter, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                xmlSerializer.Serialize(xw, key, new XmlSerializerNamespaces(new[] { new XmlQualifiedName(String.Empty, String.Empty) }));
                return stringWriter.ToString();
            }
        }
        public static String AsXmlString<TKey>(this TKey key)
            where TKey : RSA._Key
            => AsXmlString(key, new XmlSerializer(key.GetType(), new XmlRootAttribute("RSAKeyValue")));

        public static RSAParameters AsParameters<TKey>(this TKey key, Boolean onlyPublic = default)
            where TKey : RSA._Key
        {
            RSAParameters _public(RSA.PublicKey k)
                => new RSAParameters
                {
                    Modulus = Convert.FromBase64String(k.Modulus),
                    Exponent = Convert.FromBase64String(k.Exponent)
                };

            RSAParameters _private(RSA.PrivateKey k)
                => new RSAParameters
                {
                    Modulus = Convert.FromBase64String(k.Modulus),
                    Exponent = Convert.FromBase64String(k.Exponent),
                    InverseQ = Convert.FromBase64String(k.InverseQ),
                    DQ = Convert.FromBase64String(k.DQ),
                    DP = Convert.FromBase64String(k.DP),
                    D = Convert.FromBase64String(k.D),
                    Q = Convert.FromBase64String(k.Q),
                    P = Convert.FromBase64String(k.P)
                };

            return onlyPublic || key is RSA.PublicKey
                ? _public(key as RSA.PublicKey)
                : _private(key as RSA.PrivateKey);
        }
    }
}

