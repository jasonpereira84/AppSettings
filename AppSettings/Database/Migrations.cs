using System;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public partial class Database
    {
        public class Migrations<TDatabase>
            where TDatabase : IDatabase
        {
            public class Pair
            {
                public Boolean Secure { get; set; }
                public String Value { get; set; }
            }

            public String Path { get; set; }
            public TDatabase Database { get; set; }
            public String JournalTableName { get; set; }
            public Dictionary<String, Pair> Variables { get; set; }
        }

        public class Migrations : Migrations<Database> { }
    }
}
