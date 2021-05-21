// using System;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// 
// using Sila.API.Client.Domain;

// namespace SilaApiTest
// {
//     [TestClass]
//     public class Test006_RegisterTest
//     {
//         [TestInitialize]
//         public void TestInitialize() {
//             SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
//         }

//         [TestMethod("1 - Register - Random users registration")]
//         public void TestResponse200()
//         {
//             RegisterRequest request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.FirstUser.AddressAlias,
//                     City = ModelsUtilities.FirstUser.City,
//                     Country = ModelsUtilities.FirstUser.Country,
//                     PostalCode = ModelsUtilities.FirstUser.PostalCode,
//                     State = ModelsUtilities.FirstUser.State,
//                     StreetAddress1 = ModelsUtilities.FirstUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.FirstUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.FirstUser.ContactAlias,
//                     Email = ModelsUtilities.FirstUser.Email,
//                     Phone = ModelsUtilities.FirstUser.Phone,
//                     SmsOptIn = ModelsUtilities.FirstUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.FirstUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.FirstUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.FirstUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.FirstUser.EntityName,
//                     FirstName = ModelsUtilities.FirstUser.FirstName,
//                     LastName = ModelsUtilities.FirstUser.LastName
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "SSN",
//                     IdentityValue = ModelsUtilities.FirstUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.FirstUser.UserHandle
//             };

//             RegisterResponse response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.SecondUser.AddressAlias,
//                     City = ModelsUtilities.SecondUser.City,
//                     Country = ModelsUtilities.SecondUser.Country,
//                     PostalCode = ModelsUtilities.SecondUser.PostalCode,
//                     State = ModelsUtilities.SecondUser.State,
//                     StreetAddress1 = ModelsUtilities.SecondUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.SecondUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.SecondUser.ContactAlias,
//                     Email = ModelsUtilities.SecondUser.Email,
//                     Phone = ModelsUtilities.SecondUser.Phone,
//                     SmsOptIn = ModelsUtilities.SecondUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.SecondUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.SecondUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.SecondUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.SecondUser.EntityName,
//                     FirstName = ModelsUtilities.SecondUser.FirstName,
//                     LastName = ModelsUtilities.SecondUser.LastName
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "SSN",
//                     IdentityValue = ModelsUtilities.SecondUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.SecondUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.ThirdUser.AddressAlias,
//                     City = ModelsUtilities.ThirdUser.City,
//                     Country = ModelsUtilities.ThirdUser.Country,
//                     PostalCode = ModelsUtilities.ThirdUser.PostalCode,
//                     State = ModelsUtilities.ThirdUser.State,
//                     StreetAddress1 = ModelsUtilities.ThirdUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.ThirdUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.ThirdUser.ContactAlias,
//                     Email = ModelsUtilities.ThirdUser.Email,
//                     Phone = ModelsUtilities.ThirdUser.Phone,
//                     SmsOptIn = ModelsUtilities.ThirdUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.ThirdUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.ThirdUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.ThirdUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.ThirdUser.EntityName,
//                     FirstName = ModelsUtilities.ThirdUser.FirstName,
//                     LastName = ModelsUtilities.ThirdUser.LastName
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "SSN",
//                     IdentityValue = ModelsUtilities.ThirdUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.ThirdUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.FourthUser.AddressAlias,
//                     City = ModelsUtilities.FourthUser.City,
//                     Country = ModelsUtilities.FourthUser.Country,
//                     PostalCode = ModelsUtilities.FourthUser.PostalCode,
//                     State = ModelsUtilities.FourthUser.State,
//                     StreetAddress1 = ModelsUtilities.FourthUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.FourthUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.FourthUser.ContactAlias,
//                     Email = ModelsUtilities.FourthUser.Email,
//                     Phone = ModelsUtilities.FourthUser.Phone,
//                     SmsOptIn = ModelsUtilities.FourthUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.FourthUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.FourthUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.FourthUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.FourthUser.EntityName,
//                     FirstName = ModelsUtilities.FourthUser.FirstName,
//                     LastName = ModelsUtilities.FourthUser.LastName
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "SSN",
//                     IdentityValue = ModelsUtilities.FourthUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.FourthUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.BusinessUser.AddressAlias,
//                     City = ModelsUtilities.BusinessUser.City,
//                     Country = ModelsUtilities.BusinessUser.Country,
//                     PostalCode = ModelsUtilities.BusinessUser.PostalCode,
//                     State = ModelsUtilities.BusinessUser.State,
//                     StreetAddress1 = ModelsUtilities.BusinessUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.BusinessUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.BusinessUser.ContactAlias,
//                     Email = ModelsUtilities.BusinessUser.Email,
//                     Phone = ModelsUtilities.BusinessUser.Phone,
//                     SmsOptIn = ModelsUtilities.BusinessUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.BusinessUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.BusinessUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.BusinessUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     EntityName = ModelsUtilities.BusinessUser.EntityName,
//                     BusinessType = ModelsUtilities.BusinessUser.BusinessType,
//                     BusinessTypeUuid = ModelsUtilities.BusinessUser.BusinessTypeUuid,
//                     BusinessWebsite = ModelsUtilities.BusinessUser.BusinessWebsite,
//                     DoingBusinessAs = ModelsUtilities.BusinessUser.DoingBusinessAs,
//                     Type = ModelsUtilities.BusinessUser.Type
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "EIN",
//                     IdentityValue = ModelsUtilities.BusinessUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.BusinessUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.BasicUser.AddressAlias,
//                     City = ModelsUtilities.BasicUser.City,
//                     Country = ModelsUtilities.BasicUser.Country,
//                     PostalCode = ModelsUtilities.BasicUser.PostalCode,
//                     State = ModelsUtilities.BasicUser.State,
//                     StreetAddress1 = ModelsUtilities.BasicUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.BasicUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.BasicUser.ContactAlias,
//                     Email = ModelsUtilities.BasicUser.Email,
//                     Phone = ModelsUtilities.BasicUser.Phone,
//                     SmsOptIn = ModelsUtilities.BasicUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.BasicUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.BasicUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.BasicUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.BasicUser.EntityName,
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "EIN",
//                     IdentityValue = ModelsUtilities.BasicUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.BasicUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.DeviceUser.AddressAlias,
//                     City = ModelsUtilities.DeviceUser.City,
//                     Country = ModelsUtilities.DeviceUser.Country,
//                     PostalCode = ModelsUtilities.DeviceUser.PostalCode,
//                     State = ModelsUtilities.DeviceUser.State,
//                     StreetAddress1 = ModelsUtilities.DeviceUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.DeviceUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.DeviceUser.ContactAlias,
//                     Email = ModelsUtilities.DeviceUser.Email,
//                     Phone = ModelsUtilities.DeviceUser.Phone,
//                     SmsOptIn = ModelsUtilities.DeviceUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.DeviceUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.DeviceUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.DeviceUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.DeviceUser.EntityName,
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "EIN",
//                     IdentityValue = ModelsUtilities.DeviceUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.DeviceUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.BasicBusiness.AddressAlias,
//                     City = ModelsUtilities.BasicBusiness.City,
//                     Country = ModelsUtilities.BasicBusiness.Country,
//                     PostalCode = ModelsUtilities.BasicBusiness.PostalCode,
//                     State = ModelsUtilities.BasicBusiness.State,
//                     StreetAddress1 = ModelsUtilities.BasicBusiness.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.BasicBusiness.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.BasicBusiness.ContactAlias,
//                     Email = ModelsUtilities.BasicBusiness.Email,
//                     Phone = ModelsUtilities.BasicBusiness.Phone,
//                     SmsOptIn = ModelsUtilities.BasicBusiness.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.BasicBusiness.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.BasicBusiness.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.BasicBusiness.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     EntityName = ModelsUtilities.BasicBusiness.EntityName,
//                     BusinessType = ModelsUtilities.BasicBusiness.BusinessType,
//                     BusinessTypeUuid = ModelsUtilities.BasicBusiness.BusinessTypeUuid,
//                     BusinessWebsite = ModelsUtilities.BasicBusiness.BusinessWebsite,
//                     DoingBusinessAs = ModelsUtilities.BasicBusiness.DoingBusinessAs,
//                     Type = ModelsUtilities.BasicBusiness.Type
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "EIN",
//                     IdentityValue = ModelsUtilities.BasicBusiness.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.BasicBusiness.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);

//             request = new RegisterRequest{
//                 Address = new Address{
//                     AddressAlias = ModelsUtilities.InstantUser.AddressAlias,
//                     City = ModelsUtilities.InstantUser.City,
//                     Country = ModelsUtilities.InstantUser.Country,
//                     PostalCode = ModelsUtilities.InstantUser.PostalCode,
//                     State = ModelsUtilities.InstantUser.State,
//                     StreetAddress1 = ModelsUtilities.InstantUser.StreetAddress1,
//                     StreetAddress2 = ModelsUtilities.InstantUser.StreetAddress2
//                 },
//                 Contact = new Contact {
//                     ContactAlias = ModelsUtilities.InstantUser.ContactAlias,
//                     Email = ModelsUtilities.InstantUser.Email,
//                     Phone = ModelsUtilities.InstantUser.Phone,
//                     SmsOptIn = ModelsUtilities.InstantUser.SmsOptIn
//                 },
//                 CryptoEntry = new CryptoEntry{
//                     CryptoAddress = ModelsUtilities.InstantUser.CryptoAddress,
//                     CryptoAlias = ModelsUtilities.InstantUser.CryptoAlias
//                 },
//                 Device = new Device {
//                     DeviceFingerprint = ModelsUtilities.InstantUser.DeviceFingerprint
//                 },
//                 Entity = new Entity {
//                     Birthdate = "1990-01-31",
//                     EntityName = ModelsUtilities.InstantUser.EntityName,
//                 },
//                 Identity = new Identity {
//                     IdentityAlias = "EIN",
//                     IdentityValue = ModelsUtilities.InstantUser.IdentityValue
//                 },
//                 UserHandle = ModelsUtilities.InstantUser.UserHandle
//             };

//             response = Register.Send(request);

//             Assert.IsTrue(response.success);
//             Assert.AreEqual("SUCCESS", response.status);
//             Assert.IsNotNull(response.message);
//             Assert.IsNotNull(response.reference);
//         }

//     }
// }
