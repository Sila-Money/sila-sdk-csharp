using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetEntities mehtod.
    /// </summary>
    public class GetEntitiesResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entities")]
        public Entities Entities { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}