using Newtonsoft.Json;
namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountsMsg : BaseMessage
    {  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="appHandle"></param>
        public GetVirtualAccountsMsg(string userHandle, string appHandle)
        {
            Header = new Header(userHandle, appHandle);
        }
    }
}
