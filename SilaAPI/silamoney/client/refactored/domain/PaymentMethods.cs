using Newtonsoft.Json;

namespace Sila.API.Client.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentMethods
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_address_id")]
        public string BlockchainAddressId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_address")]
        public string BlockChainAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockchain_network")]
        public string BlockChainNetwork { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("frozen")]
        public bool? Frozen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("default")]
        public bool? IsDefault { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_id")]
        public string BankAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_link_status")]
        public string AccountLinkStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("match_score")]
        public float? MatchScore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("entity_name")]
        public string EntityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_owner_name")]
        public string AccountOwnerName { get; set; }



        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_name")]
        public string CardName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_last_4")]
        public string CardLast4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_type")]
        public string CardType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pull_enabled")]
        public bool? PullEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("push_enabled")]
        public bool? PushEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("push_availability")]
        public string PushAvailability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_id")]
        public string VirtualAccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_account_name")]
        public string VirtualAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed")]
        public bool? Closed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_epoch")]
        public long CreatedEpoch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("closed_epoch")]
        public string ClosedEpoch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_credit_enabled")]
        public bool AchCreditEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ach_debit_enabled")]
        public bool AchDebitEnabled { get; set; }

    }
}
