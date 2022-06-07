using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
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
