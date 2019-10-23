using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class GetTransactionsTest
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
            prefixes[0] = "http://localhost:1080/get_transactions/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200()
        {
            ApiResponse<object> response = api.GetTransactions("user.silamoney.eth", DefaultConfig.userPrivateKey, null);

            Assert.AreEqual(200, response.StatusCode);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            ApiResponse<object> response = api.GetTransactions("", DefaultConfig.userPrivateKey, null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response403()
        {
            ApiResponse<object> response = api.GetTransactions("wrongSignature.silamoney.eth", DefaultConfig.userPrivateKey, null);
        }
    }
}
