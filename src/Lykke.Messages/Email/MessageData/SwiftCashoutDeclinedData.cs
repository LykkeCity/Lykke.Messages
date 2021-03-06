﻿namespace Lykke.Messages.Email.MessageData
{
    public class SwiftCashoutDeclinedData : IEmailMessageData
    {
        public const string QueueName = "SwiftCashoutDeclined";

        public string FullName { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
    }
}
