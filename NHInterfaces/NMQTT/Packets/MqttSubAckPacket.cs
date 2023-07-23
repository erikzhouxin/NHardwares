using System.Collections.Generic;
using System.Linq;

namespace System.Data.NMQTT
{
    public sealed class MqttSubAckPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Reason Code is used in MQTTv5.0.0 and backward compatible to v.3.1.1. Return Code is used in MQTTv3.1.1
        /// </summary>
        public List<MqttSubscribeReasonCode> ReasonCodes { get; set; }

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
            var reasonCodesText = string.Join(",", ReasonCodes.Select(f => f.ToString()));

            return $"SubAck: [PacketIdentifier={PacketIdentifier}] [ReasonCode={reasonCodesText}]";
        }
    }
}