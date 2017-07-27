namespace Lykke.Messages.Email.MessageData
{
    public class NoRefundDepositDoneData : IEmailMessageData
    {
        public const string QueueName = "NoRefundDepositDoneEmail";

        public string AssetBcnId { get; set; }
        public double Amount { get; set; }
    }
}
