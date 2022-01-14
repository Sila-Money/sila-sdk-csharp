using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessEntityResponse : EntityResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity")]
        public BusinessEntityData Entity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
