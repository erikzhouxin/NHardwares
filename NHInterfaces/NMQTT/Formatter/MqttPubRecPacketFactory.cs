using System;

namespace System.Data.NMQTT
{
    public sealed class MqttPubRecPacketFactory
    {
        public MqttPubRecPacket Create(MqttApplicationMessageReceivedEventArgs applicationMessageReceivedEventArgs)
        {
            if (applicationMessageReceivedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(applicationMessageReceivedEventArgs));
            }

            var pubRecPacket = Create(applicationMessageReceivedEventArgs.PublishPacket, applicationMessageReceivedEventArgs.ReasonCode);
            pubRecPacket.UserProperties = applicationMessageReceivedEventArgs.ResponseUserProperties;

            return pubRecPacket;
        }

        public MqttPacket Create(MqttPublishPacket publishPacket, DispatchApplicationMessageResult dispatchApplicationMessageResult)
        {
            if (publishPacket == null)
            {
                throw new ArgumentNullException(nameof(publishPacket));
            }

            var pubRecPacket = new MqttPubRecPacket
            {
                PacketIdentifier = publishPacket.PacketIdentifier,
                ReasonCode = (MqttPubRecReasonCode)dispatchApplicationMessageResult.ReasonCode,
                ReasonString = dispatchApplicationMessageResult.ReasonString,
                UserProperties = dispatchApplicationMessageResult.UserProperties
            };

            return pubRecPacket;
        }

        static MqttPubRecPacket Create(MqttPublishPacket publishPacket, MqttApplicationMessageReceivedReasonCode applicationMessageReceivedReasonCode)
        {
            var pubRecPacket = new MqttPubRecPacket
            {
                PacketIdentifier = publishPacket.PacketIdentifier,
                ReasonCode = (MqttPubRecReasonCode)(int)applicationMessageReceivedReasonCode
            };

            return pubRecPacket;
        }
    }
}