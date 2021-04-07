using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.refactored.api;
using SilaAPI.silamoney.client.refactored.endpoints.entities.requestkyc;

namespace SilaApiTest
{
    [TestClass]
    public class Test010_RequestKYCTest
    {
        [TestInitialize]
        public void TestInitialize() {
            SilaApi.Init(Environments.SANDBOX, "digital_geko_e2e", "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e");
        }

        [TestMethod("4 - RequestKYC - Random user RequestKYC")]
        public void T004_Response200()
        {
            var user = DefaultConfig.FirstUser;

            RequestKycRequest request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            RequestKycResponse response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);

            user = DefaultConfig.SecondUser;

            request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);
            
            user = DefaultConfig.ThirdUser;

            request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);

            user = DefaultConfig.FourthUser;

            request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);

            user = DefaultConfig.BusinessUser;

            request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey
            };

            response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);

            user = DefaultConfig.InstantUser;

            request = new RequestKycRequest{
                UserHandle = user.UserHandle,
                UserPrivateKey = user.PrivateKey,
                KycLevel = "INSTANT-ACH"
            };

            response = RequestKyc.Send(request);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Message);
            Assert.IsNotNull(response.Reference);
            Assert.IsNotNull(response.Status);
            Assert.IsNotNull(response.VerificationUuid);
        }
    }
}
