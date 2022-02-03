using System;
using System.IO;
using System.Xml;
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

        public static RSA.PublicKey PublicKey(this RSA.PrivateKey key)
            => new RSA.PublicKey
            {
                Modulus = key.Modulus,
                Exponent = key.Exponent
            };

        public static RSAParameters AddPrivateParameters(this RSAParameters rsaParameters, RSA.PrivateKey key)
        {
            rsaParameters.P = Convert.FromBase64String(key.P);
            rsaParameters.Q = Convert.FromBase64String(key.Q);
            rsaParameters.DP = Convert.FromBase64String(key.DP);
            rsaParameters.DQ = Convert.FromBase64String(key.DQ);
            rsaParameters.InverseQ = Convert.FromBase64String(key.InverseQ);
            rsaParameters.D = Convert.FromBase64String(key.D);
            return rsaParameters;
        }

        public static RSAParameters AsRSAParameters<TKey>(this TKey key)
            where TKey : RSA._Key
        {
            var retVal = new RSAParameters
            {
                Modulus = Convert.FromBase64String(key.Modulus),
                Exponent = Convert.FromBase64String(key.Exponent)
            };
            return key is RSA.PrivateKey 
                ? retVal.AddPrivateParameters(key as RSA.PrivateKey) 
                : retVal;
        }

    }
}

