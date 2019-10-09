using System;
using System.Collections.Generic;
using System.Text;

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
        public string reference { get; set; }
        /// <summary>
        /// GetTransactionsResult object field used in the GetTransactionsResult object to save message
        /// </summary>
        public GetTransactionsResult message { get; set; }
        /// <summary>
        /// String field used in the GetTransactionsResult object to save status
        /// </summary>
        public string status { get; set; }
    }
}
