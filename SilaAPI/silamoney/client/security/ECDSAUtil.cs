using Nethereum.Signer;

namespace SilaAPI.silamoney.client.security
{
    /// <summary>
    /// Class used to hash and sign the SilaApi requests.
    /// </summary>
    public class Signer
    {
        /// <summary>
        /// Method used to get message signature.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="privateKey"></param>
        /// <returns>Signature</returns>
        public static string sign(string message, string privateKey)
        {
            MessageSigner messageSigner = new MessageSigner();

            string sig = messageSigner.HashAndSign(message, privateKey);

            return sig.Substring(2);
        }
    }
}
