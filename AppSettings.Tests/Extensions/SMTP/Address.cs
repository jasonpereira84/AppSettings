using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Mail;

namespace JasonPereira84.AppSettings.Tests
{
    namespace Extensions
    {
        using Address = AppSettings.SMTP.Address;

        public partial class SMTP
        {
            [TestClass]
            public class Test_Address
            {
                [TestMethod]
                public void AsMailAddress()
                {
                    {
                        var address = new Address
                        {
                            Value = "henry_fonda@mailserver.com",
                            DisplayName = "Henry Fonda"
                        };

                        var mailAddress = address.AsMailAddress();
                        Assert.IsNotNull(mailAddress);
                        Assert.AreEqual(
                            expected: mailAddress.Address,
                            actual: mailAddress.Address);
                        Assert.AreEqual(
                            expected: mailAddress.DisplayName,
                            actual: mailAddress.DisplayName);
                    }

                    {
                        {
                            var address = new Address
                            {
                                Value = default(String)
                            };

                            Assert.ThrowsException<ArgumentNullException>(
                                () => address.AsMailAddress());
                        }

                        {
                            var address = new Address
                            {
                                Value = ""
                            };

                            Assert.ThrowsException<ArgumentException>(
                                () => address.AsMailAddress());
                        }

                        {
                            var address = new Address
                            {
                                Value = " "
                            };

                            Assert.ThrowsException<FormatException>(
                                () => address.AsMailAddress());
                        }

                    }

                    {
                        {
                            var address = new Address
                            {
                                Value = "henry_fonda@mailserver.com",
                                DisplayName = default(String)
                            };

                            {
                                var mailAddress = address.AsMailAddress();
                                Assert.AreEqual(
                                    expected: String.Empty,
                                    actual: mailAddress.DisplayName);
                            }

                            {
                                var mailAddress = address.AsMailAddress(dontSanitizeDisplayName: true);
                                Assert.AreEqual(
                                    expected: String.Empty,
                                    actual: mailAddress.DisplayName);
                            }

                        }

                        {
                            var address = new Address
                            {
                                Value = "henry_fonda@mailserver.com",
                                DisplayName = ""
                            };

                            {
                                var mailAddress = address.AsMailAddress();
                                Assert.AreEqual(
                                    expected: String.Empty,
                                    actual: mailAddress.DisplayName);
                            }

                            {
                                var mailAddress = address.AsMailAddress(dontSanitizeDisplayName: true);
                                Assert.AreEqual(
                                    expected: String.Empty,
                                    actual: mailAddress.DisplayName);
                            }

                        }

                        {
                            var address = new Address
                            {
                                Value = "henry_fonda@mailserver.com",
                                DisplayName = " "
                            };

                            {
                                var mailAddress = address.AsMailAddress();
                                Assert.AreEqual(
                                    expected: String.Empty,
                                    actual: mailAddress.DisplayName);
                            }

                            {
                                var mailAddress = address.AsMailAddress(dontSanitizeDisplayName: true);
                                Assert.AreEqual(
                                    expected: " ",
                                    actual: mailAddress.DisplayName);
                            }
                        }

                    }

                }

            }
        }
    }
}
