﻿namespace Lykke.Messages.Email.MessageData
{
    public class RequestForExpiredDocumentData : IEmailMessageData
    {
        public const string QueueName = "RequestForExpiredDocument";


        public string FullName { get; set; }
        public string Text { get; set; }
        public string Year { get; set; }
    }
}
