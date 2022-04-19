using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test018_IssueSilaTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - IssueSila - Successfully issue 1000 tokens")]
        public void Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 1000, user.PrivateKey);
            api.IssueSila(user.UserHandle, 420, user.PrivateKey);
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            DefaultConfig.IssueReference = parsedResponse.Reference;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - IssueSila - Succesfully issue tokens with business uuid and descriptor")]
        public void Response200SuccessDescriptor()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.IssueTrans, businessUuid: DefaultConfig.businessUuid);
            var parsedResponse = (TransactionResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.AreEqual(DefaultConfig.IssueTrans, parsedResponse.Descriptor);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("3 - IssueSila - Succesfully issue tokens with same day ACH")]
        public void Response200SuccessSameDay()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 100, user.PrivateKey, processingType: ProcessingType.Sameday);
            var parsedResponse = (TransactionResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("4 - IssueSila - Successful instant ach")]
        public void Response200SuccessInstantAch()
        {
            UserConfiguration user = DefaultConfig.InstantUser;
            ApiResponse<object> response = api.IssueSila(user.UserHandle, 200, user.PrivateKey, businessUuid: DefaultConfig.businessUuid, processingType: ProcessingType.InstantACH, accountName: "defaultpt");

            Assert.AreEqual(200, response.StatusCode);
            TransactionResponse parsedResponse = (TransactionResponse)response.Data;
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("5 - IssueSila - Poll until successful issue")]
        [Timeout(300000)]
        public void Response200Transaction()
        {
            var user = DefaultConfig.FirstUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.IssueReference
            };

            GetTransactionsTest.Poll(user.UserHandle, user.PrivateKey, filters, "success");
        }

        [TestMethod("6 - IssueSila - Empty user handle failure")]
        public void Response400()
        {
            var response = api.IssueSila("", 1000, DefaultConfig.FirstUser.PrivateKey);
            Assert.AreEqual(400, response.StatusCode);
        }

        [TestMethod("7 - IssueSila - Fail issue tokens with invalid business uuid and descriptor")]
        public void Response400Descriptor()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.IssueTrans, businessUuid: DefaultConfig.InvalidBusinessUuid);
            var parsedResponse = (BadRequestResponse)response.Data;
            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("8 - IssueSila - Bad user signature failure")]
        public void Response401User()
        {
            var response = api.IssueSila(DefaultConfig.FirstUser.UserHandle, 1000, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - IssueSila");
        }

        [TestMethod("9 - IssueSila - Unsuccessfully issue tokens")]
        public void Response401NotVerified()
        {
            var user = DefaultConfig.ThirdUser;
            ApiResponse<object> response = api.IssueSila(user.UserHandle, 1000, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode);
            Assert.AreEqual("FAILURE", ((BaseResponse)response.Data).Status);
        }

        [TestMethod("10 - IssueSila - Bad app signature failure")]
        public void Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.IssueSila(user.UserHandle, 1000, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - IssueSila");
        }
    }
}
