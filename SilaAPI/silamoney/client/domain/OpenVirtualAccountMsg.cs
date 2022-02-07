using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{   /// <summary>
    /// DeleteTransactionMsg object used in the open_virtual_account endpoint
    /// </summary>
    public partial class OpenVirtualAccountMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "virtual_account_name", EmitDefaultValue = false)]
        public string VirtualAccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        /// <param name="virtualAccountName"></param>
        public OpenVirtualAccountMsg(string userHandle, string appHandle, string virtualAccountName)
        {
            Header = new Header(userHandle, appHandle);
            VirtualAccountName = virtualAccountName;
        }
    }
}
