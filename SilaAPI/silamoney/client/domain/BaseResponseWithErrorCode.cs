using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseResponseWithErrorCode : BaseResponse
    {
        /// <summary>
        ///  String field used in the TransactionResponse object to save error_code
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
