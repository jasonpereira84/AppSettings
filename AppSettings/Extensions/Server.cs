using System;
using System.Net;
using System.Linq;
using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static String HasPort(this Server server, Func<UInt16, String> funcIfTrue, Func<String> funcIfFalse = default(Func<String>))
            => HasPort(server.Endpoint, funcIfTrue, funcIfFalse);

        public static SmtpClient AsSmtpClient(this Server server, Boolean enableSsl = true)
            => new SmtpClient
            {
                Host = server.Endpoint.Host,
                Port = server.Endpoint.Port ?? 0,

                EnableSsl = enableSsl,

                Credentials = new NetworkCredential(server.Credentials.Id, server.Credentials.Secret)
            };

    }
}