using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{   /// <summary>
    /// DeleteTransactionMsg object used in the close_virtual_account endpoint
    /// </summary>
    public partial class CloseVirtualAccountMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_id", EmitDefaultValue = false)]
        public string VirtualAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="virtualAccountId"></param>
        /// <param name="accountNumber"></param>
        public CloseVirtualAccountMsg(string userHandle, string appHandle, string virtualAccountId, string accountNumber)
        {
            Header = new Header(userHandle, appHandle);
            VirtualAccountId = virtualAccountId;
            AccountNumber = accountNumber;
        }
    }
}
