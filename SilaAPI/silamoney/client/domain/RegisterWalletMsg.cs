using SilaAPI.silamoney.client.security;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// RegisterWalletMsg object used in the plaid same day auth endpoint
    /// </summary>
    public partial class RegisterWalletMsg : BaseMessageNoMsg
    {
        /// <summary>
        /// Wallet field used in the RegisterWalletMsg object to save wallet
        /// </summary>
        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }        
        /// <summary>
        /// String field used in the RegisterWalletMsg object to save wallet_verification_signature
        /// </summary>
        [DataMember(Name = "wallet_verification_signature", EmitDefaultValue = false)]
        public string WalletVerificationSignature { get; set; }   

        /// <summary>
        /// RegisterWalletMsg constructor
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="authHandle"></param>
        /// <param name="wallet"></param>        
        /// <param name="nickname"></param>
        public RegisterWalletMsg(string userHandle,
            string authHandle,
            UserWallet wallet,
            string nickname)
        {
            Header = new Header(userHandle, authHandle);
            WalletVerificationSignature = Signer.Sign(wallet.Address, wallet.PrivateKey);
            Wallet = new Wallet(wallet.Address, Header.Crypto.ETH, nickname);
        }
    }
}
