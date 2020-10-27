using Newtonsoft.Json;

public class DocumentType
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("label")]
    public string Label { get; set; }
    [JsonProperty("identity_type")]
    public string IdentityType { get; set; }
}
