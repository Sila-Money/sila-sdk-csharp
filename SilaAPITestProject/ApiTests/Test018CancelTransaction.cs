using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test018CancelTransaction
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - CancelTransaction - Successfully cancel issue transaction")]
        public void Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var issueResponse = api.IssueSila(user.UserHandle, 1000, user.PrivateKey);
            Assert.AreEqual(200, issueResponse.StatusCode);
            var response = api.CancelTransaction(user.UserHandle, user.PrivateKey, ((TransactionResponse)issueResponse.Data).TransactionId);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}