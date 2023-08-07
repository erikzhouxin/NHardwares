using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.WebSockets;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections;
#if WINDOWS_UWP
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Security.Cryptography.Certificates;
using System.Runtime.InteropServices.WindowsRuntime;
#else
using System.Security.Cryptography.X509Certificates;
#endif
#if NETCOREAPP3_0_OR_GREATER
using System.Buffers.Binary;
#endif

namespace System.Data.NMQTT
{
    /// <summary>
    /// MQTT工厂
    /// </summary>
    public sealed class MqttFactory
    {
        IMqttClientAdapterFactory _clientAdapterFactory;
        /// <summary>
        /// 
        /// </summary>
        public MqttFactory() : this(new MqttNetNullLogger())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttFactory(IMqttNetLogger logger)
        {
            DefaultLogger = logger ?? throw new ArgumentNullException(nameof(logger));

            _clientAdapterFactory = new MqttClientAdapterFactory();
        }
        /// <summary>
        /// 
        /// </summary>
        public IMqttNetLogger DefaultLogger { get; }
        /// <summary>
        /// 
        /// </summary>
        public IList<Func<MqttFactory, IMqttServerAdapter>> DefaultServerAdapters { get; } = new List<Func<MqttFactory, IMqttServerAdapter>>
        {
            factory => new MqttTcpServerAdapter()
        };
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<object, object> Properties { get; } = new Dictionary<object, object>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttApplicationMessageBuilder CreateApplicationMessageBuilder()
        {
            return new MqttApplicationMessageBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientDisconnectOptionsBuilder CreateClientDisconnectOptionsBuilder()
        {
            return new MqttClientDisconnectOptionsBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientOptionsBuilder CreateClientOptionsBuilder()
        {
            return new MqttClientOptionsBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ILowLevelMqttClient CreateLowLevelMqttClient()
        {
            return CreateLowLevelMqttClient(DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            return new LowLevelMqttClient(_clientAdapterFactory, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientAdapterFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttClientAdapterFactory clientAdapterFactory)
        {
            if (clientAdapterFactory == null)
            {
                throw new ArgumentNullException(nameof(clientAdapterFactory));
            }

            return new LowLevelMqttClient(_clientAdapterFactory, DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientAdapterFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ILowLevelMqttClient CreateLowLevelMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory clientAdapterFactory)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (clientAdapterFactory == null)
            {
                throw new ArgumentNullException(nameof(clientAdapterFactory));
            }

            return new LowLevelMqttClient(_clientAdapterFactory, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMqttClient CreateMqttClient()
        {
            return CreateMqttClient(DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IMqttClient CreateMqttClient(IMqttNetLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            return new MqttClient(_clientAdapterFactory, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientAdapterFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IMqttClient CreateMqttClient(IMqttClientAdapterFactory clientAdapterFactory)
        {
            if (clientAdapterFactory == null)
            {
                throw new ArgumentNullException(nameof(clientAdapterFactory));
            }

            return new MqttClient(clientAdapterFactory, DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientAdapterFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IMqttClient CreateMqttClient(IMqttNetLogger logger, IMqttClientAdapterFactory clientAdapterFactory)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (clientAdapterFactory == null)
            {
                throw new ArgumentNullException(nameof(clientAdapterFactory));
            }

            return new MqttClient(clientAdapterFactory, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public MqttServer CreateMqttServer(MqttServerOptions options)
        {
            return CreateMqttServer(options, DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServer CreateMqttServer(MqttServerOptions options, IMqttNetLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            var serverAdapters = DefaultServerAdapters.Select(a => a.Invoke(this));
            return CreateMqttServer(options, serverAdapters, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="serverAdapters"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServer CreateMqttServer(MqttServerOptions options, IEnumerable<IMqttServerAdapter> serverAdapters, IMqttNetLogger logger)
        {
            if (serverAdapters == null)
            {
                throw new ArgumentNullException(nameof(serverAdapters));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            return new MqttServer(options, serverAdapters, logger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="serverAdapters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServer CreateMqttServer(MqttServerOptions options, IEnumerable<IMqttServerAdapter> serverAdapters)
        {
            if (serverAdapters == null)
            {
                throw new ArgumentNullException(nameof(serverAdapters));
            }

            return new MqttServer(options, serverAdapters, DefaultLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder CreateServerOptionsBuilder()
        {
            return new MqttServerOptionsBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientSubscribeOptionsBuilder CreateSubscribeOptionsBuilder()
        {
            return new MqttClientSubscribeOptionsBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttTopicFilterBuilder CreateTopicFilterBuilder()
        {
            return new MqttTopicFilterBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientUnsubscribeOptionsBuilder CreateUnsubscribeOptionsBuilder()
        {
            return new MqttClientUnsubscribeOptionsBuilder();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientAdapterFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttFactory UseClientAdapterFactory(IMqttClientAdapterFactory clientAdapterFactory)
        {
            _clientAdapterFactory = clientAdapterFactory ?? throw new ArgumentNullException(nameof(clientAdapterFactory));
            return this;
        }
    }
    /// <summary>
    /// MQTT主题过滤创建者
    /// </summary>
    public sealed class MqttTopicFilterBuilder
    {
        /// <summary>
        /// The quality of service level.
        /// The Quality of Service (QoS) level is an agreement between the sender of a message and the receiver of a message that defines the guarantee of delivery for a specific message.
        /// There are 3 QoS levels in MQTT:
        /// - At most once  (0): Message gets delivered no time, once or multiple times.
        /// - At least once (1): Message gets delivered at least once (one time or more often).
        /// - Exactly once  (2): Message gets delivered exactly once (It's ensured that the message only comes once).
        /// </summary>
        MqttQualityOfServiceLevel _qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;

        /// <summary>
        /// The MQTT topic.
        /// In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected client.
        /// The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level separator).
        /// </summary>
        string _topic;
        bool _noLocal;
        bool _retainAsPublished;
        MqttRetainHandling _retainHandling = MqttRetainHandling.SendAtSubscribe;
        /// <summary>
        /// MQTT的主题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithTopic(string topic)
        {
            _topic = topic;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualityOfServiceLevel"></param>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel)
        {
            _qualityOfServiceLevel = qualityOfServiceLevel;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithAtLeastOnceQoS()
        {
            _qualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithAtMostOnceQoS()
        {
            _qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithExactlyOnceQoS()
        {
            _qualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithNoLocal(bool value = true)
        {
            _noLocal = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithRetainAsPublished(bool value = true)
        {
            _retainAsPublished = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttTopicFilterBuilder WithRetainHandling(MqttRetainHandling value)
        {
            _retainHandling = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttTopicFilter Build()
        {
            if (string.IsNullOrEmpty(_topic))
            {
                throw new MqttProtocolViolationException("Topic is not set.");
            }

            return new MqttTopicFilter
            {
                Topic = _topic,
                QualityOfServiceLevel = _qualityOfServiceLevel,
                NoLocal = _noLocal,
                RetainAsPublished = _retainAsPublished,
                RetainHandling = _retainHandling
            };
        }
    }
    /// <summary>
    /// MQTT应用消息创建者
    /// </summary>
    public sealed class MqttApplicationMessageBuilder
    {
        string _contentType;
        byte[] _correlationData;
        uint _messageExpiryInterval;
        byte[] _payload;
        MqttPayloadFormatIndicator _payloadFormatIndicator;
        MqttQualityOfServiceLevel _qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;
        string _responseTopic;
        bool _retain;
        List<uint> _subscriptionIdentifiers;
        string _topic;
        ushort _topicAlias;
        List<MqttUserProperty> _userProperties;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttApplicationMessage Build()
        {
            if (_topicAlias == 0 && string.IsNullOrEmpty(_topic))
            {
                throw new MqttProtocolViolationException("Topic or TopicAlias is not set.");
            }

            var applicationMessage = new MqttApplicationMessage
            {
                Topic = _topic,
                Payload = _payload,
                QualityOfServiceLevel = _qualityOfServiceLevel,
                Retain = _retain,
                ContentType = _contentType,
                ResponseTopic = _responseTopic,
                CorrelationData = _correlationData,
                TopicAlias = _topicAlias,
                SubscriptionIdentifiers = _subscriptionIdentifiers,
                MessageExpiryInterval = _messageExpiryInterval,
                PayloadFormatIndicator = _payloadFormatIndicator,
                UserProperties = _userProperties
            };

            return applicationMessage;
        }

        /// <summary>
        ///     Adds the content type to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithContentType(string contentType)
        {
            _contentType = contentType;
            return this;
        }

        /// <summary>
        ///     Adds the correlation data to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="correlationData">
        ///     The correlation data.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithCorrelationData(byte[] correlationData)
        {
            _correlationData = correlationData;
            return this;
        }

        /// <summary>
        ///     Adds the message expiry interval in seconds to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="messageExpiryInterval">
        ///     The message expiry interval.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithMessageExpiryInterval(uint messageExpiryInterval)
        {
            _messageExpiryInterval = messageExpiryInterval;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public MqttApplicationMessageBuilder WithPayload(byte[] payload)
        {
            _payload = payload;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public MqttApplicationMessageBuilder WithPayload(IEnumerable<byte> payload)
        {
            if (payload == null)
            {
                _payload = null;
                return this;
            }

            _payload = payload as byte[] ?? payload.ToArray();

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public MqttApplicationMessageBuilder WithPayload(Stream payload)
        {
            if (payload == null)
            {
                _payload = null;
                return this;
            }

            return WithPayload(payload, payload.Length - payload.Position);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public MqttApplicationMessageBuilder WithPayload(Stream payload, long length)
        {
            if (payload == null)
            {
                _payload = null;
                return this;
            }

            if (payload.Length == 0)
            {
                _payload = null;
            }
            else
            {
                _payload = new byte[length];

                var totalRead = 0;
                do
                {
                    var bytesRead = payload.Read(_payload, totalRead, _payload.Length - totalRead);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    totalRead += bytesRead;
                } while (totalRead < length);
            }

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public MqttApplicationMessageBuilder WithPayload(string payload)
        {
            if (payload == null)
            {
                _payload = null;
                return this;
            }

            _payload = string.IsNullOrEmpty(payload) ? null : Encoding.UTF8.GetBytes(payload);
            return this;
        }

        /// <summary>
        ///     Adds the payload format indicator to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="payloadFormatIndicator">
        ///     The payload format indicator.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithPayloadFormatIndicator(MqttPayloadFormatIndicator payloadFormatIndicator)
        {
            _payloadFormatIndicator = payloadFormatIndicator;
            return this;
        }

        /// <summary>
        ///     The quality of service level.
        ///     The Quality of Service (QoS) level is an agreement between the sender of a message and the receiver of a message
        ///     that defines the guarantee of delivery for a specific message.
        ///     There are 3 QoS levels in MQTT:
        ///     - At most once  (0): Message gets delivered no time, once or multiple times.
        ///     - At least once (1): Message gets delivered at least once (one time or more often).
        ///     - Exactly once  (2): Message gets delivered exactly once (It's ensured that the message only comes once).
        /// </summary>
        public MqttApplicationMessageBuilder WithQualityOfServiceLevel(MqttQualityOfServiceLevel qualityOfServiceLevel)
        {
            _qualityOfServiceLevel = qualityOfServiceLevel;
            return this;
        }

        /// <summary>
        ///     Adds the response topic to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="responseTopic">
        ///     The response topic.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithResponseTopic(string responseTopic)
        {
            _responseTopic = responseTopic;
            return this;
        }

        /// <summary>
        ///     A value indicating whether the message should be retained or not.
        ///     A retained message is a normal MQTT message with the retained flag set to true.
        ///     The broker stores the last retained message and the corresponding QoS for that topic.
        /// </summary>
        public MqttApplicationMessageBuilder WithRetainFlag(bool value = true)
        {
            _retain = value;
            return this;
        }

        /// <summary>
        ///     Adds the subscription identifier to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="subscriptionIdentifier">
        ///     The subscription identifier.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithSubscriptionIdentifier(uint subscriptionIdentifier)
        {
            if (_subscriptionIdentifiers == null)
            {
                _subscriptionIdentifiers = new List<uint>();
            }

            _subscriptionIdentifiers.Add(subscriptionIdentifier);
            return this;
        }

        /// <summary>
        ///     The MQTT topic.
        ///     In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected
        ///     client.
        ///     The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level
        ///     separator).
        /// </summary>
        public MqttApplicationMessageBuilder WithTopic(string topic)
        {
            _topic = topic;
            return this;
        }

        /// <summary>
        ///     Adds the topic alias to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="topicAlias">
        ///     The topic alias.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithTopicAlias(ushort topicAlias)
        {
            _topicAlias = topicAlias;
            return this;
        }

        /// <summary>
        ///     Adds the user property to the message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        /// <param
        ///     name="name">
        ///     The property name.
        /// </param>
        /// <param
        ///     name="value">
        ///     The property value.
        /// </param>
        /// <returns>
        ///     A new instance of the
        ///     <see
        ///         cref="MqttApplicationMessageBuilder" />
        ///     class.
        /// </returns>
        public MqttApplicationMessageBuilder WithUserProperty(string name, string value)
        {
            if (_userProperties == null)
            {
                _userProperties = new List<MqttUserProperty>();
            }

            _userProperties.Add(new MqttUserProperty(name, value));
            return this;
        }
    }
    /// <summary>
    /// MQTT应用消息
    /// </summary>
    public sealed class MqttApplicationMessage
    {
        /// <summary>
        ///     Gets or sets the content type.
        ///     The content type must be a UTF-8 encoded string. The content type value identifies the kind of UTF-8 encoded
        ///     payload.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        ///     Gets or sets the correlation data.
        ///     In order for the sender to know what sent message the response refers to it can also send correlation data with the
        ///     published message.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public byte[] CorrelationData { get; set; }

        /// <summary>
        ///     If the DUP flag is set to 0, it indicates that this is the first occasion that the Client or Server has attempted
        ///     to send this MQTT PUBLISH Packet.
        ///     If the DUP flag is set to 1, it indicates that this might be re-delivery of an earlier attempt to send the Packet.
        ///     The DUP flag MUST be set to 1 by the Client or Server when it attempts to re-deliver a PUBLISH Packet
        ///     [MQTT-3.3.1.-1].
        ///     The DUP flag MUST be set to 0 for all QoS 0 messages [MQTT-3.3.1-2].
        /// </summary>
        public bool Dup { get; set; }

        /// <summary>
        ///     Gets or sets the message expiry interval.
        ///     A client can set the message expiry interval in seconds for each PUBLISH message individually.
        ///     This interval defines the period of time that the broker stores the PUBLISH message for any matching subscribers
        ///     that are not currently connected.
        ///     When no message expiry interval is set, the broker must store the message for matching subscribers indefinitely.
        ///     When the retained=true option is set on the PUBLISH message, this interval also defines how long a message is
        ///     retained on a topic.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public uint MessageExpiryInterval { get; set; }

        /// <summary>
        ///     Gets or sets the payload.
        ///     The payload is the data bytes sent via the MQTT protocol.
        /// </summary>
        public byte[] Payload { get; set; }

        /// <summary>
        ///     Gets or sets the payload format indicator.
        ///     The payload format indicator is part of any MQTT packet that can contain a payload. The indicator is an optional
        ///     byte value.
        ///     A value of 0 indicates an “unspecified byte stream”.
        ///     A value of 1 indicates a "UTF-8 encoded payload".
        ///     If no payload format indicator is provided, the default value is 0.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public MqttPayloadFormatIndicator PayloadFormatIndicator { get; set; } = MqttPayloadFormatIndicator.Unspecified;

        /// <summary>
        ///     Gets or sets the quality of service level.
        ///     The Quality of Service (QoS) level is an agreement between the sender of a message and the receiver of a message
        ///     that defines the guarantee of delivery for a specific message.
        ///     There are 3 QoS levels in MQTT:
        ///     - At most once  (0): Message gets delivered no time, once or multiple times.
        ///     - At least once (1): Message gets delivered at least once (one time or more often).
        ///     - Exactly once  (2): Message gets delivered exactly once (It's ensured that the message only comes once).
        /// </summary>
        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

        /// <summary>
        ///     Gets or sets the response topic.
        ///     In MQTT 5 the ability to publish a response topic was added in the publish message which allows you to implement
        ///     the request/response pattern between clients that is common in web applications.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public string ResponseTopic { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the message should be retained or not.
        ///     A retained message is a normal MQTT message with the retained flag set to true.
        ///     The broker stores the last retained message and the corresponding QoS for that topic.
        /// </summary>
        public bool Retain { get; set; }

        /// <summary>
        ///     Gets or sets the subscription identifiers.
        ///     The client can specify a subscription identifier when subscribing.
        ///     The broker will establish and store the mapping relationship between this subscription and subscription identifier
        ///     when successfully create or modify subscription.
        ///     The broker will return the subscription identifier associated with this PUBLISH packet and the PUBLISH packet to
        ///     the client when need to forward PUBLISH packets matching this subscription to this client.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public List<uint> SubscriptionIdentifiers { get; set; }

        /// <summary>
        ///     Gets or sets the MQTT topic.
        ///     In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected
        ///     client.
        ///     The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level
        ///     separator).
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        ///     Gets or sets the topic alias.
        ///     Topic aliases were introduced are a mechanism for reducing the size of published packets by reducing the size of
        ///     the topic field.
        ///     A value of 0 indicates no topic alias is used.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public ushort TopicAlias { get; set; }

        /// <summary>
        ///     Gets or sets the user properties.
        ///     In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT
        ///     packet.
        ///     As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add
        ///     metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        ///     The feature is very similar to the HTTP header concept.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    #region // Adapter
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttChannelAdapter : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        string Endpoint { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsSecureConnection { get; }
        /// <summary>
        /// 
        /// </summary>
        X509Certificate2 ClientCertificate { get; }
        /// <summary>
        /// 
        /// </summary>
        MqttPacketFormatterAdapter PacketFormatterAdapter { get; }
        /// <summary>
        /// 
        /// </summary>
        long BytesSent { get; }
        /// <summary>
        /// 
        /// </summary>
        long BytesReceived { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsReadingPacket { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ConnectAsync(CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DisconnectAsync(CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendPacketAsync(MqttPacket packet, CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttPacket> ReceivePacketAsync(CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        void ResetStatistics();
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttClientAdapterFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="packetInspector"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        IMqttChannelAdapter CreateClientAdapter(MqttClientOptions options, MqttPacketInspector packetInspector, IMqttNetLogger logger);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttServerAdapter : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        Task StartAsync(MqttServerOptions options, IMqttNetLogger logger);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task StopAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttChannelAdapter : Disposable, IMqttChannelAdapter
    {
        const uint ErrorOperationAborted = 0x800703E3;
        const int ReadBufferSize = 4096;

        readonly IMqttChannel _channel;
        readonly byte[] _fixedHeaderBuffer = new byte[2];
        readonly MqttNetSourceLogger _logger;

        readonly MqttPacketInspector _packetInspector;

        readonly byte[] _singleByteBuffer = new byte[1];

        readonly AsyncLock _syncRoot = new AsyncLock();

        long _bytesReceived;
        long _bytesSent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="packetFormatterAdapter"></param>
        /// <param name="packetInspector"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttChannelAdapter(IMqttChannel channel, MqttPacketFormatterAdapter packetFormatterAdapter, MqttPacketInspector packetInspector, IMqttNetLogger logger)
        {
            _channel = channel ?? throw new ArgumentNullException(nameof(channel));
            _packetInspector = packetInspector;

            PacketFormatterAdapter = packetFormatterAdapter ?? throw new ArgumentNullException(nameof(packetFormatterAdapter));

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger.WithSource(nameof(MqttChannelAdapter));
        }
        /// <summary>
        /// 
        /// </summary>
        public long BytesReceived => Interlocked.Read(ref _bytesReceived);
        /// <summary>
        /// 
        /// </summary>
        public long BytesSent => Interlocked.Read(ref _bytesSent);
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate2 ClientCertificate => _channel.ClientCertificate;
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint => _channel.Endpoint;
        /// <summary>
        /// 
        /// </summary>
        public bool IsReadingPacket { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSecureConnection => _channel.IsSecureConnection;
        /// <summary>
        /// 
        /// </summary>
        public MqttPacketFormatterAdapter PacketFormatterAdapter { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            try
            {
                /*
                 * We have to implement a small workaround here to support connecting in Xamarin
                 * with a disabled WiFi network. If the WiFi is disabled the connect method will
                 * block forever. Even a cancellation token is not supported properly.
                 */

                var connectTask = _channel.ConnectAsync(cancellationToken);

                var timeout = new TaskCompletionSource<object>();
                using (cancellationToken.Register(() => timeout.TrySetResult(null)))
                {
                    await TestTry.TaskWhenAny(connectTask, timeout.Task).ConfigureAwait(false);
                    if (timeout.Task.IsCompleted && !connectTask.IsCompleted)
                    {
                        throw new OperationCanceledException("MQTT connect canceled.", cancellationToken);
                    }

                    // Make sure that the exception from the connect task gets thrown.
                    await connectTask.ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                if (!WrapAndThrowException(exception))
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            try
            {
                await _channel.DisconnectAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (!WrapAndThrowException(exception))
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MqttPacket> ReceivePacketAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            try
            {
                _packetInspector?.BeginReceivePacket();

                ReceivedMqttPacket receivedPacket;
                var receivedPacketTask = ReceiveAsync(cancellationToken);
                if (receivedPacketTask.IsCompleted)
                {
                    receivedPacket = receivedPacketTask.Result;
                }
                else
                {
                    receivedPacket = await receivedPacketTask.ConfigureAwait(false);
                }

                if (receivedPacket.TotalLength == 0 || cancellationToken.IsCancellationRequested)
                {
                    return null;
                }

                _packetInspector?.EndReceivePacket();

                Interlocked.Add(ref _bytesSent, receivedPacket.TotalLength);

                if (PacketFormatterAdapter.ProtocolVersion == MqttProtocolVersion.Unknown)
                {
                    PacketFormatterAdapter.DetectProtocolVersion(receivedPacket);
                }

                var packet = PacketFormatterAdapter.Decode(receivedPacket);
                if (packet == null)
                {
                    throw new MqttProtocolViolationException("Received malformed packet.");
                }

                _logger.Verbose("RX ({0} bytes) <<< {1}", receivedPacket.TotalLength, packet);

                return packet;
            }
            catch (OperationCanceledException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception exception)
            {
                if (!WrapAndThrowException(exception))
                {
                    throw;
                }
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResetStatistics()
        {
            Interlocked.Exchange(ref _bytesReceived, 0L);
            Interlocked.Exchange(ref _bytesSent, 0L);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SendPacketAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            // This lock makes sure that multiple threads can send packets at the same time.
            // This is required when a disconnect is sent from another thread while the 
            // worker thread is still sending publish packets etc.
            using (await _syncRoot.EnterAsync(cancellationToken).ConfigureAwait(false))
            {
                // Check for cancellation here again because "WaitAsync" might take some time.
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    var packetBuffer = PacketFormatterAdapter.Encode(packet);
                    _packetInspector?.BeginSendPacket(packetBuffer);

                    _logger.Verbose("TX ({0} bytes) >>> {1}", packetBuffer.Length, packet);

                    if (packetBuffer.Payload.Count > 0)
                    {
                        await _channel.WriteAsync(packetBuffer.Packet, false, cancellationToken).ConfigureAwait(false);
                        await _channel.WriteAsync(packetBuffer.Payload, true, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await _channel.WriteAsync(packetBuffer.Packet, true, cancellationToken).ConfigureAwait(false);
                    }

                    Interlocked.Add(ref _bytesReceived, packetBuffer.Length);
                }
                catch (Exception exception)
                {
                    if (!WrapAndThrowException(exception))
                    {
                        throw;
                    }
                }
                finally
                {
                    PacketFormatterAdapter.Cleanup();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _channel.Dispose();
                _syncRoot.Dispose();
            }

            base.Dispose(disposing);
        }

        async Task<int> ReadBodyLengthAsync(byte initialEncodedByte, CancellationToken cancellationToken)
        {
            var offset = 0;
            var multiplier = 128;
            var value = initialEncodedByte & 127;
            int encodedByte = initialEncodedByte;

            while ((encodedByte & 128) != 0)
            {
                offset++;
                if (offset > 3)
                {
                    throw new MqttProtocolViolationException("Remaining length is invalid.");
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    return 0;
                }

                var readCount = await _channel.ReadAsync(_singleByteBuffer, 0, 1, cancellationToken).ConfigureAwait(false);

                if (cancellationToken.IsCancellationRequested)
                {
                    return 0;
                }

                if (readCount == 0)
                {
                    return 0;
                }

                _packetInspector?.FillReceiveBuffer(_singleByteBuffer);

                encodedByte = _singleByteBuffer[0];

                value += (encodedByte & 127) * multiplier;
                multiplier *= 128;
            }

            return value;
        }

        async Task<ReadFixedHeaderResult> ReadFixedHeaderAsync(CancellationToken cancellationToken)
        {
            // The MQTT fixed header contains 1 byte of flags and at least 1 byte for the remaining data length.
            // So in all cases at least 2 bytes must be read for a complete MQTT packet.
            var buffer = _fixedHeaderBuffer;
            var totalBytesRead = 0;

            while (totalBytesRead < buffer.Length)
            {
                // Check two times for cancellation because the call to _ReadAsync_ might block for some time.
                if (cancellationToken.IsCancellationRequested)
                {
                    return ReadFixedHeaderResult.Canceled;
                }

                int bytesRead;
                try
                {
                    bytesRead = await _channel.ReadAsync(buffer, totalBytesRead, buffer.Length - totalBytesRead, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return ReadFixedHeaderResult.Canceled;
                }
                catch (SocketException)
                {
                    return ReadFixedHeaderResult.ConnectionClosed;
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    return ReadFixedHeaderResult.Canceled;
                }

                if (bytesRead == 0)
                {
                    return ReadFixedHeaderResult.ConnectionClosed;
                }

                totalBytesRead += bytesRead;
            }

            _packetInspector?.FillReceiveBuffer(buffer);

            var hasRemainingLength = buffer[1] != 0;
            if (!hasRemainingLength)
            {
                return new ReadFixedHeaderResult
                {
                    FixedHeader = new MqttFixedHeader(buffer[0], 0, totalBytesRead)
                };
            }

            var bodyLength = await ReadBodyLengthAsync(buffer[1], cancellationToken).ConfigureAwait(false);
            if (bodyLength == 0)
            {
                return new ReadFixedHeaderResult
                {
                    IsConnectionClosed = true
                };
            }

            totalBytesRead += bodyLength;
            return new ReadFixedHeaderResult
            {
                FixedHeader = new MqttFixedHeader(buffer[0], bodyLength, totalBytesRead)
            };
        }

        async Task<ReceivedMqttPacket> ReceiveAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return ReceivedMqttPacket.Empty;
            }

            var readFixedHeaderResult = await ReadFixedHeaderAsync(cancellationToken).ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested)
            {
                return ReceivedMqttPacket.Empty;
            }

            if (readFixedHeaderResult.IsConnectionClosed)
            {
                return ReceivedMqttPacket.Empty;
            }

            IsReadingPacket = true;
            try
            {
                var fixedHeader = readFixedHeaderResult.FixedHeader;
                if (fixedHeader.RemainingLength == 0)
                {
                    return new ReceivedMqttPacket(fixedHeader.Flags, EmptyBuffer.ArraySegment, 2);
                }

                var bodyLength = fixedHeader.RemainingLength;
                var body = new byte[bodyLength];

                var bodyOffset = 0;
                var chunkSize = Math.Min(ReadBufferSize, bodyLength);

                do
                {
                    var bytesLeft = body.Length - bodyOffset;
                    if (chunkSize > bytesLeft)
                    {
                        chunkSize = bytesLeft;
                    }

                    var readBytes = await _channel.ReadAsync(body, bodyOffset, chunkSize, cancellationToken).ConfigureAwait(false);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return ReceivedMqttPacket.Empty;
                    }

                    if (readBytes == 0)
                    {
                        return ReceivedMqttPacket.Empty;
                    }

                    bodyOffset += readBytes;
                } while (bodyOffset < bodyLength);

                _packetInspector?.FillReceiveBuffer(body);

                var bodySegment = new ArraySegment<byte>(body, 0, bodyLength);
                return new ReceivedMqttPacket(fixedHeader.Flags, bodySegment, fixedHeader.TotalLength);
            }
            finally
            {
                IsReadingPacket = false;
            }
        }

        static bool WrapAndThrowException(Exception exception)
        {
            if (exception is OperationCanceledException || exception is MqttCommunicationTimedOutException || exception is MqttCommunicationException ||
                exception is MqttProtocolViolationException)
            {
                return false;
            }

            if (exception is IOException && exception.InnerException is SocketException innerException)
            {
                exception = innerException;
            }

            if (exception is SocketException socketException)
            {
                if (socketException.SocketErrorCode == SocketError.OperationAborted)
                {
                    throw new OperationCanceledException();
                }

                if (socketException.SocketErrorCode == SocketError.ConnectionAborted)
                {
                    throw new MqttCommunicationException(socketException);
                }
            }

            if (exception is COMException comException)
            {
#if !NET40
                if ((uint)comException.HResult == ErrorOperationAborted)
                {
                    throw new OperationCanceledException();
                }
#endif
            }

            throw new MqttCommunicationException(exception);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketInspector
    {
        readonly MqttNetSourceLogger _logger;
        readonly AsyncEvent<InspectMqttPacketEventArgs> _asyncEvent;

        MemoryStream _receivedPacketBuffer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyncEvent"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketInspector(AsyncEvent<InspectMqttPacketEventArgs> asyncEvent, IMqttNetLogger logger)
        {
            _asyncEvent = asyncEvent ?? throw new ArgumentNullException(nameof(asyncEvent));

            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger.WithSource(nameof(MqttPacketInspector));
        }
        /// <summary>
        /// 
        /// </summary>
        public void BeginReceivePacket()
        {
            if (!_asyncEvent.HasHandlers)
            {
                return;
            }

            if (_receivedPacketBuffer == null)
            {
                _receivedPacketBuffer = new MemoryStream();
            }

            _receivedPacketBuffer?.SetLength(0);
        }
        /// <summary>
        /// 
        /// </summary>
        public void EndReceivePacket()
        {
            if (!_asyncEvent.HasHandlers)
            {
                return;
            }

            var buffer = _receivedPacketBuffer.ToArray();
            _receivedPacketBuffer.SetLength(0);

            InspectPacket(buffer, MqttPacketFlowDirection.Inbound);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void BeginSendPacket(MqttPacketBuffer buffer)
        {
            if (!_asyncEvent.HasHandlers)
            {
                return;
            }

            // Create a copy of the actual packet so that the inspector gets no access
            // to the internal buffers. This is waste of memory but this feature is only
            // intended for debugging etc. so that this is OK.
            var bufferCopy = buffer.ToArray();

            InspectPacket(bufferCopy, MqttPacketFlowDirection.Outbound);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void FillReceiveBuffer(byte[] buffer)
        {
            if (!_asyncEvent.HasHandlers)
            {
                return;
            }

            _receivedPacketBuffer?.Write(buffer, 0, buffer.Length);
        }

        void InspectPacket(byte[] buffer, MqttPacketFlowDirection direction)
        {
            try
            {
                var eventArgs = new InspectMqttPacketEventArgs
                {
                    Buffer = buffer,
                    Direction = direction
                };

                _asyncEvent.InvokeAsync(eventArgs).GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Error while inspecting packet.");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public readonly struct ReceivedMqttPacket
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ReceivedMqttPacket Empty = new ReceivedMqttPacket();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fixedHeader"></param>
        /// <param name="body"></param>
        /// <param name="totalLength"></param>
        public ReceivedMqttPacket(byte fixedHeader, ArraySegment<byte> body, int totalLength)
        {
            FixedHeader = fixedHeader;
            Body = body;
            TotalLength = totalLength;
        }
        /// <summary>
        /// 
        /// </summary>
        public byte FixedHeader { get; }
        /// <summary>
        /// 
        /// </summary>
        public ArraySegment<byte> Body { get; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalLength { get; }
    }
    #endregion Adapter
    #region  // Certificates
    /// <summary>
    /// 证书提供接口
    /// </summary>
    public interface ICertificateProvider
    {
        /// <summary>
        /// 获取证书
        /// </summary>
        /// <returns></returns>
        X509Certificate2 GetCertificate();
    }
    /// <summary>
    /// 大对象证书
    /// </summary>
    public class BlobCertificateProvider : ICertificateProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blob"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BlobCertificateProvider(byte[] blob)
        {
            Blob = blob ?? throw new ArgumentNullException(nameof(blob));
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Blob { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public X509Certificate2 GetCertificate()
        {
            if (string.IsNullOrEmpty(Password))
            {
                // Use a different overload when no password is specified. Otherwise the constructor will fail.
                return new X509Certificate2(Blob);
            }

            return new X509Certificate2(Blob, Password);
        }
    }
#if !WINDOWS_UWP
    /// <summary>
    /// X509证书
    /// </summary>
    public class X509CertificateProvider : ICertificateProvider
    {
        readonly X509Certificate2 _certificate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public X509CertificateProvider(X509Certificate2 certificate)
        {
            _certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public X509Certificate2 GetCertificate()
        {
            return _certificate;
        }
    }
#endif
    #endregion Certificates
    #region // Channel
    /// <summary>
    /// MQTT通道
    /// </summary>
    public interface IMqttChannel : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        string Endpoint { get; }
        /// <summary>
        /// 
        /// </summary>
        bool IsSecureConnection { get; }
        /// <summary>
        /// 
        /// </summary>
        X509Certificate2 ClientCertificate { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ConnectAsync(CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DisconnectAsync(CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isEndOfPacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task WriteAsync(ArraySegment<byte> buffer, bool isEndOfPacket, CancellationToken cancellationToken);
    }
    #endregion Channel
    #region // Client
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttClient : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        event Func<MqttApplicationMessageReceivedEventArgs, Task> ApplicationMessageReceivedAsync;
        /// <summary>
        /// 
        /// </summary>
        event Func<MqttClientConnectedEventArgs, Task> ConnectedAsync;
        /// <summary>
        /// 
        /// </summary>
        event Func<MqttClientConnectingEventArgs, Task> ConnectingAsync;
        /// <summary>
        /// 
        /// </summary>
        event Func<MqttClientDisconnectedEventArgs, Task> DisconnectedAsync;
        /// <summary>
        /// 
        /// </summary>
        event Func<InspectMqttPacketEventArgs, Task> InspectPackage;
        /// <summary>
        /// 
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 
        /// </summary>
        MqttClientOptions Options { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttClientConnectResult> ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task PingAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken = default);
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClient : Disposable, IMqttClient
    {
        readonly IMqttClientAdapterFactory _adapterFactory;
        readonly AsyncEvent<MqttApplicationMessageReceivedEventArgs> _applicationMessageReceivedEvent = new AsyncEvent<MqttApplicationMessageReceivedEventArgs>();

        readonly MqttClientPublishResultFactory _clientPublishResultFactory = new MqttClientPublishResultFactory();
        readonly MqttClientSubscribeResultFactory _clientSubscribeResultFactory = new MqttClientSubscribeResultFactory();
        readonly MqttClientUnsubscribeResultFactory _clientUnsubscribeResultFactory = new MqttClientUnsubscribeResultFactory();

        readonly AsyncEvent<MqttClientConnectedEventArgs> _connectedEvent = new AsyncEvent<MqttClientConnectedEventArgs>();
        readonly AsyncEvent<MqttClientConnectingEventArgs> _connectingEvent = new AsyncEvent<MqttClientConnectingEventArgs>();
        readonly AsyncEvent<MqttClientDisconnectedEventArgs> _disconnectedEvent = new AsyncEvent<MqttClientDisconnectedEventArgs>();
        readonly object _disconnectLock = new object();
        readonly AsyncEvent<InspectMqttPacketEventArgs> _inspectPacketEvent = new AsyncEvent<InspectMqttPacketEventArgs>();
        readonly MqttNetSourceLogger _logger;

        readonly MqttPacketIdentifierProvider _packetIdentifierProvider = new MqttPacketIdentifierProvider();
        readonly IMqttNetLogger _rootLogger;

        IMqttChannelAdapter _adapter;
        CancellationTokenSource _backgroundCancellationTokenSource;
        bool _cleanDisconnectInitiated;
        volatile int _connectionStatus;
        MqttClientDisconnectReason _disconnectReason;
        string _disconnectReasonString;
        Task _keepAlivePacketsSenderTask;
        DateTime _lastPacketSentTimestamp;
        MqttPacketDispatcher _packetDispatcher;
        Task _packetReceiverTask;
        AsyncQueue<MqttPublishPacket> _publishPacketReceiverQueue;
        Task _publishPacketReceiverTask;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelFactory"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClient(IMqttClientAdapterFactory channelFactory, IMqttNetLogger logger)
        {
            _adapterFactory = channelFactory ?? throw new ArgumentNullException(nameof(channelFactory));
            _rootLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger = logger.WithSource(nameof(MqttClient));
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<MqttApplicationMessageReceivedEventArgs, Task> ApplicationMessageReceivedAsync
        {
            add => _applicationMessageReceivedEvent.AddHandler(value);
            remove => _applicationMessageReceivedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<MqttClientConnectedEventArgs, Task> ConnectedAsync
        {
            add => _connectedEvent.AddHandler(value);
            remove => _connectedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<MqttClientConnectingEventArgs, Task> ConnectingAsync
        {
            add => _connectingEvent.AddHandler(value);
            remove => _connectingEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<MqttClientDisconnectedEventArgs, Task> DisconnectedAsync
        {
            add => _disconnectedEvent.AddHandler(value);
            remove => _disconnectedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InspectMqttPacketEventArgs, Task> InspectPackage
        {
            add => _inspectPacketEvent.AddHandler(value);
            remove => _inspectPacketEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected => (MqttClientConnectionStatus)_connectionStatus == MqttClientConnectionStatus.Connected;
        /// <summary>
        /// 
        /// </summary>
        public MqttClientOptions Options { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<MqttClientConnectResult> ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.ChannelOptions == null)
            {
                throw new ArgumentException("ChannelOptions are not set.");
            }

            ThrowIfConnected("It is not allowed to connect with a server after the connection is established.");

            ThrowIfDisposed();

            if (CompareExchangeConnectionStatus(MqttClientConnectionStatus.Connecting, MqttClientConnectionStatus.Disconnected) != MqttClientConnectionStatus.Disconnected)
            {
                throw new InvalidOperationException("Not allowed to connect while connect/disconnect is pending.");
            }

            MqttClientConnectResult connectResult = null;

            try
            {
                Options = options;

                if (_connectingEvent.HasHandlers)
                {
                    await _connectingEvent.InvokeAsync(new MqttClientConnectingEventArgs(options));
                }

                _packetIdentifierProvider.Reset();
                _packetDispatcher = new MqttPacketDispatcher();

                _backgroundCancellationTokenSource = new CancellationTokenSource();
                var backgroundCancellationToken = _backgroundCancellationTokenSource.Token;

                var adapter = _adapterFactory.CreateClientAdapter(options, new MqttPacketInspector(_inspectPacketEvent, _rootLogger), _rootLogger);
                _adapter = adapter;

                using (var effectiveCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(backgroundCancellationToken, cancellationToken))
                {
                    _logger.Verbose("Trying to connect with server '{0}'.", options.ChannelOptions);
                    await adapter.ConnectAsync(effectiveCancellationToken.Token).ConfigureAwait(false);
                    _logger.Verbose("Connection with server established.");

                    _publishPacketReceiverQueue?.Dispose();
                    _publishPacketReceiverQueue = new AsyncQueue<MqttPublishPacket>();
                    _publishPacketReceiverTask = TestTry.TaskRun(() => ProcessReceivedPublishPackets(backgroundCancellationToken), backgroundCancellationToken);

                    _packetReceiverTask = TestTry.TaskRun(() => TryReceivePacketsAsync(backgroundCancellationToken), backgroundCancellationToken);

                    connectResult = await AuthenticateAsync(options, effectiveCancellationToken.Token).ConfigureAwait(false);
                }

                _lastPacketSentTimestamp = DateTime.UtcNow;

                var keepAliveInterval = Options.KeepAlivePeriod;
                if (connectResult.ServerKeepAlive > 0)
                {
                    _logger.Info($"Using keep alive value ({connectResult.ServerKeepAlive}) sent from the server.");
                    keepAliveInterval = TimeSpan.FromSeconds(connectResult.ServerKeepAlive);
                }

                if (keepAliveInterval != TimeSpan.Zero)
                {
                    _keepAlivePacketsSenderTask = TestTry.TaskRun(() => TrySendKeepAliveMessagesAsync(backgroundCancellationToken), backgroundCancellationToken);
                }

                CompareExchangeConnectionStatus(MqttClientConnectionStatus.Connected, MqttClientConnectionStatus.Connecting);

                _logger.Info("Connected.");

                if (_connectedEvent.HasHandlers)
                {
                    var eventArgs = new MqttClientConnectedEventArgs(connectResult);
                    await _connectedEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
                }

                return connectResult;
            }
            catch (Exception exception)
            {
                _disconnectReason = MqttClientDisconnectReason.UnspecifiedError;

                _logger.Error(exception, "Error while connecting with server.");

                await DisconnectInternalAsync(null, exception, connectResult).ConfigureAwait(false);

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task DisconnectAsync(MqttClientDisconnectOptions options, CancellationToken cancellationToken = default)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            ThrowIfDisposed();

            var clientWasConnected = IsConnected;
            if (DisconnectIsPendingOrFinished())
            {
                return;
            }

            try
            {
                _disconnectReason = MqttClientDisconnectReason.NormalDisconnection;
                _cleanDisconnectInitiated = true;

                if (clientWasConnected)
                {
                    var disconnectPacket = MqttPacketFactories.Disconnect.Create(options);
                    await SendAsync(disconnectPacket, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                await DisconnectCoreAsync(null, null, null, clientWasConnected).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PingAsync(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.CanBeCanceled)
            {
                await SendAndReceiveAsync<MqttPingRespPacket>(MqttPingReqPacket.Instance, cancellationToken).ConfigureAwait(false);
            }
            else
            {
#if NET40
                using (var timeout = new CancellationTokenSource())
                {
                    timeout.CancelAfter(Options.Timeout);
#else
                using (var timeout = new CancellationTokenSource(Options.Timeout))
                {
#endif
                    await SendAndReceiveAsync<MqttPingRespPacket>(MqttPingReqPacket.Instance, timeout.Token).ConfigureAwait(false);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            MqttTopicValidator.ThrowIfInvalid(applicationMessage);

            ThrowIfDisposed();
            ThrowIfNotConnected();

            var publishPacket = MqttPacketFactories.Publish.Create(applicationMessage);

            switch (applicationMessage.QualityOfServiceLevel)
            {
                case MqttQualityOfServiceLevel.AtMostOnce:
                    {
                        return PublishAtMostOnce(publishPacket, cancellationToken);
                    }
                case MqttQualityOfServiceLevel.AtLeastOnce:
                    {
                        return PublishAtLeastOnceAsync(publishPacket, cancellationToken);
                    }
                case MqttQualityOfServiceLevel.ExactlyOnce:
                    {
                        return PublishExactlyOnceAsync(publishPacket, cancellationToken);
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data, CancellationToken cancellationToken = default)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ThrowIfDisposed();
            ThrowIfNotConnected();

            var authPacket = new MqttAuthPacket
            {
                // This must always be equal to the value from the CONNECT packet. So we use it here to ensure that.
                AuthenticationMethod = Options.AuthenticationMethod,
                AuthenticationData = data.AuthenticationData,
                ReasonString = data.ReasonString,
                UserProperties = data.UserProperties
            };

            return SendAsync(authPacket, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            foreach (var topicFilter in options.TopicFilters)
            {
                MqttTopicValidator.ThrowIfInvalidSubscribe(topicFilter.Topic);
            }

            ThrowIfDisposed();
            ThrowIfNotConnected();

            var subscribePacket = MqttPacketFactories.Subscribe.Create(options);
            subscribePacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();

            var subAckPacket = await SendAndReceiveAsync<MqttSubAckPacket>(subscribePacket, cancellationToken).ConfigureAwait(false);

            return _clientSubscribeResultFactory.Create(subscribePacket, subAckPacket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            ThrowIfDisposed();
            ThrowIfNotConnected();

            var unsubscribePacket = MqttPacketFactories.Unsubscribe.Create(options);
            unsubscribePacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();

            var unsubAckPacket = await SendAndReceiveAsync<MqttUnsubAckPacket>(unsubscribePacket, cancellationToken).ConfigureAwait(false);

            return _clientUnsubscribeResultFactory.Create(unsubscribePacket, unsubAckPacket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Cleanup();
            }

            base.Dispose(disposing);
        }

        Task AcknowledgeReceivedPublishPacket(MqttApplicationMessageReceivedEventArgs eventArgs, CancellationToken cancellationToken)
        {
            if (eventArgs.PublishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce)
            {
                // no response required
            }
            else if (eventArgs.PublishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtLeastOnce)
            {
                if (!eventArgs.ProcessingFailed)
                {
                    var pubAckPacket = MqttPacketFactories.PubAck.Create(eventArgs);
                    return SendAsync(pubAckPacket, cancellationToken);
                }
            }
            else if (eventArgs.PublishPacket.QualityOfServiceLevel == MqttQualityOfServiceLevel.ExactlyOnce)
            {
                if (!eventArgs.ProcessingFailed)
                {
                    var pubRecPacket = MqttPacketFactories.PubRec.Create(eventArgs);
                    return SendAsync(pubRecPacket, cancellationToken);
                }
            }
            else
            {
                throw new MqttProtocolViolationException("Received a not supported QoS level.");
            }

            return CompletedTask.Instance;
        }

        async Task<MqttClientConnectResult> AuthenticateAsync(MqttClientOptions options, CancellationToken cancellationToken)
        {
            MqttClientConnectResult result;

            try
            {
                var connectPacket = MqttPacketFactories.Connect.Create(options);

                var connAckPacket = await SendAndReceiveAsync<MqttConnAckPacket>(connectPacket, cancellationToken).ConfigureAwait(false);

                var clientConnectResultFactory = new MqttClientConnectResultFactory();
                result = clientConnectResultFactory.Create(connAckPacket, options.ProtocolVersion);
            }
            catch (Exception exception)
            {
                throw new MqttConnectingFailedException($"Error while authenticating. {exception.Message}", exception, null);
            }

            if (result.ResultCode != MqttClientConnectResultCode.Success)
            {
                throw new MqttConnectingFailedException($"Connecting with MQTT server failed ({result.ResultCode}).", null, result);
            }

            _logger.Verbose("Authenticated MQTT connection with server established.");

            return result;
        }

        void Cleanup()
        {
            try
            {
                _backgroundCancellationTokenSource?.Cancel(false);
            }
            finally
            {
                _backgroundCancellationTokenSource?.Dispose();
                _backgroundCancellationTokenSource = null;

                _publishPacketReceiverQueue?.Dispose();
                _publishPacketReceiverQueue = null;

                _adapter?.Dispose();
                _adapter = null;

                _packetDispatcher?.Dispose();
                _packetDispatcher = null;
            }
        }

        MqttClientConnectionStatus CompareExchangeConnectionStatus(MqttClientConnectionStatus value, MqttClientConnectionStatus comparand)
        {
            return (MqttClientConnectionStatus)Interlocked.CompareExchange(ref _connectionStatus, (int)value, (int)comparand);
        }

        async Task DisconnectCoreAsync(Task sender, Exception exception, MqttClientConnectResult connectResult, bool clientWasConnected)
        {
            TryInitiateDisconnect();

            try
            {
                if (_adapter != null)
                {
                    _logger.Verbose("Disconnecting [Timeout={0}]", Options.Timeout);
#if NET40
                    using (var timeout = new CancellationTokenSource())
                    {
                        timeout.CancelAfter(Options.Timeout);
#else
                    using (var timeout = new CancellationTokenSource(Options.Timeout))
                    {
#endif
                        await _adapter.DisconnectAsync(timeout.Token).ConfigureAwait(false);
                    }
                }

                _logger.Verbose("Disconnected from adapter.");
            }
            catch (Exception adapterException)
            {
                _logger.Warning(adapterException, "Error while disconnecting from adapter.");
            }

            try
            {
                _packetDispatcher.Dispose(new MqttClientDisconnectedException(exception));

                var receiverTask = WaitForTaskAsync(_packetReceiverTask, sender);
                var publishPacketReceiverTask = WaitForTaskAsync(_publishPacketReceiverTask, sender);
                var keepAliveTask = WaitForTaskAsync(_keepAlivePacketsSenderTask, sender);

                await TestTry.TaskWhenAll(receiverTask, publishPacketReceiverTask, keepAliveTask).ConfigureAwait(false);
            }
            catch (Exception innerException)
            {
                _logger.Warning(innerException, "Error while waiting for internal tasks.");
            }
            finally
            {
                Cleanup();
                _cleanDisconnectInitiated = false;
                CompareExchangeConnectionStatus(MqttClientConnectionStatus.Disconnected, MqttClientConnectionStatus.Disconnecting);

                _logger.Info("Disconnected.");

                var eventArgs = new MqttClientDisconnectedEventArgs
                {
                    ClientWasConnected = clientWasConnected,
                    Exception = exception,
                    ConnectResult = connectResult,
                    Reason = _disconnectReason,
                    ReasonString = _disconnectReasonString
                };

                // This handler must be executed in a new thread because otherwise a dead lock may happen
                // when trying to reconnect in that handler etc.
                TestTry.TaskRun(() => _disconnectedEvent.InvokeAsync(eventArgs)).RunInBackground(_logger);
            }
        }

        Task DisconnectInternalAsync(Task sender, Exception exception, MqttClientConnectResult connectResult)
        {
            var clientWasConnected = IsConnected;

            if (!DisconnectIsPendingOrFinished())
            {
                return DisconnectCoreAsync(sender, exception, connectResult, clientWasConnected);
            }

            return CompletedTask.Instance;
        }

        bool DisconnectIsPendingOrFinished()
        {
            var connectionStatus = (MqttClientConnectionStatus)_connectionStatus;

            do
            {
                switch (connectionStatus)
                {
                    case MqttClientConnectionStatus.Disconnected:
                    case MqttClientConnectionStatus.Disconnecting:
                        return true;
                    case MqttClientConnectionStatus.Connected:
                    case MqttClientConnectionStatus.Connecting:
                        // This will compare the _connectionStatus to old value and set it to "MqttClientConnectionStatus.Disconnecting" afterwards.
                        // So the first caller will get a "false" and all subsequent ones will get "true".
                        var curStatus = CompareExchangeConnectionStatus(MqttClientConnectionStatus.Disconnecting, connectionStatus);
                        if (curStatus == connectionStatus)
                        {
                            return false;
                        }

                        connectionStatus = curStatus;
                        break;
                }
            } while (true);
        }

        void EnqueueReceivedPublishPacket(MqttPublishPacket publishPacket)
        {
            try
            {
                _publishPacketReceiverQueue.Enqueue(publishPacket);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Error while queueing application message.");
            }
        }

        async Task<MqttApplicationMessageReceivedEventArgs> HandleReceivedApplicationMessageAsync(MqttPublishPacket publishPacket)
        {
            var applicationMessage = MqttApplicationMessageFactory.Create(publishPacket);
            var eventArgs = new MqttApplicationMessageReceivedEventArgs(Options.ClientId, applicationMessage, publishPacket, AcknowledgeReceivedPublishPacket);

            await _applicationMessageReceivedEvent.InvokeAsync(eventArgs).ConfigureAwait(false);

            return eventArgs;
        }

        Task ProcessReceivedAuthPacket(MqttAuthPacket authPacket)
        {
            var extendedAuthenticationExchangeHandler = Options.ExtendedAuthenticationExchangeHandler;
            if (extendedAuthenticationExchangeHandler != null)
            {
                return extendedAuthenticationExchangeHandler.HandleRequestAsync(new MqttExtendedAuthenticationExchangeContext(authPacket, this));
            }

            return CompletedTask.Instance;
        }

        Task ProcessReceivedDisconnectPacket(MqttDisconnectPacket disconnectPacket)
        {
            _disconnectReason = (MqttClientDisconnectReason)disconnectPacket.ReasonCode;
            _disconnectReasonString = disconnectPacket.ReasonString;

            // Also dispatch disconnect to waiting threads to generate a proper exception.
            _packetDispatcher.Dispose(new MqttClientUnexpectedDisconnectReceivedException(disconnectPacket));

            return DisconnectInternalAsync(_packetReceiverTask, null, null);
        }

        async Task ProcessReceivedPublishPackets(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var publishPacketDequeueResult = await _publishPacketReceiverQueue.TryDequeueAsync(cancellationToken).ConfigureAwait(false);
                    if (!publishPacketDequeueResult.IsSuccess)
                    {
                        return;
                    }

                    var publishPacket = publishPacketDequeueResult.Item;
                    var eventArgs = await HandleReceivedApplicationMessageAsync(publishPacket).ConfigureAwait(false);

                    if (eventArgs.AutoAcknowledge)
                    {
                        await eventArgs.AcknowledgeAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception exception)
                {
                    _logger.Error(exception, "Error while handling application message.");
                }
            }
        }

        Task ProcessReceivedPubRecPacket(MqttPubRecPacket pubRecPacket, CancellationToken cancellationToken)
        {
            if (!_packetDispatcher.TryDispatch(pubRecPacket))
            {
                // The packet is unknown. Probably due to a restart of the client.
                // So wen send this to the server to trigger a full resend of the message.
                var pubRelPacket = MqttPacketFactories.PubRel.Create(pubRecPacket, MqttApplicationMessageReceivedReasonCode.PacketIdentifierNotFound);
                return SendAsync(pubRelPacket, cancellationToken);
            }

            return CompletedTask.Instance;
        }

        Task ProcessReceivedPubRelPacket(MqttPubRelPacket pubRelPacket, CancellationToken cancellationToken)
        {
            var pubCompPacket = MqttPacketFactories.PubComp.Create(pubRelPacket, MqttApplicationMessageReceivedReasonCode.Success);
            return SendAsync(pubCompPacket, cancellationToken);
        }

        async Task<MqttClientPublishResult> PublishAtLeastOnceAsync(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
        {
            publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();

            var pubAckPacket = await SendAndReceiveAsync<MqttPubAckPacket>(publishPacket, cancellationToken).ConfigureAwait(false);

            return _clientPublishResultFactory.Create(pubAckPacket);
        }

        async Task<MqttClientPublishResult> PublishAtMostOnce(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
        {
            // No packet identifier is used for QoS 0 [3.3.2.2 Packet Identifier]
            await SendAsync(publishPacket, cancellationToken).ConfigureAwait(false);

            return _clientPublishResultFactory.Create(null);
        }

        async Task<MqttClientPublishResult> PublishExactlyOnceAsync(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
        {
            publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();

            var pubRecPacket = await SendAndReceiveAsync<MqttPubRecPacket>(publishPacket, cancellationToken).ConfigureAwait(false);

            var pubRelPacket = MqttPacketFactories.PubRel.Create(pubRecPacket, MqttApplicationMessageReceivedReasonCode.Success);

            var pubCompPacket = await SendAndReceiveAsync<MqttPubCompPacket>(pubRelPacket, cancellationToken).ConfigureAwait(false);

            return _clientPublishResultFactory.Create(pubRecPacket, pubCompPacket);
        }

        async Task<TResponsePacket> SendAndReceiveAsync<TResponsePacket>(MqttPacket requestPacket, CancellationToken cancellationToken) where TResponsePacket : MqttPacket
        {
            cancellationToken.ThrowIfCancellationRequested();

            ushort packetIdentifier = 0;
            if (requestPacket is MqttPacketWithIdentifier packetWithIdentifier)
            {
                packetIdentifier = packetWithIdentifier.PacketIdentifier;
            }

            using (var packetAwaitable = _packetDispatcher.AddAwaitable<TResponsePacket>(packetIdentifier))
            {
                try
                {
                    await SendAsync(requestPacket, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    _logger.Warning(exception, "Error when sending request packet ({0}).", requestPacket.GetType().Name);
                    packetAwaitable.Fail(exception);
                }

                try
                {
                    return await packetAwaitable.WaitOneAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    if (exception is MqttCommunicationTimedOutException)
                    {
                        _logger.Warning("Timeout while waiting for response packet ({0}).", typeof(TResponsePacket).Name);
                    }

                    throw;
                }
            }
        }

        Task SendAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _lastPacketSentTimestamp = DateTime.UtcNow;

            return _adapter.SendPacketAsync(packet, cancellationToken);
        }

        void ThrowIfConnected(string message)
        {
            if (IsConnected)
            {
                throw new MqttProtocolViolationException(message);
            }
        }

        void ThrowIfNotConnected()
        {
            if (!IsConnected)
            {
                throw new MqttCommunicationException("The client is not connected.");
            }
        }

        void TryInitiateDisconnect()
        {
            lock (_disconnectLock)
            {
                try
                {
                    _backgroundCancellationTokenSource?.Cancel(false);
                }
                catch (Exception exception)
                {
                    _logger.Warning(exception, "Error while initiating disconnect.");
                }
            }
        }

        async Task TryProcessReceivedPacketAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            try
            {
                if (packet is MqttPublishPacket publishPacket)
                {
                    EnqueueReceivedPublishPacket(publishPacket);
                }
                else if (packet is MqttPubRecPacket pubRecPacket)
                {
                    await ProcessReceivedPubRecPacket(pubRecPacket, cancellationToken).ConfigureAwait(false);
                }
                else if (packet is MqttPubRelPacket pubRelPacket)
                {
                    await ProcessReceivedPubRelPacket(pubRelPacket, cancellationToken).ConfigureAwait(false);
                }
                else if (packet is MqttDisconnectPacket disconnectPacket)
                {
                    await ProcessReceivedDisconnectPacket(disconnectPacket).ConfigureAwait(false);
                }
                else if (packet is MqttAuthPacket authPacket)
                {
                    await ProcessReceivedAuthPacket(authPacket).ConfigureAwait(false);
                }
                else if (packet is MqttPingRespPacket)
                {
                    _packetDispatcher.TryDispatch(packet);
                }
                else if (packet is MqttPingReqPacket)
                {
                    throw new MqttProtocolViolationException("The PINGREQ Packet is sent from a Client to the Server only.");
                }
                else
                {
                    if (!_packetDispatcher.TryDispatch(packet))
                    {
                        throw new MqttProtocolViolationException($"Received packet '{packet}' at an unexpected time.");
                    }
                }
            }
            catch (Exception exception)
            {
                if (_cleanDisconnectInitiated)
                {
                    return;
                }

                if (exception is OperationCanceledException)
                {
                }
                else if (exception is MqttCommunicationException)
                {
                    _logger.Warning(exception, "Communication error while receiving packets.");
                }
                else
                {
                    _logger.Error(exception, $"Error while processing received packet ({packet.GetType().Name}).");
                }

                _packetDispatcher.FailAll(exception);

                await DisconnectInternalAsync(_packetReceiverTask, exception, null).ConfigureAwait(false);
            }
        }

        async Task TryReceivePacketsAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Verbose("Start receiving packets.");

                while (!cancellationToken.IsCancellationRequested)
                {
                    MqttPacket packet;
                    var packetTask = _adapter.ReceivePacketAsync(cancellationToken);

                    if (packetTask.IsCompleted)
                    {
                        packet = packetTask.Result;
                    }
                    else
                    {
                        packet = await packetTask.ConfigureAwait(false);
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    if (packet == null)
                    {
                        await DisconnectInternalAsync(_packetReceiverTask, null, null).ConfigureAwait(false);

                        return;
                    }

                    await TryProcessReceivedPacketAsync(packet, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                if (_cleanDisconnectInitiated)
                {
                    return;
                }

                if (exception is AggregateException aggregateException)
                {
                    exception = aggregateException.GetBaseException();
                }

                if (exception is OperationCanceledException)
                {
                }
                else if (exception is MqttCommunicationException)
                {
                    _logger.Warning(exception, "Communication error while receiving packets.");
                }
                else
                {
                    _logger.Error(exception, "Error while receiving packets.");
                }

                _packetDispatcher.FailAll(exception);

                await DisconnectInternalAsync(_packetReceiverTask, exception, null).ConfigureAwait(false);
            }
            finally
            {
                _logger.Verbose("Stopped receiving packets.");
            }
        }

        async Task TrySendKeepAliveMessagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Verbose("Start sending keep alive packets.");

                var keepAlivePeriod = Options.KeepAlivePeriod;

                while (!cancellationToken.IsCancellationRequested)
                {
                    // Values described here: [MQTT-3.1.2-24].
                    var timeWithoutPacketSent = DateTime.UtcNow - _lastPacketSentTimestamp;

                    if (timeWithoutPacketSent > keepAlivePeriod)
                    {
                        using (var timeoutCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                        {
                            timeoutCancellationTokenSource.CancelAfter(Options.Timeout);
                            await PingAsync(timeoutCancellationTokenSource.Token).ConfigureAwait(false);
                        }
                    }

                    // Wait a fixed time in all cases. Calculation of the remaining time is complicated
                    // due to some edge cases and was buggy in the past. Now we wait several ms because the
                    // min keep alive value is one second so that the server will wait 1.5 seconds for a PING
                    // packet.
                    await TestTry.TaskDelay(250, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                if (_cleanDisconnectInitiated)
                {
                    return;
                }

                if (exception is OperationCanceledException)
                {
                    return;
                }
                else if (exception is MqttCommunicationException)
                {
                    _logger.Warning(exception, "Communication error while sending/receiving keep alive packets.");
                }
                else
                {
                    _logger.Error(exception, "Error exception while sending/receiving keep alive packets.");
                }

                await DisconnectInternalAsync(_keepAlivePacketsSenderTask, exception, null).ConfigureAwait(false);
            }
            finally
            {
                _logger.Verbose("Stopped sending keep alive packets.");
            }
        }

        async Task WaitForTaskAsync(Task task, Task sender)
        {
            if (task == null)
            {
                return;
            }

            if (task == sender)
            {
                // Return here to avoid deadlocks, but first any eventual exception in the task
                // must be handled to avoid not getting an unhandled task exception
                if (!task.IsFaulted)
                {
                    return;
                }

                // By accessing the Exception property the exception is considered handled and will
                // not result in an unhandled task exception later by the finalizer
                _logger.Warning(task.Exception, "Error while waiting for background task.");
                return;
            }

            try
            {
                await task.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketIdentifierProvider
    {
        readonly object _syncRoot = new object();

        ushort _value;
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            lock (_syncRoot)
            {
                _value = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort GetNextPacketIdentifier()
        {
            lock (_syncRoot)
            {
                _value++;

                if (_value == 0)
                {
                    // As per official MQTT documentation the package identifier should never be 0.
                    _value = 1;
                }

                return _value;
            }
        }
    }
    #region // Connecting
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectResult"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientConnectedEventArgs(MqttClientConnectResult connectResult)
        {
            ConnectResult = connectResult ?? throw new ArgumentNullException(nameof(connectResult));
        }

        /// <summary>
        ///     Gets the authentication result.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientConnectResult ConnectResult { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectingEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        public MqttClientConnectingEventArgs(MqttClientOptions clientOptions)
        {
            ClientOptions = clientOptions;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientOptions ClientOptions { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectResult
    {
        /// <summary>
        /// Gets the result code.
        /// MQTTv5 only.
        /// </summary>
        public MqttClientConnectResultCode ResultCode { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether a session was already available or not.
        /// MQTTv5 only.
        /// </summary>
        public bool IsSessionPresent { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether wildcards can be used in subscriptions at the current server.
        /// MQTTv5 only.
        /// </summary>
        public bool WildcardSubscriptionAvailable { get; internal set; }

        /// <summary>
        /// Gets whether the server supports retained messages.
        /// MQTTv5 only.
        /// </summary>
        public bool RetainAvailable { get; internal set; }

        /// <summary>
        /// Gets the client identifier which was chosen by the server.
        /// MQTTv5 only.
        /// </summary>
        public string AssignedClientIdentifier { get; internal set; }

        /// <summary>
        /// Gets the authentication method.
        /// MQTTv5 only.
        /// </summary>
        public string AuthenticationMethod { get; internal set; }

        /// <summary>
        /// Gets the authentication data.
        /// MQTTv5 only.
        /// </summary>
        public byte[] AuthenticationData { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public uint? MaximumPacketSize { get; internal set; }

        /// <summary>
        /// Gets the reason string.
        /// MQTTv5 only.
        /// </summary>
        public string ReasonString { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort? ReceiveMaximum { get; internal set; }

        /// <summary>
        /// Gets the maximum QoS which is supported by the server.
        /// MQTTv5 only.
        /// </summary>
        public MqttQualityOfServiceLevel MaximumQoS { get; internal set; }

        /// <summary>
        /// Gets the response information.
        /// MQTTv5 only.
        /// </summary>
        public string ResponseInformation { get; internal set; }

        /// <summary>
        /// Gets the maximum value for a topic alias. 0 means not supported.
        /// MQTTv5 only.
        /// </summary>
        public ushort TopicAliasMaximum { get; internal set; }

        /// <summary>
        /// Gets an alternate server which should be used instead of the current one.
        /// MQTTv5 only.
        /// </summary>
        public string ServerReference { get; internal set; }

        /// <summary>
        /// MQTTv5 only.
        /// Gets the keep alive interval which was chosen by the server instead of the
        /// keep alive interval from the client CONNECT packet.
        /// A value of 0 indicates that the feature is not used.
        /// </summary>
        public ushort ServerKeepAlive { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public uint? SessionExpiryInterval { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the subscription identifiers are available or not.
        /// MQTTv5 only.
        /// </summary>
        public bool SubscriptionIdentifiersAvailable { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the shared subscriptions are available or not.
        /// MQTTv5 only.
        /// </summary>
        public bool SharedSubscriptionAvailable { get; internal set; }

        /// <summary>
        /// Gets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// MQTTv5 only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; internal set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectResultFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connAckPacket"></param>
        /// <param name="protocolVersion"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientConnectResult Create(MqttConnAckPacket connAckPacket, MqttProtocolVersion protocolVersion)
        {
            if (connAckPacket == null) throw new ArgumentNullException(nameof(connAckPacket));

            if (protocolVersion == MqttProtocolVersion.V500)
            {
                return CreateForMqtt500(connAckPacket);
            }

            return CreateForMqtt311(connAckPacket);
        }

        static MqttClientConnectResult CreateForMqtt500(MqttConnAckPacket connAckPacket)
        {
            if (connAckPacket == null) throw new ArgumentNullException(nameof(connAckPacket));

            return new MqttClientConnectResult
            {
                IsSessionPresent = connAckPacket.IsSessionPresent,
                ResultCode = (MqttClientConnectResultCode)(int)connAckPacket.ReasonCode,
                WildcardSubscriptionAvailable = connAckPacket.WildcardSubscriptionAvailable,
                RetainAvailable = connAckPacket.RetainAvailable,
                AssignedClientIdentifier = connAckPacket.AssignedClientIdentifier,
                AuthenticationMethod = connAckPacket.AuthenticationMethod,
                AuthenticationData = connAckPacket.AuthenticationData,
                MaximumPacketSize = connAckPacket.MaximumPacketSize,
                ReasonString = connAckPacket.ReasonString,
                ReceiveMaximum = connAckPacket.ReceiveMaximum,
                MaximumQoS = connAckPacket.MaximumQoS,
                ResponseInformation = connAckPacket.ResponseInformation,
                TopicAliasMaximum = connAckPacket.TopicAliasMaximum,
                ServerReference = connAckPacket.ServerReference,
                ServerKeepAlive = connAckPacket.ServerKeepAlive,
                SessionExpiryInterval = connAckPacket.SessionExpiryInterval,
                SubscriptionIdentifiersAvailable = connAckPacket.SubscriptionIdentifiersAvailable,
                SharedSubscriptionAvailable = connAckPacket.SharedSubscriptionAvailable,
                UserProperties = connAckPacket.UserProperties
            };
        }

        static MqttClientConnectResult CreateForMqtt311(MqttConnAckPacket connAckPacket)
        {
            if (connAckPacket == null) throw new ArgumentNullException(nameof(connAckPacket));

            return new MqttClientConnectResult
            {
                RetainAvailable = true, // Always true because v3.1.1 does not have a way to "disable" that feature.
                WildcardSubscriptionAvailable = true, // Always true because v3.1.1 does not have a way to "disable" that feature.
                IsSessionPresent = connAckPacket.IsSessionPresent,
                ResultCode = ConvertReturnCodeToResultCode(connAckPacket.ReturnCode)
            };
        }

        static MqttClientConnectResultCode ConvertReturnCodeToResultCode(MqttConnectReturnCode connectReturnCode)
        {
            switch (connectReturnCode)
            {
                case MqttConnectReturnCode.ConnectionAccepted:
                    {
                        return MqttClientConnectResultCode.Success;
                    }

                case MqttConnectReturnCode.ConnectionRefusedUnacceptableProtocolVersion:
                    {
                        return MqttClientConnectResultCode.UnsupportedProtocolVersion;
                    }

                case MqttConnectReturnCode.ConnectionRefusedNotAuthorized:
                    {
                        return MqttClientConnectResultCode.NotAuthorized;
                    }

                case MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword:
                    {
                        return MqttClientConnectResultCode.BadUserNameOrPassword;
                    }

                case MqttConnectReturnCode.ConnectionRefusedIdentifierRejected:
                    {
                        return MqttClientConnectResultCode.ClientIdentifierNotValid;
                    }

                case MqttConnectReturnCode.ConnectionRefusedServerUnavailable:
                    {
                        return MqttClientConnectResultCode.ServerUnavailable;
                    }

                default:
                    throw new MqttProtocolViolationException("Received unexpected return code.");
            }
        }
    }
    #endregion Connecting
    #region // Disconnecting
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientDisconnectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool ClientWasConnected { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        /// Gets the authentication result.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientConnectResult ConnectResult { get; internal set; }

        /// <summary>
        /// Gets or sets the reason.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientDisconnectReason Reason { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; internal set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientDisconnectOptions
    {
        /// <summary>
        /// Gets or sets the reason code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientDisconnectReason Reason { get; set; } = MqttClientDisconnectReason.NormalDisconnection;

        /// <summary>
        /// Gets or sets the reason string.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public string ReasonString { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientDisconnectOptionsBuilder
    {
        MqttClientDisconnectReason _reason = MqttClientDisconnectReason.NormalDisconnection;
        string _reasonString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientDisconnectOptionsBuilder WithReasonString(string value)
        {
            _reasonString = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientDisconnectOptionsBuilder WithReason(MqttClientDisconnectReason value)
        {
            _reason = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientDisconnectOptions Build()
        {
            return new MqttClientDisconnectOptions
            {
                Reason = _reason,
                ReasonString = _reasonString
            };
        }
    }
    #endregion Disconnecting
    #region // ExtendedAuthenticationExchange
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttExtendedAuthenticationExchangeHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task HandleRequestAsync(MqttExtendedAuthenticationExchangeContext context);
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttExtendedAuthenticationExchangeContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authPacket"></param>
        /// <param name="client"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttExtendedAuthenticationExchangeContext(MqttAuthPacket authPacket, MqttClient client)
        {
            if (authPacket == null) throw new ArgumentNullException(nameof(authPacket));

            ReasonCode = authPacket.ReasonCode;
            ReasonString = authPacket.ReasonString;
            AuthenticationMethod = authPacket.AuthenticationMethod;
            AuthenticationData = authPacket.AuthenticationData;
            UserProperties = authPacket.UserProperties;

            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets the reason code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttAuthenticateReasonCode ReasonCode { get; }

        /// <summary>
        /// Gets the reason string.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public string ReasonString { get; }

        /// <summary>
        /// Gets the authentication method.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public string AuthenticationMethod { get; }

        /// <summary>
        /// Gets the authentication data.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public byte[] AuthenticationData { get; }

        /// <summary>
        /// Gets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClient Client { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttExtendedAuthenticationExchangeData
    {
        /// <summary>
        /// Gets or sets the reason code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttAuthenticateReasonCode ReasonCode { get; set; }

        /// <summary>
        /// Gets or sets the reason string.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        /// Gets or sets the authentication data.
        /// Authentication data is binary information used to transmit multiple iterations of cryptographic secrets of protocol steps.
        /// The content of the authentication data is highly dependent on the specific implementation of the authentication method.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public byte[] AuthenticationData { get; set; }

        /// <summary>
        /// Gets or sets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; }
    }
    #endregion ExtendedAuthenticationExchange
    #region // Options
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttClientChannelOptions
    {
        /// <summary>
        /// 
        /// </summary>
        MqttClientTlsOptions TlsOptions { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttClientCredentialsProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        string GetUserName(MqttClientOptions clientOptions);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        byte[] GetPassword(MqttClientOptions clientOptions);
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientCertificateValidationEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate Certificate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public X509Chain Chain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SslPolicyErrors SslPolicyErrors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IMqttClientChannelOptions ClientOptions { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientCredentials : IMqttClientCredentialsProvider
    {
        readonly string _userName;
        readonly byte[] _password;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public MqttClientCredentials(string userName, byte[] password = null)
        {
            _userName = userName;
            _password = password;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        public string GetUserName(MqttClientOptions clientOptions)
        {
            return _userName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        public byte[] GetPassword(MqttClientOptions clientOptions)
        {
            return _password;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientDefaultCertificateValidationHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public static bool Handle(MqttClientCertificateValidationEventArgs eventArgs)
        {
            if (eventArgs.SslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            if (eventArgs.Chain.ChainStatus.Any(c =>
                    c.Status == X509ChainStatusFlags.RevocationStatusUnknown || c.Status == X509ChainStatusFlags.Revoked || c.Status == X509ChainStatusFlags.OfflineRevocation))
            {
                if (eventArgs.ClientOptions?.TlsOptions?.IgnoreCertificateRevocationErrors != true)
                {
                    return false;
                }
            }

            if (eventArgs.Chain.ChainStatus.Any(c => c.Status == X509ChainStatusFlags.PartialChain))
            {
                if (eventArgs.ClientOptions?.TlsOptions?.IgnoreCertificateChainErrors != true)
                {
                    return false;
                }
            }

            return eventArgs.ClientOptions?.TlsOptions?.AllowUntrustedCertificates == true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientOptions
    {
        /// <summary>
        ///     Gets or sets the authentication data.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public byte[] AuthenticationData { get; set; }

        /// <summary>
        ///     Gets or sets the authentication method.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public string AuthenticationMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IMqttClientChannelOptions ChannelOptions { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether clean sessions are used or not.
        ///     When a client connects to a broker it can connect using either a non persistent connection (clean session) or a
        ///     persistent connection.
        ///     With a non persistent connection the broker doesn't store any subscription information or undelivered messages for
        ///     the client.
        ///     This mode is ideal when the client only publishes messages.
        ///     It can also connect as a durable client using a persistent connection.
        ///     In this mode, the broker will store subscription information, and undelivered messages for the client.
        /// </summary>
        public bool CleanSession { get; set; } = true;

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; set; } = Guid.NewGuid().ToString("N");
        /// <summary>
        /// 
        /// </summary>
        public IMqttClientCredentialsProvider Credentials { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IMqttExtendedAuthenticationExchangeHandler ExtendedAuthenticationExchangeHandler { get; set; }

        /// <summary>
        ///     Gets or sets the keep alive period.
        ///     The connection is normally left open by the client so that is can send and receive data at any time.
        ///     If no data flows over an open connection for a certain time period then the client will generate a PINGREQ and
        ///     expect to receive a PINGRESP from the broker.
        ///     This message exchange confirms that the connection is open and working.
        ///     This period is known as the keep alive period.
        /// </summary>
        public TimeSpan KeepAlivePeriod { get; set; } = TimeSpan.FromSeconds(15);
        /// <summary>
        /// 
        /// </summary>
        public uint MaximumPacketSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttProtocolVersion ProtocolVersion { get; set; } = MqttProtocolVersion.V311;

        /// <summary>
        ///     Gets or sets the receive maximum.
        ///     This gives the maximum length of the receive messages.
        /// </summary>
        public ushort ReceiveMaximum { get; set; }

        /// <summary>
        ///     Gets or sets the request problem information.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public bool RequestProblemInformation { get; set; } = true;

        /// <summary>
        ///     Gets or sets the request response information.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public bool RequestResponseInformation { get; set; }

        /// <summary>
        ///     Gets or sets the session expiry interval.
        ///     The time after a session expires when it's not actively used.
        /// </summary>
        public uint SessionExpiryInterval { get; set; }

        /// <summary>
        ///     Gets or sets the timeout which will be applied at socket level and internal operations.
        ///     The default value is the same as for sockets in .NET in general.
        /// </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(100);

        /// <summary>
        ///     Gets or sets the topic alias maximum.
        ///     This gives the maximum length of the topic alias.
        /// </summary>
        public ushort TopicAliasMaximum { get; set; }

        /// <summary>
        ///     If set to true, the bridge will attempt to indicate to the remote broker that it is a bridge not an ordinary
        ///     client.
        ///     If successful, this means that loop detection will be more effective and that retained messages will be propagated
        ///     correctly.
        ///     Not all brokers support this feature so it may be necessary to set it to false if your bridge does not connect
        ///     properly.
        /// </summary>
        public bool TryPrivate { get; set; } = true;

        /// <summary>
        ///     Gets or sets the user properties.
        ///     In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT
        ///     packet.
        ///     As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add
        ///     metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        ///     The feature is very similar to the HTTP header concept.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }

        /// <summary>
        ///     Gets or sets the content type of the will message.
        /// </summary>
        public string WillContentType { get; set; }

        /// <summary>
        ///     Gets or sets the correlation data of the will message.
        /// </summary>
        public byte[] WillCorrelationData { get; set; }

        /// <summary>
        ///     Gets or sets the will delay interval.
        ///     This is the time between the client disconnect and the time the will message will be sent.
        /// </summary>
        public uint WillDelayInterval { get; set; }

        /// <summary>
        ///     Gets or sets the message expiry interval of the will message.
        /// </summary>
        public uint WillMessageExpiryInterval { get; set; }

        /// <summary>
        ///     Gets or sets the payload of the will message.
        /// </summary>
        public byte[] WillPayload { get; set; }

        /// <summary>
        ///     Gets or sets the payload format indicator of the will message.
        /// </summary>
        public MqttPayloadFormatIndicator WillPayloadFormatIndicator { get; set; }

        /// <summary>
        ///     Gets or sets the QoS level of the will message.
        /// </summary>
        public MqttQualityOfServiceLevel WillQualityOfServiceLevel { get; set; }

        /// <summary>
        ///     Gets or sets the response topic of the will message.
        /// </summary>
        public string WillResponseTopic { get; set; }

        /// <summary>
        ///     Gets or sets the retain flag of the will message.
        /// </summary>
        public bool WillRetain { get; set; }

        /// <summary>
        ///     Gets or sets the topic of the will message.
        /// </summary>
        public string WillTopic { get; set; }

        /// <summary>
        ///     Gets or sets the user properties of the will message.
        /// </summary>
        public List<MqttUserProperty> WillUserProperties { get; set; }

        /// <summary>
        ///     Gets or sets the default and initial size of the packet write buffer.
        ///     It is recommended to set this to a value close to the usual expected packet size * 1.5.
        ///     Do not change this value when no memory issues are experienced.
        /// </summary>
        public int WriterBufferSize { get; set; } = 4096;

        /// <summary>
        ///     Gets or sets the maximum size of the buffer writer. The writer will reduce its internal buffer
        ///     to this value after serializing a packet.
        ///     Do not change this value when no memory issues are experienced.
        /// </summary>
        public int WriterBufferSizeMax { get; set; } = 65535;
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientOptionsBuilder
    {
        readonly MqttClientOptions _options = new MqttClientOptions();
        MqttClientWebSocketProxyOptions _proxyOptions;

        MqttClientTcpOptions _tcpOptions;
        MqttClientOptionsBuilderTlsParameters _tlsParameters;
        MqttClientWebSocketOptions _webSocketOptions;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public MqttClientOptions Build()
        {
            if (_tcpOptions == null && _webSocketOptions == null)
            {
                throw new InvalidOperationException("A channel must be set.");
            }

            if (_tlsParameters != null)
            {
                if (_tlsParameters?.UseTls == true)
                {
                    var tlsOptions = new MqttClientTlsOptions
                    {
                        UseTls = true,
                        SslProtocol = _tlsParameters.SslProtocol,
                        AllowUntrustedCertificates = _tlsParameters.AllowUntrustedCertificates,
                        CertificateValidationHandler = _tlsParameters.CertificateValidationHandler,
                        IgnoreCertificateChainErrors = _tlsParameters.IgnoreCertificateChainErrors,
                        IgnoreCertificateRevocationErrors = _tlsParameters.IgnoreCertificateRevocationErrors,
#if WINDOWS_UWP
                        Certificates = _tlsParameters.Certificates?.Select(c => c.ToArray()).ToList(),
#else
                        Certificates = _tlsParameters.Certificates?.ToList(),
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
                        ApplicationProtocols = _tlsParameters.ApplicationProtocols,
#endif
                    };

                    if (_tcpOptions != null)
                    {
                        _tcpOptions.TlsOptions = tlsOptions;
                    }
                    else if (_webSocketOptions != null)
                    {
                        _webSocketOptions.TlsOptions = tlsOptions;
                    }
                }
            }

            if (_proxyOptions != null)
            {
                if (_webSocketOptions == null)
                {
                    throw new InvalidOperationException("Proxies are only supported for WebSocket connections.");
                }

                _webSocketOptions.ProxyOptions = _proxyOptions;
            }

            _options.ChannelOptions = (IMqttClientChannelOptions)_tcpOptions ?? _webSocketOptions;

            return _options;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithAuthentication(string method, byte[] data)
        {
            _options.AuthenticationMethod = method;
            _options.AuthenticationData = data;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithCleanSession(bool value = true)
        {
            _options.CleanSession = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithClientId(string value)
        {
            _options.ClientId = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public MqttClientOptionsBuilder WithConnectionUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var port = uri.IsDefaultPort ? null : (int?)uri.Port;
            switch (uri.Scheme.ToLower())
            {
                case "tcp":
                case "mqtt":
                    WithTcpServer(uri.Host, port);
                    break;

                case "mqtts":
                    WithTcpServer(uri.Host, port).WithTls();
                    break;

                case "ws":
                case "wss":
                    WithWebSocketServer(uri.ToString());
                    break;

                default:
                    throw new ArgumentException("Unexpected scheme in uri.");
            }

            if (!string.IsNullOrEmpty(uri.UserInfo))
            {
                var userInfo = uri.UserInfo.Split(':');
                var username = userInfo[0];
                var password = userInfo.Length > 1 ? userInfo[1] : "";
                WithCredentials(username, password);
            }

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithConnectionUri(string uri)
        {
            return WithConnectionUri(new Uri(uri, UriKind.Absolute));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithCredentials(string username, string password)
        {
            byte[] passwordBuffer = null;

            if (password != null)
            {
                passwordBuffer = Encoding.UTF8.GetBytes(password);
            }

            return WithCredentials(username, passwordBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithCredentials(string username, byte[] password = null)
        {
            return WithCredentials(new MqttClientCredentials(username, password));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithCredentials(IMqttClientCredentialsProvider credentials)
        {
            _options.Credentials = credentials;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithExtendedAuthenticationExchangeHandler(IMqttExtendedAuthenticationExchangeHandler handler)
        {
            _options.ExtendedAuthenticationExchangeHandler = handler;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithKeepAlivePeriod(TimeSpan value)
        {
            _options.KeepAlivePeriod = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maximumPacketSize"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithMaximumPacketSize(uint maximumPacketSize)
        {
            _options.MaximumPacketSize = maximumPacketSize;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithNoKeepAlive()
        {
            return WithKeepAlivePeriod(TimeSpan.Zero);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public MqttClientOptionsBuilder WithProtocolVersion(MqttProtocolVersion value)
        {
            if (value == MqttProtocolVersion.Unknown)
            {
                throw new ArgumentException("Protocol version is invalid.");
            }

            _options.ProtocolVersion = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="bypassOnLocal"></param>
        /// <param name="bypassList"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithProxy(
            string address,
            string username = null,
            string password = null,
            string domain = null,
            bool bypassOnLocal = false,
            string[] bypassList = null)
        {
            _proxyOptions = new MqttClientWebSocketProxyOptions
            {
                Address = address,
                Username = username,
                Password = password,
                Domain = domain,
                BypassOnLocal = bypassOnLocal,
                BypassList = bypassList
            };

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientOptionsBuilder WithProxy(Action<MqttClientWebSocketProxyOptions> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            _proxyOptions = new MqttClientWebSocketProxyOptions();
            optionsBuilder(_proxyOptions);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiveMaximum"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithReceiveMaximum(ushort receiveMaximum)
        {
            _options.ReceiveMaximum = receiveMaximum;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestProblemInformation"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithRequestProblemInformation(bool requestProblemInformation = true)
        {
            _options.RequestProblemInformation = requestProblemInformation;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestResponseInformation"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithRequestResponseInformation(bool requestResponseInformation = true)
        {
            _options.RequestResponseInformation = requestResponseInformation;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionExpiryInterval"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithSessionExpiryInterval(uint sessionExpiryInterval)
        {
            _options.SessionExpiryInterval = sessionExpiryInterval;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithTcpServer(string server, int? port = null)
        {
            _tcpOptions = new MqttClientTcpOptions
            {
                Server = server,
                Port = port
            };

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientOptionsBuilder WithTcpServer(Action<MqttClientTcpOptions> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            _tcpOptions = new MqttClientTcpOptions();
            optionsBuilder.Invoke(_tcpOptions);

            return this;
        }

        /// <summary>
        ///     Sets the timeout which will be applied at socket level and internal operations.
        ///     The default value is the same as for sockets in .NET in general.
        /// </summary>
        public MqttClientOptionsBuilder WithTimeout(TimeSpan value)
        {
            _options.Timeout = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithTls(MqttClientOptionsBuilderTlsParameters parameters)
        {
            _tlsParameters = parameters;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithTls()
        {
            return WithTls(new MqttClientOptionsBuilderTlsParameters { UseTls = true });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientOptionsBuilder WithTls(Action<MqttClientOptionsBuilderTlsParameters> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            _tlsParameters = new MqttClientOptionsBuilderTlsParameters
            {
                UseTls = true
            };

            optionsBuilder(_tlsParameters);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicAliasMaximum"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithTopicAliasMaximum(ushort topicAliasMaximum)
        {
            _options.TopicAliasMaximum = topicAliasMaximum;
            return this;
        }

        /// <summary>
        ///     If set to true, the bridge will attempt to indicate to the remote broker that it is a bridge not an ordinary
        ///     client.
        ///     If successful, this means that loop detection will be more effective and that retained messages will be propagated
        ///     correctly.
        ///     Not all brokers support this feature so it may be necessary to set it to false if your bridge does not connect
        ///     properly.
        /// </summary>
        public MqttClientOptionsBuilder WithTryPrivate(bool tryPrivate = true)
        {
            _options.TryPrivate = true;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientOptionsBuilder WithUserProperty(string name, string value)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (_options.UserProperties == null)
            {
                _options.UserProperties = new List<MqttUserProperty>();
            }

            _options.UserProperties.Add(new MqttUserProperty(name, value));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWebSocketServer(string uri, MqttClientOptionsBuilderWebSocketParameters parameters = null)
        {
            _webSocketOptions = new MqttClientWebSocketOptions
            {
                Uri = uri,
                RequestHeaders = parameters?.RequestHeaders,
                CookieContainer = parameters?.CookieContainer
            };

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientOptionsBuilder WithWebSocketServer(Action<MqttClientWebSocketOptions> optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            _webSocketOptions = new MqttClientWebSocketOptions();
            optionsBuilder.Invoke(_webSocketOptions);

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willDelayInterval"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillDelayInterval(uint willDelayInterval)
        {
            _options.WillDelayInterval = willDelayInterval;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willPayload"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillPayload(byte[] willPayload)
        {
            _options.WillPayload = willPayload;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willPayload"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillPayload(string willPayload)
        {
            if (string.IsNullOrEmpty(willPayload))
            {
                return WithWillPayload((byte[])null);
            }

            _options.WillPayload = Encoding.UTF8.GetBytes(willPayload);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willQualityOfServiceLevel"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillQualityOfServiceLevel(MqttQualityOfServiceLevel willQualityOfServiceLevel)
        {
            _options.WillQualityOfServiceLevel = willQualityOfServiceLevel;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willTopic"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillTopic(string willTopic)
        {
            _options.WillTopic = willTopic;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willRetain"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillRetain(bool willRetain = true)
        {
            _options.WillRetain = willRetain;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willContentType"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillContentType(string willContentType)
        {
            _options.WillContentType = willContentType;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willCorrelationData"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillCorrelationData(byte[] willCorrelationData)
        {
            _options.WillCorrelationData = willCorrelationData;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willResponseTopic"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillResponseTopic(string willResponseTopic)
        {
            _options.WillResponseTopic = willResponseTopic;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="willPayloadFormatIndicator"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillPayloadFormatIndicator(MqttPayloadFormatIndicator willPayloadFormatIndicator)
        {
            _options.WillPayloadFormatIndicator = willPayloadFormatIndicator;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttClientOptionsBuilder WithWillUserProperty(string name, string value)
        {
            if (_options.WillUserProperties == null)
            {
                _options.WillUserProperties = new List<MqttUserProperty>();
            }

            _options.WillUserProperties.Add(new MqttUserProperty(name, value));
            return this;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientOptionsBuilderTlsParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public bool UseTls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Func<MqttClientCertificateValidationEventArgs, bool> CertificateValidationHandler { get; set; }

#if NET40 || NET45 || NETStd
        /// <summary>
        /// 
        /// </summary>
        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00 /*Tls12*/ | (SslProtocols)0x00003000 /*Tls13*/;
#else
        /// <summary>
        /// 
        /// </summary>
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#endif

#if WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<IEnumerable<byte>> Certificates { get; set; }
#else
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<X509Certificate> Certificates { get; set; }
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        public List<SslApplicationProtocol> ApplicationProtocols { get;set; }
#endif

        /// <summary>
        /// 
        /// </summary>
        public bool AllowUntrustedCertificates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreCertificateChainErrors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreCertificateRevocationErrors { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttClientOptionsBuilderWebSocketParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> RequestHeaders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CookieContainer CookieContainer { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientTcpOptions : IMqttClientChannelOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressFamily AddressFamily { get; set; } = AddressFamily.Unspecified;

        /// <summary>
        /// Gets the local endpoint (network card) which is used by the client.
        /// Set it to _null_ to let the OS select the network card.
        /// </summary>
        public EndPoint LocalEndpoint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BufferSize { get; set; } = 8192;

        /// <summary>
        /// Gets or sets whether the underlying socket should run in dual mode.
        /// Leaving this _null_ will avoid setting this value at socket level.
        /// Setting this a value other than _null_ will throw an exception when only IPv4 is supported on the machine.
        /// </summary>
        public bool? DualMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LingerOption LingerState { get; set; } = new LingerOption(true, 0);
        /// <summary>
        /// 
        /// </summary>
        public bool NoDelay { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public int? Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Server + ":" + this.GetPort();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientTlsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Func<MqttClientCertificateValidationEventArgs, bool> CertificateValidationHandler { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UseTls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreCertificateRevocationErrors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IgnoreCertificateChainErrors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AllowUntrustedCertificates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public X509RevocationMode RevocationMode { get; set; } = X509RevocationMode.Online;

#if WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        public List<byte[]> Certificates { get; set; }
#else
        /// <summary>
        /// 
        /// </summary>
        public List<X509Certificate> Certificates { get; set; }
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        public List<System.Net.Security.SslApplicationProtocol> ApplicationProtocols { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.Net.Security.CipherSuitesPolicy CipherSuitesPolicy { get; set; }
#endif

        /// <summary>
        /// 
        /// </summary>
#if NET40 || NET45 || NETStd
        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00 /*Tls12*/ | (SslProtocols)0x00003000 /*Tls13*/;
#else
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#endif
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientWebSocketOptions : IMqttClientChannelOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public CookieContainer CookieContainer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientWebSocketProxyOptions ProxyOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> RequestHeaders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> SubProtocols { get; set; } = new List<string> { "mqtt" };
        /// <summary>
        /// 
        /// </summary>
        public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();
        /// <summary>
        /// 
        /// </summary>
        public string Uri { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Uri;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientWebSocketProxyOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool BypassOnLocal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] BypassList { get; set; }
    }
    #endregion Options
    #region // Publishing
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientPublishResult
    {
        /// <summary>
        /// Returns if the overall status of the publish is a success. This can be the reason code _Success_ or
        /// _NoMatchingSubscribers_. _NoMatchingSubscribers_ usually indicates only that no other client is interested in the topic but overall transmit
        /// to the server etc. was a success.
        /// </summary>
        public bool IsSuccess => ReasonCode == MqttClientPublishReasonCode.Success || ReasonCode == MqttClientPublishReasonCode.NoMatchingSubscribers;

        /// <summary>
        /// Gets the packet identifier which was used for this publish.
        /// </summary>
        public ushort? PacketIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the reason code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientPublishReasonCode ReasonCode { get; set; } = MqttClientPublishReasonCode.Success;

        /// <summary>
        /// Gets or sets the reason string.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        /// Gets or sets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT
        /// packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add
        /// metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public IReadOnlyCollection<MqttUserProperty> UserProperties { get; internal set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientPublishResultFactory
    {
        static readonly MqttClientPublishResult EmptySuccessResult = new MqttClientPublishResult();
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubAckPacket"></param>
        /// <returns></returns>
        public MqttClientPublishResult Create(MqttPubAckPacket pubAckPacket)
        {
            // QoS 0 has no response. So we treat it as a success always.
            if (pubAckPacket == null)
            {
                return EmptySuccessResult;
            }

            var result = new MqttClientPublishResult
            {
                // Both enums have the same values. So it can be easily converted.
                ReasonCode = (MqttClientPublishReasonCode)(int)pubAckPacket.ReasonCode,
                PacketIdentifier = pubAckPacket.PacketIdentifier,
                ReasonString = pubAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubAckPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                UserProperties = pubAckPacket.UserProperties ?? EmptyUserProperties
#endif
            };

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubRecPacket"></param>
        /// <param name="pubCompPacket"></param>
        /// <returns></returns>
        public MqttClientPublishResult Create(MqttPubRecPacket pubRecPacket, MqttPubCompPacket pubCompPacket)
        {
            if (pubRecPacket == null || pubCompPacket == null)
            {
                return new MqttClientPublishResult
                {
                    ReasonCode = MqttClientPublishReasonCode.UnspecifiedError
                };
            }

            MqttClientPublishResult result;

            // The PUBCOMP is the last packet in QoS 2. So we use the results from that instead of PUBREC.
            if (pubCompPacket.ReasonCode == MqttPubCompReasonCode.PacketIdentifierNotFound)
            {
                result = new MqttClientPublishResult
                {
                    PacketIdentifier = pubCompPacket.PacketIdentifier,
                    ReasonCode = MqttClientPublishReasonCode.UnspecifiedError,
                    ReasonString = pubCompPacket.ReasonString,
#if NET40
                    UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubCompPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                    UserProperties = pubCompPacket.UserProperties ?? EmptyUserProperties
#endif
                };

                return result;
            }

            result = new MqttClientPublishResult
            {
                PacketIdentifier = pubCompPacket.PacketIdentifier,
                ReasonCode = MqttClientPublishReasonCode.Success,
                ReasonString = pubCompPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(pubCompPacket.UserProperties ?? new List<MqttUserProperty>())
#else
                UserProperties = pubCompPacket.UserProperties ?? EmptyUserProperties
#endif
            };

            if (pubRecPacket.ReasonCode != MqttPubRecReasonCode.Success)
            {
                // Both enums share the same values.
                result.ReasonCode = (MqttClientPublishReasonCode)pubRecPacket.ReasonCode;
            }

            return result;
        }
    }
    #endregion Publishing
    #region // Receiving
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttApplicationMessageReceivedEventArgs : EventArgs
    {
        readonly Func<MqttApplicationMessageReceivedEventArgs, CancellationToken, Task> _acknowledgeHandler;

        int _isAcknowledged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="applicationMessage"></param>
        /// <param name="publishPacket"></param>
        /// <param name="acknowledgeHandler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttApplicationMessageReceivedEventArgs(
            string clientId,
            MqttApplicationMessage applicationMessage,
            MqttPublishPacket publishPacket,
            Func<MqttApplicationMessageReceivedEventArgs, CancellationToken, Task> acknowledgeHandler)
        {
            ClientId = clientId;
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            PublishPacket = publishPacket ?? throw new ArgumentNullException(nameof(publishPacket));
            _acknowledgeHandler = acknowledgeHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; }

        /// <summary>
        ///     Gets or sets whether the library should send MQTT ACK packets automatically if required.
        /// </summary>
        public bool AutoAcknowledge { get; set; } = true;

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets or sets whether this message was handled.
        ///     This value can be used in user code for custom control flow.
        /// </summary>
        public bool IsHandled { get; set; }

        /// <summary>
        ///     Gets the identifier of the MQTT packet
        /// </summary>
        public ushort PacketIdentifier => PublishPacket.PacketIdentifier;

        /// <summary>
        ///     Indicates if the processing of this PUBLISH packet has failed.
        ///     If the processing has failed the client will not send an ACK packet etc.
        /// </summary>
        public bool ProcessingFailed { get; set; }

        /// <summary>
        ///     Gets or sets the reason code which will be sent to the server.
        /// </summary>
        public MqttApplicationMessageReceivedReasonCode ReasonCode { get; set; } = MqttApplicationMessageReceivedReasonCode.Success;

        /// <summary>
        ///     Gets or sets the reason string which will be sent to the server in the ACK packet.
        /// </summary>
        public string ResponseReasonString { get; set; }

        /// <summary>
        ///     Gets or sets the user properties which will be sent to the server in the ACK packet etc.
        /// </summary>
        public List<MqttUserProperty> ResponseUserProperties { get; } = new List<MqttUserProperty>();
        /// <summary>
        /// 
        /// </summary>
        public object Tag { get; set; }

        internal MqttPublishPacket PublishPacket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Task AcknowledgeAsync(CancellationToken cancellationToken)
        {
            if (_acknowledgeHandler == null)
            {
                throw new NotSupportedException("Deferred acknowledgement of application message is not yet supported in MQTTnet server.");
            }

            if (Interlocked.CompareExchange(ref _isAcknowledged, 1, 0) == 0)
            {
                return _acknowledgeHandler(this, cancellationToken);
            }

            throw new InvalidOperationException("The application message is already acknowledged.");
        }
    }
    #endregion Receiving
    #region // Subscribing
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscribeOptions
    {
        /// <summary>
        /// Gets or sets a list of topic filters the client wants to subscribe to.
        /// Topic filters can include regular topics or wild cards.
        /// </summary>
        public List<MqttTopicFilter> TopicFilters { get; set; } = new List<MqttTopicFilter>();

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// The client can specify a subscription identifier when subscribing.
        /// The broker will establish and store the mapping relationship between this subscription and subscription identifier when successfully create or modify subscription.
        /// The broker will return the subscription identifier associated with this PUBLISH packet and the PUBLISH packet to the client when need to forward PUBLISH packets matching this subscription to this client.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public uint SubscriptionIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscribeOptionsBuilder
    {
        readonly MqttClientSubscribeOptions _subscribeOptions = new MqttClientSubscribeOptions();

        /// <summary>
        /// Adds the user property to the subscribe options.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>A new instance of the <see cref="MqttApplicationMessageBuilder"/> class.</returns>
        public MqttClientSubscribeOptionsBuilder WithUserProperty(string name, string value)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (_subscribeOptions.UserProperties == null)
            {
                _subscribeOptions.UserProperties = new List<MqttUserProperty>();
            }

            _subscribeOptions.UserProperties.Add(new MqttUserProperty(name, value));

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionIdentifier"></param>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttClientSubscribeOptionsBuilder WithSubscriptionIdentifier(uint subscriptionIdentifier)
        {
            if (subscriptionIdentifier == 0)
            {
                throw new MqttProtocolViolationException("Subscription identifier cannot be 0.");
            }

            _subscribeOptions.SubscriptionIdentifier = subscriptionIdentifier;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="noLocal"></param>
        /// <param name="retainAsPublished"></param>
        /// <param name="retainHandling"></param>
        /// <returns></returns>
        public MqttClientSubscribeOptionsBuilder WithTopicFilter(
            string topic,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            bool noLocal = false,
            bool retainAsPublished = false,
            MqttRetainHandling retainHandling = MqttRetainHandling.SendAtSubscribe)
        {
            return WithTopicFilter(new MqttTopicFilter
            {
                Topic = topic,
                QualityOfServiceLevel = qualityOfServiceLevel,
                NoLocal = noLocal,
                RetainAsPublished = retainAsPublished,
                RetainHandling = retainHandling
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicFilterBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientSubscribeOptionsBuilder WithTopicFilter(Action<MqttTopicFilterBuilder> topicFilterBuilder)
        {
            if (topicFilterBuilder == null) throw new ArgumentNullException(nameof(topicFilterBuilder));

            var internalTopicFilterBuilder = new MqttTopicFilterBuilder();
            topicFilterBuilder(internalTopicFilterBuilder);

            return WithTopicFilter(internalTopicFilterBuilder);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicFilterBuilder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientSubscribeOptionsBuilder WithTopicFilter(MqttTopicFilterBuilder topicFilterBuilder)
        {
            if (topicFilterBuilder == null) throw new ArgumentNullException(nameof(topicFilterBuilder));

            return WithTopicFilter(topicFilterBuilder.Build());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicFilter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientSubscribeOptionsBuilder WithTopicFilter(MqttTopicFilter topicFilter)
        {
            if (topicFilter == null) throw new ArgumentNullException(nameof(topicFilter));

            if (_subscribeOptions.TopicFilters == null)
            {
                _subscribeOptions.TopicFilters = new List<MqttTopicFilter>();
            }

            _subscribeOptions.TopicFilters.Add(topicFilter);

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientSubscribeOptions Build()
        {
            return _subscribeOptions;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscribeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<MqttClientSubscribeResultItem> Items { get; internal set; }

        /// <summary>
        /// Gets the user properties which were part of the SUBACK packet.
        /// MQTTv5 only.
        /// </summary>
        public IReadOnlyCollection<MqttUserProperty> UserProperties { get; internal set; }

        /// <summary>
        /// Gets the reason string.
        /// MQTTv5 only.
        /// </summary>
        public string ReasonString { get; internal set; }

        /// <summary>
        /// Gets the packet identifier which was used.
        /// </summary>
        public ushort PacketIdentifier { get; internal set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscribeResultFactory
    {
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribePacket"></param>
        /// <param name="subAckPacket"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttClientSubscribeResult Create(MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
        {
            if (subscribePacket == null) throw new ArgumentNullException(nameof(subscribePacket));
            if (subAckPacket == null) throw new ArgumentNullException(nameof(subAckPacket));

            // MQTTv5.0.0 handling.
            if (subAckPacket.ReasonCodes.Any() && subAckPacket.ReasonCodes.Count != subscribePacket.TopicFilters.Count)
            {
                throw new MqttProtocolViolationException(
                    "The reason codes are not matching the topic filters [MQTT-3.9.3-1].");
            }

            var items = new List<MqttClientSubscribeResultItem>();
            for (var i = 0; i < subscribePacket.TopicFilters.Count; i++)
            {
                items.Add(CreateSubscribeResultItem(i, subscribePacket, subAckPacket));
            }

            var result = new MqttClientSubscribeResult
            {
                PacketIdentifier = subAckPacket.PacketIdentifier,
                ReasonString = subAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(subAckPacket.UserProperties ?? new List<MqttUserProperty>()),
                Items = new EReadOnlyCollection<MqttClientSubscribeResultItem>(items)
#else
                UserProperties = subAckPacket.UserProperties ?? EmptyUserProperties,
                Items = items
#endif
            };

            return result;
        }

        static MqttClientSubscribeResultItem CreateSubscribeResultItem(int index, MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
        {
            var resultCode = (MqttClientSubscribeResultCode)subAckPacket.ReasonCodes[index];

            return new MqttClientSubscribeResultItem
            {
                TopicFilter = subscribePacket.TopicFilters[index],
                ResultCode = resultCode,
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscribeResultItem
    {
        /// <summary>
        /// Gets or sets the topic filter.
        /// The topic filter can contain topics and wildcards.
        /// </summary>
        public MqttTopicFilter TopicFilter { get; internal set; }

        /// <summary>
        /// Gets or sets the result code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientSubscribeResultCode ResultCode { get; internal set; }
    }
    #endregion Subscribing
    #region // Unsubscribing
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientUnsubscribeOptions
    {
        /// <summary>
        /// Gets or sets a list of topic filters the client wants to unsubscribe from.
        /// Topic filters can include regular topics or wild cards.
        /// </summary>
        public List<string> TopicFilters { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the user properties.
        /// In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT packet.
        /// As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        /// The feature is very similar to the HTTP header concept.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; } = new List<MqttUserProperty>();
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttClientUnsubscribeOptionsBuilder
    {
        private readonly MqttClientUnsubscribeOptions _unsubscribeOptions = new MqttClientUnsubscribeOptions();

        /// <summary>
        /// Adds the user property to the unsubscribe options.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>A new instance of the <see cref="MqttClientUnsubscribeOptionsBuilder"/> class.</returns>
        public MqttClientUnsubscribeOptionsBuilder WithUserProperty(string name, string value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (value is null) throw new ArgumentNullException(nameof(value));

            return WithUserProperty(new MqttUserProperty(name, value));
        }

        /// <summary>
        /// Adds the user property to the unsubscribe options.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        /// <param name="userProperty">The user property.</param>
        /// <returns>A new instance of the <see cref="MqttClientUnsubscribeOptionsBuilder"/> class.</returns>
        public MqttClientUnsubscribeOptionsBuilder WithUserProperty(MqttUserProperty userProperty)
        {
            if (userProperty is null) throw new ArgumentNullException(nameof(userProperty));

            if (_unsubscribeOptions.UserProperties is null)
            {
                _unsubscribeOptions.UserProperties = new List<MqttUserProperty>();
            }

            _unsubscribeOptions.UserProperties.Add(userProperty);

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientUnsubscribeOptionsBuilder WithTopicFilter(string topic)
        {
            if (topic is null) throw new ArgumentNullException(nameof(topic));

            if (_unsubscribeOptions.TopicFilters is null)
            {
                _unsubscribeOptions.TopicFilters = new List<string>();
            }

            _unsubscribeOptions.TopicFilters.Add(topic);

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicFilter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientUnsubscribeOptionsBuilder WithTopicFilter(MqttTopicFilter topicFilter)
        {
            if (topicFilter is null) throw new ArgumentNullException(nameof(topicFilter));

            return WithTopicFilter(topicFilter.Topic);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttClientUnsubscribeOptions Build()
        {
            return _unsubscribeOptions;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientUnsubscribeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<MqttClientUnsubscribeResultItem> Items { get; internal set; }

        /// <summary>
        /// Gets the user properties which were part of the UNSUBACK packet.
        /// MQTTv5 only.
        /// </summary>
        public IReadOnlyCollection<MqttUserProperty> UserProperties { get; internal set; }

        /// <summary>
        /// Gets the reason string.
        /// MQTTv5 only.
        /// </summary>
        public string ReasonString { get; internal set; }

        /// <summary>
        /// Gets the packet identifier which was used.
        /// </summary>
        public ushort PacketIdentifier { get; internal set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientUnsubscribeResultFactory
    {
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unsubscribePacket"></param>
        /// <param name="unsubAckPacket"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttClientUnsubscribeResult Create(MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
        {
            if (unsubscribePacket == null) throw new ArgumentNullException(nameof(unsubscribePacket));
            if (unsubAckPacket == null) throw new ArgumentNullException(nameof(unsubAckPacket));

            // MQTTv3.1.1 has no reason code at all!
            if (unsubAckPacket.ReasonCodes != null && unsubAckPacket.ReasonCodes.Count != unsubscribePacket.TopicFilters.Count)
            {
                throw new MqttProtocolViolationException(
                    "The return codes are not matching the topic filters [MQTT-3.9.3-1].");
            }

            var items = new List<MqttClientUnsubscribeResultItem>();
            for (var i = 0; i < unsubscribePacket.TopicFilters.Count; i++)
            {
                items.Add(CreateUnsubscribeResultItem(i, unsubscribePacket, unsubAckPacket));
            }

            var result = new MqttClientUnsubscribeResult
            {
                PacketIdentifier = unsubAckPacket.PacketIdentifier,
                ReasonString = unsubAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(unsubAckPacket.UserProperties ?? new List<MqttUserProperty>()),
                Items = new EReadOnlyCollection<MqttClientUnsubscribeResultItem>(items)
#else
                UserProperties = unsubAckPacket.UserProperties ?? EmptyUserProperties,
                Items = items
#endif
            };

            return result;
        }

        static MqttClientUnsubscribeResultItem CreateUnsubscribeResultItem(int index, MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
        {
            var resultCode = MqttClientUnsubscribeResultCode.Success;

            if (unsubAckPacket.ReasonCodes != null)
            {
                // MQTTv3.1.1 has no reason code and no return code!.
                resultCode = (MqttClientUnsubscribeResultCode)unsubAckPacket.ReasonCodes[index];
            }

            return new MqttClientUnsubscribeResultItem
            {
                TopicFilter = unsubscribePacket.TopicFilters[index],
                ResultCode = resultCode
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientUnsubscribeResultItem
    {
        /// <summary>
        /// Gets or sets the topic filter.
        /// The topic filter can contain topics and wildcards.
        /// </summary>
        public string TopicFilter { get; internal set; }

        /// <summary>
        /// Gets or sets the result code.
        /// Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientUnsubscribeResultCode ResultCode { get; internal set; }
    }
    #endregion Unsubscribing
    #endregion Client
    #region // Diagnostics
    #region // Logger
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttNetLogger
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        /// <param name="exception"></param>
        void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception);
    }
    /// <summary>
    ///     This logger fires an event when a new message was published.
    /// </summary>
    public sealed class MqttNetEventLogger : IMqttNetLogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logId"></param>
        public MqttNetEventLogger(string logId = null)
        {
            LogId = logId;
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<MqttNetLogMessagePublishedEventArgs> LogMessagePublished;
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled => LogMessagePublished != null;
        /// <summary>
        /// 
        /// </summary>
        public string LogId { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        /// <param name="exception"></param>
        public void Publish(MqttNetLogLevel level, string source, string message, object[] parameters, Exception exception)
        {
            var eventHandler = LogMessagePublished;
            if (eventHandler == null)
            {
                // No listener is attached so we can step out.
                // Keep a reference to the handler because the handler
                // might be null after preparing the message.
                return;
            }

            if (parameters?.Length > 0 && message?.Length > 0)
            {
                try
                {
                    message = string.Format(message, parameters);
                }
                catch (FormatException)
                {
                    message = "MESSAGE FORMAT INVALID: " + message;
                }
            }

            // We only use UTC here to improve performance. Using a local date time
            // would require to load the time zone settings!
            var logMessage = new MqttNetLogMessage
            {
                LogId = LogId,
                Timestamp = DateTime.UtcNow,
                Source = source,
#if NET40
                ThreadId = Thread.CurrentThread.ManagedThreadId,
#else
                ThreadId = Environment.CurrentManagedThreadId,
#endif
                Level = level,
                Message = message,
                Exception = exception
            };

            eventHandler.Invoke(this, new MqttNetLogMessagePublishedEventArgs(logMessage));
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttNetLogMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string LogId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ThreadId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttNetLogLevel Level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"[{Timestamp:O}] [{LogId}] [{ThreadId}] [{Source}] [{Level}]: {Message}";
            if (Exception != null)
            {
                result += Environment.NewLine + Exception;
            }

            return result;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttNetLogMessagePublishedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMessage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttNetLogMessagePublishedEventArgs(MqttNetLogMessage logMessage)
        {
            LogMessage = logMessage ?? throw new ArgumentNullException(nameof(logMessage));
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttNetLogMessage LogMessage { get; }
    }
    /// <summary>
    ///     This logger does nothing with the messages.
    /// </summary>
    public sealed class MqttNetNullLogger : IMqttNetLogger
    {
        /// <summary>
        /// 
        /// </summary>
        public MqttNetNullLogger()
        {
            IsEnabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public static MqttNetNullLogger Instance { get; } = new MqttNetNullLogger();
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        /// <param name="exception"></param>
        public void Publish(MqttNetLogLevel logLevel, string source, string message, object[] parameters, Exception exception)
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttNetSourceLogger
    {
        readonly IMqttNetLogger _logger;
        readonly string _source;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttNetSourceLogger(IMqttNetLogger logger, string source)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _source = source;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled => _logger.IsEnabled;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        /// <param name="exception"></param>
        public void Publish(MqttNetLogLevel logLevel, string message, object[] parameters, Exception exception)
        {
            _logger.Publish(logLevel, _source, message, parameters, exception);
        }
    }
    #endregion Logger
    #region // PacketInspection
    /// <summary>
    /// 
    /// </summary>
    public sealed class InspectMqttPacketEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public MqttPacketFlowDirection Direction { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Buffer { get; set; }
    }
    #endregion PacketInspection
    #endregion Diagnostics
    #region // Formatter
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttPacketFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        /// <returns></returns>
        MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttPacket"></param>
        /// <returns></returns>
        MqttPacketBuffer Encode(MqttPacket mqttPacket);
    }
    /// <summary>
    /// 
    /// </summary>
    public static class MqttApplicationMessageFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishPacket"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MqttApplicationMessage Create(MqttPublishPacket publishPacket)
        {
            if (publishPacket == null)
            {
                throw new ArgumentNullException(nameof(publishPacket));
            }

            return new MqttApplicationMessage
            {
                Topic = publishPacket.Topic,
                Payload = publishPacket.Payload,
                QualityOfServiceLevel = publishPacket.QualityOfServiceLevel,
                Retain = publishPacket.Retain,
                Dup = publishPacket.Dup,
                ResponseTopic = publishPacket.ResponseTopic,
                ContentType = publishPacket.ContentType,
                CorrelationData = publishPacket.CorrelationData,
                MessageExpiryInterval = publishPacket.MessageExpiryInterval,
                SubscriptionIdentifiers = publishPacket.SubscriptionIdentifiers,
                TopicAlias = publishPacket.TopicAlias,
                PayloadFormatIndicator = publishPacket.PayloadFormatIndicator,
                UserProperties = publishPacket.UserProperties
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttBufferReader
    {
        byte[] _buffer = EmptyBuffer.Array;
        int _maxPosition;
        int _offset;
        int _position;
        /// <summary>
        /// 
        /// </summary>
        public int BytesLeft => _maxPosition - _position;
        /// <summary>
        /// 
        /// </summary>
        public bool EndOfStream => BytesLeft == 0;
        /// <summary>
        /// 
        /// </summary>
        public int Position => _position - _offset;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ReadBinaryData()
        {
            var length = ReadTwoByteInteger();

            if (length == 0)
            {
                return EmptyBuffer.Array;
            }

            ValidateReceiveBuffer(length);

            var result = new byte[length];
            MqttMemoryHelper.Copy(_buffer, _position, result, 0, length);
            _position += length;

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            ValidateReceiveBuffer(1);
            return _buffer[_position++];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadFourByteInteger()
        {
            ValidateReceiveBuffer(4);

#if NETCOREAPP3_0_OR_GREATER
            var value = BinaryPrimitives.ReadUInt32BigEndian(_buffer.AsSpan(_position));
#else
            var byte0 = _buffer[_position];
            var byte1 = _buffer[_position + 1];
            var byte2 = _buffer[_position + 2];
            var byte3 = _buffer[_position + 3];

            var value = (uint)((byte0 << 24) | (byte1 << 16) | (byte2 << 8) | byte3);
#endif

            _position += 4;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ReadRemainingData()
        {
            var bufferLength = BytesLeft;
            if (bufferLength == 0)
            {
                return EmptyBuffer.Array;
            }

            var buffer = new byte[bufferLength];
            MqttMemoryHelper.Copy(_buffer, _position, buffer, 0, bufferLength);
            _position += bufferLength;

            return buffer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            var length = ReadTwoByteInteger();

            if (length == 0)
            {
                return string.Empty;
            }

            ValidateReceiveBuffer(length);

#if NETCOREAPP3_0_OR_GREATER
            // AsSpan() version is slightly faster. Not much but at least a little bit.
            var result = Encoding.UTF8.GetString(_buffer.AsSpan(_position, length));
#else
            var result = Encoding.UTF8.GetString(_buffer, _position, length);
#endif

            _position += length;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort ReadTwoByteInteger()
        {
            ValidateReceiveBuffer(2);

#if NETCOREAPP3_0_OR_GREATER
            var value = BinaryPrimitives.ReadUInt16BigEndian(_buffer.AsSpan(_position));
#else
            var msb = _buffer[_position];
            var lsb = _buffer[_position + 1];

            var value = (ushort)((msb << 8) | lsb);
#endif

            _position += 2;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public uint ReadVariableByteInteger()
        {
            var multiplier = 1;
            var value = 0U;
            byte encodedByte;

            do
            {
                encodedByte = ReadByte();
                value += (uint)((encodedByte & 127) * multiplier);

                if (multiplier > 2097152)
                {
                    throw new MqttProtocolViolationException("Variable length integer is invalid.");
                }

                multiplier *= 128;
            } while ((encodedByte & 128) != 0);

            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public void Seek(int position)
        {
            _position = _offset + position;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public void SetBuffer(ArraySegment<byte> buffer)
        {
            SetBuffer(buffer.Array, buffer.Offset, buffer.Count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetBuffer(byte[] buffer, int offset, int length)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            _offset = offset;
            _position = offset;
            _maxPosition = offset + length;
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        void ValidateReceiveBuffer(int length)
        {
            var newPosition = _position + length;
            if (_maxPosition < newPosition)
            {
                throw new MqttProtocolViolationException($"Expected at least {newPosition} bytes but there are only {_maxPosition} bytes");
            }
        }
    }
    /// <summary>
    ///     This is a custom implementation of a memory stream which provides only MQTTnet relevant features.
    ///     The goal is to avoid lots of argument checks like in the original stream. The growth rule is the
    ///     same as for the original MemoryStream in .net. Also this implementation allows accessing the internal
    ///     buffer for all platforms and .net framework versions (which is not available at the regular MemoryStream).
    /// </summary>
    public sealed class MqttBufferWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public const uint VariableByteIntegerMaxValue = 268435455;

        readonly int _maxBufferSize;

        byte[] _buffer;
        int _position;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferSize"></param>
        /// <param name="maxBufferSize"></param>
        public MqttBufferWriter(int bufferSize, int maxBufferSize)
        {
            _buffer = new byte[bufferSize];
            _maxBufferSize = maxBufferSize;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetType"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static byte BuildFixedHeader(MqttControlPacketType packetType, byte flags = 0)
        {
            var fixedHeader = (int)packetType << 4;
            fixedHeader |= flags;
            return (byte)fixedHeader;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Cleanup()
        {
            // This method frees the used memory by shrinking the buffer. This is required because the buffer
            // is used across several messages. In general this is not a big issue because subsequent Ping packages
            // have the same size but a very big publish package with 100 MB of payload will increase the buffer
            // a lot and the size will never reduced. So this method tries to find a size which can be held in
            // memory for a long time without causing troubles.

            if (_buffer.Length <= _maxBufferSize)
            {
                return;
            }

            // Create a new and empty buffer. Do not use Array.Resize because it will copy all data from
            // the old array to the new one which is not required in this case.
            _buffer = new byte[_maxBufferSize];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetBuffer()
        {
            return _buffer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetVariableByteIntegerSize(uint value)
        {
            // From RFC: Table 2.4 Size of Remaining Length field

            // 0 (0x00) to 127 (0x7F)
            if (value <= 127)
            {
                return 1;
            }

            // 128 (0x80, 0x01) to 16 383 (0xFF, 0x7F)
            if (value <= 16383)
            {
                return 2;
            }

            // 16 384 (0x80, 0x80, 0x01) to 2 097 151 (0xFF, 0xFF, 0x7F)
            if (value <= 2097151)
            {
                return 3;
            }

            // 2 097 152 (0x80, 0x80, 0x80, 0x01) to 268 435 455 (0xFF, 0xFF, 0xFF, 0x7F)
            return 4;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        public void Reset(int length)
        {
            _position = 0;
            Length = length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public void Seek(int position)
        {
            EnsureCapacity(position);
            _position = position;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyWriter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Write(MqttBufferWriter propertyWriter)
        {
            if (propertyWriter == null)
            {
                throw new ArgumentNullException(nameof(propertyWriter));
            }

            WriteBinary(propertyWriter._buffer, 0, propertyWriter.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void WriteBinary(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (count == 0)
            {
                return;
            }

            EnsureAdditionalCapacity(count);

            MqttMemoryHelper.Copy(buffer, offset, _buffer, _position, count);
            IncreasePosition(count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteBinaryData(byte[] value)
        {
            if (value == null || value.Length == 0)
            {
                EnsureAdditionalCapacity(2);

                _buffer[_position] = 0;
                _buffer[_position + 1] = 0;

                IncreasePosition(2);
            }
            else
            {
                var valueLength = value.Length;

                EnsureAdditionalCapacity(valueLength + 2);

                _buffer[_position] = (byte)(valueLength >> 8);
                _buffer[_position + 1] = (byte)valueLength;

                MqttMemoryHelper.Copy(value, 0, _buffer, _position + 2, valueLength);
                IncreasePosition(valueLength + 2);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byte"></param>
        public void WriteByte(byte @byte)
        {
            EnsureAdditionalCapacity(1);

            _buffer[_position] = @byte;
            IncreasePosition(1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                EnsureAdditionalCapacity(2);

                _buffer[_position] = 0;
                _buffer[_position + 1] = 0;

                IncreasePosition(2);
            }
            else
            {
                // Do not use Encoding.UTF8.GetByteCount(value);
                // UTF8 chars can have a max length of 4 and the used buffer increase *2 every time.
                // So the buffer should always have much more capacity left so that a correct value
                // here is only waste of CPU cycles.
                var byteCount = value.Length * 4;

                EnsureAdditionalCapacity(byteCount + 2);

                var writtenBytes = Encoding.UTF8.GetBytes(value, 0, value.Length, _buffer, _position + 2);

                _buffer[_position] = (byte)(writtenBytes >> 8);
                _buffer[_position + 1] = (byte)writtenBytes;

                IncreasePosition(writtenBytes + 2);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteTwoByteInteger(ushort value)
        {
            EnsureAdditionalCapacity(2);

            _buffer[_position] = (byte)(value >> 8);
            IncreasePosition(1);
            _buffer[_position] = (byte)value;
            IncreasePosition(1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public void WriteVariableByteInteger(uint value)
        {
            if (value == 0)
            {
                _buffer[_position] = 0;
                IncreasePosition(1);

                return;
            }

            if (value <= 127)
            {
                _buffer[_position] = (byte)value;
                IncreasePosition(1);

                return;
            }

            if (value > VariableByteIntegerMaxValue)
            {
                throw new MqttProtocolViolationException($"The specified value ({value}) is too large for a variable byte integer.");
            }

            var size = 0;
            var x = value;
            do
            {
                var encodedByte = x % 128;
                x /= 128;
                if (x > 0)
                {
                    encodedByte |= 128;
                }

                _buffer[_position + size] = (byte)encodedByte;
                size++;
            } while (x > 0);

            IncreasePosition(size);
        }
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        void EnsureAdditionalCapacity(int additionalCapacity)
        {
            var bufferLength = _buffer.Length;

            var freeSpace = bufferLength - _position;
            if (freeSpace >= additionalCapacity)
            {
                return;
            }

            EnsureCapacity(bufferLength + additionalCapacity - freeSpace);
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        void EnsureCapacity(int capacity)
        {
            var newBufferLength = _buffer.Length;

            if (newBufferLength >= capacity)
            {
                return;
            }

            while (newBufferLength < capacity)
            {
                newBufferLength *= 2;
            }

            // Array.Resize will create a new array and copy the existing
            // data to the new one.
            Array.Resize(ref _buffer, newBufferLength);
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        void IncreasePosition(int length)
        {
            _position += length;

            if (_position > Length)
            {
                Length = _position;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttConnAckPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validatingConnectionEventArgs"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttConnAckPacket Create(ValidatingConnectionEventArgs validatingConnectionEventArgs)
        {
            if (validatingConnectionEventArgs == null)
            {
                throw new ArgumentNullException(nameof(validatingConnectionEventArgs));
            }

            var connAckPacket = new MqttConnAckPacket
            {
                ReturnCode = MqttConnectReasonCodeConverter.ToConnectReturnCode(validatingConnectionEventArgs.ReasonCode),
                ReasonCode = validatingConnectionEventArgs.ReasonCode,
                RetainAvailable = true,
                SubscriptionIdentifiersAvailable = true,
                SharedSubscriptionAvailable = false,
                TopicAliasMaximum = ushort.MaxValue,
                MaximumQoS = MqttQualityOfServiceLevel.ExactlyOnce,
                WildcardSubscriptionAvailable = true,

                AuthenticationMethod = validatingConnectionEventArgs.AuthenticationMethod,
                AuthenticationData = validatingConnectionEventArgs.ResponseAuthenticationData,
                AssignedClientIdentifier = validatingConnectionEventArgs.AssignedClientIdentifier,
                ReasonString = validatingConnectionEventArgs.ReasonString,
                ServerReference = validatingConnectionEventArgs.ServerReference,
                UserProperties = validatingConnectionEventArgs.ResponseUserProperties,

                ResponseInformation = null,
                MaximumPacketSize = 0, // Unlimited,
                ReceiveMaximum = 0 // Unlimited
            };

            return connAckPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttConnectPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttConnectPacket Create(MqttClientOptions clientOptions)
        {
            if (clientOptions == null)
            {
                throw new ArgumentNullException(nameof(clientOptions));
            }

            var connectPacket = new MqttConnectPacket
            {
                ClientId = clientOptions.ClientId,
                Username = clientOptions.Credentials?.GetUserName(clientOptions),
                Password = clientOptions.Credentials?.GetPassword(clientOptions),
                CleanSession = clientOptions.CleanSession,
                KeepAlivePeriod = (ushort)clientOptions.KeepAlivePeriod.TotalSeconds,
                AuthenticationMethod = clientOptions.AuthenticationMethod,
                AuthenticationData = clientOptions.AuthenticationData,
                WillDelayInterval = clientOptions.WillDelayInterval,
                MaximumPacketSize = clientOptions.MaximumPacketSize,
                ReceiveMaximum = clientOptions.ReceiveMaximum,
                RequestProblemInformation = clientOptions.RequestProblemInformation,
                RequestResponseInformation = clientOptions.RequestResponseInformation,
                SessionExpiryInterval = clientOptions.SessionExpiryInterval,
                TopicAliasMaximum = clientOptions.TopicAliasMaximum,
                UserProperties = clientOptions.UserProperties,
                TryPrivate = clientOptions.TryPrivate
            };

            if (!string.IsNullOrEmpty(clientOptions.WillTopic))
            {
                connectPacket.WillFlag = true;
                connectPacket.WillTopic = clientOptions.WillTopic;
                connectPacket.WillQoS = clientOptions.WillQualityOfServiceLevel;
                connectPacket.WillMessage = clientOptions.WillPayload;
                connectPacket.WillRetain = clientOptions.WillRetain;
                connectPacket.WillDelayInterval = clientOptions.WillDelayInterval;
                connectPacket.WillContentType = clientOptions.WillContentType;
                connectPacket.WillCorrelationData = clientOptions.WillCorrelationData;
                connectPacket.WillResponseTopic = clientOptions.WillResponseTopic;
                connectPacket.WillMessageExpiryInterval = clientOptions.WillMessageExpiryInterval;
                connectPacket.WillPayloadFormatIndicator = clientOptions.WillPayloadFormatIndicator;
                connectPacket.WillUserProperties = clientOptions.WillUserProperties;
            }

            return connectPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttDisconnectPacketFactory
    {
        readonly MqttDisconnectPacket _normalDisconnection = new MqttDisconnectPacket
        {
            ReasonCode = MqttDisconnectReasonCode.NormalDisconnection
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <returns></returns>
        public MqttDisconnectPacket Create(MqttDisconnectReasonCode reasonCode)
        {
            if (reasonCode == MqttDisconnectReasonCode.NormalDisconnection)
            {
                return _normalDisconnection;
            }

            return new MqttDisconnectPacket
            {
                ReasonCode = reasonCode
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientDisconnectOptions"></param>
        /// <returns></returns>
        public MqttDisconnectPacket Create(MqttClientDisconnectOptions clientDisconnectOptions)
        {
            var packet = new MqttDisconnectPacket();

            if (clientDisconnectOptions == null)
            {
                packet.ReasonCode = MqttDisconnectReasonCode.NormalDisconnection;
            }
            else
            {
                packet.ReasonCode = (MqttDisconnectReasonCode)clientDisconnectOptions.Reason;
            }

            return packet;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public struct MqttFixedHeader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="remainingLength"></param>
        /// <param name="totalLength"></param>
        public MqttFixedHeader(byte flags, int remainingLength, int totalLength)
        {
            Flags = flags;
            RemainingLength = remainingLength;
            TotalLength = totalLength;
        }
        /// <summary>
        /// 
        /// </summary>
        public byte Flags { get; }
        /// <summary>
        /// 
        /// </summary>
        public int RemainingLength { get; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalLength { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public readonly struct MqttPacketBuffer
    {
        static readonly ArraySegment<byte> EmptyPayload = EmptyBuffer.ArraySegment;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="payload"></param>
        public MqttPacketBuffer(ArraySegment<byte> packet, ArraySegment<byte> payload)
        {
            Packet = packet;
            Payload = payload;

            Length = Packet.Count + Payload.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        public MqttPacketBuffer(ArraySegment<byte> packet)
        {
            Packet = packet;
            Payload = EmptyPayload;

            Length = Packet.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Length { get; }
        /// <summary>
        /// 
        /// </summary>
        public ArraySegment<byte> Packet { get; }
        /// <summary>
        /// 
        /// </summary>
        public ArraySegment<byte> Payload { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            if (Payload.Count == 0)
            {
                return Packet.Array.ToArray();
            }

            var buffer = new byte[Length];
            MqttMemoryHelper.Copy(Packet.Array, Packet.Offset, buffer, 0, Packet.Count);
            MqttMemoryHelper.Copy(Payload.Array, Payload.Offset, buffer, Packet.Count, Payload.Count);

            return buffer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ArraySegment<byte> Join()
        {
            if (Payload.Count == 0)
            {
                return Packet;
            }

            var buffer = new byte[Length];
            MqttMemoryHelper.Copy(Packet.Array, Packet.Offset, buffer, 0, Packet.Count);
            MqttMemoryHelper.Copy(Payload.Array, Payload.Offset, buffer, Packet.Count, Payload.Count);

            return new ArraySegment<byte>(buffer);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketFormatterAdapter
    {
        readonly MqttBufferReader _bufferReader = new MqttBufferReader();
        readonly MqttBufferWriter _bufferWriter;

        IMqttPacketFormatter _formatter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttBufferWriter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketFormatterAdapter(MqttBufferWriter mqttBufferWriter)
        {
            _bufferWriter = mqttBufferWriter ?? throw new ArgumentNullException(nameof(mqttBufferWriter));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocolVersion"></param>
        /// <param name="bufferWriter"></param>
        public MqttPacketFormatterAdapter(MqttProtocolVersion protocolVersion, MqttBufferWriter bufferWriter) : this(bufferWriter)
        {
            UseProtocolVersion(protocolVersion);
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttProtocolVersion ProtocolVersion { get; private set; } = MqttProtocolVersion.Unknown;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        /// <returns></returns>
        public MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket)
        {
            ThrowIfFormatterNotSet();

            return _formatter.Decode(receivedMqttPacket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        public void DetectProtocolVersion(ReceivedMqttPacket receivedMqttPacket)
        {
            var protocolVersion = ParseProtocolVersion(receivedMqttPacket);
            UseProtocolVersion(protocolVersion);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public MqttPacketBuffer Encode(MqttPacket packet)
        {
            ThrowIfFormatterNotSet();
            return _formatter.Encode(packet);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Cleanup()
        {
            _bufferWriter.Cleanup();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocolVersion"></param>
        /// <param name="bufferWriter"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static IMqttPacketFormatter GetMqttPacketFormatter(MqttProtocolVersion protocolVersion, MqttBufferWriter bufferWriter)
        {
            if (protocolVersion == MqttProtocolVersion.Unknown)
            {
                throw new InvalidOperationException("MQTT protocol version is invalid.");
            }

            switch (protocolVersion)
            {
                case MqttProtocolVersion.V500:
                    {
                        return new MqttV5PacketFormatter(bufferWriter);
                    }
                case MqttProtocolVersion.V310:
                case MqttProtocolVersion.V311:
                    {
                        return new MqttV3PacketFormatter(bufferWriter, protocolVersion);
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }
        }

        MqttProtocolVersion ParseProtocolVersion(ReceivedMqttPacket receivedMqttPacket)
        {
            if (receivedMqttPacket.Body.Count < 7)
            {
                // 2 byte protocol name length
                // at least 4 byte protocol name
                // 1 byte protocol level
                throw new MqttProtocolViolationException("CONNECT packet must have at least 7 bytes.");
            }

            _bufferReader.SetBuffer(receivedMqttPacket.Body.Array, receivedMqttPacket.Body.Offset, receivedMqttPacket.Body.Count);

            var protocolName = _bufferReader.ReadString();
            var protocolLevel = _bufferReader.ReadByte();

            // Remove the mosquitto try_private flag (MQTT 3.1.1 Bridge).
            // This flag is accepted but not yet used.
            protocolLevel &= 0x7F;

            if (protocolName == "MQTT")
            {
                if (protocolLevel == 5)
                {
                    return MqttProtocolVersion.V500;
                }

                if (protocolLevel == 4)
                {
                    return MqttProtocolVersion.V311;
                }

                throw new MqttProtocolViolationException($"Protocol level '{protocolLevel}' not supported.");
            }

            if (protocolName == "MQIsdp")
            {
                if (protocolLevel == 3)
                {
                    return MqttProtocolVersion.V310;
                }

                throw new MqttProtocolViolationException($"Protocol level '{protocolLevel}' not supported.");
            }

            throw new MqttProtocolViolationException($"Protocol '{protocolName}' not supported.");
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        void ThrowIfFormatterNotSet()
        {
            if (_formatter == null)
            {
                throw new InvalidOperationException("Protocol version not set or detected.");
            }
        }

        void UseProtocolVersion(MqttProtocolVersion protocolVersion)
        {
            if (protocolVersion == MqttProtocolVersion.Unknown)
            {
                throw new InvalidOperationException("MQTT protocol version is invalid.");
            }

            ProtocolVersion = protocolVersion;
            _formatter = GetMqttPacketFormatter(protocolVersion, _bufferWriter);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubAckPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishPacket"></param>
        /// <param name="dispatchApplicationMessageResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPubAckPacket Create(
            MqttPublishPacket publishPacket,
            DispatchApplicationMessageResult dispatchApplicationMessageResult)
        {
            if (publishPacket == null)
            {
                throw new ArgumentNullException(nameof(publishPacket));
            }

            if (dispatchApplicationMessageResult == null)
            {
                throw new ArgumentNullException(nameof(dispatchApplicationMessageResult));
            }

            var pubAckPacket = new MqttPubAckPacket
            {
                PacketIdentifier = publishPacket.PacketIdentifier,
                ReasonCode = (MqttPubAckReasonCode)dispatchApplicationMessageResult.ReasonCode,
                ReasonString = dispatchApplicationMessageResult.ReasonString,
                UserProperties = dispatchApplicationMessageResult.UserProperties
            };

            return pubAckPacket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessageReceivedEventArgs"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPubAckPacket Create(MqttApplicationMessageReceivedEventArgs applicationMessageReceivedEventArgs)
        {
            if (applicationMessageReceivedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(applicationMessageReceivedEventArgs));
            }

            var pubAckPacket = new MqttPubAckPacket
            {
                PacketIdentifier = applicationMessageReceivedEventArgs.PublishPacket.PacketIdentifier,
                ReasonCode = (MqttPubAckReasonCode)(int)applicationMessageReceivedEventArgs.ReasonCode,
                UserProperties = applicationMessageReceivedEventArgs.ResponseUserProperties,
                ReasonString = applicationMessageReceivedEventArgs.ResponseReasonString
            };

            return pubAckPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubCompPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubRelPacket"></param>
        /// <param name="reasonCode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPubCompPacket Create(MqttPubRelPacket pubRelPacket, MqttApplicationMessageReceivedReasonCode reasonCode)
        {
            if (pubRelPacket == null)
            {
                throw new ArgumentNullException(nameof(pubRelPacket));
            }

            return new MqttPubCompPacket
            {
                PacketIdentifier = pubRelPacket.PacketIdentifier,
                ReasonCode = (MqttPubCompReasonCode)(int)reasonCode
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPublishPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishPacket"></param>
        /// <returns></returns>
        public MqttPublishPacket Clone(MqttPublishPacket publishPacket)
        {
            return new MqttPublishPacket
            {
                Topic = publishPacket.Topic,
                Payload = publishPacket.Payload,
                Retain = publishPacket.Retain,
                QualityOfServiceLevel = publishPacket.QualityOfServiceLevel,
                Dup = publishPacket.Dup,
                PacketIdentifier = publishPacket.PacketIdentifier
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPublishPacket Create(MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null)
            {
                throw new ArgumentNullException(nameof(applicationMessage));
            }

            // Copy all values to their matching counterparts.
            // The not supported values in MQTT 3.1.1 are not serialized (excluded) later.
            var packet = new MqttPublishPacket
            {
                Topic = applicationMessage.Topic,
                Payload = applicationMessage.Payload,
                QualityOfServiceLevel = applicationMessage.QualityOfServiceLevel,
                Retain = applicationMessage.Retain,
                Dup = applicationMessage.Dup,
                ContentType = applicationMessage.ContentType,
                CorrelationData = applicationMessage.CorrelationData,
                MessageExpiryInterval = applicationMessage.MessageExpiryInterval,
                PayloadFormatIndicator = applicationMessage.PayloadFormatIndicator,
                ResponseTopic = applicationMessage.ResponseTopic,
                TopicAlias = applicationMessage.TopicAlias,
                SubscriptionIdentifiers = applicationMessage.SubscriptionIdentifiers,
                UserProperties = applicationMessage.UserProperties
            };

            return packet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectPacket"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttPublishPacket Create(MqttConnectPacket connectPacket)
        {
            if (connectPacket == null)
            {
                throw new ArgumentNullException(nameof(connectPacket));
            }

            if (!connectPacket.WillFlag)
            {
                throw new MqttProtocolViolationException("The CONNECT packet contains no will message (WillFlag).");
            }

            var packet = new MqttPublishPacket
            {
                Topic = connectPacket.WillTopic,
                Payload = connectPacket.WillMessage,
                QualityOfServiceLevel = connectPacket.WillQoS,
                Retain = connectPacket.WillRetain,
                ContentType = connectPacket.WillContentType,
                CorrelationData = connectPacket.WillCorrelationData,
                MessageExpiryInterval = connectPacket.WillMessageExpiryInterval,
                PayloadFormatIndicator = connectPacket.WillPayloadFormatIndicator,
                ResponseTopic = connectPacket.WillResponseTopic,
                UserProperties = connectPacket.WillUserProperties
            };

            return packet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retainedMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPublishPacket Create(MqttRetainedMessageMatch retainedMessage)
        {
            if (retainedMessage == null)
            {
                throw new ArgumentNullException(nameof(retainedMessage));
            }

            var publishPacket = Create(retainedMessage.ApplicationMessage);
            publishPacket.QualityOfServiceLevel = retainedMessage.SubscriptionQualityOfServiceLevel;
            return publishPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubRecPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessageReceivedEventArgs"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPubRecPacket Create(MqttApplicationMessageReceivedEventArgs applicationMessageReceivedEventArgs)
        {
            if (applicationMessageReceivedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(applicationMessageReceivedEventArgs));
            }

            var pubRecPacket = Create(applicationMessageReceivedEventArgs.PublishPacket, applicationMessageReceivedEventArgs.ReasonCode);
            pubRecPacket.UserProperties = applicationMessageReceivedEventArgs.ResponseUserProperties;

            return pubRecPacket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishPacket"></param>
        /// <param name="dispatchApplicationMessageResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacket Create(MqttPublishPacket publishPacket, DispatchApplicationMessageResult dispatchApplicationMessageResult)
        {
            if (publishPacket == null)
            {
                throw new ArgumentNullException(nameof(publishPacket));
            }

            var pubRecPacket = new MqttPubRecPacket
            {
                PacketIdentifier = publishPacket.PacketIdentifier,
                ReasonCode = (MqttPubRecReasonCode)dispatchApplicationMessageResult.ReasonCode,
                ReasonString = dispatchApplicationMessageResult.ReasonString,
                UserProperties = dispatchApplicationMessageResult.UserProperties
            };

            return pubRecPacket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishPacket"></param>
        /// <param name="applicationMessageReceivedReasonCode"></param>
        /// <returns></returns>
        static MqttPubRecPacket Create(MqttPublishPacket publishPacket, MqttApplicationMessageReceivedReasonCode applicationMessageReceivedReasonCode)
        {
            var pubRecPacket = new MqttPubRecPacket
            {
                PacketIdentifier = publishPacket.PacketIdentifier,
                ReasonCode = (MqttPubRecReasonCode)(int)applicationMessageReceivedReasonCode
            };

            return pubRecPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubRelPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubRecPacket"></param>
        /// <param name="reasonCode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPubRelPacket Create(MqttPubRecPacket pubRecPacket, MqttApplicationMessageReceivedReasonCode reasonCode)
        {
            if (pubRecPacket == null)
            {
                throw new ArgumentNullException(nameof(pubRecPacket));
            }

            return new MqttPubRelPacket
            {
                PacketIdentifier = pubRecPacket.PacketIdentifier,
                ReasonCode = (MqttPubRelReasonCode)(int)reasonCode
            };
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSubAckPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribePacket"></param>
        /// <param name="subscribeResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttSubAckPacket Create(MqttSubscribePacket subscribePacket, SubscribeResult subscribeResult)
        {
            if (subscribePacket == null)
            {
                throw new ArgumentNullException(nameof(subscribePacket));
            }

            if (subscribeResult == null)
            {
                throw new ArgumentNullException(nameof(subscribeResult));
            }

            var subAckPacket = new MqttSubAckPacket
            {
                PacketIdentifier = subscribePacket.PacketIdentifier,
                ReasonCodes = subscribeResult.ReasonCodes,
                ReasonString = subscribeResult.ReasonString,
                UserProperties = subscribeResult.UserProperties
            };

            return subAckPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSubscribePacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSubscribeOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttSubscribePacket Create(MqttClientSubscribeOptions clientSubscribeOptions)
        {
            if (clientSubscribeOptions == null)
            {
                throw new ArgumentNullException(nameof(clientSubscribeOptions));
            }

            var packet = new MqttSubscribePacket
            {
                TopicFilters = clientSubscribeOptions.TopicFilters,
                SubscriptionIdentifier = clientSubscribeOptions.SubscriptionIdentifier,
                UserProperties = clientSubscribeOptions.UserProperties
            };

            return packet;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttUnsubAckPacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unsubscribePacket"></param>
        /// <param name="unsubscribeResult"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttUnsubAckPacket Create(MqttUnsubscribePacket unsubscribePacket, UnsubscribeResult unsubscribeResult)
        {
            if (unsubscribePacket == null)
            {
                throw new ArgumentNullException(nameof(unsubscribePacket));
            }

            if (unsubscribeResult == null)
            {
                throw new ArgumentNullException(nameof(unsubscribeResult));
            }

            var unsubAckPacket = new MqttUnsubAckPacket
            {
                PacketIdentifier = unsubscribePacket.PacketIdentifier
            };

            // MQTTv5.0.0 only.
            unsubAckPacket.ReasonCodes = unsubscribeResult.ReasonCodes;

            return unsubAckPacket;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttUnsubscribePacketFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientUnsubscribeOptions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttUnsubscribePacket Create(MqttClientUnsubscribeOptions clientUnsubscribeOptions)
        {
            if (clientUnsubscribeOptions == null)
            {
                throw new ArgumentNullException(nameof(clientUnsubscribeOptions));
            }

            var packet = new MqttUnsubscribePacket
            {
                UserProperties = clientUnsubscribeOptions.UserProperties
            };

            if (clientUnsubscribeOptions.TopicFilters != null)
            {
                packet.TopicFilters.AddRange(clientUnsubscribeOptions.TopicFilters);
            }

            return packet;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public struct ReadFixedHeaderResult
    {
        /// <summary>
        /// 
        /// </summary>
        public static ReadFixedHeaderResult Canceled { get; } = new ReadFixedHeaderResult
        {
            IsCanceled = true
        };
        /// <summary>
        /// 
        /// </summary>
        public static ReadFixedHeaderResult ConnectionClosed { get; } = new ReadFixedHeaderResult
        {
            IsConnectionClosed = true
        };
        /// <summary>
        /// 
        /// </summary>
        public bool IsCanceled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsConnectionClosed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttFixedHeader FixedHeader { get; set; }
    }
    #region // V3
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttV3PacketFormatter : IMqttPacketFormatter
    {
        const int FixedHeaderSize = 1;

        static readonly MqttDisconnectPacket DisconnectPacket = new MqttDisconnectPacket();

        readonly MqttBufferReader _bufferReader = new MqttBufferReader();
        readonly MqttBufferWriter _bufferWriter;
        readonly MqttProtocolVersion _mqttProtocolVersion;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferWriter"></param>
        /// <param name="mqttProtocolVersion"></param>
        public MqttV3PacketFormatter(MqttBufferWriter bufferWriter, MqttProtocolVersion mqttProtocolVersion)
        {
            _bufferWriter = bufferWriter;
            _mqttProtocolVersion = mqttProtocolVersion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket)
        {
            if (receivedMqttPacket.TotalLength == 0)
            {
                return null;
            }

            var controlPacketType = receivedMqttPacket.FixedHeader >> 4;
            if (controlPacketType < 1 || controlPacketType > 14)
            {
                throw new MqttProtocolViolationException($"The packet type is invalid ({controlPacketType}).");
            }

            switch ((MqttControlPacketType)controlPacketType)
            {
                case MqttControlPacketType.Publish:
                    return DecodePublishPacket(receivedMqttPacket);
                case MqttControlPacketType.PubAck:
                    return DecodePubAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubRec:
                    return DecodePubRecPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubRel:
                    return DecodePubRelPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubComp:
                    return DecodePubCompPacket(receivedMqttPacket.Body);

                case MqttControlPacketType.PingReq:
                    return MqttPingReqPacket.Instance;
                case MqttControlPacketType.PingResp:
                    return MqttPingRespPacket.Instance;

                case MqttControlPacketType.Connect:
                    return DecodeConnectPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.ConnAck:
                    if (_mqttProtocolVersion == MqttProtocolVersion.V311)
                    {
                        return DecodeConnAckPacketV311(receivedMqttPacket.Body);
                    }
                    else
                    {
                        return DecodeConnAckPacket(receivedMqttPacket.Body);
                    }
                case MqttControlPacketType.Disconnect:
                    return DisconnectPacket;

                case MqttControlPacketType.Subscribe:
                    return DecodeSubscribePacket(receivedMqttPacket.Body);
                case MqttControlPacketType.SubAck:
                    return DecodeSubAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.Unsubscribe:
                    return DecodeUnsubscribePacket(receivedMqttPacket.Body);
                case MqttControlPacketType.UnsubAck:
                    return DecodeUnsubAckPacket(receivedMqttPacket.Body);

                default:
                    throw new MqttProtocolViolationException($"Packet type ({controlPacketType}) not supported.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketBuffer Encode(MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            // Leave enough head space for max header size (fixed + 4 variable remaining length = 5 bytes)
            _bufferWriter.Reset(5);
            _bufferWriter.Seek(5);

            var fixedHeader = EncodePacket(packet, _bufferWriter);
            var remainingLength = (uint)(_bufferWriter.Length - 5);

            var publishPacket = packet as MqttPublishPacket;
            if (publishPacket?.Payload != null)
            {
                remainingLength += (uint)publishPacket.Payload.Length;
            }

            var remainingLengthSize = MqttBufferWriter.GetVariableByteIntegerSize(remainingLength);

            var headerSize = FixedHeaderSize + remainingLengthSize;
            var headerOffset = 5 - headerSize;

            // Position cursor on correct offset on beginning of array (has leading 0x0)
            _bufferWriter.Seek(headerOffset);
            _bufferWriter.WriteByte(fixedHeader);
            _bufferWriter.WriteVariableByteInteger(remainingLength);

            var buffer = _bufferWriter.GetBuffer();

            var firstSegment = new ArraySegment<byte>(buffer, headerOffset, _bufferWriter.Length - headerOffset);

            if (publishPacket?.Payload != null)
            {
                var payloadSegment = new ArraySegment<byte>(publishPacket.Payload, 0, publishPacket.Payload.Length);
                return new MqttPacketBuffer(firstSegment, payloadSegment);
            }

            return new MqttPacketBuffer(firstSegment);
        }

        MqttPacket DecodeConnAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttConnAckPacket();

            _bufferReader.ReadByte(); // Reserved.
            packet.ReturnCode = (MqttConnectReturnCode)_bufferReader.ReadByte();

            return packet;
        }

        MqttPacket DecodeConnAckPacketV311(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttConnAckPacket();

            var acknowledgeFlags = _bufferReader.ReadByte();

            packet.IsSessionPresent = (acknowledgeFlags & 0x1) > 0;
            packet.ReturnCode = (MqttConnectReturnCode)_bufferReader.ReadByte();

            return packet;
        }

        MqttPacket DecodeConnectPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var protocolName = _bufferReader.ReadString();
            var protocolVersion = _bufferReader.ReadByte();

            if (protocolName != "MQTT" && protocolName != "MQIsdp")
            {
                throw new MqttProtocolViolationException("MQTT protocol name do not match MQTT v3.");
            }

            var tryPrivate = (protocolVersion & 0x80) > 0;
            protocolVersion &= 0x7F;

            if (protocolVersion != 3 && protocolVersion != 4)
            {
                throw new MqttProtocolViolationException("MQTT protocol version do not match MQTT v3.");
            }

            var packet = new MqttConnectPacket
            {
                TryPrivate = tryPrivate
            };

            var connectFlags = _bufferReader.ReadByte();
            if ((connectFlags & 0x1) > 0)
            {
                throw new MqttProtocolViolationException("The first bit of the Connect Flags must be set to 0.");
            }

            packet.CleanSession = (connectFlags & 0x2) > 0;

            var willFlag = (connectFlags & 0x4) > 0;
            var willQoS = (connectFlags & 0x18) >> 3;
            var willRetain = (connectFlags & 0x20) > 0;
            var passwordFlag = (connectFlags & 0x40) > 0;
            var usernameFlag = (connectFlags & 0x80) > 0;

            packet.KeepAlivePeriod = _bufferReader.ReadTwoByteInteger();
            packet.ClientId = _bufferReader.ReadString();

            if (willFlag)
            {
                packet.WillFlag = true;
                packet.WillQoS = (MqttQualityOfServiceLevel)willQoS;
                packet.WillRetain = willRetain;

                packet.WillTopic = _bufferReader.ReadString();
                packet.WillMessage = _bufferReader.ReadBinaryData();
            }

            if (usernameFlag)
            {
                packet.Username = _bufferReader.ReadString();
            }

            if (passwordFlag)
            {
                packet.Password = _bufferReader.ReadBinaryData();
            }

            ValidateConnectPacket(packet);
            return packet;
        }

        MqttPacket DecodePubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            return new MqttPubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };
        }

        MqttPacket DecodePubCompPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            return new MqttPubCompPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };
        }

        MqttPacket DecodePublishPacket(ReceivedMqttPacket receivedMqttPacket)
        {
            ThrowIfBodyIsEmpty(receivedMqttPacket.Body);

            _bufferReader.SetBuffer(receivedMqttPacket.Body.Array, receivedMqttPacket.Body.Offset, receivedMqttPacket.Body.Count);

            var retain = (receivedMqttPacket.FixedHeader & 0x1) > 0;
            var qualityOfServiceLevel = (MqttQualityOfServiceLevel)((receivedMqttPacket.FixedHeader >> 1) & 0x3);
            var dup = (receivedMqttPacket.FixedHeader & 0x8) > 0;

            var topic = _bufferReader.ReadString();

            ushort packetIdentifier = 0;
            if (qualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
            {
                packetIdentifier = _bufferReader.ReadTwoByteInteger();
            }

            var packet = new MqttPublishPacket
            {
                PacketIdentifier = packetIdentifier,
                Retain = retain,
                Topic = topic,
                QualityOfServiceLevel = qualityOfServiceLevel,
                Dup = dup
            };

            if (!_bufferReader.EndOfStream)
            {
                packet.Payload = _bufferReader.ReadRemainingData();
            }

            return packet;
        }

        MqttPacket DecodePubRecPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            return new MqttPubRecPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };
        }

        MqttPacket DecodePubRelPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            return new MqttPubRelPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };
        }

        MqttPacket DecodeSubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttSubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger(),
                ReasonCodes = new List<MqttSubscribeReasonCode>(_bufferReader.BytesLeft)
            };

            while (!_bufferReader.EndOfStream)
            {
                packet.ReasonCodes.Add((MqttSubscribeReasonCode)_bufferReader.ReadByte());
            }

            return packet;
        }

        MqttPacket DecodeSubscribePacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttSubscribePacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            while (!_bufferReader.EndOfStream)
            {
                var topicFilter = new MqttTopicFilter
                {
                    Topic = _bufferReader.ReadString(),
                    QualityOfServiceLevel = (MqttQualityOfServiceLevel)_bufferReader.ReadByte()
                };

                packet.TopicFilters.Add(topicFilter);
            }

            return packet;
        }

        MqttPacket DecodeUnsubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            return new MqttUnsubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };
        }

        MqttPacket DecodeUnsubscribePacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttUnsubscribePacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            while (!_bufferReader.EndOfStream)
            {
                packet.TopicFilters.Add(_bufferReader.ReadString());
            }

            return packet;
        }

        byte EncodeConnAckPacket(MqttConnAckPacket packet, MqttBufferWriter bufferWriter)
        {
            bufferWriter.WriteByte(0); // Reserved.
            bufferWriter.WriteByte((byte)packet.ReturnCode);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.ConnAck);
        }

        byte EncodeConnAckPacketV311(MqttConnAckPacket packet, MqttBufferWriter bufferWriter)
        {
            byte connectAcknowledgeFlags = 0x0;
            if (packet.IsSessionPresent)
            {
                connectAcknowledgeFlags |= 0x1;
            }

            bufferWriter.WriteByte(connectAcknowledgeFlags);
            bufferWriter.WriteByte((byte)packet.ReturnCode);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.ConnAck);
        }

        byte EncodeConnectPacket(MqttConnectPacket packet, MqttBufferWriter bufferWriter)
        {
            ValidateConnectPacket(packet);

            bufferWriter.WriteString("MQIsdp");

            var protocolVersion = 3;
            if (packet.TryPrivate)
            {
                protocolVersion |= 0x80;
            }

            bufferWriter.WriteByte((byte)protocolVersion);

            byte connectFlags = 0x0;
            if (packet.CleanSession)
            {
                connectFlags |= 0x2;
            }

            if (packet.WillFlag)
            {
                connectFlags |= 0x4;
                connectFlags |= (byte)((byte)packet.WillQoS << 3);

                if (packet.WillRetain)
                {
                    connectFlags |= 0x20;
                }
            }

            if (packet.Password != null && packet.Username == null)
            {
                throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
            }

            if (packet.Password != null)
            {
                connectFlags |= 0x40;
            }

            if (packet.Username != null)
            {
                connectFlags |= 0x80;
            }

            bufferWriter.WriteByte(connectFlags);
            bufferWriter.WriteTwoByteInteger(packet.KeepAlivePeriod);
            bufferWriter.WriteString(packet.ClientId);

            if (packet.WillFlag)
            {
                bufferWriter.WriteString(packet.WillTopic);
                bufferWriter.WriteBinaryData(packet.WillMessage);
            }

            if (packet.Username != null)
            {
                bufferWriter.WriteString(packet.Username);
            }

            if (packet.Password != null)
            {
                bufferWriter.WriteBinaryData(packet.Password);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Connect);
        }

        byte EncodeConnectPacketV311(MqttConnectPacket packet, MqttBufferWriter bufferWriter)
        {
            ValidateConnectPacket(packet);

            bufferWriter.WriteString("MQTT");
            bufferWriter.WriteByte(4); // 3.1.2.2 Protocol Level 4

            byte connectFlags = 0x0;
            if (packet.CleanSession)
            {
                connectFlags |= 0x2;
            }

            if (packet.WillFlag)
            {
                connectFlags |= 0x4;
                connectFlags |= (byte)((byte)packet.WillQoS << 3);

                if (packet.WillRetain)
                {
                    connectFlags |= 0x20;
                }
            }

            if (packet.Password != null && packet.Username == null)
            {
                throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
            }

            if (packet.Password != null)
            {
                connectFlags |= 0x40;
            }

            if (packet.Username != null)
            {
                connectFlags |= 0x80;
            }

            bufferWriter.WriteByte(connectFlags);
            bufferWriter.WriteTwoByteInteger(packet.KeepAlivePeriod);
            bufferWriter.WriteString(packet.ClientId);

            if (packet.WillFlag)
            {
                bufferWriter.WriteString(packet.WillTopic);
                bufferWriter.WriteBinaryData(packet.WillMessage);
            }

            if (packet.Username != null)
            {
                bufferWriter.WriteString(packet.Username);
            }

            if (packet.Password != null)
            {
                bufferWriter.WriteBinaryData(packet.Password);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Connect);
        }

        static byte EncodeEmptyPacket(MqttControlPacketType type)
        {
            return MqttBufferWriter.BuildFixedHeader(type);
        }

        byte EncodePacket(MqttPacket packet, MqttBufferWriter bufferWriter)
        {
            switch (packet)
            {
                case MqttConnectPacket connectPacket:
                    if (_mqttProtocolVersion == MqttProtocolVersion.V311)
                    {
                        return EncodeConnectPacketV311(connectPacket, bufferWriter);
                    }
                    else
                    {
                        return EncodeConnectPacket(connectPacket, bufferWriter);
                    }
                case MqttConnAckPacket connAckPacket:
                    if (_mqttProtocolVersion == MqttProtocolVersion.V311)
                    {
                        return EncodeConnAckPacketV311(connAckPacket, bufferWriter);
                    }
                    else
                    {
                        return EncodeConnAckPacket(connAckPacket, bufferWriter);
                    }
                case MqttDisconnectPacket _:
                    return EncodeEmptyPacket(MqttControlPacketType.Disconnect);
                case MqttPingReqPacket _:
                    return EncodeEmptyPacket(MqttControlPacketType.PingReq);
                case MqttPingRespPacket _:
                    return EncodeEmptyPacket(MqttControlPacketType.PingResp);
                case MqttPublishPacket publishPacket:
                    return EncodePublishPacket(publishPacket, bufferWriter);
                case MqttPubAckPacket pubAckPacket:
                    return EncodePubAckPacket(pubAckPacket, bufferWriter);
                case MqttPubRecPacket pubRecPacket:
                    return EncodePubRecPacket(pubRecPacket, bufferWriter);
                case MqttPubRelPacket pubRelPacket:
                    return EncodePubRelPacket(pubRelPacket, bufferWriter);
                case MqttPubCompPacket pubCompPacket:
                    return EncodePubCompPacket(pubCompPacket, bufferWriter);
                case MqttSubscribePacket subscribePacket:
                    return EncodeSubscribePacket(subscribePacket, bufferWriter);
                case MqttSubAckPacket subAckPacket:
                    return EncodeSubAckPacket(subAckPacket, bufferWriter);
                case MqttUnsubscribePacket unsubscribePacket:
                    return EncodeUnsubscribePacket(unsubscribePacket, bufferWriter);
                case MqttUnsubAckPacket unsubAckPacket:
                    return EncodeUnsubAckPacket(unsubAckPacket, bufferWriter);

                default:
                    throw new MqttProtocolViolationException("Packet type invalid.");
            }
        }

        static byte EncodePubAckPacket(MqttPubAckPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("PubAck packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubAck);
        }

        static byte EncodePubCompPacket(MqttPubCompPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("PubComp packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubComp);
        }

        static byte EncodePublishPacket(MqttPublishPacket packet, MqttBufferWriter bufferWriter)
        {
            ValidatePublishPacket(packet);

            bufferWriter.WriteString(packet.Topic);

            if (packet.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
            {
                if (packet.PacketIdentifier == 0)
                {
                    throw new MqttProtocolViolationException("Publish packet has no packet identifier.");
                }

                bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);
            }
            else
            {
                if (packet.PacketIdentifier > 0)
                {
                    throw new MqttProtocolViolationException("Packet identifier must be empty if QoS == 0 [MQTT-2.3.1-5].");
                }
            }

            // The payload is the past part of the packet. But it is not added here in order to keep
            // memory allocation low.

            byte fixedHeader = 0;

            if (packet.Retain)
            {
                fixedHeader |= 0x01;
            }

            fixedHeader |= (byte)((byte)packet.QualityOfServiceLevel << 1);

            if (packet.Dup)
            {
                fixedHeader |= 0x08;
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Publish, fixedHeader);
        }

        static byte EncodePubRecPacket(MqttPubRecPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("PubRec packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubRec);
        }

        static byte EncodePubRelPacket(MqttPubRelPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("PubRel packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubRel, 0x02);
        }

        static byte EncodeSubAckPacket(MqttSubAckPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("SubAck packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (packet.ReasonCodes.Any())
            {
                foreach (var packetSubscribeReturnCode in packet.ReasonCodes)
                {
                    if (packetSubscribeReturnCode == MqttSubscribeReasonCode.GrantedQoS0)
                    {
                        bufferWriter.WriteByte((byte)MqttSubscribeReturnCode.SuccessMaximumQoS0);
                    }
                    else if (packetSubscribeReturnCode == MqttSubscribeReasonCode.GrantedQoS1)
                    {
                        bufferWriter.WriteByte((byte)MqttSubscribeReturnCode.SuccessMaximumQoS1);
                    }
                    else if (packetSubscribeReturnCode == MqttSubscribeReasonCode.GrantedQoS2)
                    {
                        bufferWriter.WriteByte((byte)MqttSubscribeReturnCode.SuccessMaximumQoS2);
                    }
                    else
                    {
                        bufferWriter.WriteByte((byte)MqttSubscribeReturnCode.Failure);
                    }
                }
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.SubAck);
        }

        static byte EncodeSubscribePacket(MqttSubscribePacket packet, MqttBufferWriter bufferWriter)
        {
            if (!packet.TopicFilters.Any())
            {
                throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.8.3-3].");
            }

            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("Subscribe packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (packet.TopicFilters?.Count > 0)
            {
                foreach (var topicFilter in packet.TopicFilters)
                {
                    bufferWriter.WriteString(topicFilter.Topic);
                    bufferWriter.WriteByte((byte)topicFilter.QualityOfServiceLevel);
                }
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Subscribe, 0x02);
        }

        static byte EncodeUnsubAckPacket(MqttUnsubAckPacket packet, MqttBufferWriter bufferWriter)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("UnsubAck packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);
            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.UnsubAck);
        }

        static byte EncodeUnsubscribePacket(MqttUnsubscribePacket packet, MqttBufferWriter bufferWriter)
        {
            if (!packet.TopicFilters.Any())
            {
                throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.10.3-2].");
            }

            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("Unsubscribe packet has no packet identifier.");
            }

            bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (packet.TopicFilters?.Any() == true)
            {
                foreach (var topicFilter in packet.TopicFilters)
                {
                    bufferWriter.WriteString(topicFilter);
                }
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Unsubscribe, 0x02);
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        static void ThrowIfBodyIsEmpty(ArraySegment<byte> body)
        {
            if (body.Count == 0)
            {
                throw new MqttProtocolViolationException("Data from the body is required but not present.");
            }
        }

        void ValidateConnectPacket(MqttConnectPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            if (string.IsNullOrEmpty(packet.ClientId) && !packet.CleanSession)
            {
                throw new MqttProtocolViolationException("CleanSession must be set if ClientId is empty [MQTT-3.1.3-7].");
            }
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        static void ValidatePublishPacket(MqttPublishPacket packet)
        {
            if (packet.QualityOfServiceLevel == 0 && packet.Dup)
            {
                throw new MqttProtocolViolationException("Dup flag must be false for QoS 0 packets [MQTT-3.3.1-2].");
            }
        }
    }
    #endregion V3
    #region // V5
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttV5PacketDecoder
    {
        readonly MqttBufferReader _bufferReader = new MqttBufferReader();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket)
        {
            if (receivedMqttPacket.TotalLength == 0)
            {
                return null;
            }

            var controlPacketType = receivedMqttPacket.FixedHeader >> 4;
            if (controlPacketType < 1)
            {
                throw new MqttProtocolViolationException($"The packet type is invalid ({controlPacketType}).");
            }

            switch ((MqttControlPacketType)controlPacketType)
            {
                case MqttControlPacketType.Connect:
                    return DecodeConnectPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.ConnAck:
                    return DecodeConnAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.Disconnect:
                    return DecodeDisconnectPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.Publish:
                    return DecodePublishPacket(receivedMqttPacket.FixedHeader, receivedMqttPacket.Body);
                case MqttControlPacketType.PubAck:
                    return DecodePubAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubRec:
                    return DecodePubRecPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubRel:
                    return DecodePubRelPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PubComp:
                    return DecodePubCompPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.PingReq:
                    return MqttPingReqPacket.Instance;
                case MqttControlPacketType.PingResp:
                    return MqttPingRespPacket.Instance;
                case MqttControlPacketType.Subscribe:
                    return DecodeSubscribePacket(receivedMqttPacket.Body);
                case MqttControlPacketType.SubAck:
                    return DecodeSubAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.Unsubscribe:
                    return DecodeUnsubscribePacket(receivedMqttPacket.Body);
                case MqttControlPacketType.UnsubAck:
                    return DecodeUnsubAckPacket(receivedMqttPacket.Body);
                case MqttControlPacketType.Auth:
                    return DecodeAuthPacket(receivedMqttPacket.Body);

                default:
                    throw new MqttProtocolViolationException($"Packet type ({controlPacketType}) not supported.");
            }
        }

        MqttPacket DecodeAuthPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttAuthPacket();

            if (_bufferReader.EndOfStream)
            {
                packet.ReasonCode = MqttAuthenticateReasonCode.Success;
                return packet;
            }

            packet.ReasonCode = (MqttAuthenticateReasonCode)_bufferReader.ReadByte();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
                {
                    packet.AuthenticationMethod = propertiesReader.ReadAuthenticationMethod();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
                {
                    packet.AuthenticationData = propertiesReader.ReadAuthenticationData();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttAuthPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodeConnAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var acknowledgeFlags = _bufferReader.ReadByte();

            var packet = new MqttConnAckPacket
            {
                IsSessionPresent = (acknowledgeFlags & 0x1) > 0,
                ReasonCode = (MqttConnectReasonCode)_bufferReader.ReadByte(),
                // indicate that a feature is available.
                // Set all default values according to specification. When they are missing the often
                RetainAvailable = true,
                SharedSubscriptionAvailable = true,
                SubscriptionIdentifiersAvailable = true,
                WildcardSubscriptionAvailable = true,
                // Absence indicates max QoS level.
                MaximumQoS = MqttQualityOfServiceLevel.ExactlyOnce
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
                {
                    packet.SessionExpiryInterval = propertiesReader.ReadSessionExpiryInterval();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
                {
                    packet.AuthenticationMethod = propertiesReader.ReadAuthenticationMethod();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
                {
                    packet.AuthenticationData = propertiesReader.ReadAuthenticationData();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.RetainAvailable)
                {
                    packet.RetainAvailable = propertiesReader.ReadRetainAvailable();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReceiveMaximum)
                {
                    packet.ReceiveMaximum = propertiesReader.ReadReceiveMaximum();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.MaximumQoS)
                {
                    packet.MaximumQoS = propertiesReader.ReadMaximumQoS();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AssignedClientIdentifier)
                {
                    packet.AssignedClientIdentifier = propertiesReader.ReadAssignedClientIdentifier();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.TopicAliasMaximum)
                {
                    packet.TopicAliasMaximum = propertiesReader.ReadTopicAliasMaximum();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.MaximumPacketSize)
                {
                    packet.MaximumPacketSize = propertiesReader.ReadMaximumPacketSize();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.WildcardSubscriptionAvailable)
                {
                    packet.WildcardSubscriptionAvailable = propertiesReader.ReadWildcardSubscriptionAvailable();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifiersAvailable)
                {
                    packet.SubscriptionIdentifiersAvailable = propertiesReader.ReadSubscriptionIdentifiersAvailable();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.SharedSubscriptionAvailable)
                {
                    packet.SharedSubscriptionAvailable = propertiesReader.ReadSharedSubscriptionAvailable();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ServerKeepAlive)
                {
                    packet.ServerKeepAlive = propertiesReader.ReadServerKeepAlive();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ResponseInformation)
                {
                    packet.ResponseInformation = propertiesReader.ReadResponseInformation();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ServerReference)
                {
                    packet.ServerReference = propertiesReader.ReadServerReference();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttConnAckPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodeConnectPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttConnectPacket
            {
                // If the Request Problem Information is absent, the value of 1 is used.
                RequestProblemInformation = true
            };

            var protocolName = _bufferReader.ReadString();
            var protocolVersion = _bufferReader.ReadByte();

            if (protocolName != "MQTT" && protocolVersion != 5)
            {
                throw new MqttProtocolViolationException("MQTT protocol name and version do not match MQTT v5.");
            }

            var connectFlags = _bufferReader.ReadByte();

            var cleanSessionFlag = (connectFlags & 0x02) > 0;
            var willMessageFlag = (connectFlags & 0x04) > 0;
            var willMessageQoS = (byte)((connectFlags >> 3) & 3);
            var willMessageRetainFlag = (connectFlags & 0x20) > 0;
            var passwordFlag = (connectFlags & 0x40) > 0;
            var usernameFlag = (connectFlags & 0x80) > 0;

            packet.CleanSession = cleanSessionFlag;

            if (willMessageFlag)
            {
                packet.WillFlag = true;
                packet.WillQoS = (MqttQualityOfServiceLevel)willMessageQoS;
                packet.WillRetain = willMessageRetainFlag;
            }

            packet.KeepAlivePeriod = _bufferReader.ReadTwoByteInteger();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
                {
                    packet.SessionExpiryInterval = propertiesReader.ReadSessionExpiryInterval();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationMethod)
                {
                    packet.AuthenticationMethod = propertiesReader.ReadAuthenticationMethod();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.AuthenticationData)
                {
                    packet.AuthenticationData = propertiesReader.ReadAuthenticationData();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReceiveMaximum)
                {
                    packet.ReceiveMaximum = propertiesReader.ReadReceiveMaximum();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.TopicAliasMaximum)
                {
                    packet.TopicAliasMaximum = propertiesReader.ReadTopicAliasMaximum();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.MaximumPacketSize)
                {
                    packet.MaximumPacketSize = propertiesReader.ReadMaximumPacketSize();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.RequestResponseInformation)
                {
                    packet.RequestResponseInformation = propertiesReader.RequestResponseInformation();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.RequestProblemInformation)
                {
                    packet.RequestProblemInformation = propertiesReader.RequestProblemInformation();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttConnectPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            packet.ClientId = _bufferReader.ReadString();

            if (packet.WillFlag)
            {
                var willPropertiesReader = new MqttV5PropertiesReader(_bufferReader);

                while (willPropertiesReader.MoveNext())
                {
                    if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.PayloadFormatIndicator)
                    {
                        packet.WillPayloadFormatIndicator = willPropertiesReader.ReadPayloadFormatIndicator();
                    }
                    else if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.MessageExpiryInterval)
                    {
                        packet.WillMessageExpiryInterval = willPropertiesReader.ReadMessageExpiryInterval();
                    }
                    else if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.ResponseTopic)
                    {
                        packet.WillResponseTopic = willPropertiesReader.ReadResponseTopic();
                    }
                    else if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.CorrelationData)
                    {
                        packet.WillCorrelationData = willPropertiesReader.ReadCorrelationData();
                    }
                    else if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.ContentType)
                    {
                        packet.WillContentType = willPropertiesReader.ReadContentType();
                    }
                    else if (willPropertiesReader.CurrentPropertyId == MqttPropertyId.WillDelayInterval)
                    {
                        packet.WillDelayInterval = willPropertiesReader.ReadWillDelayInterval();
                    }
                    else
                    {
                        willPropertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPublishPacket));
                    }
                }

                packet.WillTopic = _bufferReader.ReadString();
                packet.WillMessage = _bufferReader.ReadBinaryData();
                packet.WillUserProperties = willPropertiesReader.CollectedUserProperties;
            }

            if (usernameFlag)
            {
                packet.Username = _bufferReader.ReadString();
            }

            if (passwordFlag)
            {
                packet.Password = _bufferReader.ReadBinaryData();
            }

            return packet;
        }

        MqttPacket DecodeDisconnectPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttDisconnectPacket
            {
                ReasonCode = (MqttDisconnectReasonCode)_bufferReader.ReadByte()
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.SessionExpiryInterval)
                {
                    packet.SessionExpiryInterval = propertiesReader.ReadSessionExpiryInterval();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ServerReference)
                {
                    packet.ServerReference = propertiesReader.ReadServerReference();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttDisconnectPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodePubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttPubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            if (_bufferReader.EndOfStream)
            {
                packet.ReasonCode = MqttPubAckReasonCode.Success;
                return packet;
            }

            packet.ReasonCode = (MqttPubAckReasonCode)_bufferReader.ReadByte();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubAckPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodePubCompPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttPubCompPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            if (_bufferReader.EndOfStream)
            {
                packet.ReasonCode = MqttPubCompReasonCode.Success;
                return packet;
            }

            packet.ReasonCode = (MqttPubCompReasonCode)_bufferReader.ReadByte();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubCompPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodePublishPacket(byte header, ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var retain = (header & 1) > 0;
            var qos = (MqttQualityOfServiceLevel)((header >> 1) & 3);
            var dup = ((header >> 3) & 1) > 0;

            var packet = new MqttPublishPacket
            {
                Topic = _bufferReader.ReadString(),
                Retain = retain,
                QualityOfServiceLevel = qos,
                Dup = dup
            };

            if (qos > 0)
            {
                packet.PacketIdentifier = _bufferReader.ReadTwoByteInteger();
            }

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.PayloadFormatIndicator)
                {
                    packet.PayloadFormatIndicator = propertiesReader.ReadPayloadFormatIndicator();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.MessageExpiryInterval)
                {
                    packet.MessageExpiryInterval = propertiesReader.ReadMessageExpiryInterval();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.TopicAlias)
                {
                    packet.TopicAlias = propertiesReader.ReadTopicAlias();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ResponseTopic)
                {
                    packet.ResponseTopic = propertiesReader.ReadResponseTopic();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.CorrelationData)
                {
                    packet.CorrelationData = propertiesReader.ReadCorrelationData();
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifier)
                {
                    if (packet.SubscriptionIdentifiers == null)
                    {
                        packet.SubscriptionIdentifiers = new List<uint>();
                    }

                    packet.SubscriptionIdentifiers.Add(propertiesReader.ReadSubscriptionIdentifier());
                }
                else if (propertiesReader.CurrentPropertyId == MqttPropertyId.ContentType)
                {
                    packet.ContentType = propertiesReader.ReadContentType();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPublishPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            if (!_bufferReader.EndOfStream)
            {
                packet.Payload = _bufferReader.ReadRemainingData();
            }

            return packet;
        }

        MqttPacket DecodePubRecPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttPubRecPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            if (_bufferReader.EndOfStream)
            {
                packet.ReasonCode = MqttPubRecReasonCode.Success;
                return packet;
            }

            packet.ReasonCode = (MqttPubRecReasonCode)_bufferReader.ReadByte();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubRecPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodePubRelPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttPubRelPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            if (_bufferReader.EndOfStream)
            {
                packet.ReasonCode = MqttPubRelReasonCode.Success;
                return packet;
            }

            packet.ReasonCode = (MqttPubRelReasonCode)_bufferReader.ReadByte();

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttPubRelPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            return packet;
        }

        MqttPacket DecodeSubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttSubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttSubAckPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            packet.ReasonCodes = new List<MqttSubscribeReasonCode>(_bufferReader.BytesLeft);
            while (!_bufferReader.EndOfStream)
            {
                var reasonCode = (MqttSubscribeReasonCode)_bufferReader.ReadByte();
                packet.ReasonCodes.Add(reasonCode);
            }

            return packet;
        }

        MqttPacket DecodeSubscribePacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttSubscribePacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.SubscriptionIdentifier)
                {
                    packet.SubscriptionIdentifier = propertiesReader.ReadSubscriptionIdentifier();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttSubscribePacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            while (!_bufferReader.EndOfStream)
            {
                var topic = _bufferReader.ReadString();
                var options = _bufferReader.ReadByte();

                var qos = (MqttQualityOfServiceLevel)(options & 3);
                var noLocal = (options & (1 << 2)) > 0;
                var retainAsPublished = (options & (1 << 3)) > 0;
                var retainHandling = (MqttRetainHandling)((options >> 4) & 3);

                packet.TopicFilters.Add(
                    new MqttTopicFilter
                    {
                        Topic = topic,
                        QualityOfServiceLevel = qos,
                        NoLocal = noLocal,
                        RetainAsPublished = retainAsPublished,
                        RetainHandling = retainHandling
                    });
            }

            return packet;
        }

        MqttPacket DecodeUnsubAckPacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttUnsubAckPacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                if (propertiesReader.CurrentPropertyId == MqttPropertyId.ReasonString)
                {
                    packet.ReasonString = propertiesReader.ReadReasonString();
                }
                else
                {
                    propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttUnsubAckPacket));
                }
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            packet.ReasonCodes = new List<MqttUnsubscribeReasonCode>(_bufferReader.BytesLeft);

            while (!_bufferReader.EndOfStream)
            {
                var reasonCode = (MqttUnsubscribeReasonCode)_bufferReader.ReadByte();
                packet.ReasonCodes.Add(reasonCode);
            }

            return packet;
        }

        MqttPacket DecodeUnsubscribePacket(ArraySegment<byte> body)
        {
            ThrowIfBodyIsEmpty(body);

            _bufferReader.SetBuffer(body.Array, body.Offset, body.Count);

            var packet = new MqttUnsubscribePacket
            {
                PacketIdentifier = _bufferReader.ReadTwoByteInteger()
            };

            var propertiesReader = new MqttV5PropertiesReader(_bufferReader);
            while (propertiesReader.MoveNext())
            {
                propertiesReader.ThrowInvalidPropertyIdException(typeof(MqttUnsubscribePacket));
            }

            packet.UserProperties = propertiesReader.CollectedUserProperties;

            while (!_bufferReader.EndOfStream)
            {
                packet.TopicFilters.Add(_bufferReader.ReadString());
            }

            return packet;
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        static void ThrowIfBodyIsEmpty(ArraySegment<byte> body)
        {
            if (body.Count == 0)
            {
                throw new MqttProtocolViolationException("Data from the body is required but not present.");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttV5PacketEncoder
    {
        const int FixedHeaderSize = 1;

        readonly MqttBufferWriter _bufferWriter;
        readonly MqttV5PropertiesWriter _propertiesWriter = new MqttV5PropertiesWriter(new MqttBufferWriter(1024, 4096));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferWriter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttV5PacketEncoder(MqttBufferWriter bufferWriter)
        {
            _bufferWriter = bufferWriter ?? throw new ArgumentNullException(nameof(bufferWriter));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketBuffer Encode(MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            // Leave enough head space for max header size (fixed + 4 variable remaining length = 5 bytes)
            _bufferWriter.Reset(5);
            _bufferWriter.Seek(5);

            var fixedHeader = EncodePacket(packet);
            var remainingLength = (uint)_bufferWriter.Length - 5;

            var publishPacket = packet as MqttPublishPacket;
            if (publishPacket?.Payload != null)
            {
                remainingLength += (uint)publishPacket.Payload.Length;
            }

            var remainingLengthSize = MqttBufferWriter.GetVariableByteIntegerSize(remainingLength);

            var headerSize = FixedHeaderSize + remainingLengthSize;
            var headerOffset = 5 - headerSize;

            // Position cursor on correct offset on beginning of array (has leading 0x0)
            _bufferWriter.Seek(headerOffset);
            _bufferWriter.WriteByte(fixedHeader);
            _bufferWriter.WriteVariableByteInteger(remainingLength);

            var buffer = _bufferWriter.GetBuffer();

            var firstSegment = new ArraySegment<byte>(buffer, headerOffset, _bufferWriter.Length - headerOffset);

            if (publishPacket?.Payload != null)
            {
                var payloadSegment = new ArraySegment<byte>(publishPacket.Payload, 0, publishPacket.Payload.Length);
                return new MqttPacketBuffer(firstSegment, payloadSegment);
            }

            return new MqttPacketBuffer(firstSegment);
        }

        byte EncodeAuthPacket(MqttAuthPacket packet)
        {
            _bufferWriter.WriteByte((byte)packet.ReasonCode);

            _propertiesWriter.WriteAuthenticationMethod(packet.AuthenticationMethod);
            _propertiesWriter.WriteAuthenticationData(packet.AuthenticationData);
            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Auth);
        }

        byte EncodeConnAckPacket(MqttConnAckPacket packet)
        {
            byte connectAcknowledgeFlags = 0x0;
            if (packet.IsSessionPresent)
            {
                connectAcknowledgeFlags |= 0x1;
            }

            _bufferWriter.WriteByte(connectAcknowledgeFlags);
            _bufferWriter.WriteByte((byte)packet.ReasonCode);

            _propertiesWriter.WriteSessionExpiryInterval(packet.SessionExpiryInterval);
            _propertiesWriter.WriteAuthenticationMethod(packet.AuthenticationMethod);
            _propertiesWriter.WriteAuthenticationData(packet.AuthenticationData);
            _propertiesWriter.WriteRetainAvailable(packet.RetainAvailable);
            _propertiesWriter.WriteReceiveMaximum(packet.ReceiveMaximum);
            _propertiesWriter.WriteMaximumQoS(packet.MaximumQoS);
            _propertiesWriter.WriteAssignedClientIdentifier(packet.AssignedClientIdentifier);
            _propertiesWriter.WriteTopicAliasMaximum(packet.TopicAliasMaximum);
            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteMaximumPacketSize(packet.MaximumPacketSize);
            _propertiesWriter.WriteWildcardSubscriptionAvailable(packet.WildcardSubscriptionAvailable);
            _propertiesWriter.WriteSubscriptionIdentifiersAvailable(packet.SubscriptionIdentifiersAvailable);
            _propertiesWriter.WriteSharedSubscriptionAvailable(packet.SharedSubscriptionAvailable);
            _propertiesWriter.WriteServerKeepAlive(packet.ServerKeepAlive);
            _propertiesWriter.WriteResponseInformation(packet.ResponseInformation);
            _propertiesWriter.WriteServerReference(packet.ServerReference);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.ConnAck);
        }

        byte EncodeConnectPacket(MqttConnectPacket packet)
        {
            if (string.IsNullOrEmpty(packet.ClientId) && !packet.CleanSession)
            {
                throw new MqttProtocolViolationException("CleanSession must be set if ClientId is empty [MQTT-3.1.3-7].");
            }

            _bufferWriter.WriteString("MQTT");
            _bufferWriter.WriteByte(5); // [3.1.2.2 Protocol Version]

            byte connectFlags = 0x0;
            if (packet.CleanSession)
            {
                connectFlags |= 0x2;
            }

            if (packet.WillFlag)
            {
                connectFlags |= 0x4;
                connectFlags |= (byte)((byte)packet.WillQoS << 3);

                if (packet.WillRetain)
                {
                    connectFlags |= 0x20;
                }
            }

            if (packet.Password != null && packet.Username == null)
            {
                throw new MqttProtocolViolationException("If the User Name Flag is set to 0, the Password Flag MUST be set to 0 [MQTT-3.1.2-22].");
            }

            if (packet.Password != null)
            {
                connectFlags |= 0x40;
            }

            if (packet.Username != null)
            {
                connectFlags |= 0x80;
            }

            _bufferWriter.WriteByte(connectFlags);
            _bufferWriter.WriteTwoByteInteger(packet.KeepAlivePeriod);

            _propertiesWriter.WriteSessionExpiryInterval(packet.SessionExpiryInterval);
            _propertiesWriter.WriteAuthenticationMethod(packet.AuthenticationMethod);
            _propertiesWriter.WriteAuthenticationData(packet.AuthenticationData);
            _propertiesWriter.WriteRequestProblemInformation(packet.RequestProblemInformation);
            _propertiesWriter.WriteRequestResponseInformation(packet.RequestResponseInformation);
            _propertiesWriter.WriteReceiveMaximum(packet.ReceiveMaximum);
            _propertiesWriter.WriteTopicAliasMaximum(packet.TopicAliasMaximum);
            _propertiesWriter.WriteMaximumPacketSize(packet.MaximumPacketSize);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            _bufferWriter.WriteString(packet.ClientId);

            if (packet.WillFlag)
            {
                _propertiesWriter.WritePayloadFormatIndicator(packet.WillPayloadFormatIndicator);
                _propertiesWriter.WriteMessageExpiryInterval(packet.WillMessageExpiryInterval);
                _propertiesWriter.WriteResponseTopic(packet.WillResponseTopic);
                _propertiesWriter.WriteCorrelationData(packet.WillCorrelationData);
                _propertiesWriter.WriteContentType(packet.WillContentType);
                _propertiesWriter.WriteUserProperties(packet.WillUserProperties);
                _propertiesWriter.WriteWillDelayInterval(packet.WillDelayInterval);

                _propertiesWriter.WriteTo(_bufferWriter);
                _propertiesWriter.Reset();

                _bufferWriter.WriteString(packet.WillTopic);
                _bufferWriter.WriteBinaryData(packet.WillMessage);
            }

            if (packet.Username != null)
            {
                _bufferWriter.WriteString(packet.Username);
            }

            if (packet.Password != null)
            {
                _bufferWriter.WriteBinaryData(packet.Password);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Connect);
        }

        byte EncodeDisconnectPacket(MqttDisconnectPacket packet)
        {
            _bufferWriter.WriteByte((byte)packet.ReasonCode);

            _propertiesWriter.WriteServerReference(packet.ServerReference);
            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteSessionExpiryInterval(packet.SessionExpiryInterval);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Disconnect);
        }

        byte EncodePacket(MqttPacket packet)
        {
            switch (packet)
            {
                case MqttConnectPacket connectPacket:
                    return EncodeConnectPacket(connectPacket);
                case MqttConnAckPacket connAckPacket:
                    return EncodeConnAckPacket(connAckPacket);
                case MqttDisconnectPacket disconnectPacket:
                    return EncodeDisconnectPacket(disconnectPacket);
                case MqttPingReqPacket _:
                    return EncodePingReqPacket();
                case MqttPingRespPacket _:
                    return EncodePingRespPacket();
                case MqttPublishPacket publishPacket:
                    return EncodePublishPacket(publishPacket);
                case MqttPubAckPacket pubAckPacket:
                    return EncodePubAckPacket(pubAckPacket);
                case MqttPubRecPacket pubRecPacket:
                    return EncodePubRecPacket(pubRecPacket);
                case MqttPubRelPacket pubRelPacket:
                    return EncodePubRelPacket(pubRelPacket);
                case MqttPubCompPacket pubCompPacket:
                    return EncodePubCompPacket(pubCompPacket);
                case MqttSubscribePacket subscribePacket:
                    return EncodeSubscribePacket(subscribePacket);
                case MqttSubAckPacket subAckPacket:
                    return EncodeSubAckPacket(subAckPacket);
                case MqttUnsubscribePacket unsubscribePacket:
                    return EncodeUnsubscribePacket(unsubscribePacket);
                case MqttUnsubAckPacket unsubAckPacket:
                    return EncodeUnsubAckPacket(unsubAckPacket);
                case MqttAuthPacket authPacket:
                    return EncodeAuthPacket(authPacket);

                default:
                    throw new MqttProtocolViolationException("Packet type invalid.");
            }
        }

        static byte EncodePingReqPacket()
        {
            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PingReq);
        }

        static byte EncodePingRespPacket()
        {
            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PingResp);
        }

        byte EncodePubAckPacket(MqttPubAckPacket packet)
        {
            if (packet.PacketIdentifier == 0)
            {
                throw new MqttProtocolViolationException("PubAck packet has no packet identifier.");
            }

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            if (_bufferWriter.Length > 0 || packet.ReasonCode != MqttPubAckReasonCode.Success)
            {
                _bufferWriter.WriteByte((byte)packet.ReasonCode);
                _propertiesWriter.WriteTo(_bufferWriter);
                _propertiesWriter.Reset();
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubAck);
        }

        byte EncodePubCompPacket(MqttPubCompPacket packet)
        {
            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            if (_propertiesWriter.Length > 0 || packet.ReasonCode != MqttPubCompReasonCode.Success)
            {
                _bufferWriter.WriteByte((byte)packet.ReasonCode);
                _propertiesWriter.WriteTo(_bufferWriter);
                _propertiesWriter.Reset();
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubComp);
        }

        byte EncodePublishPacket(MqttPublishPacket packet)
        {
            if (packet.QualityOfServiceLevel == 0 && packet.Dup)
            {
                throw new MqttProtocolViolationException("Dup flag must be false for QoS 0 packets [MQTT-3.3.1-2].");
            }

            _bufferWriter.WriteString(packet.Topic);

            if (packet.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
            {
                if (packet.PacketIdentifier == 0)
                {
                    throw new MqttProtocolViolationException("Publish packet has no packet identifier.");
                }

                _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);
            }
            else
            {
                if (packet.PacketIdentifier > 0)
                {
                    throw new MqttProtocolViolationException("Packet identifier must be 0 if QoS == 0 [MQTT-2.3.1-5].");
                }
            }

            _propertiesWriter.WriteContentType(packet.ContentType);
            _propertiesWriter.WriteCorrelationData(packet.CorrelationData);
            _propertiesWriter.WriteMessageExpiryInterval(packet.MessageExpiryInterval);
            _propertiesWriter.WritePayloadFormatIndicator(packet.PayloadFormatIndicator);
            _propertiesWriter.WriteResponseTopic(packet.ResponseTopic);
            _propertiesWriter.WriteSubscriptionIdentifiers(packet.SubscriptionIdentifiers);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);
            _propertiesWriter.WriteTopicAlias(packet.TopicAlias);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            // The payload is the past part of the packet. But it is not added here in order to keep
            // memory allocation low.

            byte fixedHeader = 0;

            if (packet.Retain)
            {
                fixedHeader |= 0x01;
            }

            fixedHeader |= (byte)((byte)packet.QualityOfServiceLevel << 1);

            if (packet.Dup)
            {
                fixedHeader |= 0x08;
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Publish, fixedHeader);
        }

        byte EncodePubRecPacket(MqttPubRecPacket packet)
        {
            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (_bufferWriter.Length > 0 || packet.ReasonCode != MqttPubRecReasonCode.Success)
            {
                _bufferWriter.WriteByte((byte)packet.ReasonCode);
                _propertiesWriter.WriteTo(_bufferWriter);
                _propertiesWriter.Reset();
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubRec);
        }

        byte EncodePubRelPacket(MqttPubRelPacket packet)
        {
            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (_propertiesWriter.Length > 0 || packet.ReasonCode != MqttPubRelReasonCode.Success)
            {
                _bufferWriter.WriteByte((byte)packet.ReasonCode);
                _propertiesWriter.WriteTo(_bufferWriter);
                _propertiesWriter.Reset();
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.PubRel, 0x02);
        }

        byte EncodeSubAckPacket(MqttSubAckPacket packet)
        {
            if (packet.ReasonCodes?.Any() != true)
            {
                throw new MqttProtocolViolationException("At least one reason code must be set[MQTT - 3.8.3 - 3].");
            }

            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            foreach (var reasonCode in packet.ReasonCodes)
            {
                _bufferWriter.WriteByte((byte)reasonCode);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.SubAck);
        }

        byte EncodeSubscribePacket(MqttSubscribePacket packet)
        {
            if (packet.TopicFilters?.Any() != true)
            {
                throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.8.3-3].");
            }

            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            if (packet.SubscriptionIdentifier > 0)
            {
                _propertiesWriter.WriteSubscriptionIdentifier(packet.SubscriptionIdentifier);
            }

            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            if (packet.TopicFilters?.Count > 0)
            {
                foreach (var topicFilter in packet.TopicFilters)
                {
                    _bufferWriter.WriteString(topicFilter.Topic);

                    var options = (byte)topicFilter.QualityOfServiceLevel;

                    if (topicFilter.NoLocal)
                    {
                        options |= 1 << 2;
                    }

                    if (topicFilter.RetainAsPublished)
                    {
                        options |= 1 << 3;
                    }

                    if (topicFilter.RetainHandling != MqttRetainHandling.SendAtSubscribe)
                    {
                        options |= (byte)((byte)topicFilter.RetainHandling << 4);
                    }

                    _bufferWriter.WriteByte(options);
                }
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Subscribe, 0x02);
        }

        byte EncodeUnsubAckPacket(MqttUnsubAckPacket packet)
        {
            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            _propertiesWriter.WriteReasonString(packet.ReasonString);
            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            foreach (var reasonCode in packet.ReasonCodes)
            {
                _bufferWriter.WriteByte((byte)reasonCode);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.UnsubAck);
        }

        byte EncodeUnsubscribePacket(MqttUnsubscribePacket packet)
        {
            if (packet.TopicFilters?.Any() != true)
            {
                throw new MqttProtocolViolationException("At least one topic filter must be set [MQTT-3.10.3-2].");
            }

            ThrowIfPacketIdentifierIsInvalid(packet.PacketIdentifier, packet);

            _bufferWriter.WriteTwoByteInteger(packet.PacketIdentifier);

            _propertiesWriter.WriteUserProperties(packet.UserProperties);

            _propertiesWriter.WriteTo(_bufferWriter);
            _propertiesWriter.Reset();

            foreach (var topicFilter in packet.TopicFilters)
            {
                _bufferWriter.WriteString(topicFilter);
            }

            return MqttBufferWriter.BuildFixedHeader(MqttControlPacketType.Unsubscribe, 0x02);
        }

        static void ThrowIfPacketIdentifierIsInvalid(ushort packetIdentifier, MqttPacket packet)
        {
            // SUBSCRIBE, UNSUBSCRIBE, and PUBLISH(in cases where QoS > 0) Control Packets MUST contain a non-zero 16 - bit Packet Identifier[MQTT - 2.3.1 - 1]. 

            if (packetIdentifier == 0)
            {
                throw new MqttProtocolViolationException($"Packet identifier is not set for {packet.GetType().Name}.");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttV5PacketFormatter : IMqttPacketFormatter
    {
        readonly MqttV5PacketDecoder _decoder = new MqttV5PacketDecoder();
        readonly MqttV5PacketEncoder _encoder;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferWriter"></param>
        public MqttV5PacketFormatter(MqttBufferWriter bufferWriter)
        {
            _encoder = new MqttV5PacketEncoder(bufferWriter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedMqttPacket"></param>
        /// <returns></returns>
        public MqttPacket Decode(ReceivedMqttPacket receivedMqttPacket)
        {
            return _decoder.Decode(receivedMqttPacket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttPacket"></param>
        /// <returns></returns>
        public MqttPacketBuffer Encode(MqttPacket mqttPacket)
        {
            return _encoder.Encode(mqttPacket);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public struct MqttV5PropertiesReader
    {
        readonly MqttBufferReader _body;
        readonly int _length;
        readonly int _targetOffset;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttV5PropertiesReader(MqttBufferReader body)
        {
            _body = body ?? throw new ArgumentNullException(nameof(body));

            if (!body.EndOfStream)
            {
                _length = (int)body.ReadVariableByteInteger();
            }
            else
            {
                _length = 0;
            }

            _targetOffset = body.Position + _length;

            CollectedUserProperties = null;
            CurrentPropertyId = MqttPropertyId.None;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> CollectedUserProperties { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttPropertyId CurrentPropertyId { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            while (true)
            {
                if (_length == 0)
                {
                    return false;
                }

                if (_body.Position >= _targetOffset)
                {
                    return false;
                }

                CurrentPropertyId = (MqttPropertyId)_body.ReadByte();

                // User properties are special because they can appear multiple times in the
                // buffer and at any position. So we collect them here to expose them as a 
                // final result list.
                if (CurrentPropertyId == MqttPropertyId.UserProperty)
                {
                    var name = _body.ReadString();
                    var value = _body.ReadString();

                    if (CollectedUserProperties == null)
                    {
                        CollectedUserProperties = new List<MqttUserProperty>();
                    }

                    CollectedUserProperties.Add(new MqttUserProperty(name, value));
                    continue;
                }

                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadAssignedClientIdentifier()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ReadAuthenticationData()
        {
            return _body.ReadBinaryData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadAuthenticationMethod()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadContentType()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ReadCorrelationData()
        {
            return _body.ReadBinaryData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadMaximumPacketSize()
        {
            return _body.ReadFourByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public MqttQualityOfServiceLevel ReadMaximumQoS()
        {
            var value = _body.ReadByte();
            if (value > 1)
            {
                throw new MqttProtocolViolationException($"Unexpected Maximum QoS value: {value}");
            }

            return (MqttQualityOfServiceLevel)value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadMessageExpiryInterval()
        {
            return _body.ReadFourByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttPayloadFormatIndicator ReadPayloadFormatIndicator()
        {
            return (MqttPayloadFormatIndicator)_body.ReadByte();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadReasonString()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort ReadReceiveMaximum()
        {
            return _body.ReadTwoByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadResponseInformation()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadResponseTopic()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadRetainAvailable()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort ReadServerKeepAlive()
        {
            return _body.ReadTwoByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadServerReference()
        {
            return _body.ReadString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadSessionExpiryInterval()
        {
            return _body.ReadFourByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadSharedSubscriptionAvailable()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadSubscriptionIdentifier()
        {
            return _body.ReadVariableByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadSubscriptionIdentifiersAvailable()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort ReadTopicAlias()
        {
            return _body.ReadTwoByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ushort ReadTopicAliasMaximum()
        {
            return _body.ReadTwoByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadWildcardSubscriptionAvailable()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint ReadWillDelayInterval()
        {
            return _body.ReadFourByteInteger();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RequestProblemInformation()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RequestResponseInformation()
        {
            return _body.ReadByte() == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="MqttProtocolViolationException"></exception>
        public void ThrowInvalidPropertyIdException(Type type)
        {
            throw new MqttProtocolViolationException($"Property ID '{CurrentPropertyId}' is not supported for package type '{type.Name}'.");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttV5PropertiesWriter
    {
        readonly MqttBufferWriter _bufferWriter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferWriter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttV5PropertiesWriter(MqttBufferWriter bufferWriter)
        {
            _bufferWriter = bufferWriter ?? throw new ArgumentNullException(nameof(bufferWriter));
        }
        /// <summary>
        /// 
        /// </summary>
        public int Length => _bufferWriter.Length;
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _bufferWriter.Reset(0);
            _bufferWriter.Cleanup();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteAssignedClientIdentifier(string value)
        {
            Write(MqttPropertyId.AssignedClientIdentifier, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteAuthenticationData(byte[] value)
        {
            Write(MqttPropertyId.AuthenticationData, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteAuthenticationMethod(string value)
        {
            Write(MqttPropertyId.AuthenticationMethod, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteContentType(string value)
        {
            Write(MqttPropertyId.ContentType, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteCorrelationData(byte[] value)
        {
            Write(MqttPropertyId.CorrelationData, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteMaximumPacketSize(uint value)
        {
            // It is a Protocol Error to include the Maximum Packet Size more than once, or for the value to be set to zero.
            if (value == 0)
            {
                return;
            }

            WriteAsFourByteInteger(MqttPropertyId.MaximumPacketSize, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteMaximumQoS(MqttQualityOfServiceLevel value)
        {
            // It is a Protocol Error to include Maximum QoS more than once, or to have a value other than 0 or 1. If the Maximum QoS is absent, the Client uses a Maximum QoS of 2.
            if (value == MqttQualityOfServiceLevel.ExactlyOnce)
            {
                return;
            }

            if (value == MqttQualityOfServiceLevel.AtLeastOnce)
            {
                Write(MqttPropertyId.MaximumQoS, 0x1);
            }
            else
            {
                Write(MqttPropertyId.MaximumQoS, 0x0);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteMessageExpiryInterval(uint value)
        {
            // If absent, the Application Message does not expire.
            // This library uses 0 to indicate no expiration.
            if (value == 0)
            {
                return;
            }

            WriteAsFourByteInteger(MqttPropertyId.MessageExpiryInterval, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WritePayloadFormatIndicator(MqttPayloadFormatIndicator value)
        {
            // 0 (0x00) Byte Indicates that the Payload is unspecified bytes, which is equivalent to not sending a Payload Format Indicator.
            if (value == MqttPayloadFormatIndicator.Unspecified)
            {
                return;
            }

            Write(MqttPropertyId.PayloadFormatIndicator, (byte)value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteReasonString(string value)
        {
            Write(MqttPropertyId.ReasonString, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteReceiveMaximum(ushort value)
        {
            // It is a Protocol Error to include the Receive Maximum value more than once or for it to have the value 0.
            if (value == 0)
            {
                return;
            }

            Write(MqttPropertyId.ReceiveMaximum, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteRequestProblemInformation(bool value)
        {
            // If the Request Problem Information is absent, the value of 1 is used.
            if (value)
            {
                return;
            }

            Write(MqttPropertyId.RequestProblemInformation, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteRequestResponseInformation(bool value)
        {
            // If the Request Response Information is absent, the value of 0 is used.
            if (!value)
            {
                return;
            }

            Write(MqttPropertyId.RequestResponseInformation, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteResponseInformation(string value)
        {
            Write(MqttPropertyId.ResponseInformation, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteResponseTopic(string value)
        {
            Write(MqttPropertyId.ResponseTopic, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteRetainAvailable(bool value)
        {
            if (value)
            {
                // Absence of the flag means it is supported! 
                return;
            }

            Write(MqttPropertyId.RetainAvailable, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteServerKeepAlive(ushort value)
        {
            if (value == 0)
            {
                return;
            }

            Write(MqttPropertyId.ServerKeepAlive, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteServerReference(string value)
        {
            Write(MqttPropertyId.ServerReference, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteSessionExpiryInterval(uint value)
        {
            // If the Session Expiry Interval is absent the value 0 is used.
            if (value == 0)
            {
                return;
            }

            WriteAsFourByteInteger(MqttPropertyId.SessionExpiryInterval, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteSharedSubscriptionAvailable(bool value)
        {
            if (value)
            {
                // Absence of the flag means it is supported! 
                return;
            }

            Write(MqttPropertyId.SharedSubscriptionAvailable, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteSubscriptionIdentifier(uint value)
        {
            WriteAsVariableByteInteger(MqttPropertyId.SubscriptionIdentifier, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteSubscriptionIdentifiers(ICollection<uint> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var subscriptionIdentifier in value)
            {
                WriteAsVariableByteInteger(MqttPropertyId.SubscriptionIdentifier, subscriptionIdentifier);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteSubscriptionIdentifiersAvailable(bool value)
        {
            if (value)
            {
                // Absence of the flag means it is supported! 
                return;
            }

            Write(MqttPropertyId.SubscriptionIdentifiersAvailable, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void WriteTo(MqttBufferWriter target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.WriteVariableByteInteger((uint)_bufferWriter.Length);
            target.Write(_bufferWriter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteTopicAlias(ushort value)
        {
            // A Topic Alias of 0 is not permitted. A sender MUST NOT send a PUBLISH packet containing a Topic Alias which has the value 0.
            if (value == 0)
            {
                return;
            }

            Write(MqttPropertyId.TopicAlias, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteTopicAliasMaximum(ushort value)
        {
            // If the Topic Alias Maximum property is absent, the default value is 0.
            if (value == 0)
            {
                return;
            }

            Write(MqttPropertyId.TopicAliasMaximum, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProperties"></param>
        public void WriteUserProperties(List<MqttUserProperty> userProperties)
        {
            if (userProperties == null || userProperties.Count == 0)
            {
                return;
            }

            foreach (var property in userProperties)
            {
                _bufferWriter.WriteByte((byte)MqttPropertyId.UserProperty);
                _bufferWriter.WriteString(property.Name);
                _bufferWriter.WriteString(property.Value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteWildcardSubscriptionAvailable(bool value)
        {
            // If not present, then Wildcard Subscriptions are supported.
            if (value)
            {
                return;
            }

            Write(MqttPropertyId.WildcardSubscriptionAvailable, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WriteWillDelayInterval(uint value)
        {
            // If the Will Delay Interval is absent, the default value is 0 and there is no delay before the Will Message is published.
            if (value == 0)
            {
                return;
            }

            WriteAsFourByteInteger(MqttPropertyId.WillDelayInterval, value);
        }

        void Write(MqttPropertyId id, bool value)
        {
            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteByte(value ? (byte)0x1 : (byte)0x0);
        }

        void Write(MqttPropertyId id, byte value)
        {
            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteByte(value);
        }

        void Write(MqttPropertyId id, ushort value)
        {
            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteTwoByteInteger(value);
        }

        void Write(MqttPropertyId id, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteString(value);
        }

        void Write(MqttPropertyId id, byte[] value)
        {
            if (value == null)
            {
                return;
            }

            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteBinaryData(value);
        }

        void WriteAsFourByteInteger(MqttPropertyId id, uint value)
        {
            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteByte((byte)(value >> 24));
            _bufferWriter.WriteByte((byte)(value >> 16));
            _bufferWriter.WriteByte((byte)(value >> 8));
            _bufferWriter.WriteByte((byte)value);
        }

        void WriteAsVariableByteInteger(MqttPropertyId id, uint value)
        {
            _bufferWriter.WriteByte((byte)id);
            _bufferWriter.WriteVariableByteInteger(value);
        }
    }
    #endregion V5
    #endregion Formatter
    #region // Implementations
    /// <summary>
    /// 跨平台Socket
    /// </summary>
    public sealed class CrossPlatformSocket : IDisposable
    {
        readonly Socket _socket;

#if !NET5_0_OR_GREATER
        readonly Action _socketDisposeAction;
#endif

        NetworkStream _networkStream;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressFamily"></param>
        public CrossPlatformSocket(AddressFamily addressFamily)
        {
            _socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);

#if !NET5_0_OR_GREATER
            _socketDisposeAction = _socket.Dispose;
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public CrossPlatformSocket()
        {
            // Having this constructor is important because avoiding the address family as parameter
            // will make use of dual mode in the .net framework.
#if NET40
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
#else
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
#endif

#if !NET5_0_OR_GREATER
            _socketDisposeAction = _socket.Dispose;
#endif
        }

        CrossPlatformSocket(Socket socket)
        {
            _socket = socket ?? throw new ArgumentNullException(nameof(socket));
            _networkStream = new NetworkStream(socket, true);

#if !NET5_0_OR_GREATER
            _socketDisposeAction = _socket.Dispose;
#endif
        }
#if !NET40
        /// <summary>
        /// 
        /// </summary>
        public bool DualMode
        {
            get => _socket.DualMode;
            set => _socket.DualMode = value;
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected => _socket.Connected;
        /// <summary>
        /// 
        /// </summary>
        public bool KeepAlive
        {
            get => _socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive) as int? == 1;
            set => _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, value ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        public int TcpKeepAliveInterval
        {
#if NETCOREAPP3_0_OR_GREATER
            get => _socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval) as int? ?? 0;
            set => _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval, value);
#else
            get { throw new NotSupportedException("TcpKeepAliveInterval requires at least net5.0."); }
            set { throw new NotSupportedException("TcpKeepAliveInterval requires at least net5.0."); }
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public int TcpKeepAliveRetryCount
        {
#if NETCOREAPP3_0_OR_GREATER
            get => _socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveRetryCount) as int? ?? 0;
            set => _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveRetryCount, value);
#else
            get { throw new NotSupportedException("TcpKeepAliveRetryCount requires at least net5.0."); }
            set { throw new NotSupportedException("TcpKeepAliveRetryCount requires at least net5.0."); }
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public int TcpKeepAliveTime
        {
#if NETCOREAPP3_0_OR_GREATER
            get => _socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime) as int? ?? 0;
            set => _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime, value);
#else
            get { throw new NotSupportedException("TcpKeepAliveTime requires at least net5.0."); }
            set { throw new NotSupportedException("TcpKeepAliveTime requires at least net5.0."); }
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public LingerOption LingerState
        {
            get => _socket.LingerState;
            set => _socket.LingerState = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public EndPoint LocalEndPoint => _socket.LocalEndPoint;
        /// <summary>
        /// 
        /// </summary>
        public bool NoDelay
        {
            // We cannot use the _NoDelay_ property from the socket because there is an issue in .NET 4.5.2, 4.6.
            // The decompiled code is: this.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, value ? 1 : 0);
            // Which is wrong because the "NoDelay" should be set and not "Debug".
            get => (int?)_socket.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay) != 0;
            set => _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, value ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReceiveBufferSize
        {
            get => _socket.ReceiveBufferSize;
            set => _socket.ReceiveBufferSize = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public EndPoint RemoteEndPoint => _socket.RemoteEndPoint;
        /// <summary>
        /// 
        /// </summary>
        public bool ReuseAddress
        {
            get => _socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress) as int? != 0;
            set => _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, value ? 1 : 0);
        }
        /// <summary>
        /// 
        /// </summary>
        public int SendBufferSize
        {
            get => _socket.SendBufferSize;
            set => _socket.SendBufferSize = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int SendTimeout
        {
            get => _socket.SendTimeout;
            set => _socket.SendTimeout = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CrossPlatformSocket> AcceptAsync()
        {
            try
            {
#if NET452 || NET461 || NET40 || NET45
                var clientSocket = await Task.Factory.FromAsync(_socket.BeginAccept, _socket.EndAccept, null).ConfigureAwait(false);
#else
                var clientSocket = await _socket.AcceptAsync().ConfigureAwait(false);
#endif
                return new CrossPlatformSocket(clientSocket);
            }
            catch (ObjectDisposedException)
            {
                // This will happen when _socket.EndAccept gets called by Task library but the socket is already disposed.
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localEndPoint"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Bind(EndPoint localEndPoint)
        {
            if (localEndPoint is null)
            {
                throw new ArgumentNullException(nameof(localEndPoint));
            }

            _socket.Bind(localEndPoint);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="MqttCommunicationTimedOutException"></exception>
        /// <exception cref="MqttCommunicationException"></exception>
        public async Task ConnectAsync(string host, int port, CancellationToken cancellationToken)
        {
            if (host is null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            cancellationToken.ThrowIfCancellationRequested();

            try
            {
#if NET5_0_OR_GREATER

                if (_networkStream != null)
                {
                    await _networkStream.DisposeAsync().ConfigureAwait(false);
                }

                await _socket.ConnectAsync(host, port, cancellationToken).ConfigureAwait(false);
#else
                _networkStream?.Dispose();

                // Workaround for: https://github.com/dotnet/corefx/issues/24430
                using (cancellationToken.Register(_socketDisposeAction))
                {
#if NET452 || NET461 || NET40 || NET45
                    await Task.Factory.FromAsync(_socket.BeginConnect, _socket.EndConnect, host, port, null).ConfigureAwait(false);
#else
                    await _socket.ConnectAsync(host, port).ConfigureAwait(false);
#endif
                }
#endif
                _networkStream = new NetworkStream(_socket, true);
            }
            catch (SocketException socketException)
            {
                if (socketException.SocketErrorCode == SocketError.OperationAborted)
                {
                    throw new OperationCanceledException();
                }

                if (socketException.SocketErrorCode == SocketError.TimedOut)
                {
                    throw new MqttCommunicationTimedOutException();
                }

                throw new MqttCommunicationException($"Error while connecting with host '{host}:{port}'.", socketException);
            }
            catch (ObjectDisposedException)
            {
                // This will happen when _socket.EndConnect gets called by Task library but the socket is already disposed.
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _networkStream?.Dispose();
            _socket?.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public NetworkStream GetStream()
        {
            var networkStream = _networkStream;
            if (networkStream == null)
            {
                throw new IOException("The socket is not connected.");
            }

            return networkStream;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionBacklog"></param>
        public void Listen(int connectionBacklog)
        {
            _socket.Listen(connectionBacklog);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="socketFlags"></param>
        /// <returns></returns>
        public async Task<int> ReceiveAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
        {
            try
            {
#if NET452 || NET461 || NET40 || NET45
                return await Task.Factory.FromAsync(SocketWrapper.BeginReceive, _socket.EndReceive, new SocketWrapper(_socket, buffer, socketFlags)).ConfigureAwait(false);
#else
                return await _socket.ReceiveAsync(buffer, socketFlags).ConfigureAwait(false);
#endif
            }
            catch (ObjectDisposedException)
            {
                // This will happen when _socket.EndReceive gets called by Task library but the socket is already disposed.
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="socketFlags"></param>
        /// <returns></returns>
        public async Task SendAsync(ArraySegment<byte> buffer, SocketFlags socketFlags)
        {
            try
            {
#if NET452 || NET461 || NET40 || NET45
                await Task.Factory.FromAsync(SocketWrapper.BeginSend, _socket.EndSend, new SocketWrapper(_socket, buffer, socketFlags)).ConfigureAwait(false);
#else
                await _socket.SendAsync(buffer, socketFlags).ConfigureAwait(false);
#endif
            }
            catch (ObjectDisposedException)
            {
                // This will happen when _socket.EndConnect gets called by Task library but the socket is already disposed.
            }
        }

#if NET452 || NET461 || NET40 || NET45
        sealed class SocketWrapper
        {
            readonly ArraySegment<byte> _buffer;
            readonly Socket _socket;
            readonly SocketFlags _socketFlags;

            public SocketWrapper(Socket socket, ArraySegment<byte> buffer, SocketFlags socketFlags)
            {
                _socket = socket;
                _buffer = buffer;
                _socketFlags = socketFlags;
            }

            public static IAsyncResult BeginReceive(AsyncCallback callback, object state)
            {
                var socketWrapper = (SocketWrapper)state;
                return socketWrapper._socket.BeginReceive(
                    socketWrapper._buffer.Array,
                    socketWrapper._buffer.Offset,
                    socketWrapper._buffer.Count,
                    socketWrapper._socketFlags,
                    callback,
                    state);
            }

            public static IAsyncResult BeginSend(AsyncCallback callback, object state)
            {
                var socketWrapper = (SocketWrapper)state;
                return socketWrapper._socket.BeginSend(
                    socketWrapper._buffer.Array,
                    socketWrapper._buffer.Offset,
                    socketWrapper._buffer.Count,
                    socketWrapper._socketFlags,
                    callback,
                    state);
            }
        }
#endif
    }
    /// <summary>
    /// MQTT客户端代理工厂
    /// </summary>
    public sealed class MqttClientAdapterFactory : IMqttClientAdapterFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="packetInspector"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
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
                        break;
#endif
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
#if WINDOWS_UWP
    /// <summary>
    /// MQTT的TCP通道
    /// </summary>
    public sealed class MqttTcpChannel : IMqttChannel
    {
        readonly MqttClientTcpOptions _options;
        readonly int _bufferSize;

        StreamSocket _socket;
        Stream _readStream;
        Stream _writeStream;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        public MqttTcpChannel(MqttClientOptions clientOptions)
        {
            _options = (MqttClientTcpOptions)clientOptions.ChannelOptions;
            _bufferSize = _options.BufferSize;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="clientCertificate"></param>
        /// <param name="serverOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttTcpChannel(StreamSocket socket, X509Certificate2 clientCertificate, MqttServerOptions serverOptions)
        {
            _socket = socket ?? throw new ArgumentNullException(nameof(socket));
            _bufferSize = serverOptions.DefaultEndpointOptions.BufferSize;

            CreateStreams();

            IsSecureConnection = socket.Information.ProtectionLevel >= SocketProtectionLevel.Tls12;
            ClientCertificate = clientCertificate;

            Endpoint = _socket.Information.RemoteAddress + ":" + _socket.Information.RemotePort;
        }
        /// <summary>
        /// 
        /// </summary>
        public static Func<MqttClientTcpOptions, IEnumerable<ChainValidationResult>> CustomIgnorableServerCertificateErrorsResolver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSecureConnection { get; }
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate2 ClientCertificate { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            if (_socket == null)
            {
                _socket = new StreamSocket();
                _socket.Control.NoDelay = _options.NoDelay;
                _socket.Control.KeepAlive = true;
            }

            if (_options.TlsOptions?.UseTls != true)
            {
                await _socket.ConnectAsync(new HostName(_options.Server), _options.GetPort().ToString()).AsTask().ConfigureAwait(false);
            }
            else
            {
                _socket.Control.ClientCertificate = LoadCertificate(_options);

                foreach (var ignorableChainValidationResult in ResolveIgnorableServerCertificateErrors())
                {
                    _socket.Control.IgnorableServerCertificateErrors.Add(ignorableChainValidationResult);
                }

                var socketProtectionLevel = SocketProtectionLevel.Tls12;
                if (_options.TlsOptions.SslProtocol == SslProtocols.Tls11)
                {
                    socketProtectionLevel = SocketProtectionLevel.Tls11;
                }
                else if (_options.TlsOptions.SslProtocol == SslProtocols.Tls)
                {
                    socketProtectionLevel = SocketProtectionLevel.Tls10;
                }

                await _socket.ConnectAsync(new HostName(_options.Server), _options.GetPort().ToString(), socketProtectionLevel).AsTask().ConfigureAwait(false);
            }

            Endpoint = _socket.Information.RemoteAddress + ":" + _socket.Information.RemotePort;

            CreateStreams();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DisconnectAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.FromResult(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return _readStream.ReadAsync(buffer, offset, count, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isEndOfPacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task WriteAsync(ArraySegment<byte> buffer, bool isEndOfPacket, CancellationToken cancellationToken)
        {
            // In the write method only the internal buffer will be filled. So here is no
            // async/await required. The real network transmit is done when calling the
            // Flush method.
            _writeStream.Write(buffer.Array, buffer.Offset, buffer.Count);
            return _writeStream.FlushAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            TryDispose(_readStream, () => _readStream = null);
            TryDispose(_writeStream, () => _writeStream = null);
            TryDispose(_socket, () => _socket = null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private static Certificate LoadCertificate(IMqttClientChannelOptions options)
        {
            if (options.TlsOptions.Certificates == null || !options.TlsOptions.Certificates.Any())
            {
                return null;
            }

            if (options.TlsOptions.Certificates.Count > 1)
            {
                throw new NotSupportedException("Only one client certificate is supported when using 'uap10.0'.");
            }

            return new Certificate(options.TlsOptions.Certificates.First().AsBuffer());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ChainValidationResult> ResolveIgnorableServerCertificateErrors()
        {
            if (CustomIgnorableServerCertificateErrorsResolver != null)
            {
                return CustomIgnorableServerCertificateErrorsResolver(_options);
            }

            var result = new List<ChainValidationResult>();

            if (_options.TlsOptions.IgnoreCertificateRevocationErrors)
            {
                result.Add(ChainValidationResult.RevocationInformationMissing);
                //_socket.Control.IgnorableServerCertificateErrors.Add(ChainValidationResult.Revoked); Not supported.
                result.Add(ChainValidationResult.RevocationFailure);
            }

            if (_options.TlsOptions.IgnoreCertificateChainErrors)
            {
                result.Add(ChainValidationResult.IncompleteChain);
            }

            if (_options.TlsOptions.AllowUntrustedCertificates)
            {
                result.Add(ChainValidationResult.Untrusted);
            }

            return result;
        }

        private void CreateStreams()
        {
            // Attention! Do not set the buffer for the read method. This will
            // limit the internal buffer and the read operation will hang forever
            // if more data than the buffer size was received.
            _readStream = _socket.InputStream.AsStreamForRead();

            _writeStream = _socket.OutputStream.AsStreamForWrite(_bufferSize);
        }

        private static void TryDispose(IDisposable disposable, Action afterDispose)
        {
            try
            {
                disposable?.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (NullReferenceException)
            {
            }
            finally
            {
                afterDispose();
            }
        }
    }
#else
    /// <summary>
    /// MQTT的TCP通道
    /// </summary>
    public sealed class MqttTcpChannel : IMqttChannel
    {
        readonly MqttClientOptions _clientOptions;
        readonly Action _disposeAction;
        readonly MqttClientTcpOptions _tcpOptions;

        Stream _stream;
        /// <summary>
        /// 构造
        /// </summary>
        public MqttTcpChannel()
        {
            _disposeAction = Dispose;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="clientOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttTcpChannel(MqttClientOptions clientOptions) : this()
        {
            _clientOptions = clientOptions ?? throw new ArgumentNullException(nameof(clientOptions));
            _tcpOptions = (MqttClientTcpOptions)clientOptions.ChannelOptions;

            IsSecureConnection = clientOptions.ChannelOptions?.TlsOptions?.UseTls == true;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="endpoint"></param>
        /// <param name="clientCertificate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttTcpChannel(Stream stream, string endpoint, X509Certificate2 clientCertificate) : this()
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));

            Endpoint = endpoint;

            IsSecureConnection = stream is SslStream;
            ClientCertificate = clientCertificate;
        }
        /// <summary>
        /// 客户端证书
        /// </summary>
        public X509Certificate2 ClientCertificate { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSecureConnection { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            CrossPlatformSocket socket = null;
            try
            {
                if (_tcpOptions.AddressFamily == AddressFamily.Unspecified)
                {
                    socket = new CrossPlatformSocket();
                }
                else
                {
                    socket = new CrossPlatformSocket(_tcpOptions.AddressFamily);
                }

                if (_tcpOptions.LocalEndpoint != null)
                {
                    socket.Bind(_tcpOptions.LocalEndpoint);
                }

                socket.ReceiveBufferSize = _tcpOptions.BufferSize;
                socket.SendBufferSize = _tcpOptions.BufferSize;
                socket.SendTimeout = (int)_clientOptions.Timeout.TotalMilliseconds;
                socket.NoDelay = _tcpOptions.NoDelay;

                if (socket.LingerState != null)
                {
                    socket.LingerState = _tcpOptions.LingerState;
                }

                if (_tcpOptions.DualMode.HasValue)
                {
                    // It is important to avoid setting the flag if no specific value is set by the user
                    // because on IPv4 only networks the setter will always throw an exception. Regardless
                    // of the actual value.
#if !NET40
                    socket.DualMode = _tcpOptions.DualMode.Value;
#endif
                }

                await socket.ConnectAsync(_tcpOptions.Server, _tcpOptions.GetPort(), cancellationToken).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested();

                var networkStream = socket.GetStream();

                if (_tcpOptions.TlsOptions?.UseTls == true)
                {
                    var sslStream = new SslStream(networkStream, false, InternalUserCertificateValidationCallback);
                    try
                    {
#if NETCOREAPP3_1 || NET5_0_OR_GREATER
                        var sslOptions = new SslClientAuthenticationOptions
                        {
                            ApplicationProtocols = _tcpOptions.TlsOptions.ApplicationProtocols,
                            ClientCertificates = LoadCertificates(),
                            EnabledSslProtocols = _tcpOptions.TlsOptions.SslProtocol,
                            CertificateRevocationCheckMode =
 _tcpOptions.TlsOptions.IgnoreCertificateRevocationErrors ? X509RevocationMode.NoCheck : _tcpOptions.TlsOptions.RevocationMode,
                            TargetHost = _tcpOptions.Server,
                            CipherSuitesPolicy = _tcpOptions.TlsOptions.CipherSuitesPolicy
                        };

                        await sslStream.AuthenticateAsClientAsync(sslOptions, cancellationToken).ConfigureAwait(false);
#elif NET40
                        await AuthenticateAsClientAsync(sslStream,
                                _tcpOptions.Server,
                                LoadCertificates(),
                                _tcpOptions.TlsOptions.SslProtocol,
                                !_tcpOptions.TlsOptions.IgnoreCertificateRevocationErrors)
                            .ConfigureAwait(false);
                        Task AuthenticateAsClientAsync(SslStream _SslState, string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation)
                        {
                            return Task.Factory.FromAsync((AsyncCallback callback, object state) => _SslState.BeginAuthenticateAsClient(targetHost, clientCertificates, enabledSslProtocols, checkCertificateRevocation, callback, state), _SslState.EndAuthenticateAsClient, null);
                        }
#else
                        await sslStream.AuthenticateAsClientAsync(
                                _tcpOptions.Server,
                                LoadCertificates(),
                                _tcpOptions.TlsOptions.SslProtocol,
                                !_tcpOptions.TlsOptions.IgnoreCertificateRevocationErrors)
                            .ConfigureAwait(false);
#endif
                    }
                    catch
                    {
#if NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0_OR_GREATER
                        await sslStream.DisposeAsync().ConfigureAwait(false);
#else
                        sslStream.Dispose();
#endif

                        throw;
                    }

                    _stream = sslStream;
                }
                else
                {
                    _stream = networkStream;
                }

                Endpoint = socket.RemoteEndPoint?.ToString();
            }
            catch (Exception)
            {
                socket?.Dispose();
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DisconnectAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return CompletedTask.Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // When the stream is disposed it will also close the socket and this will also dispose it.
            // So there is no need to dispose the socket again.
            // https://stackoverflow.com/questions/3601521/should-i-manually-dispose-the-socket-after-closing-it
            try
            {
#if !NETSTANDARD1_3
                _stream?.Close();
#endif
                _stream?.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (NullReferenceException)
            {
            }
            finally
            {
                _stream = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var stream = _stream;

                if (stream == null)
                {
                    return 0;
                }

                if (!stream.CanRead)
                {
                    return 0;
                }

#if NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                return await stream.ReadAsync(buffer.AsMemory(offset, count), cancellationToken).ConfigureAwait(false);
#else
                // Workaround for: https://github.com/dotnet/corefx/issues/24430
                using (cancellationToken.Register(_disposeAction))
                {
                    return await stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
                }
#endif
            }
            catch (ObjectDisposedException)
            {
                // Indicate a graceful socket close.
                return 0;
            }
            catch (IOException exception)
            {
                if (exception.InnerException is SocketException socketException)
                {
#if NET40
                    throw socketException;
#else
                    ExceptionDispatchInfo.Capture(socketException).Throw();
#endif
                }

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isEndOfPacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="MqttCommunicationException"></exception>
        public async Task WriteAsync(ArraySegment<byte> buffer, bool isEndOfPacket, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var stream = _stream;

                if (stream == null)
                {
                    throw new MqttCommunicationException("The TCP connection is closed.");
                }

#if NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                await stream.WriteAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false);
#else
                // Workaround for: https://github.com/dotnet/corefx/issues/24430
                using (cancellationToken.Register(_disposeAction))
                {
                    await stream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count, cancellationToken).ConfigureAwait(false);
                }
#endif
            }
            catch (ObjectDisposedException)
            {
                throw new MqttCommunicationException("The TCP connection is closed.");
            }
            catch (IOException exception)
            {
                if (exception.InnerException is SocketException socketException)
                {
#if NET40
                    throw socketException;
#else
                    ExceptionDispatchInfo.Capture(socketException).Throw();
#endif
                }

                throw;
            }
        }

        bool InternalUserCertificateValidationCallback(object sender, X509Certificate x509Certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var certificateValidationHandler = _tcpOptions?.TlsOptions?.CertificateValidationHandler;
            if (certificateValidationHandler != null)
            {
                var eventArgs = new MqttClientCertificateValidationEventArgs
                {
                    Certificate = x509Certificate,
                    Chain = chain,
                    SslPolicyErrors = sslPolicyErrors,
                    ClientOptions = _tcpOptions
                };

                return certificateValidationHandler(eventArgs);
            }

            if (_tcpOptions?.TlsOptions?.IgnoreCertificateChainErrors ?? false)
            {
                sslPolicyErrors &= ~SslPolicyErrors.RemoteCertificateChainErrors;
            }

            return sslPolicyErrors == SslPolicyErrors.None;
        }

        X509CertificateCollection LoadCertificates()
        {
            var certificates = new X509CertificateCollection();
            if (_tcpOptions.TlsOptions.Certificates == null)
            {
                return certificates;
            }

            foreach (var certificate in _tcpOptions.TlsOptions.Certificates)
            {
                certificates.Add(certificate);
            }

            return certificates;
        }
    }
#endif
#if WINDOWS_UWP
    /// <summary>
    /// MQTT的TCP服务监听
    /// </summary>
    public sealed class MqttTcpServerAdapter : IMqttServerAdapter
    {
        IMqttNetLogger _rootLogger;
        MqttNetSourceLogger _logger;
 
        MqttServerOptions _options;
        StreamSocketListener _listener;
        /// <summary>
        /// 
        /// </summary>
        public Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public async Task StartAsync(MqttServerOptions options, IMqttNetLogger logger)
        {
            if (_listener != null) throw new InvalidOperationException("Server is already started.");

            if (logger is null) throw new ArgumentNullException(nameof(logger));
            _rootLogger = logger;
            _logger = logger.WithSource(nameof(MqttTcpServerAdapter));

            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (options.DefaultEndpointOptions.IsEnabled)
            {
                _listener = new StreamSocketListener();

                // This also affects the client sockets.
                _listener.Control.NoDelay = options.DefaultEndpointOptions.NoDelay;
                _listener.Control.KeepAlive = true;
                _listener.Control.QualityOfService = SocketQualityOfService.LowLatency;
                _listener.ConnectionReceived += OnConnectionReceivedAsync;

                await _listener.BindServiceNameAsync(options.DefaultEndpointOptions.Port.ToString(), SocketProtectionLevel.PlainSocket);
            }

            if (options.TlsEndpointOptions.IsEnabled)
            {
                throw new NotSupportedException("TLS servers are not supported when using 'uap10.0'.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task StopAsync()
        {
            if (_listener != null)
            {
                _listener.ConnectionReceived -= OnConnectionReceivedAsync;
            }

            return Task.FromResult(0);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _listener?.Dispose();
            _listener = null;
        }

        async void OnConnectionReceivedAsync(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            try
            {
                var clientHandler = ClientHandler;
                if (clientHandler != null)
                {
                    X509Certificate2 clientCertificate = null;

                    if (args.Socket.Control.ClientCertificate != null)
                    {
                        try
                        {
                            clientCertificate = new X509Certificate2(args.Socket.Control.ClientCertificate.GetCertificateBlob().ToArray());
                        }
                        catch (Exception exception)
                        {
                            _logger.Warning(exception, "Unable to convert UWP certificate to X509Certificate2.");
                        }
                    }

                    var bufferWriter = new MqttBufferWriter(4096, 65535);
                    var packetFormatterAdapter = new MqttPacketFormatterAdapter(bufferWriter);
                    var tcpChannel = new MqttTcpChannel(args.Socket, clientCertificate, _options);

                    using (var clientAdapter = new MqttChannelAdapter(tcpChannel, packetFormatterAdapter, null, _rootLogger))
                    {
                        await clientHandler(clientAdapter).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is ObjectDisposedException)
                {
                    // It can happen that the listener socket is accessed after the cancellation token is already set and the listener socket is disposed.
                    return;
                }

                _logger.Error(exception, "Error while handling client connection.");
            }
            finally
            {
                try
                {
                    args.Socket.Dispose();
                }
                catch (Exception exception)
                {
                    _logger.Error(exception, "Error while cleaning up client connection.");
                }
            }
        }
    }
#else
    /// <summary>
    /// MQTT的TCP服务适配
    /// </summary>
    public sealed class MqttTcpServerAdapter : IMqttServerAdapter
    {
        readonly List<MqttTcpServerListener> _listeners = new List<MqttTcpServerListener>();

        MqttServerOptions _serverOptions;
        CancellationTokenSource _cancellationTokenSource;
        /// <summary>
        /// 
        /// </summary>
        public Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TreatSocketOpeningErrorAsWarning { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Task StartAsync(MqttServerOptions options, IMqttNetLogger logger)
        {
            if (_cancellationTokenSource != null) throw new InvalidOperationException("Server is already started.");

            _serverOptions = options;

            _cancellationTokenSource = new CancellationTokenSource();

            if (options.DefaultEndpointOptions.IsEnabled)
            {
                RegisterListeners(options.DefaultEndpointOptions, null, logger, _cancellationTokenSource.Token);
            }

            if (options.TlsEndpointOptions?.IsEnabled == true)
            {
                if (options.TlsEndpointOptions.CertificateProvider == null)
                {
                    throw new ArgumentException("TLS certificate is not set.");
                }

                var tlsCertificate = options.TlsEndpointOptions.CertificateProvider.GetCertificate();
                if (!tlsCertificate.HasPrivateKey)
                {
                    throw new InvalidOperationException("The certificate for TLS encryption must contain the private key.");
                }

                RegisterListeners(options.TlsEndpointOptions, tlsCertificate, logger, _cancellationTokenSource.Token);
            }

            return CompletedTask.Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task StopAsync()
        {
            Cleanup();
            return CompletedTask.Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Cleanup();
        }

        void Cleanup()
        {
            try
            {
                _cancellationTokenSource?.Cancel(false);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;

                foreach (var listener in _listeners)
                {
                    listener.Dispose();
                }

                _listeners.Clear();
            }
        }

        void RegisterListeners(MqttServerTcpEndpointBaseOptions tcpEndpointOptions, X509Certificate2 tlsCertificate, IMqttNetLogger logger, CancellationToken cancellationToken)
        {
            if (!tcpEndpointOptions.BoundInterNetworkAddress.Equals(IPAddress.None))
            {
                var listenerV4 = new MqttTcpServerListener(AddressFamily.InterNetwork, _serverOptions, tcpEndpointOptions, tlsCertificate, logger)
                {
                    ClientHandler = OnClientAcceptedAsync
                };

                if (listenerV4.Start(TreatSocketOpeningErrorAsWarning, cancellationToken))
                {
                    _listeners.Add(listenerV4);
                }
            }

            if (!tcpEndpointOptions.BoundInterNetworkV6Address.Equals(IPAddress.None))
            {
                var listenerV6 = new MqttTcpServerListener(AddressFamily.InterNetworkV6, _serverOptions, tcpEndpointOptions, tlsCertificate, logger)
                {
                    ClientHandler = OnClientAcceptedAsync
                };

                if (listenerV6.Start(TreatSocketOpeningErrorAsWarning, cancellationToken))
                {
                    _listeners.Add(listenerV6);
                }
            }
        }

        Task OnClientAcceptedAsync(IMqttChannelAdapter channelAdapter)
        {
            var clientHandler = ClientHandler;
            if (clientHandler == null)
            {
                return CompletedTask.Instance;
            }

            return clientHandler(channelAdapter);
        }
    }
#endif
#if !WINDOWS_UWP
    /// <summary>
    /// MQTT的TCP服务监听
    /// </summary>
    public sealed class MqttTcpServerListener : IDisposable
    {
        readonly MqttNetSourceLogger _logger;
        readonly IMqttNetLogger _rootLogger;
        readonly AddressFamily _addressFamily;
        readonly MqttServerOptions _serverOptions;
        readonly MqttServerTcpEndpointBaseOptions _options;
        readonly MqttServerTlsTcpEndpointOptions _tlsOptions;
        readonly X509Certificate2 _tlsCertificate;

        CrossPlatformSocket _socket;
        IPEndPoint _localEndPoint;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <param name="serverOptions"></param>
        /// <param name="tcpEndpointOptions"></param>
        /// <param name="tlsCertificate"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttTcpServerListener(
            AddressFamily addressFamily,
            MqttServerOptions serverOptions,
            MqttServerTcpEndpointBaseOptions tcpEndpointOptions,
            X509Certificate2 tlsCertificate,
            IMqttNetLogger logger)
        {
            _addressFamily = addressFamily;
            _serverOptions = serverOptions ?? throw new ArgumentNullException(nameof(serverOptions));
            _options = tcpEndpointOptions ?? throw new ArgumentNullException(nameof(tcpEndpointOptions));
            _tlsCertificate = tlsCertificate;
            _rootLogger = logger;
            _logger = logger.WithSource(nameof(MqttTcpServerListener));

            if (_options is MqttServerTlsTcpEndpointOptions tlsOptions)
            {
                _tlsOptions = tlsOptions;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Func<IMqttChannelAdapter, Task> ClientHandler { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="treatErrorsAsWarning"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public bool Start(bool treatErrorsAsWarning, CancellationToken cancellationToken)
        {
            try
            {
                var boundIp = _options.BoundInterNetworkAddress;
                if (_addressFamily == AddressFamily.InterNetworkV6)
                {
                    boundIp = _options.BoundInterNetworkV6Address;
                }

                _localEndPoint = new IPEndPoint(boundIp, _options.Port);

                _logger.Info("Starting TCP listener (Endpoint='{0}', TLS={1}).", _localEndPoint, _tlsCertificate != null);

                _socket = new CrossPlatformSocket(_addressFamily);

                // Usage of socket options is described here: https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socket.setsocketoption?view=netcore-2.2
                if (_options.ReuseAddress)
                {
                    _socket.ReuseAddress = true;
                }

                if (_options.NoDelay)
                {
                    _socket.NoDelay = true;
                }

                if (_options.LingerState != null)
                {
                    _socket.LingerState = _options.LingerState;
                }

                _socket.Bind(_localEndPoint);

                // Get the local endpoint back from the socket. The port may have changed.
                // This can happen when port 0 is used. Then the OS will choose the next free port.
                _localEndPoint = (IPEndPoint)_socket.LocalEndPoint;
                _options.Port = _localEndPoint.Port;

                _socket.Listen(_options.ConnectionBacklog);

                _logger.Verbose("TCP listener started (Endpoint='{0}'.", _localEndPoint);

                TestTry.TaskRun(() => AcceptClientConnectionsAsync(cancellationToken), cancellationToken).RunInBackground(_logger);

                return true;
            }
            catch (Exception exception)
            {
                if (!treatErrorsAsWarning)
                {
                    throw;
                }

                _logger.Warning(exception, "Error while creating listener socket for local end point '{0}'.", _localEndPoint);
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _socket?.Dispose();

#if NET452 || NET40 || NET45
#else
            _tlsCertificate?.Dispose();
#endif
        }

        async Task AcceptClientConnectionsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var clientSocket = await _socket.AcceptAsync().ConfigureAwait(false);
                    if (clientSocket == null)
                    {
                        continue;
                    }

                    _ = Task.Factory.StartNew(() => TryHandleClientConnectionAsync(clientSocket), cancellationToken, TaskCreationOptions.PreferFairness, TaskScheduler.Default).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception exception)
                {
                    if (exception is SocketException socketException)
                    {
                        if (socketException.SocketErrorCode == SocketError.ConnectionAborted ||
                            socketException.SocketErrorCode == SocketError.OperationAborted)
                        {
                            continue;
                        }
                    }

                    _logger.Error(exception, "Error while accepting connection at TCP listener {0} TLS={1}.", _localEndPoint, _tlsCertificate != null);
                    await TestTry.TaskDelay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                }
            }
        }

        async Task TryHandleClientConnectionAsync(CrossPlatformSocket clientSocket)
        {
            Stream stream = null;
            string remoteEndPoint = null;

            try
            {
                remoteEndPoint = clientSocket.RemoteEndPoint.ToString();

                _logger.Verbose("Client '{0}' accepted by TCP listener '{1}, {2}'.",
                    remoteEndPoint,
                    _localEndPoint,
                    _addressFamily == AddressFamily.InterNetwork ? "ipv4" : "ipv6");

                clientSocket.NoDelay = _options.NoDelay;
                stream = clientSocket.GetStream();
                X509Certificate2 clientCertificate = null;

                if (_tlsCertificate != null)
                {
                    var sslStream = new SslStream(stream, false, _tlsOptions.RemoteCertificateValidationCallback);

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
                        await sslStream.AuthenticateAsServerAsync(
                            new SslServerAuthenticationOptions()
                            {
                                ServerCertificate = _tlsCertificate,
                                ClientCertificateRequired = _tlsOptions.ClientCertificateRequired,
                                EnabledSslProtocols = _tlsOptions.SslProtocol,
                                CertificateRevocationCheckMode = _tlsOptions.CheckCertificateRevocation ? X509RevocationMode.Online : X509RevocationMode.NoCheck,
                                EncryptionPolicy = EncryptionPolicy.RequireEncryption,
                                CipherSuitesPolicy = _tlsOptions.CipherSuitesPolicy
                            }).ConfigureAwait(false);
#elif NET40
                    await AuthenticateAsServerAsync(sslStream,
                            _tlsCertificate,
                            _tlsOptions.ClientCertificateRequired,
                            _tlsOptions.SslProtocol,
                            _tlsOptions.CheckCertificateRevocation).ConfigureAwait(false);
                    Task AuthenticateAsServerAsync(SslStream _sslStream, X509Certificate serverCertificate, bool clientCertificateRequired, SslProtocols enabledSslProtocols, bool checkCertificateRevocation)
                    {
                        return Task.Factory.FromAsync((AsyncCallback callback, object state) => _sslStream.BeginAuthenticateAsServer(serverCertificate, clientCertificateRequired, enabledSslProtocols, checkCertificateRevocation, callback, state), _sslStream.EndAuthenticateAsServer, null);
                    }
#else
                    await sslStream.AuthenticateAsServerAsync(
                            _tlsCertificate,
                            _tlsOptions.ClientCertificateRequired,
                            _tlsOptions.SslProtocol,
                            _tlsOptions.CheckCertificateRevocation).ConfigureAwait(false);
#endif

                    stream = sslStream;

                    clientCertificate = sslStream.RemoteCertificate as X509Certificate2;

                    if (clientCertificate == null && sslStream.RemoteCertificate != null)
                    {
                        clientCertificate = new X509Certificate2(sslStream.RemoteCertificate.Export(X509ContentType.Cert));
                    }
                }

                var clientHandler = ClientHandler;
                if (clientHandler != null)
                {
                    var tcpChannel = new MqttTcpChannel(stream, remoteEndPoint, clientCertificate);
                    var bufferWriter = new MqttBufferWriter(_serverOptions.WriterBufferSize, _serverOptions.WriterBufferSizeMax);
                    var packetFormatterAdapter = new MqttPacketFormatterAdapter(bufferWriter);

                    using (var clientAdapter = new MqttChannelAdapter(tcpChannel, packetFormatterAdapter, null, _rootLogger))
                    {
                        await clientHandler(clientAdapter).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception is ObjectDisposedException)
                {
                    // It can happen that the listener socket is accessed after the cancellation token is already set and the listener socket is disposed.
                    return;
                }

                if (exception is SocketException socketException &&
                    socketException.SocketErrorCode == SocketError.OperationAborted)
                {
                    return;
                }

                _logger.Error(exception, "Error while handling client connection.");
            }
            finally
            {
                try
                {
                    stream?.Dispose();
                    clientSocket?.Dispose();
                }
                catch (Exception disposeException)
                {
                    _logger.Error(disposeException, "Error while cleaning up client connection");
                }
            }

            _logger.Verbose("Client '{0}' disconnected at TCP listener '{1}, {2}'.",
                remoteEndPoint,
                _localEndPoint,
                _addressFamily == AddressFamily.InterNetwork ? "ipv4" : "ipv6");
        }
    }
#endif
#if !NET40
    /// <summary>
    /// MQTT的WebSocket通道
    /// </summary>
    public sealed class MqttWebSocketChannel : IMqttChannel
    {
        readonly MqttClientWebSocketOptions _options;

        AsyncLock _sendLock = new AsyncLock();
        WebSocket _webSocket;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttWebSocketChannel(MqttClientWebSocketOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="endpoint"></param>
        /// <param name="isSecureConnection"></param>
        /// <param name="clientCertificate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttWebSocketChannel(WebSocket webSocket, string endpoint, bool isSecureConnection, X509Certificate2 clientCertificate)
        {
            _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));

            Endpoint = endpoint;
            IsSecureConnection = isSecureConnection;
            ClientCertificate = clientCertificate;
        }
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate2 ClientCertificate { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSecureConnection { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            var uri = _options.Uri;
            if (!uri.StartsWith("ws://", StringComparison.OrdinalIgnoreCase) && !uri.StartsWith("wss://", StringComparison.OrdinalIgnoreCase))
            {
                if (_options.TlsOptions?.UseTls == false)
                {
                    uri = "ws://" + uri;
                }
                else
                {
                    uri = "wss://" + uri;
                }
            }

            var clientWebSocket = new ClientWebSocket();
            try
            {
                SetupClientWebSocket(clientWebSocket);

                await clientWebSocket.ConnectAsync(new Uri(uri), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // Prevent a memory leak when always creating new instance which will fail while connecting.
                clientWebSocket.Dispose();
                throw;
            }

            _webSocket = clientWebSocket;
            IsSecureConnection = uri.StartsWith("wss://", StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            if (_webSocket == null)
            {
                return;
            }

            if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken).ConfigureAwait(false);
            }

            Cleanup();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Cleanup();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var response = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer, offset, count), cancellationToken).ConfigureAwait(false);
            return response.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isEndOfPacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task WriteAsync(ArraySegment<byte> buffer, bool isEndOfPacket, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

#if NET5_0_OR_GREATER
            // MQTT Control Packets MUST be sent in WebSocket binary data frames. If any other type of data frame is received the recipient MUST close the Network Connection [MQTT-6.0.0-1].
            // A single WebSocket data frame can contain multiple or partial MQTT Control Packets. The receiver MUST NOT assume that MQTT Control Packets are aligned on WebSocket frame boundaries [MQTT-6.0.0-2].
            await _webSocket.SendAsync(buffer, WebSocketMessageType.Binary, isEndOfPacket, cancellationToken).ConfigureAwait(false);
#else
            // The lock is required because the client will throw an exception if _SendAsync_ is 
            // called from multiple threads at the same time. But this issue only happens with several
            // framework versions.
            if (_sendLock == null)
            {
                return;
            }

            using (await _sendLock.EnterAsync(cancellationToken).ConfigureAwait(false))
            {
                await _webSocket.SendAsync(buffer, WebSocketMessageType.Binary, isEndOfPacket, cancellationToken).ConfigureAwait(false);
            }
#endif
        }

        void Cleanup()
        {
            _sendLock?.Dispose();
            _sendLock = null;

            try
            {
                _webSocket?.Dispose();
            }
            catch (ObjectDisposedException)
            {
            }
            finally
            {
                _webSocket = null;
            }
        }

        IWebProxy CreateProxy()
        {
            if (string.IsNullOrEmpty(_options.ProxyOptions?.Address))
            {
                return null;
            }

#if WINDOWS_UWP
            throw new NotSupportedException("Proxies are not supported when using 'uap10.0'.");
#elif NETSTANDARD1_3
            throw new NotSupportedException("Proxies are not supported when using 'netstandard 1.3'.");
#else
            var proxyUri = new Uri(_options.ProxyOptions.Address);

            if (!string.IsNullOrEmpty(_options.ProxyOptions.Username) && !string.IsNullOrEmpty(_options.ProxyOptions.Password))
            {
                var credentials = new NetworkCredential(_options.ProxyOptions.Username, _options.ProxyOptions.Password, _options.ProxyOptions.Domain);
                return new WebProxy(proxyUri, _options.ProxyOptions.BypassOnLocal, _options.ProxyOptions.BypassList, credentials);
            }

            return new WebProxy(proxyUri, _options.ProxyOptions.BypassOnLocal, _options.ProxyOptions.BypassList);
#endif
        }

        void SetupClientWebSocket(ClientWebSocket clientWebSocket)
        {
            if (_options.ProxyOptions != null)
            {
                clientWebSocket.Options.Proxy = CreateProxy();
            }

            if (_options.RequestHeaders != null)
            {
                foreach (var requestHeader in _options.RequestHeaders)
                {
                    clientWebSocket.Options.SetRequestHeader(requestHeader.Key, requestHeader.Value);
                }
            }

            if (_options.SubProtocols != null)
            {
                foreach (var subProtocol in _options.SubProtocols)
                {
                    clientWebSocket.Options.AddSubProtocol(subProtocol);
                }
            }

            if (_options.CookieContainer != null)
            {
                clientWebSocket.Options.Cookies = _options.CookieContainer;
            }

            if (_options.TlsOptions?.UseTls == true && _options.TlsOptions?.Certificates != null)
            {
                clientWebSocket.Options.ClientCertificates = new X509CertificateCollection();
                foreach (var certificate in _options.TlsOptions.Certificates)
                {
#if WINDOWS_UWP
                    clientWebSocket.Options.ClientCertificates.Add(new X509Certificate(certificate));
#else
                    clientWebSocket.Options.ClientCertificates.Add(certificate);
#endif
                }
            }

            var certificateValidationHandler = _options.TlsOptions?.CertificateValidationHandler;
            if (certificateValidationHandler != null)
            {
#if NETSTANDARD1_3
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'netstandard1.3'.");
#elif NETSTANDARD2_0
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'netstandard2.0'.");
#elif WINDOWS_UWP
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'uap10.0'.");
#elif NET452
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'net452'.");
#elif NET45
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'net452'.");
#elif NET40
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'net40'.");
#elif NET461
                throw new NotSupportedException("Remote certificate validation callback is not supported when using 'net461'.");
#else
                clientWebSocket.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    // TODO: Find a way to add client options to same callback. Problem is that they have a different type.
                    var context = new MqttClientCertificateValidationEventArgs
                    {
                        Certificate = certificate,
                        Chain = chain,
                        SslPolicyErrors = sslPolicyErrors,
                        ClientOptions = _options
                    };

                    return certificateValidationHandler(context);
                };
#endif
            }
        }
    }
#endif
    #endregion Implementations
    #region // Internal
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public sealed class AsyncEvent<TEventArgs> where TEventArgs : EventArgs
    {
        readonly List<AsyncEventInvocator<TEventArgs>> _handlers = new List<AsyncEventInvocator<TEventArgs>>();

        ICollection<AsyncEventInvocator<TEventArgs>> _handlersForInvoke;
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent()
        {
            _handlersForInvoke = _handlers;
        }

        /// <summary>
        /// Track the existence of handlers in a separate field so that checking it all the time will not
        /// require locking the actual list (_handlers).
        /// </summary>
        public bool HasHandlers { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddHandler(Func<TEventArgs, Task> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_handlers)
            {
                _handlers.Add(new AsyncEventInvocator<TEventArgs>(null, handler));

                HasHandlers = true;
                _handlersForInvoke = new List<AsyncEventInvocator<TEventArgs>>(_handlers);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddHandler(Action<TEventArgs> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_handlers)
            {
                _handlers.Add(new AsyncEventInvocator<TEventArgs>(handler, null));

                HasHandlers = true;
                _handlersForInvoke = new List<AsyncEventInvocator<TEventArgs>>(_handlers);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        public async Task InvokeAsync(TEventArgs eventArgs)
        {
            if (!HasHandlers)
            {
                return;
            }

            // Adding or removing handlers will produce a new list instance all the time.
            // So locking here is not required since only the reference to an immutable list
            // of handlers is used.
            var handlers = _handlersForInvoke;
            foreach (var handler in handlers)
            {
                await handler.InvokeAsync(eventArgs).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveHandler(Func<TEventArgs, Task> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_handlers)
            {
                _handlers.RemoveAll(h => h.WrapsHandler(handler));

                HasHandlers = _handlers.Count > 0;
                _handlersForInvoke = new List<AsyncEventInvocator<TEventArgs>>(_handlers);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveHandler(Action<TEventArgs> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_handlers)
            {
                _handlers.RemoveAll(h => h.WrapsHandler(handler));

                HasHandlers = _handlers.Count > 0;
                _handlersForInvoke = new List<AsyncEventInvocator<TEventArgs>>(_handlers);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task TryInvokeAsync(TEventArgs eventArgs, MqttNetSourceLogger logger)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            try
            {
                await InvokeAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                logger.Warning(exception, $"Error while invoking event with arguments of type {typeof(TEventArgs)}.");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public readonly struct AsyncEventInvocator<TEventArgs>
    {
        readonly Action<TEventArgs> _handler;
        readonly Func<TEventArgs, Task> _asyncHandler;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="asyncHandler"></param>
        public AsyncEventInvocator(Action<TEventArgs> handler, Func<TEventArgs, Task> asyncHandler)
        {
            _handler = handler;
            _asyncHandler = asyncHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public bool WrapsHandler(Action<TEventArgs> handler)
        {
            // Do not use ReferenceEquals! It will not work with delegates.
            return handler == _handler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public bool WrapsHandler(Func<TEventArgs, Task> handler)
        {
            // Do not use ReferenceEquals! It will not work with delegates.
            return handler == _asyncHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task InvokeAsync(TEventArgs eventArgs)
        {
            if (_handler != null)
            {
                _handler.Invoke(eventArgs);
                return CompletedTask.Instance;
            }

            if (_asyncHandler != null)
            {
                return _asyncHandler.Invoke(eventArgs);
            }

            throw new InvalidOperationException();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class AsyncLock : IDisposable
    {
        readonly Task<IDisposable> _completedTask;
        readonly IDisposable _releaser;
        readonly object _syncRoot = new object();
        readonly Queue<AsyncLockWaiter> _waiters = new Queue<AsyncLockWaiter>(64);

        volatile bool _isDisposed;
        bool _isLocked;
        /// <summary>
        /// 
        /// </summary>
        public AsyncLock()
        {
            _releaser = new Releaser(this);
            _completedTask = TestTry.TaskFromResult(_releaser);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            lock (_syncRoot)
            {
                _isDisposed = true;

                while (_waiters.Any())
                {
                    _waiters.Dequeue().Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ObjectDisposedException"></exception>
        public Task<IDisposable> EnterAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(AsyncLock));
            }

            lock (_syncRoot)
            {
                if (!_isLocked)
                {
                    _isLocked = true;
                    return _completedTask;
                }

                var waiter = new AsyncLockWaiter(cancellationToken);
                _waiters.Enqueue(waiter);

                return waiter.Task;
            }
        }

        void Release()
        {
            lock (_syncRoot)
            {
                if (_isDisposed)
                {
                    // All waiters have been canceled with a ObjectDisposedException.
                    // So there is nothing left to do.
                    return;
                }

                // Assume that there is no waiter left first.
                _isLocked = false;

                // Try to find the next waiter which can be approved.
                // Some of them might be canceled already so it is not
                // guaranteed that the very next waiter is the correct one.
                while (_waiters.Any())
                {
                    var waiter = _waiters.Dequeue();
                    var isApproved = waiter.Approve(_releaser);
                    waiter.Dispose();

                    if (isApproved)
                    {
                        _isLocked = true;
                        return;
                    }
                }
            }
        }

        sealed class AsyncLockWaiter : IDisposable
        {
            readonly CancellationTokenRegistration _cancellationRegistration;
            readonly bool _hasCancellationRegistration;
            readonly AsyncTaskCompletionSource<IDisposable> _promise = new AsyncTaskCompletionSource<IDisposable>();

            public AsyncLockWaiter(CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (cancellationToken.CanBeCanceled)
                {
                    _cancellationRegistration = cancellationToken.Register(Cancel);
                    _hasCancellationRegistration = true;
                }
            }

            public Task<IDisposable> Task => _promise.Task;

            public bool Approve(IDisposable scope)
            {
                if (scope == null)
                {
                    throw new ArgumentNullException(nameof(scope));
                }

                if (_promise.Task.IsCompleted)
                {
                    return false;
                }

                return _promise.TrySetResult(scope);
            }

            public void Dispose()
            {
                if (_hasCancellationRegistration)
                {
                    _cancellationRegistration.Dispose();
                }

                _promise.TrySetException(new ObjectDisposedException(nameof(AsyncLockWaiter)));
            }

            void Cancel()
            {
                _promise.TrySetCanceled();
            }
        }

        readonly struct Releaser : IDisposable
        {
            readonly AsyncLock _asyncLock;

            public Releaser(AsyncLock asyncLock)
            {
                _asyncLock = asyncLock ?? throw new ArgumentNullException(nameof(asyncLock));
            }

            public void Dispose()
            {
                _asyncLock.Release();
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public sealed class AsyncQueue<TItem> : IDisposable
    {
        readonly AsyncSignal _signal = new AsyncSignal();
        readonly object _syncRoot = new object();

        ConcurrentQueue<TItem> _queue = new ConcurrentQueue<TItem>();

        bool _isDisposed;
        /// <summary>
        /// 
        /// </summary>
        public int Count => _queue.Count;
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Interlocked.Exchange(ref _queue, new ConcurrentQueue<TItem>());
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            lock (_syncRoot)
            {
                _signal.Dispose();

                _isDisposed = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(TItem item)
        {
            lock (_syncRoot)
            {
                _queue.Enqueue(item);
                _signal.Set();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AsyncQueueDequeueResult<TItem> TryDequeue()
        {
            if (_queue.TryDequeue(out var item))
            {
                return AsyncQueueDequeueResult<TItem>.Success(item);
            }

            return AsyncQueueDequeueResult<TItem>.NonSuccess;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AsyncQueueDequeueResult<TItem>> TryDequeueAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Task task = null;
                    lock (_syncRoot)
                    {
                        if (_isDisposed)
                        {
                            return AsyncQueueDequeueResult<TItem>.NonSuccess;
                        }

                        if (_queue.IsEmpty)
                        {
                            task = _signal.WaitAsync(cancellationToken);
                        }
                    }

                    if (task != null)
                    {
                        await task.ConfigureAwait(false);
                    }

                    if (cancellationToken.IsCancellationRequested)
                    {
                        return AsyncQueueDequeueResult<TItem>.NonSuccess;
                    }

                    if (_queue.TryDequeue(out var item))
                    {
                        return AsyncQueueDequeueResult<TItem>.Success(item);
                    }
                }
                catch (OperationCanceledException)
                {
                    return AsyncQueueDequeueResult<TItem>.NonSuccess;
                }
            }

            return AsyncQueueDequeueResult<TItem>.NonSuccess;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public sealed class AsyncQueueDequeueResult<TItem>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly AsyncQueueDequeueResult<TItem> NonSuccess = new AsyncQueueDequeueResult<TItem>(false, default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="item"></param>
        public AsyncQueueDequeueResult(bool isSuccess, TItem item)
        {
            IsSuccess = isSuccess;
            Item = item;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccess { get; }
        /// <summary>
        /// 
        /// </summary>
        public TItem Item { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static AsyncQueueDequeueResult<TItem> Success(TItem item)
        {
            return new AsyncQueueDequeueResult<TItem>(true, item);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class AsyncSignal : IDisposable
    {
        readonly object _syncRoot = new object();

        bool _isDisposed;
        bool _isSignaled;
        AsyncSignalWaiter _waiter;
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            lock (_syncRoot)
            {
                _waiter?.Dispose();
                _waiter = null;

                _isDisposed = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Set()
        {
            lock (_syncRoot)
            {
                _isSignaled = true;

                Cleanup();

                // If there is already a waiting task let it run.
                if (_waiter != null)
                {
                    _waiter.Approve();
                    _waiter.Dispose();
                    _waiter = null;

                    // Since we already got a waiter the signal must be reset right now!
                    _isSignaled = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task WaitAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            lock (_syncRoot)
            {
                ThrowIfDisposed();

                Cleanup();

                if (_isSignaled)
                {
                    _isSignaled = false;
                    return CompletedTask.Instance;
                }

                if (_waiter != null)
                {
                    if (!_waiter.Task.IsCompleted)
                    {
                        throw new InvalidOperationException("Only one waiting task is permitted per async signal.");
                    }

                    _waiter.Dispose();
                }

                _waiter = new AsyncSignalWaiter(cancellationToken);
                return _waiter.Task;
            }
        }

        void Cleanup()
        {
            // Cleanup if the previous waiter was cancelled.
            if (_waiter != null && _waiter.Task.IsCanceled)
            {
                _waiter = null;
            }
        }

        void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(AsyncSignal));
            }
        }

        sealed class AsyncSignalWaiter : IDisposable
        {
            readonly AsyncTaskCompletionSource<bool> _promise = new AsyncTaskCompletionSource<bool>();

            // ReSharper disable once FieldCanBeMadeReadOnly.Local
            CancellationTokenRegistration _cancellationTokenRegistration;

            volatile bool _isCompleted;

            public AsyncSignalWaiter(CancellationToken cancellationToken)
            {
                if (cancellationToken.CanBeCanceled)
                {
                    _cancellationTokenRegistration = cancellationToken.Register(Cancel);
                }
            }

            public Task Task => _promise.Task;

            public void Approve()
            {
                if (_isCompleted)
                {
                    return;
                }

                _isCompleted = true;
                _promise.TrySetResult(true);
            }

            public void Dispose()
            {
                _cancellationTokenRegistration.Dispose();

                if (_isCompleted)
                {
                    // Avoid allocation of _ObjectDisposedException_ which may not be used.
                    return;
                }

                _isCompleted = true;
                _promise.TrySetException(new ObjectDisposedException(nameof(AsyncSignalWaiter)));
            }

            void Cancel()
            {
                if (_isCompleted)
                {
                    return;
                }

                _isCompleted = true;
                _promise.TrySetCanceled();
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public sealed class AsyncTaskCompletionSource<TResult>
    {
        readonly TaskCompletionSource<TResult> _taskCompletionSource;
        /// <summary>
        /// 
        /// </summary>
        public AsyncTaskCompletionSource()
        {
#if NET452 || NET40 || NET45
            _taskCompletionSource = new TaskCompletionSource<TResult>();
#else
            _taskCompletionSource = new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public Task<TResult> Task => _taskCompletionSource.Task;
        /// <summary>
        /// 
        /// </summary>
        public void TrySetCanceled()
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetCanceled_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            TestTry.TaskRun(() => _taskCompletionSource.TrySetCanceled());
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);
#else
            _taskCompletionSource.TrySetCanceled();
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public void TrySetException(Exception exception)
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetException_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            TestTry.TaskRun(() => _taskCompletionSource.TrySetException(exception));
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);
#else
            _taskCompletionSource.TrySetException(exception);
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TrySetResult(TResult result)
        {
#if NET452 || NET40 || NET45
            // To prevent deadlocks it is required to call the _TrySetResult_ method
            // from a new thread because the awaiting code will not(!) be executed in
            // a new thread automatically (due to await). Furthermore _this_ thread will
            // do it. But _this_ thread is also reading incoming packets -> deadlock.
            // NET452 does not support RunContinuationsAsynchronously
            if (_taskCompletionSource.Task.IsCompleted)
            {
                return false;
            }

            TestTry.TaskRun(() => _taskCompletionSource.TrySetResult(result));
            SpinWait.SpinUntil(() => _taskCompletionSource.Task.IsCompleted);

            return true;
#else
            return _taskCompletionSource.TrySetResult(result);
#endif
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public sealed class BlockingQueue<TItem> : IDisposable
    {
        readonly object _syncRoot = new object();
        readonly LinkedList<TItem> _items = new LinkedList<TItem>();

        ManualResetEventSlim _gate = new ManualResetEventSlim(false);
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                lock (_syncRoot)
                {
                    return _items.Count;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Enqueue(TItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            lock (_syncRoot)
            {
                _items.AddLast(item);
                _gate?.Set();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public TItem Dequeue(CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                lock (_syncRoot)
                {
                    if (_items.Count > 0)
                    {
                        var item = _items.First.Value;
                        _items.RemoveFirst();

                        return item;
                    }

                    if (_items.Count == 0)
                    {
                        _gate?.Reset();
                    }
                }

                _gate?.Wait(cancellationToken);
            }

            throw new OperationCanceledException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public TItem PeekAndWait(CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                lock (_syncRoot)
                {
                    if (_items.Count > 0)
                    {
                        return _items.First.Value;
                    }

                    if (_items.Count == 0)
                    {
                        _gate?.Reset();
                    }
                }

                _gate?.Wait(cancellationToken);
            }

            throw new OperationCanceledException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveFirst(Predicate<TItem> match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            lock (_syncRoot)
            {
                if (_items.Count > 0 && match(_items.First.Value))
                {
                    _items.RemoveFirst();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TItem RemoveFirst()
        {
            lock (_syncRoot)
            {
                var item = _items.First;
                _items.RemoveFirst();

                return item.Value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            lock (_syncRoot)
            {
                _items.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _gate?.Dispose();
            _gate = null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        protected bool IsDisposed { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        protected void ThrowIfDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.

            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketBus : IDisposable
    {
        readonly LinkedList<MqttPacketBusItem>[] _partitions =
        {
            new LinkedList<MqttPacketBusItem>(),
            new LinkedList<MqttPacketBusItem>(),
            new LinkedList<MqttPacketBusItem>()
        };

        readonly AsyncSignal _signal = new AsyncSignal();
        readonly object _syncRoot = new object();

        int _activePartition = (int)MqttPacketBusPartition.Health;
        /// <summary>
        /// 
        /// </summary>
        public int TotalItemsCount
        {
            get
            {
                lock (_syncRoot)
                {
                    return _partitions.Sum(p => p.Count);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            lock (_syncRoot)
            {
                foreach (var partition in _partitions)
                {
                    partition.Clear();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<MqttPacketBusItem> DequeueItemAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                lock (_syncRoot)
                {
                    for (var i = 0; i < 3; i++)
                    {
                        // Iterate through the partitions in order to ensure processing of health packets
                        // even if lots of data packets are enqueued.

                        // Partition | Messages (left = oldest).
                        // DATA      | [#]#########################
                        // CONTROL   | [#]#############
                        // HEALTH    | [#]####

                        // In this sample the 3 oldest messages from the partitions are processed in a row.
                        // Then the next 3 from all 3 partitions.

                        MoveActivePartition();

                        var activePartition = _partitions[_activePartition];

                        if (activePartition.First != null)
                        {
                            var item = activePartition.First;
                            activePartition.RemoveFirst();

                            return item.Value;
                        }
                    }
                }

                // No partition contains data so that we have to wait and put
                // the worker back to the thread pool.
                try
                {
                    await _signal.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (ObjectDisposedException)
                {
                    // The cancelled token should "hide" the disposal of the signal.
                    cancellationToken.ThrowIfCancellationRequested();
                    throw;
                }
            }

            cancellationToken.ThrowIfCancellationRequested();

            throw new InvalidOperationException("MqttPacketBus is broken.");
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _signal.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partition"></param>
        public void DropFirstItem(MqttPacketBusPartition partition)
        {
            lock (_syncRoot)
            {
                var partitionInstance = _partitions[(int)partition];

                if (partitionInstance.Any())
                {
                    partitionInstance.RemoveFirst();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="partition"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void EnqueueItem(MqttPacketBusItem item, MqttPacketBusPartition partition)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            lock (_syncRoot)
            {
                _partitions[(int)partition].AddLast(item);
                _signal.Set();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partition"></param>
        /// <returns></returns>
        public List<MqttPacket> ExportPackets(MqttPacketBusPartition partition)
        {
            lock (_syncRoot)
            {
                return _partitions[(int)partition].Select(i => i.Packet).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partition"></param>
        /// <returns></returns>
        public int ItemsCount(MqttPacketBusPartition partition)
        {
            lock (_syncRoot)
            {
                return _partitions[(int)partition].Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partition"></param>
        /// <returns></returns>
        public int PartitionItemsCount(MqttPacketBusPartition partition)
        {
            lock (_syncRoot)
            {
                return _partitions[(int)partition].Count;
            }
        }

        void MoveActivePartition()
        {
            if (_activePartition >= _partitions.Length - 1)
            {
                _activePartition = 0;
            }
            else
            {
                _activePartition++;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketBusItem
    {
        readonly AsyncTaskCompletionSource<bool> _promise = new AsyncTaskCompletionSource<bool>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketBusItem(MqttPacket packet)
        {
            Packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Completed;
        /// <summary>
        /// 
        /// </summary>
        public MqttPacket Packet { get; }
        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            _promise.TrySetCanceled();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Complete()
        {
            _promise.TrySetResult(true);
            Completed?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public void Fail(Exception exception)
        {
            _promise.TrySetException(exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task WaitAsync()
        {
            return _promise.Task;
        }
    }
    #endregion Internal
    #region // LowLevelClient
    /// <summary>
    /// 
    /// </summary>
    public interface ILowLevelMqttClient : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        event Func<InspectMqttPacketEventArgs, Task> InspectPackage;
        /// <summary>
        /// 
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DisconnectAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MqttPacket> ReceiveAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendAsync(MqttPacket packet, CancellationToken cancellationToken = default);
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class LowLevelMqttClient : ILowLevelMqttClient
    {
        readonly IMqttClientAdapterFactory _clientAdapterFactory;
        readonly AsyncEvent<InspectMqttPacketEventArgs> _inspectPacketEvent = new AsyncEvent<InspectMqttPacketEventArgs>();
        readonly MqttNetSourceLogger _logger;

        readonly IMqttNetLogger _rootLogger;

        IMqttChannelAdapter _adapter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientAdapterFactory"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LowLevelMqttClient(IMqttClientAdapterFactory clientAdapterFactory, IMqttNetLogger logger)
        {
            _clientAdapterFactory = clientAdapterFactory ?? throw new ArgumentNullException(nameof(clientAdapterFactory));

            _rootLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger = logger.WithSource(nameof(LowLevelMqttClient));
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InspectMqttPacketEventArgs, Task> InspectPackage
        {
            add => _inspectPacketEvent.AddHandler(value);
            remove => _inspectPacketEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected => _adapter != null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (_adapter != null)
            {
                throw new InvalidOperationException("Low level MQTT client is already connected. Disconnect first before connecting again.");
            }

            var newAdapter = _clientAdapterFactory.CreateClientAdapter(options, new MqttPacketInspector(_inspectPacketEvent, _rootLogger), _rootLogger);

            try
            {
                _logger.Verbose("Trying to connect with server '{0}'.", options.ChannelOptions);
                await newAdapter.ConnectAsync(cancellationToken).ConfigureAwait(false);
                _logger.Verbose("Connection with server established.");
            }
            catch (Exception)
            {
                _adapter?.Dispose();
                throw;
            }

            _adapter = newAdapter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task DisconnectAsync(CancellationToken cancellationToken)
        {
            var adapter = _adapter;
            if (adapter == null)
            {
                throw new InvalidOperationException("Low level MQTT client is not connected.");
            }

            try
            {
                await adapter.DisconnectAsync(cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                Dispose();
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _adapter?.Dispose();
            _adapter = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<MqttPacket> ReceiveAsync(CancellationToken cancellationToken)
        {
            var adapter = _adapter;
            if (adapter == null)
            {
                throw new InvalidOperationException("Low level MQTT client is not connected.");
            }

            try
            {
                var receivedPacket = await adapter.ReceivePacketAsync(cancellationToken).ConfigureAwait(false);
                if (receivedPacket == null)
                {
                    // Graceful socket close.
                    throw new MqttCommunicationException("The connection is closed.");
                }

                return receivedPacket;
            }
            catch
            {
                Dispose();
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SendAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            if (packet is null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            var adapter = _adapter;
            if (adapter == null)
            {
                throw new InvalidOperationException("Low level MQTT client is not connected.");
            }

            try
            {
                await adapter.SendPacketAsync(packet, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                Dispose();
                throw;
            }
        }
    }
    #endregion LowLevelClient
    #region // PacketDispatcher
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttPacketAwaitable : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        MqttPacketAwaitableFilter Filter { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        void Complete(MqttPacket packet);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        void Fail(Exception exception);
        /// <summary>
        /// 
        /// </summary>
        void Cancel();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPacket"></typeparam>
    public sealed class MqttPacketAwaitable<TPacket> : IMqttPacketAwaitable where TPacket : MqttPacket
    {
        readonly AsyncTaskCompletionSource<MqttPacket> _promise = new AsyncTaskCompletionSource<MqttPacket>();
        readonly MqttPacketDispatcher _owningPacketDispatcher;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetIdentifier"></param>
        /// <param name="owningPacketDispatcher"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttPacketAwaitable(ushort packetIdentifier, MqttPacketDispatcher owningPacketDispatcher)
        {
            Filter = new MqttPacketAwaitableFilter
            {
                Type = typeof(TPacket),
                Identifier = packetIdentifier
            };

            _owningPacketDispatcher = owningPacketDispatcher ?? throw new ArgumentNullException(nameof(owningPacketDispatcher));
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttPacketAwaitableFilter Filter { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TPacket> WaitOneAsync(CancellationToken cancellationToken)
        {
            using (cancellationToken.Register(() => Fail(new MqttCommunicationTimedOutException())))
            {
                var packet = await _promise.Task.ConfigureAwait(false);
                return (TPacket)packet;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Complete(MqttPacket packet)
        {
            if (packet == null) throw new ArgumentNullException(nameof(packet));

            _promise.TrySetResult(packet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Fail(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            _promise.TrySetException(exception);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            _promise.TrySetCanceled();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _owningPacketDispatcher.RemoveAwaitable(this);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketAwaitableFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort Identifier { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPacketDispatcher : IDisposable
    {
        readonly List<IMqttPacketAwaitable> _waiters = new List<IMqttPacketAwaitable>();

        bool _isDisposed;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponsePacket"></typeparam>
        /// <param name="packetIdentifier"></param>
        /// <returns></returns>
        public MqttPacketAwaitable<TResponsePacket> AddAwaitable<TResponsePacket>(ushort packetIdentifier) where TResponsePacket : MqttPacket
        {
            var awaitable = new MqttPacketAwaitable<TResponsePacket>(packetIdentifier, this);

            lock (_waiters)
            {
                _waiters.Add(awaitable);
            }

            return awaitable;
        }
        /// <summary>
        /// 
        /// </summary>
        public void CancelAll()
        {
            lock (_waiters)
            {
                foreach (var awaitable in _waiters)
                {
                    awaitable.Cancel();
                }

                _waiters.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(new ObjectDisposedException(nameof(MqttPacketDispatcher)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Dispose(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            lock (_waiters)
            {
                FailAll(exception);

                // Make sure that no task can start waiting after this instance is already disposed.
                // This will prevent unexpected freezes.
                _isDisposed = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void FailAll(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            lock (_waiters)
            {
                foreach (var awaitable in _waiters)
                {
                    awaitable.Fail(exception);
                }

                _waiters.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="awaitable"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveAwaitable(IMqttPacketAwaitable awaitable)
        {
            if (awaitable == null)
            {
                throw new ArgumentNullException(nameof(awaitable));
            }

            lock (_waiters)
            {
                _waiters.Remove(awaitable);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool TryDispatch(MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            ushort identifier = 0;
            if (packet is MqttPacketWithIdentifier packetWithIdentifier)
            {
                identifier = packetWithIdentifier.PacketIdentifier;
            }

            var packetType = packet.GetType();
            var waiters = new List<IMqttPacketAwaitable>();

            lock (_waiters)
            {
                ThrowIfDisposed();

                for (var i = _waiters.Count - 1; i >= 0; i--)
                {
                    var entry = _waiters[i];

                    // Note: The PingRespPacket will also arrive here and has NO identifier but there
                    // is code which waits for it. So the code must be able to deal with filters which
                    // are referring to the type only (identifier is 0)!
                    if (entry.Filter.Type != packetType || entry.Filter.Identifier != identifier)
                    {
                        continue;
                    }

                    waiters.Add(entry);
                    _waiters.RemoveAt(i);
                }
            }

            foreach (var matchingEntry in waiters)
            {
                matchingEntry.Complete(packet);
            }

            return waiters.Count > 0;
        }

        void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(MqttPacketDispatcher));
            }
        }
    }
    #endregion PacketDispatcher
    #region // Packets
    /// <summary>
    /// Added in MQTTv5.0.0.
    /// </summary>
    public sealed class MqttAuthPacket : MqttPacket
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] AuthenticationData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttAuthenticateReasonCode ReasonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttConnAckPacket : MqttPacket
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string AssignedClientIdentifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] AuthenticationData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationMethod { get; set; }

        /// <summary>
        ///     Added in MQTTv3.1.1.
        /// </summary>
        public bool IsSessionPresent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint MaximumPacketSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel MaximumQoS { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttConnectReasonCode ReasonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort ReceiveMaximum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResponseInformation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RetainAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttConnectReturnCode ReturnCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort ServerKeepAlive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServerReference { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint SessionExpiryInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SharedSubscriptionAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SubscriptionIdentifiersAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort TopicAliasMaximum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool WildcardSubscriptionAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ConnAck: [ReturnCode={ReturnCode}] [ReasonCode={ReasonCode}] [IsSessionPresent={IsSessionPresent}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttConnectPacket : MqttPacket
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] AuthenticationData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationMethod { get; set; }

        /// <summary>
        ///     Also called "Clean Start" in MQTTv5.
        /// </summary>
        public bool CleanSession { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] WillCorrelationData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort KeepAlivePeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint MaximumPacketSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort ReceiveMaximum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RequestProblemInformation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RequestResponseInformation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WillResponseTopic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint SessionExpiryInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort TopicAliasMaximum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WillContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint WillDelayInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool WillFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] WillMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint WillMessageExpiryInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttPayloadFormatIndicator WillPayloadFormatIndicator { get; set; } = MqttPayloadFormatIndicator.Unspecified;
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel WillQoS { get; set; } = MqttQualityOfServiceLevel.AtMostOnce;
        /// <summary>
        /// 
        /// </summary>
        public bool WillRetain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WillTopic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> WillUserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TryPrivate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var passwordText = string.Empty;

            if (Password != null)
            {
                passwordText = "****";
            }

            return $"Connect: [ClientId={ClientId}] [Username={Username}] [Password={passwordText}] [KeepAlivePeriod={KeepAlivePeriod}] [CleanSession={CleanSession}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttDisconnectPacket : MqttPacket
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttDisconnectReasonCode ReasonCode { get; set; } = MqttDisconnectReasonCode.NormalDisconnection;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ServerReference { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public uint SessionExpiryInterval { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Disconnect: [ReasonCode={ReasonCode}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class MqttPacket
    {
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttUnsubscribePacket : MqttPacketWithIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> TopicFilters { get; set; } = new List<string>();

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var topicFiltersText = string.Join(",", TopicFilters);
            return $"Unsubscribe: [PacketIdentifier={PacketIdentifier}] [TopicFilters={topicFiltersText}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttUnsubAckPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUnsubscribeReasonCode> ReasonCodes { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var reasonCodesText = string.Empty;
            if (ReasonCodes != null)
            {
                reasonCodesText = string.Join(",", ReasonCodes?.Select(f => f.ToString()));
            }

            return $"UnsubAck: [PacketIdentifier={PacketIdentifier}] [ReasonCodes={reasonCodesText}] [ReasonString={ReasonString}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttTopicFilter
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the sender will not receive its own published application messages.
        /// </summary>
        /// Hint: MQTT 5 feature only.
        public bool NoLocal { get; set; }

        /// <summary>
        ///     Gets or sets the quality of service level.
        ///     The Quality of Service (QoS) level is an agreement between the sender of a message and the receiver of a message
        ///     that defines the guarantee of delivery for a specific message.
        ///     There are 3 QoS levels in MQTT:
        ///     - At most once  (0): Message gets delivered no time, once or multiple times.
        ///     - At least once (1): Message gets delivered at least once (one time or more often).
        ///     - Exactly once  (2): Message gets delivered exactly once (It's ensured that the message only comes once).
        /// </summary>
        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether messages are retained as published or not.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public bool RetainAsPublished { get; set; }

        /// <summary>
        ///     Gets or sets the retain handling.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public MqttRetainHandling RetainHandling { get; set; }

        /// <summary>
        ///     Gets or sets the MQTT topic.
        ///     In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected
        ///     client.
        ///     The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level
        ///     separator).
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"TopicFilter: [Topic={Topic}] [QualityOfServiceLevel={QualityOfServiceLevel}] [NoLocal={NoLocal}] [RetainAsPublished={RetainAsPublished}] [RetainHandling={RetainHandling}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSubscribePacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     It is a Protocol Error if the Subscription Identifier has a value of 0.
        /// </summary>
        public uint SubscriptionIdentifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttTopicFilter> TopicFilters { get; set; } = new List<MqttTopicFilter>();

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var topicFiltersText = string.Join(",", TopicFilters.Select(f => f.Topic + "@" + f.QualityOfServiceLevel));
            return $"Subscribe: [PacketIdentifier={PacketIdentifier}] [TopicFilters={topicFiltersText}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSubAckPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Reason Code is used in MQTTv5.0.0 and backward compatible to v.3.1.1. Return Code is used in MQTTv3.1.1
        /// </summary>
        public List<MqttSubscribeReasonCode> ReasonCodes { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var reasonCodesText = string.Join(",", ReasonCodes.Select(f => f.ToString()));

            return $"SubAck: [PacketIdentifier={PacketIdentifier}] [ReasonCode={reasonCodesText}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubRelPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubRelReasonCode ReasonCode { get; set; } = MqttPubRelReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"PubRel: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubRecPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubRecReasonCode ReasonCode { get; set; } = MqttPubRecReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"PubRec: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPublishPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] CorrelationData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Dup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint MessageExpiryInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Payload { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttPayloadFormatIndicator PayloadFormatIndicator { get; set; } = MqttPayloadFormatIndicator.Unspecified;
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; } = MqttQualityOfServiceLevel.AtMostOnce;
        /// <summary>
        /// 
        /// </summary>
        public string ResponseTopic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Retain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<uint> SubscriptionIdentifiers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort TopicAlias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                $"Publish: [Topic={Topic}] [Payload.Length={Payload?.Length}] [QoSLevel={QualityOfServiceLevel}] [Dup={Dup}] [Retain={Retain}] [PacketIdentifier={PacketIdentifier}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubCompPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubCompReasonCode ReasonCode { get; set; } = MqttPubCompReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"PubComp: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPubAckPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubAckReasonCode ReasonCode { get; set; } = MqttPubAckReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"PubAck: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPingRespPacket : MqttPacket
    {
        /// <summary>
        /// This is a minor performance improvement.
        /// </summary>
        public static readonly MqttPingRespPacket Instance = new MqttPingRespPacket();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "PingResp";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttPingReqPacket : MqttPacket
    {
        /// <summary>
        /// This is a minor performance improvement.
        /// </summary>
        public static readonly MqttPingReqPacket Instance = new MqttPingReqPacket();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "PingReq";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class MqttPacketWithIdentifier : MqttPacket
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort PacketIdentifier { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttUserProperty
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttUserProperty(string name, string value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return Equals(other as MqttUserProperty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MqttUserProperty other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return string.Equals(Name, other.Name, StringComparison.Ordinal) && string.Equals(Value, other.Value, StringComparison.Ordinal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Value.GetHashCode();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} = {Value}";
        }
    }
    #endregion Packets
    #region // Server
    /// <summary>
    /// 
    /// </summary>
    public sealed class InjectedMqttApplicationMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InjectedMqttApplicationMessage(MqttApplicationMessage applicationMessage)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
        }
        /// <summary>
        /// 
        /// </summary>
        public string SenderClientId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttRetainedMessageMatch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="subscriptionQualityOfServiceLevel"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttRetainedMessageMatch(MqttApplicationMessage applicationMessage, MqttQualityOfServiceLevel subscriptionQualityOfServiceLevel)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            SubscriptionQualityOfServiceLevel = subscriptionQualityOfServiceLevel;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel SubscriptionQualityOfServiceLevel { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttServer : Disposable
    {
        readonly ICollection<IMqttServerAdapter> _adapters;
        readonly MqttClientSessionsManager _clientSessionsManager;
        readonly MqttServerEventContainer _eventContainer = new MqttServerEventContainer();
        readonly MqttServerKeepAliveMonitor _keepAliveMonitor;
        readonly MqttNetSourceLogger _logger;
        readonly MqttServerOptions _options;
        readonly MqttRetainedMessagesManager _retainedMessagesManager;
        readonly IMqttNetLogger _rootLogger;

        readonly IDictionary _sessionItems = new ConcurrentDictionary<object, object>();

        CancellationTokenSource _cancellationTokenSource;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="adapters"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServer(MqttServerOptions options, IEnumerable<IMqttServerAdapter> adapters, IMqttNetLogger logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (adapters == null)
            {
                throw new ArgumentNullException(nameof(adapters));
            }

            _adapters = adapters.ToList();

            _rootLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger = logger.WithSource(nameof(MqttServer));

            _retainedMessagesManager = new MqttRetainedMessagesManager(_eventContainer, _rootLogger);
            _clientSessionsManager = new MqttClientSessionsManager(options, _retainedMessagesManager, _eventContainer, _rootLogger);
            _keepAliveMonitor = new MqttServerKeepAliveMonitor(options, _clientSessionsManager, _rootLogger);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ApplicationMessageNotConsumedEventArgs, Task> ApplicationMessageNotConsumedAsync
        {
            add => _eventContainer.ApplicationMessageNotConsumedEvent.AddHandler(value);
            remove => _eventContainer.ApplicationMessageNotConsumedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ClientAcknowledgedPublishPacketEventArgs, Task> ClientAcknowledgedPublishPacketAsync
        {
            add => _eventContainer.ClientAcknowledgedPublishPacketEvent.AddHandler(value);
            remove => _eventContainer.ClientAcknowledgedPublishPacketEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ClientConnectedEventArgs, Task> ClientConnectedAsync
        {
            add => _eventContainer.ClientConnectedEvent.AddHandler(value);
            remove => _eventContainer.ClientConnectedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ClientDisconnectedEventArgs, Task> ClientDisconnectedAsync
        {
            add => _eventContainer.ClientDisconnectedEvent.AddHandler(value);
            remove => _eventContainer.ClientDisconnectedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ClientSubscribedTopicEventArgs, Task> ClientSubscribedTopicAsync
        {
            add => _eventContainer.ClientSubscribedTopicEvent.AddHandler(value);
            remove => _eventContainer.ClientSubscribedTopicEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ClientUnsubscribedTopicEventArgs, Task> ClientUnsubscribedTopicAsync
        {
            add => _eventContainer.ClientUnsubscribedTopicEvent.AddHandler(value);
            remove => _eventContainer.ClientUnsubscribedTopicEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InterceptingPacketEventArgs, Task> InterceptingInboundPacketAsync
        {
            add => _eventContainer.InterceptingInboundPacketEvent.AddHandler(value);
            remove => _eventContainer.InterceptingInboundPacketEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InterceptingPacketEventArgs, Task> InterceptingOutboundPacketAsync
        {
            add => _eventContainer.InterceptingOutboundPacketEvent.AddHandler(value);
            remove => _eventContainer.InterceptingOutboundPacketEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InterceptingPublishEventArgs, Task> InterceptingPublishAsync
        {
            add => _eventContainer.InterceptingPublishEvent.AddHandler(value);
            remove => _eventContainer.InterceptingPublishEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InterceptingSubscriptionEventArgs, Task> InterceptingSubscriptionAsync
        {
            add => _eventContainer.InterceptingSubscriptionEvent.AddHandler(value);
            remove => _eventContainer.InterceptingSubscriptionEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<InterceptingUnsubscriptionEventArgs, Task> InterceptingUnsubscriptionAsync
        {
            add => _eventContainer.InterceptingUnsubscriptionEvent.AddHandler(value);
            remove => _eventContainer.InterceptingUnsubscriptionEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<LoadingRetainedMessagesEventArgs, Task> LoadingRetainedMessageAsync
        {
            add => _eventContainer.LoadingRetainedMessagesEvent.AddHandler(value);
            remove => _eventContainer.LoadingRetainedMessagesEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<EventArgs, Task> PreparingSessionAsync
        {
            add => _eventContainer.PreparingSessionEvent.AddHandler(value);
            remove => _eventContainer.PreparingSessionEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<RetainedMessageChangedEventArgs, Task> RetainedMessageChangedAsync
        {
            add => _eventContainer.RetainedMessageChangedEvent.AddHandler(value);
            remove => _eventContainer.RetainedMessageChangedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<EventArgs, Task> RetainedMessagesClearedAsync
        {
            add => _eventContainer.RetainedMessagesClearedEvent.AddHandler(value);
            remove => _eventContainer.RetainedMessagesClearedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<SessionDeletedEventArgs, Task> SessionDeletedAsync
        {
            add => _eventContainer.SessionDeletedEvent.AddHandler(value);
            remove => _eventContainer.SessionDeletedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<EventArgs, Task> StartedAsync
        {
            add => _eventContainer.StartedEvent.AddHandler(value);
            remove => _eventContainer.StartedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<EventArgs, Task> StoppedAsync
        {
            add => _eventContainer.StoppedEvent.AddHandler(value);
            remove => _eventContainer.StoppedEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public event Func<ValidatingConnectionEventArgs, Task> ValidatingConnectionAsync
        {
            add => _eventContainer.ValidatingConnectionEvent.AddHandler(value);
            remove => _eventContainer.ValidatingConnectionEvent.RemoveHandler(value);
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsStarted => _cancellationTokenSource != null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task DeleteRetainedMessagesAsync()
        {
            ThrowIfNotStarted();

            return _retainedMessagesManager?.ClearMessages() ?? CompletedTask.Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reasonCode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task DisconnectClientAsync(string id, MqttDisconnectReasonCode reasonCode)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            ThrowIfNotStarted();

            return _clientSessionsManager.GetClient(id).StopAsync(reasonCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttClientStatus>> GetClientsAsync()
        {
            ThrowIfNotStarted();

            return _clientSessionsManager.GetClientStatusesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttApplicationMessage>> GetRetainedMessagesAsync()
        {
            ThrowIfNotStarted();

            return _retainedMessagesManager.GetMessages();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttSessionStatus>> GetSessionsAsync()
        {
            ThrowIfNotStarted();

            return _clientSessionsManager.GetSessionStatusAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="injectedApplicationMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public Task InjectApplicationMessage(InjectedMqttApplicationMessage injectedApplicationMessage, CancellationToken cancellationToken = default)
        {
            if (injectedApplicationMessage == null)
            {
                throw new ArgumentNullException(nameof(injectedApplicationMessage));
            }

            if (injectedApplicationMessage.ApplicationMessage == null)
            {
                throw new ArgumentNullException(nameof(injectedApplicationMessage.ApplicationMessage));
            }

            MqttTopicValidator.ThrowIfInvalid(injectedApplicationMessage.ApplicationMessage.Topic);

            ThrowIfNotStarted();

            if (string.IsNullOrEmpty(injectedApplicationMessage.ApplicationMessage.Topic))
            {
                throw new NotSupportedException("Injected application messages must contain a topic. Topic alias is not supported.");
            }

            return _clientSessionsManager.DispatchApplicationMessage(
                injectedApplicationMessage.SenderClientId,
                _sessionItems,
                injectedApplicationMessage.ApplicationMessage,
                cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            ThrowIfStarted();

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            await _retainedMessagesManager.Start().ConfigureAwait(false);
            _clientSessionsManager.Start();
            _keepAliveMonitor.Start(cancellationToken);

            foreach (var adapter in _adapters)
            {
                adapter.ClientHandler = c => OnHandleClient(c, cancellationToken);
                await adapter.StartAsync(_options, _rootLogger).ConfigureAwait(false);
            }

            await _eventContainer.StartedEvent.InvokeAsync(EventArgs.Empty).ConfigureAwait(false);

            _logger.Info("Started.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task StopAsync()
        {
            try
            {
                if (_cancellationTokenSource == null)
                {
                    return;
                }

                _cancellationTokenSource.Cancel(false);

                await _clientSessionsManager.CloseAllConnectionsAsync().ConfigureAwait(false);

                foreach (var adapter in _adapters)
                {
                    adapter.ClientHandler = null;
                    await adapter.StopAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }

            await _eventContainer.StoppedEvent.InvokeAsync(EventArgs.Empty).ConfigureAwait(false);

            _logger.Info("Stopped.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task SubscribeAsync(string clientId, ICollection<MqttTopicFilter> topicFilters)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            foreach (var topicFilter in topicFilters)
            {
                MqttTopicValidator.ThrowIfInvalidSubscribe(topicFilter.Topic);
            }

            ThrowIfDisposed();
            ThrowIfNotStarted();

            return _clientSessionsManager.SubscribeAsync(clientId, topicFilters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task UnsubscribeAsync(string clientId, ICollection<string> topicFilters)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            ThrowIfDisposed();
            ThrowIfNotStarted();

            return _clientSessionsManager.UnsubscribeAsync(clientId, topicFilters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retainedMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task UpdateRetainedMessageAsync(MqttApplicationMessage retainedMessage)
        {
            if (retainedMessage == null)
            {
                throw new ArgumentNullException(nameof(retainedMessage));
            }

            ThrowIfDisposed();
            ThrowIfNotStarted();

            return _retainedMessagesManager?.UpdateMessage(null, retainedMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopAsync().GetAwaiter().GetResult();

                foreach (var adapter in _adapters)
                {
                    adapter.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        Task OnHandleClient(IMqttChannelAdapter channelAdapter, CancellationToken cancellationToken)
        {
            return _clientSessionsManager.HandleClientConnectionAsync(channelAdapter, cancellationToken);
        }

        void ThrowIfNotStarted()
        {
            ThrowIfDisposed();

            if (_cancellationTokenSource == null)
            {
                throw new InvalidOperationException("The MQTT server is not started.");
            }
        }

        void ThrowIfStarted()
        {
            ThrowIfDisposed();

            if (_cancellationTokenSource != null)
            {
                throw new InvalidOperationException("The MQTT server is already started.");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class PublishResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public MqttPubAckReasonCode ReasonCode { get; set; } = MqttPubAckReasonCode.Success;
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class SubscribeResponse
    {
        /// <summary>
        /// Gets or sets the reason code which is sent to the client.
        /// The subscription is skipped when the value is not GrantedQoS_.
        /// MQTTv5 only.
        /// </summary>
        public MqttSubscribeReasonCode ReasonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; } = new List<MqttUserProperty>();
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class UnsubscribeResponse
    {
        /// <summary>
        /// Gets or sets the reason code which is sent to the client.
        /// MQTTv5 only.
        /// </summary>
        public MqttUnsubscribeReasonCode ReasonCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; } = new List<MqttUserProperty>();
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
    }
    #region // Events
    /// <summary>
    /// 
    /// </summary>
    public sealed class ApplicationMessageNotConsumedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="senderId"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationMessageNotConsumedEventArgs(MqttApplicationMessage applicationMessage, string senderId)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            SenderId = senderId;
        }

        /// <summary>
        ///     Gets the application message which was not consumed by any client.
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; }

        /// <summary>
        ///     Gets the ID of the client which has sent the affected application message.
        /// </summary>
        public string SenderId { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientAcknowledgedPublishPacketEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="sessionItems"></param>
        /// <param name="publishPacket"></param>
        /// <param name="acknowledgePacket"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientAcknowledgedPublishPacketEventArgs(string clientId, IDictionary sessionItems, MqttPublishPacket publishPacket, MqttPacketWithIdentifier acknowledgePacket)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
            PublishPacket = publishPacket ?? throw new ArgumentNullException(nameof(publishPacket));
            AcknowledgePacket = acknowledgePacket ?? throw new ArgumentNullException(nameof(acknowledgePacket));
        }

        /// <summary>
        ///     Gets the packet which was used for acknowledge. This can be a PubAck or PubComp packet.
        /// </summary>
        public MqttPacketWithIdentifier AcknowledgePacket { get; }

        /// <summary>
        ///     Gets the ID of the client which acknowledged a PUBLISH packet.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets whether the PUBLISH packet is fully acknowledged. This is the case for PUBACK (QoS 1) and PUBCOMP (QoS 2.
        /// </summary>
        public bool IsCompleted => AcknowledgePacket is MqttPubAckPacket || AcknowledgePacket is MqttPubCompPacket;

        /// <summary>
        ///     Gets the PUBLISH packet which was acknowledged.
        /// </summary>
        public MqttPublishPacket PublishPacket { get; }

        /// <summary>
        ///     Gets the session items which contain custom user data per session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="userName"></param>
        /// <param name="protocolVersion"></param>
        /// <param name="endpoint"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientConnectedEventArgs(string clientId, string userName, MqttProtocolVersion protocolVersion, string endpoint, IDictionary sessionItems)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            UserName = userName;
            ProtocolVersion = protocolVersion;
            Endpoint = endpoint;
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the client identifier of the connected client.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets the endpoint of the connected client.
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        ///     Gets the protocol version which is used by the connected client.
        /// </summary>
        public MqttProtocolVersion ProtocolVersion { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }

        /// <summary>
        ///     Gets the user name of the connected client.
        /// </summary>
        public string UserName { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientDisconnectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="disconnectType"></param>
        /// <param name="endpoint"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientDisconnectedEventArgs(string clientId, MqttClientDisconnectType disconnectType, string endpoint, IDictionary sessionItems)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            DisconnectType = disconnectType;
            Endpoint = endpoint;
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientDisconnectType DisconnectType { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientSubscribedTopicEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilter"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientSubscribedTopicEventArgs(string clientId, MqttTopicFilter topicFilter, IDictionary sessionItems)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            TopicFilter = topicFilter ?? throw new ArgumentNullException(nameof(topicFilter));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }

        /// <summary>
        ///     Gets the topic filter.
        ///     The topic filter can contain topics and wildcards.
        /// </summary>
        public MqttTopicFilter TopicFilter { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientUnsubscribedTopicEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilter"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ClientUnsubscribedTopicEventArgs(string clientId, string topicFilter, IDictionary sessionItems)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            TopicFilter = topicFilter ?? throw new ArgumentNullException(nameof(topicFilter));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }

        /// <summary>
        ///     Gets or sets the topic filter.
        ///     The topic filter can contain topics and wildcards.
        /// </summary>
        public string TopicFilter { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class InterceptingPacketEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="clientId"></param>
        /// <param name="endpoint"></param>
        /// <param name="packet"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InterceptingPacketEventArgs(CancellationToken cancellationToken, string clientId, string endpoint, MqttPacket packet, IDictionary sessionItems)
        {
            CancellationToken = cancellationToken;
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            Endpoint = endpoint;
            Packet = packet ?? throw new ArgumentNullException(nameof(packet));
            SessionItems = sessionItems;
        }

        /// <summary>
        ///     Gets the cancellation token from the connection managing thread.
        ///     Use this in further event processing.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///     Gets the client ID which has sent the packet or will receive the packet.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets the endpoint of the sending or receiving client.
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        ///     Gets or sets the MQTT packet which was received or will be sent.
        /// </summary>
        public MqttPacket Packet { get; set; }

        /// <summary>
        ///     Gets or sets whether the packet should be processed or not.
        /// </summary>
        public bool ProcessPacket { get; set; } = true;

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class InterceptingPublishEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="clientId"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InterceptingPublishEventArgs(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken, string clientId, IDictionary sessionItems)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            CancellationToken = cancellationToken;
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; set; }

        /// <summary>
        ///     Gets the cancellation token which can indicate that the client connection gets down.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool CloseConnection { get; set; }

        /// <summary>
        ///     Gets or sets whether the publish should be processed internally.
        /// </summary>
        public bool ProcessPublish { get; set; } = true;

        /// <summary>
        ///     Gets the response which will be sent to the client via the PUBACK etc. packets.
        /// </summary>
        public PublishResponse Response { get; } = new PublishResponse();

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class InterceptingSubscriptionEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="clientId"></param>
        /// <param name="session"></param>
        /// <param name="topicFilter"></param>
        public InterceptingSubscriptionEventArgs(
            CancellationToken cancellationToken,
            string clientId,
            MqttSessionStatus session,
            MqttTopicFilter topicFilter)
        {
            CancellationToken = cancellationToken;
            ClientId = clientId;
            Session = session;
            TopicFilter = topicFilter;
        }

        /// <summary>
        ///     Gets the cancellation token which can indicate that the client connection gets down.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets or sets whether the broker should close the client connection.
        /// </summary>
        public bool CloseConnection { get; set; }

        /// <summary>
        ///     Gets or sets whether the broker should create an internal subscription for the client.
        ///     The broker can also avoid this and return "success" to the client.
        ///     This feature allows using the MQTT Broker as the Frontend and another system as the backend.
        /// </summary>
        public bool ProcessSubscription { get; set; } = true;

        /// <summary>
        ///     Gets or sets the reason string which will be sent to the client in the SUBACK packet.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Gets the response which will be sent to the client via the SUBACK packet.
        /// </summary>
        public SubscribeResponse Response { get; } = new SubscribeResponse();

        /// <summary>
        ///     Gets the current client session.
        /// </summary>
        public MqttSessionStatus Session { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems => Session.Items;

        /// <summary>
        ///     Gets or sets the topic filter.
        ///     The topic filter can contain topics and wildcards.
        /// </summary>
        public MqttTopicFilter TopicFilter { get; set; }

        /// <summary>
        ///     Gets or sets the user properties.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class InterceptingUnsubscriptionEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="clientId"></param>
        /// <param name="sessionItems"></param>
        /// <param name="topic"></param>
        public InterceptingUnsubscriptionEventArgs(CancellationToken cancellationToken, string clientId, IDictionary sessionItems, string topic)
        {
            CancellationToken = cancellationToken;
            ClientId = clientId;
            SessionItems = sessionItems;
            Topic = topic;
        }

        /// <summary>
        ///     Gets the cancellation token which can indicate that the client connection gets down.
        /// </summary>
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets or sets whether the broker should close the client connection.
        /// </summary>
        public bool CloseConnection { get; set; }

        /// <summary>
        ///     Gets or sets whether the broker should remove an internal subscription for the client.
        ///     The broker can also avoid this and return "success" to the client.
        ///     This feature allows using the MQTT Broker as the Frontend and another system as the backend.
        /// </summary>
        public bool ProcessUnsubscription { get; set; } = true;

        /// <summary>
        ///     Gets the response which will be sent to the client via the UNSUBACK pocket.
        /// </summary>
        public UnsubscribeResponse Response { get; } = new UnsubscribeResponse();

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }

        /// <summary>
        ///     Gets or sets the MQTT topic.
        ///     In MQTT, the word topic refers to an UTF-8 string that the broker uses to filter messages for each connected
        ///     client.
        ///     The topic consists of one or more topic levels. Each topic level is separated by a forward slash (topic level
        ///     separator).
        /// </summary>
        public string Topic { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class LoadingRetainedMessagesEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MqttApplicationMessage> LoadedRetainedMessages { get; set; } = new List<MqttApplicationMessage>();
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class PreparingSessionEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; internal set; }

        // TODO: Allow adding of packets to the queue etc.

        /// <summary>
        /// The Session State in the Server consists of:
        /// The existence of a Session, even if the rest of the Session State is empty.
        /// The Clients subscriptions, including any Subscription Identifiers.
        /// QoS 1 and QoS 2 messages which have been sent to the Client, but have not been completely acknowledged.
        /// QoS 1 and QoS 2 messages pending transmission to the Client and OPTIONALLY QoS 0 messages pending transmission to the Client.
        /// QoS 2 messages which have been received from the Client, but have not been completely acknowledged.The Will Message and the Will Delay Interval
        /// If the Session is currently not connected, the time at which the Session will end and Session State will be discarded.
        /// </summary>
        public bool IsExistingSession { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<object, object> Items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttPublishPacket> PublishPackets { get; } = new List<MqttPublishPacket>();
        /// <summary>
        /// 
        /// </summary>
        DateTime? SessionExpiryTimestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttSubscription> Subscriptions { get; } = new List<MqttSubscription>();
        /// <summary>
        ///     Gets the will delay interval.
        ///     This is the time between the client disconnect and the time the will message will be sent.
        /// </summary>
        public uint? WillDelayInterval { get; set; }

        // <summary>
        //     Gets the last will message.
        //     In MQTT, you use the last will message feature to notify other clients about an ungracefully disconnected client.
        // </summary>
        // TODO: Use single properties. No entire will message.
        //MqttApplicationMessage WillMessage { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class RetainedMessageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="changedRetainedMessage"></param>
        /// <param name="storedRetainedMessages"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RetainedMessageChangedEventArgs(string clientId, MqttApplicationMessage changedRetainedMessage, List<MqttApplicationMessage> storedRetainedMessages)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            ChangedRetainedMessage = changedRetainedMessage ?? throw new ArgumentNullException(nameof(changedRetainedMessage));
            StoredRetainedMessages = storedRetainedMessages ?? throw new ArgumentNullException(nameof(storedRetainedMessages));
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttApplicationMessage ChangedRetainedMessage { get; }
        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttApplicationMessage> StoredRetainedMessages { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class SessionDeletedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sessionItems"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SessionDeletedEventArgs(string id, IDictionary sessionItems)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the ID of the session.
        /// </summary>
        public string Id { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class ValidatingConnectionEventArgs : EventArgs
    {
        readonly MqttConnectPacket _connectPacket;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectPacket"></param>
        /// <param name="clientAdapter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ValidatingConnectionEventArgs(MqttConnectPacket connectPacket, IMqttChannelAdapter clientAdapter)
        {
            _connectPacket = connectPacket ?? throw new ArgumentNullException(nameof(connectPacket));
            ChannelAdapter = clientAdapter ?? throw new ArgumentNullException(nameof(clientAdapter));
        }

        /// <summary>
        ///     Gets or sets the assigned client identifier.
        ///     MQTTv5 only.
        /// </summary>
        public string AssignedClientIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the authentication data.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public byte[] AuthenticationData => _connectPacket.AuthenticationData;

        /// <summary>
        ///     Gets or sets the authentication method.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public string AuthenticationMethod => _connectPacket.AuthenticationMethod;

        /// <summary>
        ///     Gets the channel adapter. This can be a _MqttConnectionContext_ (used in ASP.NET), a _MqttChannelAdapter_ (used for
        ///     TCP or WebSockets) or a custom implementation.
        /// </summary>
        public IMqttChannelAdapter ChannelAdapter { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether clean sessions are used or not.
        ///     When a client connects to a broker it can connect using either a non persistent connection (clean session) or a
        ///     persistent connection.
        ///     With a non persistent connection the broker doesn't store any subscription information or undelivered messages for
        ///     the client.
        ///     This mode is ideal when the client only publishes messages.
        ///     It can also connect as a durable client using a persistent connection.
        ///     In this mode, the broker will store subscription information, and undelivered messages for the client.
        /// </summary>
        public bool? CleanSession => _connectPacket.CleanSession;
        /// <summary>
        /// 
        /// </summary>
        public X509Certificate2 ClientCertificate => ChannelAdapter.ClientCertificate;

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId => _connectPacket.ClientId;
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint => ChannelAdapter.Endpoint;
        /// <summary>
        /// 
        /// </summary>
        public bool IsSecureConnection => ChannelAdapter.IsSecureConnection;

        /// <summary>
        ///     Gets or sets the keep alive period.
        ///     The connection is normally left open by the client so that is can send and receive data at any time.
        ///     If no data flows over an open connection for a certain time period then the client will generate a PINGREQ and
        ///     expect to receive a PINGRESP from the broker.
        ///     This message exchange confirms that the connection is open and working.
        ///     This period is known as the keep alive period.
        /// </summary>
        public ushort? KeepAlivePeriod => _connectPacket.KeepAlivePeriod;

        /// <summary>
        ///     A value of 0 indicates that the value is not used.
        /// </summary>
        public uint MaximumPacketSize => _connectPacket.MaximumPacketSize;
        /// <summary>
        /// 
        /// </summary>
        public string Password => Encoding.UTF8.GetString(RawPassword ?? EmptyBuffer.Array);
        /// <summary>
        /// 
        /// </summary>
        public MqttProtocolVersion ProtocolVersion => ChannelAdapter.PacketFormatterAdapter.ProtocolVersion;
        /// <summary>
        /// 
        /// </summary>
        public byte[] RawPassword => _connectPacket.Password;

        /// <summary>
        ///     Gets or sets the reason code. When a MQTTv3 client connects the enum value must be one which is
        ///     also supported in MQTTv3. Otherwise the connection attempt will fail because not all codes can be
        ///     converted properly.
        ///     MQTTv5 only.
        /// </summary>
        public MqttConnectReasonCode ReasonCode { get; set; } = MqttConnectReasonCode.Success;
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Gets or sets the receive maximum.
        ///     This gives the maximum length of the receive messages.
        ///     A value of 0 indicates that the value is not used.
        /// </summary>
        public ushort ReceiveMaximum => _connectPacket.ReceiveMaximum;

        /// <summary>
        ///     Gets the request problem information.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public bool RequestProblemInformation => _connectPacket.RequestProblemInformation;

        /// <summary>
        ///     Gets the request response information.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public bool RequestResponseInformation => _connectPacket.RequestResponseInformation;

        /// <summary>
        ///     Gets or sets the response authentication data.
        ///     MQTTv5 only.
        /// </summary>
        public byte[] ResponseAuthenticationData { get; set; }

        /// <summary>
        ///     Gets or sets the response user properties.
        ///     In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT
        ///     packet.
        ///     As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add
        ///     metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        ///     The feature is very similar to the HTTP header concept.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> ResponseUserProperties { get; set; }

        /// <summary>
        ///     Gets or sets the server reference. This can be used together with i.e. "Server Moved" to send
        ///     a different server address to the client.
        ///     MQTTv5 only.
        /// </summary>
        public string ServerReference { get; set; }

        /// <summary>
        ///     Gets the session expiry interval.
        ///     The time after a session expires when it's not actively used.
        ///     A value of 0 means no expiation.
        /// </summary>
        public uint SessionExpiryInterval => _connectPacket.SessionExpiryInterval;

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; internal set; }

        /// <summary>
        ///     Gets or sets the topic alias maximum.
        ///     This gives the maximum length of the topic alias.
        ///     A value of 0 indicates that the value is not used.
        /// </summary>
        public ushort TopicAliasMaximum => _connectPacket.TopicAliasMaximum;
        /// <summary>
        /// 
        /// </summary>
        [Obsolete("This property name has a typo. Use 'UserName' instead. This one will be removed soon.")]
        public string Username => _connectPacket.Username;
        /// <summary>
        /// 
        /// </summary>
        public string UserName => _connectPacket.Username;

        /// <summary>
        ///     Gets or sets the user properties.
        ///     In MQTT 5, user properties are basic UTF-8 string key-value pairs that you can append to almost every type of MQTT
        ///     packet.
        ///     As long as you don’t exceed the maximum message size, you can use an unlimited number of user properties to add
        ///     metadata to MQTT messages and pass information between publisher, broker, and subscriber.
        ///     The feature is very similar to the HTTP header concept.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public List<MqttUserProperty> UserProperties => _connectPacket.UserProperties;

        /// <summary>
        ///     Gets or sets the will delay interval.
        ///     This is the time between the client disconnect and the time the will message will be sent.
        ///     A value of 0 indicates that the value is not used.
        /// </summary>
        public uint WillDelayInterval => _connectPacket.WillDelayInterval;
    }
    #endregion Events
    #region // Internal
    /// <summary>
    /// 
    /// </summary>
    public sealed class CheckSubscriptionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public static CheckSubscriptionsResult NotSubscribed { get; } = new CheckSubscriptionsResult();
        /// <summary>
        /// 
        /// </summary>
        public bool IsSubscribed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RetainAsPublished { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<uint> SubscriptionIdentifiers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel QualityOfServiceLevel { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class DispatchApplicationMessageResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reasonCode"></param>
        /// <param name="closeConnection"></param>
        /// <param name="reasonString"></param>
        /// <param name="userProperties"></param>
        public DispatchApplicationMessageResult(int reasonCode, bool closeConnection, string reasonString, List<MqttUserProperty> userProperties)
        {
            ReasonCode = reasonCode;
            CloseConnection = closeConnection;
            ReasonString = reasonString;
            UserProperties = userProperties;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CloseConnection { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ReasonCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionChangedNotification
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSession"></param>
        /// <param name="subscriptionsTopics"></param>
        void OnSubscriptionsAdded(MqttSession clientSession, List<string> subscriptionsTopics);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSession"></param>
        /// <param name="subscriptionTopics"></param>
        void OnSubscriptionsRemoved(MqttSession clientSession, List<string> subscriptionTopics);
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttServerClient : IDisposable
    {
        readonly MqttConnectPacket _connectPacket;
        readonly MqttServerEventContainer _eventContainer;
        readonly MqttNetSourceLogger _logger;
        readonly MqttServerOptions _serverOptions;
        readonly MqttClientSessionsManager _sessionsManager;
        readonly Dictionary<ushort, string> _topicAlias = new Dictionary<ushort, string>();

        CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        bool _disconnectPacketSent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectPacket"></param>
        /// <param name="channelAdapter"></param>
        /// <param name="session"></param>
        /// <param name="serverOptions"></param>
        /// <param name="eventContainer"></param>
        /// <param name="sessionsManager"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServerClient(
            MqttConnectPacket connectPacket,
            IMqttChannelAdapter channelAdapter,
            MqttSession session,
            MqttServerOptions serverOptions,
            MqttServerEventContainer eventContainer,
            MqttClientSessionsManager sessionsManager,
            IMqttNetLogger logger)
        {
            _serverOptions = serverOptions ?? throw new ArgumentNullException(nameof(serverOptions));
            _eventContainer = eventContainer ?? throw new ArgumentNullException(nameof(eventContainer));
            _sessionsManager = sessionsManager ?? throw new ArgumentNullException(nameof(sessionsManager));
            _connectPacket = connectPacket ?? throw new ArgumentNullException(nameof(connectPacket));

            ChannelAdapter = channelAdapter ?? throw new ArgumentNullException(nameof(channelAdapter));
            Endpoint = channelAdapter.Endpoint;
            Session = session ?? throw new ArgumentNullException(nameof(session));

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger.WithSource(nameof(MqttServerClient));
        }
        /// <summary>
        /// 
        /// </summary>
        public IMqttChannelAdapter ChannelAdapter { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Id => _connectPacket.ClientId;
        /// <summary>
        /// 
        /// </summary>
        public bool IsCleanDisconnect { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTakenOver { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort KeepAlivePeriod => _connectPacket.KeepAlivePeriod;
        /// <summary>
        /// 
        /// </summary>
        public MqttSession Session { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientStatistics Statistics { get; } = new MqttClientStatistics();
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _cancellationToken?.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResetStatistics()
        {
            ChannelAdapter.ResetStatistics();
            Statistics.ResetStatistics();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            _logger.Info("Client '{0}': Session started", Id);

            Session.LatestConnectPacket = _connectPacket;
            Session.WillMessageSent = false;

            try
            {
                var cancellationToken = _cancellationToken.Token;

                _ = Task.Factory.StartNew(() => SendPacketsLoop(cancellationToken), cancellationToken, TaskCreationOptions.PreferFairness, TaskScheduler.Default)
                    .ConfigureAwait(false);

                IsRunning = true;

                await ReceivePackagesLoop(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                IsRunning = false;

                _cancellationToken?.TryCancel();
                _cancellationToken?.Dispose();
                _cancellationToken = null;
            }

            if (!IsTakenOver && !IsCleanDisconnect && Session.LatestConnectPacket.WillFlag && !Session.WillMessageSent)
            {
                var willPublishPacket = MqttPacketFactories.Publish.Create(Session.LatestConnectPacket);
                var willApplicationMessage = MqttApplicationMessageFactory.Create(willPublishPacket);

                _ = _sessionsManager.DispatchApplicationMessage(Id, Session.Items, willApplicationMessage, CancellationToken.None);
                Session.WillMessageSent = true;

                _logger.Info("Client '{0}': Published will message", Id);
            }

            _logger.Info("Client '{0}': Connection stopped", Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SendPacketAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            packet = await InterceptPacketAsync(packet, cancellationToken).ConfigureAwait(false);
            if (packet == null)
            {
                // The interceptor has decided that this packet will not used at all.
                // This might break the protocol but the user wants that.
                return;
            }

            await ChannelAdapter.SendPacketAsync(packet, cancellationToken).ConfigureAwait(false);
            Statistics.HandleSentPacket(packet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        public async Task StopAsync(MqttDisconnectReasonCode reason)
        {
            IsRunning = false;

            if (!_disconnectPacketSent)
            {
                // Sending DISCONNECT packets from the server to the client is only supported when using MQTTv5+.
                if (ChannelAdapter.PacketFormatterAdapter.ProtocolVersion == MqttProtocolVersion.V500)
                {
                    // The Client or Server MAY send a DISCONNECT packet before closing the Network Connection.
                    // This library does not sent a DISCONNECT packet for a normal disconnection. Maybe adding
                    // a configuration option is requested in the future.
                    if (reason != MqttDisconnectReasonCode.NormalDisconnection)
                    {
                        // Is is very important to send the DISCONNECT packet here BEFORE cancelling the
                        // token because the entire connection is closed (disposed) as soon as the cancellation
                        // token is cancelled. To there is no chance that the DISCONNECT packet will ever arrive
                        // at the client!
                        await TrySendDisconnectPacket(reason).ConfigureAwait(false);
                    }
                }
            }

            StopInternal();
        }

        Task ClientAcknowledgedPublishPacket(MqttPublishPacket publishPacket, MqttPacketWithIdentifier acknowledgePacket)
        {
            if (_eventContainer.ClientAcknowledgedPublishPacketEvent.HasHandlers)
            {
                var eventArgs = new ClientAcknowledgedPublishPacketEventArgs(Id, Session.Items, publishPacket, acknowledgePacket);
                return _eventContainer.ClientAcknowledgedPublishPacketEvent.TryInvokeAsync(eventArgs, _logger);
            }

            return CompletedTask.Instance;
        }

        void HandleIncomingPingReqPacket()
        {
            // See: The Server MUST send a PINGRESP packet in response to a PINGREQ packet [MQTT-3.12.4-1].
            Session.EnqueueHealthPacket(new MqttPacketBusItem(MqttPingRespPacket.Instance));
        }

        Task HandleIncomingPubAckPacket(MqttPubAckPacket pubAckPacket)
        {
            var acknowledgedPublishPacket = Session.AcknowledgePublishPacket(pubAckPacket.PacketIdentifier);

            if (acknowledgedPublishPacket != null)
            {
                return ClientAcknowledgedPublishPacket(acknowledgedPublishPacket, pubAckPacket);
            }

            return CompletedTask.Instance;
        }

        Task HandleIncomingPubCompPacket(MqttPubCompPacket pubCompPacket)
        {
            var acknowledgedPublishPacket = Session.AcknowledgePublishPacket(pubCompPacket.PacketIdentifier);

            if (acknowledgedPublishPacket != null)
            {
                return ClientAcknowledgedPublishPacket(acknowledgedPublishPacket, pubCompPacket);
            }

            return CompletedTask.Instance;
        }

        async Task HandleIncomingPublishPacket(MqttPublishPacket publishPacket, CancellationToken cancellationToken)
        {
            HandleTopicAlias(publishPacket);

            var applicationMessage = MqttApplicationMessageFactory.Create(publishPacket);

            var dispatchApplicationMessageResult =
                await _sessionsManager.DispatchApplicationMessage(Id, Session.Items, applicationMessage, cancellationToken).ConfigureAwait(false);

            if (dispatchApplicationMessageResult.CloseConnection)
            {
                await StopAsync(MqttDisconnectReasonCode.UnspecifiedError);
                return;
            }

            switch (publishPacket.QualityOfServiceLevel)
            {
                case MqttQualityOfServiceLevel.AtMostOnce:
                    {
                        // Do nothing since QoS 0 has no ACK at all!
                        break;
                    }
                case MqttQualityOfServiceLevel.AtLeastOnce:
                    {
                        var pubAckPacket = MqttPacketFactories.PubAck.Create(publishPacket, dispatchApplicationMessageResult);
                        Session.EnqueueControlPacket(new MqttPacketBusItem(pubAckPacket));
                        break;
                    }
                case MqttQualityOfServiceLevel.ExactlyOnce:
                    {
                        var pubRecPacket = MqttPacketFactories.PubRec.Create(publishPacket, dispatchApplicationMessageResult);
                        Session.EnqueueControlPacket(new MqttPacketBusItem(pubRecPacket));
                        break;
                    }
                default:
                    {
                        throw new MqttCommunicationException("Received a not supported QoS level");
                    }
            }
        }

        Task HandleIncomingPubRecPacket(MqttPubRecPacket pubRecPacket)
        {
            // Do not fire the event _ClientAcknowledgedPublishPacket_ here because the QoS 2 process is only finished
            // properly when the client has sent the PUBCOMP packet.
            var pubRelPacket = MqttPacketFactories.PubRel.Create(pubRecPacket, MqttApplicationMessageReceivedReasonCode.Success);
            Session.EnqueueControlPacket(new MqttPacketBusItem(pubRelPacket));

            return CompletedTask.Instance;
        }

        void HandleIncomingPubRelPacket(MqttPubRelPacket pubRelPacket)
        {
            var pubCompPacket = MqttPacketFactories.PubComp.Create(pubRelPacket, MqttApplicationMessageReceivedReasonCode.Success);
            Session.EnqueueControlPacket(new MqttPacketBusItem(pubCompPacket));
        }

        async Task HandleIncomingSubscribePacket(MqttSubscribePacket subscribePacket, CancellationToken cancellationToken)
        {
            var subscribeResult = await Session.Subscribe(subscribePacket, cancellationToken).ConfigureAwait(false);

            var subAckPacket = MqttPacketFactories.SubAck.Create(subscribePacket, subscribeResult);

            Session.EnqueueControlPacket(new MqttPacketBusItem(subAckPacket));

            if (subscribeResult.CloseConnection)
            {
                StopInternal();
                return;
            }

            if (subscribeResult.RetainedMessages != null)
            {
                foreach (var retainedMessageMatch in subscribeResult.RetainedMessages)
                {
                    var publishPacket = MqttPacketFactories.Publish.Create(retainedMessageMatch);
                    Session.EnqueueDataPacket(new MqttPacketBusItem(publishPacket));
                }
            }
        }

        async Task HandleIncomingUnsubscribePacket(MqttUnsubscribePacket unsubscribePacket, CancellationToken cancellationToken)
        {
            var unsubscribeResult = await Session.Unsubscribe(unsubscribePacket, cancellationToken).ConfigureAwait(false);

            var unsubAckPacket = MqttPacketFactories.UnsubAck.Create(unsubscribePacket, unsubscribeResult);

            Session.EnqueueControlPacket(new MqttPacketBusItem(unsubAckPacket));

            if (unsubscribeResult.CloseConnection)
            {
                StopInternal();
            }
        }

        void HandleTopicAlias(MqttPublishPacket publishPacket)
        {
            if (publishPacket.TopicAlias == 0)
            {
                return;
            }

            lock (_topicAlias)
            {
                if (!string.IsNullOrEmpty(publishPacket.Topic))
                {
                    _topicAlias[publishPacket.TopicAlias] = publishPacket.Topic;
                }
                else
                {
                    if (_topicAlias.TryGetValue(publishPacket.TopicAlias, out var topic))
                    {
                        publishPacket.Topic = topic;
                    }
                    else
                    {
                        _logger.Warning("Client '{0}': Received invalid topic alias ({1})", Id, publishPacket.TopicAlias);
                    }
                }
            }
        }

        async Task<MqttPacket> InterceptPacketAsync(MqttPacket packet, CancellationToken cancellationToken)
        {
            if (!_eventContainer.InterceptingOutboundPacketEvent.HasHandlers)
            {
                return packet;
            }

            var interceptingPacketEventArgs = new InterceptingPacketEventArgs(cancellationToken, Id, Endpoint, packet, Session.Items);
            await _eventContainer.InterceptingOutboundPacketEvent.InvokeAsync(interceptingPacketEventArgs).ConfigureAwait(false);

            if (!interceptingPacketEventArgs.ProcessPacket || packet == null)
            {
                return null;
            }

            return interceptingPacketEventArgs.Packet;
        }

        async Task ReceivePackagesLoop(CancellationToken cancellationToken)
        {
            MqttPacket currentPacket = null;
            try
            {
                // We do not listen for the cancellation token here because the internal buffer might still
                // contain data to be read even if the TCP connection was already dropped. So we rely on an
                // own exception in the reading loop!
                while (!cancellationToken.IsCancellationRequested)
                {
#if !NET40
                    await Task.Yield();
#endif
                    currentPacket = await ChannelAdapter.ReceivePacketAsync(cancellationToken).ConfigureAwait(false);
                    if (currentPacket == null)
                    {
                        return;
                    }

                    // Check for cancellation again because receive packet might block some time.
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    // The TCP connection of this client may be still open but the client has already been taken over by
                    // a new TCP connection. So we must exit here to make sure to no longer process any message.
                    if (IsTakenOver || !IsRunning)
                    {
                        return;
                    }

                    var processPacket = true;

                    if (_eventContainer.InterceptingInboundPacketEvent.HasHandlers)
                    {
                        var interceptingPacketEventArgs = new InterceptingPacketEventArgs(cancellationToken, Id, Endpoint, currentPacket, Session.Items);
                        await _eventContainer.InterceptingInboundPacketEvent.InvokeAsync(interceptingPacketEventArgs).ConfigureAwait(false);
                        currentPacket = interceptingPacketEventArgs.Packet;
                        processPacket = interceptingPacketEventArgs.ProcessPacket;
                    }

                    if (!processPacket || currentPacket == null)
                    {
                        // Restart the receiving process to get the next packet ignoring the current one..
                        continue;
                    }

                    Statistics.HandleReceivedPacket(currentPacket);

                    if (currentPacket is MqttPublishPacket publishPacket)
                    {
                        await HandleIncomingPublishPacket(publishPacket, cancellationToken).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttPubAckPacket pubAckPacket)
                    {
                        await HandleIncomingPubAckPacket(pubAckPacket).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttPubCompPacket pubCompPacket)
                    {
                        await HandleIncomingPubCompPacket(pubCompPacket).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttPubRecPacket pubRecPacket)
                    {
                        await HandleIncomingPubRecPacket(pubRecPacket).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttPubRelPacket pubRelPacket)
                    {
                        HandleIncomingPubRelPacket(pubRelPacket);
                    }
                    else if (currentPacket is MqttSubscribePacket subscribePacket)
                    {
                        await HandleIncomingSubscribePacket(subscribePacket, cancellationToken).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttUnsubscribePacket unsubscribePacket)
                    {
                        await HandleIncomingUnsubscribePacket(unsubscribePacket, cancellationToken).ConfigureAwait(false);
                    }
                    else if (currentPacket is MqttPingReqPacket)
                    {
                        HandleIncomingPingReqPacket();
                    }
                    else if (currentPacket is MqttPingRespPacket)
                    {
                        throw new MqttProtocolViolationException("A PINGRESP Packet is sent by the Server to the Client in response to a PINGREQ Packet only.");
                    }
                    else if (currentPacket is MqttDisconnectPacket)
                    {
                        IsCleanDisconnect = true;
                        return;
                    }
                    else
                    {
                        throw new MqttProtocolViolationException("Packet not allowed");
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                if (exception is MqttCommunicationException)
                {
                    _logger.Warning(exception, "Client '{0}': Communication exception while receiving packets", Id);
                    return;
                }

                var logLevel = MqttNetLogLevel.Error;

                if (!IsRunning)
                {
                    // There was an exception but the connection is already closed. So there is no chance to send a response to the client etc.
                    logLevel = MqttNetLogLevel.Warning;
                }

                if (currentPacket == null)
                {
                    _logger.Publish(logLevel, exception, "Client '{0}': Error while receiving packets", Id);
                }
                else
                {
                    _logger.Publish(logLevel, exception, "Client '{0}': Error while processing {1} packet", Id, currentPacket.GetRfcName());
                }
            }
        }

        async Task SendPacketsLoop(CancellationToken cancellationToken)
        {
            MqttPacketBusItem packetBusItem = null;

            try
            {
                while (!cancellationToken.IsCancellationRequested && !IsTakenOver && IsRunning)
                {
                    packetBusItem = await Session.DequeuePacketAsync(cancellationToken).ConfigureAwait(false);

                    // Also check the cancellation token here because the dequeue is blocking and may take some time.
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    if (IsTakenOver || !IsRunning)
                    {
                        return;
                    }

                    try
                    {
                        await SendPacketAsync(packetBusItem.Packet, cancellationToken).ConfigureAwait(false);
                        packetBusItem.Complete();
                    }
                    catch (OperationCanceledException)
                    {
                        packetBusItem.Cancel();
                    }
                    catch (Exception exception)
                    {
                        packetBusItem.Fail(exception);
                    }
                    finally
                    {
#if !NET40
                        await Task.Yield();
#endif
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                if (exception is MqttCommunicationTimedOutException)
                {
                    _logger.Warning(exception, "Client '{0}': Sending PUBLISH packet failed due to timeout", Id);
                }
                else if (exception is MqttCommunicationException)
                {
                    _logger.Warning(exception, "Client '{0}': Sending PUBLISH packet failed due to communication exception", Id);
                }
                else
                {
                    _logger.Error(exception, "Client '{0}': Sending PUBLISH packet failed", Id);
                }

                if (packetBusItem?.Packet is MqttPublishPacket publishPacket)
                {
                    if (publishPacket.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
                    {
                        publishPacket.Dup = true;
                        Session.EnqueueDataPacket(new MqttPacketBusItem(publishPacket));
                    }
                }

                StopInternal();
            }
        }

        void StopInternal()
        {
            _cancellationToken?.TryCancel();
        }

        async Task TrySendDisconnectPacket(MqttDisconnectReasonCode reasonCode)
        {
            try
            {
                // This also indicates that it was tried at least!
                _disconnectPacketSent = true;

                var disconnectPacket = MqttPacketFactories.Disconnect.Create(reasonCode);
#if NET40
                using (var timeout = new CancellationTokenSource())
                {
                    timeout.CancelAfter(_serverOptions.DefaultCommunicationTimeout);
#else
                using (var timeout = new CancellationTokenSource(_serverOptions.DefaultCommunicationTimeout))
                {
#endif
                    await SendPacketAsync(disconnectPacket, timeout.Token).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                _logger.Warning(exception, "Client '{0}': Error while sending DISCONNECT packet (ReasonCode = {1})", Id, reasonCode);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSessionsManager : ISubscriptionChangedNotification, IDisposable
    {
        readonly Dictionary<string, MqttServerClient> _clients = new Dictionary<string, MqttServerClient>(4096);

        readonly AsyncLock _createConnectionSyncRoot = new AsyncLock();

        readonly MqttServerEventContainer _eventContainer;
        readonly MqttNetSourceLogger _logger;
        readonly MqttServerOptions _options;

        readonly MqttRetainedMessagesManager _retainedMessagesManager;
        readonly IMqttNetLogger _rootLogger;

        // The _sessions dictionary contains all session, the _subscriberSessions hash set contains subscriber sessions only.
        // See the MqttSubscription object for a detailed explanation.
        readonly Dictionary<string, MqttSession> _sessions = new Dictionary<string, MqttSession>(4096);

        readonly object _sessionsManagementLock = new object();
        readonly HashSet<MqttSession> _subscriberSessions = new HashSet<MqttSession>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="retainedMessagesManager"></param>
        /// <param name="eventContainer"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientSessionsManager(
            MqttServerOptions options,
            MqttRetainedMessagesManager retainedMessagesManager,
            MqttServerEventContainer eventContainer,
            IMqttNetLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger.WithSource(nameof(MqttClientSessionsManager));
            _rootLogger = logger;

            _options = options ?? throw new ArgumentNullException(nameof(options));
            _retainedMessagesManager = retainedMessagesManager ?? throw new ArgumentNullException(nameof(retainedMessagesManager));
            _eventContainer = eventContainer ?? throw new ArgumentNullException(nameof(eventContainer));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CloseAllConnectionsAsync()
        {
            List<MqttServerClient> connections;
            lock (_clients)
            {
                connections = _clients.Values.ToList();
                _clients.Clear();
            }

            foreach (var connection in connections)
            {
                await connection.StopAsync(MqttDisconnectReasonCode.NormalDisconnection).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task DeleteSessionAsync(string clientId)
        {
            _logger.Verbose("Deleting session for client '{0}'.", clientId);

            MqttServerClient connection;

            lock (_clients)
            {
                _clients.TryGetValue(clientId, out connection);
            }

            MqttSession session;

            lock (_sessionsManagementLock)
            {
                _sessions.TryGetValue(clientId, out session);
                _sessions.Remove(clientId);

                if (session != null)
                {
                    _subscriberSessions.Remove(session);
                }
            }

            try
            {
                if (connection != null)
                {
                    await connection.StopAsync(MqttDisconnectReasonCode.NormalDisconnection).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Error while deleting session '{clientId}'.");
            }

            try
            {
                if (_eventContainer.SessionDeletedEvent.HasHandlers && session != null)
                {
                    var eventArgs = new SessionDeletedEventArgs(clientId, session.Items);
                    await _eventContainer.SessionDeletedEvent.TryInvokeAsync(eventArgs, _logger).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                _logger.Error(exception, $"Error while executing session deleted event for session '{clientId}'.");
            }

            session?.Dispose();

            _logger.Verbose("Session for client '{0}' deleted.", clientId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="senderSessionItems"></param>
        /// <param name="applicationMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DispatchApplicationMessageResult> DispatchApplicationMessage(
            string senderId,
            IDictionary senderSessionItems,
            MqttApplicationMessage applicationMessage,
            CancellationToken cancellationToken)
        {
            var processPublish = true;
            var closeConnection = false;
            string reasonString = null;
            List<MqttUserProperty> userProperties = null;
            var reasonCode = 0; // The reason code is later converted into several different but compatible enums!

            // Allow the user to intercept application message...
            if (_eventContainer.InterceptingPublishEvent.HasHandlers)
            {
                var interceptingPublishEventArgs = new InterceptingPublishEventArgs(applicationMessage, cancellationToken, senderId, senderSessionItems);
                if (string.IsNullOrEmpty(interceptingPublishEventArgs.ApplicationMessage.Topic))
                {
                    // This can happen if a topic alias us used but the topic is
                    // unknown to the server.
                    interceptingPublishEventArgs.Response.ReasonCode = MqttPubAckReasonCode.TopicNameInvalid;
                    interceptingPublishEventArgs.ProcessPublish = false;
                }

                await _eventContainer.InterceptingPublishEvent.InvokeAsync(interceptingPublishEventArgs).ConfigureAwait(false);

                applicationMessage = interceptingPublishEventArgs.ApplicationMessage;
                closeConnection = interceptingPublishEventArgs.CloseConnection;
                processPublish = interceptingPublishEventArgs.ProcessPublish;
                reasonString = interceptingPublishEventArgs.Response.ReasonString;
                userProperties = interceptingPublishEventArgs.Response.UserProperties;
                reasonCode = (int)interceptingPublishEventArgs.Response.ReasonCode;
            }

            // Process the application message...
            if (processPublish && applicationMessage != null)
            {
                var matchingSubscribersCount = 0;
                try
                {
                    if (applicationMessage.Retain)
                    {
                        await _retainedMessagesManager.UpdateMessage(senderId, applicationMessage).ConfigureAwait(false);
                    }

                    List<MqttSession> subscriberSessions;
                    lock (_sessionsManagementLock)
                    {
                        subscriberSessions = _subscriberSessions.ToList();
                    }

                    // Calculate application message topic hash once for subscription checks
                    MqttSubscription.CalculateTopicHash(applicationMessage.Topic, out var topicHash, out _, out _);

                    foreach (var session in subscriberSessions)
                    {
                        if (!session.TryCheckSubscriptions(
                                applicationMessage.Topic,
                                topicHash,
                                applicationMessage.QualityOfServiceLevel,
                                senderId,
                                out var checkSubscriptionsResult))
                        {
                            // Checking the subscriptions has failed for the session. The session
                            // will be ignored.
                            continue;
                        }

                        if (!checkSubscriptionsResult.IsSubscribed)
                        {
                            continue;
                        }

                        var publishPacketCopy = MqttPacketFactories.Publish.Create(applicationMessage);
                        publishPacketCopy.QualityOfServiceLevel = checkSubscriptionsResult.QualityOfServiceLevel;
                        publishPacketCopy.SubscriptionIdentifiers = checkSubscriptionsResult.SubscriptionIdentifiers;

                        if (publishPacketCopy.QualityOfServiceLevel > 0)
                        {
                            publishPacketCopy.PacketIdentifier = session.PacketIdentifierProvider.GetNextPacketIdentifier();
                        }

                        if (checkSubscriptionsResult.RetainAsPublished)
                        {
                            // Transfer the original retain state from the publisher. This is a MQTTv5 feature.
                            publishPacketCopy.Retain = applicationMessage.Retain;
                        }
                        else
                        {
                            publishPacketCopy.Retain = false;
                        }

                        session.EnqueueDataPacket(new MqttPacketBusItem(publishPacketCopy));
                        matchingSubscribersCount++;

                        _logger.Verbose("Client '{0}': Queued PUBLISH packet with topic '{1}'.", session.Id, applicationMessage.Topic);
                    }

                    if (matchingSubscribersCount == 0)
                    {
                        reasonCode = (int)MqttPubAckReasonCode.NoMatchingSubscribers;
                        await FireApplicationMessageNotConsumedEvent(applicationMessage, senderId).ConfigureAwait(false);
                    }
                }
                catch (Exception exception)
                {
                    _logger.Error(exception, "Unhandled exception while processing next queued application message.");
                }
            }

            return new DispatchApplicationMessageResult(reasonCode, closeConnection, reasonString, userProperties);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _createConnectionSyncRoot.Dispose();

            lock (_sessionsManagementLock)
            {
                foreach (var sessionItem in _sessions)
                {
                    sessionItem.Value.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public MqttServerClient GetClient(string id)
        {
            lock (_clients)
            {
                if (!_clients.TryGetValue(id, out var client))
                {
                    throw new InvalidOperationException($"Client with ID '{id}' not found.");
                }

                return client;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MqttServerClient> GetClients()
        {
            lock (_clients)
            {
                return _clients.Values.ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttClientStatus>> GetClientStatusesAsync()
        {
            var result = new List<MqttClientStatus>();

            lock (_clients)
            {
                foreach (var connection in _clients.Values)
                {
                    var clientStatus = new MqttClientStatus(connection)
                    {
                        Session = new MqttSessionStatus(connection.Session)
                    };

                    result.Add(clientStatus);
                }
            }

            return TestTry.TaskFromResult((IList<MqttClientStatus>)result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttSessionStatus>> GetSessionStatusAsync()
        {
            var result = new List<MqttSessionStatus>();

            lock (_sessionsManagementLock)
            {
                foreach (var sessionItem in _sessions)
                {
                    var sessionStatus = new MqttSessionStatus(sessionItem.Value);
                    result.Add(sessionStatus);
                }
            }

            return TestTry.TaskFromResult((IList<MqttSessionStatus>)result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelAdapter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleClientConnectionAsync(IMqttChannelAdapter channelAdapter, CancellationToken cancellationToken)
        {
            MqttServerClient client = null;

            try
            {
                var connectPacket = await ReceiveConnectPacket(channelAdapter, cancellationToken).ConfigureAwait(false);
                if (connectPacket == null)
                {
                    // Nothing was received in time etc.
                    return;
                }

                var validatingConnectionEventArgs = await ValidateConnection(connectPacket, channelAdapter).ConfigureAwait(false);
                var connAckPacket = MqttPacketFactories.ConnAck.Create(validatingConnectionEventArgs);

                if (validatingConnectionEventArgs.ReasonCode != MqttConnectReasonCode.Success)
                {
                    // Send failure response here without preparing a connection and session!
                    await channelAdapter.SendPacketAsync(connAckPacket, cancellationToken).ConfigureAwait(false);
                    return;
                }

                // Pass connAckPacket so that IsSessionPresent flag can be set if the client session already exists.
                client = await CreateClientConnection(connectPacket, connAckPacket, channelAdapter, validatingConnectionEventArgs).ConfigureAwait(false);

                await client.SendPacketAsync(connAckPacket, cancellationToken).ConfigureAwait(false);

                if (_eventContainer.ClientConnectedEvent.HasHandlers)
                {
                    var eventArgs = new ClientConnectedEventArgs(
                        connectPacket.ClientId,
                        connectPacket.Username,
                        channelAdapter.PacketFormatterAdapter.ProtocolVersion,
                        channelAdapter.Endpoint,
                        client.Session.Items);

                    await _eventContainer.ClientConnectedEvent.TryInvokeAsync(eventArgs, _logger).ConfigureAwait(false);
                }

                await client.RunAsync().ConfigureAwait(false);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
            }
            finally
            {
                if (client != null)
                {
                    if (client.Id != null)
                    {
                        // in case it is a takeover _clientConnections already contains the new connection
                        if (!client.IsTakenOver)
                        {
                            lock (_clients)
                            {
                                _clients.Remove(client.Id);
                            }

                            if (!_options.EnablePersistentSessions || !client.Session.IsPersistent)
                            {
                                await DeleteSessionAsync(client.Id).ConfigureAwait(false);
                            }
                        }
                    }

                    var endpoint = client.Endpoint;

                    if (client.Id != null && !client.IsTakenOver && _eventContainer.ClientDisconnectedEvent.HasHandlers)
                    {
                        var disconnectType = client.IsCleanDisconnect ? MqttClientDisconnectType.Clean : MqttClientDisconnectType.NotClean;
                        var eventArgs = new ClientDisconnectedEventArgs(client.Id, disconnectType, endpoint, client.Session.Items);

                        await _eventContainer.ClientDisconnectedEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
                    }
                }
#if NET40
                using (var timeout = new CancellationTokenSource())
                {
                    timeout.CancelAfter(_options.DefaultCommunicationTimeout);
#else
                using (var timeout = new CancellationTokenSource(_options.DefaultCommunicationTimeout))
                {
#endif
                    await channelAdapter.DisconnectAsync(timeout.Token).ConfigureAwait(false);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSession"></param>
        /// <param name="topics"></param>
        public void OnSubscriptionsAdded(MqttSession clientSession, List<string> topics)
        {
            lock (_sessionsManagementLock)
            {
                if (!clientSession.HasSubscribedTopics)
                {
                    // first subscribed topic
                    _subscriberSessions.Add(clientSession);
                }

                foreach (var topic in topics)
                {
                    clientSession.AddSubscribedTopic(topic);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientSession"></param>
        /// <param name="subscriptionTopics"></param>
        public void OnSubscriptionsRemoved(MqttSession clientSession, List<string> subscriptionTopics)
        {
            lock (_sessionsManagementLock)
            {
                foreach (var subscriptionTopic in subscriptionTopics)
                {
                    clientSession.RemoveSubscribedTopic(subscriptionTopic);
                }

                if (!clientSession.HasSubscribedTopics)
                {
                    // last subscription removed
                    _subscriberSessions.Remove(clientSession);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            if (!_options.EnablePersistentSessions)
            {
                _sessions.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task SubscribeAsync(string clientId, ICollection<MqttTopicFilter> topicFilters)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            var fakeSubscribePacket = new MqttSubscribePacket();
            fakeSubscribePacket.TopicFilters.AddRange(topicFilters);

            var clientSession = GetClientSession(clientId);

            var subscribeResult = await clientSession.Subscribe(fakeSubscribePacket, CancellationToken.None).ConfigureAwait(false);

            if (subscribeResult.RetainedMessages != null)
            {
                foreach (var retainedMessageMatch in subscribeResult.RetainedMessages)
                {
                    var publishPacket = MqttPacketFactories.Publish.Create(retainedMessageMatch);
                    clientSession.EnqueueDataPacket(new MqttPacketBusItem(publishPacket));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="topicFilters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task UnsubscribeAsync(string clientId, ICollection<string> topicFilters)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            var fakeUnsubscribePacket = new MqttUnsubscribePacket();
            fakeUnsubscribePacket.TopicFilters.AddRange(topicFilters);

            return GetClientSession(clientId).Unsubscribe(fakeUnsubscribePacket, CancellationToken.None);
        }

        MqttServerClient CreateClient(MqttConnectPacket connectPacket, IMqttChannelAdapter channelAdapter, MqttSession session)
        {
            return new MqttServerClient(connectPacket, channelAdapter, session, _options, _eventContainer, this, _rootLogger);
        }

        async Task<MqttServerClient> CreateClientConnection(
            MqttConnectPacket connectPacket,
            MqttConnAckPacket connAckPacket,
            IMqttChannelAdapter channelAdapter,
            ValidatingConnectionEventArgs validatingConnectionEventArgs)
        {
            MqttServerClient client;

            bool sessionShouldPersist;

            if (validatingConnectionEventArgs.ProtocolVersion == MqttProtocolVersion.V500)
            {
                // MQTT 5.0 section 3.1.2.11.2
                // The Client and Server MUST store the Session State after the Network Connection is closed if the Session Expiry Interval is greater than 0 [MQTT-3.1.2-23].
                //
                // A Client that only wants to process messages while connected will set the Clean Start to 1 and set the Session Expiry Interval to 0.
                // It will not receive Application Messages published before it connected and has to subscribe afresh to any topics that it is interested
                // in each time it connects.

                // Persist if SessionExpiryInterval != 0, but may start with a clean session
                sessionShouldPersist = validatingConnectionEventArgs.SessionExpiryInterval != 0;
            }
            else
            {
                // MQTT 3.1.1 section 3.1.2.4: persist only if 'not CleanSession'
                //
                // If CleanSession is set to 1, the Client and Server MUST discard any previous Session and start a new one.
                // This Session lasts as long as the Network Connection. State data associated with this Session MUST NOT be
                // reused in any subsequent Session [MQTT-3.1.2-6].

                sessionShouldPersist = !connectPacket.CleanSession;
            }

            using (await _createConnectionSyncRoot.EnterAsync().ConfigureAwait(false))
            {
                MqttSession oldSession;
                MqttServerClient oldClient;

                lock (_sessionsManagementLock)
                {
                    MqttSession session;

                    // Create a new session (if required).
                    if (!_sessions.TryGetValue(connectPacket.ClientId, out oldSession))
                    {
                        session = CreateSession(connectPacket.ClientId, validatingConnectionEventArgs.SessionItems, sessionShouldPersist);
                    }
                    else
                    {
                        if (connectPacket.CleanSession)
                        {
                            _logger.Verbose("Deleting existing session of client '{0}' due to clean start.", connectPacket.ClientId);
                            _subscriberSessions.Remove(oldSession);
                            session = CreateSession(connectPacket.ClientId, validatingConnectionEventArgs.SessionItems, sessionShouldPersist);
                        }
                        else
                        {
                            _logger.Verbose("Reusing existing session of client '{0}'.", connectPacket.ClientId);
                            session = oldSession;
                            oldSession = null;

                            // Session persistence could change for MQTT 5 clients that reconnect with different SessionExpiryInterval
                            session.IsPersistent = sessionShouldPersist;
                            connAckPacket.IsSessionPresent = true;
                            session.Recover();
                        }
                    }

                    _sessions[connectPacket.ClientId] = session;

                    // Create a new client (always required).
                    _clients.TryGetValue(connectPacket.ClientId, out oldClient);
                    if (oldClient != null)
                    {
                        // This will stop the current client from sending and receiving but remains the connection active
                        // for a later DISCONNECT packet.
                        oldClient.IsTakenOver = true;
                    }

                    client = CreateClient(connectPacket, channelAdapter, session);

                    _clients[connectPacket.ClientId] = client;
                }

                if (!connAckPacket.IsSessionPresent)
                {
                    // TODO: This event is not yet final. It can already be used but restoring sessions from storage will be added later!
                    var preparingSessionEventArgs = new PreparingSessionEventArgs();
                    await _eventContainer.PreparingSessionEvent.TryInvokeAsync(preparingSessionEventArgs, _logger).ConfigureAwait(false);
                }

                if (oldClient != null)
                {
                    await oldClient.StopAsync(MqttDisconnectReasonCode.SessionTakenOver).ConfigureAwait(false);

                    if (_eventContainer.ClientDisconnectedEvent.HasHandlers)
                    {
                        var eventArgs = new ClientDisconnectedEventArgs(oldClient.Id, MqttClientDisconnectType.Takeover, oldClient.Endpoint, oldClient.Session.Items);

                        await _eventContainer.ClientDisconnectedEvent.TryInvokeAsync(eventArgs, _logger).ConfigureAwait(false);
                    }
                }

                oldSession?.Dispose();
            }

            return client;
        }

        MqttSession CreateSession(string clientId, IDictionary sessionItems, bool isPersistent)
        {
            _logger.Verbose("Created new session for client '{0}'.", clientId);

            return new MqttSession(clientId, isPersistent, sessionItems, _options, _eventContainer, _retainedMessagesManager, this);
        }

        async Task FireApplicationMessageNotConsumedEvent(MqttApplicationMessage applicationMessage, string senderId)
        {
            if (!_eventContainer.ApplicationMessageNotConsumedEvent.HasHandlers)
            {
                return;
            }

            var eventArgs = new ApplicationMessageNotConsumedEventArgs(applicationMessage, senderId);
            await _eventContainer.ApplicationMessageNotConsumedEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
        }

        MqttSession GetClientSession(string clientId)
        {
            lock (_sessionsManagementLock)
            {
                if (!_sessions.TryGetValue(clientId, out var session))
                {
                    throw new InvalidOperationException($"Client session '{clientId}' is unknown.");
                }

                return session;
            }
        }

        async Task<MqttConnectPacket> ReceiveConnectPacket(IMqttChannelAdapter channelAdapter, CancellationToken cancellationToken)
        {
            try
            {
#if NET40
                using (var timeoutToken = new CancellationTokenSource())
                {
                    timeoutToken.CancelAfter(_options.DefaultCommunicationTimeout);
#else
                using (var timeoutToken = new CancellationTokenSource(_options.DefaultCommunicationTimeout))
                {
#endif
                    using (var effectiveCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(timeoutToken.Token, cancellationToken))
                    {
                        var firstPacket = await channelAdapter.ReceivePacketAsync(effectiveCancellationToken.Token).ConfigureAwait(false);
                        if (firstPacket is MqttConnectPacket connectPacket)
                        {
                            return connectPacket;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.Warning("Client '{0}': Connected but did not sent a CONNECT packet.", channelAdapter.Endpoint);
            }
            catch (MqttCommunicationTimedOutException)
            {
                _logger.Warning("Client '{0}': Connected but did not sent a CONNECT packet.", channelAdapter.Endpoint);
            }

            _logger.Warning("Client '{0}': First received packet was no 'CONNECT' packet [MQTT-3.1.0-1].", channelAdapter.Endpoint);
            return null;
        }

        async Task<ValidatingConnectionEventArgs> ValidateConnection(MqttConnectPacket connectPacket, IMqttChannelAdapter channelAdapter)
        {
            var eventArgs = new ValidatingConnectionEventArgs(connectPacket, channelAdapter)
            {
                SessionItems = new ConcurrentDictionary<object, object>()
            };

            await _eventContainer.ValidatingConnectionEvent.InvokeAsync(eventArgs).ConfigureAwait(false);

            // Check the client ID and set a random one if supported.
            if (string.IsNullOrEmpty(connectPacket.ClientId) && channelAdapter.PacketFormatterAdapter.ProtocolVersion == MqttProtocolVersion.V500)
            {
                connectPacket.ClientId = eventArgs.AssignedClientIdentifier;
            }

            if (string.IsNullOrEmpty(connectPacket.ClientId))
            {
                eventArgs.ReasonCode = MqttConnectReasonCode.ClientIdentifierNotValid;
            }

            return eventArgs;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientStatistics
    {
        long _receivedApplicationMessagesCount;

        // Start with 1 because the CONNACK packet is not counted here.
        long _receivedPacketsCount = 1;
        long _sentApplicationMessagesCount;

        // Start with 1 because the CONNECT packet is not counted here.
        long _sentPacketsCount = 1;
        /// <summary>
        /// 
        /// </summary>
        public MqttClientStatistics()
        {
            ConnectedTimestamp = DateTime.UtcNow;

            LastPacketReceivedTimestamp = ConnectedTimestamp;
            LastPacketSentTimestamp = ConnectedTimestamp;

            LastNonKeepAlivePacketReceivedTimestamp = ConnectedTimestamp;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ConnectedTimestamp { get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastNonKeepAlivePacketReceivedTimestamp { get; private set; }

        /// <summary>
        ///     Timestamp of the last package that has been sent to the client ("received" from the client's perspective)
        /// </summary>
        public DateTime LastPacketReceivedTimestamp { get; private set; }

        /// <summary>
        ///     Timestamp of the last package that has been received from the client ("sent" from the client's perspective)
        /// </summary>
        public DateTime LastPacketSentTimestamp { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public long ReceivedApplicationMessagesCount => Interlocked.Read(ref _receivedApplicationMessagesCount);
        /// <summary>
        /// 
        /// </summary>
        public long ReceivedPacketsCount => Interlocked.Read(ref _receivedPacketsCount);
        /// <summary>
        /// 
        /// </summary>
        public long SentApplicationMessagesCount => Interlocked.Read(ref _sentApplicationMessagesCount);
        /// <summary>
        /// 
        /// </summary>
        public long SentPacketsCount => Interlocked.Read(ref _sentPacketsCount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void HandleReceivedPacket(MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            // This class is tracking all values from Clients perspective!
            LastPacketSentTimestamp = DateTime.UtcNow;

            Interlocked.Increment(ref _sentPacketsCount);

            if (packet is MqttPublishPacket)
            {
                Interlocked.Increment(ref _sentApplicationMessagesCount);
            }

            if (!(packet is MqttPingReqPacket || packet is MqttPingRespPacket))
            {
                LastNonKeepAlivePacketReceivedTimestamp = LastPacketReceivedTimestamp;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void HandleSentPacket(MqttPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            // This class is tracking all values from Clients perspective!
            LastPacketReceivedTimestamp = DateTime.UtcNow;

            Interlocked.Increment(ref _receivedPacketsCount);

            if (packet is MqttPublishPacket)
            {
                Interlocked.Increment(ref _receivedApplicationMessagesCount);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResetStatistics()
        {
            Interlocked.Exchange(ref _sentApplicationMessagesCount, 0);
            Interlocked.Exchange(ref _receivedApplicationMessagesCount, 0);
            Interlocked.Exchange(ref _sentPacketsCount, 0);
            Interlocked.Exchange(ref _receivedPacketsCount, 0);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientSubscriptionsManager : IDisposable
    {
        static readonly List<uint> EmptySubscriptionIdentifiers = new List<uint>();

        readonly MqttServerEventContainer _eventContainer;
        readonly Dictionary<ulong, HashSet<MqttSubscription>> _noWildcardSubscriptionsByTopicHash = new Dictionary<ulong, HashSet<MqttSubscription>>();
        readonly MqttRetainedMessagesManager _retainedMessagesManager;

        readonly MqttSession _session;

        // Callback to maintain list of subscriber clients
        readonly ISubscriptionChangedNotification _subscriptionChangedNotification;

        // Subscriptions are stored in various dictionaries and use a "topic hash"; see the MqttSubscription object for a detailed explanation.
        // The additional lock is important to coordinate complex update logic with multiple steps, checks and interceptors.
        readonly Dictionary<string, MqttSubscription> _subscriptions = new Dictionary<string, MqttSubscription>();

        // Use subscription lock to maintain consistency across subscriptions and topic hash dictionaries
        readonly AsyncLock _subscriptionsLock = new AsyncLock();
        readonly Dictionary<ulong, TopicHashMaskSubscriptions> _wildcardSubscriptionsByTopicHash = new Dictionary<ulong, TopicHashMaskSubscriptions>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventContainer"></param>
        /// <param name="retainedMessagesManager"></param>
        /// <param name="subscriptionChangedNotification"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientSubscriptionsManager(
            MqttSession session,
            MqttServerEventContainer eventContainer,
            MqttRetainedMessagesManager retainedMessagesManager,
            ISubscriptionChangedNotification subscriptionChangedNotification)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _eventContainer = eventContainer ?? throw new ArgumentNullException(nameof(eventContainer));
            _retainedMessagesManager = retainedMessagesManager ?? throw new ArgumentNullException(nameof(retainedMessagesManager));
            _subscriptionChangedNotification = subscriptionChangedNotification;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="topicHash"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="senderId"></param>
        /// <returns></returns>
        public CheckSubscriptionsResult CheckSubscriptions(string topic, ulong topicHash, MqttQualityOfServiceLevel qualityOfServiceLevel, string senderId)
        {
            var possibleSubscriptions = new List<MqttSubscription>();

            // Check for possible subscriptions. They might have collisions but this is fine.
            using (_subscriptionsLock.EnterAsync(CancellationToken.None).GetAwaiter().GetResult())
            {
                if (_noWildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var noWildcardSubscriptions))
                {
                    possibleSubscriptions.AddRange(noWildcardSubscriptions);
                }

                foreach (var wcs in _wildcardSubscriptionsByTopicHash)
                {
                    var subscriptionHash = wcs.Key;
                    var subscriptionsByHashMask = wcs.Value.SubscriptionsByHashMask;
                    foreach (var shm in subscriptionsByHashMask)
                    {
                        var subscriptionHashMask = shm.Key;
                        if ((topicHash & subscriptionHashMask) == subscriptionHash)
                        {
                            var subscriptions = shm.Value;
                            possibleSubscriptions.AddRange(subscriptions);
                        }
                    }
                }
            }

            // The pre check has evaluated that nothing is subscribed.
            // If there were some possible candidates they get checked below
            // again to avoid collisions.
            if (possibleSubscriptions.Count == 0)
            {
                return CheckSubscriptionsResult.NotSubscribed;
            }

            var senderIsReceiver = string.Equals(senderId, _session.Id);
            var maxQoSLevel = -1; // Not subscribed.

            HashSet<uint> subscriptionIdentifiers = null;
            var retainAsPublished = false;

            foreach (var subscription in possibleSubscriptions)
            {
                if (subscription.NoLocal && senderIsReceiver)
                {
                    // This is a MQTTv5 feature!
                    continue;
                }

                if (MqttTopicFilterComparer.Compare(topic, subscription.Topic) != MqttTopicFilterCompareResult.IsMatch)
                {
                    continue;
                }

                if (subscription.RetainAsPublished)
                {
                    // This is a MQTTv5 feature!
                    retainAsPublished = true;
                }

                if ((int)subscription.GrantedQualityOfServiceLevel > maxQoSLevel)
                {
                    maxQoSLevel = (int)subscription.GrantedQualityOfServiceLevel;
                }

                if (subscription.Identifier > 0)
                {
                    if (subscriptionIdentifiers == null)
                    {
                        subscriptionIdentifiers = new HashSet<uint>();
                    }

                    subscriptionIdentifiers.Add(subscription.Identifier);
                }
            }

            if (maxQoSLevel == -1)
            {
                return CheckSubscriptionsResult.NotSubscribed;
            }

            var result = new CheckSubscriptionsResult
            {
                IsSubscribed = true,
                RetainAsPublished = retainAsPublished,
                SubscriptionIdentifiers = subscriptionIdentifiers?.ToList() ?? EmptySubscriptionIdentifiers,

                // Start with the same QoS as the publisher.
                QualityOfServiceLevel = qualityOfServiceLevel
            };

            // Now downgrade if required.
            //
            // If a subscribing Client has been granted maximum QoS 1 for a particular Topic Filter, then a QoS 0 Application Message matching the filter is delivered
            // to the Client at QoS 0. This means that at most one copy of the message is received by the Client. On the other hand, a QoS 2 Message published to
            // the same topic is downgraded by the Server to QoS 1 for delivery to the Client, so that Client might receive duplicate copies of the Message.

            // Subscribing to a Topic Filter at QoS 2 is equivalent to saying "I would like to receive Messages matching this filter at the QoS with which they were published".
            // This means a publisher is responsible for determining the maximum QoS a Message can be delivered at, but a subscriber is able to require that the Server
            // downgrades the QoS to one more suitable for its usage.
            if (maxQoSLevel < (int)qualityOfServiceLevel)
            {
                result.QualityOfServiceLevel = (MqttQualityOfServiceLevel)maxQoSLevel;
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _subscriptionsLock.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribePacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SubscribeResult> Subscribe(MqttSubscribePacket subscribePacket, CancellationToken cancellationToken)
        {
            if (subscribePacket == null)
            {
                throw new ArgumentNullException(nameof(subscribePacket));
            }

            var retainedApplicationMessages = await _retainedMessagesManager.GetMessages().ConfigureAwait(false);
            var result = new SubscribeResult(subscribePacket.TopicFilters.Count);

            var addedSubscriptions = new List<string>();
            var finalTopicFilters = new List<MqttTopicFilter>();

            // The topic filters are order by its QoS so that the higher QoS will win over a
            // lower one.
            foreach (var topicFilterItem in subscribePacket.TopicFilters.OrderByDescending(f => f.QualityOfServiceLevel))
            {
                var subscriptionEventArgs = await InterceptSubscribe(topicFilterItem, cancellationToken).ConfigureAwait(false);
                var topicFilter = subscriptionEventArgs.TopicFilter;
                var processSubscription = subscriptionEventArgs.ProcessSubscription && subscriptionEventArgs.Response.ReasonCode <= MqttSubscribeReasonCode.GrantedQoS2;

                result.UserProperties = subscriptionEventArgs.UserProperties;
                result.ReasonString = subscriptionEventArgs.ReasonString;
                result.ReasonCodes.Add(subscriptionEventArgs.Response.ReasonCode);

                if (subscriptionEventArgs.CloseConnection)
                {
                    // When any of the interceptor calls leads to a connection close the connection
                    // must be closed. So do not revert to false!
                    result.CloseConnection = true;
                }

                if (!processSubscription || string.IsNullOrEmpty(topicFilter.Topic))
                {
                    continue;
                }

                var createSubscriptionResult = CreateSubscription(topicFilter, subscribePacket.SubscriptionIdentifier, subscriptionEventArgs.Response.ReasonCode);

                addedSubscriptions.Add(topicFilter.Topic);
                finalTopicFilters.Add(topicFilter);

                FilterRetainedApplicationMessages(retainedApplicationMessages, createSubscriptionResult, result);
            }

            // This call will add the new subscription to the internal storage.
            // So the event _ClientSubscribedTopicEvent_ must be called afterwards.
            _subscriptionChangedNotification?.OnSubscriptionsAdded(_session, addedSubscriptions);

            if (_eventContainer.ClientSubscribedTopicEvent.HasHandlers)
            {
                foreach (var finalTopicFilter in finalTopicFilters)
                {
                    var eventArgs = new ClientSubscribedTopicEventArgs(_session.Id, finalTopicFilter, _session.Items);
                    await _eventContainer.ClientSubscribedTopicEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unsubscribePacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<UnsubscribeResult> Unsubscribe(MqttUnsubscribePacket unsubscribePacket, CancellationToken cancellationToken)
        {
            if (unsubscribePacket == null)
            {
                throw new ArgumentNullException(nameof(unsubscribePacket));
            }

            var result = new UnsubscribeResult();

            var removedSubscriptions = new List<string>();

            using (await _subscriptionsLock.EnterAsync(cancellationToken).ConfigureAwait(false))
            {
                foreach (var topicFilter in unsubscribePacket.TopicFilters)
                {
                    _subscriptions.TryGetValue(topicFilter, out var existingSubscription);

                    var interceptorContext = await InterceptUnsubscribe(topicFilter, existingSubscription, cancellationToken).ConfigureAwait(false);
                    var acceptUnsubscription = interceptorContext.Response.ReasonCode == MqttUnsubscribeReasonCode.Success;

                    result.ReasonCodes.Add(interceptorContext.Response.ReasonCode);

                    if (interceptorContext.CloseConnection)
                    {
                        // When any of the interceptor calls leads to a connection close the connection
                        // must be closed. So do not revert to false!
                        result.CloseConnection = true;
                    }

                    if (!acceptUnsubscription)
                    {
                        continue;
                    }

                    if (interceptorContext.ProcessUnsubscription)
                    {
                        _subscriptions.Remove(topicFilter);

                        // must remove subscription object from topic hash dictionary also
                        if (existingSubscription != null)
                        {
                            var topicHash = existingSubscription.TopicHash;

                            if (existingSubscription.TopicHasWildcard)
                            {
                                if (_wildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                                {
                                    subscriptions.RemoveSubscription(existingSubscription);
                                    if (subscriptions.SubscriptionsByHashMask.Count == 0)
                                    {
                                        _wildcardSubscriptionsByTopicHash.Remove(topicHash);
                                    }
                                }
                            }
                            else
                            {
                                if (_noWildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                                {
                                    subscriptions.Remove(existingSubscription);
                                    if (subscriptions.Count == 0)
                                    {
                                        _noWildcardSubscriptionsByTopicHash.Remove(topicHash);
                                    }
                                }
                            }
                        }

                        removedSubscriptions.Add(topicFilter);
                    }
                }
            }

            _subscriptionChangedNotification?.OnSubscriptionsRemoved(_session, removedSubscriptions);

            if (_eventContainer.ClientUnsubscribedTopicEvent.HasHandlers)
            {
                foreach (var topicFilter in unsubscribePacket.TopicFilters)
                {
                    var eventArgs = new ClientUnsubscribedTopicEventArgs(_session.Id, topicFilter, _session.Items);
                    await _eventContainer.ClientUnsubscribedTopicEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
                }
            }

            return result;
        }

        CreateSubscriptionResult CreateSubscription(MqttTopicFilter topicFilter, uint subscriptionIdentifier, MqttSubscribeReasonCode reasonCode)
        {
            MqttQualityOfServiceLevel grantedQualityOfServiceLevel;

            if (reasonCode == MqttSubscribeReasonCode.GrantedQoS0)
            {
                grantedQualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce;
            }
            else if (reasonCode == MqttSubscribeReasonCode.GrantedQoS1)
            {
                grantedQualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce;
            }
            else if (reasonCode == MqttSubscribeReasonCode.GrantedQoS2)
            {
                grantedQualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce;
            }
            else
            {
                throw new InvalidOperationException();
            }

            var subscription = new MqttSubscription(
                topicFilter.Topic,
                topicFilter.NoLocal,
                topicFilter.RetainHandling,
                topicFilter.RetainAsPublished,
                grantedQualityOfServiceLevel,
                subscriptionIdentifier);

            bool isNewSubscription;

            // Add to subscriptions and maintain topic hash dictionaries

            using (_subscriptionsLock.EnterAsync(CancellationToken.None).GetAwaiter().GetResult())
            {
                MqttSubscription.CalculateTopicHash(topicFilter.Topic, out var topicHash, out var topicHashMask, out var hasWildcard);

                if (_subscriptions.TryGetValue(topicFilter.Topic, out var existingSubscription))
                {
                    // must remove object from topic hash dictionary first
                    if (hasWildcard)
                    {
                        if (_wildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                        {
                            subscriptions.RemoveSubscription(existingSubscription);
                            // no need to remove empty entry because we'll be adding subscription again below
                        }
                    }
                    else
                    {
                        if (_noWildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                        {
                            subscriptions.Remove(existingSubscription);
                            // no need to remove empty entry because we'll be adding subscription again below
                        }
                    }
                }

                isNewSubscription = existingSubscription == null;
                _subscriptions[topicFilter.Topic] = subscription;

                // Add or re-add to topic hash dictionary
                if (hasWildcard)
                {
                    if (!_wildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                    {
                        subscriptions = new TopicHashMaskSubscriptions();
                        _wildcardSubscriptionsByTopicHash.Add(topicHash, subscriptions);
                    }

                    subscriptions.AddSubscription(subscription);
                }
                else
                {
                    if (!_noWildcardSubscriptionsByTopicHash.TryGetValue(topicHash, out var subscriptions))
                    {
                        subscriptions = new HashSet<MqttSubscription>();
                        _noWildcardSubscriptionsByTopicHash.Add(topicHash, subscriptions);
                    }

                    subscriptions.Add(subscription);
                }
            }

            return new CreateSubscriptionResult
            {
                IsNewSubscription = isNewSubscription,
                Subscription = subscription
            };
        }

        static void FilterRetainedApplicationMessages(
            IList<MqttApplicationMessage> retainedMessages,
            CreateSubscriptionResult createSubscriptionResult,
            SubscribeResult subscribeResult)
        {
            for (var index = retainedMessages.Count - 1; index >= 0; index--)
            {
                var retainedMessage = retainedMessages[index];
                if (retainedMessage == null)
                {
                    continue;
                }

                if (createSubscriptionResult.Subscription.RetainHandling == MqttRetainHandling.DoNotSendOnSubscribe)
                {
                    // This is a MQTT V5+ feature.
                    continue;
                }

                if (createSubscriptionResult.Subscription.RetainHandling == MqttRetainHandling.SendAtSubscribeIfNewSubscriptionOnly && !createSubscriptionResult.IsNewSubscription)
                {
                    // This is a MQTT V5+ feature.
                    continue;
                }

                if (MqttTopicFilterComparer.Compare(retainedMessage.Topic, createSubscriptionResult.Subscription.Topic) != MqttTopicFilterCompareResult.IsMatch)
                {
                    continue;
                }

                var retainedMessageMatch = new MqttRetainedMessageMatch(retainedMessage, createSubscriptionResult.Subscription.GrantedQualityOfServiceLevel);
                if (retainedMessageMatch.SubscriptionQualityOfServiceLevel > retainedMessageMatch.ApplicationMessage.QualityOfServiceLevel)
                {
                    // UPGRADING the QoS is not allowed! 
                    // From MQTT spec: Subscribing to a Topic Filter at QoS 2 is equivalent to saying
                    // "I would like to receive Messages matching this filter at the QoS with which they were published".
                    // This means a publisher is responsible for determining the maximum QoS a Message can be delivered at,
                    // but a subscriber is able to require that the Server downgrades the QoS to one more suitable for its usage.
                    retainedMessageMatch.SubscriptionQualityOfServiceLevel = retainedMessageMatch.ApplicationMessage.QualityOfServiceLevel;
                }

                if (subscribeResult.RetainedMessages == null)
                {
                    subscribeResult.RetainedMessages = new List<MqttRetainedMessageMatch>();
                }

                subscribeResult.RetainedMessages.Add(retainedMessageMatch);

                // Clear the retained message from the list because the client should receive every message only 
                // one time even if multiple subscriptions affect them.
                retainedMessages[index] = null;
            }
        }

        async Task<InterceptingSubscriptionEventArgs> InterceptSubscribe(MqttTopicFilter topicFilter, CancellationToken cancellationToken)
        {
            var eventArgs = new InterceptingSubscriptionEventArgs(cancellationToken, _session.Id, new MqttSessionStatus(_session), topicFilter);

            if (topicFilter.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtMostOnce)
            {
                eventArgs.Response.ReasonCode = MqttSubscribeReasonCode.GrantedQoS0;
            }
            else if (topicFilter.QualityOfServiceLevel == MqttQualityOfServiceLevel.AtLeastOnce)
            {
                eventArgs.Response.ReasonCode = MqttSubscribeReasonCode.GrantedQoS1;
            }
            else if (topicFilter.QualityOfServiceLevel == MqttQualityOfServiceLevel.ExactlyOnce)
            {
                eventArgs.Response.ReasonCode = MqttSubscribeReasonCode.GrantedQoS2;
            }

            if (topicFilter.Topic.StartsWith("$share/"))
            {
                eventArgs.Response.ReasonCode = MqttSubscribeReasonCode.SharedSubscriptionsNotSupported;
            }
            else
            {
                await _eventContainer.InterceptingSubscriptionEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
            }

            return eventArgs;
        }

        async Task<InterceptingUnsubscriptionEventArgs> InterceptUnsubscribe(string topicFilter, MqttSubscription mqttSubscription, CancellationToken cancellationToken)
        {
            var clientUnsubscribingTopicEventArgs = new InterceptingUnsubscriptionEventArgs(cancellationToken, topicFilter, _session.Items, topicFilter)
            {
                Response =
                {
                    ReasonCode = mqttSubscription == null ? MqttUnsubscribeReasonCode.NoSubscriptionExisted : MqttUnsubscribeReasonCode.Success
                }
            };

            await _eventContainer.InterceptingUnsubscriptionEvent.InvokeAsync(clientUnsubscribingTopicEventArgs).ConfigureAwait(false);

            return clientUnsubscribingTopicEventArgs;
        }

        sealed class CreateSubscriptionResult
        {
            public bool IsNewSubscription { get; set; }

            public MqttSubscription Subscription { get; set; }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttRetainedMessagesManager
    {
        readonly Dictionary<string, MqttApplicationMessage> _messages = new Dictionary<string, MqttApplicationMessage>(4096);
        readonly AsyncLock _storageAccessLock = new AsyncLock();

        readonly MqttServerEventContainer _eventContainer;
        readonly MqttNetSourceLogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventContainer"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttRetainedMessagesManager(MqttServerEventContainer eventContainer, IMqttNetLogger logger)
        {
            _eventContainer = eventContainer ?? throw new ArgumentNullException(nameof(eventContainer));

            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger.WithSource(nameof(MqttRetainedMessagesManager));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            try
            {
                var eventArgs = new LoadingRetainedMessagesEventArgs();
                await _eventContainer.LoadingRetainedMessagesEvent.InvokeAsync(eventArgs).ConfigureAwait(false);

                lock (_messages)
                {
                    _messages.Clear();

                    if (eventArgs.LoadedRetainedMessages != null)
                    {
                        foreach (var retainedMessage in eventArgs.LoadedRetainedMessages)
                        {
                            _messages[retainedMessage.Topic] = retainedMessage;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Unhandled exception while loading retained messages.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="applicationMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task UpdateMessage(string clientId, MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null)
            {
                throw new ArgumentNullException(nameof(applicationMessage));
            }

            try
            {
                List<MqttApplicationMessage> messagesForSave = null;
                var saveIsRequired = false;

                lock (_messages)
                {
                    var hasPayload = applicationMessage.Payload != null && applicationMessage.Payload.Length > 0;

                    if (!hasPayload)
                    {
                        saveIsRequired = _messages.Remove(applicationMessage.Topic);
                        _logger.Verbose("Client '{0}' cleared retained message for topic '{1}'.", clientId, applicationMessage.Topic);
                    }
                    else
                    {
                        if (!_messages.TryGetValue(applicationMessage.Topic, out var existingMessage))
                        {
                            _messages[applicationMessage.Topic] = applicationMessage;
                            saveIsRequired = true;
                        }
                        else
                        {
                            if (existingMessage.QualityOfServiceLevel != applicationMessage.QualityOfServiceLevel || !existingMessage.Payload.SequenceEqual(applicationMessage.Payload ?? EmptyBuffer.Array))
                            {
                                _messages[applicationMessage.Topic] = applicationMessage;
                                saveIsRequired = true;
                            }
                        }

                        _logger.Verbose("Client '{0}' set retained message for topic '{1}'.", clientId, applicationMessage.Topic);
                    }

                    if (saveIsRequired)
                    {
                        messagesForSave = new List<MqttApplicationMessage>(_messages.Values);
                    }
                }

                if (saveIsRequired)
                {
                    using (await _storageAccessLock.EnterAsync().ConfigureAwait(false))
                    {
                        var eventArgs = new RetainedMessageChangedEventArgs(clientId, applicationMessage, messagesForSave);
                        await _eventContainer.RetainedMessageChangedEvent.InvokeAsync(eventArgs).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Unhandled exception while handling retained messages.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IList<MqttApplicationMessage>> GetMessages()
        {
            lock (_messages)
            {
                var result = new List<MqttApplicationMessage>(_messages.Values);
                return TestTry.TaskFromResult((IList<MqttApplicationMessage>)result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ClearMessages()
        {
            lock (_messages)
            {
                _messages.Clear();
            }

            using (await _storageAccessLock.EnterAsync().ConfigureAwait(false))
            {
                await _eventContainer.RetainedMessagesClearedEvent.InvokeAsync(EventArgs.Empty).ConfigureAwait(false);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttServerEventContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ApplicationMessageNotConsumedEventArgs> ApplicationMessageNotConsumedEvent { get; } = new AsyncEvent<ApplicationMessageNotConsumedEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ClientAcknowledgedPublishPacketEventArgs> ClientAcknowledgedPublishPacketEvent { get; } = new AsyncEvent<ClientAcknowledgedPublishPacketEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ClientConnectedEventArgs> ClientConnectedEvent { get; } = new AsyncEvent<ClientConnectedEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ClientDisconnectedEventArgs> ClientDisconnectedEvent { get; } = new AsyncEvent<ClientDisconnectedEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ClientSubscribedTopicEventArgs> ClientSubscribedTopicEvent { get; } = new AsyncEvent<ClientSubscribedTopicEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ClientUnsubscribedTopicEventArgs> ClientUnsubscribedTopicEvent { get; } = new AsyncEvent<ClientUnsubscribedTopicEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<InterceptingPacketEventArgs> InterceptingInboundPacketEvent { get; } = new AsyncEvent<InterceptingPacketEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<InterceptingPacketEventArgs> InterceptingOutboundPacketEvent { get; } = new AsyncEvent<InterceptingPacketEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<InterceptingPublishEventArgs> InterceptingPublishEvent { get; } = new AsyncEvent<InterceptingPublishEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<InterceptingSubscriptionEventArgs> InterceptingSubscriptionEvent { get; } = new AsyncEvent<InterceptingSubscriptionEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<InterceptingUnsubscriptionEventArgs> InterceptingUnsubscriptionEvent { get; } = new AsyncEvent<InterceptingUnsubscriptionEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<LoadingRetainedMessagesEventArgs> LoadingRetainedMessagesEvent { get; } = new AsyncEvent<LoadingRetainedMessagesEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<EventArgs> PreparingSessionEvent { get; } = new AsyncEvent<EventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<RetainedMessageChangedEventArgs> RetainedMessageChangedEvent { get; } = new AsyncEvent<RetainedMessageChangedEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<EventArgs> RetainedMessagesClearedEvent { get; } = new AsyncEvent<EventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<SessionDeletedEventArgs> SessionDeletedEvent { get; } = new AsyncEvent<SessionDeletedEventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<EventArgs> StartedEvent { get; } = new AsyncEvent<EventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<EventArgs> StoppedEvent { get; } = new AsyncEvent<EventArgs>();
        /// <summary>
        /// 
        /// </summary>
        public AsyncEvent<ValidatingConnectionEventArgs> ValidatingConnectionEvent { get; } = new AsyncEvent<ValidatingConnectionEventArgs>();
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttServerKeepAliveMonitor
    {
        readonly MqttNetSourceLogger _logger;
        readonly MqttServerOptions _options;
        readonly MqttClientSessionsManager _sessionsManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="sessionsManager"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServerKeepAliveMonitor(MqttServerOptions options, MqttClientSessionsManager sessionsManager, IMqttNetLogger logger)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _sessionsManager = sessionsManager ?? throw new ArgumentNullException(nameof(sessionsManager));

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger.WithSource(nameof(MqttServerKeepAliveMonitor));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        public void Start(CancellationToken cancellationToken)
        {
            // The keep alive monitor spawns a real new thread (LongRunning) because it does not 
            // support async/await. Async etc. is avoided here because the thread will usually check
            // the connections every few milliseconds and thus the context changes (due to async) are 
            // only consuming resources. Also there is just 1 thread for the entire server which is fine at all!
            Task.Factory.StartNew(_ => DoWork(cancellationToken), cancellationToken, TaskCreationOptions.LongRunning).RunInBackground(_logger);
        }

        void DoWork(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Info("Starting keep alive monitor.");

                while (!cancellationToken.IsCancellationRequested)
                {
                    TryProcessClients();
                    Sleep(_options.KeepAliveMonitorInterval);
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Unhandled exception while checking keep alive timeouts.");
            }
            finally
            {
                _logger.Verbose("Stopped checking keep alive timeout.");
            }
        }

        static void Sleep(TimeSpan timeout)
        {
#if !NETSTANDARD1_3 && !WINDOWS_UWP
            try
            {
                Thread.Sleep(timeout);
            }
            catch (ThreadAbortException)
            {
                // The ThreadAbortException is not actively catched in this project.
                // So we use a one which is similar and will be catched properly.
                throw new OperationCanceledException();
            }
#else
            Task.Delay(timeout).Wait();
#endif
        }

        void TryProcessClient(MqttServerClient connection, DateTime now)
        {
            try
            {
                if (!connection.IsRunning)
                {
                    // The connection is already dead or just created so there is no need to check it.
                    return;
                }

                if (connection.KeepAlivePeriod == 0)
                {
                    // The keep alive feature is not used by the current connection.
                    return;
                }

                if (connection.ChannelAdapter.IsReadingPacket)
                {
                    // The connection is currently reading a (large) packet. So it is obviously 
                    // doing something and thus "connected".
                    return;
                }

                // Values described here: [MQTT-3.1.2-24].
                // If the client sends 5 sec. the server will allow up to 7.5 seconds.
                // If the client sends 1 sec. the server will allow up to 1.5 seconds.
                var maxSecondsWithoutPacket = connection.KeepAlivePeriod * 1.5D;

                var secondsWithoutPackage = (now - connection.Statistics.LastPacketSentTimestamp).TotalSeconds;
                if (secondsWithoutPackage < maxSecondsWithoutPacket)
                {
                    // A packet was received before the timeout is affected.
                    return;
                }

                _logger.Warning("Client '{0}': Did not receive any packet or keep alive signal.", connection.Id);

                // Execute the disconnection in background so that the keep alive monitor can continue
                // with checking other connections.
                // We do not need to wait for the task so no await is needed.
                // Also the internal state of the connection must be swapped to "Finalizing" because the
                // next iteration of the keep alive timer happens.
                var _ = connection.StopAsync(MqttDisconnectReasonCode.KeepAliveTimeout);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Client {0}: Unhandled exception while checking keep alive timeouts.", connection.Id);
            }
        }

        void TryProcessClients()
        {
            var now = DateTime.UtcNow;
            foreach (var client in _sessionsManager.GetClients())
            {
                TryProcessClient(client, now);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSession : IDisposable
    {
        readonly MqttClientSessionsManager _clientSessionsManager;
        readonly MqttPacketBus _packetBus = new MqttPacketBus();
        readonly MqttPacketIdentifierProvider _packetIdentifierProvider = new MqttPacketIdentifierProvider();

        readonly MqttServerOptions _serverOptions;
        readonly MqttClientSubscriptionsManager _subscriptionsManager;

        // Do not use a dictionary in order to keep the ordering of the messages.
        readonly List<MqttPublishPacket> _unacknowledgedPublishPackets = new List<MqttPublishPacket>();

        // Bookkeeping to know if this is a subscribing client; lazy initialize later.
        HashSet<string> _subscribedTopics;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="isPersistent"></param>
        /// <param name="items"></param>
        /// <param name="serverOptions"></param>
        /// <param name="eventContainer"></param>
        /// <param name="retainedMessagesManager"></param>
        /// <param name="clientSessionsManager"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttSession(
            string clientId,
            bool isPersistent,
            IDictionary items,
            MqttServerOptions serverOptions,
            MqttServerEventContainer eventContainer,
            MqttRetainedMessagesManager retainedMessagesManager,
            MqttClientSessionsManager clientSessionsManager)
        {
            Id = clientId ?? throw new ArgumentNullException(nameof(clientId));
            IsPersistent = isPersistent;
            Items = items ?? throw new ArgumentNullException(nameof(items));

            _serverOptions = serverOptions ?? throw new ArgumentNullException(nameof(serverOptions));
            _clientSessionsManager = clientSessionsManager ?? throw new ArgumentNullException(nameof(clientSessionsManager));

            _subscriptionsManager = new MqttClientSubscriptionsManager(this, eventContainer, retainedMessagesManager, clientSessionsManager);
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedTimestamp { get; } = DateTime.UtcNow;
        /// <summary>
        /// 
        /// </summary>
        public bool HasSubscribedTopics => _subscribedTopics != null && _subscribedTopics.Count > 0;
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; }

        /// <summary>
        ///     Session should persist if CleanSession was set to false (Mqtt3) or if SessionExpiryInterval != 0 (Mqtt5)
        /// </summary>
        public bool IsPersistent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IDictionary Items { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttConnectPacket LatestConnectPacket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MqttPacketIdentifierProvider PacketIdentifierProvider { get; } = new MqttPacketIdentifierProvider();
        /// <summary>
        /// 
        /// </summary>
        public long PendingDataPacketsCount => _packetBus.PartitionItemsCount(MqttPacketBusPartition.Data);
        /// <summary>
        /// 
        /// </summary>
        public bool WillMessageSent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetIdentifier"></param>
        /// <returns></returns>
        public MqttPublishPacket AcknowledgePublishPacket(ushort packetIdentifier)
        {
            MqttPublishPacket publishPacket;

            lock (_unacknowledgedPublishPackets)
            {
                publishPacket = _unacknowledgedPublishPackets.FirstOrDefault(p => p.PacketIdentifier.Equals(packetIdentifier));
                _unacknowledgedPublishPackets.Remove(publishPacket);
            }

            return publishPacket;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        public void AddSubscribedTopic(string topic)
        {
            if (_subscribedTopics == null)
            {
                _subscribedTopics = new HashSet<string>();
            }

            _subscribedTopics.Add(topic);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task DeleteAsync()
        {
            return _clientSessionsManager.DeleteSessionAsync(Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<MqttPacketBusItem> DequeuePacketAsync(CancellationToken cancellationToken)
        {
            return _packetBus.DequeueItemAsync(cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _packetBus.Dispose();
            _subscriptionsManager.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBusItem"></param>
        public void EnqueueControlPacket(MqttPacketBusItem packetBusItem)
        {
            _packetBus.EnqueueItem(packetBusItem, MqttPacketBusPartition.Control);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBusItem"></param>
        public void EnqueueDataPacket(MqttPacketBusItem packetBusItem)
        {
            if (_packetBus.ItemsCount(MqttPacketBusPartition.Data) >= _serverOptions.MaxPendingMessagesPerClient)
            {
                if (_serverOptions.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropNewMessage)
                {
                    return;
                }

                if (_serverOptions.PendingMessagesOverflowStrategy == MqttPendingMessagesOverflowStrategy.DropOldestQueuedMessage)
                {
                    // Only drop from the data partition. Dropping from control partition might break the connection
                    // because the client does not receive PINGREQ packets etc. any longer.
                    _packetBus.DropFirstItem(MqttPacketBusPartition.Data);
                }
            }

            var publishPacket = (MqttPublishPacket)packetBusItem.Packet;

            if (publishPacket.QualityOfServiceLevel > MqttQualityOfServiceLevel.AtMostOnce)
            {
                publishPacket.PacketIdentifier = _packetIdentifierProvider.GetNextPacketIdentifier();

                lock (_unacknowledgedPublishPackets)
                {
                    _unacknowledgedPublishPackets.Add(publishPacket);
                }
            }

            _packetBus.EnqueueItem(packetBusItem, MqttPacketBusPartition.Data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetBusItem"></param>
        public void EnqueueHealthPacket(MqttPacketBusItem packetBusItem)
        {
            _packetBus.EnqueueItem(packetBusItem, MqttPacketBusPartition.Health);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="packetIdentifier"></param>
        /// <returns></returns>
        public MqttPublishPacket PeekAcknowledgePublishPacket(ushort packetIdentifier)
        {
            // This will only return the matching PUBLISH packet but does not remove it.
            // This is required for QoS 2.
            lock (_unacknowledgedPublishPackets)
            {
                return _unacknowledgedPublishPackets.FirstOrDefault(p => p.PacketIdentifier.Equals(packetIdentifier));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Recover()
        {
            // TODO: Keep the bus and only insert pending items again.
            // TODO: Check if packet identifier must be restarted or not.
            // TODO: Recover package identifier.

            /*
                The Session state in the Client consists of:
                ·         QoS 1 and QoS 2 messages which have been sent to the Server, but have not been completely acknowledged.
                ·         QoS 2 messages which have been received from the Server, but have not been completely acknowledged. 

                The Session state in the Server consists of:
                ·         The existence of a Session, even if the rest of the Session state is empty.
                ·         The Client’s subscriptions.
                ·         QoS 1 and QoS 2 messages which have been sent to the Client, but have not been completely acknowledged.
                ·         QoS 1 and QoS 2 messages pending transmission to the Client.
                ·         QoS 2 messages which have been received from the Client, but have not been completely acknowledged.
                ·         Optionally, QoS 0 messages pending transmission to the Client. 
             */

            // Create a copy of all currently unacknowledged publish packets and clear the storage.
            // We must re-enqueue them in order to trigger other code.
            List<MqttPublishPacket> unacknowledgedPublishPackets;
            lock (_unacknowledgedPublishPackets)
            {
                unacknowledgedPublishPackets = _unacknowledgedPublishPackets.ToList();
                _unacknowledgedPublishPackets.Clear();
            }

            _packetBus.Clear();

            foreach (var publishPacket in unacknowledgedPublishPackets)
            {
                EnqueueDataPacket(new MqttPacketBusItem(publishPacket));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        public void RemoveSubscribedTopic(string topic)
        {
            _subscribedTopics?.Remove(topic);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscribePacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<SubscribeResult> Subscribe(MqttSubscribePacket subscribePacket, CancellationToken cancellationToken)
        {
            return _subscriptionsManager.Subscribe(subscribePacket, cancellationToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="topicHash"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="senderId"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryCheckSubscriptions(string topic, ulong topicHash, MqttQualityOfServiceLevel qualityOfServiceLevel, string senderId, out CheckSubscriptionsResult result)
        {
            result = null;

            try
            {
                result = _subscriptionsManager.CheckSubscriptions(topic, topicHash, qualityOfServiceLevel, senderId);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unsubscribePacket"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UnsubscribeResult> Unsubscribe(MqttUnsubscribePacket unsubscribePacket, CancellationToken cancellationToken)
        {
            return _subscriptionsManager.Unsubscribe(unsubscribePacket, cancellationToken);
        }
    }
    /// <summary>
    /// The MqttSubscription object stores subscription parameters and calculates 
    /// topic hashes.
    ///
    /// Use of Topic Hashes to improve message processing performance
    /// =============================================================
    /// 
    /// Motivation
    /// -----------
    /// In a typical use case for MQTT there may be many publishers (sensors or 
    /// other devices in the field) and few subscribers (monitoring all or many topics).
    /// Each publisher may have one or more topic(s) to publish and therefore both, the 
    /// number of publishers and the number of topics may be large.
    /// 
    /// Maintaining subscribers in a separate container
    /// -----------------------------------------------
    /// Instead of placing all sessions into a single _sessions container, subscribers 
    /// are added into another _subscriberSessions container (if a client is a
    /// subscriber and a publisher then the client is present in both containers). The
    /// cost is some additional bookkeeping work upon subscription where each client 
    /// session needs to maintain a list of subscribed topics.
    /// 
    /// When the client subscribes to the first topic, then the session manager adds
    /// the client to the _subscriberSessions container, and when the client 
    /// unsubscribes from the last topic then the session manager removes the client
    /// from the container. Now, when an application message arrives, only the list of
    /// subscribers need processing instead of looping through potentially thousands of
    /// publishers.
    /// 
    /// Improving subscriber topic lookup
    /// ---------------------------------
    /// For each subscriber, it needs to be determined whether an application message 
    /// matches any topic the subscriber has subscribed to. There may only be few 
    /// subscribers but there may be many subscribed topics, including wildcard topics.
    /// 
    /// The implemented approach uses a topic hash and a hash mask calculated on the
    /// subscribed topic and the published topic (the application message topic) to 
    /// find candidates for a match, with the existing match logic evaluating a reduced
    /// number of candidates.
    /// 
    /// For each subscription, the topic hash and a hash mask is stored with the
    /// subscription, and for each application message received, the hash is calculated
    /// for the published topic before attempting to find matching subscriptions. The
    /// hash calculation itself is simple and does not have a large performance impact.
    /// 
    /// We'll first explain how topic hashes and hash masks are constructed and then how
    /// they are used.
    /// 
    /// Topic hash
    /// ----------
    /// Topic hashes are stored as 64-bit numbers. Each byte within the 64-bit number
    /// relates to one MQTT topic level. A checksum is calculated for each topic level
    /// by iterating over the characters within the topic level (cast to byte) and the
    /// result is stored into the corresponding byte of the 64-bit number. If a topic
    /// level contains a wildcard character, then 0x00 is stored instead of the
    /// checksum.
    /// 
    /// If there are less than 8 levels then the rest of the 64-bit number is filled
    /// with 0xff. If there are more than 8 levels then topics where the first 8 MQTT
    /// topic levels are identical will have the same hash value.
    /// 
    /// This is the topic hash for the MQTT topic below: 0x655D4AF1FFFFFF
    /// 
    /// client1/building1/level1/sensor1 (empty) (empty) (empty) (empty)
    /// \_____/ \_______/ \____/ \_____/ \_____/ \_____/ \_____/ \_____/
    ///    |        |       |       |       |       |       |       |
    ///   0x65     0x5D    0x4A   0xF1     0xFF    0xFF    0xFF    0xFF
    /// 
    /// This is the topic hash for an MQTT topic containing a wildcard: 0x655D00F1FFFFFF
    /// 
    /// client1/building1/ + /sensor1 (empty) (empty) (empty) (empty)
    /// \_____/ \_______/ \_/ \_____/ \_____/ \_____/ \_____/ \_____/
    ///    |        |      |     |       |       |       |       |
    ///   0x65     0x5D    0    0xF1    0xFF    0xFF    0xFF    0xFF
    /// 
    /// For topics that contain the multi level wildcard # at the end, the topic hash
    /// is filled with 0x00: 0x65004A00000000
    /// 
    /// client1/ + /level1/ #  (empty) (empty) (empty) (empty)
    /// \_____/ \_/ \____/ \_/ \_____/ \_____/ \_____/ \_____/
    ///    |     |    |     |     |       |       |       |
    ///   0x65   0   0x4A   0     0       0       0       0
    /// 
    /// 
    /// Topic hash mask
    /// ---------------
    /// The hash mask simply contains 0xFF for non-wildcard topic levels and 0x00 for
    /// wildcard topic levels. Here are the topic hash masks for the examples above.
    /// 
    /// client1/building1/level1/sensor1 (empty) (empty) (empty) (empty)
    /// \_____/ \_______/ \____/ \_____/ \_____/ \_____/ \_____/ \_____/
    ///    |        |       |       |       |       |       |       |
    ///   0xFF     0xFF    0xFF   0xFF     0xFF    0xFF    0xFF    0xFF
    /// 
    /// client1/building1/ + /sensor1 (empty) (empty) (empty) (empty)
    /// \_____/ \_______/ \_/ \_____/ \_____/ \_____/ \_____/ \_____/
    ///    |        |      |     |       |       |       |       |
    ///   0xFF     0xFF    0    0xFF    0xFF    0xFF    0xFF    0xFF
    /// 
    /// client1/ + /level1/ #  (empty) (empty) (empty) (empty)
    /// \_____/ \_/ \____/ \_/ \_____/ \_____/ \_____/ \_____/
    ///    |     |    |     |     |       |       |       |
    ///   0xFF   0    0xFF  0     0       0       0       0
    /// 
    /// 
    /// Topic hash and hash mask properties
    /// -----------------------------------
    /// The following properties of topic hashes and hash masks can be exploited to
    /// find potentially matching subscribed topics for a given published topic.
    /// 
    /// (1) If a subscribed topic does not contain wildcards then the topic hash of the
    /// subscribed topic must be equal to the topic hash of the published topic,
    /// otherwise the subscribed topic cannot be a candidate for a match.
    /// 
    /// (2) If a subscribed topic contains wildcards then the hash of the published
    /// topic masked with the subscribed topic's hash mask must be equal to the hash of
    /// the subscribed topic. I.e. a subscribed topic is a candidate for a match if:
    /// (publishedTopicHash &amp; subscribedTopicHashMask) == subscribedTopicHash
    /// 
    /// (3) If a subscribed topic contains wildcards then any potentially matching
    /// published topic must have a hash value that is greater than or equal to the
    /// hash value of the subscribed topic (because the subscribed topic contains
    /// zeroes in wildcard positions).
    /// 
    /// Match finding
    /// -------------
    /// The subscription manager maintains two separate dictionaries to assist finding
    /// matches using topic hashes: a _noWildcardSubscriptionsByTopicHash dictionary
    /// containing all subscriptions that do not have wildcards, and a
    /// _wildcardSubscriptionsByTopicHash dictionary containing subscriptions with
    /// wildcards.
    /// 
    /// For subscriptions without wildcards, all potential candidates for a match are
    /// obtained by a single look-up (exploiting point 1 above).
    /// 
    /// For subscriptions with wildcards, the subscription manager loops through the
    /// wildcard subscriptions and selects candidates that satisfy condition 
    /// (publishedTopicHash &amp; subscribedTopicMask) == subscribedTopicHash (point 2).
    /// The loop could exit early if wildcard subscriptions were stored into a sorted
    /// dictionary (utilizing point 3), but, after testing, there does not seem to be
    /// any real benefit doing so.
    /// 
    /// Other considerations
    /// --------------------
    /// Characters in the topic string are cast to byte and any additional bytes in a
    /// multi-byte character are disregarded. Best guess is that this does not impact
    /// performance in practice.
    /// 
    /// Instead of one-byte checksums per topic level, one-word checksums per topic
    /// level could be used. If most topics contained four levels or less then hash
    /// buckets would be shallower.
    /// 
    /// For very large numbers of topics, performing a parallel search may help further.
    /// 
    /// To also handle a larger number of subscribers, it may be beneficial to maintain
    /// a subscribers-by-subscription-topic dictionary.
    /// </summary>
    public sealed class MqttSubscription
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="noLocal"></param>
        /// <param name="retainHandling"></param>
        /// <param name="retainAsPublished"></param>
        /// <param name="qualityOfServiceLevel"></param>
        /// <param name="identifier"></param>
        public MqttSubscription(
            string topic,
            bool noLocal,
            MqttRetainHandling retainHandling,
            bool retainAsPublished,
            MqttQualityOfServiceLevel qualityOfServiceLevel,
            uint identifier)
        {
            Topic = topic;
            NoLocal = noLocal;
            RetainHandling = retainHandling;
            RetainAsPublished = retainAsPublished;
            GrantedQualityOfServiceLevel = qualityOfServiceLevel;
            Identifier = identifier;

            CalculateTopicHash(Topic, out var hash, out var hashMask, out var hasWildcard);
            TopicHash = hash;
            TopicHashMask = hashMask;
            TopicHasWildcard = hasWildcard;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttQualityOfServiceLevel GrantedQualityOfServiceLevel { get; }
        /// <summary>
        /// 
        /// </summary>
        public uint Identifier { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoLocal { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool RetainAsPublished { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttRetainHandling RetainHandling { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Topic { get; }
        /// <summary>
        /// 
        /// </summary>
        public ulong TopicHash { get; }
        /// <summary>
        /// 
        /// </summary>
        public ulong TopicHashMask { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool TopicHasWildcard { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="resultHash"></param>
        /// <param name="resultHashMask"></param>
        /// <param name="resultHasWildcard"></param>
        public static void CalculateTopicHash(string topic, out ulong resultHash, out ulong resultHashMask, out bool resultHasWildcard)
        {
            // calculate topic hash
            ulong hash = 0;
            ulong hashMaskInverted = 0;
            ulong levelBitMask = 0;
            ulong fillLevelBitMask = 0;
            var hasWildcard = false;
            byte checkSum = 0;
            var level = 0;

            var i = 0;
            while (i < topic.Length)
            {
                var c = topic[i];
                if (c == MqttTopicFilterComparer.LevelSeparator)
                {
                    // done with this level
                    hash <<= 8;
                    hash |= checkSum;
                    hashMaskInverted <<= 8;
                    hashMaskInverted |= levelBitMask;
                    checkSum = 0;
                    levelBitMask = 0;
                    ++level;
                    if (level >= 8)
                    {
                        break;
                    }
                }
                else if (c == MqttTopicFilterComparer.SingleLevelWildcard)
                {
                    levelBitMask = 0xff;
                    hasWildcard = true;
                }
                else if (c == MqttTopicFilterComparer.MultiLevelWildcard)
                {
                    // checksum is zero for a valid topic
                    levelBitMask = 0xff;
                    // fill rest with this fillLevelBitMask
                    fillLevelBitMask = 0xff;
                    hasWildcard = true;
                    break;
                }
                else
                {
                    // The checksum should be designed to reduce the hash bucket depth for the expected
                    // fairly regularly named MQTT topics that don't differ much,
                    // i.e. "room1/sensor1"
                    //      "room1/sensor2"
                    //      "room1/sensor3"
                    // etc.
                    if ((c & 1) == 0)
                    {
                        checkSum += (byte)c;
                    }
                    else
                    {
                        checkSum ^= (byte)(c >> 1);
                    }
                }

                ++i;
            }

            // Shift hash left and leave zeroes to fill ulong
            if (level < 8)
            {
                hash <<= 8;
                hash |= checkSum;
                hashMaskInverted <<= 8;
                hashMaskInverted |= levelBitMask;
                ++level;
                while (level < 8)
                {
                    hash <<= 8;
                    hashMaskInverted <<= 8;
                    hashMaskInverted |= fillLevelBitMask;
                    ++level;
                }
            }

            if (!hasWildcard)
            {
                while (i < topic.Length)
                {
                    var c = topic[i];
                    if (c == MqttTopicFilterComparer.SingleLevelWildcard || c == MqttTopicFilterComparer.MultiLevelWildcard)
                    {
                        hasWildcard = true;
                        break;
                    }

                    ++i;
                }
            }

            resultHash = hash;
            resultHashMask = ~hashMaskInverted;
            resultHasWildcard = hasWildcard;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class SubscribeResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="topicsCount"></param>
        public SubscribeResult(int topicsCount)
        {
            ReasonCodes = new List<MqttSubscribeReasonCode>(topicsCount);
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CloseConnection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttSubscribeReasonCode> ReasonCodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttRetainedMessageMatch> RetainedMessages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }
    }
    /// <summary>
    ///     Helper class that stores subscriptions by their topic hash mask.
    /// </summary>
    public sealed class TopicHashMaskSubscriptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<ulong, HashSet<MqttSubscription>> SubscriptionsByHashMask { get; } = new Dictionary<ulong, HashSet<MqttSubscription>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscription"></param>
        public void AddSubscription(MqttSubscription subscription)
        {
            if (!SubscriptionsByHashMask.TryGetValue(subscription.TopicHashMask, out var subscriptions))
            {
                subscriptions = new HashSet<MqttSubscription>();
                SubscriptionsByHashMask.Add(subscription.TopicHashMask, subscriptions);
            }
            subscriptions.Add(subscription);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscription"></param>
        public void RemoveSubscription(MqttSubscription subscription)
        {
            if (SubscriptionsByHashMask.TryGetValue(subscription.TopicHashMask, out var subscriptions))
            {
                subscriptions.Remove(subscription);
                if (subscriptions.Count == 0)
                {
                    SubscriptionsByHashMask.Remove(subscription.TopicHashMask);
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class UnsubscribeResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MqttUnsubscribeReasonCode> ReasonCodes { get; } = new List<MqttUnsubscribeReasonCode>(128);
        /// <summary>
        /// 
        /// </summary>
        public bool CloseConnection { get; set; }
    }
    #endregion Internal
    #region // Options
    /// <summary>
    /// 
    /// </summary>
    public interface IMqttServerCertificateCredentials
    {
        /// <summary>
        /// 
        /// </summary>
        string Password { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttServerCertificateCredentials : IMqttServerCertificateCredentials
    {
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttServerOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan DefaultCommunicationTimeout { get; set; } = TimeSpan.FromSeconds(100);
        /// <summary>
        /// 
        /// </summary>
        public MqttServerTcpEndpointOptions DefaultEndpointOptions { get; } = new MqttServerTcpEndpointOptions();
        /// <summary>
        /// 
        /// </summary>
        public bool EnablePersistentSessions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan KeepAliveMonitorInterval { get; set; } = TimeSpan.FromMilliseconds(500);
        /// <summary>
        /// 
        /// </summary>
        public int MaxPendingMessagesPerClient { get; set; } = 250;
        /// <summary>
        /// 
        /// </summary>
        public MqttPendingMessagesOverflowStrategy PendingMessagesOverflowStrategy { get; set; } = MqttPendingMessagesOverflowStrategy.DropOldestQueuedMessage;
        /// <summary>
        /// 
        /// </summary>
        public MqttServerTlsTcpEndpointOptions TlsEndpointOptions { get; } = new MqttServerTlsTcpEndpointOptions();

        /// <summary>
        ///     Gets or sets the default and initial size of the packet write buffer.
        ///     It is recommended to set this to a value close to the usual expected packet size * 1.5.
        ///     Do not change this value when no memory issues are experienced.
        /// </summary>
        public int WriterBufferSize { get; set; } = 4096;

        /// <summary>
        ///     Gets or sets the maximum size of the buffer writer. The writer will reduce its internal buffer
        ///     to this value after serializing a packet.
        ///     Do not change this value when no memory issues are experienced.
        /// </summary>
        public int WriterBufferSizeMax { get; set; } = 65535;
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttServerOptionsBuilder
    {
        readonly MqttServerOptions _options = new MqttServerOptions();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithConnectionBacklog(int value)
        {
            _options.DefaultEndpointOptions.ConnectionBacklog = value;
            _options.TlsEndpointOptions.ConnectionBacklog = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithMaxPendingMessagesPerClient(int value)
        {
            _options.MaxPendingMessagesPerClient = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultCommunicationTimeout(TimeSpan value)
        {
            _options.DefaultCommunicationTimeout = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultEndpoint()
        {
            _options.DefaultEndpointOptions.IsEnabled = true;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultEndpointPort(int value)
        {
            _options.DefaultEndpointOptions.Port = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultEndpointBoundIPAddress(IPAddress value)
        {
            _options.DefaultEndpointOptions.BoundInterNetworkAddress = value ?? IPAddress.Any;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultEndpointBoundIPV6Address(IPAddress value)
        {
            _options.DefaultEndpointOptions.BoundInterNetworkV6Address = value ?? IPAddress.Any;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithoutDefaultEndpoint()
        {
            _options.DefaultEndpointOptions.IsEnabled = false;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithEncryptedEndpoint()
        {
            _options.TlsEndpointOptions.IsEnabled = true;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithEncryptedEndpointPort(int value)
        {
            _options.TlsEndpointOptions.Port = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithEncryptedEndpointBoundIPAddress(IPAddress value)
        {
            _options.TlsEndpointOptions.BoundInterNetworkAddress = value;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithEncryptedEndpointBoundIPV6Address(IPAddress value)
        {
            _options.TlsEndpointOptions.BoundInterNetworkV6Address = value;
            return this;
        }

#if !WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServerOptionsBuilder WithEncryptionCertificate(byte[] value, IMqttServerCertificateCredentials credentials = null)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _options.TlsEndpointOptions.CertificateProvider = new BlobCertificateProvider(value)
            {
                Password = credentials?.Password
            };

            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttServerOptionsBuilder WithEncryptionCertificate(X509Certificate2 certificate)
        {
            if (certificate == null) throw new ArgumentNullException(nameof(certificate));

            _options.TlsEndpointOptions.CertificateProvider = new X509CertificateProvider(certificate);
            return this;
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithEncryptionSslProtocol(SslProtocols value)
        {
            _options.TlsEndpointOptions.SslProtocol = value;
            return this;
        }

#if !WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validationCallback"></param>
        /// <param name="checkCertificateRevocation"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithClientCertificate(RemoteCertificateValidationCallback validationCallback = null, bool checkCertificateRevocation = false)
        {
            _options.TlsEndpointOptions.ClientCertificateRequired = true;
            _options.TlsEndpointOptions.CheckCertificateRevocation = checkCertificateRevocation;
            _options.TlsEndpointOptions.RemoteCertificateValidationCallback = validationCallback;
            return this;
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithoutEncryptedEndpoint()
        {
            _options.TlsEndpointOptions.IsEnabled = false;
            return this;
        }

#if !WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithRemoteCertificateValidationCallback(RemoteCertificateValidationCallback value)
        {
            _options.TlsEndpointOptions.RemoteCertificateValidationCallback = value;
            return this;
        }
#endif

        // public MqttServerOptionsBuilder WithApplicationMessageInterceptor(IMqttServerApplicationMessageInterceptor value)
        // {
        //     _options.ApplicationMessageInterceptor = value;
        //     return this;
        // }
        //
        // public MqttServerOptionsBuilder WithApplicationMessageInterceptor(Action<InterceptingMqttClientPublishEventArgs> value)
        // {
        //     _options.ApplicationMessageInterceptor = new MqttServerApplicationMessageInterceptorDelegate(value);
        //     return this;
        // }
        //
        // public MqttServerOptionsBuilder WithApplicationMessageInterceptor(Func<InterceptingMqttClientPublishEventArgs, Task> value)
        // {
        //     _options.ApplicationMessageInterceptor = new MqttServerApplicationMessageInterceptorDelegate(value);
        //     return this;
        // }

        // public MqttServerOptionsBuilder WithMultiThreadedApplicationMessageInterceptor(Action<InterceptingMqttClientPublishEventArgs> value)
        // {
        //     _options.ApplicationMessageInterceptor = new MqttServerMultiThreadedApplicationMessageInterceptorDelegate(value);
        //     return this;
        // }
        //
        // public MqttServerOptionsBuilder WithMultiThreadedApplicationMessageInterceptor(Func<InterceptingMqttClientPublishEventArgs, Task> value)
        // {
        //     _options.ApplicationMessageInterceptor = new MqttServerMultiThreadedApplicationMessageInterceptorDelegate(value);
        //     return this;
        // }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithDefaultEndpointReuseAddress()
        {
            _options.DefaultEndpointOptions.ReuseAddress = true;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithTlsEndpointReuseAddress()
        {
            _options.TlsEndpointOptions.ReuseAddress = true;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MqttServerOptionsBuilder WithPersistentSessions(bool value = true)
        {
            _options.EnablePersistentSessions = value;
            return this;
        }

        // /// <summary>
        // /// Gets or sets the client ID which is used when publishing messages from the server directly.
        // /// </summary>
        // public MqttServerOptionsBuilder WithClientId(string value)
        // {
        //     _options.ClientId = value;
        //     return this;
        // }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MqttServerOptions Build()
        {
            return _options;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class MqttServerTcpEndpointBaseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ConnectionBacklog { get; set; } = 100;
        /// <summary>
        /// 
        /// </summary>
        public bool NoDelay { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public LingerOption LingerState { get; set; } = new LingerOption(true, 0);

#if WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        public int BufferSize { get; set; } = 4096;
#endif
        /// <summary>
        /// 
        /// </summary>
        public IPAddress BoundInterNetworkAddress { get; set; } = IPAddress.Any;
        /// <summary>
        /// 
        /// </summary>
        public IPAddress BoundInterNetworkV6Address { get; set; } = IPAddress.IPv6Any;

        /// <summary>
        ///     This requires admin permissions on Linux.
        /// </summary>
        public bool ReuseAddress { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MqttServerTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public MqttServerTcpEndpointOptions()
        {
            Port = 1883;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttServerTlsTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public MqttServerTlsTcpEndpointOptions()
        {
            Port = 8883;
        }

#if !WINDOWS_UWP
        /// <summary>
        /// 
        /// </summary>
        public System.Net.Security.RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
#endif
        /// <summary>
        /// 
        /// </summary>
        public ICertificateProvider CertificateProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ClientCertificateRequired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool CheckCertificateRevocation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00;

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        /// <summary>
        /// 
        /// </summary>
        public System.Net.Security.CipherSuitesPolicy CipherSuitesPolicy { get; set; }
#endif
    }
    #endregion Options
    #region // Status
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientStatus
    {
        readonly MqttServerClient _client;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientStatus(MqttServerClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets or sets the client identifier.
        /// Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string Id => _client.Id;
        /// <summary>
        /// 
        /// </summary>
        public string Endpoint => _client.Endpoint;
        /// <summary>
        /// 
        /// </summary>
        public MqttProtocolVersion ProtocolVersion => _client.ChannelAdapter.PacketFormatterAdapter.ProtocolVersion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ConnectedTimestamp => _client.Statistics.ConnectedTimestamp;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastPacketReceivedTimestamp => _client.Statistics.LastPacketReceivedTimestamp;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastPacketSentTimestamp => _client.Statistics.LastPacketSentTimestamp;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastNonKeepAlivePacketReceivedTimestamp => _client.Statistics.LastNonKeepAlivePacketReceivedTimestamp;
        /// <summary>
        /// 
        /// </summary>
        public long ReceivedApplicationMessagesCount => _client.Statistics.ReceivedApplicationMessagesCount;
        /// <summary>
        /// 
        /// </summary>
        public long SentApplicationMessagesCount => _client.Statistics.SentApplicationMessagesCount;
        /// <summary>
        /// 
        /// </summary>
        public long ReceivedPacketsCount => _client.Statistics.ReceivedPacketsCount;
        /// <summary>
        /// 
        /// </summary>
        public long SentPacketsCount => _client.Statistics.SentPacketsCount;
        /// <summary>
        /// 
        /// </summary>
        public MqttSessionStatus Session { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long BytesSent => _client.ChannelAdapter.BytesSent;
        /// <summary>
        /// 
        /// </summary>
        public long BytesReceived => _client.ChannelAdapter.BytesReceived;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task DisconnectAsync()
        {
            return _client.StopAsync(MqttDisconnectReasonCode.NormalDisconnection);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ResetStatistics()
        {
            _client.ResetStatistics();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttSessionStatus
    {
        readonly MqttSession _session;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttSessionStatus(MqttSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }
        /// <summary>
        /// 
        /// </summary>
        public string Id => _session.Id;
        /// <summary>
        /// 
        /// </summary>
        public long PendingApplicationMessagesCount => _session.PendingDataPacketsCount;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedTimestamp => _session.CreatedTimestamp;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary Items => _session.Items;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task EnqueueApplicationMessageAsync(MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null) throw new ArgumentNullException(nameof(applicationMessage));

            var publishPacketFactory = new MqttPublishPacketFactory();
            _session.EnqueueDataPacket(new MqttPacketBusItem(publishPacketFactory.Create(applicationMessage)));

            return CompletedTask.Instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task DeliverApplicationMessageAsync(MqttApplicationMessage applicationMessage)
        {
            if (applicationMessage == null) throw new ArgumentNullException(nameof(applicationMessage));

            var publishPacketFactory = new MqttPublishPacketFactory();
            var packetBusItem = new MqttPacketBusItem(publishPacketFactory.Create(applicationMessage));
            _session.EnqueueDataPacket(packetBusItem);

            return packetBusItem.WaitAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task DeleteAsync()
        {
            return _session.DeleteAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task ClearApplicationMessagesQueueAsync()
        {
            throw new NotImplementedException();
        }
    }
    #endregion Status
    #endregion Server
}
