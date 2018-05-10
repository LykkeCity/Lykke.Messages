namespace Lykke.Messages.Email.MessageData
{
    public class DeclinedDocumentsData : IEmailMessageData
    {
        public const string QueueName = "DeclinedDocuments";

        public string FullName { get; set; }
        public string LykkeKycWebsiteUrl { get; set; }
        public KycDocumentData[] Documents { get; set; }
    }
}
