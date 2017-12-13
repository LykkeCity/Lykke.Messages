﻿namespace Lykke.Messages.Email.MessageData
{
    public class VisaShippingInfoData : IEmailMessageData
    {
        public const string QueueName = "VisaShippingInfo";
        public string TrackingId { get; set; }
        public string TrackingUrl { get; set; }
        public string Year { get; set; }
    }
}
