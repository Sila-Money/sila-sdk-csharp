using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class GetStatementsDataRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public StatementSearchFilters SearchFilters { get; set; }
    }
}
