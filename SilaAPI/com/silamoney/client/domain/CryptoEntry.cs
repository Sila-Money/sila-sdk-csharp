using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.com.silamoney.client.domain
{
    [DataContract]
    public partial class CryptoEntry
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CryptoCodeEnum
        {
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
        [DataMember(Name = "crypto_alias", EmitDefaultValue = false)]
        public string cryptoAlias { get; set; }
        [DataMember(Name = "crypto_address", EmitDefaultValue = false)]
        public string cryptoAddress { get; set; }
        [DataMember(Name = "crypto_code", EmitDefaultValue = false)]
        public CryptoCodeEnum cryptoCode { get; set; }

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
