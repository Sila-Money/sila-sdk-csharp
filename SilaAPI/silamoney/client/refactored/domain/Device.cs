﻿using System.Runtime.Serialization;

namespace Sila.API.Client.Domain
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

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "session_identifier", EmitDefaultValue = false)]
        public string SessionIdentifier { get; set; }
    }
}
