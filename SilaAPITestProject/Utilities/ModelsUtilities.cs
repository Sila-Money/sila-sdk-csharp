﻿using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;

namespace SilaApiTest
{
    public static class ModelsUtilities
    {
        public static User CreateUser()
        {
            return new User("user.silamoney.eth", "Example", "User", "Example User", "123452222", "1234567890", "fake@email.com", "123 Main Street",
                "", "New City", "OR", "97204", "0x65a796a4bD3AaF6370791BefFb1A86EAcfdBc3C1", new DateTime(1990, 05, 19));
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
                TimeLines = CreateTimeLines()
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