namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkAccountMxRequest
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
        public string Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderTokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountId { get; set; }
    }
}