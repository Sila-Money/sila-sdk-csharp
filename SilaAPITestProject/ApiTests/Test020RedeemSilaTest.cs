using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;

namespace SilaApiTest
{
    #pragma warning disable CS0618
    [TestClass]
    public class Test020RedeemSilaTest
    {    
        private Mock<ApiClient> mockApiClient;
        private SilaApi api;

        [TestInitialize]
        public void Setup()
        {
            mockApiClient = new Mock<ApiClient>(DefaultConfig.environment) { CallBase = true };

            // Create a real instance of Configuration
            var configuration = new Configuration();
            configuration.PrivateKey = DefaultConfig.privateKey;

            // Use reflection to set the internal ApiClient instance in Configuration
            var apiClientField = typeof(Configuration).GetField("_apiClient", BindingFlags.Instance | BindingFlags.NonPublic);
            apiClientField.SetValue(configuration, mockApiClient.Object);

            // Use the real SilaApi instance with the mocked ApiClient in Configuration
            api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);
            var configProperty = typeof(SilaApi).GetProperty("Configuration", BindingFlags.Instance | BindingFlags.NonPublic);
            configProperty.SetValue(api, configuration);

        }

        [TestMethod("1 - RedeemSila - Successful redeem for user")]
        public void T001Response200Success()
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.SetupGet(r => r.Headers).Returns(new List<RestSharp.Parameter>{});
            mockResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            mockResponse.SetupGet(r => r.Content).Returns(JsonConvert.SerializeObject(new TransactionResponse
            {
                Status = "SUCCESS",
                TransactionId = "mock-transaction-id",
                Reference = "mock-reference",
                ResponseTimeMs = "123"
            }));

            mockApiClient.Setup(m => m.CallApi(
                It.IsAny<string>(),
                It.IsAny<Method>(),
                It.IsAny<object>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<string>()))
            .Returns(mockResponse.Object);

            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "mock_acct");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            DefaultConfig.RedeemReference = parsedResponse.Reference;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - RedeemSila - Successful redeem tokens with business uuid and descriptor")]
        public void T002Response200Descriptor()
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.SetupGet(r => r.Headers).Returns(new List<RestSharp.Parameter>{});
            mockResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            mockResponse.SetupGet(r => r.Content).Returns(JsonConvert.SerializeObject(new TransactionResponse
            {
                Status = "SUCCESS",
                TransactionId = "mock-transaction-id",
                Reference = "mock-reference",
                ResponseTimeMs = "123",
                Descriptor = DefaultConfig.RedeemTrans
            }));

            mockApiClient.Setup(m => m.CallApi(
                It.IsAny<string>(),
                It.IsAny<Method>(),
                It.IsAny<object>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<string>()))
            .Returns(mockResponse.Object);

            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.RedeemTrans, businessUuid: DefaultConfig.businessUuid, accountName: "mock_acct");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.AreEqual(DefaultConfig.RedeemTrans, parsedResponse.Descriptor);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("3 - RedeemSila - Successful redeem tokens with same day ACH")]
        public void T003Response200SameDay()
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.SetupGet(r => r.Headers).Returns(new List<RestSharp.Parameter>{});
            mockResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            mockResponse.SetupGet(r => r.Content).Returns(JsonConvert.SerializeObject(new TransactionResponse
            {
                Status = "SUCCESS",
                TransactionId = "mock-transaction-id",
                Reference = "mock-reference",
                ResponseTimeMs = "123"
            }));

            mockApiClient.Setup(m => m.CallApi(
                It.IsAny<string>(),
                It.IsAny<Method>(),
                It.IsAny<object>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<string>()))
            .Returns(mockResponse.Object);
   
            var user = DefaultConfig.SecondUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, processingType: ProcessingType.Sameday, accountName: "mock_acct");
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
        }

        [TestMethod("4 - RedeemSila - Unsuccessful redeem for empty wallet")]
        public void T004Response200Failure()
        {
            var mockResponse = new Mock<IRestResponse>();            
            mockResponse.SetupGet(r => r.Headers).Returns(new List<RestSharp.Parameter>{});
            mockResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.BadRequest);
            mockResponse.SetupGet(r => r.Content).Returns(JsonConvert.SerializeObject(new BadRequestResponse
            {
                Status = "FAILURE",
                Reference = "mock-reference",
                ResponseTimeMs = "123",
                Message = "Insufficient wallet balance."
            }));

            mockApiClient.Setup(m => m.CallApi(
                It.IsAny<string>(),
                It.IsAny<Method>(),
                It.IsAny<object>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<string>()))
            .Returns(mockResponse.Object);

            var user = DefaultConfig.FourthUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "mock_acct");
            var parsedResponse = (BadRequestResponse)response.Data;

            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            DefaultConfig.InvalidRedeemReference = parsedResponse.Reference;
        }

        [TestMethod("5 - RedeemSila - Empty user handle failure")]
        public void T005Response400()
        {
            var realApi = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);

            ApiResponse<object> response = realApi.RedeemSila("", 100, DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode);
        }

        [TestMethod("6 - RedeemSila - Fail redeem tokens with invalid business uuid and descriptor")]
        public void T006Response400Descriptor()
        {
            var realApi = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);

            var user = DefaultConfig.SecondUser;
            var response = realApi.RedeemSila(user.UserHandle, 100, user.PrivateKey, descriptor: DefaultConfig.RedeemTrans, businessUuid: DefaultConfig.InvalidBusinessUuid);
            var parsedResponse = (BadRequestResponse)response.Data;

            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("7 - RedeemSila - Bad user signature failure")]
        public void T007Response401User()
        {
            var realApi = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);

            var response = realApi.RedeemSila(DefaultConfig.FirstUser.UserHandle, 100, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - RedeemSila");
        }

        [TestMethod("8 - RedeemSila - Bad app signature failure")]
        public void T008Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.RedeemSila(user.UserHandle, 100, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - RedeemSila");
        }
    }
    #pragma warning restore CS0618
}
