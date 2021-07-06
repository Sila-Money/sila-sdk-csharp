using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetBusinessTypesResponse
    /// </summary>
    public class BusinessType : BusinessInformation
    {
        [JsonProperty("requires_certification")]
        public bool RequiresCertification { get; set; }
    }
}