using System.Runtime.Serialization;
using static SilaAPI.silamoney.client.domain.Header;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class WalletSearchFilters : SearchFilterBase
    {
        /// New Params for Get Wallets Endpoint
        /// <summary>
        /// String field used in the SearchFilters object to save blockchain_address
        /// </summary>
        [DataMember(Name = "blockchain_address", EmitDefaultValue = false)]
        public string BlockChainAddress { get; set; }
        /// <summary>
        /// String field used in the SearchFilters object to save blockchain_network
        /// </summary>
        [DataMember(Name = "blockchain_network", EmitDefaultValue = false)]
        public Crypto BlockChainNetwork { get; set; }
        /// <summary>
        /// String field used in the SearchFilters object to save nickname
        /// </summary>
        [DataMember(Name = "nickname", EmitDefaultValue = false)]
        public string Nickname { get; set; }

        /// <summary>
        /// String field used in the SearchFilters object to save uuid
        /// </summary>
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public string UuId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockChainAddress"></param>
        /// <param name="blockChainNetwork"></param>
        /// <param name="nickname"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="sortAscending"></param>
        /// <param name="uuid"></param>
        public WalletSearchFilters(string blockChainAddress = default,
            Crypto blockChainNetwork = default,
            string nickname = default,
            int? page = default,
            int? perPage = default,
            bool? sortAscending = default,
            string uuid = default) : base(page, perPage, sortAscending)
        {
            BlockChainAddress = blockChainAddress;
            BlockChainNetwork = blockChainNetwork;
            Nickname = nickname;
            UuId = uuid;
        }
    }
}
