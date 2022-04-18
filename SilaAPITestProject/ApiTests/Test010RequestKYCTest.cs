using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test010_RequestKYCTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("4 - RequestKYC - Random user RequestKYC")]
        public void T004_Response200()
        {
            var user = DefaultConfig.FirstUser;

            var response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey);
            var parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);

            user = DefaultConfig.SecondUser;

            response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey);
            parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);
            
            user = DefaultConfig.ThirdUser;

            response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey);
            parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);

            user = DefaultConfig.FourthUser;

            response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey);
            parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);

            user = DefaultConfig.BusinessUser;

            response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey);
            parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);

            user = DefaultConfig.InstantUser;

            response = api.RequestKYC(userHandle: user.UserHandle, userPrivateKey: user.PrivateKey, kycLevel: "INSTANT-ACH");
            parsedResponse = (RequestKYCResponse) response.Data;

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.VerificationUuid);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
