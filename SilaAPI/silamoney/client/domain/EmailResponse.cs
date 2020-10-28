using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <sumary>
    ///
    /// </sumary>
    public class EmailResponse : BaseResponseWithoutReference
    {
        /// <sumary>
        ///
        /// </sumary>
        [JsonProperty("email")]
        public EmailData Email { get; set; }
    }
}
