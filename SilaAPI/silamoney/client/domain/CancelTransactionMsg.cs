using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the endpoint
    /// </summary>
    [DataContract]
    public class CancelTransactionMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }

        /// <summary>
        /// The transaction id to be cancel
        /// </summary>
        [DataMember(Name = "transaction_id", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        /// <sumary>
        /// The cancel transaction message constructor
        /// <param name="authHandle">The application handle</param>
        /// <param name="userHandle">The user handle</param>
        /// <param name="transactionId">The transaction id</param>
        /// </sumary>
        public CancelTransactionMsg(string authHandle, string userHandle, string transactionId)
        {
            this.Header = new Header(userHandle, authHandle);
            this.TransactionId = transactionId;
        }
    }
}