using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetBusinessTypes method
    /// </summary>
    public class BusinessRolesResponse : BaseResponse
    {
        /// <summary>
        /// List of business roles.
        /// </summary>
        /// <value>BusinessRoles</value>
        [JsonProperty("business_roles")]
        public List<BusinessRole> BusinessRoles { get; set; }
    }
}