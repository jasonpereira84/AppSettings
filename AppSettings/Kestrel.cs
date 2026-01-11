using System;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public class Kestrel
    {
        public UInt16 HttpPort { get; set; }

        public UInt16 HttpsPort { get; set; }

        public Dictionary<String, Certificate> Certificates { get; set; } = new Dictionary<String, Certificate>();
    }
}
