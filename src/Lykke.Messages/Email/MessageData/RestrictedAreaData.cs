namespace Lykke.Messages.Email.MessageData
{
    public class RestrictedAreaData : IEmailMessageData
    {
        public const string QueueName = "RestrictedAreaEmail";


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Year { get; set; }
    }
}
