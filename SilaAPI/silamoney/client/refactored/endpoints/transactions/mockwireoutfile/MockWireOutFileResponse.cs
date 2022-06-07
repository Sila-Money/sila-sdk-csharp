using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class MockWireOutFileResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("wire_status")]
        public string WireStatus { get; set; }
    }
}

