using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test018GetAccountBalanceTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetAccountBalance - Successful plaid account balance")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var firstResponse = api.GetAccountBalance(user.UserHandle, user.PrivateKey, "defaultpt");

            Assert.AreEqual(200, firstResponse.StatusCode, $"{user.UserHandle} account 'default' should success get_accounts");
            var parsedResponse = (GetAccountBalanceResponse)firstResponse.Data;
            Assert.AreEqual("defaultpt", parsedResponse.AccountName, $"{user.UserHandle} account 'default' should match account_name");
            Assert.IsTrue(parsedResponse.Success);

            var secondResponse = api.GetAccountBalance(user.UserHandle, user.PrivateKey, "sync_by_id");

            Assert.AreEqual(200, secondResponse.StatusCode, $"{user.UserHandle} account 'sync_by_id' should success get_accounts");
            parsedResponse = (GetAccountBalanceResponse)secondResponse.Data;
            Assert.AreEqual("sync_by_id", parsedResponse.AccountName, $"{user.UserHandle} account 'sync_by_id' should match account_name");
            Assert.IsTrue(parsedResponse.Success);
        }

        [TestMethod("2 - GetAccountBalance - Unsuccessful direct link account balance")]
        public void Response400()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetAccountBalance(user.UserHandle, user.PrivateKey, "sync_direct");

            Assert.AreEqual(400, response.StatusCode, $"{user.UserHandle} account 'sync_direct' sould fail get_accounts");
        }

        [TestMethod("3 - GetAccountBalance - Bad user signature failure")]
        public void Response403User()
        {
            var response = api.GetAccountBalance(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey, "default");

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - GetAccountBalance");
        }

        [TestMethod("4 - GetAccountBalance - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.GetAccountBalance(user.UserHandle, user.PrivateKey, "default");

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - GetAccountBalance");
        }
    }
}
