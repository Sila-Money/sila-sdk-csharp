using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test016UpdateAccount
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Update account - Successful update account")]
        public void T020Response200()
        {
            UpdateAccountRequest request = new UpdateAccountRequest {
                AccountName = "toupdate",
                NewAccountName = "updated",
                UserHandle = DefaultConfig.FirstUser.UserHandle,
                UserPrivateKey = DefaultConfig.FirstUser.PrivateKey
            };

            var response = api.UpdateAccount(request);
            var parsedResponse = (UpdateAccountResponse) response.Data;

            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Account);
            Assert.IsNotNull(parsedResponse.Changes);
        }
    }
}
