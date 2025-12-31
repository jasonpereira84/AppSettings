using System;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public class Kestrel
    {
        public Dictionary<String, Certificate> Certificates { get; set; } = new Dictionary<String, Certificate>();
    }
}
