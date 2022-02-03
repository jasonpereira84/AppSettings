using System;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public partial class SMTP
    {
        public class Message
        {
            public String Priority { get; set; }

            public String Subject { get; set; }

            public Address From { get; set; }

            public IEnumerable<Address> To { get; set; }

            public IEnumerable<Address> CC { get; set; }

            public IEnumerable<Address> Bcc { get; set; }
        }
    }
}
