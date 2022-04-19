using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetBusinessTypes method
    /// </summary>
    public class BusinessTypesResponse : BaseResponse
    {
        /// <summary>
        /// List of business types.
        /// </summary>
        /// <value>BusinessTypes</value>
        [JsonProperty("business_types")]
        public List<BusinessType> BusinessTypes { get; set; }
    }
}