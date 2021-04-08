using System.Runtime.Serialization;

namespace SilaAPI.Silamoney.Client.Refactored.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Device
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_fingerprint", EmitDefaultValue = false)]
        public string DeviceFingerprint { get; set; }
    }
}
