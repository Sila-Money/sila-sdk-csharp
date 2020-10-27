using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    public class RegistrationDataBase
    {
        [JsonProperty("added_epoch")]
        public long AddedEpoch { get; set; }
        [JsonProperty("modified_epoch")]
        public long ModifiedEpoch { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
