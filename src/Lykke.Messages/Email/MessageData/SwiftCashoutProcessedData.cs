namespace Lykke.Messages.Email.MessageData
{
    public class SwiftCashoutProcessedData : IEmailMessageData
    {
        public const string QueueName = "SwiftCashoutProcessed";

        public string FullName { get; set; }
        public string DateOfWithdrawal { get; set; }
        public string Year { get; set; }
    }
}
