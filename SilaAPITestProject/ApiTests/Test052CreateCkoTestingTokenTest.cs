using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test052CreateCkoTestingTokenTest
    {
        SilaApi api = DefaultConfig.Client;
        //SilaApi api = new SilaApi(DefaultConfig.environment, "arc_sandbox_test_app01",
        //"9c17e7b767b8f4a63863caf1619ef3e9967a34b287ce58542f3eb19b5a72f076");

        [TestMethod("1 - CreateCkoTestingToken - Succesfully")]
        public void T001CreateCkoTestingToken200Success()
        {
            //Register User
            var ckoUser = ModelsUtilities.CKOUser;
            var ckoResponse = api.Register(ckoUser);

            Assert.AreEqual(200, ckoResponse.StatusCode);
            var ckoResponseParse = (BaseResponse)ckoResponse.Data;

            //Request KYC
            var response = api.RequestKYC(userHandle: ckoUser.UserHandle, userPrivateKey: DefaultConfig.CKOUser.PrivateKey);
            var parsedResponse = (RequestKYCResponse)response.Data;

            //Check KYC(Empty User)
            SuccessCheck(ckoUser.UserHandle, DefaultConfig.CKOUser.PrivateKey);

            Thread.Sleep(5000);
            //Generated CKO Token
            var filters = new Message()
            {
                CardNumber = "4659105569051157",
                ExpiryMonth = 12,
                ExpiryYear = 2027,
                CkoPublicKey = "pk_sbox_i2uzy5w5nsllogfsc4xdscorcii",
            };

            var response1 = api.CreateCkoTestingToken(ckoUser.UserHandle, DefaultConfig.CKOUser.PrivateKey, filters);
            var parsedResponse1 = (CkoTestingTokenResponse)response1.Data;
            Assert.AreEqual(200, response1.StatusCode);
            Assert.IsTrue(parsedResponse1.Success);
            Assert.IsNotNull(parsedResponse1.Token);
            Assert.IsNotNull(parsedResponse1.Message);
            Assert.IsNotNull(parsedResponse1.Reference);
            Assert.IsNotNull(parsedResponse1.ResponseTimeMs);

            Thread.Sleep(5000);
            //Link Card and pass token i.e generated from (Generate CKO token method)
            string card_name = System.Guid.NewGuid().ToString();
            //var user = DefaultConfig.CKOUser;
            var responseLinkCard = api.LinkCard(ckoUser.UserHandle, parsedResponse1.Token, DefaultConfig.CKOUser.PrivateKey, "12345", card_name, "cko");
            var parsedResponseLinkCard = (LinkCardResponse)responseLinkCard.Data;

            Thread.Sleep(5000);
            //Issue Sila from Card Name
            var responseIssueSila = api.IssueSila(ckoUser.UserHandle, 1000, DefaultConfig.CKOUser.PrivateKey, accountName: null, cardName: card_name);
            var parsedResponseIssueSila = (TransactionResponse)responseIssueSila.Data;
        }

        private void SuccessCheck(string handle, string privateKey)
        {
            var response = api.CheckKYC(handle, privateKey);
            var parsedResponse = (CheckKYCResponse)response.Data;
            var status = parsedResponse.Status;
            var message = parsedResponse.Message;
            int statusCode = response.StatusCode;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);

            while (statusCode == 200 && status == "FAILURE" && message.Contains("pending") && !message.Contains("Business has passed verification"))
            {
                Console.WriteLine($"{handle} KYC check waiting 30 seconds...");
                Console.WriteLine($"Last call result. Status: {statusCode}; Result: {status}; Message: {message}");
                Thread.Sleep(5000);
                response = api.CheckKYC(handle, privateKey);
                parsedResponse = (CheckKYCResponse)response.Data;
                statusCode = response.StatusCode;
                status = parsedResponse.Status;
                message = parsedResponse.Message;
            }
        }

        [TestMethod("2 - CreateCkoTestingToken - FAILURE")]
        public void T002CreateCkoTestingTokenResponse400()
        {
            var ckoUser = ModelsUtilities.CKOUser;
            var filters = new Message()
            {
                CardNumber = "4095254802642505",
                ExpiryMonth = 12,
                CkoPublicKey = "pk_sbox_i2uzy5w5nsllogfsc4xdscorcii",
            };
            var response = api.CreateCkoTestingToken(ckoUser.UserHandle, DefaultConfig.CKOUser.PrivateKey, filters);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }


        [TestMethod("3 - RefundDebitCard - FAILURE")]
        public void T003RefundDebitCardResponse400()
        {
            var ckoUser = ModelsUtilities.CKOUser;

            var responseRefundDebitCard = api.RefundDebitCard(ckoUser.UserHandle, DefaultConfig.CKOUser.PrivateKey, null);
            var parsedResponseRefundDebitCard = (BaseResponse)responseRefundDebitCard.Data;
            Assert.AreEqual(400, responseRefundDebitCard.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponseRefundDebitCard.Status);
        }


    }
}

