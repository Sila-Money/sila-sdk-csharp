using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;

namespace SilaApiTest
{
    [TestClass]
    public class Test005_CheckHandleTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - CheckHandle - Random users validation")]
        public void Response200Success()
        {
            var firstResponse = api.CheckHandle(DefaultConfig.FirstUser.UserHandle);


            Assert.AreEqual(200, firstResponse.StatusCode, $"{DefaultConfig.FirstUser.UserHandle} should be available");
            Assert.AreEqual("SUCCESS", ((BaseResponse)firstResponse.Data).Status, $"{DefaultConfig.FirstUser.UserHandle} should be available");

            var secondResponse = api.CheckHandle(DefaultConfig.SecondUser.UserHandle);

            Assert.AreEqual(200, secondResponse.StatusCode, $"{DefaultConfig.SecondUser.UserHandle} should be available");
            Assert.AreEqual("SUCCESS", ((BaseResponse)secondResponse.Data).Status, $"{DefaultConfig.SecondUser.UserHandle} should be available");

            var thirdResponse = api.CheckHandle(DefaultConfig.ThirdUser.UserHandle);

            Assert.AreEqual(200, thirdResponse.StatusCode, $"{DefaultConfig.ThirdUser.UserHandle} should be available");
            Assert.AreEqual("SUCCESS", ((BaseResponse)thirdResponse.Data).Status, $"{DefaultConfig.ThirdUser.UserHandle} should be available");

            var fourthResponse = api.CheckHandle(DefaultConfig.FourthUser.UserHandle);

            Assert.AreEqual(200, fourthResponse.StatusCode, $"{DefaultConfig.FourthUser.UserHandle} should be available");
            Assert.AreEqual("SUCCESS", ((BaseResponse)fourthResponse.Data).Status, $"{DefaultConfig.FourthUser.UserHandle} should be available");
            Assert.IsNotNull(((BaseResponse)fourthResponse.Data).ResponseTimeMs);
        }

        [TestMethod("2 - CheckHandle - Default user failure")]
        public void Response200Failure()
        {
            var handle = "user.silamoney.eth";
            var response = api.CheckHandle(handle);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).Status, $"{handle} should not be available");
            Assert.IsNotNull(((BaseResponse)response.Data).ResponseTimeMs);
        }

        [TestMethod("3 - CheckHandle - Empty handle failure")]
        public void Response400()
        {
            var response = api.CheckHandle("");

            Assert.AreEqual(400, response.StatusCode, "Empty user handle should fail - CheckHandle");
            var parsedResponse = (BadRequestResponse)response.Data;
        }

        [TestMethod("4 - CheckHandle - Bad signature failure")]
        public void Response401()
        {
            SilaApi failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.CheckHandle(DefaultConfig.FirstUser.UserHandle);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature should fail - CheckHandle");
        }
    }
}
