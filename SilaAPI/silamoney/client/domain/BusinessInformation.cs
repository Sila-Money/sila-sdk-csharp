namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Object used to display uuid, name and label in different response objects
    /// </summary>
    public class BusinessInformation
    {
        /// <summary>
        /// Uuid of business information
        /// </summary>
        /// <value>uuid</value>
        public string uuid { get; }
        /// <summary>
        /// Name of business information
        /// </summary>
        /// <value>name</value>
        public string name { get; }
        /// <summary>
        /// Label of business information
        /// </summary>
        /// <value>label</value>
        public string label { get; }
    }
}