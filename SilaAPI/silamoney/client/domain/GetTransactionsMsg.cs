using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class GetTransactionsMsg : BaseMessage
    {
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public SearchFilters searchFilters { get; set; }

        public GetTransactionsMsg(Header header = default(Header), SearchFilters searchFilters = default(SearchFilters))
        {
            if (header == null)
            {
                throw new InvalidDataException("header is a required property for GetTransactionsMsg and cannot be null");
            }
            else
            {
                this.header = header;
            }
            this.searchFilters = searchFilters;
            this.message = MessageEnum.GetTransactionMsg;
        }
    }
}
