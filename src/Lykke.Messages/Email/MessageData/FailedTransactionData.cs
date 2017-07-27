namespace Lykke.Messages.Email.MessageData
{
    public class FailedTransactionData : IEmailMessageData
    {
        public const string QueueName = "FailedTransactionBroadcast";

        public string TransactionId { get; set; }
        public string[] AffectedClientIds { get; set; }
    }
}
