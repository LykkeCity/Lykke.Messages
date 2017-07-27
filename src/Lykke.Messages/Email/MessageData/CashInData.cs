namespace Lykke.Messages.Email.MessageData
{
    public class CashInData : IEmailMessageData
    {
        public const string QueueName = "CashInEmail";

        public string Multisig { get; set; }
        public string AssetId { get; set; }
    }
}
