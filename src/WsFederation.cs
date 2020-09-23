using System;

namespace JasonPereira84.AppSettings
{
    public class WsFederation
    {
        public String Realm { get; set; } = default(String);

        public String Issuer { get; set; } = default(String);

        public String Referer { get; set; } = default(String);

        public String Metadata { get; set; } = default(String);

        public String[] Audiences { get; set; } = default(String[]);
    }
}