﻿using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using static SilaAPITestProject.Utilities.PlaidTokenHelper;

namespace SilaApiTest
{
    class DefaultConfig
    {
        public static string environment = Environments.SANDBOX;
        public static string privateKey = Environment.GetEnvironmentVariable("SILA_PRIVATE_KEY");
        public static string appHandle = "digital_geko_e2e.silamoney.eth";
        public static string businessUuid = "9f280665-629f-45bf-a694-133c86bffd5e";
        public static string InvalidBusinessUuid { get { return "6d933c10-fa89-41ab-b443-2e78a7cc8cac"; } }
        public static string IssueTrans { get { return "Issue Trans"; } }
        public static string TransferTrans { get { return "Transfer Trans"; } }
        public static string RedeemTrans { get { return "Redeem Trans"; } }
        public static string InvalidBusinessUuidRegex { get { return $"{InvalidBusinessUuid} does not have an approved ACH display name"; } }
        public static List<BusinessRole> BusinessRoles { get; set; }
        public static List<BusinessType> BusinessTypes { get; set; }
        public static List<DocumentType> DocumentTypes { get; set; }
        public static Dictionary<string, List<NaicsSubcategory>> NaicsCategories { get; set; }
        public static string CertificationToken {get;set;}

    private static UserConfiguration firstUser;
    private static UserConfiguration secondUser;
    private static UserConfiguration thirdUser;
    private static UserConfiguration fourthUser;
    private static UserConfiguration businessUser;

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
