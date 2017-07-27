using System.Threading.Tasks;
using Lykke.Messages.Email.MessageData;

namespace Lykke.Messages.Email
{
    internal interface IEmailMessageProducer
    {
        Task ProduceSendEmailCommand<T>(string mailAddress, T msgData) where T: IEmailMessageData;
        Task ProduceSendEmailBroadcast<T>(BroadcastGroup broadcastGroup, T msgData) where T: IEmailMessageData;
    }
}
