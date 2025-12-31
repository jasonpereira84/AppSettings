using System;

namespace JasonPereira84.AppSettings
{
    public interface IDatabase
    {
        String Name { get; set; }

        String Schema { get; set; }

        String Provider { get; set; }

        Server Server { get; set; }
    }

    public partial class Database : IDatabase
    {
        public String Name { get; set; }

        public String Schema { get; set; }

        public String Provider { get; set; }

        public Server Server { get; set; }
    }
}
