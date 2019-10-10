using System;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Header object used in HeaderMsg
    /// </summary>
    [DataContract]
    public partial class Header
    {
        /// <summary>
        /// Enum field used in Header object to select version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public VersionEnum Version { get; set; }
        /// <summary>
        /// String field used in Header object to save reference
        /// </summary>
        [DataMember(Name = "reference", EmitDefaultValue = false)]
        public string Reference { get; set; }
        /// <summary>
        /// Integer field used in the Header object to save created
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public int Created { get; set; }
        /// <summary>
        /// String field used in the Header object to save user handle
        /// </summary>
        [DataMember(Name = "user_handle", EmitDefaultValue = false)]
        public string UserHandle { get; set; }
        /// <summary>
        /// String field used in the Header object to save auth handle
        /// </summary>
        [DataMember(Name = "auth_handle", EmitDefaultValue = false)]
        public string AuthHandle { get; set; }
        /// <summary>
        /// Enum field used in the Header object to select crypto
        /// </summary>
        [DataMember(Name = "crypto", EmitDefaultValue = false)]
        public CryptoEnum Crypto { get; set; }

        /// <summary>
        /// Header constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <returns></returns>
        public Header(string userHandle = default,
            string authHandle = default
            )
        {
            this.UserHandle = userHandle;
            this.AuthHandle = authHandle;

            this.Crypto = CryptoEnum.ETH;
            this.Version = VersionEnum._02;
            this.Created = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            this.Reference = (new Random()).Next(1, 999999).ToString();
        }
    }
}
