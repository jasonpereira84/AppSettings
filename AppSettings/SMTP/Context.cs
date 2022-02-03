using System;

namespace JasonPereira84.AppSettings
{
    public partial class SMTP
    {
        public class Context
        {
            public Server Server { get; set; }

            public Message Message { get; set; }
        }
    }
}
