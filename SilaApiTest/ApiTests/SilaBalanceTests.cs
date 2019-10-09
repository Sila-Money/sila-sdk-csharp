using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;

namespace SilaApiTest
{
    [TestClass]
    public class SilaBalanceTests
    {
        UserApi api = new UserApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestInitialize]
        public void configuartion()
        {
            Thread thread = new Thread(createWebServer);
            thread.Start();
        }

        private void createWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:8080/silaBalance/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200Success()
        {
            ApiResponse<object> response = api.SilaBalance(DefaultConfig.environment,"0xabc123abc123abc123");

            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
