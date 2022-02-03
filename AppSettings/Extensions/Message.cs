using System;
using System.Net.Mail;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    public static partial class Extensions
    {
        public static MailMessage AsMailMessage(this SMTP.Message message,
            MailPriority defaultMailPriority = default(MailPriority), Boolean dontSanitizeSubject = false,
            Boolean dontSanitizeDisplayNameFROM = false,
            Boolean dontSanitizeDisplayNameTO = false, Boolean dontSanitizeDisplayNameCC = false, Boolean dontSanitizeDisplayNameBCC = false)
        {
            var retVal = new MailMessage
            {
                Priority = Enum.TryParse(message.Priority, true, out MailPriority parsedMailPriority) ? parsedMailPriority : defaultMailPriority,
                Subject = dontSanitizeSubject || !String.IsNullOrWhiteSpace(message.Subject) ? message.Subject : "No Subject"
            };
            {
                if (message.From != null)
                    retVal.From = message.From.AsMailAddress(dontSanitizeDisplayNameFROM);

                void _addAddresses(IEnumerable<SMTP.Address> addresses, Boolean dontSanitizeDisplayName, MailAddressCollection mailAddressCollection)
                {
                    if (addresses != null)
                        foreach (var address in addresses)
                            if (address != null)
                                mailAddressCollection.Add(address.AsMailAddress(dontSanitizeDisplayName));
                }
                _addAddresses(message.To, dontSanitizeDisplayNameTO, retVal.To);
                _addAddresses(message.CC, dontSanitizeDisplayNameCC, retVal.CC);
                _addAddresses(message.Bcc, dontSanitizeDisplayNameBCC, retVal.Bcc);
            }
            return retVal;
        }

    }
}
