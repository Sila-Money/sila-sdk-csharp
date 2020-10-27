using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class IndividualEntityData : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
