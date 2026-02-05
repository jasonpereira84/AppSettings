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
        public Server Server { get; set; }
        public String Bucket { get; set; }
        public Boolean Ssl { get; set; }
    }
}
