using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class GetTransactionsRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public SearchFilters SearchFilters { get; set; }
    }
}