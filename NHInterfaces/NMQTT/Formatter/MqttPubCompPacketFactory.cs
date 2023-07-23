using System;

namespace System.Data.NMQTT
{
    public sealed class MqttPubCompPacketFactory
    {
        public MqttPubCompPacket Create(MqttPubRelPacket pubRelPacket, MqttApplicationMessageReceivedReasonCode reasonCode)
        {
            if (pubRelPacket == null)
            {
                throw new ArgumentNullException(nameof(pubRelPacket));
            }

            return new MqttPubCompPacket
            {
                PacketIdentifier = pubRelPacket.PacketIdentifier,
                ReasonCode = (MqttPubCompReasonCode)(int)reasonCode
            };
        }
    }
}