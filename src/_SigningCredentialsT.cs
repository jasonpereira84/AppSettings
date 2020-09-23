using System;

namespace JasonPereira84.AppSettings
{
    public abstract class _SigningCredentials<T>
    {
        public String Algorithm { get; set; } = default(String);

        public String Digest { get; set; } = default(String);

        public T Key { get; set; } = default(T);
    }
}
