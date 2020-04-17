﻿using SilaAPI.silamoney.client.domain;
using System;
using static SilaAPITestProject.Utilities.PlaidTokenHelper;

namespace SilaApiTest
{
    class DefaultConfig
    {
        public static string environment = Environments.SANDBOX;
        public static string privateKey = Environment.GetEnvironmentVariable("SILA_PRIVATE_KEY");
        public static string appHandle = "digital_geko_e2e.silamoney.eth";

        private static UserConfiguration firstUser;
        private static UserConfiguration secondUser;
        private static UserConfiguration thirdUser;
        private static UserConfiguration fourthUser;

        public static UserConfiguration FirstUser
        {
            get
            {
                if (firstUser == null) firstUser = new UserConfiguration();
                return firstUser;
            }
        }

        public static UserConfiguration SecondUser
        {
            get
            {
                if (secondUser == null) secondUser = new UserConfiguration();
                return secondUser;
            }
        }

        public static UserConfiguration ThirdUser
        {
            get
            {
                if (thirdUser == null) thirdUser = new UserConfiguration();
                return thirdUser;
            }
        }

        public static UserConfiguration FourthUser
        {
            get
            {
                if (fourthUser == null) fourthUser = new UserConfiguration();
                return fourthUser;
            }
        }

        public static PlaidConfiguration PlaidToken
        {
            get
            {
                return getPlaidToken();
            }
        }

        private static UserWallet wallet;

        public static UserWallet Wallet
        {
            get
            {
                if (wallet == null) wallet = new UserWallet();
                return wallet;
            }
        }

        public static string IssueReference { get; set; }

        public static string TransferReference { get; set; }

        public static string InvalidTransferReference { get; set; }

        public static string RedeemReference { get; set; }

        public static string InvalidRedeemReference { get; set; }

        private static string _randomCryptoAddress;
        public static string randomCryptoAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_randomCryptoAddress))
                {
                    var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                    _randomCryptoAddress = ecKey.GetPublicAddress();
                }
                return _randomCryptoAddress;
            }
            set
            {
                _randomCryptoAddress = value;
            }
        }
    }
}
