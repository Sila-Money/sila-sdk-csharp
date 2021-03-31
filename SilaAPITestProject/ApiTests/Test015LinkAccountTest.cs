using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.refactored.api;

namespace SilaApiTest
{
    [TestClass]
    public class Test015_LinkAccountTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environment.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("5 - LinkAccount - Link through plaid token")]
        public void T005_Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;

            LinkAccountRequest request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                PlaidToken = plaid.Token,
                AccountName = "defaultpt"
            };

            LinkAccountResponse response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.AccountOwnerName);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            user = DefaultConfig.SecondUser;
            plaid = DefaultConfig.PlaidToken;

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                PlaidToken = plaid.Token,
                AccountName = "defaultpt"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.AccountOwnerName);
            Assert.IsNotNull(response.EntityName);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            user = DefaultConfig.FourthUser;
            plaid = DefaultConfig.PlaidToken;

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                PlaidToken = plaid.Token,
                AccountName = "defaultpt"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.AccountOwnerName);
            Assert.IsNotNull(response.EntityName);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            user = DefaultConfig.InstantUser;
            plaid = DefaultConfig.PlaidToken;

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                PlaidToken = plaid.Token,
                AccountName = "defaultpt"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.AccountOwnerName);
            Assert.IsNotNull(response.EntityName);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
        }

        [TestMethod("6 - LinkAccount - Link through plaid token and account id")]
        public void T006_Response200SuccessId()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;
            LinkAccountRequest request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                PlaidToken = plaid.Token,
                AccountName = "sync_by_id",
                SelectedAccountId = plaid.AccountId
            };

            LinkAccountResponse response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.AccountOwnerName);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
        }

        [TestMethod("7 - LinkAccount - Link direct account link")]
        public void T007_Response200SuccessDirect()
        {
            var user = DefaultConfig.FirstUser;

            LinkAccountRequest request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                AccountName = "sync_direct",
                AccountNumber = "123456789012",
                RoutingNumber = "123456789"
            };

            LinkAccountResponse response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                AccountName = "default",
                AccountNumber = "123456789012",
                RoutingNumber = "123456789"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                AccountName = "unlink",
                AccountNumber = "123456789012",
                RoutingNumber = "123456789"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);

            request = new LinkAccountRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                AccountName = "toupdate",
                AccountNumber = "123456789012",
                RoutingNumber = "123456789"
            };

            response = LinkAccount.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Account);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
        }
    }
}
