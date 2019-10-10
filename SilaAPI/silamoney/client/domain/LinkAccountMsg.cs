using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// LinkAccountMsg object used in the link_account endpoint
    /// </summary>
    public partial class LinkAccountMsg : BaseMessage
    {
        /// <summary>
        /// String field used in the LinkAccountMsg object to save public token
        /// </summary>
        [DataMember(Name = "public_token", EmitDefaultValue = false)]
        public string publicToken { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string accountName { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save selected account id
        /// </summary>
        [DataMember(Name = "selected_account_id", EmitDefaultValue = false)]
        public string selectedAccountId { get; set; }

        /// <summary>
        /// LinkAccountMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="publicToken"></param>
        /// <param name="appHandle"></param>
        /// <param name="accountName"></param>
        public LinkAccountMsg(string userHandle,
            string publicToken,
            string appHandle,
            string accountName)
        {
            this.Header = new Header(userHandle, appHandle);
            this.publicToken = publicToken;
            this.MessageOption = Message.LinkAccountMsg;
            this.accountName = accountName;
        }
    }
}
