using SilaAPI.Silamoney.Client.Refactored.Domain;

namespace SilaAPI.Silamoney.Client.Refactored.endpoints.transactions.gettransactions
{
    public class GetTransactionsRequest
    {
        public string UserHandle { get; set; }
        public SearchFilters SearchFilters { get; set; }
    }
}