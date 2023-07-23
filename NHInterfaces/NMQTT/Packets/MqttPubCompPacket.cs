using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttPubCompPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubCompReasonCode ReasonCode { get; set; } = MqttPubCompReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }

        public override string ToString()
        {
            return $"PubComp: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
}