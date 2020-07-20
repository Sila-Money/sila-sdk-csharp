using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in the GetEntitiesResponse object.
    /// </summary>
    public class Entities
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("individuals")]
        public List<IndividualEntity> Individuals { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("businesses")]
        public List<BusinessEntity> Businesses { get; set; }
    }
}