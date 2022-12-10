using Sila.API.Client.Domain;

namespace Sila.API.Client.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletStatementDataRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public StatementSearchFilters SearchFilters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WalletId { get; set; }
        
    }
}