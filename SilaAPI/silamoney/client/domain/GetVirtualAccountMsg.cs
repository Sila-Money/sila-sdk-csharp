using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_id", EmitDefaultValue = false)]
        public string VirtualAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="virtualAccountId"></param>
        public GetVirtualAccountMsg(string userHandle, string appHandle, string virtualAccountId)
        {
            Header = new Header(userHandle, appHandle);
            VirtualAccountId = virtualAccountId;
        }
    }
}
