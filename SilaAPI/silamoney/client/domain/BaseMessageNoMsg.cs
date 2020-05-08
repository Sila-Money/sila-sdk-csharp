using System.Runtime.Serialization;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Parent object used in all the message objects
    /// </summary>
    [DataContract]
    public partial class BaseMessageNoMsg
    {
        /// <summary>
        /// Header object field used in the BaseMessageNoMsg object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }
    }
}
