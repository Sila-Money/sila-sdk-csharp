using System.Collections.Generic;
using Newtonsoft.Json;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used in Get nacis categories
    /// </summary>
    public class NaicsCategoriesResponse : BaseResponse
    {       
        /// <summary>
        /// Get the Naics Subcategories.
        /// </summary>
        /// <value>NaicsSubcategories</value>
        [JsonProperty("naics_categories")]
        public Dictionary<string, List<NaicsSubcategory>> NaicsCategories { get; set; }       
    }
}