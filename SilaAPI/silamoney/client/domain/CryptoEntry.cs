using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
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
        /// EnumMember values for CryptoCode field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CryptoCodeEnum
        {
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
        /// <summary>
        /// String field used in the CryptoEntry object to save crypto alias
        /// </summary>
        [DataMember(Name = "crypto_alias", EmitDefaultValue = false)]
        public string cryptoAlias { get; set; }
        /// <summary>
        /// String field used in the CryptoEntry object to save crypto address
        /// </summary>
        [DataMember(Name = "crypto_address", EmitDefaultValue = false)]
        public string cryptoAddress { get; set; }
        /// <summary>
        /// Enum field used in the CryptoEntry object to select crypto code
        /// </summary>
        [DataMember(Name = "crypto_code", EmitDefaultValue = false)]
        public CryptoCodeEnum cryptoCode { get; set; }

        /// <summary>
        /// If user is not null, set user values in the CryptoEntry object
        /// </summary>
        /// <param name="user"></param>
        public CryptoEntry(User user)
        {
            if (user != null)
            {
                this.cryptoAlias = "";
                this.cryptoCode = CryptoCodeEnum.ETH;
                this.cryptoAddress = user.cryptopAddress;
            }
        }
    }
}
