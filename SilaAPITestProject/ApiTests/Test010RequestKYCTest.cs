using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test010_RequestKYCTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - RequestKYC - Bad user signature failure")]
        public void T001_Response401User()
        {
            var response = api.RequestKYC(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - RequestKYC");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - RequestKYC");
        }

        [TestMethod("2 - RequestKYC - Bad app signature failure")]
        public void T002_Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.RequestKYC(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - RequestKYC");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - RequestKYC");
        }

        [TestMethod("3 - RequestKYC - Random KYC Level")]
        public void T003_Response403()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.RequestKYC(user.UserHandle, user.PrivateKey, new System.Random().Next().ToString());

            Assert.AreEqual(403, response.StatusCode, "Random KYC level status - RequestKYC");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("KYC flow"), "Random KYC level message - RequestKYC");
        }

        [TestMethod("4 - RequestKYC - Random user RequestKYC")]
        public void T004_Response200()
        {
            var firstUser = DefaultConfig.FirstUser;
            var firstResponse = api.RequestKYC(firstUser.UserHandle, firstUser.PrivateKey);

            Assert.AreEqual(200, firstResponse.StatusCode, $"{firstUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)firstResponse.Data).Status, $"{firstUser.UserHandle} should be sent to KYC verification");

            var secondUser = DefaultConfig.SecondUser;
            var secondResponse = api.RequestKYC(secondUser.UserHandle, secondUser.PrivateKey);

            Assert.AreEqual(200, secondResponse.StatusCode, $"{secondUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)secondResponse.Data).Status, $"{secondUser.UserHandle} should be sent to KYC verification");

            var thirdUser = DefaultConfig.ThirdUser;
            var thirdResponse = api.RequestKYC(thirdUser.UserHandle, thirdUser.PrivateKey);

            Assert.AreEqual(200, thirdResponse.StatusCode, $"{thirdUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)thirdResponse.Data).Status, $"{thirdUser.UserHandle} should be sent to KYC verification");

            var fourthUser = DefaultConfig.FourthUser;
            var fourthResponse = api.RequestKYC(fourthUser.UserHandle, fourthUser.PrivateKey);

            Assert.AreEqual(200, fourthResponse.StatusCode, $"{fourthUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)fourthResponse.Data).Status, $"{fourthUser.UserHandle} should be sent to KYC verification");

            var businessUser = DefaultConfig.BusinessUser;
            var businessResponse = api.RequestKYC(businessUser.UserHandle, businessUser.PrivateKey);

            Assert.AreEqual(200, businessResponse.StatusCode, $"{businessUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)businessResponse.Data).Status, $"{businessUser.UserHandle} should be sent to KYC verification");

            UserConfiguration instantUser = DefaultConfig.InstantUser;
            ApiResponse<object> instantResponse = api.RequestKYC(instantUser.UserHandle, instantUser.PrivateKey, "INSTANT-ACH");

            Assert.AreEqual(200, instantResponse.StatusCode, $"{instantUser.UserHandle} should be sent to KYC verification");
            Assert.AreEqual("SUCCESS", ((BaseResponse)instantResponse.Data).Status, $"{instantUser.UserHandle} should be sent to KYC verification");
        }

        [TestMethod("5 - RequestKYC - Empty user handle failure")]
        public void T005_Response400()
        {
            var response = api.RequestKYC("", DefaultConfig.privateKey);

            Assert.AreEqual(400, response.StatusCode, "Empty user handle should fail - RequestKYC");
        }
    }
}
