using Sila.API.Client.Domain;

namespace Sila.API.Client.Wallets
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletsRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WalletSearchFilters SearchFilters { get; set; }
    }
}