namespace Lykke.Messages.Email.MessageData
{
    public class PrivateWalletBackupData : IEmailMessageData
    {
        public const string QueueName = "PrivateWalletBackupEmail";

        public string WalletName { get; set; }
        public string WalletAddress { get; set; }
        public string SecurityQuestion { get; set; }
        public string EncodedKey { get; set; }
    }
}
