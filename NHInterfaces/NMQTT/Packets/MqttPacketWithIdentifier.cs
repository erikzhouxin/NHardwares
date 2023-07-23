namespace System.Data.NMQTT
{
    public abstract class MqttPacketWithIdentifier : MqttPacket
    {
        public ushort PacketIdentifier { get; set; }
    }
}
