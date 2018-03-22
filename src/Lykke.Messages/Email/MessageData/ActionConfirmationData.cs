namespace Lykke.Messages.Email.MessageData
{
    public class ActionConfirmationData : IEmailMessageData
    {
        public const string QueueName = "ActionConfirmation";

        public string ClientName { get; set; }
        public string Ip { get; set; }
        public string ConfirmationLink { get; set; }
    }
}