namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVAudioSampleParamType
    * @brief 音频参数
    * @attention 无
    */
    public struct NETDEV_AUDIO_SAMPLE_PARAM_S
    {
        public Int32 dwChannels;                               /* 声道数,单声道为1,立体声为2 */
        public Int32 dwSampleRate;                             /* 采样率 */
        public NETDEV_AUDIO_SAMPLE_FORMAT_E enSampleFormat;    /* 位宽 */
    };

}
