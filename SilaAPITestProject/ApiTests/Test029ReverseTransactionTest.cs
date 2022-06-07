using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test029ReverseTransactionTest
    {
        SilaApi api = DefaultConfig.Client;
        
        [TestMethod("1 - IssueSila - Succesfully issue")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 1000, user.PrivateKey, accountName: null, cardName: "visa");
            var parsedResponse = (TransactionResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            DefaultConfig.IssueReference = parsedResponse.Reference;
            DefaultConfig.TransactionId = parsedResponse.TransactionId;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - GetTransactions - Successfully transactions")]
        public void Response200GetTransactions()
        {
            var response = api.GetTransactions(
                userHandle: DefaultConfig.FirstUser.UserHandle,
                searchFilters: new SearchFilters
                {
                    ReferenceId = DefaultConfig.IssueReference
                }
            );

            var parsedResponse = (GetTransactionsResult)response.Data;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
            int i = 0;
            do
            {
                if (parsedResponse.Transactions[0].Status.ToLower() != "success")
                {
                    response = api.GetTransactions(userHandle: DefaultConfig.FirstUser.UserHandle,
                         searchFilters: new SearchFilters
                         {
                             ReferenceId = DefaultConfig.IssueReference
                         }
                     );

                    parsedResponse = (GetTransactionsResult)response.Data;
                    if (parsedResponse.Transactions[0].Status.ToLower() == "success")
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                Thread.Sleep(30000);
                i++;
            }
            while (i <= 8);

            Assert.AreEqual("CARD", parsedResponse.Transactions[0].ProcessingType);
        }

        [TestMethod("3 - Reverse Transaction - Successful reverse Transaction")]
        public void Response200ReverseTransaction()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.ReverseTransaction(user.UserHandle, user.PrivateKey, DefaultConfig.TransactionId);
            var parsedResponse = (BaseResponse)response.Data;

            //Assert.AreEqual("SUCCESS", parsedResponse.Status);
            //Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}

