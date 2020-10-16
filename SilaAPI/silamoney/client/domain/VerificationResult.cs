using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store the verification result of an attempt of the check_kyc endpoint.
    /// </summary>
    public class VerificationResult : VerificationResultBase
    {
        /// <summary>
        /// An id of the verification attempt
        /// </summary>
        [JsonProperty("verification_id")]
        public string VerificationId { get; set; }
        /// <summary>
        /// An array of string reasons of the verification attempt
        /// </summary>
        [JsonProperty("reasons")]
        public List<string> Reasons { get; set; }
        /// <summary>
        /// An array of string tags of the verification attempt
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        /// <summary>
        /// The score result of the verification attempt
        /// </summary>
        [JsonProperty("score")]
        public decimal? Score { get; set; }
        /// <summary>
        /// The verification status of the parent entity
        /// </summary>
        [JsonProperty("parent_verification")]
        public ParentVerificationResult ParentVerification { get; set; }
    }
}
