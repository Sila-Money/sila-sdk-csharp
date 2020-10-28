using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_epoch")]
        public long CreatedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }
    }
}
