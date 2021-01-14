using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Threading;

namespace SilaApiTest
{
    public class GetTransactionsTest
    {
        private static SilaApi api = DefaultConfig.Client;

        public static void Poll(string userHandle, string userPrivateKey, SearchFilters filters, string result)
        {
            var response = api.GetTransactions(userHandle, userPrivateKey, filters);
            var statusCode = response.StatusCode;
            var parsedResponse = (GetTransactionsResult)response.Data;
            var transactionStatus = parsedResponse.Transactions[0].Status;

            while (statusCode == 200 && (transactionStatus == "pending" || transactionStatus == "queued"))
            {
                Console.WriteLine("Transaction waiting 30 seconds...");
                Thread.Sleep(30000);
                response = api.GetTransactions(userHandle, userPrivateKey, filters);
                statusCode = response.StatusCode;
                parsedResponse = (GetTransactionsResult)response.Data;
                transactionStatus = parsedResponse.Transactions[0].Status;
            }

            Assert.AreEqual(200, statusCode);
            Assert.AreEqual(result, transactionStatus);
        }
    }
}
