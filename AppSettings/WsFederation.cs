using System;

namespace JasonPereira84.AppSettings
{
    public class WsFederation
    {
        public String Realm { get; set; }

        public String Issuer { get; set; }

        public String Referer { get; set; }

        public String Metadata { get; set; }

        public String[] Audiences { get; set; }
    }
}