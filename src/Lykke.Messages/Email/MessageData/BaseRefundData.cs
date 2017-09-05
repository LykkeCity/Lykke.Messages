namespace Lykke.Messages.Email.MessageData
{
    public class BaseRefundData 
    {
        public double Amount { get; set; }
        public string SrcBlockchainHash { get; set; }
        public string RefundTransaction { get; set; }
        public int ValidDays { get; set; }
    }
}
