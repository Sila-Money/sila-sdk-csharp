using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.domain
{
    public class GetTransactionsResult
    {
        public bool success { get; set; }
        public int page { get; set; }
        public int returnedCount { get; set; }
        public int totalCount { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
