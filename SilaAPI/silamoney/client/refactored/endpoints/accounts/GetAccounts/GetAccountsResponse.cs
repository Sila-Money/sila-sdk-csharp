using System.Collections.Generic;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccountsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Account> Accounts { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accounts"></param>
        public GetAccountsResponse(List<Account> accounts) {
            Accounts = accounts;
        }
    }
}