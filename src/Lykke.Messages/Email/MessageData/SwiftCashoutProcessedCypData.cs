namespace Lykke.Messages.Email.MessageData
{
    public class SwiftCashoutProcessedCypData : IEmailMessageData
    {
        public const string QueueName = "SwiftCashoutProcessedCyp";

        public string FullName { get; set; }
        public string DateOfWithdrawal { get; set; }
        public string Year { get; set; }
    }
}
