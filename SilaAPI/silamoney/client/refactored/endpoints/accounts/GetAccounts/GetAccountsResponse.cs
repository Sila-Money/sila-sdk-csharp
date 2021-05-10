using System.Collections.Generic;
using Sila.API.Client.Domain;

namespace Sila.API.Client.Accounts.GetAccounts
{
    public class GetAccountsResponse
    {
        public List<Account> Accounts { get; private set; }

        public GetAccountsResponse(List<Account> accounts) {
            Accounts = accounts;
        }
    }
}