namespace Lykke.Messages.Email.MessageData
{
    public class KycOkData : IEmailMessageData
    {
        public const string QueueName = "WelcomeFxEmail";

        public string ClientId { get; set; }
        public string Year { get; set; }
    }
}
