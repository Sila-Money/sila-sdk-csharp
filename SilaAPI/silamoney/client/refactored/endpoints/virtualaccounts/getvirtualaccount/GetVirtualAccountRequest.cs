﻿using Sila.API.Client.Domain;
namespace Sila.API.Client.VirtualAccounts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVirtualAccountRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VirtualAccountId { get; set; }

    }
}