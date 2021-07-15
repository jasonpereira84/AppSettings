using System;
using System.Net.Mail;

namespace JasonPereira84.AppSettings
{
    using SMTP;

    public static partial class Extensions
    {
        public static MailAddress AsMailAddress(this Address address, Boolean dontSanitizeDisplayName = false)
        {
            if (dontSanitizeDisplayName)
                return new MailAddress(address.Value, address.DisplayName);

            var displayName_EVAL = address.DisplayName.EvaluateSanity();
            return !displayName_EVAL.IsSane ? new MailAddress(address.Value)
                : new MailAddress(address.Value, displayName_EVAL.Value);
        }

        public static MailAddressCollection AddAddress(this MailAddressCollection mailAddressCollection, Address address, Boolean dontSanitizeDisplayName = false)
        {
            if (address != null)
                mailAddressCollection.Add(
                    address.AsMailAddress(dontSanitizeDisplayName));
            return mailAddressCollection;
        }

    }
}
