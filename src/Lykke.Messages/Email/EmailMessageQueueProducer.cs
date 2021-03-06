﻿using System;
using System.Threading.Tasks;
using AzureStorage.Queue;
using Lykke.Messages.Email.MessageData;

namespace Lykke.Messages.Email
{
    internal class EmailMessageQueueProducer : IEmailMessageProducer
    {
        private readonly IQueueExt _queueExt;

        public EmailMessageQueueProducer(IQueueExt queueExt)
        {
            _queueExt = queueExt;

            _queueExt.RegisterTypes(
                QueueType.Create(LykkeCardVisaData.QueueName, typeof(QueueRequestModel<SendEmailData<LykkeCardVisaData>>)),
                QueueType.Create(BankCashInData.QueueName, typeof(QueueRequestModel<SendEmailData<BankCashInData>>)),
                QueueType.Create(CashInData.QueueName, typeof(QueueRequestModel<SendEmailData<CashInData>>)),
                QueueType.Create(CashInRefundData.QueueName, typeof(QueueRequestModel<SendEmailData<CashInRefundData>>)),
                QueueType.Create(CashoutUnlockData.QueueName, typeof(QueueRequestModel<SendEmailData<CashoutUnlockData>>)),
                QueueType.Create(DeclinedDocumentsData.QueueName, typeof(QueueRequestModel<SendEmailData<DeclinedDocumentsData>>)),
                QueueType.Create(DirectTransferCompletedData.QueueName, typeof(QueueRequestModel<SendEmailData<DirectTransferCompletedData>>)),
                QueueType.Create(EmailComfirmationData.QueueName, typeof(QueueRequestModel<SendEmailData<EmailComfirmationData>>)),
                QueueType.Create(FailedTransactionData.QueueName, typeof(QueueRequestModel<SendBroadcastData<FailedTransactionData>>)),
                QueueType.Create(FreezePeriodNotificationData.QueueName, typeof(QueueRequestModel<SendBroadcastData<FreezePeriodNotificationData>>)),
                QueueType.Create(KycRegReminderData.QueueName, typeof(QueueRequestModel<SendEmailData<KycRegReminderData>>)),
                QueueType.Create(KycOkData.QueueName, typeof(QueueRequestModel<SendEmailData<KycOkData>>)),
                QueueType.Create(MyLykkeCashInData.QueueName, typeof(QueueRequestModel<SendEmailData<MyLykkeCashInData>>)),
                QueueType.Create(NoRefundDepositDoneData.QueueName, typeof(QueueRequestModel<SendEmailData<NoRefundDepositDoneData>>)),
                QueueType.Create(NoRefundOCashOutData.QueueName, typeof(QueueRequestModel<SendEmailData<NoRefundOCashOutData>>)),
                QueueType.Create(OrdinaryCashOutRefundData.QueueName, typeof(QueueRequestModel<SendEmailData<OrdinaryCashOutRefundData>>)),
                QueueType.Create(PasswordRecoveryEmailComfirmationData.QueueName, typeof(QueueRequestModel<SendEmailData<PasswordRecoveryEmailComfirmationData>>)),
                QueueType.Create(PlainTextBroadCastData.QueueName, typeof(QueueRequestModel<SendBroadcastData<PlainTextBroadCastData>>)),
                QueueType.Create(PlainTextData.QueueName, typeof(QueueRequestModel<SendEmailData<PlainTextData>>)),
                QueueType.Create(PrivateWalletAddressData.QueueName, typeof(QueueRequestModel<SendEmailData<PrivateWalletAddressData>>)),
                QueueType.Create(PrivateWalletBackupData.QueueName, typeof(QueueRequestModel<SendEmailData<PrivateWalletBackupData>>)),
                QueueType.Create(RegistrationMessageData.QueueName, typeof(QueueRequestModel<SendEmailData<RegistrationMessageData>>)),
                QueueType.Create(RejectedData.QueueName, typeof(QueueRequestModel<SendEmailData<RejectedData>>)),
                QueueType.Create(RemindPasswordData.QueueName, typeof(QueueRequestModel<SendEmailData<RemindPasswordData>>)),
                QueueType.Create(RequestForDocumentData.QueueName, typeof(QueueRequestModel<SendEmailData<RequestForDocumentData>>)),
                QueueType.Create(RequestForExpiredDocumentData.QueueName, typeof(QueueRequestModel<SendEmailData<RequestForExpiredDocumentData>>)),
                QueueType.Create(RestrictedAreaData.QueueName, typeof(QueueRequestModel<SendEmailData<RestrictedAreaData>>)),
                QueueType.Create(SolarCashOutData.QueueName, typeof(QueueRequestModel<SendEmailData<SolarCashOutData>>)),
                QueueType.Create(SolarCoinAddressData.QueueName, typeof(QueueRequestModel<SendEmailData<SolarCoinAddressData>>)),
                QueueType.Create(SwapRefundData.QueueName, typeof(QueueRequestModel<SendEmailData<SwapRefundData>>)),
                QueueType.Create(SwiftCashoutDeclinedData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashoutDeclinedData>>)),
                QueueType.Create(SwiftCashoutProcessedData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashoutProcessedData>>)),
                QueueType.Create(SwiftCashOutRequestData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashOutRequestData>>)),
                QueueType.Create(SwiftCashoutRequestedData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashoutRequestedData>>)),
                QueueType.Create(SwiftConfirmedData.QueueName, typeof(QueueRequestModel<SendBroadcastData<SwiftConfirmedData>>)),
                QueueType.Create(TransferCompletedData.QueueName, typeof(QueueRequestModel<SendEmailData<TransferCompletedData>>)),
                QueueType.Create(UserRegisteredData.QueueName, typeof(QueueRequestModel<SendBroadcastData<UserRegisteredData>>)),
                QueueType.Create(RegistrationEmailVerifyData.QueueName, typeof(QueueRequestModel<SendEmailData<RegistrationEmailVerifyData>>)),
                QueueType.Create(VisaShippingInfoData.QueueName, typeof(QueueRequestModel<SendEmailData<VisaShippingInfoData>>)),
                QueueType.Create(VisaUpgradeLimitsData.QueueName, typeof(QueueRequestModel<SendEmailData<VisaUpgradeLimitsData>>)),
                QueueType.Create(PaymentRequestCreatedMessageData.QueueName, typeof(QueueRequestModel<SendEmailData<PaymentRequestCreatedMessageData>>)),
                QueueType.Create(PaymentRequestCreatedEmployeesMessageData.QueueName, typeof(QueueRequestModel<SendEmailData<PaymentRequestCreatedEmployeesMessageData>>)),
                QueueType.Create(PaymentRequestCompletedMessageData.QueueName, typeof(QueueRequestModel<SendEmailData<PaymentRequestCompletedMessageData>>)),
                QueueType.Create(RegistrationCypMessageData.QueueName, typeof(QueueRequestModel<SendEmailData<RegistrationCypMessageData>>)),
                QueueType.Create(EmailComfirmationCypData.QueueName, typeof(QueueRequestModel<SendEmailData<EmailComfirmationCypData>>)),
                QueueType.Create(KycOkCypData.QueueName, typeof(QueueRequestModel<SendEmailData<KycOkCypData>>)),
                QueueType.Create(DirectTransferCompletedCypData.QueueName, typeof(QueueRequestModel<SendEmailData<DirectTransferCompletedCypData>>)),
                QueueType.Create(ActionConfirmationData.QueueName, typeof(QueueRequestModel<SendEmailData<ActionConfirmationData>>)),
                QueueType.Create(NoAccountPasswordRecoveryData.QueueName, typeof(QueueRequestModel<SendEmailData<NoAccountPasswordRecoveryData>>)),
                QueueType.Create(NoAccountPasswordRecoveryCypData.QueueName, typeof(QueueRequestModel<SendEmailData<NoAccountPasswordRecoveryCypData>>)),
                QueueType.Create(SwiftCashoutDeclinedCypData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashoutDeclinedCypData>>)),
                QueueType.Create(SwiftCashoutProcessedCypData.QueueName, typeof(QueueRequestModel<SendEmailData<SwiftCashoutProcessedCypData>>)),
                QueueType.Create(RejectedCypData.QueueName, typeof(QueueRequestModel<SendEmailData<RejectedCypData>>)),
                QueueType.Create(RemindPasswordCypData.QueueName, typeof(QueueRequestModel<SendEmailData<RemindPasswordCypData>>))
            );
        }

        public Task ProduceSendEmailCommand<T>(string partnerId, string mailAddress, T msgData) where T : IEmailMessageData
        {
            var data = SendEmailData<T>.Create(partnerId, mailAddress, msgData);
            var msg = new QueueRequestModel<SendEmailData<T>> { Data = data };
            return _queueExt.PutMessageAsync(msg);
        }

        public Task ProduceSendEmailBroadcast<T>(string partnerId, BroadcastGroup broadcastGroup, T msgData) where T : IEmailMessageData
        {
            if (typeof(PlainTextData) == typeof(T))
                throw new ArgumentException("Broadcast can not be done using PlainTextData type");

            var data = SendBroadcastData<T>.Create(partnerId, broadcastGroup, msgData);
            var msg = new QueueRequestModel<SendBroadcastData<T>> { Data = data };
            return _queueExt.PutMessageAsync(msg);
        }
    }
}
