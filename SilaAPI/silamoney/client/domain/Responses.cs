using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Responses
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }    
    }
}
