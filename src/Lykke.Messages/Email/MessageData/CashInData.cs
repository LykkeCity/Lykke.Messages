using System;

namespace Lykke.Messages.Email.MessageData
{
    public class CashInData : IEmailMessageData
    {
        public const string QueueName = "CashInEmail";


        public string Address { get; set; }
        
        public string AddressExtension { get; set; }

        public string AddressExtensionName { get; set; }

        public string AddressName { get; set; }

        public string AssetId { get; set; }

        [Obsolete]
        public string Multisig { get; set; }
    }
}
