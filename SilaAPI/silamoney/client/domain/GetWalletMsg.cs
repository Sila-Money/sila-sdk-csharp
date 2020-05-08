using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// GetWalletMsg object used in the Get Wallet endpoint
    /// </summary>
    public partial class GetWalletMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// GetWalletMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        public GetWalletMsg(string userHandle,
            string authHandle)
        {
            this.Header = new Header(userHandle, authHandle);
        }
    }
}
