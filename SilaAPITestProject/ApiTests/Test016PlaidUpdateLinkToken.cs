using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.Silamoney.Client.Refactored.Api;
using SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.PlaidUpdateLinkToken;

namespace SilaApiTest
{
    [TestClass]
    public class Test016PlaidUpdateLinkToken
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - Plaid update link token - Successful get plaid link token")]
        public void T001Response200()
        {
            var user = DefaultConfig.FirstUser;
            PlaidUpdateLinkTokenRequest request = new PlaidUpdateLinkTokenRequest{
                AccountName = "defaultpt",
                UserHandle = user.UserHandle
            }; 

            PlaidUpdateLinkTokenResponse response = PlaidUpdateLinkToken.Send(request);
            Assert.IsNotNull(response.LinkToken);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Status);
            Assert.IsTrue(response.Success);
        }
    }
}
