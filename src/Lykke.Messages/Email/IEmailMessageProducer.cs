using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Messages.Email.MessageData;

namespace Lykke.Messages.Email
{
    internal interface IEmailMessageProducer
    {
        Task ProduceSendEmailCommand<T>(string partnerId, string mailAddress, T msgData) where T : IEmailMessageData;
        Task ProduceSendEmailCommand(string partnerId, string email, string templateId, IDictionary<string, string> msgData, IEnumerable<EmailAttachmentData> attachments);

        Task ProduceSendEmailBroadcast<T>(string partnerId, BroadcastGroup broadcastGroup, T msgData) where T: IEmailMessageData;
    }
}
