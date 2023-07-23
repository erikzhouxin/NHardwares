using System.Net;
using System.Net.Sockets;

namespace System.Data.NMQTT
{
    public abstract class MqttServerTcpEndpointBaseOptions
    {
        public bool IsEnabled { get; set; }

        public int Port { get; set; }

        public int ConnectionBacklog { get; set; } = 100;

        public bool NoDelay { get; set; } = true;

        public LingerOption LingerState { get; set; } = new LingerOption(true, 0);

#if WINDOWS_UWP
        public int BufferSize { get; set; } = 4096;
#endif

        public IPAddress BoundInterNetworkAddress { get; set; } = IPAddress.Any;

        public IPAddress BoundInterNetworkV6Address { get; set; } = IPAddress.IPv6Any;

        /// <summary>
        ///     This requires admin permissions on Linux.
        /// </summary>
        public bool ReuseAddress { get; set; }
    }
}