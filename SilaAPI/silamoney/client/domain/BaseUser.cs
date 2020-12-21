namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseUser
    {
        /// <summary>
        /// String field used in the User object to save userHandle
        /// </summary>
        public string UserHandle { get; set; }
        /// <summary>
        /// String field used in the User object to save entityName
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// String field used in the User object to save phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// String field used in the User object to save email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// String field used in the User object to save identityValue
        /// </summary>
        public string IdentityValue { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress1
        /// </summary>
        public string StreetAddress1 { get; set; }
        /// <summary>
        /// String field used in the User object to save streetAddress2
        /// </summary>
        /// <value></value>
        public string StreetAddress2 { get; set; }
        /// <summary>
        /// String field used in the User object to save city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// String field used in the User object to save state
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// String field used in the User object to save postalCode
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// String field used in the User object to save cryptopAddress
        /// </summary>
        public string CryptoAddress { get; set; }
        /// <summary>
        /// String field used to register the country of the user
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// String field used to register an alias for the user contact information
        /// </summary>
        public string ContactAlias { get; set; }
        /// <summary>
        /// String field used to register an alias for the user crypto address
        /// </summary>
        public string CryptoAlias { get; set; }
        /// <summary>
        /// String field used to register an alias for the user address
        /// </summary>
        public string AddressAlias { get; set; }
        /// <summary>
        /// Optional. Choice Field: valid values are individual and business. (If not specified, other validation fields assume individual)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// This field should contain a valid Iovation device fingerprint in the production environment, but can be an arbitrary non-empty string in the sandbox environment.
        /// </summary>
        public string DeviceFingerprint { get; set; }
    }
}
