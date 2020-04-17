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
        public string PublicToken { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save account name
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save selected account id
        /// </summary>
        [DataMember(Name = "selected_account_id", EmitDefaultValue = false)]
        public string SelectedAccountId { get; set; }

        /// Adding new 3 params
        /// <summary>
        /// String field used in the LinkAccountMsg object to save selected account number
        /// </summary>
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save selected routing number
        /// </summary>
        [DataMember(Name = "routing_number", EmitDefaultValue = false)]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// String field used in the LinkAccountMsg object to save selected account type
        /// </summary>
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }                        

        /// <summary>
        /// LinkAccountMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="publicToken"></param>
        /// <param name="appHandle"></param>
        /// <param name="accountId"></param>
        /// <param name="accountName"></param>                   
        public LinkAccountMsg(string userHandle,
            string publicToken,
            string appHandle,
            string accountId,
            string accountName)
        {
            Header = new Header(userHandle, appHandle);
            PublicToken = publicToken;
            MessageOption = Message.LinkAccountMsg;
            AccountName = accountName;
            SelectedAccountId = accountId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="accountNumber"></param>
        /// <param name="routingNumber"></param>
        /// <param name="accountName"></param>
        /// <param name="accountType"></param>
        public LinkAccountMsg(string userHandle, 
            string appHandle, 
            string accountNumber, 
            string routingNumber,  
            string accountType,
            string accountName)
        {
            Header = new Header(userHandle, appHandle);
            AccountNumber = accountNumber;
            RoutingNumber = routingNumber;
            AccountType = accountType;
            MessageOption = Message.LinkAccountMsg;
            AccountName = accountName;
        }
    }
}
