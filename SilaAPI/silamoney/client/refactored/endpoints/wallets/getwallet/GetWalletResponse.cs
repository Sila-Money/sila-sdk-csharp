using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Wallets
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public WalletResponse Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_balance")]
        internal decimal Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SilaBalance { get { return decimal.ToInt32(Balance); } }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_available_balance")]
        public decimal SilaAvailableBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sila_pending_balance")]
        public decimal SilaPendingBalance { get; set; }
    }
}
