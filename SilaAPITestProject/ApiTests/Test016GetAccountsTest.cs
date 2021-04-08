using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.Silamoney.Client.Refactored.Api;
using SilaAPI.Silamoney.Client.Refactored.Endpoints.Accounts.GetAccounts;
using System.Collections.Generic;

namespace SilaApiTest
{
    [TestClass]
    public class Test016_GetAccountsTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - GetAccounts - Successfully obtained accounts")]
        public void Response200()
        {
            var user = DefaultConfig.FirstUser;
            GetAccountsRequest request = new GetAccountsRequest
            {
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            GetAccountsResponse response = GetAccounts.Send(request);

            Assert.IsNotNull(response.Accounts);
            Assert.IsTrue(response.Accounts.Count > 0);
            Assert.IsNotNull(response.Accounts[0].AccountName);
        }
    }
}
