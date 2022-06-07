using Sila.API.Client.Domain;
namespace Sila.API.Client.Webhooks
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWebhooksRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserHandle { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public WebhooksSearchFilters searchFilters { get; set; } = null;

    }
}