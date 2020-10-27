using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    internal class ListDocumentsMsg
    {
        [DataMember(Name = "header")]
        public Header Header { get; }
        [DataMember(Name = "start_date", EmitDefaultValue = false)]
        public string StartDate { get; }
        [DataMember(Name = "end_date", EmitDefaultValue = false)]
        public string EndDate { get; }
        [DataMember(Name = "doc_types", EmitDefaultValue = false)]
        public List<string> DocTypes { get; }
        [DataMember(Name = "search", EmitDefaultValue = false)]
        public string Search { get; }
        [DataMember(Name = "sort_by", EmitDefaultValue = false)]
        public string SortBy { get; }

        public ListDocumentsMsg(string authHandle, string userHandle, DateTime? startDate, DateTime? endDate, List<string> docTypes, string search, string sortBy)
        {
            Header = new Header(userHandle, authHandle);
            StartDate = startDate.HasValue ? startDate.Value.ToString("yyyy-MM-dd") : null;
            EndDate = endDate.HasValue ? endDate.Value.ToString("yyyy-MM-dd") : null;
            DocTypes = docTypes;
            Search = search;
            SortBy = sortBy;
        }
    }
}
