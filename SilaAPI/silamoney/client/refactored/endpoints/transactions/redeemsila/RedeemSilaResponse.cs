using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class RedeemSilaResponse : BaseResponse
    {
        /// <summary>
        ///  String field used in the TransactionResponse object to save error_code
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("destination_id")]
        public string DestinationId { get; set; }
    }
}

