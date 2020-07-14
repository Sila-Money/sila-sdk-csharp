using System.Collections.Generic;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Object used in the GetBusinessTypes method
    /// </summary>
    public class BusinessTypesResponse
    {
        /// <summary>
        /// Get the success value of the method.
        /// </summary>
        /// <value>Success</value>
        public bool Success { get; }
        /// <summary>
        /// List of business types.
        /// </summary>
        /// <value>BusinessTypes</value>
        public List<BusinessType> BusinessTypes { get; }
    }
}