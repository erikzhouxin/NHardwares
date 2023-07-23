namespace System.Data.NMQTT
{
    public sealed class MqttPingReqPacket : MqttPacket
    {
        // This is a minor performance improvement.
        public static readonly MqttPingReqPacket Instance = new MqttPingReqPacket();

        public override string ToString()
        {
            return "PingReq";
        }
    }
}
