using Sila.API.Client.Domain;
namespace Sila.API.Client.RetryWebhook
{
    /// <summary>
    /// 
    /// </summary>
    public class RetryWebhookRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string EventUuid { get; set; }

    }
}