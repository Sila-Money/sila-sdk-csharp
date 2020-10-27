using Nethereum.Signer;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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

        /// <summary>
        /// Hashes a file with SHA256 algorithm
        /// </summary>
        /// <param name="file">The filestream of the file</param>
        /// <returns></returns>
        public static string HashFile(FileStream file)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(file);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
