using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class GetAccountsTest
    {
        readonly SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestInitialize]
        public void configuartion()
        {
            Thread thread = new Thread(createWebServer);
            thread.Start();
        }

        private void createWebServer()
        {
            string[] prefixes = new string[1];
            prefixes[0] = "http://localhost:8080/get_accounts/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200()
        {
            ApiResponse<object> response = api.GetAccounts("user.silamoney.eth", DefaultConfig.userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            _ = api.GetAccounts("", DefaultConfig.userPrivateKey);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            _ = api.GetAccounts("wrongSignature.silamoney.eth", DefaultConfig.userPrivateKey);
        }
    }
}
