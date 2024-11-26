using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.configuration;
using SilaAPI.silamoney.client.domain;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace SilaApiTest
{
    [TestClass]
    public class Test018GetAccountBalanceTest
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

        [TestMethod("1 - GetAccountBalance - Successful plaid account balance")]
        public void Response200()
        {
            #pragma warning disable CS0618
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.SetupGet(r => r.Headers).Returns(new List<RestSharp.Parameter>{});
            mockResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            mockResponse.SetupGet(r => r.Content).Returns(JsonConvert.SerializeObject(new GetAccountBalanceResponse
            {
                Status = "SUCCESS",
                AccountName = "mock_acct",
                Reference = "mock-reference",
                ResponseTimeMs = "123",
                Success = true
            }));

            mockApiClient.Setup(m => m.CallApi(
                It.IsAny<string>(),
                It.IsAny<Method>(),
                It.IsAny<object>(),
                It.IsAny<Dictionary<string, string>>(),
                It.IsAny<string>()))
            .Returns(mockResponse.Object);

            var user = DefaultConfig.FirstUser;
            var firstResponse = api.GetAccountBalance(user.UserHandle, user.PrivateKey, "mock_acct");

            Assert.AreEqual(200, firstResponse.StatusCode, $"{user.UserHandle} account 'default' should success get_accounts");
            var parsedResponse = (GetAccountBalanceResponse)firstResponse.Data;
            Assert.AreEqual("mock_acct", parsedResponse.AccountName, $"{user.UserHandle} account 'default' should match account_name");
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            #pragma warning restore CS0618
        }

        [TestMethod("2 - GetAccountBalance - Unsuccessful direct link account balance")]
        public void Response400()
        {
            api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);
            var user = DefaultConfig.FirstUser;
            var response = api.GetAccountBalance(user.UserHandle, user.PrivateKey, "sync_direct");

            Assert.AreEqual(400, response.StatusCode, $"{user.UserHandle} account 'sync_direct' sould fail get_accounts");
        }

        [TestMethod("3 - GetAccountBalance - Bad user signature failure")]
        public void Response403User()
        {
            api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle, false);
            var response = api.GetAccountBalance(DefaultConfig.FirstUser.UserHandle, DefaultConfig.privateKey, "default");

            Assert.AreEqual(403, response.StatusCode, "Bad user signature status - GetAccountBalance");
        }

        [TestMethod("4 - GetAccountBalance - Bad app signature failure")]
        public void Response403()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.GetAccountBalance(user.UserHandle, user.PrivateKey, "default");

            Assert.AreEqual(403, response.StatusCode, "Bad app signature status - GetAccountBalance");
        }
    }
}
