using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test015_LinkAccountTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("5 - LinkAccount - Link through plaid token")]
        public void T005_Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;

            var response = api.LinkAccount(
                userHandle: user.UserHandle, 
                publicToken: plaid.Token, 
                userPrivateKey: user.PrivateKey, 
                accountName: "defaultpt"
            );
            var parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.AccountOwnerName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            user = DefaultConfig.SecondUser;
            plaid = DefaultConfig.PlaidToken;

            response = api.LinkAccount(
                userHandle: user.UserHandle, 
                publicToken: plaid.Token, 
                userPrivateKey: user.PrivateKey, 
                accountName: "defaultpt"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.AccountOwnerName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            user = DefaultConfig.FourthUser;
            plaid = DefaultConfig.PlaidToken;

            response = api.LinkAccount(
                userHandle: user.UserHandle, 
                publicToken: plaid.Token, 
                userPrivateKey: user.PrivateKey, 
                accountName: "defaultpt", 
                plaidTokenType: "legacy"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.AccountOwnerName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            user = DefaultConfig.InstantUser;
            plaid = DefaultConfig.PlaidToken;

            response = api.LinkAccount(
                userHandle: user.UserHandle, 
                publicToken: plaid.Token, 
                userPrivateKey: user.PrivateKey, 
                accountName: "defaultpt"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.AccountOwnerName);
            Assert.IsNotNull(parsedResponse.EntityName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
        }

        [TestMethod("6 - LinkAccount - Link through plaid token and account id")]
        public void T006_Response200SuccessId()
        {
            var user = DefaultConfig.FirstUser;
            var plaid = DefaultConfig.PlaidToken;

            var response = api.LinkAccount(
                userHandle: user.UserHandle, 
                publicToken: plaid.Token, 
                userPrivateKey: user.PrivateKey, 
                accountName: "sync_by_id",
                accountId: plaid.AccountId
            );
            var parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.AccountOwnerName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
        }

        [TestMethod("7 - LinkAccount - Link direct account link")]
        public void T007_Response200SuccessDirect()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.LinkAccountDirect(
                userHandle: user.UserHandle, 
                userPrivateKey: user.PrivateKey,
                accountName: "sync_direct",
                accountNumber: "12345678912", 
                routingNumber: "123456789"
            );
            var parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            response = api.LinkAccountDirect(
                userHandle: user.UserHandle, 
                userPrivateKey: user.PrivateKey,
                accountName: "default",
                accountNumber: "12345678912", 
                routingNumber: "123456789"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            response = api.LinkAccountDirect(
                userHandle: user.UserHandle, 
                userPrivateKey: user.PrivateKey,
                accountName: "unlink",
                accountNumber: "12345678912", 
                routingNumber: "123456789"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            response = api.LinkAccountDirect(
                userHandle: user.UserHandle, 
                userPrivateKey: user.PrivateKey,
                accountName: "toupdate",
                accountNumber: "12345678912", 
                routingNumber: "123456789"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
        }
    }
}
