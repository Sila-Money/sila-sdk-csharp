using System.Collections.Generic;
using Newtonsoft.Json;
using static Sila.API.Client.Domain.CryptoEnum;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class WalletSearchFilters
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_address")]     
        public string BlockChainAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_network")]      
        public Crypto BlockChainNetwork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("wallet_id")]
        public string UuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page")]
        public int? Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sort_ascending")]
        public bool? SortAscending { get; set; }
    }
}
