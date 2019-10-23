using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class CheckHandleTest
    {
        readonly SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestInitialize]
        public void Configuartion()
        {
            Thread thread = new Thread(CreateWebServer);
            thread.Start();
        }

        private void CreateWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:1080/check_handle/";
            WebServer.TestHttpServer.Listener(prefixes);
        }

        [TestMethod]
        public void Response200Success()
        {
            ApiResponse<object> response = api.CheckHandle("user.silamoney.eth");

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        public void Response200Failure()
        {
            ApiResponse<object> response = api.CheckHandle("taken.silamoney.eth");

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            api.CheckHandle("");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            api.CheckHandle("wrongSignature.silamoney.eth");
        }
    }
}
