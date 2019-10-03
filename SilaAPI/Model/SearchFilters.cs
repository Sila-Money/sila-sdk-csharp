using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SilaAPI.Model
{
    [DataContract]
    public partial class SearchFilters
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionTypesEnum
        {
            [EnumMember(Value = "issue")]
            Issue = 1,
            [EnumMember(Value = "redeem")]
            Redeem = 2,
            [EnumMember(Value = "transfer")]
            Transfer = 3
        }
        
        [DataMember(Name="transaction_types", EmitDefaultValue=false)]
        public TransactionTypesEnum[] transactionTypes { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusesEnum
        {
            [EnumMember(Value = "pending")]
            Pending = 1,
            [EnumMember(Value = "complete")]
            Complete = 2,
            [EnumMember(Value = "successful")]
            Successful = 3,
            [EnumMember(Value = "failed")]
            Failed = 4
        }
        
        [DataMember(Name="statuses", EmitDefaultValue=false)]
        public StatusesEnum[] statuses { get; set; }

        public SearchFilters(string transactionId = default(string), int? perPage = default(int?), TransactionTypesEnum[] transactionTypes = default(TransactionTypesEnum[]), decimal? maxSilaAmount = default(decimal?), string referenceId = default(string), bool? showTimelines = default(bool?), bool? sortAscending = default(bool?), int? endEpoch = default(int?), int? startEpoch = default(int?), StatusesEnum[] statuses = default(StatusesEnum[]), int? page = default(int?), decimal? minSilaAmount = default(decimal?))
        {
            this.transactionId = transactionId;
            if(this.perPage != null)
            {
                if(this.perPage >= 1 && this.perPage <= 100)
                {
                    this.perPage = perPage;
                }
                else
                {
                    throw new InvalidDataException("perPage must be between 1 and 100");
                }
            }
            else
            {
                this.perPage = perPage;
            }
            this.transactionTypes = transactionTypes;
            this.maxSilaAmount = maxSilaAmount;
            this.referenceId = referenceId;
            this.showTimelines = showTimelines;
            this.sortAscending = sortAscending;
            this.endEpoch = endEpoch;
            this.startEpoch = startEpoch;
            this.statuses = statuses;
            this.page = page;
            this.minSilaAmount = minSilaAmount;
        }
        
        [DataMember(Name="transaction_id", EmitDefaultValue=false)]
        public string transactionId { get; set; }

        [DataMember(Name="per_page", EmitDefaultValue=false)]
        public int? perPage { get; set; }

        [DataMember(Name="max_sila_amount", EmitDefaultValue=false)]
        public decimal? maxSilaAmount { get; set; }

        [DataMember(Name="reference_id", EmitDefaultValue=false)]
        public string referenceId { get; set; }

        [DataMember(Name="show_timelines", EmitDefaultValue=false)]
        public bool? showTimelines { get; set; }

        [DataMember(Name="sort_ascending", EmitDefaultValue=false)]
        public bool? sortAscending { get; set; }

        [DataMember(Name="end_epoch", EmitDefaultValue=false)]
        public int? endEpoch { get; set; }

        [DataMember(Name="start_epoch", EmitDefaultValue=false)]
        public int? startEpoch { get; set; }

        [DataMember(Name="page", EmitDefaultValue=false)]
        public int? page { get; set; }

        [DataMember(Name="min_sila_amount", EmitDefaultValue=false)]
        public decimal? minSilaAmount { get; set; }
    }
}
