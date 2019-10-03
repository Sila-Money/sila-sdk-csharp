using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization;

namespace SilaAPI.Model
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
        public CryptoEntry(string cryptoAlias = default(string), string cryptoAddress = default(string), CryptoCodeEnum cryptoCode = default(CryptoCodeEnum))
        {
            if (cryptoAlias == null)
            {
                throw new InvalidDataException("cryptoAlias is a required property for CryptoEntry and cannot be null");
            }
            else
            {
                this.cryptoAlias = cryptoAlias;
            }
            if (cryptoAddress == null)
            {
                throw new InvalidDataException("cryptoAddress is a required property for CryptoEntry and cannot be null");
            }
            else
            {
                if(cryptoAddress.Substring(0,2).ToString() != "0x")
                {
                    throw new InvalidDataException("cryptoAddress must starts with 0x");
                }
                else
                {
                    this.cryptoAddress = cryptoAddress;
                }
            }
            if (cryptoCode == null)
            {
                throw new InvalidDataException("cryptoCode is a required property for CryptoEntry and cannot be null");
            }
            else
            {
                this.cryptoCode = cryptoCode;
            }
        }
        
        [DataMember(Name="crypto_alias", EmitDefaultValue=false)]
        public string cryptoAlias { get; set; }

        [DataMember(Name="crypto_address", EmitDefaultValue=false)]
        public string cryptoAddress { get; set; }

        [DataMember(Name="crypto_code", EmitDefaultValue=false)]
        public CryptoCodeEnum cryptoCode { get; set; }
    }
}
