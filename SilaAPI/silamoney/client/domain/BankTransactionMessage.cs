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
        ///  String field used to save the card name
        /// </summary>
        [DataMember(Name = "card_name", EmitDefaultValue = false)]
        public string CardName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "source_id", EmitDefaultValue = false)]
        public string SourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "destination_id", EmitDefaultValue = false)]
        public string DestinationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mock_wire_account_name", EmitDefaultValue = false)]
        public string MockWireAccountName { get; set; }

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
        /// <param name="cardName"></param>
        /// <param name="sourceId"></param>
        /// <param name="destinationId"></param>
        /// <param name="mockWireAccountName"></param>
        public BankTransactionMessage(string userHandle, int amount, string authHandle, string accountName, string descriptor, string businessUuid, ProcessingType? processingType, Message messageType, string cardName, string sourceId, string destinationId, string mockWireAccountName)
        {
            Header = new Header(userHandle, authHandle);
            Amount = amount;
            MessageOption = messageType;
            AccountName = accountName;
            Descriptor = descriptor;
            BusinessUuid = businessUuid;
            ProcessingType = processingType;
            CardName = cardName;
            SourceId = sourceId;
            DestinationId = destinationId;
            MockWireAccountName = mockWireAccountName;
        }
    }
}
