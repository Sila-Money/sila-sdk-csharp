using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.Model
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

        public Header(string reference = default(string), string userHandle = default(string), string authHandle = default(string))
        {
            if (reference == null)
            {
                throw new InvalidDataException("reference is a required property for Header and cannot be null");
            }
            else
            {
                this.reference = reference;
            }
            if (userHandle == null)
            {
                throw new InvalidDataException("userHandle is a required property for Header and cannot be null");
            }
            else
            {
                this.userHandle = userHandle;
            }
            if (authHandle == null)
            {
                throw new InvalidDataException("authHandle is a required property for Header and cannot be null");
            }
            else
            {
                this.authHandle = authHandle;
            }

            this.crypto = CryptoEnum.ETH;
            this.version = VersionEnum._02;
            this.created = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        [DataMember(Name="version", EmitDefaultValue=false)]
        public VersionEnum version { get; set; }
        
        [DataMember(Name="reference", EmitDefaultValue=false)]
        public string reference { get; set; }

        [DataMember(Name="created", EmitDefaultValue=false)]
        public int created { get; set; }

        [DataMember(Name="user_handle", EmitDefaultValue=false)]
        public string userHandle { get; set; }

        [DataMember(Name="auth_handle", EmitDefaultValue=false)]
        public string authHandle { get; set; }

        [DataMember(Name="crypto", EmitDefaultValue=false)]
        public CryptoEnum crypto { get; set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
