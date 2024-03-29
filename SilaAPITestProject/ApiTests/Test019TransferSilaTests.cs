﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Threading;

namespace SilaApiTest
{
    [TestClass]
    public class Test019_TransferSilaTests
    {
        SilaApi api = DefaultConfig.Client;

        [TestMethod("1 - TransferSila - Successful transfer")]
        public void T001Response200EmptyWallet()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey);
            var parsedResponse = (TransferResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.DestinationAddress));
            DefaultConfig.InvalidTransferReference = parsedResponse.Reference;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }
        /*
         * Temporally removed due to issue on Sila's end
        [TestMethod("2 - TransferSila - Unsuccessful transfer from wallet with 0 balance")]
        [Timeout(300000)]
        public void T002Response200EmptyWallet()
        {
            var user = DefaultConfig.SecondUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.InvalidTransferReference
            };

            GetTransactionsTest.Poll(user.UserHandle, user.PrivateKey, filters, "failed");
        }
        */
        [TestMethod("3 - TransferSila - Successful transfer")]
        public void T003Response200Success()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey);
            var parsedResponse = (TransferResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.DestinationAddress));
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("5 - TransferSila - Successful transfer with wallet")]
        public void T005Response200Wallet()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            DefaultConfig.TransferReference = parsedResponse.Reference;
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("6 - TransferSila - Unsuccessful transfor to random handle")]
        public void T006Response200RandomWallet()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey, destinationWallet: new Random().Next().ToString());
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(403, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }

        [TestMethod("7 - TransferSila - Successful transfer with address")]
        public void T007Response200Address()
        {
            var user = DefaultConfig.FirstUser;
            var secondUser = DefaultConfig.SecondUser;
            var response = api.TransferSila(user.UserHandle, 100, secondUser.UserHandle, user.PrivateKey, destinationAddress: secondUser.CryptoAddress);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", ((BaseResponse)response.Data).Status);
            Assert.IsNotNull(((BaseResponse)response.Data).ResponseTimeMs);
        }

        [TestMethod("8 - TransferSila - Unsuccessful transfer to sender address")]
        public void T008Response200SameAddress()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, user.UserHandle, user.PrivateKey, destinationAddress: user.CryptoAddress);
            var parsedResponse = (BaseResponse)response.Data;

            Assert.AreEqual(403, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
        }

        [TestMethod("9 - TransferSila - Successful transfer tokens with business uuid and descriptor")]
        public void T009Response200Descriptor()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey, descriptor: DefaultConfig.TransferTrans, businessUuid: DefaultConfig.businessUuid);
            var parsedResponse = (TransferResponse)response.Data;
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("SUCCESS", parsedResponse.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.TransactionId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(parsedResponse.DestinationAddress));
            Assert.AreEqual(DefaultConfig.TransferTrans, parsedResponse.Descriptor);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("10 - TransferSila - Successful transfer received by wallet")]
        [Timeout(300000)]
        public void T010Response200Wallet()
        {
            var user = DefaultConfig.FirstUser;
            var filters = new SearchFilters()
            {
                ReferenceId = DefaultConfig.TransferReference
            };

            GetTransactionsTest.Poll(user.UserHandle, filters, "success");
        }

        [TestMethod("11 - TransferSila - Empty user handle failure")]
        public void T011Response400()
        {
            var response = api.TransferSila("", 100, DefaultConfig.SecondUser.UserHandle, DefaultConfig.FirstUser.PrivateKey);

            Assert.AreEqual(400, response.StatusCode);
        }

        [TestMethod("12 - TransferSila - Fail transfer tokens with invalid business uuid and descriptor")]
        public void T012Response400Descriptor()
        {
            var user = DefaultConfig.FirstUser;
            var response = api.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey, descriptor: DefaultConfig.TransferTrans, businessUuid: DefaultConfig.InvalidBusinessUuid);
            var parsedResponse = (BadRequestResponse)response.Data;
            Assert.AreEqual(400, response.StatusCode);
            Assert.AreEqual("FAILURE", parsedResponse.Status);
            Assert.IsNotNull(parsedResponse.ResponseTimeMs);
        }

        [TestMethod("13 - TransferSila - Bad user signature failure")]
        public void T013Response401User()
        {
            var response = api.TransferSila(DefaultConfig.FirstUser.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, DefaultConfig.privateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad user signature status - TransferSila");
        }

        [TestMethod("14 - TransferSila - Bad app signature failure")]
        public void T014Response401()
        {
            var user = DefaultConfig.FirstUser;
            var failApi = new SilaApi(DefaultConfig.environment,
                "3a1076bf45ab87712ad64ccb3b10217737f7faacbf2872e88fdd9a537d8fe266",
                DefaultConfig.appHandle);
            var response = failApi.TransferSila(user.UserHandle, 100, DefaultConfig.SecondUser.UserHandle, user.PrivateKey);

            Assert.AreEqual(401, response.StatusCode, "Bad app signature status - TransferSila");
        }
    }
}
