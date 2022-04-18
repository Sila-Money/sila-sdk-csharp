using System.Collections.Generic;
using Newtonsoft.Json;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Cards
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCardsResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cards")]
        public List<Card> Cards { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
