using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Statement
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_handle")]
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

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
        [JsonProperty("wallet_id")]
        public string WalletId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("beginning_balance")]
        public string BeginningBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ending_balance")]
        public string EndingBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactions")]
        public List<StatementTransaction> Transactions { get; set; }
    }
}
