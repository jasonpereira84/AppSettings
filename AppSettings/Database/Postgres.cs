using System;
using System.Text;

namespace JasonPereira84.AppSettings
{
    public partial class Database
    {
        public class Postgres : Database, IDatabase
        {
            public Boolean IncludeErrorDetail { get; set; }
            protected String _includeErrorDetail => $"{IncludeErrorDetail}".ToLower();

            public Boolean Pooling { get; set; }
            protected String _pooling => $"{Pooling}".ToLower();

            public String SslMode { get; set; } = "Require";

            public String ConnectionString => new StringBuilder($"Host={Server.Endpoint.Host};Port={Server.Endpoint.Port};")
                .Append($"Database={Name};Username={Server.Credentials.Id};Password={Server.Credentials.Secret};")
                .Append($"Include Error Detail={_includeErrorDetail};Pooling={_pooling};SSL Mode={SslMode};")
                .ToString();
        }
    }
}
