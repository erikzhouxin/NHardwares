using System;

namespace System.Data.NMQTT
{
    public interface IMqttPacketFormatter
    {
        MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket);
        
        MqttPacketBuffer Encode(MqttPacket mqttPacket);
    }
}