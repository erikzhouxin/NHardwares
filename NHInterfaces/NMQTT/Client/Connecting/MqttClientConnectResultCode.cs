namespace System.Data.NMQTT
{
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
}
