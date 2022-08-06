using System;

namespace System.Data.KangMeiIPGBSDK
{
    /**
     * 请求广播类型
     * typedef enum __EM_QUGBTYPE_TYPE 
     * {
     *   GBTYPE_SERVER_FILES=1,     //服务器文件资源广播
     *   GBTYPE_LCA_FILES,   //本地文件资源广播 
     *   GBTYPE_SoundCard,   //本地声卡广播
     *   GBTYPE_TmCb ,       //指定终端采播
     *   GBTYPE_EncTmCb,        //指定编码终端采播
     *   GBTYPE_TextGb ,     //TTS文本转语音广播
     *   GBTYPE_ThirdRealAudioGb  //第三方实时音频流(按SDK规定的音频格式，用户自己采集实时流,推流到SDK)广播 
     * }EM_QUGBTYPE_TYPE;
    **/
    public enum NETEM_QUGBTYPE_TYPE
    {
        /// <summary>
        /// 第三方实时音频流(按SDK规定的音频格式，用户自己采集实时流,推流到SDK)广播
        /// </summary>
        GBTYPE_ThirdRealAudioGb = 7,
        /// <summary>
        /// TTS文本转语音广播
        /// </summary>
        GBTYPE_TextGb = 6,
        /// <summary>
        /// 指定编码终端采播
        /// </summary>
        GBTYPE_EncTmCb = 5,
        /// <summary>
        /// 指定终端采播
        /// </summary>
        GBTYPE_TmCb = 4,
        /// <summary>
        /// 本地声卡广播
        /// </summary>
        GBTYPE_SoundCard = 3,
        /// <summary>
        /// 本地文件资源广播 
        /// </summary>
        GBTYPE_LCA_FILES = 2,
        /// <summary>
        /// 服务器文件资源广播
        /// </summary>
        GBTYPE_SERVER_FILES = 1
    }
}
