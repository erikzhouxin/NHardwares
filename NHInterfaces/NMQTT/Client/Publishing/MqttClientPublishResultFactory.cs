using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Data.NMQTT
{
    public sealed class MqttClientPublishResultFactory
    {
        static readonly MqttClientPublishResult EmptySuccessResult = new MqttClientPublishResult();
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif

        public MqttClientPublishResult Create(MqttPubAckPacket pubAckPacket)
        {
            // QoS 0 has no response. So we treat it as a success always.
            if (pubAckPacket == null)
            {
                return EmptySuccessResult;
            }

            var result = new MqttClientPublishResult
            {
                // Both enums have the same values. So it can be easily converted.
                ReasonCode = (MqttClientPublishReasonCode)(int)pubAckPacket.ReasonCode,
                PacketIdentifier = pubAckPacket.PacketIdentifier,
                ReasonString = pubAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubAckPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                UserProperties = pubAckPacket.UserProperties ?? EmptyUserProperties
#endif
            };

            return result;
        }

        public MqttClientPublishResult Create(MqttPubRecPacket pubRecPacket, MqttPubCompPacket pubCompPacket)
        {
            if (pubRecPacket == null || pubCompPacket == null)
            {
                return new MqttClientPublishResult
                {
                    ReasonCode = MqttClientPublishReasonCode.UnspecifiedError
                };
            }

            MqttClientPublishResult result;

            // The PUBCOMP is the last packet in QoS 2. So we use the results from that instead of PUBREC.
            if (pubCompPacket.ReasonCode == MqttPubCompReasonCode.PacketIdentifierNotFound)
            {
                result = new MqttClientPublishResult
                {
                    PacketIdentifier = pubCompPacket.PacketIdentifier,
                    ReasonCode = MqttClientPublishReasonCode.UnspecifiedError,
                    ReasonString = pubCompPacket.ReasonString,
#if NET40
                    UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubCompPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                    UserProperties = pubCompPacket.UserProperties ?? EmptyUserProperties
#endif
                };

                return result;
            }

            result = new MqttClientPublishResult
            {
                PacketIdentifier = pubCompPacket.PacketIdentifier,
                ReasonCode = MqttClientPublishReasonCode.Success,
                ReasonString = pubCompPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubCompPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                UserProperties = pubCompPacket.UserProperties ?? EmptyUserProperties
#endif
            };

            if (pubRecPacket.ReasonCode != MqttPubRecReasonCode.Success)
            {
                // Both enums share the same values.
                result.ReasonCode = (MqttClientPublishReasonCode)pubRecPacket.ReasonCode;
            }

            return result;
        }
    }
}