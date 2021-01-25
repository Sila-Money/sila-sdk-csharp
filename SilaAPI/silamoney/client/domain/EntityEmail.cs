using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetEntityResponse object.
    /// </summary>
    public class EntityEmail : EntityAudit
    {
        /// <summary>
        /// Email property.
        /// </summary>
        /// <value>Email</value>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}