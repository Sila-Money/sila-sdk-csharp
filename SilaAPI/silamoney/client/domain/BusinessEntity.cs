using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in Entities object.
    /// </summary>
    public class BusinessEntity : IndividualEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dba")]
        public string Dba { get; set; }
    }
}