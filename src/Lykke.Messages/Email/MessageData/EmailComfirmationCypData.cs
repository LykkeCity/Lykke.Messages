namespace Lykke.Messages.Email.MessageData
{
    public class EmailComfirmationCypData : IEmailMessageData
    {
        public const string QueueName = "ConfirmationCypEmail";

        public string ConfirmationCode { get; set; }
        public string Year { get; set; }
    }
}