using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test023GetWalletsTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - GetWallets - Successful call")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetWallets(user.UserHandle, user.PrivateKey);
            var parsedResponse = (GetWalletsResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode, $"{user.UserHandle} get_wallets succes status");
            Assert.AreEqual(2, parsedResponse.TotalCount, $"{user.UserHandle} get_wallets succes count");
            Assert.AreEqual(2, parsedResponse.Wallets.Count, $"{user.UserHandle} get_wallets succes wallets count");
            Assert.IsTrue(parsedResponse.Success, $"{user.UserHandle} get_wallets succes property");
        }

        [TestMethod("2 - GetWallets - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.GetWallets(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - GetWallets");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - GetWallets");
        }

        [TestMethod("3 - GetWallets - Bad user signature failure")]
        public void Response403User()
        {
            var response = api.GetWallets(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey);

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - GetWallets");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - GetWallets");
        }
    }
}
