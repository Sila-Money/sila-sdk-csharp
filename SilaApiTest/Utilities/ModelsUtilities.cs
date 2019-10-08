using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilaApiTest
{
    public class ModelsUtilities
    {
        public static User createUser()
        {
            return new User("user.silamoney.eth", "Example", "User", "Example User", "123452222", "1234567890", "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", "0x65a796a4bD3AaF6370791BefFb1A86EAcfdBc3C1", new DateTime(1990, 05, 19));
        }
                    
        public static GetTransactionsResult createTransactionResult() {
            GetTransactionsResult responseMessage = new GetTransactionsResult();
            responseMessage.success = true;
            responseMessage.page = 1;
            responseMessage.returnedCount = 1;
            responseMessage.totalCount = 1;
            responseMessage.transactions = createTransactions();

            return responseMessage;
        }

        private static List<Transaction> createTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = new Transaction();
            transaction.userHandle = "user.silamoney.eth";
            transaction.referenceId = "ref";
            transaction.transactionHash = "0x1234567890abcdef1234567890abcdef";
            transaction.transactionType = "issue";
            transaction.silaAmount = 1000;
            transaction.bankAccountName = "default";
            transaction.handleAddress = "0x65a796a4bD3AaF6370791BefFb1A86EAcfdBc3C1";
            transaction.status = "success";
            transaction.usdStatus = "success";
            transaction.tokenStatus = "success";
            transaction.created = "2019-04-03T00:00:00.000Z";
            transaction.lastUpdate = "2019-04-03T00:00:00.003Z";
            transaction.createdEpoch = 1234567890;
            transaction.lastUpdateEpoch = 1234567899;
            transaction.timeLines = createTimeLines();

            transactions.Add(transaction);

            return transactions;
        }

        private static List<TimeLine> createTimeLines()
        {
            List<TimeLine> timeLines = new List<TimeLine>();
            TimeLine timeLine = new TimeLine();
            timeLine.date = "2019-04-03T00:00:00.000Z";
            timeLine.dateEpoch = 1234567890;
            timeLine.status = "queued";
            timeLine.usdStatus = "not started";
            timeLine.tokenStatus = "not started";

            timeLines.Add(timeLine);

            return timeLines;
        }

        internal static List<Account> createGetAccountsResult()
        {
            List<Account> accounts = new List<Account>();
            Account account = new Account();
            account.accountName = "default";
            account.accountNumber = "1234";
            account.accountStatus = "active";
            account.accountType = "CHEKING";

            accounts.Add(account);

            return accounts;
        }
    }
}
