using System;

namespace Lykke.Messages.Email.MessageData
{
    public class FreezePeriodNotificationData : IEmailMessageData
    {
        public const string QueueName = "FreezePeriodNotificationEmail";

        public DateTime FreezePeriod { get; set; }
        public string Year { get; set; }
    }
}