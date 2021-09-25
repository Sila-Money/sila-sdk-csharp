using System.Runtime.Serialization;

namespace SilaAPI.silamoney.client.domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Device : EntityAudit
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_fingerprint", EmitDefaultValue = false)]
        public string DeviceFingerprint { get; set; }
    }
}
