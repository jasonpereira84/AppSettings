using System;

namespace JasonPereira84.AppSettings
{
    public partial class Certificate
    {
        public class Pfx : Certificate, ICertificate
        {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public String Password { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        }
    }
}
