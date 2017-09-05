namespace Lykke.Messages.Email.MessageData
{
    public class CashInRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "CashInRefundEmail";
    }
}