using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityData : RegistrationDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identity_type")]
        public string IdentityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("document_name")]
        public string DocumentName { get; set; }
    }
}
