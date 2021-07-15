using System;

namespace JasonPereira84.AppSettings
{
    public class SecurityToken
    {
        public String Issuer { get; set; } = default(String);

        public String Audience { get; set; } = default(String);

        public Timespan ExpiresIn { get; set; } = default(Timespan);
    }
}