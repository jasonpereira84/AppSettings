using System;
using System.Net.Mail;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static MailAddress AsMailAddress(this SMTP.Address address, Boolean dontSanitizeDisplayName = false)
        {
            if (address.Value == null)
                throw new ArgumentNullException($"{nameof(address)}.{nameof(address.Value)}");
            if (address.Value.Length == 0)
                throw new ArgumentException($"The value of '{nameof(address)}.{nameof(address.Value)}' cannot be an empty string.", $"{nameof(address)}.{nameof(address.Value)}");
            if ((address.Value = address.Value.Trim()).Length == 0)
                throw new FormatException($"The value of '{nameof(address)}.{nameof(address.Value)}' is not in the form required for an e-mail address. (Parameter '{nameof(address)}.{nameof(address.Value)}')");
            return dontSanitizeDisplayName || !String.IsNullOrWhiteSpace(address.DisplayName)
                ? new MailAddress(address.Value, address.DisplayName)
                : new MailAddress(address.Value);
        }

    }
}
