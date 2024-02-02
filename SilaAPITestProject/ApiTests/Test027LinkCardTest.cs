using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using RestSharp;
using System;
using Newtonsoft.Json.Linq;
namespace SilaApiTest
{
    [TestClass]
    public class Test027LinkCardTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - LinkCard - Success Response")]
        public void Response200()
        {           
            var user = DefaultConfig.FirstUser;
            var filters = new Message()
            {
                CardNumber = "4659105569051157",
                ExpiryMonth = 12,
                ExpiryYear = 2027,
                CkoPublicKey = "pk_sbox_i2uzy5w5nsllogfsc4xdscorcii",
            };

            var response1 = api.CreateCkoTestingToken(user.UserHandle, DefaultConfig.CKOUser.PrivateKey, filters);
            var parsedResponse1 = (CkoTestingTokenResponse)response1.Data;
            var token = parsedResponse1.Token;

            var response = api.LinkCard(user.UserHandle, token, user.PrivateKey, "12345", "cko", "cko");
            var parsedResponse = (LinkCardResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.CardDetail.CardName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
