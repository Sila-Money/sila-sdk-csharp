using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityIdentity : EntityAudit
    {
        /// <summary>
        /// String field used in the Identity object to save identity
        /// </summary>
        [JsonProperty("identity")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// String field used in the Identity object to save identity type
        /// </summary>
        [JsonProperty("identity_type")]
        public string IdentityType { get; set; }
    }
}
