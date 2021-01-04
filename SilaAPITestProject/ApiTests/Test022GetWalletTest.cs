using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test022GetWalletTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - GetWallet - Sucessful retrieve for both wallets")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var firstResponse = api.GetWallet(user.UserHandle, user.PrivateKey);
            var parsedResponse = (SingleWalletResponse)firstResponse.Data;

            Assert.AreEqual(200, firstResponse.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("", parsedResponse.Wallet.Nickname);
            Assert.IsTrue(parsedResponse.SilaBalance > 0);

            var secondResponse = api.GetWallet(user.UserHandle, DefaultConfig.Wallet.PrivateKey);
            var parsedResponse2 = (SingleWalletResponse)secondResponse.Data;

            Assert.AreEqual(200, secondResponse.StatusCode);
            Assert.IsTrue(parsedResponse2.Success);
            Assert.AreEqual("new_wallet", parsedResponse2.Wallet.Nickname);
        }

        [TestMethod("2 - GetWallet - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.GetWallet(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - GetWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - GetWallet");
        }

        [TestMethod("3 - GetWallet - Bad user signature failure")]
        public void Response403User()
        {
            var response = api.GetWallet(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - GetWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - GetWallet");
        }
    }
}
