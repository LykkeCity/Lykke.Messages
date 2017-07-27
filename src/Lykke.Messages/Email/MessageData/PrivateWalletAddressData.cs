namespace Lykke.Messages.Email.MessageData
{
    public class PrivateWalletAddressData : IEmailMessageData
    {
        public const string QueueName = "PrivateWalletAddressEmail";

        public string Address { get; set; }
        public string Name { get; set; }
    }
}
