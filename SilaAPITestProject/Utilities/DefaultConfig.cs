using SilaAPI.silamoney.client.api;
using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using static SilaAPITestProject.Utilities.PlaidTokenHelper;

namespace SilaApiTest
{
    class DefaultConfig
    {
        //SANDBOX
        public static string environment = "https://sandbox.silamoney.com/0.2";
        public static string privateKey = "e60a5c57130f4e82782cbdb498943f31fe8f92ab96daac2cc13cbbbf9c0b4d9e";
        public static string appHandle = "digital_geko_e2e.silamoney.eth";
        public static string businessUuid = "9f280665-629f-45bf-a694-133c86bffd5e";

        //STAGING       
        //public static string environment = "https://stageapi.silamoney.com/0.2";
        //public static string privateKey = "197f4d0f41fa98a67b2bdcf931b3076e64005264b59f3d5c1658a6a9aba7e471";
        //public static string appHandle = "arcgate_stage_app01";
        //public static string businessUuid = "dbe721f6-1140-41e3-bdc4-baa632b37405";

        ////DEVELOPERMENT       
        //public static string environment = "https://stageapi.silamoney.com/0.2";
        //public static string privateKey = "b141233286d93618db64788a88017e1b901f3c084a047d8e3efbbbea5dd4a873";
        //public static string appHandle = "test_limit_stage_111";
        //public static string businessUuid = "dbe721f6-1140-41e3-bdc4-baa632b37405";

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

        public static string TransactionId { get; set; }        

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
