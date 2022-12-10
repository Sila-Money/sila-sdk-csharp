namespace SilaApiTest {
    class UserConfiguration {
        public string UserHandle { get; }

        public string CryptoAddress { get; }

        public string PrivateKey { get; }

        public UserConfiguration() {
            UserHandle = "netSDK-" + System.Guid.NewGuid().ToString();            
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            CryptoAddress = ecKey.GetPublicAddress();
            PrivateKey = ecKey.GetPrivateKey();
        }
    }
}