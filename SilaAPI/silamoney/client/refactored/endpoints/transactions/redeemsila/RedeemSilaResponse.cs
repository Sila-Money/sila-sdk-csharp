﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class RedeemSilaResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save message 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// Boolean field used to indicate if the response was successful or not
        /// </summary>
        [JsonProperty("success")]
        public bool? Success { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save reference
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }
    }
}

