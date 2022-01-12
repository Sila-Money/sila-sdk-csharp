using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in GetEntity method.
    /// </summary>
    public class EntityMember
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public string Details { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ownership_stake")]
        public float? OwnershipStake { get; set; }
    }
}
