﻿namespace Lykke.Messages.Email.MessageData
{
    public class RegistrationEmailVerifyData : IEmailMessageData
    {
        public const string QueueName = "RegistrationVerifyEmail";

        public string Code { get; set; }
        public string Url { get; set; }
        public string Year { get; set; }
    }
}
