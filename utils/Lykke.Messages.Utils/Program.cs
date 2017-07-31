using Lykke.Messages.Email;
using Lykke.Messages.Email.MessageData;
using System;
using System.Threading.Tasks;
using Autofac;

namespace Lykke.Messages.Utils
{
    class Program
    {
        public const string ClientId = "0dc14d6a-9bdf-47c3-8320-dd12612e7617";
        public const string PartnerId = "AlpineVault";
        public const string EmailAddress = "yury@batsyuro.ru";

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterEmailSenderViaAzureQueueMessageProducer("DefaultEndpointsProtocol=https;AccountName=lkedevmain;AccountKey=l0W0CaoNiRZQIqJ536sIScSV5fUuQmPYRQYohj/UjO7+ZVdpUiEsRLtQMxD+1szNuAeJ351ndkOsdWFzWBXmdw==", "emailsqueue-pe");
            var container = builder.Build();
            var sender = container.Resolve<IEmailSender>();

            SendTestWelcomeMessage(sender).Wait();
        }

        private static async Task SendTestWelcomeMessage(IEmailSender sender)
        {
            await sender.SendEmailAsync(PartnerId, EmailAddress, new RegistrationMessageData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

    }
}