using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class SilaBalanceTests
    {
        readonly SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);
        Thread thread;

        [TestInitialize]
        public void configuartion()
        {
            thread = new Thread(createWebServer);
            thread.Start();
        }

        private void createWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:1080/silaBalance/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200Success()
        {
            ApiResponse<object> response = api.SilaBalance("http://localhost:1080", "0xabc123abc123abc123");

            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
