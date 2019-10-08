using System.IO;
namespace SilaAPI.com.silamoney.client.domain
{
    public partial class HeaderMsg : BaseMessage
    {
        public HeaderMsg(string handle, string authHandle)
        {
            this.header = new Header(handle, authHandle);
            this.message = MessageEnum.HeaderMsg;
        }
    }
}
