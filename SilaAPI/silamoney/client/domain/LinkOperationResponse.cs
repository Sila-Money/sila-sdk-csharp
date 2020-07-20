using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in Link and Unlink business member.
    /// </summary>
    public class LinkOperationResponse : BaseResponse
    {
        /// <summary>
        /// Gets the response role.
        /// </summary>
        /// <value>Role</value>
        [JsonProperty("role")]
        public string Role {get;set;}
        /// <summary>
        /// Gets the response details.
        /// </summary>
        /// <value>Details</value>
        [JsonProperty("details")]
        public string Details {get;set;}
        /// <summary>
        /// Gets the response verification uuid.
        /// </summary>
        /// <value>VerificationUuid</value>
        [JsonProperty("verification_uuid")]
        public string VerificationUuid {get;set;}
    }
}