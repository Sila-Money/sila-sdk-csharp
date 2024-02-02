using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test100TearDown
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("101 - UnlinkBusinessMember - Successful unlink administrator")]
        public void T101Response200Administrator()
        {
            var businessRole = DefaultConfig.BusinessRole("administrator");
            var response = api.UnlinkBusinessMember(
                DefaultConfig.FirstUser.UserHandle,
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole
            );

            var parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
    }


        [TestMethod("102 - UnlinkBusinessMember - Successful unlink beneficial owner")]
        public void T102Response200BeneficialOwner()
        {
            var businessRole = DefaultConfig.BusinessRole("beneficial_owner");
            var response = api.UnlinkBusinessMember(
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                businessRole
            );

            var parsedResponse = (LinkOperationResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(businessRole.Name, parsedResponse.Role);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }


        [TestMethod("103 - DeleteRegistrationAddress - Failure Response")]
        // Addresses cannot be deleted or modified within 30 days of passing kyc.
        public void T103Response403DeleteRegistrationAddress()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.GetEntity(user.UserHandle, user.PrivateKey);
            Assert.AreEqual(200, response.StatusCode);
            var entityResponse = (GetEntityResponse)response.Data;


            response = api.DeleteRegistrationData(user.UserHandle, user.PrivateKey, RegistrationData.Address, entityResponse.Addresses[0].Uuid);
            Assert.AreEqual(403, response.StatusCode);
            var parsedResponse = (BaseResponseWithoutReference)response.Data;
            Assert.IsFalse(parsedResponse.Success);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }


        [TestMethod("104 - DeleteRegistrationEmail - Success Response")]
        public void T104Response200DeleteRegistrationEmail()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.GetEntity(user.UserHandle, user.PrivateKey);
            Assert.AreEqual(200, response.StatusCode);
            var entityResponse = (GetEntityResponse)response.Data;


            response = api.DeleteRegistrationData(user.UserHandle, user.PrivateKey, RegistrationData.Email, entityResponse.Emails[0].Uuid);
            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (BaseResponseWithoutReference)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }



       

        [TestMethod("105 - DeleteRegistrationPhone - Success Response")]
        public void T105Response200DeleteRegistrationPhone()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.GetEntity(user.UserHandle, user.PrivateKey);
            Assert.AreEqual(200, response.StatusCode);
            var entityResponse = (GetEntityResponse)response.Data;


            response = api.DeleteRegistrationData(user.UserHandle, user.PrivateKey, RegistrationData.Phone, entityResponse.Phones[0].Uuid);
            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (BaseResponseWithoutReference)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

      

        [TestMethod("106 - DeleteLinkAccountDirect - Successful delete account")]
        public void T106Response200DeleteLinkAccountDirect()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "sync_direct");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("107 - DeleteLinkAccountDirect - Successful delete account")]
        public void T107Response200DeleteLinkAccountDirect()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "default");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        
        [TestMethod("108 - DeleteLinkAccount1 - Successful delete account")]
        public void T108Response200DeleteLinkAccount1()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "defaultpt");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("109 - DeleteLinkAccount2 - Successful delete account")]
        public void T109Response200DeleteLinkAccount2()
        {
            var user = DefaultConfig.SecondUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "defaultpt");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("110 - DeleteLinkAccount4 - Successful delete account")]
        public void T110Response200DeleteLinkAccount4()
        {
            var user = DefaultConfig.FourthUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "defaultpt");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }


        [TestMethod("111 - DeleteLinkAccountInstant - Successful delete account")]
        public void T111Response200DeleteLinkAccountInstant()
        {
            var user = DefaultConfig.InstantUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "defaultpt");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("112 - DeleteLinkAccountPlaid - Successful delete account")]
        public void T112Response200DeleteLinkAccountPlaid()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.DeleteAccount(user.UserHandle, user.PrivateKey, "sync_by_id");
            var parsedResponse = (DeleteAccountResult)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
