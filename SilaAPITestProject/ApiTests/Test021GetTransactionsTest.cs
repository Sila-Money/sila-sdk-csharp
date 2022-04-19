using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test021GetTransactionsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetTransactions - Successfully retrieve timeline of transactions")]
        public void T001_GetTransactionsWithTimeline()
        {
            var response = api.GetTransactions(
                userHandle: DefaultConfig.FirstUser.UserHandle, 
                searchFilters: new SearchFilters {
                    ShowTimelines = true
                }
            );

            var parsedResponse = (GetTransactionsResult) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
            Assert.IsTrue(parsedResponse.Transactions[0].TimeLines.Count > 0);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

    }
}
