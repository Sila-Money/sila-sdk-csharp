using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class TransferResponse : TransactionResponse
    {
        /// <summary>
        /// String field used in the TransferResponse object to save destination address
        /// </summary>
        [JsonProperty("destination_address")]
        public string DestinationAddress { get; set; }
    }
}
