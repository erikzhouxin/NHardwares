using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class SubscribeResponse
    {
        /// <summary>
        /// Gets or sets the reason code which is sent to the client.
        /// The subscription is skipped when the value is not GrantedQoS_.
        /// MQTTv5 only.
        /// </summary>
        public MqttSubscribeReasonCode ReasonCode { get; set; }
        
        public List<MqttUserProperty> UserProperties { get; } = new List<MqttUserProperty>();
        
        public string ReasonString { get; set; }
    }
}