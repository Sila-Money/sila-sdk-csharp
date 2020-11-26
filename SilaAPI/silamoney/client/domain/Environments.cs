namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Class used to get standard values for the Base Path.
    /// </summary>
    public static class Environments
    {
        private const string _sandbox = "https://sandbox.silamoney.com/0.2";
        /// <summary>
        /// Property to get sandbox envirnoment.
        /// </summary>
        public static string SANDBOX { get => _sandbox; }

        private const string _production = "https://api.silamoney.com/0.2";
        /// <summary>
        /// Property to get production envirnoment.
        /// </summary>
        public static string PRODUCTION { get => _production; }

        private const string _local = "http://localhost:8080";
        /// <summary>
        /// Property to get localhost envirnoment.
        /// </summary>
        public static string LOCAL { get => _local; }
    }
}
