using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.com.silamoney.client.domain
{
    public class TimeLine
    {
        public string date { get; set; }
        public long dateEpoch { get; set; }
        public string status { get; set; }
        public string usdStatus { get; set; }
        public string tokenStatus { get; set; }
    }
}
