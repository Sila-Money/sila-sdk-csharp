using SilaAPI.silamoney.client.refactored.domain;

namespace SilaAPI.silamoney.client.refactored.endpoints.transactions.gettransactions
{
    public class GetTransactionsRequest
    {
        public string UserHandle { get; set; }
        public SearchFilters SearchFilters { get; set; }
    }
}