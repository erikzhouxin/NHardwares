using System;

namespace System.Data.NMQTT
{
    public interface IMqttNetLogger
    {
        bool IsEnabled { get; }
        
        void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception);
    }
}
