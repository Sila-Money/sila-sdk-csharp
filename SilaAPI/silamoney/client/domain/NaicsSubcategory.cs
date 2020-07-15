using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Object used in NaicsCategories object.
    /// </summary>
    public class NaicsSubcategory
    {
        /// <summary>
        /// Get the Subcategory code.
        /// </summary>
        /// <value>Code</value>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// Get the Subcategory name.
        /// </summary>
        /// <value>Subcateogry</value>
        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }
    }
}