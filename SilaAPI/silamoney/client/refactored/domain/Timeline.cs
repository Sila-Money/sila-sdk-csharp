using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Timeline object used in the SearchFilters object
    /// </summary>
    public class Timeline
    {
        /// <summary>
        /// String field used in the TimeLine object to save date
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }
        /// <summary>
        /// Long field used in the TimeLine object to save date epoch
        /// </summary>
        [JsonProperty("date_epoch")]
        public long DateEpoch { get; set; }
        /// <summary>
        /// String field used in the TimeLine object to save status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// String field used in the TimeLine object to save usd status
        /// </summary>
        [JsonProperty("usd_status")]
        public string UsdStatus { get; set; }
        /// <summary>
        /// String field used in the TimeLine to save token status
        /// </summary>
        [JsonProperty("token_status")]
        public string TokenStatus { get; set; }
    }
}
