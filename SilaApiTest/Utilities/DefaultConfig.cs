﻿using SilaAPI.silamoney.client.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SilaAPI.silamoney.client.api.UserApi;

namespace SilaApiTest
{
    class DefaultConfig
    {
        public static string environment = Environments.LOCAL;
        public static string privateKey = "7D50ED14899B09193EA0D72328DF028FEACF5F28DB2BFCDC93544850A7DEECE9";
        public static string appHandle = "silaSDKTest.app.silamoney.eth";
        public static string userPrivateKey = "9C87D93E39297DA31565B2885BF5237CCF6595880E17765A1FD233D691E40E5D";
    }
}
