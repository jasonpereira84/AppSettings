using System;

namespace JasonPereira84.AppSettings
{
    public class Server
    {
        public Endpoint Endpoint { get; set; } = default(Endpoint);

        public Credentials Credentials { get; set; } = default(Credentials);
    }
}