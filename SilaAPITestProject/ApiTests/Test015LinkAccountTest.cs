using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test015_LinkAccountTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("7 - LinkAccount - Link direct account link")]
        public void T007_Response200SuccessDirect()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.LinkAccountDirect(
                userHandle: user.UserHandle, 
                userPrivateKey: user.PrivateKey,
                accountName: "sync_direct",
                accountNumber: "12345678912", 
                routingNumber: "123456780"
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
                routingNumber: "123456780"
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
                routingNumber: "123456780"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);

            response = api.LinkAccountDirect(
                userHandle: DefaultConfig.SecondUser.UserHandle, 
                userPrivateKey: DefaultConfig.SecondUser.PrivateKey,
                accountName: "defaultpt",
                accountNumber: "12345678912", 
                routingNumber: "123456780"
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
                accountName: "defaultpt",
                accountNumber: "12345678912", 
                routingNumber: "123456780"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);

            response = api.LinkAccountDirect(
                userHandle: DefaultConfig.FourthUser.UserHandle, 
                userPrivateKey: DefaultConfig.FourthUser.PrivateKey,
                accountName: "defaultpt",
                accountNumber: "12345678912", 
                routingNumber: "123456780"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);

            response = api.LinkAccountDirect(
                userHandle: DefaultConfig.InstantUser.UserHandle, 
                userPrivateKey: DefaultConfig.InstantUser.PrivateKey,
                accountName: "defaultpt",
                accountNumber: "12345678912", 
                routingNumber: "123456780"
            );
            parsedResponse = (LinkAccountResponse)response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.AccountName);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
