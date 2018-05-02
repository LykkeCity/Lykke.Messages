namespace Lykke.Messages.Email.MessageData
{
    public class NoAccountPasswordRecoveryData : IEmailMessageData
    {
        public const string QueueName = "NoAccountPasswordRecoveryEmail";

        public string Email { get; set; }
    }
}
