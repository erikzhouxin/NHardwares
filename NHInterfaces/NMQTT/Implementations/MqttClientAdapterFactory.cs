using System;

namespace System.Data.NMQTT
{
    public sealed class MqttClientAdapterFactory : IMqttClientAdapterFactory
    {
        public IMqttChannelAdapter CreateClientAdapter(MqttClientOptions options, MqttPacketInspector packetInspector, IMqttNetLogger logger)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            IMqttChannel channel;
            switch (options.ChannelOptions)
            {
                case MqttClientTcpOptions _:
                    {
                        channel = new MqttTcpChannel(options);
                        break;
                    }

                case MqttClientWebSocketOptions webSocketOptions:
                    {
#if NET40
                        throw new NotSupportedException();
#else
                        channel = new MqttWebSocketChannel(webSocketOptions);
#endif
                        break;
                    }

                default:
                    {
                        throw new NotSupportedException();
                    }
            }

            var bufferWriter = new MqttBufferWriter(options.WriterBufferSize, options.WriterBufferSizeMax);
            var packetFormatterAdapter = new MqttPacketFormatterAdapter(options.ProtocolVersion, bufferWriter);
            return new MqttChannelAdapter(channel, packetFormatterAdapter, packetInspector, logger);
        }
    }
}
