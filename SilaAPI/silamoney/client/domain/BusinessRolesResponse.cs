using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetBusinessTypes method
    /// </summary>
    public class BusinessRolesResponse
    {
        /// <summary>
        /// Get the success value of the method.
        /// </summary>
        /// <value>Success</value>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// List of business roles.
        /// </summary>
        /// <value>BusinessRoles</value>
        [JsonProperty("business_roles")]
        public List<BusinessRole> BusinessRoles { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}