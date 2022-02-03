using System;

namespace JasonPereira84.AppSettings
{
    public partial class SOAP
    {
        public class ServiceEndpoint
        {
            public String Name { get; set; }

            public String Address { get; set; }

            public TimeSpan Timeout { get; set; }
        }
    }
}
