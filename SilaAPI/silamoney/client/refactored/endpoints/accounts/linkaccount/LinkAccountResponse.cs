using Newtonsoft.Json;

namespace Sila.API.Client.Accounts.LinkAccount
{
    public class LinkAccountResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("reference")]
        public string Reference { get; private set; }
        [JsonProperty("account_name")]
        public string AccountName { get; private set; }
        [JsonProperty("match_score")]
        public float? MatchScore { get; private set; }
        [JsonProperty("account_owner_name")]
        public string AccountOwnerName { get; private set; }
        [JsonProperty("entity_name")]
        public string EntityName { get; private set; }
    }
}