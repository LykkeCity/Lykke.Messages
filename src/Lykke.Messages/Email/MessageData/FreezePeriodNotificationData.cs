using System;

namespace Lykke.Messages.Email.MessageData
{
    public class FreezePeriodNotificationData : IEmailMessageData
    {
        public DateTime FreezePeriod { get; set; }
        public string Year { get; set; }

        public const string QueueName = "FreezePeriodNotificationEmail";        
    }
}