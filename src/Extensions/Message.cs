using System;
using System.Linq;
using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.AppSettings
{
    using SMTP;

    public static partial class Extensions
    {
        public static MailMessage AsMailMessage(this Message message,
            Boolean dontSanitizeDisplayNameFROM = false, Boolean dontSanitizeSubject = false, MailPriority defaultMailPriority = default(MailPriority),
            Boolean dontSanitizeDisplayNameTO = false, Boolean dontSanitizeDisplayNameCC = false, Boolean dontSanitizeDisplayNameBCC = false)
        {
            var from = message.From.AsMailAddress(dontSanitizeDisplayNameFROM);
            var subj = dontSanitizeSubject ? message.Subject : message.Subject.SanitizeTo("No Subject");
            var prty = Enum.TryParse(message.Priority, true, out MailPriority parsedMailPriority) ? parsedMailPriority : defaultMailPriority;

            void _addAddresses(IEnumerable<Address> addresses, Boolean dontSanitizeDisplayName, MailAddressCollection mailAddressCollection)
                => addresses?.Select(addr => mailAddressCollection.AddAddress(addr));

            var mailMessage = new MailMessage { From = from, Subject = subj, Priority = prty };
            _addAddresses(message.To, dontSanitizeDisplayNameTO, mailMessage.To);
            _addAddresses(message.CC, dontSanitizeDisplayNameCC, mailMessage.CC);
            _addAddresses(message.Bcc, dontSanitizeDisplayNameBCC, mailMessage.Bcc);
            return mailMessage;
        }

    }
}
