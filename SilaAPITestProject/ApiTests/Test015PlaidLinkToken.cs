// using System.Linq;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using SilaAPI.silamoney.client.api;
// using SilaAPI.silamoney.client.domain;

// namespace SilaApiTest
// {
//     [TestClass]
//     public class Test015PlaidLinkToken
//     {
//         SilaApi api = DefaultConfig.Client;

//         [TestMethod("1 - Plaid link token - Successful get plaid link token")]
//         public void T020Response200()
//         {
//             var user = DefaultConfig.FirstUser;
//             var response = api.PlaidLinkToken(user.UserHandle, user.PrivateKey);
//             var parsedResponse = (PlaidLinkTokenResult)response.Data;

//             Assert.AreEqual(200, response.StatusCode);
//             Assert.IsNotNull(parsedResponse.LinkToken);
//             Assert.IsNotNull(parsedResponse.Message);
//             Assert.IsNotNull(parsedResponse.Status);
//             Assert.IsTrue(parsedResponse.Success);
//             Assert.IsNotNull(parsedResponse.ResponseTimeMs);
//         }
//     }
// }
