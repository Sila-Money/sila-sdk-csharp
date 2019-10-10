namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// TransactionsResponse used in the get_transactions_msg endpoint response
    /// </summary>
    public class GetTransactionsResponse
    {
        /// <summary>
        /// String field used in the GetTransactionsResponse object to save reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// GetTransactionsResult object field used in the GetTransactionsResult object to save message
        /// </summary>
        public GetTransactionsResult Message { get; set; }
        /// <summary>
        /// String field used in the GetTransactionsResult object to save status
        /// </summary>
        public string Status { get; set; }
    }
}
