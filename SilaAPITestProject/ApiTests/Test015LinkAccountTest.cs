using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test015_LinkAccountTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - LinkAccount - Empty user handle failure")]
        public void T001_Response400()
        {
            var response = api.LinkAccount("", DefaultConfig.PlaidToken.Token, DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode, "Empty user handle failure - LinkAccount");
        }

        [TestMethod("2 - LinkAccount - Bad user signature failure")]
        public void T002_Response401User()
        {
            var response = api.LinkAccount(DefaultConfig.FirstUser.UserHandle, DefaultConfig.PlaidToken.Token, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - LinkAccount");
        }

        [TestMethod("3 - LinkAccount - Bad app signature failure")]
        public void T003_Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.LinkAccount(user.UserHandle, DefaultConfig.PlaidToken.Token, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - LinkAccount");
        }

        [TestMethod("4 - LinkAccount - Random token failure")]
        public void T004_Response400Failure()
        {
            var user = DefaultConfig.FirstUser;
            var randomToken = $"public-sandbox-{System.Guid.NewGuid()}";
            var response = api.LinkAccount(user.UserHandle, randomToken, user.PrivateKey);

            var baseResp = (BaseResponse)response.Data;
            Assert.AreEqual(400, response.StatusCode, "Random token should not be valid - status code");
            Assert.AreEqual("FAILURE", baseResp.Status, "Random token should not be valid - status");
        }

        [TestMethod("5 - LinkAccount - Link through plaid token")]
        public void T005_Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;
            var response = api.LinkAccount(user.UserHandle, plaid.Token, user.PrivateKey);
            var parsedData = (LinkAccountResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link plaid account - status code");
            Assert.AreEqual("SUCCESS", parsedData.Status, $"{user.UserHandle} should link plaid account - status");
            Assert.IsFalse(string.IsNullOrEmpty(parsedData.AccountName));

            user = DefaultConfig.SecondUser;
            plaid = DefaultConfig.PlaidToken;
            response = api.LinkAccount(user.UserHandle, plaid.Token, user.PrivateKey, accountName: "default");
            parsedData = (LinkAccountResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link plaid account - status code");
            Assert.AreEqual("SUCCESS", parsedData.Status, $"{user.UserHandle} should link plaid account - status");
            Assert.IsFalse(string.IsNullOrEmpty(parsedData.AccountName));

            user = DefaultConfig.FourthUser;
            plaid = DefaultConfig.PlaidToken;
            response = api.LinkAccount(user.UserHandle, plaid.Token, user.PrivateKey);
            parsedData = (LinkAccountResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link plaid account - status code");
            Assert.AreEqual("SUCCESS", parsedData.Status, $"{user.UserHandle} should link plaid account - status");
            Assert.IsFalse(string.IsNullOrEmpty(parsedData.AccountName));

            user = DefaultConfig.InstantUser;
            plaid = DefaultConfig.PlaidToken;
            response = api.LinkAccount(user.UserHandle, plaid.Token, user.PrivateKey);

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link plaid account - status code");
            parsedData = (LinkAccountResponse)response.Data;
            Assert.AreEqual("SUCCESS", parsedData.Status, $"{user.UserHandle} should link plaid account - status");
            Assert.IsFalse(string.IsNullOrEmpty(parsedData.AccountName));
        }

        [TestMethod("6 - LinkAccount - Link through plaid token and account id")]
        public void T006_Response200SuccessId()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;
            var response = api.LinkAccount(user.UserHandle, plaid.Token, user.PrivateKey, "sync_by_id", plaid.AccountId);

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link plaid account by id - status code");
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status, $"{user.UserHandle} should link plaid account by id - status");
        }

        [TestMethod("7 - LinkAccount - Link direct account link")]
        public void T007_Response200SuccessDirect()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.LinkAccountDirect(user.UserHandle, user.PrivateKey, "123456789012", "123456789", accountName: "sync_direct");
            api.LinkAccountDirect(user.UserHandle, user.PrivateKey, "123456789012", "123456789", accountName: "unlink");

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should link direct account - status code");
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status, $"{user.UserHandle} should link direct account - status");
        }
    }
}
