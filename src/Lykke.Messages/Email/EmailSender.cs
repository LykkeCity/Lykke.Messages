using System.Threading.Tasks;
using Lykke.Messages.Email.MessageData;

namespace Lykke.Messages.Email
{
    internal class EmailSender : IEmailSender
    {
        private readonly IEmailMessageProducer _messageProducer;

        public EmailSender(IEmailMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public async Task SendEmailAsync<T>(string email, T msgData) where T: IEmailMessageData
        {
            await _messageProducer.ProduceSendEmailCommand(email, msgData);
        }

        public async Task SendEmailBroadcastAsync<T>(BroadcastGroup broadcastGroup, T messageData) where T : IEmailMessageData
        {
            await _messageProducer.ProduceSendEmailBroadcast(broadcastGroup, messageData);
        }
    }
}
