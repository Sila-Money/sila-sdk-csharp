using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistrationDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("added_epoch")]
        public long AddedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("modified_epoch")]
        public long ModifiedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}
