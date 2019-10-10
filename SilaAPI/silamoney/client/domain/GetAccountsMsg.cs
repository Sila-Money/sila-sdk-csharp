namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// AccountMsg used in the get_accounts_msg endpoint
    /// </summary>
    public partial class GetAccountsMsg : BaseMessage
    {
        /// <summary>
        /// GetAccountsMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        public GetAccountsMsg(string userHandle, string authHandle)
        {
            this.Header = new Header(userHandle, authHandle);
            this.MessageOption = Message.GetAccountsMsg;
        }
    }
}
