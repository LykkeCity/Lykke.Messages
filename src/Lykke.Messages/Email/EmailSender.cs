using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lykke.Messages.Email
{
    internal class EmailSender : IEmailSender
    {
        private readonly ITemplateDataValidator _validator;
        private readonly IEmailMessageProducer _messageProducer;
        private readonly IEmailAttachmentProducer _attachmentProducer;

        public EmailSender(ITemplateDataValidator validator, IEmailAttachmentProducer attachmentProducer, IEmailMessageProducer messageProducer)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _messageProducer = messageProducer ?? throw new ArgumentNullException(nameof(messageProducer));
            _attachmentProducer = attachmentProducer ?? throw new ArgumentNullException(nameof(attachmentProducer));
        }

        public async Task SendEmailAsync<T>(string partnerId, string email, T msgData) where T : IEmailMessageData
        {
            await _messageProducer.ProduceSendEmailCommand(partnerId, email, msgData);
        }

        public async Task SendEmailAsync(string partnerId, string email, string templateId, IDictionary<string, string> msgData, IEnumerable<EmailAttachment> attachments)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(email));
            if (string.IsNullOrWhiteSpace(templateId))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(templateId));

            await _validator.AssertValid(templateId, msgData);
            IEnumerable<EmailAttachmentData> attachmentsData = null == attachments ? null : await Task.WhenAll(attachments.Select(_attachmentProducer.SaveAttachmentAsync));
            await _messageProducer.ProduceSendEmailCommand(partnerId, email, templateId, msgData, attachmentsData);
        }

        public async Task SendEmailBroadcastAsync<T>(string partnerId, BroadcastGroup broadcastGroup, T messageData) where T : IEmailMessageData
        {
            await _messageProducer.ProduceSendEmailBroadcast(partnerId, broadcastGroup, messageData);
        }
    }
}
