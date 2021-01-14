using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaApiTest
{
    [TestClass]
    public class Test021GetTransactionsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetTransactions - Successfully retrieve timeline of transactions")]
        public void T001_GetTransactionsWithTimeline()
        {
            SearchFilters filters = new SearchFilters(showTimelines: true);
            var response = api.GetTransactions(DefaultConfig.FirstUser.UserHandle, DefaultConfig.FirstUser.PrivateKey, filters);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (GetTransactionsResult)response.Data;
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
            Assert.IsNotNull(parsedResponse.Transactions[0].TimeLine);
            Assert.IsTrue(parsedResponse.Transactions[0].TimeLine.Count > 0);
        }

    }
}
