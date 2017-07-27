namespace Lykke.Messages.Email.MessageData
{
    public class SolarCoinAddressData : IEmailMessageData
    {
        public const string QueueName = "SolarCoinAddress";

        public string Address { get; set; }
    }
}
