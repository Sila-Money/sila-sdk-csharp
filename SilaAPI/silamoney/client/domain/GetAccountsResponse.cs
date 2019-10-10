using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// AccountResponse object used in the get_accounts_msg endpoint response
    /// </summary>
    public class GetAccountsResponse
    {
        /// <summary>
        /// String field used in the GetAccountsResponse object to save reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// List of Accounts objects used in the GetAccountsResponse object to save message
        /// </summary>
        public List<Account> Message { get; set; }
        /// <summary>
        /// String field used in the GetAccountsResponse object to save status
        /// </summary>
        public string Status { get; set; }
    }
}
