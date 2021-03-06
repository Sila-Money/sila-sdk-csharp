using System.Collections.Generic;

using SilaAPI.silamoney.client.security;

namespace Sila.API.Client.Utils
{
    public static class HeaderUtils
    {
        public static Dictionary<string, string> SetAuthSignature(Dictionary<string, string> headers, string body)
        {
            headers.Add("authsignature", Signer.Sign(body, SilaAPI.GetInstance().PrivateKey));
            return headers;
        }
        public static Dictionary<string, string> SetUserSignature(Dictionary<string, string> headers, string body, string userPrivateKey)
        {
            headers.Add("usersignature", Signer.Sign(body, userPrivateKey));
            return headers;
        }
    }
}