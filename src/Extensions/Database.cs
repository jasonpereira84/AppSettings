using System;
using System.Linq;
using System.Text;

namespace JasonPereira84.AppSettings
{
    using Internal;
    using Database;

    public static partial class Extensions
    {
        public static String HasPort<TDatabase>(this TDatabase database, Func<UInt16, String> funcIfTrue, Func<String> funcIfFalse = default(Func<String>))
            where TDatabase : _Base
            => HasPort(database.Server, funcIfTrue, funcIfFalse);

        public static String AsConnectionString(this MySql mySql)
            => new StringBuilder($"Database={mySql.Name};")
                .Append($"Server={mySql.Server.Endpoint.Host};{mySql.Server.HasPort(port => $"Port={port};")}")
                .Append($"User Id={mySql.Server.Credentials.Id};Password={mySql.Server.Credentials.Secret};")
                .Append(mySql.PersistSecurityInfo.HasValue(value => $"PersistSecurityInfo={value};"))
                .Append(mySql.AllowUserVariables.HasValue(value => $"AllowUserVariables={value};"))
                .ToString();

        public static String AsConnectionString(this SqlServer sqlServer)
            => new StringBuilder($"Database={sqlServer.Name};")
                .Append($"Server={sqlServer.Server.Endpoint.Host}{sqlServer.Server.HasPort(port => $",{port}")};")
                .Append($"{sqlServer.Server.Credentials.HasId(id => $"User Id={id};")}{sqlServer.Server.Credentials.HasSecret(secret => $"User Id={secret};")}")
                .Append(sqlServer.IntegratedSecurity.HasValue(value => $"IntegratedSecurity={value};"))
                .Append(sqlServer.PersistSecurityInfo.HasValue(value => $"PersistSecurityInfo={value};"))
                .ToString();
    }
}