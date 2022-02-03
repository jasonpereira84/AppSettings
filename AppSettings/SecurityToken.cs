using System;

namespace JasonPereira84.AppSettings
{
    public class SecurityToken
    {
        public String Issuer { get; set; }

        public String Audience { get; set; }

        public Timespan ExpiresIn { get; set; }
    }
}