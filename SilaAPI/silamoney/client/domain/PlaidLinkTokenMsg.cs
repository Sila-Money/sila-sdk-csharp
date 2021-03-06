using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// PlaidLinkTokenMsg object used in the plaid link token endpoint
    /// </summary>
    [DataContract]
    public partial class PlaidLinkTokenMsg : BaseMessageNoMsg
    {

        /// <summary>
        /// PlaidLinkTokenMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        public PlaidLinkTokenMsg(string userHandle,
            string authHandle)
        {
            Header = new Header(userHandle, authHandle);
        }
    }
}
