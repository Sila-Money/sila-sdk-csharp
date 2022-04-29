using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// PlaidUpdateLinkTokenMsg object used in the PlaidUpdateLinkToken endpoint
    /// </summary>
    [DataContract]
    public partial class PlaidUpdateLinkTokenMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "account_name", EmitDefaultValue = false)]
        public string AccountName { get; set; }       

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userHandle"></param>
       /// <param name="authHandle"></param>
       /// <param name="accountName"></param>
        public PlaidUpdateLinkTokenMsg(string userHandle, string authHandle, string accountName)
        {
            this.Header = new Header(userHandle, authHandle);
            this.AccountName = accountName;
        }
    }
}
