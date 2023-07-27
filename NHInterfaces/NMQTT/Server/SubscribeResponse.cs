using System.Collections.Generic;

namespace System.Data.NMQTT
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SubscribeResponse
    {
        /// <summary>
        /// Gets or sets the reason code which is sent to the client.
        /// The subscription is skipped when the value is not GrantedQoS_.
        /// MQTTv5 only.
        /// </summary>
        public MqttSubscribeReasonCode ReasonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; } = new List<MqttUserProperty>();
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
    }
}