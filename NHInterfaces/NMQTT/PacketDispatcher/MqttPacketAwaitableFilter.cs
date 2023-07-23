using System;

namespace System.Data.NMQTT
{
    public sealed class MqttPacketAwaitableFilter
    {
        public Type Type { get; set; }
        
        public ushort Identifier { get; set; }
    }
}