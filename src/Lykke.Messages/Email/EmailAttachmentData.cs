using System.ComponentModel.DataAnnotations;

namespace Lykke.Messages.Email
{
    public class EmailAttachmentData
    {
        public static EmailAttachmentData Create(string fileId, string fileName, string contentType, string encodingWebName)
        {
            return new EmailAttachmentData
            {
                FileId = fileId,
                FileName = fileName,
                ContentType = contentType,
                EncodingWebName = encodingWebName
            };
        }

        public string FileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string EncodingWebName { get; set; }
    }
}