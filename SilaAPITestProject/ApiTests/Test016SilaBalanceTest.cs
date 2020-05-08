﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test016SilaBalanceTests
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - SilaBalance - Successful balance retrieval")]
        public void Response200Success()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.SilaBalance("https://sandbox.silatokenapi.silamoney.com", user.CryptoAddress);
            var parsedResponse = (SilaBalanceResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.SilaBalance >= 100);
        }

        [TestMethod("2 - SilaBalance - Unsuccessful balance retrieval")]
        public void Response500()
        {
            var response = api.SilaBalance("https://sandbox.silatokenapi.silamoney.com", "");

            Assert.AreEqual(500, response.StatusCode);
        }
    }
}
