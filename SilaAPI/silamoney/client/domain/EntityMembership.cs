using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetEntity method.
    /// </summary>
    public class EntityMembership
    {
        /// <summary>
        /// Business handle property.
        /// </summary>
        /// <value>Bsuiness handle</value>
        [JsonProperty("business_handle")]
        public string BusinessHandle { get; set; }
        /// <summary>
        /// Entity name property.
        /// </summary>
        /// <value>Entity name</value>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }
        /// <summary>
        /// Role property.
        /// </summary>
        /// <value>Role</value>
        [JsonProperty("role")]
        public string Role { get; set; }
        /// <summary>
        /// Details property.
        /// </summary>
        /// <value>Details</value>
        [JsonProperty("details")]
        public string Details { get; set; }
        /// <summary>
        /// Ownership stake property.
        /// </summary>
        /// <value>Ownership stake</value>
        [JsonProperty("ownership_stake")]
        public float? OwnershipStake { get; set; }
        /// <summary>
        /// Certification token property.
        /// </summary>
        /// <value>Certification token</value>
        [JsonProperty("certification_token")]
        public string CertificationToken { get; set; }
    }
}