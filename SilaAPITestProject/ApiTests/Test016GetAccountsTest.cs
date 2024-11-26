using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System.Collections.Generic;

namespace SilaApiTest
{
    [TestClass]
    public class Test016GetAccountsTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetAccounts - Successfully obtained accounts")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetAccounts(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should success get_accounts");
            var parsedResponse = (GetAccountsResponse)response.Data;
            Assert.AreEqual(4, parsedResponse.Accounts.Count, $"{user.UserHandle} must have 3 linked accounts");
        }

        [TestMethod("2 - GetAccounts - Empty user handle failure")]
        public void Response400()
        {
            var response = api.GetAccounts("", DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode, "Empty user handle failure - GetAccounts");
        }

        /*
         * This endpoint doesn't validate user signature
        [TestMethod("3 - GetAccounts - Bad user signature failure")]
        public void Response401User()
        {
            var response = api.GetAccounts(DefaultConfig.FirstUser.userHandle, DefaultConfig.privateKey);
            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - GetAccounts");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - GetAccounts");
        }
        */

        [TestMethod("4 - GetAccounts - Bad app signature failure")]
        public void Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.GetAccounts(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - GetAccounts");
        }
    }
}