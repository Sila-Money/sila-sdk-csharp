// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using SilaAPI.silamoney.client.api;
// using SilaAPI.silamoney.client.domain;

// namespace SilaApiTest
// {
//     [TestClass]
//     public class Test016PlaidUpdateLinkToken
//     {
//         SilaApi api = DefaultConfig.Client;

//         [TestMethod("1 - Plaid update link token - Successful get plaid link token")]
//         public void T001Response200()
//         {
//             var user = DefaultConfig.FirstUser;

//             var response = api.PlaidUpdateLinkToken(
//                 accountName: "defaultpt",
//                 userHandle: user.UserHandle
//             );
//         }
//     }
// }
