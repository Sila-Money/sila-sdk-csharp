using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test009AddRegistrationTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - AddAddress - Success Response")]
        public void Response200Address()
        {
            var user = DefaultConfig.FirstUser;
            var address = new AddressMessage
            {
                AddressAlias = "new_address",
                StreetAddress1 = "324 songbird avenue",
                StreetAddress2 = "apt. 132",
                City = "portland",
                State = "va",
                PostalCode = "12345",
                Country = "US"
            };
            var response = api.AddAddress(user.UserHandle, user.PrivateKey, address);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (AddressResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Address);
            Assert.IsNotNull(parsedResponse.Address.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Address.ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Address.Uuid);
            Assert.AreEqual(address.AddressAlias, parsedResponse.Address.Nickname);
            Assert.AreEqual(address.StreetAddress1, parsedResponse.Address.StreetAddress1);
            Assert.AreEqual(address.StreetAddress2, parsedResponse.Address.StreetAddress2);
            Assert.AreEqual(address.City, parsedResponse.Address.City);
            Assert.AreEqual(address.State, parsedResponse.Address.State);
            Assert.AreEqual(address.Country, parsedResponse.Address.Country);
            Assert.AreEqual(address.PostalCode, parsedResponse.Address.PostalCode);

            DefaultConfig.AddressUuid = parsedResponse.Address.Uuid;
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
            var user = DefaultConfig.FirstUser;
            var identity = new IdentityMessage
            {
                IdentityAlias = "SSN",
                IdentityValue = "543212222"
            };
            var response = api.AddIdentity(user.UserHandle, user.PrivateKey, identity);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (IdentityResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Identity);
            Assert.IsNotNull(parsedResponse.Identity.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Identity.ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Identity.Uuid);
            Assert.AreEqual(identity.IdentityAlias, parsedResponse.Identity.IdentityType);
            Assert.IsNotNull(parsedResponse.Identity.Identity);

            DefaultConfig.IdentityUuid = parsedResponse.Identity.Uuid;
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
            Assert.IsNotNull(parsedResponse.Phone);
            Assert.IsNotNull(parsedResponse.Phone.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Phone.ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Phone.Uuid);
            Assert.AreEqual(phone, parsedResponse.Phone.Phone);

            DefaultConfig.PhoneUuid = parsedResponse.Phone.Uuid;
        }

        [TestMethod("5 - AddDevice - Success Response")]
        public void Response200Device()
        {
            var user = DefaultConfig.FirstUser;
            var deviceFingerprint = "test_device_fingerprint";
            var response = api.AddDevice(user.UserHandle, user.PrivateKey, deviceFingerprint);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
        }
    }
}
