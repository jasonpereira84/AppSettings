using System;

namespace JasonPereira84.AppSettings
{
    namespace SMTP
    {
        public class Context
        {
            public Server Server { get; set; } = default(Server);

            public Message Message { get; set; } = default(Message);
        }
    }
}
