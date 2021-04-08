using System.Runtime.Serialization;

namespace SilaAPI.Silamoney.Client.Refactored.Domain
{
    /// <summary>
    /// Crypto_Entry object used in the entity_msg object
    /// </summary>
    [DataContract]
    public class CryptoEntry
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
        public string CryptoCode { get; set; } = "ETH";
    }
}
