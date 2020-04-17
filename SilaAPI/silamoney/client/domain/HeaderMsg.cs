using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// HeaderMsg object used in check_handle, request_kyc and check_kyc endpoints
    /// </summary>
    public partial class HeaderMsg : BaseMessageNoMsg
    {

        /// <summary>
        /// String field used in the HeaderMsg object to save kyc_level
        /// </summary>
        [DataMember(Name = "kyc_level", EmitDefaultValue = false)]
        public string kycLevel { get; set; }  

        /// <summary>
        /// HeaderMsg constructor
        /// </summary>
        /// <param name="handle">The user handle</param>
        /// <param name="authHandle">The app handle</param>
        public HeaderMsg(string handle, string authHandle)
        {
            Header = new Header(handle, authHandle);
        }

        /// <summary>
        /// HeaderMsg constructor
        /// </summary>
        /// <param name="handle">The user handle</param>
        /// <param name="authHandle">The app handle</param>
        /// <param name="kycLevel">The KYC level</param>
        public HeaderMsg(string handle, string authHandle, string kycLevel)
        {
            this.kycLevel = kycLevel;
            Header = new Header(handle, authHandle);
        }        
    }
}
