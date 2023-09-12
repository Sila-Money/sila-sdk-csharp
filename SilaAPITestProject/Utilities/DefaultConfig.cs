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
        public static string privateKey = "9c17e7b767b8f4a63863caf1619ef3e9967a34b287ce58542f3eb19b5a72f076";
        public static string appHandle = "arc_sandbox_test_app01.silamoney.eth";
        public static string businessUuid = "9f280665-629f-45bf-a694-133c86bffd5e";
        public static string WirebusinessUuid = "25e77968-1ca3-4a4b-8e72-506dcac20dc7";

        ////Wire       
        //public static string environment = "https://sandbox.silamoney.com/0.2";
        //public static string privateKey = "7713b1360ea1620a88d3d83ee25d18955d05258e86befaf5ee452d98f6e45eb7";
        //public static string appHandle = "test_wires_stage001";
        //public static string businessUuid = "ad1a71cf-9313-48d8-9ba9-78fdbf33f140";

        //STAGING
        //public static string environment = "https://sandbox.silamoney.com/0.2";
        //public static string privateKey = "1b84b246caa5aba7f46fec324962e2824e1cf2c7bf18db4c74ca5b9de2192465";
        //public static string appHandle = "arc_sandbox_wires_app_001";
        //public static string businessUuid = "69fabe4e-994c-4229-a873-41d36240b76d";

        //STAGING
        //public static string environment = "https://stageapi.silamoney.com/0.2";
        //public static string privateKey = "197f4d0f41fa98a67b2bdcf931b3076e64005264b59f3d5c1658a6a9aba7e471";
        //public static string appHandle = "arcgate_stage_app01";
        //public static string businessUuid = "dbe721f6-1140-41e3-bdc4-baa632b37405";

        //STAGINGMX
        //public static string environment = "https://stageapi.silamoney.com/0.2";
        //public static string privateKey = "669761bcd34f90a7347a5cbf6bdc47f41068cc5896f7634ea8e76337f3e5a9f7";
        //public static string appHandle = "mx_stage_app_001";
        //public static string businessUuid = "ad1a71cf-9313-48d8-9ba9-78fdbf33f140"; 


        //DEVELOPERMENT       
        //public static string environment = "https://stageapi.silamoney.com/0.2";
        //public static string privateKey = "b141233286d93618db64788a88017e1b901f3c084a047d8e3efbbbea5dd4a873";
        //public static string appHandle = "test_limit_stage_111";
        //public static string businessUuid = "dbe721f6-1140-41e3-bdc4-baa632b37405";

        ////instant settlement       
        //public static string environment = "https://sandbox.silamoney.com/0.2";
        //public static string privateKey = "eaf42ff2c0016fcb0a996d0ce1e692559e19b38f58056a87492683cdf6e9a7cc";
        //public static string appHandle = "is_sandbox_test_app004";
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
        private static UserConfiguration fifthUser;
        private static UserConfiguration businessUser;
        private static UserConfiguration basicUser;
        private static UserConfiguration deviceUser;
        private static UserConfiguration basicBusiness;
        private static UserConfiguration instantUser;
        private static UserConfiguration ckoUser;
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

        public static UserConfiguration FifthUser
        {
            get
            {
                if (fifthUser == null) fifthUser = new UserConfiguration();
                return fifthUser;
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

        public static UserConfiguration CKOUser
        {
            get
            {
                if (ckoUser == null) ckoUser = new UserConfiguration();
                return ckoUser;
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
        public static string VirtualAccountId { get; internal set; }
        public static string AccountNumberDis { get; internal set; }
        public static string AccountNumber { get; internal set; }
        public static string VirtualAccountDisId { get; internal set; }
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
