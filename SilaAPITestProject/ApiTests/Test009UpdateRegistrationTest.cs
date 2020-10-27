using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Linq;

namespace SilaApiTest
{
    [TestClass]
    public class Test009UpdateRegistrationTest
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - UpdateAddress - Success Response")]
        public void Response200Address()
        {
            var user = DefaultConfig.FirstUser;
            var address = new AddressMessage
            {
                Uuid = DefaultConfig.AddressUuid,
                AddressAlias = "updated_address",
            };
            var response = api.UpdateAddress(user.UserHandle, user.PrivateKey, address);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (AddressResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated address"));
            Assert.IsNotNull(parsedResponse.Address);
            Assert.IsNotNull(parsedResponse.Address.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Address.ModifiedEpoch);
            Assert.AreEqual(address.Uuid, parsedResponse.Address.Uuid);
            Assert.AreEqual(address.AddressAlias, parsedResponse.Address.Nickname);
            Assert.IsNotNull(parsedResponse.Address.StreetAddress1);
            Assert.IsNotNull(parsedResponse.Address.StreetAddress2);
            Assert.IsNotNull(parsedResponse.Address.City);
            Assert.IsNotNull(parsedResponse.Address.State);
            Assert.IsNotNull(parsedResponse.Address.Country);
            Assert.IsNotNull(parsedResponse.Address.PostalCode);
        }

        [TestMethod("2 - UpdateEmail - Success Response")]
        public void Response200Email()
        {
            var user = DefaultConfig.FirstUser;
            var email = "some.updated.email@domain.go";
            var response = api.UpdateEmail(user.UserHandle, user.PrivateKey, DefaultConfig.EmailUuid, email);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (EmailResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated email"));
            Assert.IsNotNull(parsedResponse.Email);
            Assert.IsNotNull(parsedResponse.Email.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Email.ModifiedEpoch);
            Assert.AreEqual(DefaultConfig.EmailUuid, parsedResponse.Email.Uuid);
            Assert.AreEqual(email, parsedResponse.Email.Email);
        }

        [TestMethod("3 - UpdateEntity - Individual Success Response")]
        public void Response200Entity()
        {
            var user = DefaultConfig.FirstUser;
            var entity = new IndividualEntityMessage
            {
                FirstName = "NewFirst",
                LastName = "NewLast",
                EntityName = "NewFirst NewLast",
                BirthDate = new DateTime(1994, 1, 8)
            };
            var response = api.UpdateEntity(user.UserHandle, user.PrivateKey, entity);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (IndividualEntityResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated entity"));
            Assert.AreEqual(user.UserHandle.ToLower(), parsedResponse.UserHandle);
            Assert.AreEqual("individual", parsedResponse.EntityType);
            Assert.IsNotNull(parsedResponse.Entity);
            Assert.IsNotNull(parsedResponse.Entity.CreatedEpoch);
            Assert.AreEqual(entity.EntityName, parsedResponse.Entity.EntityName);
            Assert.IsNotNull(parsedResponse.Entity.Birthdate);
            Assert.AreEqual(entity.FirstName, parsedResponse.Entity.FirstName);
            Assert.AreEqual(entity.LastName, parsedResponse.Entity.LastName);
        }

        [TestMethod("3 - UpdateEntity - Business Success Response")]
        public void Response200EntityBusiness()
        {
            var user = DefaultConfig.BusinessUser;
            var entity = new BusinessEntityMessage
            {
                EntityName = "New Company",
                BusinessType = DefaultConfig.BusinessTypes[0].Name,
                NaicsCode = DefaultConfig.NaicsCategories.First().Value.First().Code,
                DoingBusinessAs = "NC Ltd.",
                BusinessWebsite = "https://domain.go"
            };
            var response = api.UpdateEntity(user.UserHandle, user.PrivateKey, entity);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (BusinessEntityResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated entity"));
            Assert.AreEqual(user.UserHandle.ToLower(), parsedResponse.UserHandle);
            Assert.AreEqual("business", parsedResponse.EntityType);
            Assert.IsNotNull(parsedResponse.Entity);
            Assert.IsNotNull(parsedResponse.Entity.CreatedEpoch);
            Assert.AreEqual(entity.EntityName, parsedResponse.Entity.EntityName);
            Assert.AreEqual(entity.BusinessType, parsedResponse.Entity.BusinessType);
            Assert.AreEqual(entity.NaicsCode, parsedResponse.Entity.NaicsCode);
            Assert.IsNotNull(parsedResponse.Entity.BusinessUuid);
            Assert.IsNotNull(parsedResponse.Entity.NaicsCategory);
            Assert.IsNotNull(parsedResponse.Entity.NaicsSubcategory);
            Assert.AreEqual(entity.DoingBusinessAs, parsedResponse.Entity.DoingBusinessAs);
            Assert.AreEqual(entity.BusinessWebsite, parsedResponse.Entity.BusinessWebsite);
        }

        [TestMethod("5 - UpdateIdentity - Success Response")]
        public void Response200Identity()
        {
            var user = DefaultConfig.FirstUser;
            var identity = new IdentityMessage
            {
                Uuid = DefaultConfig.IdentityUuid,
                IdentityAlias = "SSN",
                IdentityValue = "543212222"
            };
            var response = api.UpdateIdentity(user.UserHandle, user.PrivateKey, identity);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (IdentityResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated identity"));
            Assert.IsNotNull(parsedResponse.Identity);
            Assert.IsNotNull(parsedResponse.Identity.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Identity.ModifiedEpoch);
            Assert.AreEqual(identity.Uuid, parsedResponse.Identity.Uuid);
            Assert.AreEqual(identity.IdentityAlias, parsedResponse.Identity.IdentityType);
            Assert.IsNotNull(parsedResponse.Identity.Identity);

            DefaultConfig.IdentityUuid = parsedResponse.Identity.Uuid;
        }

        [TestMethod("6 - UpdatePhone - Success Response")]
        public void Response200Phone()
        {
            var user = DefaultConfig.FirstUser;
            var phone = "9087654321";
            var response = api.UpdatePhone(user.UserHandle, user.PrivateKey, DefaultConfig.PhoneUuid, phone);

            Assert.AreEqual(200, response.StatusCode);
            var parsedResponse = (PhoneResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsTrue(parsedResponse.Message.Contains("Successfully updated phone"));
            Assert.IsNotNull(parsedResponse.Phone);
            Assert.IsNotNull(parsedResponse.Phone.AddedEpoch);
            Assert.IsNotNull(parsedResponse.Phone.ModifiedEpoch);
            Assert.AreEqual(DefaultConfig.PhoneUuid, parsedResponse.Phone.Uuid);
            Assert.AreEqual(phone, parsedResponse.Phone.Phone);

            DefaultConfig.PhoneUuid = parsedResponse.Phone.Uuid;
        }
    }
}
