﻿namespace Lykke.Messages.Email.MessageData
{
    public class PlainTextBroadCastData : IEmailMessageData
    {
        public const string QueueName = "PlainTextBroadcast";

        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}