using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.refactored.api;
using SilaAPI.silamoney.client.refactored.domain;
using SilaAPI.silamoney.client.refactored.endpoints.transactions.gettransactions;
using System.Collections.Generic;

namespace SilaApiTest
{
    [TestClass]
    public class Test021GetTransactionsTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - GetTransactions - Successfully retrieve timeline of transactions")]
        public void T001_GetTransactionsWithTimeline()
        {
            GetTransactionsRequest request = new GetTransactionsRequest {
                SearchFilters = new SearchFilters {
                    ShowTimelines = true
                },
                UserHandle = DefaultConfig.FirstUser.UserHandle
            };

            GetTransactionsResponse response = GetTransactions.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Transactions.Count > 0);
            Assert.IsTrue(response.Transactions[0].Timeline.Count > 0);
        }

        [TestMethod("2 - GetTransactions - Successfully retrieve failed transactions")]
        public void T0012GetFailedTransactions()
        {

            GetTransactionsRequest request = new GetTransactionsRequest {
                SearchFilters = new SearchFilters {
                    ShowTimelines = true,
                    Statuses = new List<string> {"failed"}
                },
                UserHandle = DefaultConfig.FirstUser.UserHandle
            };

            GetTransactionsResponse response = GetTransactions.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Transactions.Count > 0);
            Assert.IsNotNull(response.Transactions[0].ReturnCode);
            Assert.IsNotNull(response.Transactions[0].ReturnDesc);
        }

    }
}
