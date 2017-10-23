using System;
using Autofac;
using AzureStorage;
using AzureStorage.Blob;
using AzureStorage.Queue;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Messages.Email
{
    public static class AutofacExtensions
    {
        /// <summary>
        /// Registers <see cref="IEmailSender"/> that points to Azure queue
        /// </summary>
        /// <param name="builder">Autofac container builder</param>
        /// <param name="connectionStringFunc">Function to extract azure storage connection string where all messaging and templating data lies</param>
        public static void RegisterEmailSenderViaAzureQueueMessageProducer(this ContainerBuilder builder, Func<IComponentContext, IReloadingManager<string>> connectionStringFunc)
        {
            builder.Register(ctx =>
            {
                var log = ctx.Resolve<ILog>();
                var connectionString = connectionStringFunc(ctx);
                var blob = AzureBlobStorage.Create(connectionString);
                var queue = AzureQueueExt.Create(connectionString, Utils.EmailMessageQueueName);
                var validator = new JsonSchemaTemplateDataValidator(blob, Utils.EmailValidationSchemaContainerName);
                var attachmentProducer = new EmailAttachmentProducer(blob, Utils.EmailAttachmentContainerName, log);
                var messageProducer = new EmailMessageQueueProducer(queue);
                return new EmailSender(validator, attachmentProducer, messageProducer);
            }).As<IEmailSender>().SingleInstance();
        }

        /// <summary>
        /// Registers <see cref="IEmailSender"/> that point to inmemory queue
        /// </summary>
        /// <param name="builder">Autofac container builder</param>
        /// <param name="connectionStringFunc">Function to extract azure storage connection string where all messaging and templating data lies</param>
        public static void RegisterEmailSenderMockQueueMessageProducer(this ContainerBuilder builder, Func<IComponentContext, IReloadingManager<string>> connectionStringFunc, IBlobStorage blobMock, IQueueExt queueMock)
        {
            builder.Register(ctx =>
            {
                var log = ctx.Resolve<ILog>();
                var connectionString = connectionStringFunc(ctx);
                var blob = AzureBlobStorage.Create(connectionString);
                var validator = new JsonSchemaTemplateDataValidator(blob, Utils.EmailValidationSchemaContainerName);
                var attachmentProducer = new EmailAttachmentProducer(blobMock, Utils.EmailAttachmentContainerName, log);
                var messageProducer = new EmailMessageQueueProducer(queueMock);
                return new EmailSender(validator, attachmentProducer, messageProducer);
            }).As<IEmailSender>().SingleInstance();
        }
    }
}
