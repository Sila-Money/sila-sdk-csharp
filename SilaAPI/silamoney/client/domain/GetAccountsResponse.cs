using Newtonsoft.Json;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.domain
{
    public class GetAccountsResponse
    {
        public string reference { get; set; }
        public string message { get; set; }
        public string status { get; set; }

        public List<Account> accounts {
            get {
                return JsonConvert.DeserializeObject<List<Account>>(message);
            }
        }
    }
}
