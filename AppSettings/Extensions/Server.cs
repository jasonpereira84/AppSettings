using System;
using System.Net;
using System.Net.Mail;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static SmtpClient AsSmtpClient(this Server server, Boolean dontEnableSsl = false)
        {
            if (server.Endpoint == null)
                throw new ArgumentNullException($"{nameof(server)}.{nameof(server.Endpoint)}");
            if (server.Endpoint.Host == null)
                throw new ArgumentNullException($"{nameof(server)}.{nameof(server.Endpoint)}.{nameof(server.Endpoint.Host)}");
            if (server.Endpoint.Host.Length == 0)
                throw new ArgumentException($"The value of '{nameof(server)}.{nameof(server.Endpoint)}.{nameof(server.Endpoint.Host)}' cannot be an empty string.", $"{nameof(server)}.{nameof(server.Endpoint)}.{nameof(server.Endpoint.Host)}");
            var retVal = new SmtpClient
            {
                Host = server.Endpoint.Host,            
                EnableSsl = !dontEnableSsl
            };
            if (server.Endpoint.Port.HasValue)
                retVal.Port = server.Endpoint.Port.Value;
            if (server.Credentials != null)
                retVal.Credentials = new NetworkCredential(server.Credentials.Id, server.Credentials.Secret, server.Credentials.Domain);
            return retVal;
        }

    }
}