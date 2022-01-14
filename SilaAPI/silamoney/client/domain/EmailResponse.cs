using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class EmailResponse : BaseResponse
    {
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("email")]
        public EmailData Email { get; set; }
    }
}
