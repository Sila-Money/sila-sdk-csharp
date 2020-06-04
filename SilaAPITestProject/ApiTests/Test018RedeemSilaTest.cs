using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test018RedeemSilaTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - RedeemSila - Successful redeem for user")]
        public void T001Response200Success()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, descriptor: "test descriptor", businessUuid: DefaultConfig.businessUuid);
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.AreEqual("test descriptor", parsedResponse.Descriptor);
            DefaultConfig.RedeemReference = parsedResponse.Reference;
        }

        [TestMethod("2 - RedeemSila - Poll for successful redeem")]
        [Timeout(480000)]
        public void T002Response200Success()
        {
            var user = DefaultConfig.SecondUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.RedeemReference
            };

            GetTransactionsTest.Poll(user.UserHandle, user.PrivateKey, filters, "success");
        }

        [TestMethod("3 - RedeemSila - Unsuccessful redeem for empty wallet")]
        public void T003Response200Failure()
        {
            var user = DefaultConfig.FourthUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            DefaultConfig.InvalidRedeemReference = parsedResponse.Reference;
        }

        [TestMethod("4 - RedeemSila - Poll for unsuccessful redeem")]
        [Timeout(300000)]
        public void T004Response200Failure()
        {
            var user = DefaultConfig.FourthUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.InvalidRedeemReference
            };

            GetTransactionsTest.Poll(user.UserHandle, user.PrivateKey, filters, "failed");
        }

        [TestMethod("5 - RedeemSila - Empty user handle failure")]
        public void T005Response400()
        {
            ApiResponse<object> response = api.RedeemSila("", 100, DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode);
        }

        [TestMethod("6 - RedeemSila - Bad user signature failure")]
        public void T006Response401User()
        {
            var response = api.RedeemSila(DefaultConfig.FirstUser.UserHandle, 100, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - IssueSila");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - IssueSila");
        }

        [TestMethod("7 - RedeemSila - Bad app signature failure")]
        public void T007Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.RedeemSila(user.UserHandle, 100, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - IssueSila");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - IssueSila");
        }
    }
}
