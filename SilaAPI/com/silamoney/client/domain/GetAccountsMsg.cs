using System.IO;

namespace SilaAPI.com.silamoney.client.domain
{
    public partial class GetAccountsMsg : BaseMessage
    {
        public GetAccountsMsg(string userHandle, string authHandle)
        {
            this.header = new Header(userHandle, authHandle);
            this.message = MessageEnum.GetAccountsMsg;
        }
    }
}
