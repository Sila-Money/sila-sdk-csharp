using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SearchFilterBase
    {
        /// <summary>
        /// Integer field used in the SearchFilters object to save page
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int? Page { get; set; }

        /// <summary>
        /// Integer field used in the SearchFilters object to save per Page
        /// </summary>
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int? PerPage { get; set; }

        /// <summary>
        /// Boolean field used in the SearchFilters object to save sort ascending
        /// </summary>
        [DataMember(Name = "sort_ascending", EmitDefaultValue = false)]
        public bool? SortAscending { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SearchFilterBase(int? page = default,
            int? perPage = default,
            bool? sortAscending = default)
        {
            if (PerPage != null && (PerPage < 1 || PerPage > 100))
                throw new InvalidDataException("perPage must be between 1 and 100");
            else PerPage = perPage;
            Page = page;
            SortAscending = sortAscending;
        }
    }
}
