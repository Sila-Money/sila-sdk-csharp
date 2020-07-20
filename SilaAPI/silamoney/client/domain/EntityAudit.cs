using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in entities objects.
    /// </summary>
    public class EntityAudit
    {
        /// <summary>
        /// Added epoch field in entities information.
        /// </summary>
        [JsonProperty("added_epoch")]
        public int AddedEpoch { get; set; }
        /// <summary>
        /// Modified epoch field in entities information.
        /// </summary>
        [JsonProperty("modified_epoch")]
        public int ModifiedEpoch { get; set; }
        /// <summary>
        /// Uuid field in entities information.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
    }
}