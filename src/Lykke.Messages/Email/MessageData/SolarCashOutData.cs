namespace Lykke.Messages.Email.MessageData
{
    public class SolarCashOutData : IEmailMessageData
    {
        public const string QueueName = "SolarCashOut";

        public string AddressTo { get; set; }
        public double Amount { get; set; }
    }
}
