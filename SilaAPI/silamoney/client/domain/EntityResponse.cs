using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityResponse : BaseResponseWithoutReference
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
    }
}
