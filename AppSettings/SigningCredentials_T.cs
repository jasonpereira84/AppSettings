using System;

namespace JasonPereira84.AppSettings
{
    public class SigningCredentials<T>
    {
        public String Algorithm { get; set; } = default(String);

        public String Digest { get; set; } = default(String);

        public T Key { get; set; } = default(T);
    }
}
