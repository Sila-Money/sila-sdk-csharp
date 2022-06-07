using Sila.API.Client.Domain;
namespace Sila.API.Client.Wallets
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterWalletRequest
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
        public UserWallet Wallet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDefault { get; set; }
    }

}
