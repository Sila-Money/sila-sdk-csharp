using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Parent object used in all the message objects
    /// </summary>
    [DataContract]
    public partial class BaseMessage
    {
        /// <summary>
        /// Header object field used in the BaseMessage object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
        /// <summary>
        /// Enum field used in the BaseMessage object to select message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public Message MessageOption { get; set; }
    }
}
