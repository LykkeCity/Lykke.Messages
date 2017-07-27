namespace Lykke.Messages.Email.MessageData
{
    public class PlainTextData : IEmailMessageData
    {
        public const string QueueName = "PlainTextEmail";

        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }


    public class PlainTextBroadCastData : IEmailMessageData
    {
        public const string QueueName = "PlainTextBroadcast";

        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}

