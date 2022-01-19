using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class BaseResponse : BaseResponseWithoutReference
    {
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
    }
}
