using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// CheckPartnerKycMsg object used in the CheckPartnerKyc endpoint
    /// </summary>
    [DataContract]
    public partial class CheckPartnerKycMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "query_app_handle", EmitDefaultValue = false)]
        public string QueryAppHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "query_user_handle", EmitDefaultValue = false)]
        public string QueryUserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHandle"></param>
        /// <param name="queryAppHandle"></param>
        /// <param name="queryUserHandle"></param>
        public CheckPartnerKycMsg(string authHandle, string queryAppHandle, string queryUserHandle)
        {
            this.Header = new Header(null, authHandle);
            this.QueryAppHandle = queryAppHandle;
            this.QueryUserHandle = queryUserHandle;
        }
    }
}
