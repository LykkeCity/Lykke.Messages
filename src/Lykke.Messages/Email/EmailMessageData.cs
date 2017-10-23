using System.Collections.Generic;
using System.Linq;
using Common;

namespace Lykke.Messages.Email
{
    internal class EmailMessageData
    {
        public const string QueueName = "EmailMessageData";

        public static EmailMessageData Create(string partnerId, string email, string templateId, IDictionary<string, string> templateData, IEnumerable<EmailAttachmentData> attachments)
        {
            return new EmailMessageData
            {
                PartnerId = partnerId,
                Email = email,
                TemplateId = templateId,
                TemplateData = templateData,
                Attachments = attachments
            };
        }

        public IEnumerable<EmailAttachmentData> Attachments { get; set; }

        public IDictionary<string, string> TemplateData { get; set; }

        public string TemplateId { get; set; }

        public string Email { get; set; }

        public string PartnerId { get; set; }
    }
}