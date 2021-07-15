using System;

namespace JasonPereira84.AppSettings
{
    namespace SOAP
    {
        public class ServiceEndpoint
        {
            public String Name { get; set; } = default(String);

            public String Address { get; set; } = default(String);

            public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
        }
    }
}
