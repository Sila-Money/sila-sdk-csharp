namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkAccountRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserPrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PlaidToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SelectedAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RoutingNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PlaidTokenType { get; set; }
    }
}