using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureStorage.Queue;

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
        public static void RegisterEmailSenderViaAzureQueueMessageProducer(this ContainerBuilder container, string connectionString, string queueName = "emailsqueue")
        {
            var messageProducer = new EmailMessageQueueProducer(new AzureQueueExt(connectionString, queueName));
            var emailSender = new EmailSender(messageProducer);
            container.RegisterInstance<IEmailMessageProducer>(new EmailMessageQueueProducer(new AzureQueueExt(connectionString, queueName)));
        }
    }
}
