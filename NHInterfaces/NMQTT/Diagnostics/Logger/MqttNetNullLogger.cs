using System;

namespace System.Data.NMQTT
{
    /// <summary>
    ///     This logger does nothing with the messages.
    /// </summary>
    public sealed class MqttNetNullLogger : IMqttNetLogger
    {
        public MqttNetNullLogger()
        {
            IsEnabled = false;
        }

        public static MqttNetNullLogger Instance { get; } = new MqttNetNullLogger();

        public bool IsEnabled { get; }

        public void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception)
        {
        }
    }
}