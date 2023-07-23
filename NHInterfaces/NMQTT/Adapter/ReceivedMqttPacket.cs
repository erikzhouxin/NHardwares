using System;

namespace System.Data.NMQTT
{
    public readonly struct ReceivedMqttPacket
    {
        public static readonly ReceivedMqttPacket Empty = new ReceivedMqttPacket();
        
        public ReceivedMqttPacket(byte fixedHeader, ArraySegment<byte> body, int totalLength)
        {
            FixedHeader = fixedHeader;
            Body = body;
            TotalLength = totalLength;
        }

        public byte FixedHeader { get; }

        public ArraySegment<byte> Body { get; }

        public int TotalLength { get; }
    }
}
