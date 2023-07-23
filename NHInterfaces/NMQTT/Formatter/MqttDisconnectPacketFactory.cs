using System;

namespace System.Data.NMQTT
{
    public sealed class MqttDisconnectPacketFactory
    {
        readonly MqttDisconnectPacket _normalDisconnection = new MqttDisconnectPacket
        {
            ReasonCode = MqttDisconnectReasonCode.NormalDisconnection
        };

        public MqttDisconnectPacket Create(MqttDisconnectReasonCode reasonCode)
        {
            if (reasonCode == MqttDisconnectReasonCode.NormalDisconnection)
            {
                return _normalDisconnection;
            }

            return new MqttDisconnectPacket
            {
                ReasonCode = reasonCode
            };
        }

        public MqttDisconnectPacket Create(MqttClientDisconnectOptions clientDisconnectOptions)
        {
            var packet = new MqttDisconnectPacket();

            if (clientDisconnectOptions == null)
            {
                packet.ReasonCode = MqttDisconnectReasonCode.NormalDisconnection;
            }
            else
            {
                packet.ReasonCode = (MqttDisconnectReasonCode)clientDisconnectOptions.Reason;
            }

            return packet;
        }
    }
}