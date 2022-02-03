using System;

namespace JasonPereira84.AppSettings
{
    public class SigningCredentials<T>
    {
        public String Algorithm { get; set; }

        public String Digest { get; set; }

        public T Key { get; set; }
    }
}
