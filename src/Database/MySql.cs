using System;

namespace JasonPereira84.AppSettings
{
    namespace Database
    {
        public class MySql : _Base
        {
            public Boolean? AllowUserVariables { get; set; } = default(Boolean);

            public Boolean? PersistSecurityInfo { get; set; } = default(Boolean);
        }
    }
}
