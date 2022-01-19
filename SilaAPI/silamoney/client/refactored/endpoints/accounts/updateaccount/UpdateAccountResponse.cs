using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
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

        [JsonProperty("reference")]
        public string Reference { get; private set; }
    }
}