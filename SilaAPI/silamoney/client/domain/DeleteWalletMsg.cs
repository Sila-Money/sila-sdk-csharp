namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// DeleteWalletMsg object used in the Delete Wallet endpoint
    /// </summary>
    public partial class DeleteWalletMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// DeleteWalletMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        public DeleteWalletMsg(string userHandle,
            string authHandle)
        {
            this.Header = new Header(userHandle, authHandle);
        }
    }
}
