namespace Lykke.Messages.Email.MessageData
{
    public class SwapRefundData : BaseRefundData, IEmailMessageData
    {
        public const string QueueName = "SwapRefundEmail";
    }
}