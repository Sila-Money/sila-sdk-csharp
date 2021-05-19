using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    public class GetTransactionsRequest
    {
        public string UserHandle { get; set; }
        public SearchFilters SearchFilters { get; set; }
    }
}