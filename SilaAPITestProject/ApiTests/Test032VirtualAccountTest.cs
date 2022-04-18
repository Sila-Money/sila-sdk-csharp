using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test032VirtualAccountTest
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - OpenVirtualAccount - Successfully create of VirtualAccount")]
        public void T001OpenVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            string virtualAccountName = "virtualaccount";
            var response = api.OpenVirtualAccount(user.UserHandle, user.PrivateKey, virtualAccountName);
            var parsedResponse = (VirtualAccountResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.VirtualAccount);

            user = DefaultConfig.SecondUser;
            response = api.OpenVirtualAccount(user.UserHandle, user.PrivateKey, virtualAccountName);
            parsedResponse = (VirtualAccountResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.VirtualAccount);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);

        }

        [TestMethod("2 - GetVirtualAccounts - Successfully retrieve of VirtualAccounts")]
        public void T002GetVirtualAccounts()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetVirtualAccounts(user.UserHandle, user.PrivateKey);
            var parsedResponse = (GetVirtualAccountsResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Pagination);
            Assert.IsNotNull(parsedResponse.VirtualAccounts);
            DefaultConfig.VirtualAccountId = parsedResponse.VirtualAccounts[0].VirtualAccountId;
            DefaultConfig.AccountNumber = parsedResponse.VirtualAccounts[0].AccountNumber;

            user = DefaultConfig.SecondUser;
            response = api.GetVirtualAccounts(user.UserHandle, user.PrivateKey);
            parsedResponse = (GetVirtualAccountsResponse)response.Data;
            DefaultConfig.VirtualAccountDisId = parsedResponse.VirtualAccounts[0].VirtualAccountId;
            DefaultConfig.AccountNumberDis = parsedResponse.VirtualAccounts[0].AccountNumber;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("3 - IssueSila - Successfully issue of VirtualAccount")]
        public void T003IssueSilaVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.IssueSila(user.UserHandle, 200, user.PrivateKey, accountName: "defaultpt",
                descriptor: DefaultConfig.IssueTrans, businessUuid: DefaultConfig.businessUuid, destinationId: DefaultConfig.VirtualAccountId);
            Thread.Sleep(30000);
            var parsedResponse = (TransactionResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Descriptor);
            Assert.IsNotNull(parsedResponse.TransactionId);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("4 - GetVirtualAccount - Successfully retrieve of VirtualAccount")]
        public void T004GetVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.GetVirtualAccount(user.UserHandle, user.PrivateKey, DefaultConfig.VirtualAccountId);
            var parsedResponse = (GetVirtualAccountResponse)response.Data;
            int i = 0;
            do
            {
                if (parsedResponse.Balance.AvailableSilaBalance <= 0)
                {
                    Thread.Sleep(30000);
                    response = api.GetVirtualAccount(user.UserHandle, user.PrivateKey, DefaultConfig.VirtualAccountId);
                    parsedResponse = (GetVirtualAccountResponse)response.Data;
                    if (parsedResponse.Balance.AvailableSilaBalance > 0)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                Thread.Sleep(30000);
                i++;
            }
            while (i <= 8);

            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Balance);
            Assert.IsNotNull(parsedResponse.VirtualAccount);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("5 - RedeemSila - Successfully redeem of VirtualAccount")]
        public void T005RedeemSilaVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.RedeemSila(user.UserHandle, 100, user.PrivateKey, accountName: "defaultpt", descriptor: DefaultConfig.RedeemTrans,
               businessUuid: DefaultConfig.businessUuid, sourceId: DefaultConfig.VirtualAccountId);

            var parsedResponse = (TransactionResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Descriptor);
            Assert.IsNotNull(parsedResponse.TransactionId);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("6 - TransferSila - Successfully transfer of VirtualAccount")]
        public void T006TransferSilaVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            var secondUser = DefaultConfig.SecondUser;
            var response = api.TransferSila(user.UserHandle, 100, secondUser.UserHandle, user.PrivateKey, descriptor: DefaultConfig.TransferTrans,
               sourceId: DefaultConfig.VirtualAccountId, destinationId: DefaultConfig.VirtualAccountDisId);

            var parsedResponse = (TransferResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.Descriptor);
            Assert.IsNotNull(parsedResponse.TransactionId);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("7 - GetTransactions - Successfully retrieve timeline of transactions")]
        public void T007GetTransactionsWithTimeline()
        {
            var response = api.GetTransactions(
                userHandle: DefaultConfig.FirstUser.UserHandle,
                searchFilters: new SearchFilters
                {
                    SourceId = DefaultConfig.VirtualAccountId
                }
            );

            var parsedResponse = (GetTransactionsResult)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsTrue(parsedResponse.Transactions.Count > 0);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("8 - UpdateVirtualAccount - Successfully update of VirtualAccount")]
        public void T008UpdateVirtualAccount()
        {
            var user = DefaultConfig.FirstUser;
            string virtualAccountId = DefaultConfig.VirtualAccountId;
            string virtualAccountName = "virtualaccount";
            bool? isActive = false;

            var response = api.UpdateVirtualAccount(user.UserHandle, user.PrivateKey, virtualAccountId, virtualAccountName, isActive);
            var parsedResponse = (VirtualAccountResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.VirtualAccount);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("9 - CloseVirtualAccount - Successfully Close of VirtualAccount")]
        public void T009CloseVirtualAccount()
        {
            string virtualAccountId = DefaultConfig.VirtualAccountId;
            string accountNumber = DefaultConfig.AccountNumber;
            var user = DefaultConfig.FirstUser;
            var response = api.CloseVirtualAccount(user.UserHandle, user.PrivateKey, virtualAccountId, accountNumber);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("10 - CreateTestVirtualAccountAchTransaction - Successfully create of test VirtualAccountAchTransaction")]
        public void T10CreateTestVirtualAccountAchTransaction()
        {
            var user = DefaultConfig.SecondUser;
            string userHandle = user.UserHandle;
            string userPrivateKey = user.PrivateKey;
            int amount = 100;
            string virtualAccountNumber = DefaultConfig.AccountNumberDis;
            int tranCode = 22;
            string entityName = ModelsUtilities.SecondUser.EntityName;
            DateTime? effectiveDate = null;
            string ced = "PAYROLL";
            string achName = "SILA INC";
            var response = api.CreateTestVirtualAccountAchTransaction(userHandle, userPrivateKey, amount, virtualAccountNumber, tranCode, entityName, effectiveDate, ced, achName);
            var parsedResponse = (BaseResponse)response.Data;
            Assert.IsTrue(parsedResponse.Success);
            Assert.IsNotNull(parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.Message);
            Assert.IsNotNull(parsedResponse.Reference);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
    }
}
