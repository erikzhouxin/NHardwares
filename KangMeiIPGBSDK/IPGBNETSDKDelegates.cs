using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /***********************************************************************
     ** 回调函数定义  注意:禁止在回调函数中调用SDK的API 和操作UI界面,会出现死锁情况
    ***********************************************************************/
    /// <summary>
    /// 登录状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="ISConn">连接或断开  (1:连接,0:断开)</param>
    /// <param name="lpUserInfo">当连接成功时输出用户信息</param>
    /// <param name="dwUser"><用户类指针/param>
    public delegate void SDKfConnectStatus(int UserId, byte ISConn, IPGBSDK_USERINFO lpUserInfo, long dwUser);
    /// <summary>
    /// 单个终端状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="lpTmInfo">单个终端状态信息</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfTerminalStatus(int UserId, IPGBSDK_TMINFO lpTmInfo, long dwUser);
    /// <summary>
    ///  批量终端状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="lpTmInfo">批量终端状态信息</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfBatchTerminalStatus(int UserId, IPGBSDK_CALLBACKTMINFO lpTmInfo, long dwUser);
    /// <summary>
    /// 编码类型终端状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="lpTmInfo">单个终端状态信息</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfEncTerminalStatus(int UserId, IPGBSDK_ENCTMINFO lpTmInfo, long dwUser);
    /// <summary>
    /// 广播流状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="StreamId">流ID</param>
    /// <param name="StreamSta">流状态</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfGbStreamStatus(int UserId, int StreamId, int StreamSta, long dwUser);
    /// <summary>
    /// 消防状态回调函数原形
    /// </summary>
    /// <param name="UserId">用户ID</param>
    /// <param name="lpFireInfo">触发的消防信息</param>
    /// <param name="dwUser">用户类指针</param>
    public delegate void SDKfFireSta(int UserId, IPGBSDK_FIREINFO lpFireInfo, long dwUser);
    internal class DCreater
    {
        /// <summary>
        /// 设置登录状态回调
        /// </summary>
        /// <param name="ConnStaCallBack"></param>
        /// <param name="dwUser"></param>
        public delegate void IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser);
        /// <summary>
        /// 设置单个终端状态回调
        /// </summary>
        /// <param name="TerminalStatusCallBack"></param>
        /// <param name="dwUser"></param>
        public delegate void IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置批量终端状态回调
        /// </summary>
        public delegate void IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置编码类型终端状态回调
        /// </summary>
        public delegate void IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser);
        /// <summary>
        /// 设置广播流状态回调
        /// </summary>
        public delegate void IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser);
        /// <summary>
        /// 设置消防状态回调
        /// </summary>
        public delegate void IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser);
        /**
         * SDK初始化
         * @param  Aport         (in)   使用第三方音源传输音频数据时监听的TCP端口号
         * @return ->返回0成功
         **/
        public delegate int IPGBNETSDK_Init(ushort Aport);

        /**
         * SDK退出清理
         * @return 
         **/
        public delegate void IPGBNETSDK_Cleanup();

        /**
         * 获取SDK版本
         * @return ->获取SDK版本 2个高字节表示主版本，2个低字节表示次版本。如0x00010003：表示版本为1.3
         **/
        public delegate uint IPGBNETSDK_GetSdkVer();

        /**
         * 登陆服务器
         * @param  lpSer         (in)   登陆信息
         * @return ->成功返回用户ID(大于0)  
         **/
        public delegate int IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer);

        /**
         * 断开与服务器连接
         * @param  UserId       (in)   用户ID
         * @return 
         **/
        public delegate void IPGBNETSDK_LogOut(uint UserId);

        /**
         * 获取连接状态,同时返回用户数据
         * @param  UserId              (in)    用户ID
         * @param  lpUserInfo          (out)   当前连接成功时返回用户信息
         * @return   ->返回连接状态
         **/
        public delegate NETEM_SDKLOGSTA_TYPE IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo);

        /**
         * 获取服务器文件资源 
         * @param  UserId              (in)    用户ID
         * @param  Finfo               (out)   输出单个文件信息
         * @param  ISFirst             (in)    当为True时从资源目录超始位开始
         * @return   ->返回0时成功
         **/
        public delegate int IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst);

        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        public delegate void IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo);

        /**
         * 设置系统声卡混音接口音量或选择此混音接口为系统默认接口
         * @param  CapMixName              (in)    混音接口名
         * @param  SetType                 (in)    设置类型 1:设置音量  2:设置系统默认接口
         * @param  MVal                    (in)    当SetType=1时的音量值 0-100
         * @return   
         **/
        public delegate void IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal);

        /**
         * 创建服务器文件广播 
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo);

        /**
         * 创建本地文件广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo);

        /**
         * 创建文本广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo);

        /**
         * 创建终端采广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo);

        /**
         * 创建编码终端采广播 
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo);

        /**
         * 创建本地声卡采集编码源通道
         * @param  pSrcinfo             (in)    编码信息
         * @return   ->成功返回通道ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo);

        /**
         * 创建本地声卡广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo);

        /**
         * 创建第三方实时流编码源通道
         * @param  pSrcinfo             (in)     编码信息
         * @param  outdesb              (out)    输出用于网络数据传输的8个字节认证内容
         * @return   ->成功返回编码通道ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb);

        /**
         * 向第三方实时流编码源通道输入相应格式的音频数据
         * @param  ASrcId          (in)    编码通道ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        public delegate int IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len);

        /**
         * 创建第三实时流广播
         * @param  UserId              (in)    用户ID
         * @param  pGbinfo             (in)    广播信息
         * @return   ->成功返回广播流ID（大于0）
         **/
        public delegate int IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo);

        /**
         * 删除一个编码源通道
         * @param  ASrcId              (in)     编码通道ID
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId);

        /**
         * 删除一个广播流
         * @param  UserId              (in)     用户ID
         * @param  StreamId            (in)     广播流ID
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_DelOneStream(uint UserId, uint StreamId);

        /**
         * 调节终端输出音量
         * @param  UserId              (in)     用户ID
         * @param  pVol                (in)     调节终端音量信息
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol);

        /**
         * 触发第三方消防系统接口信号   (需要用户权限为18级)
         * @param   UserId              (in)     用户ID
         * @param   FirePinInfo         (in)     消防信号值
         * @param   PinType             (in)     控制类型 1:触发相应信号的警报  2:删除相应信号的警报
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType);

        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo);

        /**
         * 控制两个终端建立对讲(终端只能在一个服务器节点内)
         * @param   UserId                (in)      用户ID
         * @param   MainTmID              (in)      主叫终端ID
         * @param  otherTmid             (in)      被叫终端ID
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid);

        /**
         * 控制终端断开呼叫对讲或接通呼叫对讲
         * @param   UserId                (in)      用户ID
         * @param   TmID                  (in)      终端ID
         * @param   CtlType               (in)      控制类型(1:接通  2:断开)
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType);

        /**
         * 获取用户终端分区信息
         * @param   UserId                (in)      用户ID
         * @param   pFqInfo               (out)     分区信息
         * @return   ->成功返回0
         **/
        public delegate int IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo);
    }
}
