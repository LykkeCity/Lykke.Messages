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
        public const string EmailAddress = "yury@batsyuro.ru";

        static void Main(string[] args)
        {
            var connectionStringReloadingManager = new ConstantReloadingManager<string>("DefaultEndpointsProtocol=https;AccountName=lkedevmain;AccountKey=l0W0CaoNiRZQIqJ536sIScSV5fUuQmPYRQYohj/UjO7+ZVdpUiEsRLtQMxD+1szNuAeJ351ndkOsdWFzWBXmdw==");
            var builder = new ContainerBuilder();
            builder.RegisterEmailSenderViaAzureQueueMessageProducer(connectionStringReloadingManager, "emailsqueue");
            var container = builder.Build();
            var sender = container.Resolve<IEmailSender>();

            SendBankCashInAsync(sender).Wait();
            SendCachInAsync(sender).Wait();
            SendCashInRefundAsync(sender).Wait();
            SendCashoutUnlockAsync(sender).Wait();
            SendDeclinedDocuments(sender).Wait();
            SendDirectTransferCompletedAsync(sender).Wait();
            SendEmailConfirmationAsync(sender).Wait();
            SendFailedTransactionAsync(sender).Wait();
            SendFreezePeriodNotificationAsync(sender).Wait();
            SendKycOkAsync(sender).Wait();
            SendMyLykkeCashInAsync(sender).Wait();
            SendNoRefundDepositDoneAsync(sender).Wait();
            SendNoRefundOCashOutAsync(sender).Wait();
            SendPasswordRecoveryEmailComfirmationAsync(sender).Wait();
            SendPlainTextAsync(sender).Wait();
            SendPrivateWalletAddressAsync(sender).Wait();
            SendPrivateWalletBackupAsync(sender).Wait();
            SendRegistrationEmailVerifyAsync(sender).Wait();
            SendRegistrationMessageAsync(sender).Wait();
            SendRejectedAsync(sender).Wait();
            SendRemindPasswordAsync(sender).Wait();
            SendRequestForDocumentAsync(sender).Wait();
            SendRequestForExpiredDocumentAsync(sender).Wait();
            SendSolarCashOutAsync(sender).Wait();
            SendSolarCoinAddressAsync(sender).Wait();
            SendSwapRefundAsync(sender).Wait();
            SendSwiftCashoutDeclinedAsync(sender).Wait();
            SendSwiftCashoutProcessedAsync(sender).Wait();
            SendSwiftCashOutRequestAsync(sender).Wait();
            SendSwiftConfirmedAsync(sender).Wait();
            SendTransferCompletedAsync(sender).Wait();
            SendUserRegisteredAsync(sender).Wait();
        }

        private static Task SendBankCashInAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new BankCashInData
            {
                ClientId = ClientId,
                Amount = 123,
                AssetId = "USD"
            });
        }

        private static Task SendCachInAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new CashInData
            {
                AssetId = "USD",
                Multisig = "123Multisig456",
            });
        }

        private static Task SendCashInRefundAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new CashInRefundData
            {
                Amount = 123,
                RefundTransaction = Guid.NewGuid().ToString(),
                SrcBlockchainHash = "lkdsfj2jf29j2-p9j-gf29jfg-2",
                ValidDays = 15
            });
        }

        private static Task SendCashoutUnlockAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new CashoutUnlockData
            {
                ClientId = ClientId,
                Code = "3456"
            });
        }

        private static Task SendDeclinedDocuments(IEmailSender sender)
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

        private static Task SendDirectTransferCompletedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new DirectTransferCompletedData
            {
                Amount = 123,
                AssetId = "USD",
                ClientName = "Test Client Name",
                SrcBlockchainHash = "dfvbg56y4trwe546juymnhbgwhyjtg"
            });
        }

        private static Task SendEmailConfirmationAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new EmailComfirmationData
            {
                ConfirmationCode = "1234",
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendFailedTransactionAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new FailedTransactionData
            {
                AffectedClientIds = new [] {ClientId},
                TransactionId = Guid.NewGuid().ToString()
            });
        }

        private static Task SendFreezePeriodNotificationAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new FreezePeriodNotificationData
            {
                FreezePeriod = DateTime.Now.AddDays(15),
                Year = DateTime.UtcNow.Year.ToString()
            });
        }

        private static Task SendKycOkAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new KycOkData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendMyLykkeCashInAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new MyLykkeCashInData
            {
                Amount = 123,
                AssetId = "USD",
                ConversionWalletAddress = "123456uyjhgewe",
                LkkAmount = 123,
                Price = 1
            });
        }

        private static Task SendNoRefundDepositDoneAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new NoRefundDepositDoneData
            {
                Amount = 123,
                AssetBcnId = "BCNID"
            });
        }

        private static Task SendNoRefundOCashOutAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new NoRefundOCashOutData
            {
                Amount = 123,
                AssetId = "USD",
                SrcBlockchainHash = "324567uikijhgr34567juyhrgq"
            });
        }

        private static Task SendPasswordRecoveryEmailComfirmationAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new PasswordRecoveryEmailComfirmationData
            {
                Year = DateTime.UtcNow.Year.ToString(),
                ConfirmationCode = "9012"
            });
        }

        private static Task SendPlainTextAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new PlainTextData
            {
                Sender = "Test Sender",
                Subject = "Test Subject",
                Text = "Hello, World!"
            });
        }

        private static Task SendPrivateWalletAddressAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new PrivateWalletAddressData
            {
                Address = "dsfgh6u75y4trfwer",
                Name = "Test Name"
            });
        }

        private static Task SendPrivateWalletBackupAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new PrivateWalletBackupData
            {
                EncodedKey = "wegrtj6y45t3redwetgegrw",
                SecurityQuestion = "Some security question?",
                WalletAddress = "fdghjkiuyhrtgefeer5y35",
                WalletName = "Wallet Name"
            });
        }

        private static Task SendRegistrationEmailVerifyAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RegistrationEmailVerifyData
            {
                Code = "5678",
                Year = "2017"
            });
        }

        private static Task SendRegistrationMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RegistrationMessageData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendRejectedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RejectedData { });
        }

        private static Task SendRemindPasswordAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RemindPasswordData
            {
                PasswordHint = "Hello, World!"
            });
        }

        private static Task SendRequestForDocumentAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RequestForDocumentData
            {
                Comment = "Test comment",
                FullName = "Test User Full Name",
                Text = "Test text",
                Year = DateTime.UtcNow.Year.ToString()
            });
        }

        private static Task SendRequestForExpiredDocumentAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RequestForExpiredDocumentData
            {
                FullName = "Test User Full Name",
                Text = "Test Text",
                Year = DateTime.UtcNow.Year.ToString()
            });
        }

        private static Task SendSolarCashOutAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SolarCashOutData
            {
                Amount = 123,
                AddressTo = "32456ukijmhngfbrwrty7564"
            });
        }

        private static Task SendSolarCoinAddressAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SolarCoinAddressData
            {
                Address = "34567ujnhgfvbngy65u64y53t4f"
            });
        }

        private static Task SendSwapRefundAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SwapRefundData
            {
                Amount = 123,
                SrcBlockchainHash = "324567juhgfwrbnh4y343g",
                RefundTransaction = Guid.NewGuid().ToString(),
                ValidDays = 15
            });
        }

        private static Task SendSwiftCashoutDeclinedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SwiftCashoutDeclinedData
            {
                FullName = "Test User Full Name",
                Comment = "Test comment"
            });
        }

        private static Task SendSwiftCashoutProcessedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SwiftCashoutProcessedData
            {
                FullName = "Test User Full Name",
                Year = DateTime.UtcNow.Year.ToString()
            });
        }

        private static Task SendSwiftCashOutRequestAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SwiftCashOutRequestData
            {
                AccHolderAddress = "Test Account Holder Address",
                AccName = "Test Account Name",
                AccNum = "Test Account Number",
                Amount = 123,
                AssetId = "USD",
                ClientId = ClientId,
                BankName = "Test Bank Name",
                Bic = "123456",
                CashOutRequestId = Guid.NewGuid().ToString()
            });
        }

        private static Task SendSwiftConfirmedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new SwiftConfirmedData
            {
                AccHolderAddress = "Test Account Holder Address",
                AccName = "Test Account Name",
                AccNumber = "Test Account Number",
                Amount = 123,
                AssetId = "USD",
                BankName = "Test Bank Name",
                Bic = "123456",
                BlockchainHash = "234567kiumjnhtbgefwfghntj5645",
                Email = EmailAddress
            });
        }

        private static Task SendTransferCompletedAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new TransferCompletedData
            {
                AmountFiat = 123,
                AmountLkk = 123,
                AssetId = "USD",
                ClientName = "Test Client Name",
                Price = 1,
                SrcBlockchainHash = "sdfhh97ghf942g982ghf247g9"
            });
        }

        private static Task SendUserRegisteredAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new UserRegisteredData
            {
                ClientId = ClientId
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