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
        /// <param name="androidPackageName"></param>
        public PlaidLinkTokenMsg(string userHandle, string authHandle, string androidPackageName)
        {
            Header = new Header(userHandle, authHandle, androidPackageName);
        }
    }
}
