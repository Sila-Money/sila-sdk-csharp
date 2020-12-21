using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateWalletResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SingleWallet Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Change> Changes { get; set; }
    }
}
