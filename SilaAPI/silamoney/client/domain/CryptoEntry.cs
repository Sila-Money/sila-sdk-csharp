using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Crypto_Entry object used in the entity_msg object
    /// </summary>
    [DataContract]
    public partial class CryptoEntry
    {
        /// <summary>
        /// String field used in the CryptoEntry object to save crypto alias
        /// </summary>
        [DataMember(Name = "crypto_alias", EmitDefaultValue = false)]
        public string CryptoAlias { get; set; }
        /// <summary>
        /// String field used in the CryptoEntry object to save crypto address
        /// </summary>
        [DataMember(Name = "crypto_address", EmitDefaultValue = false)]
        public string CryptoAddress { get; set; }
        /// <summary>
        /// Enum field used in the CryptoEntry object to select crypto code
        /// </summary>
        [DataMember(Name = "crypto_code", EmitDefaultValue = false)]
        public CryptoCode CryptoCodeOption { get; set; }

        /// <summary>
        /// If user is not null, set user values in the CryptoEntry object
        /// </summary>
        /// <param name="user"></param>
        public CryptoEntry(User user)
        {
            if (user != null)
            {
                this.CryptoAlias = "";
                this.CryptoCodeOption = CryptoCode.ETH;
                this.CryptoAddress = user.CryptopAddress;
            }
        }

        /// <summary>
        /// If user is not null, set user values in the CryptoEntry object
        /// </summary>
        /// <param name="user"></param>
        public CryptoEntry(BusinessUser user)
        {
            if (user != null)
            {
                this.CryptoAlias = "";
                this.CryptoCodeOption = CryptoCode.ETH;
                this.CryptoAddress = user.CryptopAddress;
            }
        }
    }
}
