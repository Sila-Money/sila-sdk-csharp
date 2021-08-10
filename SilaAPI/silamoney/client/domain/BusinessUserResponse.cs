using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    ///  Object used in the Register method for BusinessUser
    /// </summary>   
    public class BusinessUserResponse : BaseResponseWithoutReference
    {
        /// <summary>
        ///  String field used in the BusinessUserResponse object to save BusinessUuid
        /// </summary>
        /// <value>BusinessUuid</value>
        [JsonProperty("business_uuid")]
        public string BusinessUuid { get; set; }
    }
}
