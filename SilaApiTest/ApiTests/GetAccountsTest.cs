using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.com.silamoney.client.api;
using SilaAPI.com.silamoney.client.domain;
using SilaAPI.com.silamoney.client.exceptions;

namespace SilaApiTest
{
    [TestClass]
    public class GetAccountsTest
    {
        UserApi api = new UserApi(DefaultConfig.basePath, DefaultConfig.privateKey, DefaultConfig.appHandler);

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
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.GetAccounts("user.silamoney.eth", userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((GetAccountsResponse)response.Data).status);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.GetAccounts("", userPrivateKey);

            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", ((GetAccountsResponse)response.Data).status);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.GetAccounts("wrongSignature.silamoney.eth", userPrivateKey);

            Assert.AreEqual(401, response.StatusCode);
            Assert.AreEqual("FAILURE", ((GetAccountsResponse)response.Data).status);
        }
    }
}
