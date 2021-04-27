using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test016PlaidUpdateLinkToken
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - Plaid update link token - Successful get plaid link token")]
        public void T001Response200()
        {
            var user = DefaultConfig.FirstUser;
            PlaidUpdateLinkTokenRequest request = new PlaidUpdateLinkTokenRequest{
                AccountName = "defaultpt",
                UserHandle = user.UserHandle
            }; 

            var response = api.PlaidUpdateLinkToken(request);
            var parsedResponse = (PlaidUpdateLinkTokenResponse) response.Data;

            Assert.IsNotNull(parsedResponse.LinkToken);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
        }
    }
}
