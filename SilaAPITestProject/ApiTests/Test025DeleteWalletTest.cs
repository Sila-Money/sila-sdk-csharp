using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test025DeleteWalletTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - DeleteWallet - Successful wallet deletion")]
        public void Response200()
        {
            var wallet = DefaultConfig.Wallet;
            var response = api.DeleteWallet(DefaultConfig.FirstUser.UserHandle, wallet.PrivateKey);
            var parsedResponse = (DeleteWalletResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Message.Contains($"{wallet.Address}"));
        }

        [TestMethod("2 - DeleteWallet - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.DeleteWallet(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - DeleteWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - DeleteWallet");
        }

        [TestMethod("3 - DeleteWallet - Unsuccessful wallet deletion")]
        public void Response403Default()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteWallet(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(403, response.StatusCode);
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("Cannot delete"));
        }

        [TestMethod("4 - DeleteWallet - Bad user signature failure")]
        public void Response403User()
        {
            var response = api.DeleteWallet(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - DeleteWallet");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - DeleteWallet");
        }
    }
}
