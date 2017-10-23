using System.Threading.Tasks;

namespace Lykke.Messages.Email
{
    internal interface IEmailAttachmentProducer
    {
        Task<EmailAttachmentData> SaveAttachmentAsync(EmailAttachment arg);
    }
}