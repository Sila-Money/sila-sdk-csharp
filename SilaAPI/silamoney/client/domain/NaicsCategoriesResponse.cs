using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in Get nacis categories
    /// </summary>
    public class NaicsCategoriesResponse
    {
        /// <summary>
        /// Get the success value of the method.
        /// </summary>
        /// <value>Success</value>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// Get the Naics Subcategories.
        /// </summary>
        /// <value>NaicsSubcategories</value>
        [JsonProperty("naics_categories")]
        public Dictionary<string, List<NaicsSubcategory>> NaicsCategories { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}