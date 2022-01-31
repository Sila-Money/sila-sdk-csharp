using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test020RedeemSilaTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - RedeemSila - Successful redeem for user")]
        public void T001Response200Success()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "defaultpt");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            DefaultConfig.RedeemReference = parsedResponse.Reference;
        }

        [TestMethod("2 - RedeemSila - Poll for successful redeem")]
        [Timeout(480000)]
        public void T002Response200Success()
        {
            var user = DefaultConfig.SecondUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.RedeemReference
            };

            GetTransactionsTest.Poll(user.UserHandle, user.PrivateKey, filters, "success");
        }

        [TestMethod("3 - RedeemSila - Successful redeem tokens with business uuid and descriptor")]
        public void T003Response200Descriptor()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.RedeemTrans, businessUuid: DefaultConfig.businessUuid, accountName: "defaultpt");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.AreEqual(DefaultConfig.RedeemTrans, parsedResponse.Descriptor);
        }

        [TestMethod("4 - RedeemSila - Successful redeem tokens with same day ACH")]
        public void T004Response200SameDay()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, processingType: ProcessingType.Sameday, accountName: "defaultpt");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
        }

        [TestMethod("5 - RedeemSila - Unsuccessful redeem for empty wallet")]
        public void T005Response200Failure()
        {
            var user = DefaultConfig.FourthUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey);
            var parsedResponse = (BaseResponse)response.Data;

            //Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            DefaultConfig.InvalidRedeemReference = parsedResponse.Reference;
        }

        [TestMethod("6 - RedeemSila - Empty user handle failure")]
        public void T006Response400()
        {
            ApiResponse<object> response = api.RedeemSila("", 100, DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode);
        }

        [TestMethod("7 - RedeemSila - Fail redeem tokens with invalid business uuid and descriptor")]
        public void T007Response400Descriptor()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.RedeemTrans, businessUuid: DefaultConfig.InvalidBusinessUuid);
            var parsedResponse = (BadRequestResponse)response.Data;

            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }

        [TestMethod("8 - RedeemSila - Bad user signature failure")]
        public void T008Response401User()
        {
            var response = api.RedeemSila(DefaultConfig.FirstUser.UserHandle, 100, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - IssueSila");
        }

        [TestMethod("9 - RedeemSila - Bad app signature failure")]
        public void T009Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.RedeemSila(user.UserHandle, 100, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - IssueSila");
        }
    }
}
