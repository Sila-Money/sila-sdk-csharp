using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public class TimeLine
    {
        public string date { get; set; }
        [JsonProperty("date_epoch")]
        public long dateEpoch { get; set; }
        public string status { get; set; }
        [JsonProperty("usd_status")]
        public string usdStatus { get; set; }
        [JsonProperty("token_status")]
        public string tokenStatus { get; set; }
    }
}
