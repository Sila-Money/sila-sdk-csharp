using Sila.API.Client.Domain;
namespace Sila.API.Client.GetWebhooks
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
        public string UserPrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public WebhooksSearchFilters searchFilters { get; set; } = null;

    }
}