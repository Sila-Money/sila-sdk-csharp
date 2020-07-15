using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test002_RegisterTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - Register - Random users registration")]
        public void TestResponse200()
        {
            var firstUser = ModelsUtilities.FirstUser;
            Console.WriteLine(firstUser.UserHandle);
            var firstResponse = api.Register(firstUser);

            Assert.AreEqual(200, firstResponse.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)firstResponse.Data).Status, $"{firstUser.UserHandle} should register");

            var secondUser = ModelsUtilities.SecondUser;
            var secondResponse = api.Register(secondUser);

            Assert.AreEqual(200, secondResponse.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)secondResponse.Data).Status, $"{secondUser.UserHandle} should register");

            var thirdUser = ModelsUtilities.ThirdUser;
            var thirdResponse = api.Register(thirdUser);

            Assert.AreEqual(200, thirdResponse.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)thirdResponse.Data).Status, $"{thirdUser.UserHandle} should register");

            var fourthUser = ModelsUtilities.FourthUser;
            var fourthResponse = api.Register(fourthUser);

            Assert.AreEqual(200, fourthResponse.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)fourthResponse.Data).Status, $"{fourthUser.UserHandle} should register");

            var businessUser = ModelsUtilities.BusinessUser;
            var businessResponse = api.Register(businessUser);

            Assert.AreEqual(200, fourthResponse.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)businessResponse.Data).Status, $"{businessUser.UserHandle} should register");

        }

        [TestMethod("2 - Register - Random user second registration failure")]
        public void TestResponse400()
        {
            var firstUser = ModelsUtilities.FirstUser;
            var firstResponse = api.Register(firstUser);

            Assert.AreEqual(400, firstResponse.StatusCode, $"{firstUser.UserHandle} should be already register");
            Assert.IsTrue(((BaseResponse)firstResponse.Data).Message.Contains("taken"), $"{firstUser.UserHandle} should be taken");

            var secondUser = ModelsUtilities.SecondUser;
            var secondResponse = api.Register(secondUser);

            Assert.AreEqual(400, secondResponse.StatusCode, $"{secondUser.UserHandle} should be already register");
            Assert.IsTrue(((BaseResponse)secondResponse.Data).Message.Contains("taken"), $"{secondUser.UserHandle} should be taken");

            var thirdUser = ModelsUtilities.ThirdUser;
            var thirdResponse = api.Register(thirdUser);

            Assert.AreEqual(400, thirdResponse.StatusCode, $"{thirdUser.UserHandle} should be already register");
            Assert.IsTrue(((BaseResponse)thirdResponse.Data).Message.Contains("taken"), $"{thirdUser.UserHandle} should be taken");
        }

        [TestMethod("3 - Register - Bad signature failure")]
        public void TestResponse401()
        {
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            User user = ModelsUtilities.FirstUser;
            var response = failApi.Register(user);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature should fail - Register");
        }
    }
}
