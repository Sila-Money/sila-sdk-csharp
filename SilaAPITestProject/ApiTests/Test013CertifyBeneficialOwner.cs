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
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.SecondUser.PrivateKey
            );

            var parsedEntityResponse = (GetEntityResponse)entity.Data;

            foreach (var membership in parsedEntityResponse.Memberships)
            {
                if (membership.Role.Equals("beneficial_owner"))
                {
                    DefaultConfig.CertificationToken = membership.CertificationToken;
                    break;
                }
            }

            var response = api.CertifyBeneficialOwner(
                DefaultConfig.FirstUser.UserHandle,
                DefaultConfig.FirstUser.PrivateKey,
                DefaultConfig.BusinessUser.UserHandle,
                DefaultConfig.BusinessUser.PrivateKey,
                DefaultConfig.SecondUser.UserHandle,
                DefaultConfig.CertificationToken
            );

            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("Beneficial owner successfully certified.", parsedResponse.Message);
        }
    }
}
