using System.Collections.Generic;
using SilaAPI.Silamoney.Client.Refactored.Domain;

namespace SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.GetAccounts
{
    public class GetAccountsResponse
    {
        public List<Account> Accounts { get; private set; }

        public GetAccountsResponse(List<Account> accounts) {
            Accounts = accounts;
        }
    }
}