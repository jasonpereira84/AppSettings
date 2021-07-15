using System;
using System.Xml;
using System.ComponentModel;
using System.Xml.Serialization;

namespace JasonPereira84.AppSettings
{
    namespace Database
    {
        public abstract class _Base
        {
            public String Name { get; set; } = default(String);

            public String Provider { get; set; } = default(String);

            public Server Server { get; set; } = default(Server);
        }
    }
}
