namespace Lykke.Messages.Email.MessageData
{
    public class SwiftCashoutProcessedData : IEmailMessageData
    {
        public const string QueueName = "SwiftCashoutProcessed";

        public string AssetId { get; set; }
        public double Amount { get; set; }
        public string FullName { get; set; }
        public string Bic { get; set; }
        public string AccNum { get; set; }
        public string AccName { get; set; }
        public string BankName { get; set; }
        public string AccHolderAddress { get; set; }
        public string Year { get; set; }
    }
}
