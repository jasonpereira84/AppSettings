using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Mail;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings.Tests
{
    namespace Extensions
    {
        using Address = AppSettings.SMTP.Address;
        using Message = AppSettings.SMTP.Message;

        public partial class SMTP
        {
            [TestClass]
            public class Test_Message
            {
                [TestMethod]
                public void AsMailMessage()
                {
                    {
                        var priority = "High";
                        var subject = "hello";
                        var address = new Address { Value = "henry_fonda@mailserver.com" };
                        var message = new Message
                        {
                            Priority = priority,
                            Subject = subject,
                            From = address,
                            To = new[] { address },
                            CC = new[] { address },
                            Bcc = new[] { address }
                        };

                        var mailMessage = message.AsMailMessage();
                        Assert.IsNotNull(mailMessage);
                        Assert.AreEqual(
                            expected: MailPriority.High,
                            actual: mailMessage.Priority);
                        Assert.AreEqual(
                            expected: subject,
                            actual: mailMessage.Subject);
                        Assert.AreEqual(
                            expected: address.Value,
                            actual: mailMessage.From.Address);
                        Assert.IsTrue(mailMessage.To.Count == 1);
                        Assert.IsTrue(mailMessage.CC.Count == 1);
                        Assert.IsTrue(mailMessage.Bcc.Count == 1);
                    }

                    {
                        {
                            var priority = default(String);
                            var message = new Message
                            {
                                Priority = priority
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.AreEqual(
                                expected: default(MailPriority),
                                actual: mailMessage.Priority);
                        }

                        {
                            var priority = "";
                            var message = new Message
                            {
                                Priority = priority
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.AreEqual(
                                expected: default(MailPriority),
                                actual: mailMessage.Priority);
                        }

                        {
                            var priority = " ";
                            var message = new Message
                            {
                                Priority = priority
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.AreEqual(
                                expected: default(MailPriority),
                                actual: mailMessage.Priority);
                        }

                        {
                            var priority = "high";
                            var message = new Message
                            {
                                Priority = priority
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.AreEqual(
                                expected: MailPriority.High,
                                actual: mailMessage.Priority);
                        }

                    }

                    {
                        {
                            var subject = default(String);
                            var message = new Message
                            {
                                Subject = subject
                            };

                            {
                                var mailMessage = message.AsMailMessage();
                                Assert.AreEqual(
                                    expected: "No Subject",
                                    actual: mailMessage.Subject);
                            }

                            {
                                var mailMessage = message.AsMailMessage(dontSanitizeSubject: true);
                                Assert.AreEqual(
                                    expected: "",
                                    actual: mailMessage.Subject);
                            }

                        }

                        {
                            var subject = "";
                            var message = new Message
                            {
                                Subject = subject
                            };

                            {
                                var mailMessage = message.AsMailMessage();
                                Assert.AreEqual(
                                    expected: "No Subject",
                                    actual: mailMessage.Subject);
                            }

                            {
                                var mailMessage = message.AsMailMessage(dontSanitizeSubject: true);
                                Assert.AreEqual(
                                    expected: "",
                                    actual: mailMessage.Subject);
                            }

                        }

                        {
                            var subject = " ";
                            var message = new Message
                            {
                                Subject = subject
                            };

                            {
                                var mailMessage = message.AsMailMessage();
                                Assert.AreEqual(
                                    expected: "No Subject",
                                    actual: mailMessage.Subject);
                            }

                            {
                                var mailMessage = message.AsMailMessage(dontSanitizeSubject: true);
                                Assert.AreEqual(
                                    expected: " ",
                                    actual: mailMessage.Subject);
                            }
                        }

                    }

                    {
                        var message = new Message();

                        var mailMessage = message.AsMailMessage();
                        Assert.IsNull(mailMessage.From);
                    }

                    {
                        {
                            var message = new Message
                            {
                                To = default(IEnumerable<Address>)
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.To.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                To = Enumerable.Empty<Address>()
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.To.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                To = new[] {
                                    (Address)null
                                }
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.To.Count == 0);
                        }

                    }

                    {
                        {
                            var message = new Message
                            {
                                CC = default(IEnumerable<Address>)
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.CC.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                CC = Enumerable.Empty<Address>()
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.CC.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                CC = new[] {
                                    (Address)null
                                }
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.CC.Count == 0);
                        }

                    }

                    {
                        {
                            var message = new Message
                            {
                                Bcc = default(IEnumerable<Address>)
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.Bcc.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                Bcc = Enumerable.Empty<Address>()
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.Bcc.Count == 0);
                        }

                        {
                            var message = new Message
                            {
                                Bcc = new[] {
                                    (Address)null
                                }
                            };

                            var mailMessage = message.AsMailMessage();
                            Assert.IsTrue(mailMessage.Bcc.Count == 0);
                        }

                    }

                }

            }
        }
    }
}
