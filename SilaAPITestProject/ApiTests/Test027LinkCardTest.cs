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
            var client = new RestClient("https://sso.sandbox.tabapay.com:8443/v2/SSOEncrypt");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/tabapay-compact");
            request.AddHeader("Referer", "https://sso.sandbox.tabapay.com:8443/SSOEvolveISO.html");
            var body = @"cBm0RU8eASGfSxLYJjsG73Q	n9010111999999992	e202201	s4561";
            request.AddParameter("application/tabapay-compact", body, ParameterType.RequestBody);
            IRestResponse responseToken = client.Execute(request);
            string token = responseToken.Content.ToString().Replace("S2\td", "");

            var user = DefaultConfig.FirstUser;
            var response = api.LinkCard(user.UserHandle, token, user.PrivateKey, "12345", "visa");
            var parsedResponse = (LinkCardResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.CardName);
            Assert.IsNotNull(parsedResponse.AVS);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
