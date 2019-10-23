﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using SilaAPI.silamoney.client.exceptions;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class TransferSilaTests
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
            prefixes[0] = "http://localhost:1080/transfer_sila/";
            WebServer.TestHttpServer.Listener(prefixes);
        }
        [TestMethod]
        public void Response200Success()
        {
            ApiResponse<object> response = api.TransferSila("user.silamoney.eth", 13, "user2.silamoney.eth", DefaultConfig.userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        public void Response200Failure()
        {
            ApiResponse<object> response = api.TransferSila("notStarted.silamoney.eth", 13, "user2.silamoney.eth", DefaultConfig.userPrivateKey);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).Status);
        }
        [TestMethod]
        [ExpectedException(typeof(BadRequestException), "Bad request permited.")]
        public void Response400()
        {
            ApiResponse<object> response = api.TransferSila("", 13, "user2.silamoney.eth", DefaultConfig.userPrivateKey);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSignatureException), "Bad request permited.")]
        public void Response401()
        {
            ApiResponse<object> response = api.TransferSila("wrongSignature.silamoney.eth", 13, "user2.silamoney.eth", DefaultConfig.userPrivateKey);
        }
    }
}