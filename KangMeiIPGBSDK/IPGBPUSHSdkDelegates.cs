using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 推流状态回调函数原形
    /// </summary>
    /// <param name="PID">推流ID</param>
    /// <param name="PSta">推流状态</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfPushStatus(int PID, NETEM_PUSHSTREAMSTA_TYPE PSta, long dwUser);
    internal partial class DCreater
    {
        /**
         * 设置推流状态回调函数
         * @param  pFunc               (in)   回调函数地址
         * @param  puser               (in)   用户类指针
         * @return  
         **/
        public delegate void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /**
         * SDK初始化
         * @return ->返回0成功
         **/
        public delegate int IPGBPUSHSTREAM_Init();
        /**
         * SDK退出清理
         * @return 
         **/
        public delegate void IPGBPUSHSTREAM_Cleanup();
        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        public delegate void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /**
         * 设置系统声卡混音接口音量
         * @param  CapMixName              (in)    混音接口名
         * @param  MVal                    (in)    音量值 0-100
         * @return   
         **/
        public delegate void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /**
         * 创建实时声卡采集推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        public delegate int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /**
         * 创建本地第三方音频流推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        public delegate int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /**
         * 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
         * @param  StreamId        (in)    推流ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        public delegate int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /**
         * 删除一个推流
         * @param  StreamId             (in)    推流ID
         * @return 
         **/
        public delegate void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        public delegate int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
    }
}
