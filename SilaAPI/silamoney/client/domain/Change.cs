using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Change
    {
        /// <summary>
        /// 
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("old_value")]
        public string OldValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("new_value")]
        public string NewValue { get; set; }
    }
}
