using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.WebSockets;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
#if WINDOWS_UWP
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Security.Cryptography.Certificates;
using System.Runtime.InteropServices.WindowsRuntime;
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
}
