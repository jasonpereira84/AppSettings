using System;

namespace JasonPereira84.AppSettings
{
    namespace SMTP
    {
        public class Message
        {
            public String Priority { get; set; } = default(String);

            public String Subject { get; set; } = default(String);

            public Address From { get; set; } = default(Address);

            public Address[] To { get; set; } = default(Address[]);

            public Address[] CC { get; set; } = default(Address[]);

            public Address[] Bcc { get; set; } = default(Address[]);
        }
    }
}
