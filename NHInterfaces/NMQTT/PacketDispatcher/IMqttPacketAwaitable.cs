using System;

namespace System.Data.NMQTT
{
    public interface IMqttPacketAwaitable : IDisposable
    {
        MqttPacketAwaitableFilter Filter { get; }
        
        void Complete(MqttPacket packet);

        void Fail(Exception exception);

        void Cancel();
    }
}