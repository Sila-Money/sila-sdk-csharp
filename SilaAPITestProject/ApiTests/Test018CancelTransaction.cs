using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test018CancelTransaction
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - CancelTransaction - Successfully cancel issue transaction")]
        public void Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var issueResponse = api.IssueSila(user.UserHandle, 1000, user.PrivateKey);
            Assert.AreEqual(200, issueResponse.StatusCode);
            Thread.Sleep(5000);
            var response = api.CancelTransaction(user.UserHandle, user.PrivateKey, ((TransactionResponse)issueResponse.Data).TransactionId);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Message.Contains($"Transaction {((TransactionResponse)issueResponse.Data).TransactionId} has been canceled"));
        }
    }
}