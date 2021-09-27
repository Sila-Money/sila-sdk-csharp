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
        public Version VersionOption { get; set; }
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
        [DataMember(Name = "app_handle", EmitDefaultValue = false)]
        public string AuthHandle { get; set; }
        /// <summary>
        /// Enum field used in the Header object to select crypto
        /// </summary>
        [DataMember(Name = "crypto", EmitDefaultValue = false)]
        public Crypto CryptoOption { get; set; }
        /// <summary>
        /// string field used in the Header object to save android_package_name
        /// </summary>
        [DataMember(Name = "android_package_name", EmitDefaultValue = false)]
        public string AndroidPackageName { get; set; }

        /// <summary>
        /// Header constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="androidPackageName"></param>
        /// <returns></returns>
        public Header(string userHandle = default, string authHandle = default, string androidPackageName = default)
        {
            UserHandle = userHandle;
            AuthHandle = authHandle;
            CryptoOption = Crypto.ETH;
            VersionOption = Version._02;
            Created = ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds) - 100;
            Reference = Guid.NewGuid().ToString();
            AndroidPackageName = androidPackageName;
        }
    }
}
