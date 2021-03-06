using Newtonsoft.Json;
using System.Runtime.Serialization;
using static SilaAPI.silamoney.client.domain.Header;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Wallet object used in the register wallet endpoint
    /// </summary>
    [DataContract]
    public class Wallet
    {
        /// <summary>
        /// String field used in the Wallet object to save blockchain_address
        /// </summary>
        [DataMember(Name = "blockchain_address", EmitDefaultValue = false)]
        [JsonProperty("blockchain_address")]
        public string BlockChainAddress { get; set; }
        /// <summary>
        /// String field used in the Wallet object to save blockchain_network
        /// </summary>
        [DataMember(Name = "blockchain_network", EmitDefaultValue = false)]
        [JsonProperty("blockchain_network")]
        public Crypto BlockChainNetwork { get; set; }
        /// <summary>
        /// String field used in the Wallet object to save nickname
        /// </summary>
        [DataMember(Name = "nickname", EmitDefaultValue = false)]
        public string Nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Wallet() { }

        /// <summary>
        /// Wallet constructor
        /// </summary>
        /// <param name="blockChainAddress"></param>
        /// <param name="blockChainNetwork"></param>
        /// <param name="nickname"></param>
        public Wallet(string blockChainAddress, Crypto blockChainNetwork, string nickname)
        {
            BlockChainAddress = blockChainAddress;
            BlockChainNetwork = blockChainNetwork;
            Nickname = nickname;
        }
    }
}
