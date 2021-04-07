namespace SilaAPI.silamoney.client.refactored.api
{
    /// <summary>
    /// Available environments for the Sila Api
    /// </summary>
    public enum Environments
    {
        /// <summary>
        /// Using https://sandbox.silamoney.com/0.2 url
        /// </summary>
        SANDBOX,
        /// <summary>
        /// Using https://stageapi.silamoney.com/0.2 url.
        /// </summary>
        STAGING,
        /// <summary>
        /// Using https://api.silamoney.com/0.2 url.
        /// </summary>
        PRODUCTION
    }
}