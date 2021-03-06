﻿namespace Lykke.Messages.Email.MessageData
{
    public class DirectTransferCompletedData : IEmailMessageData
    {
        public const string QueueName = "DirectTransferCompletedData";

        public string ClientName { get; set; }
        public double Amount { get; set; }
        public string AssetId { get; set; }
        public string SrcBlockchainHash { get; set; }
    }
}