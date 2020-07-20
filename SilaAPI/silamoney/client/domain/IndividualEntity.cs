using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in Entities object.
    /// </summary>
    public class IndividualEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("handle")]
        public string Handle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created")]
        public int Created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_addresses")]
        public List<string> BlockchainAddresses { get; set; }
    }
}