using System.Collections.Generic;
using System.Reflection;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// HeaderMsg object used in check_handle, request_kyc and check_kyc endpoints
    /// </summary>
    public partial class HeaderMsg : BaseMessage
    {
        /// <summary>
        /// HeaderMsg constructor
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="authHandle"></param>
        public HeaderMsg(string handle, string authHandle)
        {
            this.Header = new Header(handle, authHandle);
            this.MessageOption = Message.HeaderMsg;
        }
    }
}
