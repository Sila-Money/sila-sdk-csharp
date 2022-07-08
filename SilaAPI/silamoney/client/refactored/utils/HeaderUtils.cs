using Sila.API.Client.security;
using System.Collections.Generic;

namespace Sila.API.Client.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class HeaderUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Dictionary<string, string> SetAuthSignature(Dictionary<string, string> headers, string body)
        {
            headers.Add("authsignature", Signer.Sign(body, SilaAPI.GetInstance().PrivateKey));
            return headers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="body"></param>
        /// <param name="userPrivateKey"></param>
        /// <returns></returns>
        public static Dictionary<string, string> SetUserSignature(Dictionary<string, string> headers, string body, string userPrivateKey)
        {
            headers.Add("usersignature", Signer.Sign(body, userPrivateKey));
            return headers;
        }
    }
}