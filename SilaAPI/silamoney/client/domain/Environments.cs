namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// Class used to get standard values for the Base Path.
    /// </summary>
    public static class Environments
    {
        internal const string sandbox = "https://sandbox.silamoney.com/0.2";
        /// <summary>
        /// Property to get sandbox envirnoment.
        /// </summary>
        public static string SANDBOX { get => sandbox; }

        private const string production = "https://api.silamoney.com/0.2";
        /// <summary>
        /// Property to get production envirnoment.
        /// </summary>
        public static string PRODUCTION { get => production; }

        private const string local = "http://localhost:8080";
        /// <summary>
        /// Property to get localhost envirnoment.
        /// </summary>
        public static string LOCAL { get => local; }
    }
}
