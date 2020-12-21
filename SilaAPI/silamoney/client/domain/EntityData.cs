using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityData
    {
        /// <summary>
        /// Int field used in the Entity object to save the created epoch
        /// </summary>
        [JsonProperty("created_epoch")]
        public int CreatedEpoch { get; set; }
        /// <summary>
        /// Int field used in the Entity object to save the created epoch
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }
        /// <summary>
        /// Datetime field used in the Entity object to save birthdate
        /// </summary>
        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }
        /// <summary>
        /// String field used in the Entity object to save entity name
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }
        /// <summary>
        /// String field used in the Entity object to save last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// String field used in the Entity object to save first name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// String field used in the Entity object to save business type
        /// </summary>
        [JsonProperty("business_uuid")]
        public string BusinessUuid { get; set; }
        /// <summary>
        /// String field used in the Entity object to save business type
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }
        /// <summary>
        /// String field used in the Entity object to save naics code
        /// </summary>
        [JsonProperty("naics_code")]
        public int NaicsCode { get; set; }
        /// <summary>
        /// String field used in the Entity object to save naics code
        /// </summary>
        [JsonProperty("naics_category")]
        public int NaicsCategory { get; set; }
        /// <summary>
        /// String field used in the Entity object to save naics code
        /// </summary>
        [JsonProperty("naics_subcategory")]
        public int NaicsSubcategory { get; set; }
        /// <summary>
        /// String field used in the Entity object to save business website
        /// </summary>
        [JsonProperty("business_website")]
        public string BusinessWebsite { get; set; }
        /// <summary>
        /// String field used in the Entity object to save doing business as
        /// </summary>
        [JsonProperty("doing_business_as")]
        public string DoingBusinessAs { get; set; }
    }
}
