﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    public partial class Header
    {
        /// <summary>
        /// EnumMember values for CryptoOption field
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Crypto
        {
            /// <summary>
            /// Value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1
        }
    }
}
