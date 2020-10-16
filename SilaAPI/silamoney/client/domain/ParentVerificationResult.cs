using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store the parent verification result of an attempt of the check_kyc endpoint.
    /// </summary>
    public class ParentVerificationResult : VerificationResultBase
    {
        /// <summary>
        /// An id of the verification attempt
        /// </summary>
        [JsonProperty("parent_user_handle")]
        public string ParentUserHandle { get; set; }
        /// <summary>
        /// An id of the verification attempt
        /// </summary>
        [JsonProperty("parent_verification_id")]
        public string ParentVerificationId { get; set; }
    }
}
