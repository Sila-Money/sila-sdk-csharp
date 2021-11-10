using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// DeleteTransactionMsg object used in the delete_Transaction endpoint
    /// </summary>
    public partial class ReverseTransactionMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "transaction_id", EmitDefaultValue = false)]
        public string TransactionId { get; set; }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="transactionId"></param>
        public ReverseTransactionMsg(string userHandle, string appHandle, string transactionId)
        {
            Header = new Header(userHandle, appHandle);
            TransactionId = transactionId;
        }
    }
}
