namespace Lykke.Messages.Email.MessageData
{
    public class EmailComfirmationData : IEmailMessageData
    {
        public const string QueueName = "ConfirmationEmail";

        public string ConfirmationCode { get; set; }
        public string Year { get; set; }
    }
}
