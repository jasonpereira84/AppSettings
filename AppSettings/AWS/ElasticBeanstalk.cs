using System;

namespace JasonPereira84.AppSettings
{
    namespace AWS
    {
        public class ElasticBeanstalk
        {
            public String ApplicationName { get; set; } = default(String);

            public String EnvironmentName { get; set; } = default(String);
        }
    }
}
