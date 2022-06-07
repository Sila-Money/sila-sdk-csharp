using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    internal class DeleteRegistrationMsg
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "header")]
        public Header Header { get; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "uuid")]
        public string Uuid { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHandle"></param>
        /// <param name="userHandle"></param>
        /// <param name="uuid"></param>
        public DeleteRegistrationMsg(string authHandle, string userHandle, string uuid)
        {
            Header = new Header(userHandle, authHandle);
            Uuid = uuid;
        }
    }
}
