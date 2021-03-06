﻿namespace Lykke.Messages.Email.MessageData
{
    public class PaymentRequestCompletedMessageData : IEmailMessageData
    {
        public const string QueueName = "PaymentRequestCompletedEmail";

        public string InvoiceNumber { get; set; }
        public decimal AmountReceived { get; set; }
        public string PaymentCurrency { get; set; }
        public string ClientFullName { get; set; }
        public string PaymentDate { get; set; }
        public string InvoiceDetailsLink { get; set; }
        public int Year { get; set; }
    }
}