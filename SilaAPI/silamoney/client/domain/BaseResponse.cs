using System;
using System.Collections.Generic;
using System.Text;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to store response message.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// String field used in the BaseResponse object to save reference
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save message 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save status
        /// </summary>
        public string status { get; set; }
    }
}
