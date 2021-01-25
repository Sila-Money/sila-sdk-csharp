using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// BankTransactionMessage object used in the issue_sila endpoint
    /// </summary>
    public partial class BankTransactionMessage : TransactionMessage
    {
        /// <summary>
        /// String field used to save the account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }

        /// <summary>
        /// String field used to save the processing type
        /// </summary>
        [DataMember(Name = "processing_type", EmitDefaultValue = false)]
        public ProcessingType? ProcessingType { get; set; }

        /// <summary>
        /// BankTransactionMessage constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="amount"></param>
        /// <param name="authHandle"></param>
        /// <param name="accountName"></param>
        /// <param name="descriptor"></param>
        /// <param name="businessUuid"></param>
        /// <param name="processingType"></param>
        /// <param name="messageType"></param>
        public BankTransactionMessage(string userHandle,
            int amount,
            string authHandle,
            string accountName,
            string descriptor,
            string businessUuid,
            ProcessingType? processingType, Message messageType)
        {
            Header = new Header(userHandle, authHandle);
            Amount = amount;
            MessageOption = messageType;
            AccountName = accountName;
            Descriptor = descriptor;
            BusinessUuid = businessUuid;
            ProcessingType = processingType;
        }
    }
}
