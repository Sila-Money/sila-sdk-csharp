namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckInstantACHRequest
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
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KycLevel { get; set; } = null;
    }
}