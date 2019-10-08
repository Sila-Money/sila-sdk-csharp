using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class GetTransactionsMsg : BaseMessage
    {
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public SearchFilters searchFilters { get; set; }

        public GetTransactionsMsg(string userHandle, string authHandle, SearchFilters searchFilters = default(SearchFilters))
        {
            this.header = new Header(userHandle, authHandle);
            this.searchFilters = searchFilters;
            this.message = MessageEnum.GetTransactionMsg;
        }
    }
}
