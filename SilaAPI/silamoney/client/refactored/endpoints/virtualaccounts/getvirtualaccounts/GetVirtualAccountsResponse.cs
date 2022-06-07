using Newtonsoft.Json;
using Sila.API.Client.Domain;
using System.Collections.Generic;

namespace Sila.API.Client.VirtualAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountsResponse : BaseResponse
    {  
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_accounts")]
        public List<VirtualAccount> VirtualAccounts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_credit_enabled")]
        public bool AchCreditEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_debit_enabled")]
        public bool AchDebitEnabled { get; set; }
    }
}
