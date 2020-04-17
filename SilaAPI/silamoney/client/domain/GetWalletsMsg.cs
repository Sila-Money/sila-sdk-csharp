using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletsMsg used in the Get Wallets endpoint
    /// </summary>
    [DataContract]
    public partial class GetWalletsMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// Search filters object field used in the GetWalletsMsg to save search filters
        /// </summary>
        [DataMember(Name = "search_filters", EmitDefaultValue = false)]
        public WalletSearchFilters SearchFilters { get; set; }

        /// <summary>
        /// GetWalletsMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="searchFilters"></param>
        /// <returns></returns>
        public GetWalletsMsg(string userHandle, string authHandle, WalletSearchFilters searchFilters = default)
        {
            Header = new Header(userHandle, authHandle);
            SearchFilters = searchFilters;
        }
    }
}
