using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.OpenVirtualAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenVirtualAccountResponse
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
        public bool Success { get; set; }

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
        /// 
        /// </summary>
        [JsonProperty("virtual_account")]
        public VirtualAccounts VirtualAccount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("response_time_ms")]
        public string ResponseTimeMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_credit_enabled")]
        public bool AchCreditEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_debit_enabled")]
        public bool AchDebitEnabled { get; set; }

    }
}
