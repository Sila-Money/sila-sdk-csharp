using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.domain
{
    [DataContract]
    public partial class Header
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VersionEnum
        {
            [EnumMember(Value = "0.2")]
            _02 = 1,
            [EnumMember(Value = "v0.2")]
            V02 = 2
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CryptoEnum
        {
            [EnumMember(Value = "ETH")]
            ETH = 1
        }

        [DataMember(Name = "version", EmitDefaultValue = false)]
        public VersionEnum version { get; set; }
        [DataMember(Name = "reference", EmitDefaultValue = false)]
        public string reference { get; set; }
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public int created { get; set; }
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string userHandle { get; set; }
        [DataMember(Name = "auth_handle", EmitDefaultValue = false)]
        public string authHandle { get; set; }
        [DataMember(Name = "crypto", EmitDefaultValue = false)]
        public CryptoEnum crypto { get; set; }

        public Header(string userHandle = default(string),
            string authHandle = default(string)
            )
        {
            this.userHandle = userHandle;
            this.authHandle = authHandle;

            this.crypto = CryptoEnum.ETH;
            this.version = VersionEnum._02;
            this.created = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            this.reference = (new Random()).ToString();
        }
    }
}
