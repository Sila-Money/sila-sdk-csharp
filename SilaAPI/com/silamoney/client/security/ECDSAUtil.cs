using Nethereum.Signer;

namespace SilaAPI.com.silamoney.client.security
{
    public class Signer
    {
        public static string sign(string message, string privateKey) {
            MessageSigner messageSigner = new MessageSigner();

            string sig = messageSigner.HashAndSign(message, privateKey);

            return sig.Substring(2);
        }
    }
}
