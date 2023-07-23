namespace System.Data.NMQTT
{
    public sealed class MqttPingRespPacket : MqttPacket
    {
        // This is a minor performance improvement.
        public static readonly MqttPingRespPacket Instance = new MqttPingRespPacket();

        public override string ToString()
        {
            return "PingResp";
        }
    }
}
