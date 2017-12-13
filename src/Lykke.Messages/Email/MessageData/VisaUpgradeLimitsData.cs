namespace Lykke.Messages.Email.MessageData
{
    public class VisaUpgradeLimitsData : IEmailMessageData
    {
        public const string QueueName = "VisaUpgradeLimits";
        public string Title { get; set; }
        public string Message { get; set; }
        public string Year { get; set; }
    }
}
