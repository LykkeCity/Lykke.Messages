﻿namespace Lykke.Messages.Email.MessageData
{
    public class RegistrationCypMessageData : IEmailMessageData
    {
        public const string QueueName = "WelcomeCypEmail";

        public string ClientId { get; set; }
        public string Year { get; set; }
    }
}
