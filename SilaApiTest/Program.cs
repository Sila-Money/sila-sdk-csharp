using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilaAPI.Api;
using SilaAPI.Model;

namespace SilaApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UserApi api = new UserApi("5C99813E8CF9EE2B4B5AC27DECFD26E6EB4EFB46C3AEE17D2181B9D2B5D9D6E0");
            Header header = new Header("ref", "gecko.app.silamoney.eth", "alejosApp.app.silamoney.eth");
            HeaderMsg headerMsg = new HeaderMsg(header);
            api.CheckHandle(headerMsg);
            Console.WriteLine(api.GetBasePath());
            Console.Read();
        }
    }
}
