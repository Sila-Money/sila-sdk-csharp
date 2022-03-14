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

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "session_identifier", EmitDefaultValue = false)]
        public string SessionIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public Device(BaseUser user)
        {
            if (user != null)
            {
                DeviceFingerprint = user.DeviceFingerprint;
                SessionIdentifier = user.SessionIdentifier;
            }
        }
    }
}
