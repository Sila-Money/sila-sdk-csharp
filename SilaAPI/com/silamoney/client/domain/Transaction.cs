using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.domain
{
    public class Transaction
    {
        public string userHandle { get; set; }
        public string referenceId { get; set; }
        public string transactionId { get; set; }
        public string transactionHash { get; set; }
        public string transactionType { get; set; }
        public float silaAmount { get; set; }
        public string bankAccountName { get; set; }
        public string handleAddress { get; set; }
        public string status { get; set; }
        public string usdStatus { get; set; }
        public string tokenStatus { get; set; }
        public string created { get; set; }
        public string lastUpdate { get; set; }
        public long createdEpoch { get; set; }
        public long lastUpdateEpoch { get; set; }
        public List<TimeLine> timeLines { get; set; }
    }
}
