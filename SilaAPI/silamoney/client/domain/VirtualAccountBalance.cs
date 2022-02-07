using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class VirtualAccountBalance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pending_sila_balance")]
        public int? PendingSilaBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("available_sila_balance")]
        public int? AvailableSilaBalance { get; set; }
    }
}
