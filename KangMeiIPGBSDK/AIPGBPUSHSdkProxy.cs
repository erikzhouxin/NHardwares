using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 推流SDK代理
    /// </summary>
    public interface IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 设置推流状态回调函数
        /// </summary>
        /// <param name="pFunc">回调函数地址</param>
        /// <param name="puser">用户类指针</param>
        void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /// <summary>
        /// SDK初始化
        /// </summary>
        /// <returns>返回0成功</returns>
        int IPGBPUSHSTREAM_Init();
        /// <summary>
        /// SDK退出清理
        /// </summary>
        void IPGBPUSHSTREAM_Cleanup();
        /// <summary>
        /// 获取得到系统的声卡信息
        /// </summary>
        /// <param name="SoundInfo">输出系统声卡混音接口</param>
        void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /// <summary>
        /// 设置系统声卡混音接口音量
        /// </summary>
        /// <param name="CapMixName">混音接口名</param>
        /// <param name="MVal">音量值 0-100</param>
        void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /// <summary>
        /// 创建实时声卡采集推流
        /// </summary>
        /// <param name="pSrcinfo">推流信息</param>
        /// <returns>成功返回推流ID（大于0）</returns>
        int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /// <summary>
        /// 创建本地第三方音频流推流
        /// </summary>
        /// <param name="pSrcinfo">推流信息</param>
        /// <returns>成功返回推流ID（大于0）</returns>
        int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /// <summary>
        /// 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
        /// </summary>
        /// <param name="StreamId">推流ID</param>
        /// <param name="buf">音频数据</param>
        /// <param name="len">音频数据长度</param>
        /// <returns>成功返回等于len</returns>
        int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /// <summary>
        /// 删除一个推流
        /// </summary>
        /// <param name="StreamId">推流ID</param>
        void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="FilePath">本地MP3文件目录</param>
        /// <param name="pMp3Fileinfo">输出文件信息</param>
        /// <returns>成功返回0</returns>
        int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
    }
}
