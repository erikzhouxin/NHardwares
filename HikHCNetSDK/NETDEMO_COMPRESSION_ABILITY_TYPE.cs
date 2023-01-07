namespace System.Data.HikHCNetSDK
{
    public enum COMPRESSION_ABILITY_TYPE
    {
        COMPRESSION_STREAM_ABILITY = 0, //码流压缩类型
        MAIN_RESOLUTION_ABILITY = 1,    //主码流压缩分辨率
        SUB_RESOLUTION_ABILITY = 2, //子码流压缩分辨率
        EVENT_RESOLUTION_ABILITY = 3,  //事件压缩参数分辨率
        FRAME_ABILITY = 4,              //帧率能力
        BITRATE_TYPE_ABILITY = 5,       //位率类型能力
        BITRATE_ABILITY = 6,            //位率上限
        THIRD_RESOLUTION_ABILITY = 7,   //三码流压缩分辨率
        STREAM_TYPE_ABILITY = 8,        //码流类型
        PIC_QUALITY_ABILITY = 9,         //图像质量
        INTERVAL_BPFRAME_ABILITY = 10,  //BP帧间隔
        VIDEO_ENC_ABILITY = 11,           //视频编码能力
        AUDIO_ENC_ABILITY = 12,           //音频编码能力
        VIDEO_ENC_COMPLEXITY_ABILITY = 13, //视频编码复杂度能力
        FORMAT_ABILITY = 14, //封装格式能力
    }
}
