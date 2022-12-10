using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test050StatementsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetStatement - Succesfully")]
        public void T001GetStatementResponse200Success()
        {
            var filters = new StatementSearchFilters()
            {
                Month = "07-2022",
                Page = 1,
                PerPage = 100
            };
            var user = DefaultConfig.FirstUser;
            var response = api.GetStatementsData(user.UserHandle, filters);
            var parsedResponse = (GetStatementResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Page);
            Assert.IsNotNull(parsedResponse.TotalCount);
            Assert.IsNotNull(parsedResponse.ReturnedCount);
            Assert.IsNotNull(parsedResponse.Statements.Count);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - GetWalletStatement - Succesfully")]
        public void T002GetWalletStatementResponse200Success()
        {
            var filters = new StatementSearchFilters()
            {
                StartMonth = "07-2022",
                EndMonth = "08-2022",
                Page = 1,
                PerPage = 100
            };
            var user = DefaultConfig.FirstUser;
            var responseWallet = api.GetWallet(user.UserHandle, user.PrivateKey);
            var parsedResponseWallet = (SingleWalletResponse)responseWallet.Data;

            var response = api.GetWalletStatementData(user.UserHandle, parsedResponseWallet.Wallet.WalletId, filters);
            var parsedResponse = (GetStatementResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Page);
            Assert.IsNotNull(parsedResponse.TotalCount);
            Assert.IsNotNull(parsedResponse.ReturnedCount);
            Assert.IsNotNull(parsedResponse.Statements.Count);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}

