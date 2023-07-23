using System;
using System.Collections.Generic;

namespace System.Data.NMQTT
{
    /// <summary>Added in MQTTv5.0.0.</summary>
    public sealed class MqttAuthPacket : MqttPacket
    {
        public byte[] AuthenticationData { get; set; }

        public string AuthenticationMethod { get; set; }
        
        public MqttAuthenticateReasonCode ReasonCode { get; set; }

        public string ReasonString { get; set; }

        public List<MqttUserProperty> UserProperties { get; set; }
    }
}