using System.Threading.Tasks;
using Lykke.Messages.Email.MessageData;

namespace Lykke.Messages.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync<T>(string emailAddress, T messageData) where T : IEmailMessageData;
        Task SendEmailBroadcastAsync<T>(BroadcastGroup broadcastGroup, T messageData) where T : IEmailMessageData;
    }

    public static class EmailSenderExt
    {
        public static Task BroadcastEmailAsync(this IEmailSender emailSender, BroadcastGroup broadcastGroup, string subject, string body)
        {
            var model = new PlainTextBroadCastData
            {
                Subject = subject,
                Text = body
            };
            return emailSender.SendEmailBroadcastAsync(broadcastGroup, model);
        } 
    }
}
