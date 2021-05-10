using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    public class UpdateAccountResponse
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }
        [JsonProperty("message")]
        public string Message { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("account")]
        public Account Account { get; private set; }
        [JsonProperty("changes")]
        public List<Change> Changes { get; private set; }
    }
}