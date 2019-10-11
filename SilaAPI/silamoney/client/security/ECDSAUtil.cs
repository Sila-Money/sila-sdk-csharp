using Nethereum.Signer;

namespace SilaAPI.silamoney.client.security
{
    /// <summary>
    /// Class used to hash and sign the SilaApi requests.
    /// </summary>
    public static class Signer
    {
        /// <summary>
        /// Method used to get message signature.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="privateKey"></param>
        /// <returns>Signature</returns>
        public static string Sign(string message, string privateKey)
        {
            MessageSigner messageSigner = new MessageSigner();

            string sig = messageSigner.HashAndSign(message, privateKey);

            return sig.Substring(2);
        }
    }
}
