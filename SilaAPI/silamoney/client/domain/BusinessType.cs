using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetBusinessTypesResponse
    /// </summary>
    public class BusinessType : BusinessInformation
    {
        /// <summary>
        /// Denotes whether the business type requires certification.
        /// </summary>
        [JsonProperty("requires_certification")]
        public bool RequiresCertification { get; set; }
    }
}