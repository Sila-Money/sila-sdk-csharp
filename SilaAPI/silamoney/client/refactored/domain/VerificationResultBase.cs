using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Base object used to store the verification result of an attempt of the check_kyc endpoint.
    /// </summary>
    public class VerificationResultBase
    {
        /// <summary>
        /// The status of the verification attempt
        /// </summary>
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; set; }
        /// <summary>
        /// The kyc level of the verification attempt
        /// </summary>
        [JsonProperty("kyc_level")]
        public string KYCLevel { get; set; }
        /// <summary>
        /// The epoch of the request
        /// </summary>
        [JsonProperty("requested_at")]
        public int RequestedAt { get; set; }
        /// <summary>
        /// The epoch of the last update to the request
        /// </summary>
        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }
    }
}
