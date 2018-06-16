namespace Lykke.Messages.Email.MessageData
{
    public class RemindPasswordCypData : IEmailMessageData
    {
        public const string QueueName = "RemindPasswordCypEmail";

        public string PasswordHint { get; set; }
    }
}