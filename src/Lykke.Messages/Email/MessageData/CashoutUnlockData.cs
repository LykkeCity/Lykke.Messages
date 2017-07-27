namespace Lykke.Messages.Email.MessageData
{
    public class CashoutUnlockData: IEmailMessageData
    {
        public string Code { get; set; }

        public string ClientId { get; set; }

        public string MessageId()
        {
            return "CashoutUnlockEmail";
        }
    }
}
