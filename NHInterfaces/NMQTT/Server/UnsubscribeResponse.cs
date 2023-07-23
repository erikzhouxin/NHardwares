using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class UnsubscribeResponse
    {
        /// <summary>
        /// Gets or sets the reason code which is sent to the client.
        /// MQTTv5 only.
        /// </summary>
        public MqttUnsubscribeReasonCode ReasonCode { get; set; }
        
        public List<MqttUserProperty> UserProperties { get; } = new List<MqttUserProperty>();
        
        public string ReasonString { get; set; }
    }
}