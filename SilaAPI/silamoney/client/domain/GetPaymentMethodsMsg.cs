using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPaymentMethodsMsg : BaseMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        public GetPaymentMethodsMsg(string userHandle, string appHandle)
        {
            Header = new Header(userHandle, appHandle);
        }
    }
}
