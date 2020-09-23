using System;
using System.Linq;

namespace JasonPereira84.AppSettings
{
    public partial class Okta
    {
        public class WsFederation
        {
            public String Id { get; set; } = default(String);

            public String Host { get; set; } = default(String);

            public String Origin { get; set; } = default(String);
        }
    }
}