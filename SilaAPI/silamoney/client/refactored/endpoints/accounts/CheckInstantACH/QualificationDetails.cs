﻿using Newtonsoft.Json;

namespace Sila.API.Client.Accounts
{
    /// <summary>
    /// get qualification details
    /// </summary>
    public class QualificationDetails
    {
        /// <summary>
        /// String field used in the BaseResponse object to save sms_opt_in
        /// </summary>
        [JsonProperty("sms_opt_in")]
        public string SmsOptIn { get; set; }
    }
}