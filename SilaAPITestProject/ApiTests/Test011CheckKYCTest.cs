using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test011_CheckKYCTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - CheckKYC - Empty user handle failure")]
        public void T001_Response400()
        {
            var response = api.CheckKYC("", DefaultConfig.privateKey);

            Assert.AreEqual(400, response.StatusCode, "Empty user handle failure");
        }

        /*
         * This endpoint doesn't validate user signature to be correct
        [TestMethod("2 - CheckKYC - Bad user signature failure")]
        public void T002_Response401User()
        {
            var response = api.CheckKYC(DefaultConfig.FirstUser.userHandle, DefaultConfig.SecondUser.privateKey);

            System.Console.WriteLine(((BaseResponse)response.Data).Message);
            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - CheckKYC");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("user signature"), "Bad user signature message - CheckKYC");
        }
        */

        [TestMethod("3 - CheckKYC - Bad app signature failure")]
        public void T003_Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.CheckKYC(user.UserHandle, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - CheckKYC");
            Assert.IsTrue(((BaseResponse)response.Data).Message.Contains("app signature"), "Bad app signature message - CheckKYC");
        }

        [TestMethod("4 - CheckKYC - Random users KYC passed")]
        [Timeout(300000)]
        public void T004_Response200Success()
        {
            var firstUser = DefaultConfig.FirstUser;
            var secondUser = DefaultConfig.SecondUser;
            var fourthUser = DefaultConfig.FourthUser;
            var businessUser = DefaultConfig.BusinessUser;

            SuccessCheck(firstUser.UserHandle, firstUser.PrivateKey);
            SuccessCheck(secondUser.UserHandle, secondUser.PrivateKey);
            SuccessCheck(fourthUser.UserHandle, fourthUser.PrivateKey);
            SuccessCheck(businessUser.UserHandle, businessUser.PrivateKey);
        }

        [TestMethod("5 - CheckKYC - Random users KYC failed")]
        [Timeout(300000)]
        public void T005_Response200Failure()
        {
            var thirdUser = DefaultConfig.ThirdUser;

            FailedCheck(thirdUser.UserHandle, thirdUser.PrivateKey);
        }

        private void SuccessCheck(string handle, string privateKey)
        {
            var response = api.CheckKYC(handle, privateKey);
            var parsedResponse = (CheckKYCResponse)response.Data;
            var status = parsedResponse.Status;
            var message = parsedResponse.Message;
            int statusCode = response.StatusCode;

            while (statusCode == 200 && status == "FAILURE" && message.Contains("pending") && !message.Contains("Business has passed verification"))
            {
                Console.WriteLine($"{handle} KYC check waiting 30 seconds...");
                Console.WriteLine($"Last call result. Status: {statusCode}; Result: {status}; Message: {message}");
                Thread.Sleep(30000);
                response = api.CheckKYC(handle, privateKey);
                parsedResponse = (CheckKYCResponse)response.Data;
                statusCode = response.StatusCode;
                status = parsedResponse.Status;
                message = parsedResponse.Message;
            }

            Assert.IsTrue("SUCCESS" == status || message.Contains("Business has passed verification"));
        }

        private void FailedCheck(string handle, string privateKey)
        {
            var response = api.CheckKYC(handle, privateKey);
            var parsedResponse = (CheckKYCResponse)response.Data;
            var status = parsedResponse.Status;
            var message = parsedResponse.Message;
            int statusCode = response.StatusCode;

            while (statusCode == 200 && status == "FAILURE" && !message.Contains("failed") && message.Contains("pending"))
            {
                Console.WriteLine($"{handle} KYC check waiting 30 seconds...");
                Console.WriteLine($"Last call result. Status: {statusCode}; Result: {status}; Message: {message}");
                Thread.Sleep(30000);
                response = api.CheckKYC(handle, privateKey);
                parsedResponse = (CheckKYCResponse)response.Data;
                statusCode = response.StatusCode;
                status = parsedResponse.Status;
                message = parsedResponse.Message;
            }

            Assert.AreEqual("FAILURE", status, $"{handle} should fail KYC verification");
            Assert.IsTrue(message.Contains("failed"), $"{handle} should pass KYC verification");
        }
    }
}
