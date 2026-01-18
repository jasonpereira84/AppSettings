using System;

namespace JasonPereira84.AppSettings
{
    public class SecurityToken
    {
        public String Issuer { get; set; }

        protected String _audience;
        public String Audience
        {
            set { _audience = value; }
            get
            {
                if (!String.IsNullOrWhiteSpace(_audience))
                    return _audience;

                if (_audiences == null || _audiences.Length == 0)
                    return null;

                return _audiences[0];
            }
        }

        protected String[] _audiences;
        public String[] Audiences
        {
            set {  _audiences = value; }
            get 
            {
                if (_audiences != null || _audiences.Length > 0)
                    return _audiences;

                return String.IsNullOrWhiteSpace(_audience)
                    ? new String[0]
                    : new String[] { _audience };
            }
        }

        public Timespan ExpiresIn { get; set; }

        public String AuthenticationScheme { get; set; }
    }
}