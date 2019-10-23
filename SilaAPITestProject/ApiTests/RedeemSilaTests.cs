using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class RedeemSilaTests
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestInitialize]
        public void configuartion()
        {
            Thread thread = new Thread(createWebServer);
            thread.Start();
        }

        private void createWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:1080/redeem_sila/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200Success()
        {
            ApiResponse<object> response = api.RedeemSila("user.silamoney.eth", 1000, DefaultConfig.userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        public void Response200Failure()
        {
            ApiResponse<object> response = api.RedeemSila("notStarted.silamoney.eth", 1000, DefaultConfig.userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            ApiResponse<object> response = api.RedeemSila("", 1000, DefaultConfig.userPrivateKey);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            ApiResponse<object> response = api.RedeemSila("wrongSignature.silamoney.eth", 1000, DefaultConfig.userPrivateKey);
        }
    }
}
