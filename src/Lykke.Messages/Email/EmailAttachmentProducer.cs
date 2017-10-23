using System;
using System.Threading.Tasks;
using AzureStorage;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Messages.Email
{
    public class EmailAttachmentProducer : IEmailAttachmentProducer
    {
        private readonly IBlobStorage _blob;
        private readonly string _containerName;
        private readonly ILog _log;
        private readonly int _errorCooldownInMinutes;

        public EmailAttachmentProducer(IBlobStorage blob, string containerName, ILog log, int errorCooldownInMinutes = 15)
        {
            _blob = blob;
            _containerName = containerName;
            _log = log;
            _errorCooldownInMinutes = errorCooldownInMinutes;
        }

        public async Task<EmailAttachmentData> SaveAttachmentAsync(EmailAttachment attachment)
        {
            if (null == attachment)
                return null;
            await _blob.CreateContainerIfNotExistsAsync(_containerName);
            var nextErrorLog = DateTime.MinValue;
            while (true)
            {
                try
                {
                    var fileId = Guid.NewGuid().ToString();
                    await attachment.SaveToBlobAsync(_blob, _containerName, fileId);
                    return EmailAttachmentData.Create(fileId, attachment.FileName, attachment.ContentType, attachment.EncodingWebName);
                }
                catch (Exception ex)
                {
                    if (nextErrorLog < DateTime.Now)
                    {
                        await _log.WriteErrorAsync(nameof(Email), nameof(EmailAttachmentProducer), nameof(SaveAttachmentAsync), ex);
                        nextErrorLog = DateTime.UtcNow.AddMinutes(_errorCooldownInMinutes);
                    }
                }
            }
        }
    }
}