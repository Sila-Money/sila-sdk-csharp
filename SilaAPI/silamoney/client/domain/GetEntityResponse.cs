using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetEntity method.
    /// </summary>
    public class GetEntityResponse
    {
        /// <summary>
        /// Success property.
        /// </summary>
        /// <value>Success</value>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// User handle property.
        /// </summary>
        /// <value>UserHandle</value>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }
        /// <summary>
        /// Entity type property.
        /// </summary>
        /// <value>Entity type</value>
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }
        /// <summary>
        /// Entity property.
        /// </summary>
        /// <value>Entity</value>
        [JsonProperty("entity")]
        public EntityData Entity { get; set; }
        /// <summary>
        /// Addresses property.
        /// </summary>
        /// <value>Addresses</value>
        [JsonProperty("addresses")]
        public List<Address> Addresses {get;set;} 
        /// <summary>
        /// Identities property.
        /// </summary>
        /// <value>Identities</value>
        [JsonProperty("identities")]
        public List<EntityIdentity> Identities {get;set;} 
        /// <summary>
        /// Emails property.
        /// </summary>
        /// <value>Emails</value>
        [JsonProperty("emails")]
        public List<EntityEmail> Emails {get;set;} 
        /// <summary>
        /// Phones property.
        /// </summary>
        /// <value>Phones</value>
        [JsonProperty("phones")]
        public List<EntityPhone> Phones {get;set;} 
        /// <summary>
        /// Memberships property.
        /// </summary>
        /// <value>Memberships</value>
        [JsonProperty("memberships")]
        public List<EntityMembership> Memberships {get;set;} 
    }
}