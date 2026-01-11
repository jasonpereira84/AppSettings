using System;

namespace JasonPereira84.AppSettings
{
    public interface IObjectStore
    {
        Server Server { get; set; }
        String Bucket { get; set; }
        Boolean Ssl { get; set; }
    }

    public partial class ObjectStore : IObjectStore
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Server Server { get; set; }
        public String Bucket { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Boolean Ssl { get; set; }
    }
}
