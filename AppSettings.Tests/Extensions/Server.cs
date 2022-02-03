using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Mail;

namespace JasonPereira84.AppSettings.Tests
{
    namespace Extensions
    {
        [TestClass]
        public class Test_Server
        {
            [TestMethod]
            public void AsSmtpClient()
            {
                {
                    var endpoint = new Endpoint
                    {
                        Host = "host",
                        Port = 1
                    };
                    var credentials = new Credentials
                    {
                        Id = "henry",
                        Secret = "fonda",
                        Domain = "domain"
                    };
                    var server = new Server
                    {
                        Endpoint = endpoint,
                        Credentials = credentials
                    };

                    var smtpClient = server.AsSmtpClient();
                    Assert.IsNotNull(smtpClient);
                    Assert.AreEqual(
                        expected: endpoint.Host,
                        actual: smtpClient.Host);
                    Assert.IsTrue(smtpClient.EnableSsl);
                    Assert.AreEqual(
                        expected: (Int32)endpoint.Port,
                        actual: smtpClient.Port);
                    var networkCredential = smtpClient.Credentials as NetworkCredential;
                    Assert.IsNotNull(networkCredential);
                    Assert.AreEqual(
                        expected: credentials.Id,
                        actual: networkCredential.UserName);
                    Assert.AreEqual(
                        expected: credentials.Secret,
                        actual: networkCredential.Password);
                    Assert.AreEqual(
                        expected: credentials.Domain,
                        actual: networkCredential.Domain);
                }

                {
                    var server = new Server();

                    Assert.ThrowsException<ArgumentNullException>(
                        () => server.AsSmtpClient());
                }

                {
                    {
                        var server = new Server
                        {
                            Endpoint = new Endpoint
                            {
                                Host = default(String)
                            }
                        };

                        Assert.ThrowsException<ArgumentNullException>(
                            () => server.AsSmtpClient());
                    }

                    {
                        var server = new Server
                        {
                            Endpoint = new Endpoint
                            {
                                Host = ""
                            }
                        };

                        Assert.ThrowsException<ArgumentException>(
                            () => server.AsSmtpClient());
                    }

                }

                {
                    var server = new Server
                    {
                        Endpoint = new Endpoint
                        {
                            Host = "host"
                        }
                    };

                    var smtpClient = server.AsSmtpClient();
                    Assert.AreEqual(
                        expected: 25,
                        actual: smtpClient.Port);
                }

                {
                    {
                        var server = new Server
                        {
                            Endpoint = new Endpoint
                            {
                                Host = "host"
                            }
                        };

                        var smtpClient = server.AsSmtpClient();
                        Assert.IsNull(server.Credentials);
                    }

                }

            }

        }
    }
}
