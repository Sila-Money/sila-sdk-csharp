using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test034ApproveWireTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - IssueSila - Succesfully issue")]
        public void T00340IssueSilaResponse200Success()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 50000, user.PrivateKey, accountName: "defaultpt", descriptor: DefaultConfig.IssueTrans, businessUuid: DefaultConfig.WirebusinessUuid);
            var parsedResponse = (TransactionResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.AreEqual(DefaultConfig.IssueTrans, parsedResponse.Descriptor);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            int i = 0;
            do
            {
                SearchFilters _SearchFilters = new SearchFilters();
                SearchFilters.TransactionTypes[] _tTypes = { SearchFilters.TransactionTypes.Issue };
                _SearchFilters.SetTransactionTypes(_tTypes);
                ApiResponse<object> responseTransactions1 = api.GetTransactions(user.UserHandle, _SearchFilters);
                var parsedTransactionsResponse = (GetTransactionsResult)responseTransactions1.Data;
                if (parsedTransactionsResponse.Status == "SUCCESS")
                {
                    var responseBalance = api.GetSilaBalance(user.CryptoAddress);
                    Assert.AreEqual(200, responseBalance.StatusCode);
                    var parsedBalanceResponse = (GetSilaBalanceResponse)responseBalance.Data;
                    if (parsedBalanceResponse.SilaBalance >= 1000)
                    {
                        break;
                    }
                }
                Thread.Sleep(30000);
                i++;
            }
            while (i <= 8);
        }

        [TestMethod("2 - RedeemSila - Successful redeem for user")]
        public void T00341RedeemSilaResponse200Success()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "defaultpt", businessUuid: DefaultConfig.WirebusinessUuid, processingType: ProcessingType.Wire);
            var parsedResponse = (TransactionResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            DefaultConfig.RedeemReference = parsedResponse.Reference;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            DefaultConfig.TransactionId = parsedResponse.TransactionId;
        }

        [TestMethod("3 - GetTransactions - Successfully transactions")]
        public void T00342Response200GetTransactions()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetTransactions(
                userHandle: user.UserHandle,
                searchFilters: new SearchFilters
                {
                    ProcessingType = ProcessingType.Wire,
                    ShowTimelines = true,
                    Page = 1,
                    PerPage = 20
                }
            );

            var parsedResponse = (GetTransactionsResult)response.Data;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
        }

        [TestMethod("4 - MockWireOutFile - Successful MockWireOutFile")]
        public void T00343Response200MockWireOutFile()
        {
            var user = DefaultConfig.FirstUser;

            var responseRedeemSila = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "defaultpt", businessUuid: DefaultConfig.businessUuid, processingType: ProcessingType.Wire);
            var parsedResponseRedeemSila = (TransactionResponse)responseRedeemSila.Data;
            Thread.Sleep(30000);
            var responseMockWireOutFile = api.MockWireOutFile(user.UserHandle, user.PrivateKey, parsedResponseRedeemSila.TransactionId, "PR");
            var parsedResponseMockWireOutFile = (MockWireOutFileResponse)responseMockWireOutFile.Data;

            Assert.AreEqual("SUCCESS", parsedResponseMockWireOutFile.Status);
            Assert.IsTrue(parsedResponseMockWireOutFile.Success);
            Assert.IsNotNull(parsedResponseMockWireOutFile.Message);
            Assert.IsNotNull(parsedResponseMockWireOutFile.Reference);
            Assert.IsNotNull(parsedResponseMockWireOutFile.ResponseTimeMs);
        }

        [TestMethod("5 - ApproveWire - Successful ApproveWire")]
        public void T00344Response200ApproveWire()
        {
            var user = DefaultConfig.FirstUser;
            var responseRedeemSila = api.RedeemSila(user.UserHandle, 11000, user.PrivateKey, accountName: "defaultpt", businessUuid: DefaultConfig.WirebusinessUuid, processingType: ProcessingType.Wire, mockWireAccountName: "mock_account_success");
            var parsedResponseRedeemSila = (TransactionResponse)responseRedeemSila.Data;
            Thread.Sleep(30000);
            var responseApproveWire = api.ApproveWire(user.UserHandle, user.PrivateKey, parsedResponseRedeemSila.TransactionId, true, mockWireAccountName: "mock_account_success");
            var parsedResponseApproveWire = (BaseResponse)responseApproveWire.Data;

            Assert.AreEqual("SUCCESS", parsedResponseApproveWire.Status);
            Assert.IsTrue(parsedResponseApproveWire.Success);
            Assert.IsNotNull(parsedResponseApproveWire.Message);
            Assert.IsNotNull(parsedResponseApproveWire.Reference);
            Assert.IsNotNull(parsedResponseApproveWire.ResponseTimeMs);
        }

        [TestMethod("6 - Deny ApproveWire - Successful Deny ApproveWire")]
        public void T00345Response200ApproveWireDeny()
        {
            var user = DefaultConfig.FirstUser;
            var responseRedeemSila = api.RedeemSila(user.UserHandle, 11000, user.PrivateKey, accountName: "defaultpt", businessUuid: DefaultConfig.WirebusinessUuid, processingType: ProcessingType.Wire, mockWireAccountName: "mock_account_fail");
            var parsedResponseRedeemSila = (TransactionResponse)responseRedeemSila.Data;
            Thread.Sleep(30000);
            var responseApproveWire = api.ApproveWire(user.UserHandle, user.PrivateKey, parsedResponseRedeemSila.TransactionId, false, "My reason to deny wire", mockWireAccountName: "mock_account_fail");
            var parsedResponseApproveWire = (BaseResponse)responseApproveWire.Data;

            Assert.AreEqual("SUCCESS", parsedResponseApproveWire.Status);
            Assert.IsTrue(parsedResponseApproveWire.Success);
            Assert.IsNotNull(parsedResponseApproveWire.Message);
            Assert.IsNotNull(parsedResponseApproveWire.Reference);
            Assert.IsNotNull(parsedResponseApproveWire.ResponseTimeMs);
        }
    }
}

