using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NMQTT
{
    /// <summary>
    /// 
    /// </summary>
    public enum MqttTopicFilterCompareResult
    {
        /// <summary>
        /// 
        /// </summary>
        NoMatch,
        /// <summary>
        /// 
        /// </summary>
        IsMatch,
        /// <summary>
        /// 
        /// </summary>
        FilterInvalid,
        /// <summary>
        /// 
        /// </summary>
        TopicInvalid
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientConnectResultCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        MalformedPacket = 129,
        /// <summary>
        /// 
        /// </summary>
        ProtocolError = 130,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        UnsupportedProtocolVersion = 132,
        /// <summary>
        /// 
        /// </summary>
        ClientIdentifierNotValid = 133,
        /// <summary>
        /// 
        /// </summary>
        BadUserNameOrPassword = 134,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        ServerUnavailable = 136,
        /// <summary>
        /// 
        /// </summary>
        ServerBusy = 137,
        /// <summary>
        /// 
        /// </summary>
        Banned = 138,
        /// <summary>
        /// 
        /// </summary>
        BadAuthenticationMethod = 140,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketTooLarge = 149,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153,
        /// <summary>
        /// 
        /// </summary>
        RetainNotSupported = 154,
        /// <summary>
        /// 
        /// </summary>
        QoSNotSupported = 155,
        /// <summary>
        /// 
        /// </summary>
        UseAnotherServer = 156,
        /// <summary>
        /// 
        /// </summary>
        ServerMoved = 157,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRateExceeded = 159
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientDisconnectReason
    {
        /// <summary>
        /// 
        /// </summary>
        NormalDisconnection = 0,
        /// <summary>
        /// 
        /// </summary>
        DisconnectWithWillMessage = 4,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        MalformedPacket = 129,
        /// <summary>
        /// 
        /// </summary>
        ProtocolError = 130,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        ServerBusy = 137,
        /// <summary>
        /// 
        /// </summary>
        ServerShuttingDown = 139,
        /// <summary>
        /// 
        /// </summary>
        BadAuthenticationMethod = 140,
        /// <summary>
        /// 
        /// </summary>
        KeepAliveTimeout = 141,
        /// <summary>
        /// 
        /// </summary>
        SessionTakenOver = 142,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        ReceiveMaximumExceeded = 147,
        /// <summary>
        /// 
        /// </summary>
        TopicAliasInvalid = 148,
        /// <summary>
        /// 
        /// </summary>
        PacketTooLarge = 149,
        /// <summary>
        /// 
        /// </summary>
        MessageRateTooHigh = 150,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        AdministrativeAction = 152,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153,
        /// <summary>
        /// 
        /// </summary>
        RetainNotSupported = 154,
        /// <summary>
        /// 
        /// </summary>
        QosNotSupported = 155,
        /// <summary>
        /// 
        /// </summary>
        UseAnotherServer = 156,
        /// <summary>
        /// 
        /// </summary>
        ServerMoved = 157,
        /// <summary>
        /// 
        /// </summary>
        SharedSubscriptionsNotSupported = 158,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRateExceeded = 159,
        /// <summary>
        /// 
        /// </summary>
        MaximumConnectTime = 160,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifiersNotSupported = 161,
        /// <summary>
        /// 
        /// </summary>
        WildcardSubscriptionsNotSupported = 162
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientPublishReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        NoMatchingSubscribers = 16,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttApplicationMessageReceivedReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        NoMatchingSubscribers = 16,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierNotFound = 146,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientSubscribeResultCode
    {
        /// <summary>
        /// 
        /// </summary>
        GrantedQoS0 = 0x00,
        /// <summary>
        /// 
        /// </summary>
        GrantedQoS1 = 0x01,
        /// <summary>
        /// 
        /// </summary>
        GrantedQoS2 = 0x02,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 0x80,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        SharedSubscriptionsNotSupported = 158,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifiersNotSupported = 161,
        /// <summary>
        /// 
        /// </summary>
        WildcardSubscriptionsNotSupported = 162
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientUnsubscribeResultCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        NoSubscriptionExisted = 17,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientConnectionStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Disconnected,
        /// <summary>
        /// 
        /// </summary>
        Disconnecting,
        /// <summary>
        /// 
        /// </summary>
        Connected,
        /// <summary>
        /// 
        /// </summary>
        Connecting
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttNetLogLevel
    {
        /// <summary>
        /// 
        /// </summary>
        Verbose,
        /// <summary>
        /// 
        /// </summary>
        Info,
        /// <summary>
        /// 
        /// </summary>
        Warning,
        /// <summary>
        /// 
        /// </summary>
        Error
    }
    /// <summary>
    /// Mqtt报文流向
    /// </summary>
    public enum MqttPacketFlowDirection
    {
        /// <summary>
        /// 流入
        /// </summary>
        Inbound,
        /// <summary>
        /// 流出
        /// </summary>
        Outbound
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPacketBusPartition
    {
        /// <summary>
        /// 
        /// </summary>
        Data,
        /// <summary>
        /// 
        /// </summary>
        Control,
        /// <summary>
        /// 
        /// </summary>
        Health
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttProtocolVersion
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 
        /// </summary>
        V310 = 3,
        /// <summary>
        /// 
        /// </summary>
        V311 = 4,
        /// <summary>
        /// 
        /// </summary>
        V500 = 5
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttAuthenticateReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        ContinueAuthentication = 24,
        /// <summary>
        /// 
        /// </summary>
        ReAuthenticate = 25
    }/// <summary>
     /// 
     /// </summary>
    public enum MqttConnectReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        MalformedPacket = 129,
        /// <summary>
        /// 
        /// </summary>
        ProtocolError = 130,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        UnsupportedProtocolVersion = 132,
        /// <summary>
        /// 
        /// </summary>
        ClientIdentifierNotValid = 133,
        /// <summary>
        /// 
        /// </summary>
        BadUserNameOrPassword = 134,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        ServerUnavailable = 136,
        /// <summary>
        /// 
        /// </summary>
        ServerBusy = 137,
        /// <summary>
        /// 
        /// </summary>
        Banned = 138,
        /// <summary>
        /// 
        /// </summary>
        BadAuthenticationMethod = 140,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketTooLarge = 149,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153,
        /// <summary>
        /// 
        /// </summary>
        RetainNotSupported = 154,
        /// <summary>
        /// 
        /// </summary>
        QoSNotSupported = 155,
        /// <summary>
        /// 
        /// </summary>
        UseAnotherServer = 156,
        /// <summary>
        /// 
        /// </summary>
        ServerMoved = 157,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRateExceeded = 159
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttConnectReturnCode
    {
        /// <summary>
        /// 
        /// </summary>
        ConnectionAccepted = 0x00,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRefusedUnacceptableProtocolVersion = 0x01,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRefusedIdentifierRejected = 0x02,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRefusedServerUnavailable = 0x03,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRefusedBadUsernameOrPassword = 0x04,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRefusedNotAuthorized = 0x05
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttControlPacketType
    {
        /// <summary>
        /// 
        /// </summary>
        Connect = 1,
        /// <summary>
        /// 
        /// </summary>
        ConnAck = 2,
        /// <summary>
        /// 
        /// </summary>
        Publish = 3,
        /// <summary>
        /// 
        /// </summary>
        PubAck = 4,
        /// <summary>
        /// 
        /// </summary>
        PubRec = 5,
        /// <summary>
        /// 
        /// </summary>
        PubRel = 6,
        /// <summary>
        /// 
        /// </summary>
        PubComp = 7,
        /// <summary>
        /// 
        /// </summary>
        Subscribe = 8,
        /// <summary>
        /// 
        /// </summary>
        SubAck = 9,
        /// <summary>
        /// 
        /// </summary>
        Unsubscribe = 10,
        /// <summary>
        /// 
        /// </summary>
        UnsubAck = 11,
        /// <summary>
        /// 
        /// </summary>
        PingReq = 12,
        /// <summary>
        /// 
        /// </summary>
        PingResp = 13,
        /// <summary>
        /// 
        /// </summary>
        Disconnect = 14,
        /// <summary>
        /// 
        /// </summary>
        Auth = 15
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttDisconnectReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        NormalDisconnection = 0,
        /// <summary>
        /// 
        /// </summary>
        DisconnectWithWillMessage = 4,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        MalformedPacket = 129,
        /// <summary>
        /// 
        /// </summary>
        ProtocolError = 130,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        ServerBusy = 137,
        /// <summary>
        /// 
        /// </summary>
        ServerShuttingDown = 139,
        /// <summary>
        /// 
        /// </summary>
        KeepAliveTimeout = 141,
        /// <summary>
        /// 
        /// </summary>
        SessionTakenOver = 142,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        ReceiveMaximumExceeded = 147,
        /// <summary>
        /// 
        /// </summary>
        TopicAliasInvalid = 148,
        /// <summary>
        /// 
        /// </summary>
        PacketTooLarge = 149,
        /// <summary>
        /// 
        /// </summary>
        MessageRateTooHigh = 150,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        AdministrativeAction = 152,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153,
        /// <summary>
        /// 
        /// </summary>
        RetainNotSupported = 154,
        /// <summary>
        /// 
        /// </summary>
        QoSNotSupported = 155,
        /// <summary>
        /// 
        /// </summary>
        UseAnotherServer = 156,
        /// <summary>
        /// 
        /// </summary>
        ServerMoved = 157,
        /// <summary>
        /// 
        /// </summary>
        SharedSubscriptionsNotSupported = 158,
        /// <summary>
        /// 
        /// </summary>
        ConnectionRateExceeded = 159,
        /// <summary>
        /// 
        /// </summary>
        MaximumConnectTime = 160,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifiersNotSupported = 161,
        /// <summary>
        /// 
        /// </summary>
        WildcardSubscriptionsNotSupported = 162
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPayloadFormatIndicator
    {
        /// <summary>
        /// 
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// 
        /// </summary>
        CharacterData = 1
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPropertyId
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatIndicator = 1,
        /// <summary>
        /// 
        /// </summary>
        MessageExpiryInterval = 2,
        /// <summary>
        /// 
        /// </summary>
        ContentType = 3,
        /// <summary>
        /// 
        /// </summary>
        ResponseTopic = 8,
        /// <summary>
        /// 
        /// </summary>
        CorrelationData = 9,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifier = 11,
        /// <summary>
        /// 
        /// </summary>
        SessionExpiryInterval = 17,
        /// <summary>
        /// 
        /// </summary>
        AssignedClientIdentifier = 18,
        /// <summary>
        /// 
        /// </summary>
        ServerKeepAlive = 19,
        /// <summary>
        /// 
        /// </summary>
        AuthenticationMethod = 21,
        /// <summary>
        /// 
        /// </summary>
        AuthenticationData = 22,
        /// <summary>
        /// 
        /// </summary>
        RequestProblemInformation = 23,
        /// <summary>
        /// 
        /// </summary>
        WillDelayInterval = 24,
        /// <summary>
        /// 
        /// </summary>
        RequestResponseInformation = 25,
        /// <summary>
        /// 
        /// </summary>
        ResponseInformation = 26,
        /// <summary>
        /// 
        /// </summary>
        ServerReference = 28,
        /// <summary>
        /// 
        /// </summary>
        ReasonString = 31,
        /// <summary>
        /// 
        /// </summary>
        ReceiveMaximum = 33,
        /// <summary>
        /// 
        /// </summary>
        TopicAliasMaximum = 34,
        /// <summary>
        /// 
        /// </summary>
        TopicAlias = 35,
        /// <summary>
        /// 
        /// </summary>
        MaximumQoS = 36,
        /// <summary>
        /// 
        /// </summary>
        RetainAvailable = 37,
        /// <summary>
        /// 
        /// </summary>
        UserProperty = 38,
        /// <summary>
        /// 
        /// </summary>
        MaximumPacketSize = 39,
        /// <summary>
        /// 
        /// </summary>
        WildcardSubscriptionAvailable = 40,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifiersAvailable = 41,
        /// <summary>
        /// 
        /// </summary>
        SharedSubscriptionAvailable = 42
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPubAckReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,

        /// <summary>
        /// The message is accepted but there are no subscribers. This is sent only by the Server. If the Server knows that there are no matching subscribers, it MAY use this Reason Code instead of 0x00 (Success).
        /// </summary>
        NoMatchingSubscribers = 16,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPubCompReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierNotFound = 146
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPubRecReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        NoMatchingSubscribers = 16,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicNameInvalid = 144,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        PayloadFormatInvalid = 153
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPubRelReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierNotFound = 146
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttQualityOfServiceLevel
    {
        /// <summary>
        /// 
        /// </summary>
        AtMostOnce = 0x00,
        /// <summary>
        /// 
        /// </summary>
        AtLeastOnce = 0x01,
        /// <summary>
        /// 
        /// </summary>
        ExactlyOnce = 0x02
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttUnsubscribeReasonCode
    {
        /// <summary>
        /// 
        /// </summary>
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        NoSubscriptionExisted = 17,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 128,
        /// <summary>
        /// 
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttSubscribeReturnCode
    {
        /// <summary>
        /// 
        /// </summary>
        SuccessMaximumQoS0 = 0x00,
        /// <summary>
        /// 
        /// </summary>
        SuccessMaximumQoS1 = 0x01,
        /// <summary>
        /// 
        /// </summary>
        SuccessMaximumQoS2 = 0x02,
        /// <summary>
        /// 
        /// </summary>
        Failure = 0x80
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttSubscribeReasonCode
    {
        /// <summary>
        /// Compatible with MQTTv3.1.1.
        /// </summary>
        GrantedQoS0 = 0x00,
        /// <summary>
        /// 
        /// </summary>
        GrantedQoS1 = 0x01,
        /// <summary>
        /// 
        /// </summary>
        GrantedQoS2 = 0x02,
        /// <summary>
        /// 
        /// </summary>
        UnspecifiedError = 0x80,

        /// <summary>
        /// New in MQTTv5.
        /// </summary>
        ImplementationSpecificError = 131,
        /// <summary>
        /// 
        /// </summary>
        NotAuthorized = 135,
        /// <summary>
        /// 
        /// </summary>
        TopicFilterInvalid = 143,
        /// <summary>
        /// 
        /// </summary>
        PacketIdentifierInUse = 145,
        /// <summary>
        /// 
        /// </summary>
        QuotaExceeded = 151,
        /// <summary>
        /// 
        /// </summary>
        SharedSubscriptionsNotSupported = 158,
        /// <summary>
        /// 
        /// </summary>
        SubscriptionIdentifiersNotSupported = 161,
        /// <summary>
        /// 
        /// </summary>
        WildcardSubscriptionsNotSupported = 162
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttRetainHandling
    {
        /// <summary>
        /// 
        /// </summary>
        SendAtSubscribe = 0,
        /// <summary>
        /// 
        /// </summary>
        SendAtSubscribeIfNewSubscriptionOnly = 1,
        /// <summary>
        /// 
        /// </summary>
        DoNotSendOnSubscribe = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttClientDisconnectType
    {
        /// <summary>
        /// 
        /// </summary>
        Clean,
        /// <summary>
        /// 
        /// </summary>
        NotClean,
        /// <summary>
        /// 
        /// </summary>
        Takeover
    }
    /// <summary>
    /// 
    /// </summary>
    public enum MqttPendingMessagesOverflowStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        DropOldestQueuedMessage,
        /// <summary>
        /// 
        /// </summary>
        DropNewMessage
    }
}
