using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.CloseVirtualAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class CloseVirtualAccountResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account")]
        public VirtualAccount VirtualAccount { get; set; }
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
