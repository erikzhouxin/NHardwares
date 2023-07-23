namespace System.Data.NMQTT
{
    public struct ReadFixedHeaderResult
    {
        public static ReadFixedHeaderResult Canceled { get; } = new ReadFixedHeaderResult
        {
            IsCanceled = true
        };
        
        public static ReadFixedHeaderResult ConnectionClosed { get; } = new ReadFixedHeaderResult
        {
            IsConnectionClosed = true
        };
        
        public bool IsCanceled { get; set; }
        
        public bool IsConnectionClosed { get; set; }

        public MqttFixedHeader FixedHeader { get; set; }
    }
}
