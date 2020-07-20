using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetEntity method.
    /// </summary>
    public class EntityPhone : EntityAudit
    {
        /// <summary>
        /// Phone property.
        /// </summary>
        /// <value>Phone</value>
        [JsonProperty("phone")]
        public string Phone{get;set;}
    }
}