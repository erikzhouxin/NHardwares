namespace System.Data.NMQTT
{
    public static class MqttPacketFactories
    {
        public static MqttConnAckPacketFactory ConnAck { get; } = new MqttConnAckPacketFactory();
        
        public static MqttConnectPacketFactory Connect { get; } = new MqttConnectPacketFactory();

        public static MqttDisconnectPacketFactory Disconnect { get; } = new MqttDisconnectPacketFactory();

        public static MqttPubAckPacketFactory PubAck { get; } = new MqttPubAckPacketFactory();

        public static MqttPubCompPacketFactory PubComp { get; } = new MqttPubCompPacketFactory();

        public static MqttPublishPacketFactory Publish { get; } = new MqttPublishPacketFactory();

        public static MqttPubRecPacketFactory PubRec { get; } = new MqttPubRecPacketFactory();

        public static MqttPubRelPacketFactory PubRel { get; } = new MqttPubRelPacketFactory();

        public static MqttSubAckPacketFactory SubAck { get; } = new MqttSubAckPacketFactory();

        public static MqttSubscribePacketFactory Subscribe { get; } = new MqttSubscribePacketFactory();

        public static MqttUnsubAckPacketFactory UnsubAck { get; } = new MqttUnsubAckPacketFactory();

        public static MqttUnsubscribePacketFactory Unsubscribe { get; } = new MqttUnsubscribePacketFactory();
    }
}