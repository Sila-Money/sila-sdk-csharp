using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    public class EmailResponse : BaseResponseWithoutReference
    {
        [JsonProperty("email")]
        public EmailData Email { get; set; }
    }
}
