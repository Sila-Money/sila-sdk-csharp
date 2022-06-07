using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Wallets
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public List<WalletResponse> Wallets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("returned_count")]
        public int ReturnedCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_page_count")]
        public int TotalPageCount { get; set; }
    }
}
