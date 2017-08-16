namespace Lykke.Messages.Email.MessageData
{
    public class RequestForDocumentData : IEmailMessageData
    {
        public const string QueueName = "RequestForDocument";

        public string ClientId { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string Amount { get; set; }
        public string AssetId { get; set; }
        public string Year { get; set; }
    }
}
