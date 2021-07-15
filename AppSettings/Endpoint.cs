using System;

namespace JasonPereira84.AppSettings
{
    public class Endpoint
    {
        public String Host { get; set; } = default(String);

        public UInt16? Port { get; set; } = default(UInt16?);
    }
}
