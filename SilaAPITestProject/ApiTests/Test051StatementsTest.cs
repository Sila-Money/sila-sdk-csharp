using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test051StatementsTest
    {
        SilaApi api = DefaultConfig.Client;

        //[TestMethod("1 - Statements - Succesfully")]
        //public void T001StatementsResponse200Success()
        //{
        //    var filters = new StatementsSearchFilters()
        //    {
        //        StartDate = "2022-07-19",
        //        EndDate = "2022-09-20",
        //        UserName = "Postman User",
        //        UserHandle = "1659592367",
        //        AccountType = "blockchain_address",
        //        Email = "pulkit2@silamoney.com",
        //        Identifier = "3531854e-0d04-431b-9534-7ac309ae625f",
        //        Page = 1,
        //        Status = "Unsent",
        //        PerPage = 10
        //    };
        //    var user = DefaultConfig.FirstUser;

        //    var response = api.Statements(user.UserHandle, user.PrivateKey, filters);
        //    var parsedResponse = (StatementsResponse)response.Data;
        //    Assert.AreEqual(200, response.StatusCode);
        //    Assert.IsTrue(parsedResponse.Success);
        //    Assert.IsNotNull(parsedResponse.Status);
        //    Assert.IsNotNull(parsedResponse.DeliveryAttempts.Count);
        //    Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        //}

        [TestMethod("2 - Statements with StatementId - Succesfully")]
        public void T002ResendStatementsResponse200Success()
        {
            var filters_resend = new StatementsSearchFilters()
            {
                Email = "gaurav.mehta@silamoney.com",
            };
            var user_resend = DefaultConfig.FirstUser;
            string StatementId = "59a4feba-0fcd-40ac-bd9a-59e47da0b640";
            var response_resend = api.ResendStatements(user_resend.UserHandle, user_resend.PrivateKey, StatementId, filters_resend);
            var parsedResponse_resend = (StatementsResponse)response_resend.Data;
            Assert.AreEqual(200, response_resend.StatusCode);
            Assert.IsTrue(parsedResponse_resend.Success);
            Assert.IsNotNull(parsedResponse_resend.Status);
            Assert.IsNotNull(parsedResponse_resend.Reference);
            Assert.IsNotNull(parsedResponse_resend.ResponseTimeMs);
        }

        //[TestMethod("2 - Statements - Succesfully")]
        //public void T002StatementsResponse200Success()
        //{
        //    var filters = new StatementsSearchFilters()
        //    {
        //        StartDate = "2022-07-19",
        //        EndDate = "2022-09-20",
        //        UserName = "Postman User",
        //        UserHandle = "1659592367",
        //        AccountType = "blockchain_address",
        //        Email = "pulkit2@silamoney.com",
        //        Identifier = "3531854e-0d04-431b-9534-7ac309ae625f",
        //        Page = 1,
        //        Status = "Unsent",
        //        PerPage = 10
        //    };
        //    var user = DefaultConfig.FirstUser;
        //    var responseWallet = api.GetWallet(user.UserHandle, user.PrivateKey);
        //    var parsedResponseWallet = (SingleWalletResponse)responseWallet.Data;

        //    var response = api.Statements(user.UserHandle, parsedResponseWallet.Wallet.WalletId, filters);
        //    var parsedResponse = (GetStatementResponse)response.Data;
        //    Assert.AreEqual(200, response.StatusCode);
        //    Assert.IsTrue(parsedResponse.Success);
        //    Assert.IsNotNull(parsedResponse.Status);
        //    Assert.IsNotNull(parsedResponse.Page);
        //    Assert.IsNotNull(parsedResponse.TotalCount);
        //    Assert.IsNotNull(parsedResponse.ReturnedCount);
        //    Assert.IsNotNull(parsedResponse.Statements.Count);
        //    Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        //}
    }
}

