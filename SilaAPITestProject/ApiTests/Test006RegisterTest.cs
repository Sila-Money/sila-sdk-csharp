using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sila.API;
using Sila.API.Client.Domain;
using Sila.API.Client.Entitiesregister;

namespace SilaApiTest
{
    [TestClass]
    public class Test006_RegisterTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("1 - Register - Random users registration")]
        public void TestResponse200()
        {
            RegisterRequest request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.FirstUser.AddressAlias,
                    City = ModelsUtilities.FirstUser.City,
                    PostalCode = ModelsUtilities.FirstUser.PostalCode,
                    State = ModelsUtilities.FirstUser.State,
                    StreetAddress1 = ModelsUtilities.FirstUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.FirstUser.ContactAlias,
                    Email = ModelsUtilities.FirstUser.Email,
                    Phone = ModelsUtilities.FirstUser.Phone,
                    SmsOptIn = ModelsUtilities.FirstUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.FirstUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.FirstUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.FirstUser.DeviceFingerprint
                },
                Entity = new Entity {
                    Birthdate = "1990-01-31",
                    EntityName = ModelsUtilities.FirstUser.EntityName,
                    FirstName = ModelsUtilities.FirstUser.FirstName,
                    LastName = ModelsUtilities.FirstUser.LastName,
                    Relationship = "user"
                },
                Identity = new Identity {
                    IdentityAlias = "SSN",
                    IdentityValue = ModelsUtilities.FirstUser.IdentityValue
                },
                UserHandle = ModelsUtilities.FirstUser.UserHandle
            };

            RegisterResponse response = Register.Send(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);

            request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.SecondUser.AddressAlias,
                    City = ModelsUtilities.SecondUser.City,
                    PostalCode = ModelsUtilities.SecondUser.PostalCode,
                    State = ModelsUtilities.SecondUser.State,
                    StreetAddress1 = ModelsUtilities.SecondUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.SecondUser.ContactAlias,
                    Email = ModelsUtilities.SecondUser.Email,
                    Phone = ModelsUtilities.SecondUser.Phone,
                    SmsOptIn = ModelsUtilities.SecondUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.SecondUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.SecondUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.SecondUser.DeviceFingerprint
                },
                Entity = new Entity {
                    Birthdate = "1990-01-31",
                    EntityName = ModelsUtilities.SecondUser.EntityName,
                    FirstName = ModelsUtilities.SecondUser.FirstName,
                    LastName = ModelsUtilities.SecondUser.LastName
                },
                Identity = new Identity {
                    IdentityAlias = "SSN",
                    IdentityValue = ModelsUtilities.SecondUser.IdentityValue
                },
                UserHandle = ModelsUtilities.SecondUser.UserHandle
            };

            response = Register.Send(request);
            
            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);

            request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.ThirdUser.AddressAlias,
                    City = ModelsUtilities.ThirdUser.City,
                    PostalCode = ModelsUtilities.ThirdUser.PostalCode,
                    State = ModelsUtilities.ThirdUser.State,
                    StreetAddress1 = ModelsUtilities.ThirdUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.ThirdUser.ContactAlias,
                    Email = ModelsUtilities.ThirdUser.Email,
                    Phone = ModelsUtilities.ThirdUser.Phone,
                    SmsOptIn = ModelsUtilities.ThirdUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.ThirdUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.ThirdUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.ThirdUser.DeviceFingerprint
                },
                Entity = new Entity {
                    Birthdate = "1990-01-31",
                    EntityName = ModelsUtilities.ThirdUser.EntityName,
                    FirstName = ModelsUtilities.ThirdUser.FirstName,
                    LastName = ModelsUtilities.ThirdUser.LastName
                },
                Identity = new Identity {
                    IdentityAlias = "SSN",
                    IdentityValue = ModelsUtilities.ThirdUser.IdentityValue
                },
                UserHandle = ModelsUtilities.ThirdUser.UserHandle
            };

            response = Register.Send(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);

            request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.FourthUser.AddressAlias,
                    City = ModelsUtilities.FourthUser.City,
                    PostalCode = ModelsUtilities.FourthUser.PostalCode,
                    State = ModelsUtilities.FourthUser.State,
                    StreetAddress1 = ModelsUtilities.FourthUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.FourthUser.ContactAlias,
                    Email = ModelsUtilities.FourthUser.Email,
                    Phone = ModelsUtilities.FourthUser.Phone,
                    SmsOptIn = ModelsUtilities.FourthUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.FourthUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.FourthUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.FourthUser.DeviceFingerprint
                },
                Entity = new Entity {
                    Birthdate = "1990-01-31",
                    EntityName = ModelsUtilities.FourthUser.EntityName,
                    FirstName = ModelsUtilities.FourthUser.FirstName,
                    LastName = ModelsUtilities.FourthUser.LastName
                },
                Identity = new Identity {
                    IdentityAlias = "SSN",
                    IdentityValue = ModelsUtilities.FourthUser.IdentityValue
                },
                UserHandle = ModelsUtilities.FourthUser.UserHandle
            };

            response = Register.Send(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);

            request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.BusinessUser.AddressAlias,
                    City = ModelsUtilities.BusinessUser.City,
                    PostalCode = ModelsUtilities.BusinessUser.PostalCode,
                    State = ModelsUtilities.BusinessUser.State,
                    StreetAddress1 = ModelsUtilities.BusinessUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.BusinessUser.ContactAlias,
                    Email = ModelsUtilities.BusinessUser.Email,
                    Phone = ModelsUtilities.BusinessUser.Phone,
                    SmsOptIn = ModelsUtilities.BusinessUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.BusinessUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.BusinessUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.BusinessUser.DeviceFingerprint
                },
                Entity = new Entity {
                    EntityName = ModelsUtilities.BusinessUser.EntityName,
                    BusinessType = ModelsUtilities.BusinessUser.BusinessType,
                    BusinessTypeUuid = ModelsUtilities.BusinessUser.BusinessTypeUuid,
                    BusinessWebsite = ModelsUtilities.BusinessUser.BusinessWebsite,
                    DoingBusinessAs = ModelsUtilities.BusinessUser.DoingBusinessAs,
                    Type = ModelsUtilities.BusinessUser.Type,
                    NaicsCode = ModelsUtilities.BusinessUser.NaicsCode
                },
                Identity = new Identity {
                    IdentityAlias = "EIN",
                    IdentityValue = ModelsUtilities.BusinessUser.IdentityValue
                },
                UserHandle = ModelsUtilities.BusinessUser.UserHandle
            };

            response = Register.Send(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);

            request = new RegisterRequest{
                Address = new Address{
                    AddressAlias = ModelsUtilities.InstantUser.AddressAlias,
                    City = ModelsUtilities.InstantUser.City,
                    PostalCode = ModelsUtilities.InstantUser.PostalCode,
                    State = ModelsUtilities.InstantUser.State,
                    StreetAddress1 = ModelsUtilities.InstantUser.StreetAddress1
                },
                Contact = new Contact {
                    ContactAlias = ModelsUtilities.InstantUser.ContactAlias,
                    Email = ModelsUtilities.InstantUser.Email,
                    Phone = ModelsUtilities.InstantUser.Phone,
                    SmsOptIn = ModelsUtilities.InstantUser.SmsOptIn
                },
                CryptoEntry = new CryptoEntry{
                    CryptoAddress = ModelsUtilities.InstantUser.CryptoAddress,
                    CryptoAlias = ModelsUtilities.InstantUser.CryptoAlias
                },
                Device = new Device {
                    DeviceFingerprint = ModelsUtilities.InstantUser.DeviceFingerprint
                },
                Entity = new Entity {
                    Birthdate = "1990-01-31",
                    EntityName = ModelsUtilities.InstantUser.EntityName,
                    FirstName = ModelsUtilities.InstantUser.FirstName,
                    LastName = ModelsUtilities.InstantUser.LastName
                },
                Identity = new Identity {
                    IdentityAlias = "SSN",
                    IdentityValue = ModelsUtilities.InstantUser.IdentityValue
                },
                UserHandle = ModelsUtilities.InstantUser.UserHandle
            };

            response = Register.Send(request);

            Assert.IsTrue(response.Success);
            Assert.AreEqual("SUCCESS", response.Status);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
        }

    }
}
