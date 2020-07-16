using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test024UpdateWalletTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - UpdateWallet - Successful nickname change and set as default")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var nickname = "default";
            var response = api.UpdateWallet(user.UserHandle, user.PrivateKey, nickname, true);
            var parsedResponse = (UpdateWalletResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Wallet.Default);
            Assert.AreEqual(nickname, parsedResponse.Wallet.Nickname);
            Assert.AreEqual(2, parsedResponse.Changes.Count);

            user = DefaultConfig.SecondUser;
            response = api.UpdateWallet(user.UserHandle, user.PrivateKey, nickname, true);
            parsedResponse = (UpdateWalletResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Wallet.Default);
            Assert.AreEqual(nickname, parsedResponse.Wallet.Nickname);
            Assert.AreEqual(2, parsedResponse.Changes.Count);
        }

        [TestMethod("2 - UpdateWallet - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.UpdateWallet(user.UserHandle, user.PrivateKey, "fail_app");

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - UpdateWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - UpdateWallet");
        }

        [TestMethod("3 - UpdateWallet - Bad user signature failure")]
        public void Response403User()
        {
            var response = api.UpdateWallet(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey, "fail_user");

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - UpdateWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - UpdateWallet");
        }
    }
}
