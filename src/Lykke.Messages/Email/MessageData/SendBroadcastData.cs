using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Messages.Email.MessageData
{
    public class SendBroadcastData<T> : IEmailMessageData
    {
        public string PartnerId { get; set; }
        public BroadcastGroup BroadcastGroup { get; set; }
        public T MessageData { get; set; }

        public static SendBroadcastData<T> Create(BroadcastGroup broadcastGroup, T msgData)
        {
            return new SendBroadcastData<T>
            {
                BroadcastGroup = broadcastGroup,
                MessageData = msgData
            };
        }
    }
}
