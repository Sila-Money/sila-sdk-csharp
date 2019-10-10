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
        public string Reference { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save message 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// String field used in the BaseResponse object to save status
        /// </summary>
        public string Status { get; set; }
    }
}
