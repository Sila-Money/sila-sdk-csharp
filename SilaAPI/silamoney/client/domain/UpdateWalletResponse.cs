using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateWalletResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public WalletResponse Wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Change> Changes { get; set; }
    }
}
