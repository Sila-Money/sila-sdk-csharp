using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Header object used in HeaderMsg
    /// </summary>
    [DataContract]
    public partial class Header
    {
        /// <summary>
        /// EnumMember values for Version field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VersionEnum
        {
            [EnumMember(Value = "0.2")]
            _02 = 1,
            [EnumMember(Value = "v0.2")]
            V02 = 2
        }
        /// <summary>
        /// EnumMember values for Crypto field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CryptoEnum
        {
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
        
        /// <summary>
        /// Enum field used in Header object to select version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public VersionEnum version { get; set; }
        /// <summary>
        /// String field used in Header object to save reference
        /// </summary>
        [DataMember(Name = "reference", EmitDefaultValue = false)]
        public string reference { get; set; }
        /// <summary>
        /// Integer field used in the Header object to save created
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public int created { get; set; }
        /// <summary>
        /// String field used in the Header object to save user handle
        /// </summary>
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string userHandle { get; set; }
        /// <summary>
        /// String field used in the Header object to save auth handle
        /// </summary>
        [DataMember(Name = "auth_handle", EmitDefaultValue = false)]
        public string authHandle { get; set; }
        /// <summary>
        /// Enum field used in the Header object to select crypto
        /// </summary>
        [DataMember(Name = "crypto", EmitDefaultValue = false)]
        public CryptoEnum crypto { get; set; }

        /// <summary>
        /// Header constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <returns></returns>
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
