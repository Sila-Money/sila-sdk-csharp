namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// SilaBalanceRequest used in the ApiResponse
    /// </summary>
    public class SilaBalanceRequest
    {
        /// <summary>
        /// String field used in the SilaBalanceRequest object to save address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// SilaBalanceRequest constructor
        /// </summary>
        /// <param name="address"></param>
        public SilaBalanceRequest(string address)
        {
            this.Address = address;
        }
    }
}
