namespace Lykke.Messages.Email.MessageData
{
    public class SwiftCashoutDeclinedCypData : IEmailMessageData
    {
        public const string QueueName = "SwiftCashoutDeclinedCyp";

        public string FullName { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public string Year { get; set; }
    }
}
