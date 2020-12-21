using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SilaApiTest
{
    public static class ModelsUtilities
    {
        public static User firstUser;
        public static User FirstUser
        {
            get
            {
                if (firstUser == null) firstUser = CreateUser(DefaultConfig.FirstUser.UserHandle, "First", "User", DefaultConfig.FirstUser.CryptoAddress);
                return firstUser;
            }
        }

        public static User secondUser;
        public static User SecondUser
        {
            get
            {
                if (secondUser == null) secondUser = CreateUser(DefaultConfig.SecondUser.UserHandle, "Second", "User", DefaultConfig.SecondUser.CryptoAddress);
                return secondUser;
            }
        }

        public static User thirdUser;
        public static User ThirdUser
        {
            get
            {
                if (thirdUser == null) thirdUser = CreateUser(DefaultConfig.ThirdUser.UserHandle, "Fail", "User", DefaultConfig.ThirdUser.CryptoAddress);
                return thirdUser;
            }
        }

        public static User fourthUser;

        public static User FourthUser
        {
            get
            {
                if (fourthUser == null) fourthUser = CreateUser(DefaultConfig.FourthUser.UserHandle, "Fourth", "User", DefaultConfig.FourthUser.CryptoAddress);
                return fourthUser;
            }
        }

        public static BusinessUser businessUser;

        public static BusinessUser BusinessUser
        {
            get
            {
                if (businessUser == null) businessUser = CreateBusinessUser(DefaultConfig.BusinessUser.UserHandle, "Business User", DefaultConfig.BusinessUser.CryptoAddress, DefaultConfig.BusinessTypes.First(), DefaultConfig.NaicsCategories.First().Value.First());
                return businessUser;
            }
        }

        private static User basicUser;

        public static User BasicUser
        {
            get
            {
                if (basicUser == null) basicUser = new User
                {
                    UserHandle = DefaultConfig.BasicUser.UserHandle,
                    FirstName = "Basic",
                    LastName = "Last",
                    CryptoAddress = DefaultConfig.BasicUser.CryptoAddress
                };
                return basicUser;
            }
        }

        private static User deviceUser;

        public static User DeviceUser
        {
            get
            {
                if (deviceUser == null) deviceUser = new User
                {
                    UserHandle = DefaultConfig.DeviceUser.UserHandle,
                    FirstName = "Device",
                    LastName = "User",
                    CryptoAddress = DefaultConfig.DeviceUser.CryptoAddress,
                    DeviceFingerprint = "test_instant_ach"
                };
                return deviceUser;
            }
        }
        
        private static BusinessUser basicBusiness;

        public static BusinessUser BasicBusiness
        {
            get
            {
                if (basicBusiness == null) basicBusiness = new BusinessUser
                {
                    UserHandle = DefaultConfig.BasicBusiness.UserHandle,
                    EntityName = "Basic Business",
                    CryptoAddress = DefaultConfig.BasicBusiness.CryptoAddress,
                    Type = "business",
                    BusinessTypeUuid = DefaultConfig.BusinessTypes.First().Uuid,
                    NaicsCode = DefaultConfig.NaicsCategories.First().Value.First().Code
                };
                return basicBusiness;
            }
        }

        public static User CreateUser(string handle, string firstName, string lastName, string cryptoAddress)
        {
            return new User(handle, firstName, lastName, $"{firstName} {lastName}", "123452222", "1234567890", "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", cryptoAddress, new DateTime(1990, 05, 19));
        }

        public static BusinessUser CreateBusinessUser(string handle, string entityName, string cryptoAddress, BusinessType businessType, NaicsSubcategory naicsSubcategory)
        {
            return new BusinessUser(handle, entityName, "123452222", "1234567890", "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", cryptoAddress, businessType, "https://www.businesswebsite.com", "test doing business as", naicsSubcategory.Code);
        }

        public static GetTransactionsResult CreateTransactionResult()
        {
            GetTransactionsResult responseMessage = new GetTransactionsResult
            {
                Success = true,
                Page = 1,
                ReturnedCount = 1,
                TotalCount = 1,
                Transactions = CreateTransactions()
            };

            return responseMessage;
        }

        private static List<Transaction> CreateTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = new Transaction
            {
                UserHandle = "user.silamoney.eth",
                ReferenceId = "ref",
                TransactionHash = "0x1234567890abcdef1234567890abcdef",
                TransactionType = "issue",
                SilaAmount = 1000,
                BankAccountName = "default",
                HandleAddress = "0x65a796a4bD3AaF6370791BefFb1A86EAcfdBc3C1",
                Status = "success",
                UsdStatus = "success",
                TokenStatus = "success",
                Created = "2019-04-03T00:00:00.000Z",
                LastUpdate = "2019-04-03T00:00:00.003Z",
                CreatedEpoch = 1234567890,
                LastUpdateEpoch = 1234567899,
                TimeLine = CreateTimeLines()
            };

            transactions.Add(transaction);

            return transactions;
        }

        private static List<TimeLine> CreateTimeLines()
        {
            List<TimeLine> TimeLines = new List<TimeLine>();
            TimeLine timeLine = new TimeLine
            {
                Date = "2019-04-03T00:00:00.000Z",
                DateEpoch = 1234567890,
                Status = "queued",
                UsdStatus = "not started",
                TokenStatus = "not started"
            };

            TimeLines.Add(timeLine);

            return TimeLines;
        }

        internal static List<Account> CreateGetAccountsResult()
        {
            List<Account> accounts = new List<Account>();
            Account account = new Account
            {
                AccountName = "default",
                AccountNumber = "1234",
                AccountStatus = "active",
                AccountType = "CHEKING"
            };

            accounts.Add(account);

            return accounts;
        }

        internal static BaseResponse CreateResponse(string reference, string message, string Status)
        {
            BaseResponse response = new BaseResponse
            {
                Message = message,
                Reference = reference,
                Status = Status
            };

            return response;
        }

        internal static GetTransactionsResponse CreateResponse(string reference, GetTransactionsResult message, string Status)
        {
            GetTransactionsResponse response = new GetTransactionsResponse
            {
                Message = message,
                Reference = reference,
                Status = Status
            };

            return response;
        }
    }
}
