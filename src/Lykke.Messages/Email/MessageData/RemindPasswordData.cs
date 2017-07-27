namespace Lykke.Messages.Email.MessageData
{
    public class RemindPasswordData : IEmailMessageData
    {
        public const string QueueName = "RemindPasswordEmail";

        public string PasswordHint { get; set; }
    }
}
