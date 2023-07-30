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
    /// SDK代理
    /// </summary>
    public interface IIPGBNETSdkProxy
    {
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="ConnStaCallBack"></param>
        /// <param name="dwUser"></param>
        void IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser);
        /// <summary>
        /// 设置单个终端状态回调
        /// </summary>
        /// <param name="TerminalStatusCallBack"></param>
        /// <param name="dwUser"></param>
        void IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置批量终端状态回调
        /// </summary>
        void IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置编码类型终端状态回调
        /// </summary>
        void IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置广播流状态回调
        /// </summary>
        void IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser);
        /// <summary>
        /// 设置消防状态回调
        /// </summary>
        void IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser);
        /// <summary>
        /// SDK初始化
        /// </summary>
        /// <param name="Aport">使用第三方音源传输音频数据时监听的TCP端口号</param>
        /// <returns>返回0成功</returns>  
        int IPGBNETSDK_Init(ushort Aport);
        /// <summary>
        /// SDK退出清理
        /// </summary>
        void IPGBNETSDK_Cleanup();
        /// <summary>
        /// 获取SDK版本
        /// 2个高字节表示主版本，2个低字节表示次版本。如0x00010003：表示版本为1.3
        /// </summary>
        /// <returns></returns>
        uint IPGBNETSDK_GetSdkVer();
        /// <summary>
        /// 登陆服务器
        /// </summary>
        /// <param name="lpSer">登陆信息</param>
        /// <returns>成功返回用户ID(大于0)  </returns>
        int IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer);
        /// <summary>
        /// 断开与服务器连接
        /// </summary>
        /// <param name="UserId">用户ID</param>
        void IPGBNETSDK_LogOut(uint UserId);
        /// <summary>
        /// 获取连接状态,同时返回用户数据
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="lpUserInfo">当前连接成功时返回用户信息</param>
        /// <returns>返回连接状态</returns>
        NETEM_SDKLOGSTA_TYPE IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo);
        /// <summary>
        /// 获取服务器文件资源
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="Finfo">输出单个文件信息</param>
        /// <param name="ISFirst">当为True时从资源目录超始位开始</param>
        /// <returns>返回0时成功</returns>
        int IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst);
        /// <summary>
        /// 获取得到系统的声卡信息
        /// </summary>
        /// <param name="SoundInfo">输出系统声卡混音接口</param>
        void IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo);
        /// <summary>
        /// 设置系统声卡混音接口音量或选择此混音接口为系统默认接口
        /// </summary>
        /// <param name="CapMixName">混音接口名</param>
        /// <param name="SetType">设置类型 1:设置音量  2:设置系统默认接口</param>
        /// <param name="MVal">当SetType=1时的音量值 0-100</param>
        void IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal);
        /// <summary>
        /// 创建服务器文件广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo);
        /// <summary>
        /// 创建本地文件广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo);
        /// <summary>
        /// 创建文本广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo);
        /// <summary>
        /// 创建终端采广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo);
        /// <summary>
        /// 创建编码终端采广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo);
        /// <summary>
        /// 创建本地声卡采集编码源通道
        /// </summary>
        /// <param name="pSrcinfo">编码信息</param>
        /// <returns>成功返回通道ID（大于0）</returns>
        int IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo);
        /// <summary>
        /// 创建本地声卡广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo);
        /// <summary>
        /// 创建第三方实时流编码源通道
        /// </summary>
        /// <param name="pSrcinfo">编码信息</param>
        /// <param name="outdesb">输出用于网络数据传输的8个字节认证内容</param>
        /// <returns>成功返回编码通道ID（大于0）</returns>
        int IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb);
        /// <summary>
        /// 向第三方实时流编码源通道输入相应格式的音频数据
        /// </summary>
        /// <param name="ASrcId">编码通道ID</param>
        /// <param name="buf">音频数据</param>
        /// <param name="len">音频数据长度</param>
        /// <returns>成功返回等于len</returns>
        int IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len);
        /// <summary>
        /// 创建第三实时流广播
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pGbinfo">广播信息</param>
        /// <returns>成功返回广播流ID（大于0）</returns>
        int IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo);
        /// <summary>
        /// 删除一个编码源通道
        /// </summary>
        /// <param name="ASrcId">编码通道ID</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId);
        /// <summary>
        /// 删除一个广播流
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="StreamId">广播流ID</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_DelOneStream(uint UserId, uint StreamId);
        /// <summary>
        /// 调节终端输出音量
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pVol">调节终端音量信息</param>
        /// <returns></returns>
        int IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol);
        /// <summary>
        /// 触发第三方消防系统接口信号   (需要用户权限为18级)
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="FirePinInfo">消防信号值</param>
        /// <param name="PinType">控制类型 1:触发相应信号的警报  2:删除相应信号的警报</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType);
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="FilePath">本地MP3文件目录</param>
        /// <param name="pMp3Fileinfo">输出文件信息</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo);
        /// <summary>
        /// 控制两个终端建立对讲(终端只能在一个服务器节点内)
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="MainTmID">主叫终端ID</param>
        /// <param name="otherTmid">被叫终端ID</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid);
        /// <summary>
        /// 控制终端断开呼叫对讲或接通呼叫对讲
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="TmID">终端ID</param>
        /// <param name="CtlType">控制类型(1:接通  2:断开)</param>
        /// <returns>成功返回0</returns>
        int IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType);

        /// <summary>
        /// 获取用户终端分区信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <param name="pFqInfo">分区信息</param>
        /// <returns></returns>
        int IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo);
    }
}
