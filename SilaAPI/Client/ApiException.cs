using System;

namespace SilaAPI.Client
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; set; }
        public dynamic ErrorContent { get; private set; }

        public ApiException(int errorCode, string message, dynamic errorContent = null) : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorContent = errorContent;
        }
    }

}
