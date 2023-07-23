using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public interface ILowLevelMqttClient : IDisposable
    {
        event Func<InspectMqttPacketEventArgs, Task> InspectPackage;

        bool IsConnected { get; }

        Task ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken = default);

        Task DisconnectAsync(CancellationToken cancellationToken = default);

        Task<MqttPacket> ReceiveAsync(CancellationToken cancellationToken = default);

        Task SendAsync(MqttPacket packet, CancellationToken cancellationToken = default);
    }
}