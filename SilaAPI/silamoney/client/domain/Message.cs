using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SearchFilters object used in the Statements
    /// </summary>
    [DataContract]
    public partial class Message
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cvv")]
        public int cvv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cko_public_key")]
        public string CkoPublicKey { get; set; }
        
    }
}
