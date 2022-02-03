using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace JasonPereira84.AppSettings.Tests
{
    namespace Extensions
    {
        [TestClass]
        public class Test_RSA
        {
            /*
            <RSAKeyValue>
                <Modulus>tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==</Modulus>
                <Exponent>AQAB</Exponent>
                <P>5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=</P>
                <Q>yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=</Q>
                <DP>pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=</DP>
                <DQ>poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=</DQ>
                <InverseQ>y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=</InverseQ>
                <D>FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q==</D>
            </RSAKeyValue>
            */

            [TestMethod]
            public void AsXmlString()
            {
                {
                    var key = new RSA.PrivateKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                        P = @"5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=",
                        Q = @"yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=",
                        DP = @"pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=",
                        DQ = @"poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=",
                        InverseQ = @"y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=",
                        D = @"FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q=="
                    };

                    Assert.AreEqual(
                        expected: @"<RSAKeyValue><Modulus>tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==</Modulus><Exponent>AQAB</Exponent><P>5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=</P><Q>yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=</Q><DP>pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=</DP><DQ>poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=</DQ><InverseQ>y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=</InverseQ><D>FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q==</D></RSAKeyValue>",
                        actual: key.AsXmlString(new XmlSerializer(typeof(RSA.PrivateKey), new XmlRootAttribute("RSAKeyValue"))));
                }

                {
                    var key = new RSA.PublicKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                    };

                    Assert.AreEqual(
                        expected: @"<RSAKeyValue><Modulus>tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
                        actual: key.AsXmlString(new XmlSerializer(typeof(RSA.PublicKey), new XmlRootAttribute("RSAKeyValue"))));
                }

                {
                    var key = new RSA.PublicKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                    };

                    Assert.ThrowsException<InvalidOperationException>(
                        () => key.AsXmlString(new XmlSerializer(typeof(RSA.PrivateKey), new XmlRootAttribute("RSAKeyValue"))));
                }

                {
                    var key = new RSA.PrivateKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                        P = @"5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=",
                        Q = @"yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=",
                        DP = @"pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=",
                        DQ = @"poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=",
                        InverseQ = @"y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=",
                        D = @"FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q=="
                    };

                    Assert.ThrowsException<InvalidOperationException>(
                        () => key.AsXmlString(new XmlSerializer(typeof(RSA.PublicKey), new XmlRootAttribute("RSAKeyValue"))));
                }

            }

            [TestMethod]
            public void PublicKey()
            {
                {
                    var privateKey = new RSA.PrivateKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                        P = @"5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=",
                        Q = @"yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=",
                        DP = @"pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=",
                        DQ = @"poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=",
                        InverseQ = @"y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=",
                        D = @"FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q=="
                    };

                    var publicKey = privateKey.PublicKey();
                    Assert.IsNotNull(publicKey);
                    Assert.AreEqual(
                        expected: privateKey.Modulus,
                        actual: publicKey.Modulus);
                    Assert.AreEqual(
                        expected: privateKey.Exponent,
                        actual: publicKey.Exponent);
                }

            }

            [TestMethod]
            public void AsRSAParameters()
            {
                {
                    var key = new RSA.PrivateKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB",
                        P = @"5hktKHQS26zRsM4qvKatW9bRg0bqCuCltdmjOuSeYe/Z+D9Au6Lvw8m+4QzIjtLR49oVvgsR871HpbWvHR1Jr9ARkwp0R6r5gR/JZ7eHIkrH45a1h9++2isjDsczXNJlHd+In6Acwob82wbTEbmqY0pF/k7WSRtgO0k4gwvsO2E=",
                        Q = @"yQ2ANGEhGR9EU180gf8fWPAfOX2o4lmRh0eGj8y4XuqJtiqTqY6hnYBVt4e62EDXFEe2KlSzNPcnC0Fmy6EaU6UTA0ZULGe0l38GY01sbPaXzq+ZOKWlTFvxGVjlMm4JdpeW0knI1bz6Ulsc91akrEQ+7/QrUchGKzy7BLwLOLc=",
                        DP = @"pdZLZ7aQyOb7kpRk1ObEV0ayZg08LW7PwAsFzDJtvGRkErlz7Eh4ygGjowvVmKp1P+U0em38GFG5S8NwXGl5bE9n+zQzrluZy+ie/jOWH68J9gvu9eja4t7oO4RyjlnNKwSqsXFyiPlFUI7QnRvVpA4p+CnV44bpipExO7HiJsE=",
                        DQ = @"poM9+SOwi+PvbLVfAYNQbRKCadT++GiCNO4yLgq5cDMDVxIwNa/hflZ5p4UMZGpfN3alEq4PtgA0IAhMoL2O1lPTSVUIBbbmRMp5eej3sc8Rr6aTWe0m1/UV245aVMf5onSt/wAJC6x2DZtUhC0IOXxUO9uXvSYHp2um4Kb1DEU=",
                        InverseQ = @"y9yqrDJl+vClS5QhTkVsvACJzBTCClmwZKo8J/taRWlQw1o3WlOLKT5yZn4iV2wVR7yD6vDGHFaAYbOuEmew5wWyhH71w6xxyJwe39/K4Wz3N/azRC4lvK/abGPmXdC0FyQK3LeRgy0pyDqOs0bnZ+7geRZARbucIsZf4ubzBCI=",
                        D = @"FQKHEWsW3uLmj4/PEk+c8baIYZFtRTpMfWrqTQug5hjJrEPr76+8IHBOCvWBkY1gwJ1pQLySROySnO0uJ5a2ZWF1JA37uLvJ233C/88ICdvrJmNsqd22jn1ifPpFvXyJuxMKKzMgPhdPVD92d25wouYfYCUOFGCb+FreWr95HRR98ai2+Y5Ib8ymb6/w9WI47eoGHbLYnvPHGZrjeEVew1PY8vaBVsMsNUJYH1tJF1D8HkKXiDQBsKmD9vM2whTbMtXvb+6mevqdQoD0ossQSoW+cr4CRos3tiZwp3+nEE6F4desjsDwltE3CeSg3x70a0xIPSm4VLTsBKeDzOIt4Q=="
                    };

                    var rsaParameters = key.AsRSAParameters();
                    Assert.IsNotNull(rsaParameters.Modulus);
                    Assert.IsTrue(rsaParameters.Modulus.Length == 256);
                    Assert.IsNotNull(rsaParameters.Exponent);
                    Assert.IsTrue(rsaParameters.Exponent.Length == 3);
                    Assert.IsNotNull(rsaParameters.P);
                    Assert.IsTrue(rsaParameters.P.Length == 128);
                    Assert.IsNotNull(rsaParameters.Q);
                    Assert.IsTrue(rsaParameters.Q.Length == 128);
                    Assert.IsNotNull(rsaParameters.DP);
                    Assert.IsTrue(rsaParameters.DP.Length == 128);
                    Assert.IsNotNull(rsaParameters.DQ);
                    Assert.IsTrue(rsaParameters.DQ.Length == 128);
                    Assert.IsNotNull(rsaParameters.InverseQ);
                    Assert.IsTrue(rsaParameters.InverseQ.Length == 128);
                    Assert.IsNotNull(rsaParameters.D);
                    Assert.IsTrue(rsaParameters.D.Length == 256);
                }

                {
                    var key = new RSA.PublicKey
                    {
                        Modulus = @"tLXm97kvY6CQJqZupGsEqg43Eg1vC+37YzYzb+3sImTR43YwEMm3VVYtoox9sS1iZDp0wg5hUQQq2q62XLndGEUHH4kwn6QptFur/ZT8N29tlxe9HbrnMdc2FpHfgKxDp0KMjGp8p+hlDEXoaSABHsA5MVpnKRAnz/un9dj88cO68vVZ0W6NCFSEOwaIubIbaCRcmd6d7elLDU5zH/jDmRQdHMm0V7xROixuCPX8pEkC26aj+n2B9q2BytwcXDRQUckXmKKiy5tOXUTrniXxUGSvSLEPdhqYo4qVSIICToMujtyZL/LYCws/Sz9vtsf268tJQpW9CgcE49eO/AaqVw==",
                        Exponent = @"AQAB"
                    };

                    var rsaParameters = key.AsRSAParameters();
                    Assert.IsNotNull(rsaParameters.Modulus);
                    Assert.IsTrue(rsaParameters.Modulus.Length == 256);
                    Assert.IsNotNull(rsaParameters.Exponent);
                    Assert.IsTrue(rsaParameters.Exponent.Length == 3);
                    Assert.IsNull(rsaParameters.P);
                    Assert.IsNull(rsaParameters.Q);
                    Assert.IsNull(rsaParameters.DP);
                    Assert.IsNull(rsaParameters.DQ);
                    Assert.IsNull(rsaParameters.InverseQ);
                    Assert.IsNull(rsaParameters.D);
                }

            }

        }
    }
}
