using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Object used in the GetBusinessTypes method
    /// </summary>
    public class BusinessTypesResponse
    {
        /// <summary>
        /// Get the success value of the method.
        /// </summary>
        /// <value>Success</value>
        [JsonProperty("success")]
        public bool Success { get; }
        /// <summary>
        /// List of business types.
        /// </summary>
        /// <value>BusinessTypes</value>
        [JsonProperty("business_types")]
        public List<BusinessType> BusinessTypes { get; }
    }
}