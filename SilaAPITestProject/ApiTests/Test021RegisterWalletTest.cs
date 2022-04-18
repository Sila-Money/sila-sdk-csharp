using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test021RegisterWalletTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - RegisterWallet - Succesful add new wallet to existing user")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var wallet = DefaultConfig.Wallet;
            var nickname = "new_wallet";
            var response = api.RegisterWallet(user.UserHandle, user.PrivateKey, wallet, nickname);
            var parsedResponse = (RegisterWalletResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} should succesfully add wallet {wallet.Address}");
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual(nickname, parsedResponse.WalletNickname);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - RegisterWallet - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var wallet = api.GenerateWallet();
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.RegisterWallet(user.UserHandle, user.PrivateKey, wallet, "fail_app");

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - RegisterWallet");
        }

        [TestMethod("3 - RegisterWallet - Bad user signature failure")]
        public void Response403User()
        {
            var wallet = api.GenerateWallet();
            var response = api.RegisterWallet(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey, wallet, "fail_user");

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - RegisterWallet");
        }

        [TestMethod("4 - RegisterWallet - Bad wallet signature failure")]
        public void Response403Wallet()
        {
            var user = DefaultConfig.FirstUser;
            var wallet = api.GenerateWallet();
            wallet.PrivateKey = user.PrivateKey;
            var response = api.RegisterWallet(user.UserHandle, user.PrivateKey, wallet, "fail_wallet");

            Assert.AreEqual(403, response.StatusCode, "Bad wallet signature status - RegisterWallet");
        }

        public void Response400Wallet()
        {
            var wallet = api.GenerateWallet();
            wallet.Address = "";
            wallet.PrivateKey = "";
            var response = api.RegisterWallet("", "", wallet, "");

            Assert.AreEqual(400, response.StatusCode, "Incomplete wallet information should fail registration");
        }
    }
}
