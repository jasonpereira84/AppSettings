using System;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public partial class ObjectStore
    {
        public class Migrations
        {
            public class Pair
            {
                public Boolean Secure { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
                public String Value { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public String Path { get; set; }
            public ObjectStore ObjectStore { get; set; }
            public String JournalObjectName { get; set; }
            public Dictionary<String, Pair> Variables { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        }
    }
}
