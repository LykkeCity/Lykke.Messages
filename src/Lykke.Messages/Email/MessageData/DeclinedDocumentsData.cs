namespace Lykke.Messages.Email.MessageData
{
    public class DeclinedDocumentsData : IEmailMessageData
    {
        public const string QueueName = "DeclinedDocuments";

        public string FullName { get; set; }
        public KycDocument[] Documents { get; set; }
    }
}
