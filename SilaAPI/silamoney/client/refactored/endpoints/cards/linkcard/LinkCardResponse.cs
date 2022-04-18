using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Cards
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkCardResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("card_name")]
        public string CardName { get; set; }

        /// <summary>
        /// 
        /// </summary> 
        [JsonProperty("avs")]
        public string AVS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_details")]
        public Card CardDetail { get; private set; }
    }
}
