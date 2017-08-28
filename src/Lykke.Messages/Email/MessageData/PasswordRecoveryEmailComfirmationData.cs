namespace Lykke.Messages.Email.MessageData
{    
    public class PasswordRecoveryEmailComfirmationData : IEmailMessageData
    {
        public string ConfirmationCode { get; set; }
        public string Year { get; set; }

        public const string QueueName = "PasswordRecoveryConfirmationEmail";        
    }    
}