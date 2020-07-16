using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test007CheckHandleFailTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - CheckHandle - Random users failure")]
        public void Response200Failure()
        {
            var firstHandle = DefaultConfig.FirstUser.UserHandle;
            var firstResponse = api.CheckHandle(firstHandle);

            Assert.AreEqual(200, firstResponse.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)firstResponse.Data).Status, $"{firstHandle} should not be available");

            var secondHandle = DefaultConfig.SecondUser.UserHandle;
            var secondResponse = api.CheckHandle(secondHandle);

            Assert.AreEqual(200, secondResponse.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)secondResponse.Data).Status, $"{secondHandle} should not be available");

            var thirdHandle = DefaultConfig.ThirdUser.UserHandle;
            var thirdResponse = api.CheckHandle(thirdHandle);

            Assert.AreEqual(200, thirdResponse.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)thirdResponse.Data).Status, $"{thirdHandle} should not be available");
        }
    }
}
