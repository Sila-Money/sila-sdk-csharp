using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// LinkAccountMsg object used in the link_account endpoint
    /// </summary>
    public partial class DeleteAccountMsg : BaseMessage
    {
        /// <summary>
        /// String field used in the LinkAccountMsg object to save public token
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="accountName"></param>
        public DeleteAccountMsg(string userHandle,
            string appHandle,
            string accountName)
        {
            Header = new Header(userHandle, appHandle);
            AccountName = accountName;
        }
    }
}
