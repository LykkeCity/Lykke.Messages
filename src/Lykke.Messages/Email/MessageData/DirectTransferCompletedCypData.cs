namespace Lykke.Messages.Email.MessageData
{
    public class DirectTransferCompletedCypData : IEmailMessageData
    {
        public const string QueueName = "DirectTransferCompletedCypData";

        public string ClientName { get; set; }
        public double Amount { get; set; }
        public string AssetId { get; set; }
        public string SrcBlockchainHash { get; set; }
    }
}