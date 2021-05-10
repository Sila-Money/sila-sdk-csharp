using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// Header object used in HeaderMsg
    /// </summary>
    [DataContract]
    public class Header
    {
        /// <summary>
        /// Enum field used in Header object to select version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }
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
        public string AppHandle { get; set; }
        /// <summary>
        /// Enum field used in the Header object to select crypto
        /// </summary>
        [DataMember(Name = "crypto", EmitDefaultValue = false)]
        public string Crypto { get; set; } = "ETH";
    }
}
