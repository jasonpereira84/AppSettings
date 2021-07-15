using System;

namespace JasonPereira84.AppSettings
{
    namespace Database
    {
        public class SqlServer : _Base
        {
            public Boolean? IntegratedSecurity { get; set; } = default(Boolean?);

            public Boolean? PersistSecurityInfo { get; set; } = default(Boolean);
        }
    }
}
