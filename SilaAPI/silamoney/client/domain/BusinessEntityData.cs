using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessEntityData : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("naics_code")]
        public int NaicsCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("business_uuid")]
        public string BusinessUuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("naics_category")]
        public string NaicsCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("naics_subcategory")]
        public string NaicsSubcategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("doing_business_as")]
        public string DoingBusinessAs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("business_website")]
        public string BusinessWebsite { get; set; }
    }
}
