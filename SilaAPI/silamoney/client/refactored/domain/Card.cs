using Newtonsoft.Json;
using System.Collections.Generic;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Card object used in the get_Cards endpoint response
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_name")]
        public string CardName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_last_4")]
        public int Last4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pull_enabled")]
        public string PullEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("push_enabled")]
        public string PushEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("push_availability")]
        public string PushAvailability { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_status")]
        public string CardStatus { get; set; }
    }
}
