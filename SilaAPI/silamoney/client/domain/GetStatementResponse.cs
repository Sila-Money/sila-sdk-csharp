using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetStatementResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "statements", EmitDefaultValue = false)]
        public List<Statement> Statements { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "returned_count", EmitDefaultValue = false)]
        public int ReturnedCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "total_count", EmitDefaultValue = false)]
        public int TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public Pagination Pagination { get; set; }
    }
}