using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    public class EmailData : RegistrationDataBase
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
