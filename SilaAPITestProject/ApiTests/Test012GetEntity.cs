﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test012GetEntity
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - GetEntity - Successful GetEntity")]
        [Timeout(300000)]
        public void Response200()
        {
            var response = api.GetEntity(
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey
            );

            var parsedResponse = (GetEntityResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Addresses.Count > 0);
            Assert.IsNotNull(parsedResponse.Addresses.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Addresses.First().City);
            Assert.IsNotNull(parsedResponse.Addresses.First().Country);
            Assert.IsNotNull(parsedResponse.Addresses.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Addresses.First().PostalCode);
            Assert.IsNotNull(parsedResponse.Addresses.First().State);
            Assert.IsNotNull(parsedResponse.Addresses.First().StreetAddress1);
            Assert.IsNotNull(parsedResponse.Addresses.First().Uuid);
            Assert.IsTrue(parsedResponse.Emails.Count > 0);
            Assert.IsNotNull(parsedResponse.Emails.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Emails.First().Email);
            Assert.IsNotNull(parsedResponse.Emails.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Emails.First().Uuid);
            Assert.IsNotNull(parsedResponse.Entity.Birthdate);
            Assert.IsNotNull(parsedResponse.Entity.CreatedEpoch);
            Assert.IsNotNull(parsedResponse.Entity.FirstName);
            Assert.IsNotNull(parsedResponse.Entity.LastName);
            Assert.IsNotNull(parsedResponse.EntityType);
            Assert.IsTrue(parsedResponse.Identities.Count > 0);
            Assert.IsNotNull(parsedResponse.Identities.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Identities.First().IdentityNumber);
            Assert.IsNotNull(parsedResponse.Identities.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Identities.First().IdentityType);
            Assert.IsNotNull(parsedResponse.Identities.First().Uuid);
            Assert.IsTrue(parsedResponse.Memberships.Count > 0);
            Assert.IsNotNull(parsedResponse.Memberships.First().BusinessHandle);
            Assert.IsNotNull(parsedResponse.Memberships.First().EntityName);
            Assert.IsNotNull(parsedResponse.Memberships.First().Role);
            Assert.IsTrue(parsedResponse.Phones.Count > 0);
            Assert.IsNotNull(parsedResponse.Phones.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Phones.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Phones.First().Phone);
            Assert.IsNotNull(parsedResponse.Phones.First().Uuid);
            Assert.IsNotNull(parsedResponse.UserHandle);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - GetEntity - Successful with pretty dates")]
        public void Response200WithPrettyDates()
        {
            var response = api.GetEntity(
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey,
                true
            );

            var parsedResponse = (GetEntityResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.IsTrue(parsedResponse.Addresses.Count > 0);
            Assert.IsNotNull(parsedResponse.Addresses.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Addresses.First().Added);
            Assert.IsNotNull(parsedResponse.Addresses.First().City);
            Assert.IsNotNull(parsedResponse.Addresses.First().Country);
            Assert.IsNotNull(parsedResponse.Addresses.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Addresses.First().Modified);
            Assert.IsNotNull(parsedResponse.Addresses.First().PostalCode);
            Assert.IsNotNull(parsedResponse.Addresses.First().State);
            Assert.IsNotNull(parsedResponse.Addresses.First().StreetAddress1);
            Assert.IsNotNull(parsedResponse.Addresses.First().Uuid);
            Assert.IsTrue(parsedResponse.Emails.Count > 0);
            Assert.IsNotNull(parsedResponse.Emails.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Emails.First().Added);
            Assert.IsNotNull(parsedResponse.Emails.First().Email);
            Assert.IsNotNull(parsedResponse.Emails.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Emails.First().Modified);
            Assert.IsNotNull(parsedResponse.Emails.First().Uuid);
            Assert.IsNotNull(parsedResponse.Entity.Birthdate);
            Assert.IsNotNull(parsedResponse.Entity.CreatedEpoch);
            Assert.IsNotNull(parsedResponse.Entity.Created);
            Assert.IsNotNull(parsedResponse.Entity.FirstName);
            Assert.IsNotNull(parsedResponse.Entity.LastName);
            Assert.IsNotNull(parsedResponse.EntityType);
            Assert.IsTrue(parsedResponse.Identities.Count > 0);
            Assert.IsNotNull(parsedResponse.Identities.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Identities.First().Added);
            Assert.IsNotNull(parsedResponse.Identities.First().IdentityNumber);
            Assert.IsNotNull(parsedResponse.Identities.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Identities.First().Modified);
            Assert.IsNotNull(parsedResponse.Identities.First().IdentityType);
            Assert.IsNotNull(parsedResponse.Identities.First().Uuid);
            Assert.IsTrue(parsedResponse.Memberships.Count > 0);
            Assert.IsNotNull(parsedResponse.Memberships.First().BusinessHandle);
            Assert.IsNotNull(parsedResponse.Memberships.First().EntityName);
            Assert.IsNotNull(parsedResponse.Memberships.First().Role);
            Assert.IsTrue(parsedResponse.Phones.Count > 0);
            Assert.IsNotNull(parsedResponse.Phones.First().AddedEpoch);
            Assert.IsNotNull(parsedResponse.Phones.First().Added);
            Assert.IsNotNull(parsedResponse.Phones.First().ModifiedEpoch);
            Assert.IsNotNull(parsedResponse.Phones.First().Modified);
            Assert.IsNotNull(parsedResponse.Phones.First().Phone);
            Assert.IsNotNull(parsedResponse.Phones.First().Uuid);
            Assert.IsNotNull(parsedResponse.UserHandle);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("2 - GetEntity - Failure when private key is blank")]
        public void Response403()
        {
            var response = api.GetEntity(
                DefaultConfig.SecondUser.UserHandle,
                ""
            );


            Assert.AreEqual(403, response.StatusCode);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.IsFalse(parsedResponse.Success);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }
    }
}
