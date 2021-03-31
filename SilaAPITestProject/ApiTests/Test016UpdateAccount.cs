using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.refactored.api;

namespace SilaApiTest
{
    [TestClass]
    public class Test016UpdateAccount
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environment.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - Update account - Successful update account")]
        public void T020Response200()
        {
            UpdateAccountRequest request = new UpdateAccountRequest {
                AccountName = "toupdate",
                NewAccountName = "updated",
                UserHandle = DefaultConfig.FirstUser.UserHandle,
                UserPrivateKey = DefaultConfig.FirstUser.PrivateKey
            };

            UpdateAccountResponse response = UpdateAccount.Send(request);

            Assert.IsNotNull(response.Message);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.Changes);
        }
    }
}
