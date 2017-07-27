namespace Lykke.Messages.Email.MessageData
{
    public class NoRefundOCashOutData : IEmailMessageData
    {
        public const string QueueName = "NoRefundOCashOutEmail";

        public string AssetId { get; set; }
        public double Amount { get; set; }
        public string SrcBlockchainHash { get; set; }
    }
}
