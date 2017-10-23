using Lykke.Messages.Email;
using Lykke.Messages.Email.MessageData;
using System;
using System.Threading.Tasks;
using Autofac;
using Lykke.SettingsReader;

namespace Lykke.Messages.Utils
{
    class Program
    {
        public const string ClientId = "0dc14d6a-9bdf-47c3-8320-dd12612e7617";
        public const string PartnerId = "AlpineVault";
        //public const string EmailAddress = "yury@batsyuro.ru";
        public const string EmailAddress = "yury.batsyuro@lykke.com";
        //public const string EmailAddress = "test.tiger6@gmail.com";

        static void Main(string[] args)
        {
            var connectionStringReloadingManager = new ConstantReloadingManager<string>("DefaultEndpointsProtocol=https;AccountName=lkedevmain;AccountKey=l0W0CaoNiRZQIqJ536sIScSV5fUuQmPYRQYohj/UjO7+ZVdpUiEsRLtQMxD+1szNuAeJ351ndkOsdWFzWBXmdw==");

            //var connectionStringReloadingManager = new ConstantReloadingManager<string>("UseDevelopmentStorage=true");
            var builder = new ContainerBuilder();
            builder.RegisterEmailSenderViaAzureQueueMessageProducer(ctx => connectionStringReloadingManager);
            var container = builder.Build();
            var sender = container.Resolve<IEmailSender>();

            SendTestEmailConfirmationAsync(sender).Wait();
            SendRegistrationMessageMessageAsync(sender).Wait();
            SendRemindPasswordMessageAsync(sender).Wait();
            SendKycOkMessageAsync(sender).Wait();

            //SendCachInMessageAsync(sender).Wait();
            //SendTestKycDeclined(sender).Wait();
            //SendTestEmailConfirmationAsync(sender).Wait();
            //SendRegistrationEmailVerifyMessageAsync(sender).Wait();
        }

        private static Task SendTestKycDeclined(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new DeclinedDocumentsData
            {
                FullName = "Test User Fullname",
                Documents = new[]
                {
                    new KycDocumentData
                    {
                        ClientId = ClientId,
                        DocumentId = "1234",
                        DateTime = DateTime.Now,
                        DocumentName = "Test Document",
                        FileName = "Test Filename",
                        KycComment = "Test Comment",
                        Mime = "text/plain",
                        State = "Test state",
                        Type = "Plain text document"
                    }
                }
            });
        }

        private static Task SendTestEmailConfirmationAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new EmailComfirmationData
            {
                ConfirmationCode = "1234",
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendRegistrationMessageMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RegistrationMessageData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendKycOkMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new KycOkData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendCachInMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new CashInData
            {
                AssetId = "USD",
                Multisig = "123Multisig456",
            });
        }

        private static Task SendRemindPasswordMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RemindPasswordData
            {
                PasswordHint = "Hello, World!"
            });
        }

        private static Task SendRegistrationEmailVerifyMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync("Lykke", "testds@test.com", new RegistrationEmailVerifyData
            {
                Code = "1234",
                Year = "2017"
            });
        }


    }

    internal class ConstantReloadingManager<T> : ReloadingManagerBase<T>
    {
        private readonly T _value;

        public ConstantReloadingManager(T value)
        {
            _value = value;
        }

        protected override Task<T> Load()
        {
            return Task.FromResult(_value);
        }
    }
}