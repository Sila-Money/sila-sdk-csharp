﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.com.silamoney.client.api;
using SilaAPI.com.silamoney.client.domain;
using SilaAPI.com.silamoney.client.exceptions;

namespace SilaApiTest
{
    [TestClass]
    public class LinkAccountTest
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
            prefixes[0] = "http://localhost:8080/link_account/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200Success()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.LinkAccount("user.silamoney.eth", "public-xxx-xxx", userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).status);
        }
        [TestMethod]
        public void Response200Failure()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.LinkAccount("notlinked.silamoney.eth", "public-xxx-xxx", userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).status);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.LinkAccount("", "public-xxx-xxx", userPrivateKey);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Invalid signature permited.")]
        public void Response401()
        {
            String userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
            ApiResponse<object> response = api.LinkAccount("wrongSignature.silamoney.eth", "public-xxx-xxx", userPrivateKey);
        }
    }
}
