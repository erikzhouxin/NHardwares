using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttDisconnectPacket : MqttPacket
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttDisconnectReasonCode ReasonCode { get; set; } = MqttDisconnectReasonCode.NormalDisconnection;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ServerReference { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public uint SessionExpiryInterval { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }

        public override string ToString()
        {
            return $"Disconnect: [ReasonCode={ReasonCode}]";
        }
    }
}