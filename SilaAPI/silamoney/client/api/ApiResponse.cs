using SilaAPI.silamoney.client.domain;
using System.Collections.Generic;

namespace SilaAPI.silamoney.client.api
{
    /// <summary>
    /// Object used to return the response from api server
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Response status code
        /// </summary>
        public int StatusCode { get; private set; }
        /// <summary>
        /// Response headers
        /// </summary>
        public IDictionary<string, string> Headers { get; private set; }
        /// <summary>
        /// Response data, this receive the message sent from the api server
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// ApiResponse constructor
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="headers"></param>
        /// <param name="data"></param>
        public ApiResponse(int statusCode, IDictionary<string, string> headers, T data)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.Data = data;
        }

    }

}
