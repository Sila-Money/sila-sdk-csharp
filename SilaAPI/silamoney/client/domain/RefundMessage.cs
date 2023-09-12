using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the Statements
    /// </summary>
    [DataContract]
    public partial class RefundMessage 
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
    }
}
