using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
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