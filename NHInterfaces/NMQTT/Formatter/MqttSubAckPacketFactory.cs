using System;

namespace System.Data.NMQTT
{
    public sealed class MqttSubAckPacketFactory
    {
        public MqttSubAckPacket Create(MqttSubscribePacket subscribePacket, SubscribeResult subscribeResult)
        {
            if (subscribePacket == null)
            {
                throw new ArgumentNullException(nameof(subscribePacket));
            }

            if (subscribeResult == null)
            {
                throw new ArgumentNullException(nameof(subscribeResult));
            }

            var subAckPacket = new MqttSubAckPacket
            {
                PacketIdentifier = subscribePacket.PacketIdentifier,
                ReasonCodes = subscribeResult.ReasonCodes,
                ReasonString = subscribeResult.ReasonString,
                UserProperties = subscribeResult.UserProperties
            };

            return subAckPacket;
        }
    }
}