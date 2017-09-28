using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureStorage.Queue;
using Lykke.SettingsReader;

namespace Lykke.Messages.Email
{
    public static class AutofacExtensions
    {
        /// <summary>
        /// Registers <see cref="IEmailSender"/> that point to Azure queue
        /// </summary>
        /// <param name="container"></param>
        /// <param name="connectionString">Queue connection string</param>
        /// <param name="queueName">Queue name</param>
        public static void RegisterEmailSenderViaAzureQueueMessageProducer(this ContainerBuilder container, IReloadingManager<string> connectionString, string queueName = "emailsqueue")
        {
            var messageProducer = new EmailMessageQueueProducer(AzureQueueExt.Create(connectionString, queueName));
            var emailSender = new EmailSender(messageProducer);
            container.RegisterInstance<IEmailSender>(emailSender);
        }

        /// <summary>
        /// Registers <see cref="IEmailSender"/> that point to inmemory queue
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterEmailSenderViaInmemoryQueueMessageProducer(this ContainerBuilder container)
        {
            var messageProducer = new EmailMessageQueueProducer(new QueueExtInMemory());
            var emailSender = new EmailSender(messageProducer);
            container.RegisterInstance<IEmailSender>(emailSender);
        }
    }
}
