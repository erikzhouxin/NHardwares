namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVPlayerRunInfoType
    * @brief 解码层上报运行信息的类型的枚举定义
    * @attention 无
    */
    public enum NETDEV_PLAYER_RUN_INFO_TYPE_E
    {
        NETDEV_PLAYER_RUN_INFO_RECORD_VIDEO = 1,        /**< 本地录像过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PROCESS = 2,        /**< 视频媒体处理过程中的上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_SERIES_SNATCH = 3,        /**< 连续抓拍过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_VOICE = 4,        /**< 语音业务过程中上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_NOT_IDENTIFY = 5,        /**< 码流无法识别 */
        NETDEV_PLAYER_RUN_INFO_RECV_PACKET_NUM = 6,        /**< 周期内接收到的包数 */
        NETDEV_PLAYER_RUN_INFO_RECV_BYTE_NUM = 7,        /**< 周期内接收到的字节数 */
        NETDEV_PLAYER_RUN_INFO_VIDEO_FRAME_NUM = 8,        /**< 周期内解析的视频帧数 */
        NETDEV_PLAYER_RUN_INFO_AUDIO_FRAME_NUM = 9,        /**< 周期内解析的音频帧数 */
        NETDEV_PLAYER_RUN_INFO_LOST_PACKET_RATIO = 10,       /**< 周期内丢包率统计信息（单位为0.01%） */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PLAY_PROGRESS = 11,       /**< 媒体中携带的进度信息 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_PLAY_END = 12,       /**< 媒体中携带的播放结束 */
        NETDEV_PLAYER_RUN_INFO_MEDIA_ABNORMAL = 13,       /**< 媒体处理异常 */
        NETDEV_PLAYER_RUN_INFO_CODEC = 14,       /**< 编解码器 */
        NETDEV_PLAYER_RUN_INFO_STREAM = 15,       /**< 网络流或输入流播放 */
        NETDEV_PLAYER_RUN_INFO_PLAYBACK_FINISH = 16,       /**< 回放结束 */
        NETDEV_PLAYER_RUN_INFO_SNATCH = 17,       /**< 截图过程中的上报运行信息 */
        NETDEV_PLAYER_RUN_INFO_INVALID = 0xff
    }

}
