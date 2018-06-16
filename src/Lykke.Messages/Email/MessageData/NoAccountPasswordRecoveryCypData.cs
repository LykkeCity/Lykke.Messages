namespace Lykke.Messages.Email.MessageData
{
    public class NoAccountPasswordRecoveryCypData : IEmailMessageData
    {
        public const string QueueName = "NoAccountPasswordRecoveryCypEmail";

        public string Email { get; set; }
    }
}
