using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class RefundDebitCardResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("refund_transaction_id")]
        public string RefundTransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>

        [JsonProperty("warning")]
        public string Warning { get; set; }



    }
}
