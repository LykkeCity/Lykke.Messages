namespace Lykke.Messages.Email.MessageData
{
    public class UserRegisteredData : IEmailMessageData
    {
        public const string QueueName = "UserRegisteredBroadcast";

        public string ClientId { get; set; }
    }
}
