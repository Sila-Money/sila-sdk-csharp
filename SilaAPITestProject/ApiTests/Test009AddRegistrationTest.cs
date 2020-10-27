using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;

namespace SilaApiTest
{
    [TestClass]
    public class Test009AddRegistrationTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - AddAddress - Success Response")]
        public void Response200Address()
        {
            throw new NotImplementedException();
        }

        [TestMethod("2 - AddEmail - Success Response")]
        public void Response200Email()
        {
            var user = DefaultConfig.FirstUser;
            var email = "some.new.email@domain.go";
            var response = api.AddEmail(user.UserHandle, user.PrivateKey, email);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (EmailResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully added email"));
            Assert.IsNotNull(parsedResponse.Email);
            Assert.IsNotNull(parsedResponse.Email.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Email.ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Email.Uuid);
            Assert.AreEqual(email, parsedResponse.Email.Email);

            DefaultConfig.EmailUuid = parsedResponse.Email.Uuid;
        }

        [TestMethod("3 - AddIdentity - Success Response")]
        public void Response200Identity()
        {
            throw new NotImplementedException();
        }

        [TestMethod("4 - AddPhone - Success Response")]
        public void Response200Phone()
        {
            var user = DefaultConfig.FirstUser;
            var phone = "9087654321";
            var response = api.AddPhone(user.UserHandle, user.PrivateKey, phone);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (PhoneResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully added phone"));
            Assert.IsNotNull(parsedResponse.Phone);
            Assert.IsNotNull(parsedResponse.Phone.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Phone.ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Phone.Uuid);
            Assert.AreEqual(phone, parsedResponse.Phone.Phone);

            DefaultConfig.PhoneUuid = parsedResponse.Phone.Uuid;
        }
    }
}
