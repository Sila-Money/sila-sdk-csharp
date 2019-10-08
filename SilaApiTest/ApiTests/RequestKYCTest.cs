using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;

namespace SilaApiTest
{
    [TestClass]
    public class RequestKYCTest
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
            prefixes[0] = "http://localhost:8080/request_kyc/";
            WebServer.TestHttpServer.Listener(prefixes);
        }

        [TestMethod]
        public void Response200()
        {
            ApiResponse<object> response = api.RequestKYC("user.silamoney.eth", DefaultConfig.userPrivateKey);

            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).status);
            Assert.AreEqual(200, response.StatusCode);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException),"Bad request permited.")]
        public void Response400()
        {   
            ApiResponse<object> response = api.RequestKYC("", DefaultConfig.userPrivateKey);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            ApiResponse<object> response = api.RequestKYC("wrongSignature.silamoney.eth", DefaultConfig.userPrivateKey);
        }
    }
}
