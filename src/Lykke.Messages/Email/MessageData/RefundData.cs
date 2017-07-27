namespace Lykke.Messages.Email.MessageData
{
    public class BaseRefundData 
    {
        public double Amount { get; set; }
        public string SrcBlockchainHash { get; set; }
        public string RefundTransaction { get; set; }
        public int ValidDays { get; set; }
    }

    public class CashInRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "CashInRefundEmail";
    }

    public class SwapRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "SwapRefundEmail";
    }

    public class OrdinaryCashOutRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "OCashOutRefundEmail";

        public string AssetId { get; set; }
    }
}
