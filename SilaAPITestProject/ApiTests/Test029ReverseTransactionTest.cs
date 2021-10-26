using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

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

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
            Assert.AreEqual("CARD", parsedResponse.Transactions[0].ProcessingType);
        }

        [TestMethod("3 - Reverse Transaction - Successful reverse Transaction")]
        public void Response200ReverseTransaction()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.ReverseTransaction(user.UserHandle, user.PrivateKey, DefaultConfig.TransactionId);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual("SUCCESS", parsedResponse.Status);           
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);


            //ApiResponse<object> response = api.ReverseTransaction(userHandle, userPrivateKey, transactionId);

            //// Success Response Object
            //Console.WriteLine(response.StatusCode); 
            //Console.WriteLine(((ReverseTransactionResult)response.Data).Reference); // Random reference number
            //Console.WriteLine(((ReverseTransactionResult)response.Data).Success); // true            
            //Console.WriteLine(((ReverseTransactionResult)response.Data).Status); // SUCCESS
            //Console.WriteLine(((ReverseTransactionResult)response.Data).Message); // Transaction successfully reverse.  
        }


    }
}

