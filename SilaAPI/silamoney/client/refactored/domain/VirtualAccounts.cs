using Newtonsoft.Json;
namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class VirtualAccounts
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_id")]
        public string VirtualAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_name")]
        public string VirtualAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_epoch")]
        public long? CreatedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed_epoch")]
        public string ClosedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed")]
        public bool Closed { get; set; }
    }
}
