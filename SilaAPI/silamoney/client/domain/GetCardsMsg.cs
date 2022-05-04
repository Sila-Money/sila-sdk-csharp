using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetCardsMsg object used in the GetCards endpoint
    /// </summary>
    [DataContract]
    public partial class GetCardsMsg
    {
        /// <summary>
        /// The header object
        /// </summary>
        [DataMember(Name = "header", EmitDefaultValue = false)]
        public Header Header { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        public GetCardsMsg(string userHandle, string authHandle)
        {
            this.Header = new Header(userHandle, authHandle);
        }
    }
}
