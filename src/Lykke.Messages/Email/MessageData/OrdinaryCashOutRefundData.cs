namespace Lykke.Messages.Email.MessageData
{
    public class OrdinaryCashOutRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "OCashOutRefundEmail";

        public string AssetId { get; set; }
    }
}