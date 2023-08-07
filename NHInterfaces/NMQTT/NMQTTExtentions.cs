using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace System.Data.NMQTT
{
    /// <summary>
    /// MQTT应用消息扩展
    /// </summary>
    public static class MqttApplicationMessageExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ConvertPayloadToString(this MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null) throw new ArgumentNullException(nameof(applicationMessage));

            if (applicationMessage.Payload == null)
            {
                return null;
            }

            if (applicationMessage.Payload.Length == 0)
            {
                return string.Empty;
            }

            return Encoding.UTF8.GetString(applicationMessage.Payload, 0, applicationMessage.Payload.Length);
        }
    }
    /// <summary>
    /// MQTT主题过滤比较
    /// </summary>
    public static class MqttTopicFilterComparer
    {
        /// <summary>
        /// /符号
        /// </summary>
        public const char LevelSeparator = '/';
        /// <summary>
        /// #符号
        /// </summary>
        public const char MultiLevelWildcard = '#';
        /// <summary>
        /// +符号
        /// </summary>
        public const char SingleLevelWildcard = '+';
        /// <summary>
        /// $符号
        /// </summary>
        public const char ReservedTopicPrefix = '$';
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="topic">主题</param>
        /// <param name="filter">过滤字符</param>
        /// <returns></returns>
        public static unsafe MqttTopicFilterCompareResult Compare(string topic, string filter)
        {
            if (string.IsNullOrEmpty(topic))
            {
                return MqttTopicFilterCompareResult.TopicInvalid;
            }

            if (string.IsNullOrEmpty(filter))
            {
                return MqttTopicFilterCompareResult.FilterInvalid;
            }

            var filterOffset = 0;
            var filterLength = filter.Length;

            var topicOffset = 0;
            var topicLength = topic.Length;

            fixed (char* topicPointer = topic)
            fixed (char* filterPointer = filter)
            {
                if (filterLength > topicLength)
                {
                    // It is impossible to create a filter which is longer than the actual topic.
                    // The only way this can happen is when the last char is a wildcard char.
                    // sensor/7/temperature >> sensor/7/temperature = Equal
                    // sensor/+/temperature >> sensor/7/temperature = Equal
                    // sensor/7/+           >> sensor/7/temperature = Shorter
                    // sensor/#             >> sensor/7/temperature = Shorter
                    var lastFilterChar = filterPointer[filterLength - 1];
                    if (lastFilterChar != MultiLevelWildcard && lastFilterChar != SingleLevelWildcard)
                    {
                        return MqttTopicFilterCompareResult.NoMatch;
                    }
                }

                var isMultiLevelFilter = filterPointer[filterLength - 1] == MultiLevelWildcard;
                var isReservedTopic = topicPointer[0] == ReservedTopicPrefix;

                if (isReservedTopic && filterLength == 1 && isMultiLevelFilter)
                {
                    // It is not allowed to receive i.e. '$foo/bar' with filter '#'.
                    return MqttTopicFilterCompareResult.NoMatch;
                }

                if (isReservedTopic && filterPointer[0] == SingleLevelWildcard)
                {
                    // It is not allowed to receive i.e. '$SYS/monitor/Clients' with filter '+/monitor/Clients'.
                    return MqttTopicFilterCompareResult.NoMatch;
                }

                if (filterLength == 1 && isMultiLevelFilter)
                {
                    // Filter '#' matches basically everything.
                    return MqttTopicFilterCompareResult.IsMatch;
                }

                // Go through the filter char by char.
                while (filterOffset < filterLength && topicOffset < topicLength)
                {
                    // Check if the current char is a multi level wildcard. The char is only allowed
                    // at the very las position.
                    if (filterPointer[filterOffset] == MultiLevelWildcard && filterOffset != filterLength - 1)
                    {
                        return MqttTopicFilterCompareResult.FilterInvalid;
                    }

                    if (filterPointer[filterOffset] == topicPointer[topicOffset])
                    {
                        if (topicOffset == topicLength - 1)
                        {
                            // Check for e.g. "foo" matching "foo/#"
                            if (filterOffset == filterLength - 3 && filterPointer[filterOffset + 1] == LevelSeparator && isMultiLevelFilter)
                            {
                                return MqttTopicFilterCompareResult.IsMatch;
                            }

                            // Check for e.g. "foo/" matching "foo/#"
                            if (filterOffset == filterLength - 2 && filterPointer[filterOffset] == LevelSeparator && isMultiLevelFilter)
                            {
                                return MqttTopicFilterCompareResult.IsMatch;
                            }
                        }

                        filterOffset++;
                        topicOffset++;

                        // Check if the end was reached and i.e. "foo/bar" matches "foo/bar"
                        if (filterOffset == filterLength && topicOffset == topicLength)
                        {
                            return MqttTopicFilterCompareResult.IsMatch;
                        }

                        var endOfTopic = topicOffset == topicLength;

                        if (endOfTopic && filterOffset == filterLength - 1 && filterPointer[filterOffset] == SingleLevelWildcard)
                        {
                            if (filterOffset > 0 && filterPointer[filterOffset - 1] != LevelSeparator)
                            {
                                return MqttTopicFilterCompareResult.FilterInvalid;
                            }

                            return MqttTopicFilterCompareResult.IsMatch;
                        }
                    }
                    else
                    {
                        if (filterPointer[filterOffset] == SingleLevelWildcard)
                        {
                            // Check for invalid "+foo" or "a/+foo" subscription
                            if (filterOffset > 0 && filterPointer[filterOffset - 1] != LevelSeparator)
                            {
                                return MqttTopicFilterCompareResult.FilterInvalid;
                            }

                            // Check for bad "foo+" or "foo+/a" subscription
                            if (filterOffset < filterLength - 1 && filterPointer[filterOffset + 1] != LevelSeparator)
                            {
                                return MqttTopicFilterCompareResult.FilterInvalid;
                            }

                            filterOffset++;
                            while (topicOffset < topicLength && topicPointer[topicOffset] != LevelSeparator)
                            {
                                topicOffset++;
                            }

                            if (topicOffset == topicLength && filterOffset == filterLength)
                            {
                                return MqttTopicFilterCompareResult.IsMatch;
                            }
                        }
                        else if (filterPointer[filterOffset] == MultiLevelWildcard)
                        {
                            if (filterOffset > 0 && filterPointer[filterOffset - 1] != LevelSeparator)
                            {
                                return MqttTopicFilterCompareResult.FilterInvalid;
                            }

                            if (filterOffset + 1 != filterLength)
                            {
                                return MqttTopicFilterCompareResult.FilterInvalid;
                            }

                            return MqttTopicFilterCompareResult.IsMatch;
                        }
                        else
                        {
                            // Check for e.g. "foo/bar" matching "foo/+/#".
                            if (filterOffset > 0 && filterOffset + 2 == filterLength && topicOffset == topicLength && filterPointer[filterOffset - 1] == SingleLevelWildcard &&
                                filterPointer[filterOffset] == LevelSeparator && isMultiLevelFilter)
                            {
                                return MqttTopicFilterCompareResult.IsMatch;
                            }

                            return MqttTopicFilterCompareResult.NoMatch;
                        }
                    }
                }
            }

            return MqttTopicFilterCompareResult.NoMatch;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttClientTcpOptionsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int GetPort(this MqttClientTcpOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.Port.HasValue)
            {
                return options.Port.Value;
            }

            return !options.TlsOptions.UseTls ? 1883 : 8883;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttClientExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="reason"></param>
        /// <param name="reasonString"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task DisconnectAsync(this IMqttClient client, MqttClientDisconnectReason reason = MqttClientDisconnectReason.NormalDisconnection, string reasonString = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return client.DisconnectAsync(
                new MqttClientDisconnectOptions
                {
                    Reason = reason,
                    ReasonString = reasonString
                },
                CancellationToken.None);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="retain"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<MqttClientPublishResult> PublishBinaryAsync(
            this IMqttClient mqttClient,
            string topic,
            IEnumerable<byte> payload = null,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            bool retain = false,
            CancellationToken cancellationToken = default)
        {
            if (mqttClient == null)
            {
                throw new ArgumentNullException(nameof(mqttClient));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var applicationMessage = new MqttApplicationMessageBuilder().WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(retain)
                .WithQualityOfServiceLevel(qualityOfServiceLevel)
                .Build();

            return mqttClient.PublishAsync(applicationMessage, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="retain"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<MqttClientPublishResult> PublishStringAsync(
            this IMqttClient mqttClient,
            string topic,
            string payload = null,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            bool retain = false,
            CancellationToken cancellationToken = default)
        {
            var payloadBuffer = Encoding.UTF8.GetBytes(payload ?? string.Empty);
            return mqttClient.PublishBinaryAsync(topic, payloadBuffer, qualityOfServiceLevel, retain, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task ReconnectAsync(this IMqttClient client, CancellationToken cancellationToken = default)
        {
            if (client.Options == null)
            {
                throw new InvalidOperationException(
                    "The MQTT client was not connected before. A reconnect is only permitted when the client was already connected or at least tried to.");
            }

            return client.ConnectAsync(client.Options, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task SendExtendedAuthenticationExchangeDataAsync(this IMqttClient client, MqttExtendedAuthenticationExchangeData data)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return client.SendExtendedAuthenticationExchangeDataAsync(data, CancellationToken.None);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="topicFilter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<MqttClientSubscribeResult> SubscribeAsync(this IMqttClient mqttClient, MqttTopicFilter topicFilter, CancellationToken cancellationToken = default)
        {
            if (mqttClient == null)
            {
                throw new ArgumentNullException(nameof(mqttClient));
            }

            if (topicFilter == null)
            {
                throw new ArgumentNullException(nameof(topicFilter));
            }

            var subscribeOptions = new MqttClientSubscribeOptionsBuilder().WithTopicFilter(topicFilter).Build();

            return mqttClient.SubscribeAsync(subscribeOptions, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="topic"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<MqttClientSubscribeResult> SubscribeAsync(
            this IMqttClient mqttClient,
            string topic,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            CancellationToken cancellationToken = default)
        {
            if (mqttClient == null)
            {
                throw new ArgumentNullException(nameof(mqttClient));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var subscribeOptions = new MqttClientSubscribeOptionsBuilder().WithTopicFilter(topic, qualityOfServiceLevel).Build();

            return mqttClient.SubscribeAsync(subscribeOptions, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<bool> TryPingAsync(this IMqttClient client, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            try
            {
                await client.PingAsync(cancellationToken).ConfigureAwait(false);
                return true;
            }
            catch
            {
                // Ignore errors.
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttClient"></param>
        /// <param name="topic"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<MqttClientUnsubscribeResult> UnsubscribeAsync(this IMqttClient mqttClient, string topic, CancellationToken cancellationToken = default)
        {
            if (mqttClient == null)
            {
                throw new ArgumentNullException(nameof(mqttClient));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var unsubscribeOptions = new MqttClientUnsubscribeOptionsBuilder().WithTopicFilter(topic).Build();

            return mqttClient.UnsubscribeAsync(unsubscribeOptions, cancellationToken);
        }
    }
    /// <summary>
    /// The logger uses generic parameters in order to avoid boxing of parameter values like integers etc.
    /// </summary>
    public static class MqttNetSourceLoggerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Error<TParameter1>(this MqttNetSourceLogger logger, Exception exception, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Error, message, new object[] { parameter1 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Error<TParameter1, TParameter2>(this MqttNetSourceLogger logger, Exception exception, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Error, message, new object[] { parameter1, parameter2 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Error(this MqttNetSourceLogger logger, Exception exception, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Error, message, null, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Error(this MqttNetSourceLogger logger, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Error, message, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Info<TParameter1>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Info, message, new object[] { parameter1 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Info<TParameter1, TParameter2>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Info, message, new object[] { parameter1, parameter2 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Info(this MqttNetSourceLogger logger, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Info, message, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Publish<TParameter1>(this MqttNetSourceLogger logger, MqttNetLogLevel logLevel, Exception exception, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(logLevel, message, new object[] { parameter1 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Publish<TParameter1, TParameter2>(this MqttNetSourceLogger logger, MqttNetLogLevel logLevel, Exception exception, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(logLevel, message, new object[] { parameter1, parameter2 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Verbose<TParameter1>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Verbose, message, new object[] { parameter1 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Verbose<TParameter1, TParameter2>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Verbose, message, new object[] { parameter1, parameter2 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <typeparam name="TParameter3"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        /// <param name="parameter3"></param>
        public static void Verbose<TParameter1, TParameter2, TParameter3>(
            this MqttNetSourceLogger logger,
            string message,
            TParameter1 parameter1,
            TParameter2 parameter2,
            TParameter3 parameter3)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Verbose, message, new object[] { parameter1, parameter2, parameter3 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Verbose(this MqttNetSourceLogger logger, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Verbose, message, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Warning<TParameter1>(this MqttNetSourceLogger logger, Exception exception, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, new object[] { parameter1 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Warning<TParameter1, TParameter2>(this MqttNetSourceLogger logger, Exception exception, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, new object[] { parameter1, parameter2 }, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Warning(this MqttNetSourceLogger logger, Exception exception, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, null, exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        public static void Warning<TParameter1>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, new object[] { parameter1 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter1"></typeparam>
        /// <typeparam name="TParameter2"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="parameter1"></param>
        /// <param name="parameter2"></param>
        public static void Warning<TParameter1, TParameter2>(this MqttNetSourceLogger logger, string message, TParameter1 parameter1, TParameter2 parameter2)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, new object[] { parameter1, parameter2 }, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Warning(this MqttNetSourceLogger logger, string message)
        {
            if (!logger.IsEnabled)
            {
                return;
            }

            logger.Publish(MqttNetLogLevel.Warning, message, null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MqttNetSourceLogger WithSource(this IMqttNetLogger logger, string source)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            return new MqttNetSourceLogger(logger, source);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class TargetFrameworkProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public static string TargetFramework
        {
            get
            {
#if NET452
                return "net452";
#elif NET461
                return "net461";
#elif NET472
                return "net461";
#elif NET40
                return "net40";
#elif NET45
                return "net45";
#elif NETSTANDARD1_3
                return "netstandard1.3";
#elif NETSTANDARD2_0
                return "netstandard2.0";
#elif NETSTANDARD2_1
                return "netstandard2.1";
#elif WINDOWS_UWP
                return "uap10.0";
#elif NETCOREAPP3_1
                return "netcoreapp3.1";
#elif NET5_0
                return "net5.0";
#elif NET6_0
                return "net6.0";
#endif
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class CancellationTokenSourceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="throwOnFirstException"></param>
        /// <returns></returns>
        public static bool TryCancel(this CancellationTokenSource cancellationTokenSource, bool throwOnFirstException = false)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            try
            {
                // Checking the _IsCancellationRequested_ here will not throw an
                // "ObjectDisposedException" as the getter of the property "Token" will do!
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }

                cancellationTokenSource.Cancel(throwOnFirstException);
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class CompletedTask
    {
        /// <summary>
        /// 
        /// </summary>
#if NET452 || NET40 || NET45
        public static readonly Task Instance = TestTry.TaskFromResult(true);
#else
        public static readonly Task Instance = Task.CompletedTask;
#endif
    }
    /// <summary>
    /// 
    /// </summary>
    public static class EmptyBuffer
    {
        /// <summary>
        /// 
        /// </summary>
#if NET452 || NET40 || NET45
        public static readonly byte[] Array = new byte[0];
#else
        public static readonly byte[] Array = System.Array.Empty<byte>();
#endif
        /// <summary>
        /// 
        /// </summary>
        public static readonly ArraySegment<byte> ArraySegment = new ArraySegment<byte>(Array, 0, 0);
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttMemoryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destination"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static void Copy(byte[] source, int sourceIndex, byte[] destination, int destinationIndex, int length)
        {
#if NETCOREAPP3_1_OR_GREATER || NETSTANDARD2_1
            source.AsSpan(sourceIndex, length).CopyTo(destination.AsSpan(destinationIndex, length));
#elif NET461_OR_GREATER || NETSTANDARD1_3_OR_GREATER
            unsafe
            {
                fixed (byte* sourceHandle = &source[sourceIndex])
                {
                    fixed (byte* destinationHandle = &destination[destinationIndex])
                    {
                        System.Buffer.MemoryCopy(sourceHandle, destinationHandle, length, length);
                    }
                }
            }
#else
            Array.Copy(source, sourceIndex, destination, destinationIndex, length);
#endif
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttTaskTimeout
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MqttCommunicationTimedOutException"></exception>
        public static async Task WaitAsync(Func<CancellationToken, Task> action, TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
#if NET40
            using (var timeoutCts = new CancellationTokenSource())
            {
                timeoutCts.CancelAfter(timeout);
#else
            using (var timeoutCts = new CancellationTokenSource(timeout))
            {
#endif
                using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken))
                {
                    try
                    {
                        await action(linkedCts.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException exception)
                    {
                        var timeoutReached = timeoutCts.IsCancellationRequested && !cancellationToken.IsCancellationRequested;
                        if (timeoutReached)
                        {
                            throw new MqttCommunicationTimedOutException(exception);
                        }

                        throw;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="logger"></param>
        public static void RunInBackground(this Task task, MqttNetSourceLogger logger = null)
        {
            task?.ContinueWith(t =>
            {
                // Consume the exception first so that we get no exception regarding the not observed exception.
                var exception = t.Exception;
                logger?.Error(exception, "Unhandled exception in background task.");
            },
                TaskContinuationOptions.OnlyOnFaulted);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttPacketFactories
    {
        /// <summary>
        /// 
        /// </summary>
        public static MqttConnAckPacketFactory ConnAck { get; } = new MqttConnAckPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttConnectPacketFactory Connect { get; } = new MqttConnectPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttDisconnectPacketFactory Disconnect { get; } = new MqttDisconnectPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttPubAckPacketFactory PubAck { get; } = new MqttPubAckPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttPubCompPacketFactory PubComp { get; } = new MqttPubCompPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttPublishPacketFactory Publish { get; } = new MqttPublishPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttPubRecPacketFactory PubRec { get; } = new MqttPubRecPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttPubRelPacketFactory PubRel { get; } = new MqttPubRelPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttSubAckPacketFactory SubAck { get; } = new MqttSubAckPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttSubscribePacketFactory Subscribe { get; } = new MqttSubscribePacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttUnsubAckPacketFactory UnsubAck { get; } = new MqttUnsubAckPacketFactory();
        /// <summary>
        /// 
        /// </summary>
        public static MqttUnsubscribePacketFactory Unsubscribe { get; } = new MqttUnsubscribePacketFactory();
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttConnectReasonCodeConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnCode"></param>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public static MqttConnectReasonCode ToConnectReasonCode(MqttConnectReturnCode returnCode)
        {
            switch (returnCode)
            {
                case MqttConnectReturnCode.ConnectionAccepted:
                    {
                        return MqttConnectReasonCode.Success;
                    }

                case MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion:
                    {
                        return MqttConnectReasonCode.UnsupportedProtocolVersion;
                    }

                case MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword:
                    {
                        return MqttConnectReasonCode.BadUserNameOrPassword;
                    }

                case MqttConnectReturnCode.ConnectionRefusedIdentifierRejected:
                    {
                        return MqttConnectReasonCode.ClientIdentifierNotValid;
                    }

                case MqttConnectReturnCode.ConnectionRefusedServerUnavailable:
                    {
                        return MqttConnectReasonCode.ServerUnavailable;
                    }

                case MqttConnectReturnCode.ConnectionRefusedNotAuthorized:
                    {
                        return MqttConnectReasonCode.NotAuthorized;
                    }

                default:
                    {
                        throw new MqttProtocolViolationException("Unable to convert connect reason code (MQTTv5) to return code (MQTTv3).");
                    }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public static MqttConnectReturnCode ToConnectReturnCode(MqttConnectReasonCode reasonCode)
        {
            switch (reasonCode)
            {
                case MqttConnectReasonCode.Success:
                    {
                        return MqttConnectReturnCode.ConnectionAccepted;
                    }

                case MqttConnectReasonCode.NotAuthorized:
                    {
                        return MqttConnectReturnCode.ConnectionRefusedNotAuthorized;
                    }

                case MqttConnectReasonCode.BadUserNameOrPassword:
                    {
                        return MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                    }

                case MqttConnectReasonCode.ClientIdentifierNotValid:
                    {
                        return MqttConnectReturnCode.ConnectionRefusedIdentifierRejected;
                    }

                case MqttConnectReasonCode.UnsupportedProtocolVersion:
                    {
                        return MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion;
                    }

                case MqttConnectReasonCode.ServerUnavailable:
                case MqttConnectReasonCode.ServerBusy:
                case MqttConnectReasonCode.ServerMoved:
                    {
                        return MqttConnectReturnCode.ConnectionRefusedServerUnavailable;
                    }

                default:
                    {
                        throw new MqttProtocolViolationException("Unable to convert connect reason code (MQTTv5) to return code (MQTTv3).");
                    }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttPacketExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetRfcName(this MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            switch (packet)
            {
                case MqttConnectPacket _:
                    {
                        return "CONNECT";
                    }

                case MqttConnAckPacket _:
                    {
                        return "CONNACK";
                    }

                case MqttAuthPacket _:
                    {
                        return "AUTH";
                    }

                case MqttDisconnectPacket _:
                    {
                        return "DISCONNECT";
                    }

                case MqttPingReqPacket _:
                    {
                        return "PINGREQ";
                    }

                case MqttPingRespPacket _:
                    {
                        return "PINGRESP";
                    }

                case MqttSubscribePacket _:
                    {
                        return "SUBSCRIBE";
                    }

                case MqttSubAckPacket _:
                    {
                        return "SUBACK";
                    }

                case MqttUnsubscribePacket _:
                    {
                        return "UNSUBSCRIBE";
                    }

                case MqttUnsubAckPacket _:
                    {
                        return "UNSUBACK";
                    }

                case MqttPublishPacket _:
                    {
                        return "PUBLISH";
                    }

                case MqttPubAckPacket _:
                    {
                        return "PUBACK";
                    }

                case MqttPubRelPacket _:
                    {
                        return "PUBREL";
                    }

                case MqttPubRecPacket _:
                    {
                        return "PUBREC";
                    }

                case MqttPubCompPacket _:
                    {
                        return "PUBCOMP";
                    }

                default:
                    {
                        return packet.GetType().Name;
                    }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttTopicValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfInvalid(MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null) throw new ArgumentNullException(nameof(applicationMessage));

            if (applicationMessage.TopicAlias == 0)
            {
                ThrowIfInvalid(applicationMessage.Topic);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public static void ThrowIfInvalid(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new MqttProtocolViolationException("Topic should not be empty.");
            }

            foreach (var @char in topic)
            {
                if (@char == '+')
                {
                    throw new MqttProtocolViolationException("The character '+' is not allowed in topics.");
                }

                if (@char == '#')
                {
                    throw new MqttProtocolViolationException("The character '#' is not allowed in topics.");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public static void ThrowIfInvalidSubscribe(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new MqttProtocolViolationException("Topic should not be empty.");
            }

            var indexOfHash = topic.IndexOf("#", StringComparison.Ordinal);
            if (indexOfHash != -1 && indexOfHash != topic.Length - 1)
            {
                throw new MqttProtocolViolationException("The character '#' is only allowed as last character");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttServerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="topic"></param>
        /// <param name="payload"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="retain"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task InjectApplicationMessage(
            this MqttServer server,
            string topic,
            string payload = null,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            bool retain = false)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var payloadBuffer = EmptyBuffer.Array;
            if (payload is string stringPayload)
            {
                payloadBuffer = Encoding.UTF8.GetBytes(stringPayload);
            }

            return server.InjectApplicationMessage(
                new InjectedMqttApplicationMessage(
                    new MqttApplicationMessage
                    {
                        Topic = topic,
                        Payload = payloadBuffer,
                        QualityOfServiceLevel = qualityOfServiceLevel,
                        Retain = retain
                    }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="clientId"></param>
        /// <param name="topicFilters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task SubscribeAsync(this MqttServer server, string clientId, params MqttTopicFilter[] topicFilters)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            return server.SubscribeAsync(clientId, topicFilters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="clientId"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task SubscribeAsync(this MqttServer server, string clientId, string topic)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var topicFilters = new MqttTopicFilterBuilder().WithTopic(topic).Build();
            return server.SubscribeAsync(clientId, topicFilters);
        }
    }
}
