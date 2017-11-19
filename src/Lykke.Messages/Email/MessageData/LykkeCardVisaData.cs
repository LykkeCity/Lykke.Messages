namespace Lykke.Messages.Email.MessageData
{
    public class LykkeCardVisaData : IEmailMessageData
    {
        public const string QueueName = "LykkeCardVisa";

        public string Url { get; set; }
        public int Year { get; set; }
    }
}
