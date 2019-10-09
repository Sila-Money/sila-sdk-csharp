using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TimeLine object used in the SearchFilters object
    /// </summary>
    public class TimeLine
    {
        /// <summary>
        /// String field used in the TimeLine object to save date
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// Long field used in the TimeLine object to save date epoch
        /// </summary>
        [JsonProperty("date_epoch")]
        public long dateEpoch { get; set; }
        /// <summary>
        /// String field used in the TimeLine object to save status
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// String field used in the TimeLine object to save usd status
        /// </summary>
        [JsonProperty("usd_status")]
        public string usdStatus { get; set; }
        /// <summary>
        /// String field used in the TimeLine to save token status
        /// </summary>
        [JsonProperty("token_status")]
        public string tokenStatus { get; set; }
    }
}
