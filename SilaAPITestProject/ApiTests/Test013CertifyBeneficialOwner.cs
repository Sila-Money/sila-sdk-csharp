using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;

namespace SilaApiTest
{
    [TestClass]
    public class Test013CertifyBeneficialOwner
    {
        SilaApi api = new SilaApi(DefaultConfig.environment, DefaultConfig.privateKey, DefaultConfig.appHandle);

        [TestMethod("1 - CertifyBeneficialOwner - Successful CertifyBeneficialOwner")]
        public void T026Response200()
        {
            var entity = api.GetEntity(
                DefaultConfig.ThirdUser.UserHandle,
                DefaultConfig.ThirdUser.PrivateKey
            );

            var parsedEntityResponse = (GetEntityResponse)entity.Data;

            foreach (var membership in parsedEntityResponse.Memberships)
            {
                Console.WriteLine(membership.Role);
                if (membership.Role.Equals("beneficial_owner"))
                {
                    Console.WriteLine(membership.Role);
                    DefaultConfig.CertificationToken = membership.CertificationToken;
                    break;
                }
            }

            var response = api.CertifyBeneficialOwner(
                DefaultConfig.FirstUser.UserHandle,
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                DefaultConfig.ThirdUser.UserHandle,
                DefaultConfig.CertificationToken
            );

            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("Beneficial owner successfully certified.", parsedResponse.Message);
        }
    }
}
