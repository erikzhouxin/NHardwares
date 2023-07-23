using System;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public interface IMqttServerAdapter : IDisposable
    {
        Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }

        Task StartAsync(MqttServerOptions options, IMqttNetLogger logger);
        Task StopAsync();
    }
}
