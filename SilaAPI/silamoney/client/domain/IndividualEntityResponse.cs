using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class IndividualEntityResponse : EntityResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity")]
        public IndividualEntityData Entity { get; set; }
    }
}
