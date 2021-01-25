﻿using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using static SilaAPITestProject.Utilities.PlaidTokenHelper;

namespace SilaApiTest
{
    class DefaultConfig
    {
        public static string environment = "https://stageapi.silamoney.com/0.2";
        public static string privateKey = Environment.GetEnvironmentVariable("SILA_PRIVATE_KEY");
        public static string appHandle = "end2end.silamoney.eth";
        public static string businessUuid = "ec5d1366-b56c-4442-b6c3-c919d548fcb5";
        public static string InvalidBusinessUuid { get { return "6d933c10-fa89-41ab-b443-2e78a7cc8cac"; } }
        public static string IssueTrans { get { return "Issue Trans"; } }
        public static string TransferTrans { get { return "Transfer Trans"; } }
        public static string RedeemTrans { get { return "Redeem Trans"; } }
        public static string InvalidBusinessUuidRegex { get { return $"uuid {InvalidBusinessUuid} could not be found"; } }
        public static List<BusinessRole> BusinessRoles { get; set; }
        public static List<BusinessType> BusinessTypes { get; set; }
        public static List<DocumentType> DocumentTypes { get; set; }
        public static Dictionary<string, List<NaicsSubcategory>> NaicsCategories { get; set; }
        public static string CertificationToken { get; set; }

        private static UserConfiguration firstUser;
        private static UserConfiguration secondUser;
        private static UserConfiguration thirdUser;
        private static UserConfiguration fourthUser;
        private static UserConfiguration businessUser;
        private static UserConfiguration basicUser;
        private static UserConfiguration deviceUser;
        private static UserConfiguration basicBusiness;
        private static UserConfiguration instantUser;
        private static SilaApi client;

        public static SilaApi Client
        {
            get
            {
                if (client == null) client = new SilaApi(environment, privateKey, appHandle, true);
                return client;
            }
        }

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

        public static UserConfiguration BusinessUser
        {
            get
            {
                if (businessUser == null) businessUser = new UserConfiguration();
                return businessUser;
            }
        }

        public static UserConfiguration BasicUser
        {
            get
            {
                if (basicUser == null) basicUser = new UserConfiguration();
                return basicUser;
            }
        }

        public static UserConfiguration DeviceUser
        {
            get
            {
                if (deviceUser == null) deviceUser = new UserConfiguration();
                return deviceUser;
            }
        }

        public static UserConfiguration BasicBusiness
        {
            get
            {
                if (basicBusiness == null) basicBusiness = new UserConfiguration();
                return basicBusiness;
            }
        }

        public static UserConfiguration InstantUser
        {
            get
            {
                if (instantUser == null) instantUser = new UserConfiguration();
                return instantUser;
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

        public static string DocumentId { get; internal set; }
        public static string IdentityUuid { get; internal set; }
        public static string EmailUuid { get; internal set; }
        public static string PhoneUuid { get; internal set; }
        public static string AddressUuid { get; internal set; }

        public static BusinessRole BusinessRole(string name)
        {
            foreach (var businessRole in BusinessRoles)
            {
                if (businessRole.Name.Equals(name))
                {
                    return businessRole;
                }
            }
            return null;
        }
    }
}
