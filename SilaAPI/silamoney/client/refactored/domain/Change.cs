using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.refactored.domain
{
    public class Change
    {
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
        [JsonProperty("old_value")]
        public string OldValue { get; set; }
        [JsonProperty("new_value")]
        public string NewValue { get; set; }
    }
}