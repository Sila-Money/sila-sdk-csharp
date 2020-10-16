using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class TransactionResponse : BaseResponse
    {
        /// <summary>
        /// String field used in the TransactionResponse object to save transaction id
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// String field used in the TransactionResponse object to save descriptor
        /// </summary>
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }
}
