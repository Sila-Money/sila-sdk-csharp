using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    public static class Environments
    {
        private static string _sandbox = "https://sandbox.silamoney.com/0.2";
        public static string SANDBOX { get => _sandbox;}

        private static string _production = "https://sandbox.silamoney.com/0.2";
        public static string PRODUCTION { get => _production; }

        private static string _local = "http://localhost:8080";
        public static string LOCAL { get => _local; }
    }
}
