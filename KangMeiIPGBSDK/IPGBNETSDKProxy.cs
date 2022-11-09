using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
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
    internal class IPGBNETSdkDller : IIPGBNETSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIPGBNETSdkProxy Instance { get; } = new IPGBNETSdkDller();
        private IPGBNETSdkDller() { }
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.GetFullPath(IPGBNETSdk.DllFileName);
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="ConnStaCallBack"></param>
        /// <param name="dwUser"></param>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser);
        /// <summary>
        /// 设置单个终端状态回调
        /// </summary>
        /// <param name="TerminalStatusCallBack"></param>
        /// <param name="dwUser"></param>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置批量终端状态回调
        /// </summary>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置编码类型终端状态回调
        /// </summary>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置广播流状态回调
        /// </summary>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser);
        /// <summary>
        /// 设置消防状态回调
        /// </summary>
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser);
        /**
         * SDK初始化
         * @param  Aport         (in)   使用第三方音源传输音频数据时监听的TCP端口号
         * @return ->返回0成功
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_Init(ushort Aport);

        /**
         * SDK退出清理
         * @return 
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_Cleanup();

        /**
         * 获取SDK版本
         * @return ->获取SDK版本 2个高字节表示主版本，2个低字节表示次版本。如0x00010003：表示版本为1.3
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern uint IPGBNETSDK_GetSdkVer();

        /**
         * 登陆服务器
         * @param  lpSer         (in)   登陆信息
         * @return ->成功返回用户ID(大于0)  
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer);

        /**
         * 断开与服务器连接
         * @param  UserId       (in)   用户ID
         * @return 
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_LogOut(uint UserId);

        /**
         * 获取连接状态,同时返回用户数据
         * @param  UserId              (in)    用户ID
         * @param  lpUserInfo          (out)   当前连接成功时返回用户信息
         * @return   ->返回连接状态
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern NETEM_SDKLOGSTA_TYPE IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo);

        /**
         * 获取服务器文件资源 
         * @param  UserId              (in)    用户ID
         * @param  Finfo               (out)   输出单个文件信息
         * @param  ISFirst             (in)    当为True时从资源目录超始位开始
         * @return   ->返回0时成功
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst);

        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo);

        /**
         * 设置系统声卡混音接口音量或选择此混音接口为系统默认接口
         * @param  CapMixName              (in)    混音接口名
         * @param  SetType                 (in)    设置类型 1:设置音量  2:设置系统默认接口
         * @param  MVal                    (in)    当SetType=1时的音量值 0-100
         * @return   
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern void IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal);

        /**
         * 创建服务器文件广播 
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo);

        /**
         * 创建本地文件广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo);

        /**
         * 创建文本广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo);

        /**
         * 创建终端采广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo);

        /**
         * 创建编码终端采广播 
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo);

        /**
         * 创建本地声卡采集编码源通道
         * @param  pSrcinfo             (in)    编码信息
         * @return   ->成功返回通道ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo);

        /**
         * 创建本地声卡广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo);

        /**
         * 创建第三方实时流编码源通道
         * @param  pSrcinfo             (in)     编码信息
         * @param  outdesb              (out)    输出用于网络数据传输的8个字节认证内容
         * @return   ->成功返回编码通道ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb);

        /**
         * 向第三方实时流编码源通道输入相应格式的音频数据
         * @param  ASrcId          (in)    编码通道ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len);

        /**
         * 创建第三实时流广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo);

        /**
         * 删除一个编码源通道
         * @param  ASrcId              (in)     编码通道ID
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId);

        /**
         * 删除一个广播流
         * @param  UserId              (in)     用户ID
         * @param  StreamId            (in)     广播流ID
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_DelOneStream(uint UserId, uint StreamId);

        /**
         * 调节终端输出音量
         * @param  UserId              (in)     用户ID
         * @param  pVol                (in)     调节终端音量信息
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol);

        /**
         * 触发第三方消防系统接口信号   (需要用户权限为18级)
         * @param   UserId              (in)     用户ID
         * @param   FirePinInfo         (in)     消防信号值
         * @param   PinType             (in)     控制类型 1:触发相应信号的警报  2:删除相应信号的警报
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType);

        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo);

        /**
         * 控制两个终端建立对讲(终端只能在一个服务器节点内)
         * @param   UserId                (in)      用户ID
         * @param   MainTmID              (in)      主叫终端ID
         * @param  otherTmid             (in)      被叫终端ID
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid);

        /**
         * 控制终端断开呼叫对讲或接通呼叫对讲
         * @param   UserId                (in)      用户ID
         * @param   TmID                  (in)      终端ID
         * @param   CtlType               (in)      控制类型(1:接通  2:断开)
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType);

        /**
         * 获取用户终端分区信息
         * @param   UserId                (in)      用户ID
         * @param   pFqInfo               (out)     分区信息
         * @return   ->成功返回0
         **/
        [DllImport(IPGBNETSdk.DllFileName)]
        public static extern int IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo);
        #region // 显示实现
        void IIPGBNETSdkProxy.IPGBNETSDK_Cleanup() => IPGBNETSDK_Cleanup();
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo) => IPGBNETSDK_CreateEncTerminalCbStream(UserId, pGbinfo);

        int IIPGBNETSdkProxy.IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo) => IPGBNETSDK_CreateLcaFileGbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo) => IPGBNETSDK_CreateSerFileGbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo) => IPGBNETSDK_CreateSoundCarGbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo) => IPGBNETSDK_CreateSoundCarSrcChannel(pSrcinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo) => IPGBNETSDK_CreateTerminalCbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo) => IPGBNETSDK_CreateTextGbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo) => IPGBNETSDK_CreateThirdRealAudioGbStream(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb) => IPGBNETSDK_CreateThirdRealSrcChannel(pSrcinfo, out outdesb);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid) => IPGBNETSDK_CtrlAnyTmForCall(UserId, MainTmID, otherTmid);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType) => IPGBNETSDK_CtrlAnyTmTalkStatus(UserId, TmID, CtlType);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId) => IPGBNETSDK_DelOneAudioSrcChannel(ASrcId);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneStream(uint UserId, uint StreamId) => IPGBNETSDK_DelOneStream(UserId, StreamId);
        int IIPGBNETSdkProxy.IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len) => IPGBNETSDK_FillDataToThirdRealSrcChannel(ASrcId, buf, len);
        NETEM_SDKLOGSTA_TYPE IIPGBNETSdkProxy.IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo) => IPGBNETSDK_GetConnStatusInfo(UserId, out lpUserInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo) => IPGBNETSDK_GetMp3FileInfo(FilePath, out pMp3Fileinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst) => IPGBNETSDK_GetOneSerFileInfo(UserId, out Finfo, ISFirst);
        uint IIPGBNETSdkProxy.IPGBNETSDK_GetSdkVer() => IPGBNETSDK_GetSdkVer();
        void IIPGBNETSdkProxy.IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo) => IPGBNETSDK_GetSysSoundCardINFO(out SoundInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo) => IPGBNETSDK_GetUserFqInfo(UserId, out pFqInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_Init(ushort Aport) => IPGBNETSDK_Init(Aport);
        int IIPGBNETSdkProxy.IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer) => IPGBNETSDK_LogIn(lpSer);
        void IIPGBNETSdkProxy.IPGBNETSDK_LogOut(uint UserId) => IPGBNETSDK_LogOut(UserId);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser) => IPGBNETSDK_SetBatchTerminalStatusCallBack(TerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser) => IPGBNETSDK_SetConnStatusCallBack(ConnStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser) => IPGBNETSDK_SetEncTerminalStatusCallBack(EncTerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser) => IPGBNETSDK_SetFireStaCallBack(FireStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser) => IPGBNETSDK_SetGbStreamStatusCallBack(StreamStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal) => IPGBNETSDK_SetSysSoundCardMix(CapMixName, SetType, MVal);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser) => IPGBNETSDK_SetTerminalStatusCallBack(TerminalStatusCallBack, dwUser);
        int IIPGBNETSdkProxy.IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol) => IPGBNETSDK_SetTmOutVol(UserId, pVol);
        int IIPGBNETSdkProxy.IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType) => IPGBNETSDK_ThreeFireArm(UserId, FirePinInfo, PinType);
        #endregion
    }
    internal class IPGBNETSdkLoader : ASdkDynamicLoader, IIPGBNETSdkProxy
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllPath = @"plugins\kangmeiipgbsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(Path.GetFullPath(DllPath), IPGBNETSdk.DllFileName);
        #region // 委托定义
        private DCreater.IPGBNETSDK_SetConnStatusCallBack _IPGBNETSDK_SetConnStatusCallBack;
        private DCreater.IPGBNETSDK_SetTerminalStatusCallBack _IPGBNETSDK_SetTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack _IPGBNETSDK_SetBatchTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack _IPGBNETSDK_SetEncTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetGbStreamStatusCallBack _IPGBNETSDK_SetGbStreamStatusCallBack;
        private DCreater.IPGBNETSDK_SetFireStaCallBack _IPGBNETSDK_SetFireStaCallBack;
        private DCreater.IPGBNETSDK_Init _IPGBNETSDK_Init;
        private DCreater.IPGBNETSDK_Cleanup _IPGBNETSDK_Cleanup;
        private DCreater.IPGBNETSDK_GetSdkVer _IPGBNETSDK_GetSdkVer;
        private DCreater.IPGBNETSDK_LogIn _IPGBNETSDK_LogIn;
        private DCreater.IPGBNETSDK_LogOut _IPGBNETSDK_LogOut;
        private DCreater.IPGBNETSDK_GetConnStatusInfo _IPGBNETSDK_GetConnStatusInfo;
        private DCreater.IPGBNETSDK_GetOneSerFileInfo _IPGBNETSDK_GetOneSerFileInfo;
        private DCreater.IPGBNETSDK_GetSysSoundCardINFO _IPGBNETSDK_GetSysSoundCardINFO;
        private DCreater.IPGBNETSDK_SetSysSoundCardMix _IPGBNETSDK_SetSysSoundCardMix;
        private DCreater.IPGBNETSDK_CreateSerFileGbStream _IPGBNETSDK_CreateSerFileGbStream;
        private DCreater.IPGBNETSDK_CreateLcaFileGbStream _IPGBNETSDK_CreateLcaFileGbStream;
        private DCreater.IPGBNETSDK_CreateTextGbStream _IPGBNETSDK_CreateTextGbStream;
        private DCreater.IPGBNETSDK_CreateTerminalCbStream _IPGBNETSDK_CreateTerminalCbStream;
        private DCreater.IPGBNETSDK_CreateEncTerminalCbStream _IPGBNETSDK_CreateEncTerminalCbStream;
        private DCreater.IPGBNETSDK_CreateSoundCarSrcChannel _IPGBNETSDK_CreateSoundCarSrcChannel;
        private DCreater.IPGBNETSDK_CreateSoundCarGbStream _IPGBNETSDK_CreateSoundCarGbStream;
        private DCreater.IPGBNETSDK_CreateThirdRealSrcChannel _IPGBNETSDK_CreateThirdRealSrcChannel;
        private DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel _IPGBNETSDK_FillDataToThirdRealSrcChannel;
        private DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream _IPGBNETSDK_CreateThirdRealAudioGbStream;
        private DCreater.IPGBNETSDK_DelOneAudioSrcChannel _IPGBNETSDK_DelOneAudioSrcChannel;
        private DCreater.IPGBNETSDK_DelOneStream _IPGBNETSDK_DelOneStream;
        private DCreater.IPGBNETSDK_SetTmOutVol _IPGBNETSDK_SetTmOutVol;
        private DCreater.IPGBNETSDK_ThreeFireArm _IPGBNETSDK_ThreeFireArm;
        private DCreater.IPGBNETSDK_GetMp3FileInfo _IPGBNETSDK_GetMp3FileInfo;
        private DCreater.IPGBNETSDK_CtrlAnyTmForCall _IPGBNETSDK_CtrlAnyTmForCall;
        private DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus _IPGBNETSDK_CtrlAnyTmTalkStatus;
        private DCreater.IPGBNETSDK_GetUserFqInfo _IPGBNETSDK_GetUserFqInfo;
        #endregion
        public IPGBNETSdkLoader()
        {
            hModule = LoadLibraryEx(DllFullName, IntPtr.Zero, LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);

            _IPGBNETSDK_SetConnStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetConnStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetConnStatusCallBack));
            _IPGBNETSDK_SetTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetTerminalStatusCallBack));
            _IPGBNETSDK_SetBatchTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack));
            _IPGBNETSDK_SetEncTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack));
            _IPGBNETSDK_SetGbStreamStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetGbStreamStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetGbStreamStatusCallBack));
            _IPGBNETSDK_SetFireStaCallBack = GetDelegate<DCreater.IPGBNETSDK_SetFireStaCallBack>(nameof(DCreater.IPGBNETSDK_SetFireStaCallBack));
            _IPGBNETSDK_Init = GetDelegate<DCreater.IPGBNETSDK_Init>(nameof(DCreater.IPGBNETSDK_Init));
            _IPGBNETSDK_Cleanup = GetDelegate<DCreater.IPGBNETSDK_Cleanup>(nameof(DCreater.IPGBNETSDK_Cleanup));
            _IPGBNETSDK_GetSdkVer = GetDelegate<DCreater.IPGBNETSDK_GetSdkVer>(nameof(DCreater.IPGBNETSDK_GetSdkVer));
            _IPGBNETSDK_LogIn = GetDelegate<DCreater.IPGBNETSDK_LogIn>(nameof(DCreater.IPGBNETSDK_LogIn));
            _IPGBNETSDK_LogOut = GetDelegate<DCreater.IPGBNETSDK_LogOut>(nameof(DCreater.IPGBNETSDK_LogOut));
            _IPGBNETSDK_GetConnStatusInfo = GetDelegate<DCreater.IPGBNETSDK_GetConnStatusInfo>(nameof(DCreater.IPGBNETSDK_GetConnStatusInfo));
            _IPGBNETSDK_GetOneSerFileInfo = GetDelegate<DCreater.IPGBNETSDK_GetOneSerFileInfo>(nameof(DCreater.IPGBNETSDK_GetOneSerFileInfo));
            _IPGBNETSDK_GetSysSoundCardINFO = GetDelegate<DCreater.IPGBNETSDK_GetSysSoundCardINFO>(nameof(DCreater.IPGBNETSDK_GetSysSoundCardINFO));
            _IPGBNETSDK_SetSysSoundCardMix = GetDelegate<DCreater.IPGBNETSDK_SetSysSoundCardMix>(nameof(DCreater.IPGBNETSDK_SetSysSoundCardMix));
            _IPGBNETSDK_CreateSerFileGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateSerFileGbStream>(nameof(DCreater.IPGBNETSDK_CreateSerFileGbStream));
            _IPGBNETSDK_CreateLcaFileGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateLcaFileGbStream>(nameof(DCreater.IPGBNETSDK_CreateLcaFileGbStream));
            _IPGBNETSDK_CreateTextGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateTextGbStream>(nameof(DCreater.IPGBNETSDK_CreateTextGbStream));
            _IPGBNETSDK_CreateTerminalCbStream = GetDelegate<DCreater.IPGBNETSDK_CreateTerminalCbStream>(nameof(DCreater.IPGBNETSDK_CreateTerminalCbStream));
            _IPGBNETSDK_CreateEncTerminalCbStream = GetDelegate<DCreater.IPGBNETSDK_CreateEncTerminalCbStream>(nameof(DCreater.IPGBNETSDK_CreateEncTerminalCbStream));
            _IPGBNETSDK_CreateSoundCarSrcChannel = GetDelegate<DCreater.IPGBNETSDK_CreateSoundCarSrcChannel>(nameof(DCreater.IPGBNETSDK_CreateSoundCarSrcChannel));
            _IPGBNETSDK_CreateSoundCarGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateSoundCarGbStream>(nameof(DCreater.IPGBNETSDK_CreateSoundCarGbStream));
            _IPGBNETSDK_CreateThirdRealSrcChannel = GetDelegate<DCreater.IPGBNETSDK_CreateThirdRealSrcChannel>(nameof(DCreater.IPGBNETSDK_CreateThirdRealSrcChannel));
            _IPGBNETSDK_FillDataToThirdRealSrcChannel = GetDelegate<DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel>(nameof(DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel));
            _IPGBNETSDK_CreateThirdRealAudioGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream>(nameof(DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream));
            _IPGBNETSDK_DelOneAudioSrcChannel = GetDelegate<DCreater.IPGBNETSDK_DelOneAudioSrcChannel>(nameof(DCreater.IPGBNETSDK_DelOneAudioSrcChannel));
            _IPGBNETSDK_DelOneStream = GetDelegate<DCreater.IPGBNETSDK_DelOneStream>(nameof(DCreater.IPGBNETSDK_DelOneStream));
            _IPGBNETSDK_SetTmOutVol = GetDelegate<DCreater.IPGBNETSDK_SetTmOutVol>(nameof(DCreater.IPGBNETSDK_SetTmOutVol));
            _IPGBNETSDK_ThreeFireArm = GetDelegate<DCreater.IPGBNETSDK_ThreeFireArm>(nameof(DCreater.IPGBNETSDK_ThreeFireArm));
            _IPGBNETSDK_GetMp3FileInfo = GetDelegate<DCreater.IPGBNETSDK_GetMp3FileInfo>(nameof(DCreater.IPGBNETSDK_GetMp3FileInfo));
            _IPGBNETSDK_CtrlAnyTmForCall = GetDelegate<DCreater.IPGBNETSDK_CtrlAnyTmForCall>(nameof(DCreater.IPGBNETSDK_CtrlAnyTmForCall));
            _IPGBNETSDK_CtrlAnyTmTalkStatus = GetDelegate<DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus>(nameof(DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus));
            _IPGBNETSDK_GetUserFqInfo = GetDelegate<DCreater.IPGBNETSDK_GetUserFqInfo>(nameof(DCreater.IPGBNETSDK_GetUserFqInfo));
        }
        #region // 显示实现
        void IIPGBNETSdkProxy.IPGBNETSDK_Cleanup() => _IPGBNETSDK_Cleanup.Invoke();
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo) => _IPGBNETSDK_CreateEncTerminalCbStream.Invoke(UserId, pGbinfo);

        int IIPGBNETSdkProxy.IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo) => _IPGBNETSDK_CreateLcaFileGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo) => _IPGBNETSDK_CreateSerFileGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo) => _IPGBNETSDK_CreateSoundCarGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo) => _IPGBNETSDK_CreateSoundCarSrcChannel.Invoke(pSrcinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo) => _IPGBNETSDK_CreateTerminalCbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo) => _IPGBNETSDK_CreateTextGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo) => _IPGBNETSDK_CreateThirdRealAudioGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb) => _IPGBNETSDK_CreateThirdRealSrcChannel.Invoke(pSrcinfo, out outdesb);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid) => _IPGBNETSDK_CtrlAnyTmForCall.Invoke(UserId, MainTmID, otherTmid);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType) => _IPGBNETSDK_CtrlAnyTmTalkStatus.Invoke(UserId, TmID, CtlType);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId) => _IPGBNETSDK_DelOneAudioSrcChannel.Invoke(ASrcId);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneStream(uint UserId, uint StreamId) => _IPGBNETSDK_DelOneStream.Invoke(UserId, StreamId);
        int IIPGBNETSdkProxy.IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len) => _IPGBNETSDK_FillDataToThirdRealSrcChannel.Invoke(ASrcId, buf, len);
        NETEM_SDKLOGSTA_TYPE IIPGBNETSdkProxy.IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo) => _IPGBNETSDK_GetConnStatusInfo.Invoke(UserId, out lpUserInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo) => _IPGBNETSDK_GetMp3FileInfo.Invoke(FilePath, out pMp3Fileinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst) => _IPGBNETSDK_GetOneSerFileInfo.Invoke(UserId, out Finfo, ISFirst);
        uint IIPGBNETSdkProxy.IPGBNETSDK_GetSdkVer() => _IPGBNETSDK_GetSdkVer.Invoke();
        void IIPGBNETSdkProxy.IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo) => _IPGBNETSDK_GetSysSoundCardINFO.Invoke(out SoundInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo) => _IPGBNETSDK_GetUserFqInfo.Invoke(UserId, out pFqInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_Init(ushort Aport) => _IPGBNETSDK_Init.Invoke(Aport);
        int IIPGBNETSdkProxy.IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer) => _IPGBNETSDK_LogIn.Invoke(lpSer);
        void IIPGBNETSdkProxy.IPGBNETSDK_LogOut(uint UserId) => _IPGBNETSDK_LogOut.Invoke(UserId);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetBatchTerminalStatusCallBack.Invoke(TerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser) => _IPGBNETSDK_SetConnStatusCallBack.Invoke(ConnStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetEncTerminalStatusCallBack.Invoke(EncTerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser) => _IPGBNETSDK_SetFireStaCallBack.Invoke(FireStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser) => _IPGBNETSDK_SetGbStreamStatusCallBack.Invoke(StreamStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal) => _IPGBNETSDK_SetSysSoundCardMix.Invoke(CapMixName, SetType, MVal);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetTerminalStatusCallBack.Invoke(TerminalStatusCallBack, dwUser);
        int IIPGBNETSdkProxy.IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol) => _IPGBNETSDK_SetTmOutVol.Invoke(UserId, pVol);
        int IIPGBNETSdkProxy.IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType) => _IPGBNETSDK_ThreeFireArm.Invoke(UserId, FirePinInfo, PinType);
        #endregion
    }
}
