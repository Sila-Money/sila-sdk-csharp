using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// CheckInstantACHMsg object used in the CheckInstantACH endpoint
    /// </summary>
    [DataContract]
    public partial class CheckInstantACHMsg
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
        [DataMember(Name = "kyc_level", EmitDefaultValue = false)]
        public string KycLevel { get; set; }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userHandle"></param>
       /// <param name="authHandle"></param>
       /// <param name="accountName"></param>
       /// <param name="kycLevel"></param>
        public CheckInstantACHMsg(string userHandle, string authHandle, string accountName, string kycLevel = null)
        {
            this.Header = new Header(userHandle, authHandle);
            this.AccountName = accountName;
            this.KycLevel = kycLevel;
        }
    }
}
