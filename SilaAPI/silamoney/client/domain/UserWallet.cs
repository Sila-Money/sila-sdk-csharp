using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UserWallet
    {
        /// <summary>
        /// 
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserWallet()
        {
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            PrivateKey = ecKey.GetPrivateKey();
            Address = ecKey.GetPublicAddress();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="blockchainAddress"></param>
        public UserWallet(string privateKey, string blockchainAddress)
        {
            PrivateKey = privateKey;
            Address = blockchainAddress;
        }
    }
}
