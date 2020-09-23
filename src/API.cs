using System;

namespace JasonPereira84.AppSettings
{
    public class API
    {
        public String Url { get; set; } = default(String);

        public String Key { get; set; } = default(String);

        public Credentials Credentials { get; set; } = default(Credentials);
    }
}
