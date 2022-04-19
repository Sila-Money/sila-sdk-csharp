using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAccountResult : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
    }
}
