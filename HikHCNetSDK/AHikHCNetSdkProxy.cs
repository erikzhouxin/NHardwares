using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// HCNetSdk代理
    /// </summary>
    public interface IHikHCNetSdkProxy
    {
        /// <summary>
        /// 发送或接受远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpInBuff"></param>
        /// <param name="dwInBuffSize"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <param name="dwOutDataLen"></param>
        /// <returns></returns>
        int NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);
        /// <summary>
        /// 发送或接受远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpInBuff"></param>
        /// <param name="dwInBuffSize"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <param name="dwOutDataLen"></param>
        /// <returns></returns>
        int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);
        /// <summary>
        /// 发送或接收远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpInBuff"></param>
        /// <param name="dwInBuffSize"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <param name="dwOutDataLen"></param>
        /// <returns></returns>
        int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);
        /// <summary>
        /// 标准XML配置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpInputParam"></param>
        /// <param name="lpOutputParam"></param>
        /// <returns></returns>
        bool NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);
        /// <summary>
        /// remote control gateway
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lGatewayIndex">1-begin 0xffffffff-all</param>
        /// <param name="dwStaic">0-close，1-open，2-always open，3-always close</param>
        /// <returns></returns>
        bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);
        /// <summary>
        /// Alarm information registered callback function
        /// </summary>
        /// <param name="iIndex">iIndex, scope:[0,15] </param>
        /// <param name="fMessageCallBack">callback function</param>
        /// <param name="pUser">user data</param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 获取下一个远程配置
        /// </summary>
        /// <param name="lHandle"></param>
        /// <param name="lpOutBuff"></param>
        /// <param name="dwOutBuffSize"></param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);
        /// <summary>
        /// 初始化SDK，调用其他SDK函数的前提。
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败。</returns>
        bool NET_DVR_Init();
        /// <summary>
        /// 释放SDK资源，在结束之前最后调用
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        bool NET_DVR_Cleanup();
        /// <summary>
        /// 设置硬盘录像机消息
        /// </summary>
        /// <param name="nMessage"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);
        /// <summary>
        /// 设置异常回调
        /// </summary>
        /// <param name="nMessage"></param>
        /// <param name="hWnd"></param>
        /// <param name="fExceptionCallBack"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);
        /// <summary>
        /// 设置硬盘录像机消息回调
        /// </summary>
        /// <param name="fMessCallBack"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);
        /// <summary>
        /// 设置硬盘录像机消息回调扩展
        /// </summary>
        /// <param name="fMessCallBack_EX"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);
        /// <summary>
        /// 设置硬盘录像机消息回调新
        /// </summary>
        /// <param name="fMessCallBack_NEW"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);
        /// <summary>
        /// 设置硬盘录像机消息回调
        /// </summary>
        /// <param name="fMessageCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);
        /// <summary>
        /// 设置硬盘录像机消息回调
        /// </summary>
        /// <param name="fMessageCallBack"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);
        /// <summary>
        /// 设置硬盘录像机消息回调
        /// </summary>
        /// <param name="fMessageCallBack"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);
        /// <summary>
        /// 设置SDK本地上下文
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="lpInBuff"></param>
        /// <returns></returns>
        bool NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff);
        /// <summary>
        /// 获取SDK本地上下文
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="lpOutBuff"></param>
        /// <returns></returns>
        bool NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff);
        /// <summary>
        /// 设置连接事件
        /// </summary>
        /// <param name="dwWaitTime"></param>
        /// <param name="dwTryTimes"></param>
        /// <returns></returns>
        bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);
        /// <summary>
        /// 设置重连时间
        /// </summary>
        /// <param name="dwInterval"></param>
        /// <param name="bEnableRecon"></param>
        /// <returns></returns>
        bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);
        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <param name="pValidNum"></param>
        /// <param name="pEnableBind"></param>
        /// <returns></returns>
        bool NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref Boolean pEnableBind);
        /// <summary>
        /// 设置可行IP
        /// </summary>
        /// <param name="dwIPIndex"></param>
        /// <param name="bEnableBind"></param>
        /// <returns></returns>
        bool NET_DVR_SetValidIP(uint dwIPIndex, Boolean bEnableBind);
        /// <summary>
        /// Get to the SDK version information
        /// </summary>
        /// <returns></returns>
        uint NET_DVR_GetSDKVersion();
        /// <summary>
        /// Get version number of the SDK and build information
        /// </summary>
        /// <returns></returns>
        uint NET_DVR_GetSDKBuildVersion();
        /// <summary>
        /// 硬盘录像机是否支持
        /// </summary>
        /// <returns></returns>
        Int32 NET_DVR_IsSupport();
        /// <summary>
        /// 硬盘录像机启动端口
        /// </summary>
        /// <param name="sLocalIP"></param>
        /// <param name="wLocalPort"></param>
        /// <returns></returns>
        bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);
        /// <summary>
        /// 硬盘录像机停止监听
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_StopListen();
        /// <summary>
        /// 硬盘录像机监听回调
        /// </summary>
        /// <param name="sLocalIP"></param>
        /// <param name="wLocalPort"></param>
        /// <param name="DataCallback"></param>
        /// <param name="pUserData"></param>
        /// <returns></returns>
        int NET_DVR_StartListen_V30(String sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);
        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="lListenHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopListen_V30(Int32 lListenHandle);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sDVRIP"></param>
        /// <param name="wDVRPort"></param>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <param name="lpDeviceInfo"></param>
        /// <returns></returns>
        Int32 NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        bool NET_DVR_Logout(int iUserID);
        /// <summary>
        /// 获取最后一次错误
        /// </summary>
        /// <returns></returns>
        uint NET_DVR_GetLastError();
        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="pErrorNo"></param>
        /// <returns>Returns the last error code information of the operation</returns>
        IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);
        /// <summary>
        /// 设置显示模式
        /// </summary>
        /// <param name="dwShowType"></param>
        /// <param name="colorKey"></param>
        /// <returns></returns>
        bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sServerIP"></param>
        /// <param name="wServerPort"></param>
        /// <param name="sDVRName"></param>
        /// <param name="wDVRNameLen"></param>
        /// <param name="sDVRSerialNumber"></param>
        /// <param name="wDVRSerialLen"></param>
        /// <param name="pGetIP"></param>
        /// <returns></returns>
        bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sServerIP"></param>
        /// <param name="wServerPort"></param>
        /// <param name="sDVRName"></param>
        /// <param name="wDVRNameLen"></param>
        /// <param name="sDVRSerialNumber"></param>
        /// <param name="wDVRSerialLen"></param>
        /// <param name="sGetIP"></param>
        /// <param name="dwPort"></param>
        /// <returns></returns>
        bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort);
        /// <summary>
        /// 预览相关接口
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpClientInfo"></param>
        /// <returns></returns>
        Int32 NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);
        /// <summary>
        /// 预览相关接口
        /// </summary>
        /// <param name="iUserLogID"></param>
        /// <param name="lpDVRClientInfo"></param>
        /// <returns></returns>
        Int32 NET_SDK_RealPlay(int iUserLogID, ref NET_DVR_CLIENTINFO lpDVRClientInfo);
        /// <summary>
        /// 实时预览
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpClientInfo">预览参数 </param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">请求码流过程是否阻塞：0－否；1－是 </param>
        /// <param name="bBlocked"></param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);
        /// <summary>
        /// 实时预览扩展接口
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpPreviewInfo">预览参数</param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">用户数据</param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);
        /// <summary>
        /// 停止预览
        /// </summary>
        /// <param name="iRealHandle">预览句柄，NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值</param>
        /// <returns></returns>
        bool NET_DVR_StopRealPlay(int iRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="fDrawFun"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwBufNum"></param>
        /// <returns></returns>
        bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwNum"></param>
        /// <returns></returns>
        bool NET_DVR_ThrowBFrame(Int32 lRealHandle, uint dwNum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwMode"></param>
        /// <returns></returns>
        bool NET_DVR_SetAudioMode(uint dwMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_OpenSound(Int32 lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_CloseSound();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_OpenSoundShare(Int32 lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseSoundShare(Int32 lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="wVolume"></param>
        /// <returns></returns>
        bool NET_DVR_Volume(Int32 lRealHandle, ushort wVolume);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_SaveRealData(Int32 lRealHandle, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopSaveRealData(Int32 lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="fRealDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="fStdDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sPicFileName"></param>
        /// <returns></returns>
        bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sPicFileName"></param>
        /// <param name="dwTimeOut"></param>
        /// <returns></returns>
        bool NET_DVR_CapturePictureBlock(Int32 lRealHandle, string sPicFileName, int dwTimeOut);
        /// <summary>
        /// 动态生成I帧
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_DVR_MakeKeyFrame(Int32 lUserID, Int32 lChannel);//主码流
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_DVR_MakeKeyFrameSub(Int32 lUserID, Int32 lChannel);//子码流
        /// <summary>
        /// 云台控制相关接口
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_GetPTZCtrl(Int32 lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_DVR_GetPTZCtrl_Other(Int32 lUserID, int lChannel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControl_Other(Int32 lUserID, Int32 lChannel, uint dwPTZCommand, uint dwStop);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="pPTZCodeBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_TransPTZ(Int32 lRealHandle, string pPTZCodeBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="pPTZCodeBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZPresetCmd"></param>
        /// <param name="dwPresetIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZPresetCmd"></param>
        /// <param name="dwPresetIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="pPTZCodeBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZPresetCmd"></param>
        /// <param name="dwPresetIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCruiseCmd"></param>
        /// <param name="byCruiseRoute"></param>
        /// <param name="byCruisePoint"></param>
        /// <param name="wInput"></param>
        /// <returns></returns>
        bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZCruiseCmd"></param>
        /// <param name="byCruiseRoute"></param>
        /// <param name="byCruisePoint"></param>
        /// <param name="wInput"></param>
        /// <returns></returns>
        bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCruiseCmd"></param>
        /// <param name="byCruiseRoute"></param>
        /// <param name="byCruisePoint"></param>
        /// <param name="wInput"></param>
        /// <returns></returns>
        bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <returns></returns>
        bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <returns></returns>
        bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <returns></returns>
        bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <param name="dwSpeed"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <param name="dwSpeed"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZCommand"></param>
        /// <param name="dwStop"></param>
        /// <param name="dwSpeed"></param>
        /// <returns></returns>
        bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lCruiseRoute"></param>
        /// <param name="lpCruiseRet"></param>
        /// <returns></returns>
        bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <param name="dwTrackIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <param name="dwTrackIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwPTZTrackCmd"></param>
        /// <param name="dwTrackIndex"></param>
        /// <returns></returns>
        bool NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);
        /// <summary>
        /// 文件查找与回放
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwFileType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <returns></returns>
        bool NET_DVR_FindClose(int lFindHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindCond"></param>
        /// <returns></returns>
        int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindCond"></param>
        /// <returns></returns>
        int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpSearchEventParam"></param>
        /// <returns></returns>
        int NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lSearchHandle"></param>
        /// <param name="lpSearchEventRet"></param>
        /// <returns></returns>
        int NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <returns></returns>
        bool NET_DVR_FindClose_V30(int lFindHandle);
        /// <summary>
        /// 增加查询结果带卡号的文件查找
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwFileType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sLockFileName"></param>
        /// <returns></returns>
        bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sUnlockFileName"></param>
        /// <returns></returns>
        bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sPlayBackFileName"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, System.IntPtr hWnd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pVodPara"></param>
        /// <returns></returns>
        int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sPlayBackFileName"></param>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        int NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="hWnd"></param>
        /// <param name="pPlayCond"></param>
        /// <returns></returns>
        int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="dwControlCode"></param>
        /// <param name="dwInValue"></param>
        /// <param name="LPOutValue"></param>
        /// <returns></returns>
        bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="dwControlCode"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="dwInValue"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="LPOutValue"></param>
        /// <returns></returns>
        bool NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopPlayBack(int lPlayHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="fPlayDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopPlayBackSave(int lPlayHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="lpOsdTime"></param>
        /// <returns></returns>
        bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sDVRFileName"></param>
        /// <param name="sSavedFileName"></param>
        /// <returns></returns>
        int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <param name="sSavedFileName"></param>
        /// <returns></returns>
        int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sSavedFileName"></param>
        /// <param name="pDownloadCond"></param>
        /// <returns></returns>
        int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFileHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopGetFile(int lFileHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFileHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetDownloadPos(int lFileHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetPlayBackPos(int lPlayHandle);

        /// <summary>
        /// 图片查找
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindParam"></param>
        /// <returns></returns>
        int NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseFindPicture(int lFindHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sDVRFileName"></param>
        /// <param name="sSavedFileName"></param>
        /// <returns></returns>
        bool NET_DVR_GetPicture(int lUserID, String sDVRFileName, String sSavedFileName);

        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        int NET_DVR_Upgrade(int lUserID, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwUpgradeType"></param>
        /// <param name="sFileName"></param>
        /// <param name="pInbuffer"></param>
        /// <param name="dwInBufferLen"></param>
        /// <returns></returns>
        int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, Int32 dwInBufferLen);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUpgradeHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetUpgradeState(int lUpgradeHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUpgradeHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUpgradeHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwEnvironmentLevel"></param>
        /// <returns></returns>
        bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);

        /// <summary>
        /// 远程格式化硬盘
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lDiskNumber"></param>
        /// <returns></returns>
        int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFormatHandle"></param>
        /// <param name="pCurrentFormatDisk"></param>
        /// <param name="pCurrentDiskPos"></param>
        /// <param name="pFormatStatic"></param>
        /// <returns></returns>
        bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lFormatHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseFormatHandle(int lFormatHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpProtoList"></param>
        /// <returns></returns>
        bool NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpProtoList"></param>
        /// <returns></returns>
        bool NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList);

        /// <summary>
        /// 报警
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        int NET_DVR_SetupAlarmChan(int lUserID);
        /// <summary>
        /// shut down alarm upload channel, to obtain the information such as alarm
        /// </summary>
        /// <param name="lAlarmHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseAlarmChan(int lAlarmHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        int NET_DVR_SetupAlarmChan_V30(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpSetupParam"></param>
        /// <returns></returns>
        int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lAlarmHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);

        /// <summary>
        /// 语音对讲
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwVoiceChan"></param>
        /// <param name="bNeedCBNoEncData"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lVoiceComHandle"></param>
        /// <param name="wVolume"></param>
        /// <returns></returns>
        bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lVoiceComHandle"></param>
        /// <returns></returns>
        bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        /// <summary>
        /// 语音转发
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwVoiceChan"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lVoiceComHandle"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 语音广播
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ClientAudioStart();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fVoiceAudioStart"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ClientAudioStop();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_AddDVR(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwVoiceChan"></param>
        /// <returns></returns>
        int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_DelDVR(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lVoiceHandle"></param>
        /// <returns></returns>
        bool NET_DVR_DelDVR_V30(int lVoiceHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lSerialPort"></param>
        /// <param name="fSerialDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);

        /// <summary>
        /// 485作为透明通道时，需要指明通道号，因为不同通道号485的设置可以不同(比如波特率)
        /// </summary>
        /// <param name="lSerialHandle"></param>
        /// <param name="lChannel"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lSerialHandle"></param>
        /// <returns></returns>
        bool NET_DVR_SerialStop(int lSerialHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSerialPort"></param>
        /// <param name="dwSerialIndex"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 解码 nBitrate = 16000
        /// </summary>
        /// <param name="nBitrate"></param>
        /// <returns></returns>
        System.IntPtr NET_DVR_InitG722Decoder(int nBitrate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDecHandle"></param>
        void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDecHandle"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        IntPtr NET_DVR_InitG722Encoder();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEncodeHandle"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEncodeHandle"></param>
        void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        /// <summary>
        /// 远程控制本地显示
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lKeyIndex"></param>
        /// <returns></returns>
        bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        /// <summary>
        /// 远程控制设备端手动录像
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lRecordType"></param>
        /// <returns></returns>
        bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);

        /// <summary>
        /// 解码卡
        /// </summary>
        /// <param name="pDeviceTotalChan"></param>
        /// <returns></returns>
        bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ReleaseDevice_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hParent"></param>
        /// <param name="colorKey"></param>
        /// <returns></returns>
        bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ReleaseDDraw_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpCardInfo"></param>
        /// <param name="lChannelNum"></param>
        /// <returns></returns>
        int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="lpDisplayPara"></param>
        /// <returns></returns>
        bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_RefreshSurface_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ClearSurface_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_RestoreSurface_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_OpenSound_Card(int lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseSound_Card(int lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="wVolume"></param>
        /// <returns></returns>
        bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="bEnable"></param>
        /// <returns></returns>
        bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int NET_DVR_GetCardLastError_Card();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        System.IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="sPicFileName"></param>
        /// <returns></returns>
        bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);

        /// <summary>
        /// 获取解码卡序列号此接口无效，改用GetBoardDetail接口获得(2005-12-08支持)
        /// </summary>
        /// <param name="lChannelNum"></param>
        /// <param name="pDeviceSerialNo"></param>
        /// <returns></returns>
        bool NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo);

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lSelectMode"></param>
        /// <param name="dwMajorType"></param>
        /// <param name="dwMinorType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lLogHandle"></param>
        /// <param name="lpLogData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lLogHandle"></param>
        /// <returns></returns>
        bool NET_DVR_FindLogClose(int lLogHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lSelectMode"></param>
        /// <param name="dwMajorType"></param>
        /// <param name="dwMinorType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <param name="bOnlySmart"></param>
        /// <returns></returns>
        int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lLogHandle"></param>
        /// <param name="lpLogData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lLogHandle"></param>
        /// <returns></returns>
        bool NET_DVR_FindLogClose_V30(int lLogHandle);

        /// <summary>
        /// ATM DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwFileType"></param>
        /// <param name="nFindType"></param>
        /// <param name="sCardNumber"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpJpegPara"></param>
        /// <param name="sPicFileName"></param>
        /// <returns></returns>
        bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName);

        /// <summary>
        /// JPEG抓图到内存
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpJpegPara"></param>
        /// <param name="sJpegPicBuffer"></param>
        /// <param name="dwPicSize"></param>
        /// <param name="lpSizeReturned"></param>
        /// <returns></returns>
        bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetRealPlayerIndex(int lRealHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);

        /// <summary>
        /// 人脸识别上传文件发送数据
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="pstruSendParamIN"></param>
        /// <param name="lpOutBuffer"></param>
        /// <returns></returns>
        Int32 NET_DVR_UploadSend(int lUploadHandle, ref NET_DVR_SEND_PARAM_IN pstruSendParamIN, IntPtr lpOutBuffer);

        /// <summary>
        /// 人脸识别上传文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwUploadType"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="dwInBufferSize"></param>
        /// <param name="sFileName"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        Int32 NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="pProgress"></param>
        /// <returns></returns>
        Int32 NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress);

        /// <summary>
        /// 获取当前上传的结果信息。
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        bool NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <returns></returns>
        bool NET_DVR_UploadClose(int lUploadHandle);

        /// <summary>
        /// 704-640 缩放配置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwScale"></param>
        /// <returns></returns>
        bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpOutScale"></param>
        /// <returns></returns>
        bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pScalecfg"></param>
        /// <returns></returns>
        bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pScalecfg"></param>
        /// <returns></returns>
        bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        /// <summary>
        /// ATM机端口设置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="wATMPort"></param>
        /// <returns></returns>
        bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="LPOutATMPort"></param>
        /// <returns></returns>
        bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);

        /// <summary>
        /// 支持显卡辅助输出
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_InitDDrawDevice();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool NET_DVR_ReleaseDDrawDevice();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int NET_DVR_GetDDrawDeviceTotalNums();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayPort"></param>
        /// <param name="nDeviceNum"></param>
        /// <returns></returns>
        bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="pStruPointFrame"></param>
        /// <returns></returns>
        bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="pStruPointFrame"></param>
        /// <returns></returns>
        bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);

        /// <summary>
        /// 解码设备DS-6001D/DS-6001F
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_DVR_StopDecode(int lUserID, int lChannel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderState"></param>
        /// <returns></returns>
        bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTransPort"></param>
        /// <returns></returns>
        bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTransPort"></param>
        /// <returns></returns>
        bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwControlCode"></param>
        /// <param name="dwInValue"></param>
        /// <param name="LPOutValue"></param>
        /// <param name="lpRemoteFileInfo"></param>
        /// <returns></returns>
        bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecChanInfo"></param>
        /// <returns></returns>
        bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecChanInfo"></param>
        /// <returns></returns>
        bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwControlCode"></param>
        /// <returns></returns>
        bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwControl"></param>
        /// <returns></returns>
        bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecStatus"></param>
        /// <returns></returns>
        bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        /// <summary>
        /// 多路解码器V211支持以下接口 //11
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpOuter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="dwEnable"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpdwEnable"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpdwEnable"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="dwEnable"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpdwEnable"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);

        /// <summary>
        /// 增加支持接口 //18
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="dwControlCode"></param>
        /// <param name="dwInValue"></param>
        /// <param name="LPOutValue"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpOuter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="lpDisplayCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="lpDisplayCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="lpDisplayCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="lpDisplayCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpPassiveMode"></param>
        /// <returns></returns>
        int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPassiveHandle"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSendData(int lPassiveHandle, System.IntPtr pSendBuf, uint dwBufSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPassiveHandle"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="lpDispLogoCfg"></param>
        /// <param name="sLogoBuffer"></param>
        /// <returns></returns>
        bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, System.IntPtr sLogoBuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <param name="lpPictureCfg"></param>
        /// <returns></returns>
        int NET_DVR_PicUpload(int lUserID, String sFileName, ref NET_DVR_PICTURECFG lpPictureCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetPicUploadProgress(int lUploadHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <returns></returns>
        bool NET_DVR_CloseUploadHandle(int lUploadHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <returns></returns>
        int NET_DVR_GetPicUploadState(int lUploadHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChan"></param>
        /// <param name="dwLogoSwitch"></param>
        /// <returns></returns>
        bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpDecoderCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDevNum"></param>
        /// <param name="lpInputSignalList"></param>
        /// <returns></returns>
        bool NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDispChanNum"></param>
        /// <param name="dwDispChanCmd"></param>
        /// <param name="dwCmdParam"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lPlayHandle"></param>
        /// <returns></returns>
        bool NET_DVR_RefreshPlay(int lPlayHandle);

        /// <summary>
        /// 恢复默认值
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_RestoreConfig(int lUserID);

        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_SaveConfig(int lUserID);

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_RebootDVR(int lUserID);

        /// <summary>
        /// 关闭DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_ShutDownDVR(int lUserID);

        /// <summary>
        /// Get device configuration information function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lChannel">channel number with command related, 0xFFFFFFFF represent invalid</param>
        /// <param name="lpOutBuffer">a pointer to a buffer to receive data</param>
        /// <param name="dwOutBufferSize">the receive data buffer size, don't assign 0, unit:byte</param>
        /// <param name="lpBytesReturned">pointer to the length of the data received, e.g. a int type pointer, can't be NULL</param>
        /// <returns></returns>
        bool NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

        /// <summary>
        /// Set device configuration information function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lChannel">channel number with command related, 0xFFFFFFFF represent invalid</param>
        /// <param name="lpInBuffer">a pointer to a buffer of send data</param>
        /// <param name="dwInBufferSize">the send data buffer size, unit:byte</param>
        /// <returns></returns>
        bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pWorkState"></param>
        /// <returns></returns>
        bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);
        /// <summary>
        /// 获取DVR的工作状态
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpWorkState"></param>
        /// <returns></returns>
        bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwBrightValue"></param>
        /// <param name="dwContrastValue"></param>
        /// <param name="dwSaturationValue"></param>
        /// <param name="dwHueValue"></param>
        /// <returns></returns>
        bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="pBrightValue"></param>
        /// <param name="pContrastValue"></param>
        /// <param name="pSaturationValue"></param>
        /// <param name="pHueValue"></param>
        /// <returns></returns>
        bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpFrameFormat"></param>
        /// <returns></returns>
        bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpFrameFormat"></param>
        /// <returns></returns>
        bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpAtmProtocol"></param>
        /// <returns></returns>
        bool NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpAlarmOutState"></param>
        /// <returns></returns>
        bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpAlarmOutState"></param>
        /// <returns></returns>
        bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lAlarmOutPort"></param>
        /// <param name="lAlarmOutStatic"></param>
        /// <returns></returns>
        bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);

        /// <summary>
        /// Alarm host device user configuration function(following two:get and set)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lUserIndex">index of user</param>
        /// <param name="lpDeviceUser">lookup NET_DVR_ALARM_DEVICE_USER definition</param>
        /// <returns></returns>
        bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lUserIndex"></param>
        /// <param name="lpDeviceUser"></param>
        /// <returns></returns>
        bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        /// <summary>
        /// 获取UPNP端口映射状态
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpState"></param>
        /// <returns></returns>
        bool NET_DVR_GetUpnpNatState(int lUserID, ref NET_DVR_UPNP_NAT_STATE lpState);

        /// <summary>
        /// 视频参数调节
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwBrightValue"></param>
        /// <param name="dwContrastValue"></param>
        /// <param name="dwSaturationValue"></param>
        /// <param name="dwHueValue"></param>
        /// <returns></returns>
        bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="pBrightValue"></param>
        /// <param name="pContrastValue"></param>
        /// <param name="pSaturationValue"></param>
        /// <param name="pHueValue"></param>
        /// <returns></returns>
        bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_GetConfigFile(int lUserID, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_SetConfigFile(int lUserID, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sOutBuffer"></param>
        /// <param name="dwOutSize"></param>
        /// <param name="pReturnSize"></param>
        /// <returns></returns>
        bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sOutBuffer"></param>
        /// <param name="dwOutSize"></param>
        /// <returns></returns>
        bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sInBuffer"></param>
        /// <param name="dwInSize"></param>
        /// <returns></returns>
        bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);

        /// <summary>
        /// 启用日志文件写入接口
        /// </summary>
        /// <param name="nLogLevel">(default 0) - log level, 0:close, 1:ERROR, 2:ERROR and DEBUG, 3-ALL</param>
        /// <param name="strLogDir">file directory to save, default:"C:\\SdkLog\\"(win)and "/home/sdklog/"(linux)</param>
        /// <param name="bAutoDel">whether to delete log file by auto, TRUE is default</param>
        /// <returns></returns>
        bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSDKState"></param>
        /// <returns></returns>
        bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSDKAbl"></param>
        /// <returns></returns>
        bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pPtzcfg"></param>
        /// <returns></returns>
        bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);

        /// <summary>
        /// 前面板锁定
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_LockPanel(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_UnLockPanel(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="dwInBufferSize"></param>
        /// <returns></returns>
        bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// 视频综合平台
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSceneNum"></param>
        /// <param name="lpSceneCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSceneNum"></param>
        /// <param name="lpSceneCfg"></param>
        /// <returns></returns>
        bool NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpLine"></param>
        /// <param name="lpHeight"></param>
        /// <returns></returns>
        bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpHeight);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpLine"></param>
        /// <param name="lpLength"></param>
        /// <returns></returns>
        bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpLength);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwTransType"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enc_info"></param>
        /// <returns></returns>
        IntPtr NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="p_enc_proc_param"></param>
        /// <returns></returns>
        bool NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEncodeHandle"></param>
        /// <returns></returns>
        bool NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        /// <summary>
        /// 邮件服务测试 9000_1.1
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        bool NET_DVR_EmailTest(int lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpSearchEventParam"></param>
        /// <returns></returns>
        int NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lSearchHandle"></param>
        /// <param name="lpSearchEventRet"></param>
        /// <returns></returns>
        int NET_DVR_FindNextEvent(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET lpSearchEventRet);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDVRIP">设备IP地址 </param>
        /// <param name="wDVRPort">设备端口号</param>
        /// <param name="sUserName">登录的用户名</param>
        /// <param name="sPassword">用户密码</param>
        /// <param name="lpDeviceInfo">设备信息</param>
        /// <returns>-1表示失败，其他值表示返回的用户ID值</returns>
        Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// <summary>
        /// login
        /// </summary>
        /// <param name="pLoginInfo">login parameters</param>
        /// <param name="lpDeviceInfo">device informations</param>
        /// <returns></returns>
        int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        /// <summary>
        /// 用户注销设备
        /// </summary>
        /// <param name="lUserID">用户ID号</param>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        bool NET_DVR_Logout_V30(Int32 lUserID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLogHandle"></param>
        /// <param name="lpLogData"></param>
        /// <returns></returns>
        int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lSelectMode"></param>
        /// <param name="dwMajorType"></param>
        /// <param name="dwMinorType"></param>
        /// <param name="lpVedioPlatLog"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpInputParam"></param>
        /// <param name="lpOutputParam"></param>
        /// <returns></returns>
        bool NET_DVR_STDXMLConfig(int iUserID, ref NET_DVR_XML_CONFIG_INPUT lpInputParam, ref NET_DVR_XML_CONFIG_OUTPUT lpOutputParam);

        /// <summary>
        /// Batch for device configuration information (with sending data)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer">a pointer to conditions buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the conditions buffer size, unit:byte</param>
        /// <param name="lpStatusList">a pointer to the error code list, One to one correspondence(user manual for more details)</param>
        /// <param name="lpOutBuffer">a pointer to receive data buffer, One to one correspondence(user manual for more details)</param>
        /// <param name="dwOutBufferSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        bool NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// Batch for device configuration information (with sending data)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer"> a pointer to conditions buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the conditions buffer size, unit:byte</param>
        /// <param name="lpStatusList">a pointer to the error code list, One to one correspondence(user manual for more details)</param>
        /// <param name="lpInParamBuffer">a pointer to set parameters for the device buffer, One to one correspondence(user manual for more details)</param>
        /// <param name="dwInParamBufferSize">the correspond data buffer size, unit:byte</param>
        /// <returns></returns>
        bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="dwCount"></param>
        /// <param name="lpInParam"></param>
        /// <param name="lpOutParam"></param>
        /// <returns></returns>
        bool NET_DVR_SetDeviceConfigEx(Int32 lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="lpConfigParam"></param>
        /// <returns></returns>
        bool NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="lpConfigParam"></param>
        /// <returns></returns>
        bool NET_DVR_SetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        /// <summary>
        /// Long connection configuration function
        /// Start the remote configuration
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lpInBuffer">a pointer to a buffer of send data</param>
        /// <param name="dwInBufferLen">the send data buffer size, unit:byte</param>
        /// <param name="cbStateCallback">the callback function</param>
        /// <param name="pUserData">pointer to user input data</param>
        /// <returns></returns>
        int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        /// <summary>
        /// get long connection configuration status
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="pState">the return status pointer</param>
        /// <returns></returns>
        bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);
        /// <summary>
        /// obtain the result of the information one by one
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="lpOutBuff">a pointer to a buffer to receive data(user manual for more details)</param>
        /// <param name="dwOutBuffSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        int NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, int dwOutBuffSize);

        /// <summary>
        /// Send a long connection data
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="dwDataType">refer enum LONG_CFG_SEND_DATA_TYPE_ENUM, associated with NET_DVR_StartRemoteConfig command parameters (user manual for more details)</param>
        /// <param name="pSendBuf">a pointer to a buffer of send data, associated with dwDataType</param>
        /// <param name="dwBufSize">the send data buffer size, unit:byte</param>
        /// <returns></returns>
        bool NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize);

        /// <summary>
        /// stop a long connection
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <returns></returns>
        bool NET_DVR_StopRemoteConfig(int lHandle);

        /// <summary>
        /// The remote control function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        ///// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer">a pointer to send data buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the correspond buffer size, unit:byte</param>
        /// <returns></returns>
        bool NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwCommand"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="dwInBufferSize"></param>
        /// <returns></returns>
        bool NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpInter"></param>
        /// <returns></returns>
        bool NET_DVR_ContinuousShoot(Int32 lUserID, ref NET_DVR_SNAPCFG lpInter);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpInter"></param>
        /// <param name="lpOuter"></param>
        /// <returns></returns>
        bool NET_DVR_ManualSnap(Int32 lUserID, ref NET_DVR_MANUALSNAP lpInter, ref NET_DVR_PLATE_RESULT lpOuter);

        /// <summary>
        /// NET_DVR_GetDeviceAbility get device ability
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwAbilityType">the configuration command(ACS_ABILITY)</param>
        /// <param name="pInBuf">a pointer to send data buffer(user manual for more details)</param>
        /// <param name="dwInLength">the correspond buffer size, unit:byte</param>
        /// <param name="pOutBuf">out buff(ACS_ABILITY is described with XML)</param>
        /// <param name="dwOutLength">the correspond buffer size, unit:byte</param>
        /// <returns>TRUE表示成功，FALSE表示失败。</returns>
        bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        /// <summary>
        /// 设置/获取参数关键字
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwParameterKey"></param>
        /// <param name="nValue"></param>
        /// <returns></returns>
        bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwParameterKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);

        /// <summary>
        /// 获取/设置行为分析目标叠加接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDrawMode"></param>
        /// <returns></returns>
        bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDrawMode"></param>
        /// <returns></returns>
        bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        /// <summary>
        /// 双摄像机跟踪模式设置接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpTrackMode"></param>
        /// <returns></returns>
        bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpTrackMode"></param>
        /// <returns></returns>
        bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpCCDCfg"></param>
        /// <returns></returns>
        bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpCCDCfg"></param>
        /// <returns></returns>
        bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwParamSetMode"></param>
        /// <returns></returns>
        bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpInquestRoom"></param>
        /// <param name="bNotBurn"></param>
        /// <returns></returns>
        bool NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn);
        /// <summary>
        /// 重启智能库
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        bool NET_VCA_RestartLib(int lUserID, int lChannel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        int PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam);
    }
    internal class HikHCNetSdkDller : IHikHCNetSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IHikHCNetSdkProxy Instance { get; } = new HikHCNetSdkDller();
        private HikHCNetSdkDller() { }
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);

        /// <summary>
        /// remote control gateway
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lGatewayIndex">1-begin 0xffffffff-all</param>
        /// <param name="dwStaic">0-close，1-open，2-always open，3-always close</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);

        /// <summary>
        /// Alarm information registered callback function
        /// </summary>
        /// <param name="iIndex">iIndex, scope:[0,15] </param>
        /// <param name="fMessageCallBack">callback function</param>
        /// <param name="pUser">user data</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);

        /*********************************************************
        Function:	NET_DVR_Init
        Desc:		初始化SDK，调用其他SDK函数的前提。
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败。
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_Init();

        /*********************************************************
        Function:	NET_DVR_Cleanup
        Desc:		释放SDK资源，在结束之前最后调用
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_Cleanup();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref Boolean pEnableBind);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetValidIP(uint dwIPIndex, Boolean bEnableBind);
        /// <summary>
        /// Get to the SDK version information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern uint NET_DVR_GetSDKVersion();
        /// <summary>
        /// Get version number of the SDK and build information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern uint NET_DVR_GetSDKBuildVersion();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_IsSupport();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopListen();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartListen_V30(String sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopListen_V30(Int32 lListenHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_Logout(int iUserID);
        /// <summary>
        /// 获取最后一次错误
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern uint NET_DVR_GetLastError();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="pErrorNo"></param>
        /// <returns>Returns the last error code information of the operation</returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort);
        /// <summary>
        /// 预览相关接口
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpClientInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_SDK_RealPlay(int iUserLogID, ref NET_DVR_CLIENTINFO lpDVRClientInfo);

        /// <summary>
        /// 实时预览
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpClientInfo">预览参数 </param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">请求码流过程是否阻塞：0－否；1－是 </param>
        /// <param name="bBlocked"></param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);

        /// <summary>
        /// 实时预览扩展接口
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpPreviewInfo">预览参数</param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">用户数据</param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        //[DllImport(HikHCNetSdk.DllFileName)]
        //public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        /// <summary>
        /// 停止预览
        /// </summary>
        /// <param name="iRealHandle">预览句柄，NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ThrowBFrame(Int32 lRealHandle, uint dwNum);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetAudioMode(uint dwMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_OpenSound(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseSound();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_OpenSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_Volume(Int32 lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SaveRealData(Int32 lRealHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopSaveRealData(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CapturePictureBlock(Int32 lRealHandle, string sPicFileName, int dwTimeOut);

        /// <summary>
        /// 动态生成I帧
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MakeKeyFrame(Int32 lUserID, Int32 lChannel);//主码流

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MakeKeyFrameSub(Int32 lUserID, Int32 lChannel);//子码流

        /// <summary>
        /// 云台控制相关接口
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPTZCtrl(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPTZCtrl_Other(Int32 lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControl_Other(Int32 lUserID, Int32 lChannel, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_TransPTZ(Int32 lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        /// <summary>
        /// 文件查找与回放
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwFileType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_FindClose(int lFindHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_FindClose_V30(int lFindHandle);

        /// <summary>
        /// 增加查询结果带卡号的文件查找
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, System.IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopPlayBack(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopPlayBackSave(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopGetFile(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetDownloadPos(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetPlayBackPos(int lPlayHandle);

        /// <summary>
        /// 图片查找
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindParam"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseFindPicture(int lFindHandle);
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPicture(int lUserID, String sDVRFileName, String sSavedFileName);

        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_Upgrade(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, Int32 dwInBufferLen);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetUpgradeState(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);

        /// <summary>
        /// 远程格式化硬盘
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lDiskNumber"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseFormatHandle(int lFormatHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList);
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList);

        /// <summary>
        /// 报警
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SetupAlarmChan(int lUserID);
        /// <summary>
        /// shut down alarm upload channel, to obtain the information such as alarm
        /// </summary>
        /// <param name="lAlarmHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseAlarmChan(int lAlarmHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SetupAlarmChan_V30(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);

        /// <summary>
        /// 语音对讲
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        /// <summary>
        /// 语音转发
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 语音广播
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientAudioStart();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);


        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientAudioStop();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_AddDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DelDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DelDVR_V30(int lVoiceHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);

        /// <summary>
        /// 485作为透明通道时，需要指明通道号，因为不同通道号485的设置可以不同(比如波特率)
        /// </summary>
        /// <param name="lSerialHandle"></param>
        /// <param name="lChannel"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SerialStop(int lSerialHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 解码 nBitrate = 16000
        /// </summary>
        /// <param name="nBitrate"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern System.IntPtr NET_DVR_InitG722Decoder(int nBitrate);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern IntPtr NET_DVR_InitG722Encoder();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        /// <summary>
        /// 远程控制本地显示
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lKeyIndex"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        /// <summary>
        /// 远程控制设备端手动录像
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lRecordType"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);

        /// <summary>
        /// 解码卡
        /// </summary>
        /// <param name="pDeviceTotalChan"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ReleaseDevice_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ReleaseDDraw_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RefreshSurface_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClearSurface_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RestoreSurface_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_OpenSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetCardLastError_Card();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern System.IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);

        /// <summary>
        /// 获取解码卡序列号此接口无效，改用GetBoardDetail接口获得(2005-12-08支持)
        /// </summary>
        /// <param name="lChannelNum"></param>
        /// <param name="pDeviceSerialNo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo);

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lSelectMode"></param>
        /// <param name="dwMajorType"></param>
        /// <param name="dwMinorType"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_FindLogClose(int lLogHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_FindLogClose_V30(int lLogHandle);

        /// <summary>
        /// ATM DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwFileType"></param>
        /// <param name="nFindType"></param>
        /// <param name="sCardNumber"></param>
        /// <param name="lpStartTime"></param>
        /// <param name="lpStopTime"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName);
        // public static extern bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, IntPtr sPicFileName);

        /// <summary>
        /// JPEG抓图到内存
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpJpegPara"></param>
        /// <param name="sJpegPicBuffer"></param>
        /// <param name="dwPicSize"></param>
        /// <param name="lpSizeReturned"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);

        /// <summary>
        /// 人脸识别上传文件发送数据
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="pstruSendParamIN"></param>
        /// <param name="lpOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_UploadSend(int lUploadHandle, ref NET_DVR_SEND_PARAM_IN pstruSendParamIN, IntPtr lpOutBuffer);

        /// <summary>
        /// 人脸识别上传文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwUploadType"></param>
        /// <param name="lpInBuffer"></param>
        /// <param name="dwInBufferSize"></param>
        /// <param name="sFileName"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress);

        /// <summary>
        /// 获取当前上传的结果信息。
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_UploadClose(int lUploadHandle);

        /// <summary>
        /// 704-640 缩放配置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwScale"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        /// <summary>
        /// ATM机端口设置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="wATMPort"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);

        /// <summary>
        /// 支持显卡辅助输出
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_InitDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ReleaseDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetDDrawDeviceTotalNums();

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);

        /// <summary>
        /// 解码设备DS-6001D/DS-6001F
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopDecode(int lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        /// <summary>
        /// 多路解码器V211支持以下接口 //11
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);

        /// <summary>
        /// 增加支持接口 //18
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSendData(int lPassiveHandle, System.IntPtr pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, System.IntPtr sLogoBuffer);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_PicUpload(int lUserID, String sFileName, ref NET_DVR_PICTURECFG lpPictureCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetPicUploadProgress(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_CloseUploadHandle(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetPicUploadState(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RefreshPlay(int lPlayHandle);

        /// <summary>
        /// 恢复默认值
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RestoreConfig(int lUserID);

        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SaveConfig(int lUserID);

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RebootDVR(int lUserID);

        /// <summary>
        /// 关闭DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ShutDownDVR(int lUserID);

        /// <summary>
        /// Get device configuration information function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lChannel">channel number with command related, 0xFFFFFFFF represent invalid</param>
        /// <param name="lpOutBuffer">a pointer to a buffer to receive data</param>
        /// <param name="dwOutBufferSize">the receive data buffer size, don't assign 0, unit:byte</param>
        /// <param name="lpBytesReturned">pointer to the length of the data received, e.g. a int type pointer, can't be NULL</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

        /// <summary>
        /// Set device configuration information function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lChannel">channel number with command related, 0xFFFFFFFF represent invalid</param>
        /// <param name="lpInBuffer">a pointer to a buffer of send data</param>
        /// <param name="dwInBufferSize">the send data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);

        /// <summary>
        /// Alarm host device user configuration function(following two:get and set)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lUserIndex">index of user</param>
        /// <param name="lpDeviceUser">lookup NET_DVR_ALARM_DEVICE_USER definition</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        /// <summary>
        /// 获取UPNP端口映射状态
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpState"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetUpnpNatState(int lUserID, ref NET_DVR_UPNP_NAT_STATE lpState);

        /// <summary>
        /// 视频参数调节
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwBrightValue"></param>
        /// <param name="dwContrastValue"></param>
        /// <param name="dwSaturationValue"></param>
        /// <param name="dwHueValue"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);

        /// <summary>
        /// 启用日志文件写入接口
        /// </summary>
        /// <param name="nLogLevel">(default 0) - log level, 0:close, 1:ERROR, 2:ERROR and DEBUG, 3-ALL</param>
        /// <param name="strLogDir">file directory to save, default:"C:\\SdkLog\\"(win)and "/home/sdklog/"(linux)</param>
        /// <param name="bAutoDel">whether to delete log file by auto, TRUE is default</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);

        /// <summary>
        /// 前面板锁定
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_LockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_UnLockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// 视频综合平台
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSceneNum"></param>
        /// <param name="lpSceneCfg"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpHeight);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpLength);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);

        /// <summary>
        /// Win32位定义
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_EncodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern IntPtr NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        //邮件服务测试 9000_1.1
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_EmailTest(int lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextEvent(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET lpSearchEventRet);

        /*********************************************************
        Function:	NET_DVR_Login_V30
        Desc:		
        Input:	sDVRIP [in] 设备IP地址 
                wServerPort [in] 设备端口号 
                sUserName [in] 登录的用户名 
                sPassword [in] 用户密码 
        Output:	lpDeviceInfo [out] 设备信息 
        Return:	-1表示失败，其他值表示返回的用户ID值
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// <summary>
        /// login
        /// </summary>
        /// <param name="pLoginInfo">login parameters</param>
        /// <param name="lpDeviceInfo">device informations</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        /// <summary>
        /// 用户注册设备
        /// </summary>
        /// <param name="lUserID">用户ID号</param>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);


        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_STDXMLConfig(int iUserID, ref NET_DVR_XML_CONFIG_INPUT lpInputParam, ref NET_DVR_XML_CONFIG_OUTPUT lpOutputParam);

        /// <summary>
        /// Batch for device configuration information (with sending data)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer">a pointer to conditions buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the conditions buffer size, unit:byte</param>
        /// <param name="lpStatusList">a pointer to the error code list, One to one correspondence(user manual for more details)</param>
        /// <param name="lpOutBuffer">a pointer to receive data buffer, One to one correspondence(user manual for more details)</param>
        /// <param name="dwOutBufferSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// Batch for device configuration information (with sending data)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer"> a pointer to conditions buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the conditions buffer size, unit:byte</param>
        /// <param name="lpStatusList">a pointer to the error code list, One to one correspondence(user manual for more details)</param>
        /// <param name="lpInParamBuffer">a pointer to set parameters for the device buffer, One to one correspondence(user manual for more details)</param>
        /// <param name="dwInParamBufferSize">the correspond data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetDeviceConfigEx(Int32 lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        /// <summary>
        /// Long connection configuration function
        /// Start the remote configuration
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        /// <param name="lpInBuffer">a pointer to a buffer of send data</param>
        /// <param name="dwInBufferLen">the send data buffer size, unit:byte</param>
        /// <param name="cbStateCallback">the callback function</param>
        /// <param name="pUserData">pointer to user input data</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);
        // public static extern int NET_DVR_StartRemoteConfig(int lUserID, uint dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        /// <summary>
        /// get long connection configuration status
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="pState">the return status pointer</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);
        /// <summary>
        /// obtain the result of the information one by one
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="lpOutBuff">a pointer to a buffer to receive data(user manual for more details)</param>
        /// <param name="dwOutBuffSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, int dwOutBuffSize);
        // public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, uint dwOutBuffSize);

        /// <summary>
        /// Send a long connection data
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="dwDataType">refer enum LONG_CFG_SEND_DATA_TYPE_ENUM, associated with NET_DVR_StartRemoteConfig command parameters (user manual for more details)</param>
        /// <param name="pSendBuf">a pointer to a buffer of send data, associated with dwDataType</param>
        /// <param name="dwBufSize">the send data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize);
        // public static extern bool NET_DVR_SendRemoteConfig(int lHandle, uint dwDataType, IntPtr pSendBuf, uint dwBufSize);
        /// <summary>
        /// stop a long connection
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_StopRemoteConfig(int lHandle);

        /// <summary>
        /// The remote control function
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwCommand">the configuration command(usually with NET_DVR_ prefix)</param>
        ///// <param name="dwCount">the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64</param>
        /// <param name="lpInBuffer">a pointer to send data buffer(user manual for more details)</param>
        /// <param name="dwInBufferSize">the correspond buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize);
        //public static extern bool NET_DVR_RemoteControl(int lUserID, uint dwCommand, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ContinuousShoot(Int32 lUserID, ref NET_DVR_SNAPCFG lpInter);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_ManualSnap(Int32 lUserID, ref NET_DVR_MANUALSNAP lpInter, ref NET_DVR_PLATE_RESULT lpOuter);

        /// <summary>
        /// NET_DVR_GetDeviceAbility get device ability
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="dwAbilityType">the configuration command(ACS_ABILITY)</param>
        /// <param name="pInBuf">a pointer to send data buffer(user manual for more details)</param>
        /// <param name="dwInLength">the correspond buffer size, unit:byte</param>
        /// <param name="pOutBuf">out buff(ACS_ABILITY is described with XML)</param>
        /// <param name="dwOutLength">the correspond buffer size, unit:byte</param>
        /// <returns>TRUE表示成功，FALSE表示失败。</returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        /// <summary>
        /// 设置/获取参数关键字
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwParameterKey"></param>
        /// <param name="nValue"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);

        /// <summary>
        /// 获取/设置行为分析目标叠加接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDrawMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        /// <summary>
        /// 双摄像机跟踪模式设置接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpTrackMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);

        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn);
        /// <summary>
        /// 重启智能库
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileName)]
        public static extern bool NET_VCA_RestartLib(int lUserID, int lChannel);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Int64 wParam, Int64 lParam);

        #region // 显示实现方法
        bool IHikHCNetSdkProxy.NET_DVR_AddDVR(int lUserID)
            => NET_DVR_AddDVR(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan)
            => NET_DVR_AddDVR_V30(lUserID, dwVoiceChan);

        bool IHikHCNetSdkProxy.NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable)
            => NET_DVR_AudioPreview_Card(lRealHandle, bEnable);

        bool IHikHCNetSdkProxy.NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName)
            => NET_DVR_CaptureJPEGPicture(lUserID, lChannel, ref lpJpegPara, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned)
            => NET_DVR_CaptureJPEGPicture_NEW(lUserID, lChannel, ref lpJpegPara, sJpegPicBuffer, dwPicSize, ref lpSizeReturned);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePicture(int lRealHandle, string sPicFileName)
            => NET_DVR_CapturePicture(lRealHandle, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePictureBlock(int lRealHandle, string sPicFileName, int dwTimeOut)
            => NET_DVR_CapturePictureBlock(lRealHandle, sPicFileName, dwTimeOut);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName)
            => NET_DVR_CapturePicture_Card(lRealHandle, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_Cleanup()
            => NET_DVR_Cleanup();

        bool IHikHCNetSdkProxy.NET_DVR_ClearSurface_Card()
            => NET_DVR_ClearSurface_Card();

        bool IHikHCNetSdkProxy.NET_DVR_ClickKey(int lUserID, int lKeyIndex)
            => NET_DVR_ClickKey(lUserID, lKeyIndex);

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStart()
            => NET_DVR_ClientAudioStart();

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser)
            => NET_DVR_ClientAudioStart_V30(fVoiceAudioStart, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStop()
            => NET_DVR_ClientAudioStop();

        bool IHikHCNetSdkProxy.NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat)
            => NET_DVR_ClientGetframeformat(lUserID, ref lpFrameFormat);

        bool IHikHCNetSdkProxy.NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue)
            => NET_DVR_ClientGetVideoEffect(lRealHandle, ref pBrightValue, ref pContrastValue, ref pSaturationValue, ref pHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat)
            => NET_DVR_ClientSetframeformat(lUserID, ref lpFrameFormat);

        bool IHikHCNetSdkProxy.NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue)
            => NET_DVR_ClientSetVideoEffect(lRealHandle, dwBrightValue, dwContrastValue, dwSaturationValue, dwHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_CloseAlarmChan(int lAlarmHandle)
            => NET_DVR_CloseAlarmChan(lAlarmHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseAlarmChan_V30(int lAlarmHandle)
            => NET_DVR_CloseAlarmChan_V30(lAlarmHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseFindPicture(int lFindHandle)
            => NET_DVR_CloseFindPicture(lFindHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseFormatHandle(int lFormatHandle)
            => NET_DVR_CloseFormatHandle(lFormatHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseSound()
            => NET_DVR_CloseSound();

        bool IHikHCNetSdkProxy.NET_DVR_CloseSoundShare(int lRealHandle)
            => NET_DVR_CloseSoundShare(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseSound_Card(int lRealHandle)
            => NET_DVR_CloseSound_Card(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseUpgradeHandle(int lUpgradeHandle)
            => NET_DVR_CloseUpgradeHandle(lUpgradeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseUploadHandle(int lUploadHandle)
            => NET_DVR_CloseUploadHandle(lUploadHandle);

        bool IHikHCNetSdkProxy.NET_DVR_ContinuousShoot(int lUserID, ref NET_DVR_SNAPCFG lpInter)
            => NET_DVR_ContinuousShoot(lUserID, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic)
            => NET_DVR_ControlGateway(lUserID, lGatewayIndex, dwStaic);

        bool IHikHCNetSdkProxy.NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode)
            => NET_DVR_DecCtrlDec(lUserID, lChannel, dwControlCode);

        bool IHikHCNetSdkProxy.NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl)
            => NET_DVR_DecCtrlScreen(lUserID, lChannel, dwControl);

        bool IHikHCNetSdkProxy.NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer)
            => NET_DVR_DecodeG711Frame(iType, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer)
            => NET_DVR_DecodeG722Frame(pDecHandle, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo)
            => NET_DVR_DecPlayBackCtrl(lUserID, lChannel, dwControlCode, dwInValue, ref LPOutValue, ref lpRemoteFileInfo);

        bool IHikHCNetSdkProxy.NET_DVR_DelDVR(int lUserID)
            => NET_DVR_DelDVR(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_DelDVR_V30(int lVoiceHandle)
            => NET_DVR_DelDVR_V30(lVoiceHandle);

        bool IHikHCNetSdkProxy.NET_DVR_EmailTest(int lUserID) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_EmailTest(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param)
            => NET_DVR_EncodeG711Frame(handle, ref p_enc_proc_param);

        bool IHikHCNetSdkProxy.NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer)
            => NET_DVR_EncodeG722Frame(pEncodeHandle, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_FindClose(int lFindHandle)
            => NET_DVR_FindClose(lFindHandle);

        bool IHikHCNetSdkProxy.NET_DVR_FindClose_V30(int lFindHandle)
            => NET_DVR_FindClose_V30(lFindHandle);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => NET_DVR_FindDVRLog(lUserID, lSelectMode, dwMajorType, dwMinorType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => NET_DVR_FindDVRLog_Matrix(iUserID, lSelectMode, dwMajorType, dwMinorType, ref lpVedioPlatLog, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart)
            => NET_DVR_FindDVRLog_V30(lUserID, lSelectMode, dwMajorType, dwMinorType, ref lpStartTime, ref lpStopTime, bOnlySmart);

        int IHikHCNetSdkProxy.NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => NET_DVR_FindFile(lUserID, lChannel, dwFileType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => NET_DVR_FindFileByCard(lUserID, lChannel, dwFileType, nFindType, ref sCardNumber, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam)
            => NET_DVR_FindFileByEvent(lUserID, ref lpSearchEventParam);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam)
            => NET_DVR_FindFileByEvent_V40(lUserID, ref lpSearchEventParam);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_FindFile_Card(lUserID, lChannel, dwFileType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond)
            => NET_DVR_FindFile_V30(lUserID, ref pFindCond);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond)
            => NET_DVR_FindFile_V40(lUserID, ref pFindCond);

        bool IHikHCNetSdkProxy.NET_DVR_FindLogClose(int lLogHandle)
            => NET_DVR_FindLogClose(lLogHandle);

        bool IHikHCNetSdkProxy.NET_DVR_FindLogClose_V30(int lLogHandle)
            => NET_DVR_FindLogClose_V30(lLogHandle);

        int IHikHCNetSdkProxy.NET_DVR_FindNextEvent(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET lpSearchEventRet)
            => NET_DVR_FindNextEvent(lSearchHandle, ref lpSearchEventRet);

        int IHikHCNetSdkProxy.NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet)
            => NET_DVR_FindNextEvent_V40(lSearchHandle, ref lpSearchEventRet);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData)
            => NET_DVR_FindNextFile(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData)
            => NET_DVR_FindNextFile_Card(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData)
            => NET_DVR_FindNextFile_V30(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData)
            => NET_DVR_FindNextFile_V40(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData)
            => NET_DVR_FindNextLog(lLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData)
            => NET_DVR_FindNextLog_MATRIX(iLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData)
            => NET_DVR_FindNextLog_V30(lLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData)
            => NET_DVR_FindNextPicture_V50(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam)
            => NET_DVR_FindPicture(lUserID, ref pFindParam);

        int IHikHCNetSdkProxy.NET_DVR_FormatDisk(int lUserID, int lDiskNumber)
            => NET_DVR_FormatDisk(lUserID, lDiskNumber);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser)
            => NET_DVR_GetAlarmDeviceUser(lUserID, lUserIndex, ref lpDeviceUser);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState)
            => NET_DVR_GetAlarmOut(lUserID, ref lpAlarmOutState);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState)
            => NET_DVR_GetAlarmOut_V30(lUserID, lpAlarmOutState);

        bool IHikHCNetSdkProxy.NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort)
            => NET_DVR_GetATMPortCFG(lUserID, ref LPOutATMPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetAtmProtocol(lUserID, ref lpAtmProtocol);

        bool IHikHCNetSdkProxy.NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue)
            => NET_DVR_GetBehaviorParamKey(lUserID, lChannel, dwParameterKey, ref pValue);

        int IHikHCNetSdkProxy.NET_DVR_GetCardLastError_Card()
            => NET_DVR_GetCardLastError_Card();

        bool IHikHCNetSdkProxy.NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetCCDCfg(lUserID, lChannel, ref lpCCDCfg);

        IntPtr IHikHCNetSdkProxy.NET_DVR_GetChanHandle_Card(int lRealHandle)
            => NET_DVR_GetChanHandle_Card(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile(int lUserID, string sFileName)
            => NET_DVR_GetConfigFile(lUserID, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize)
            => NET_DVR_GetConfigFile_EX(lUserID, sOutBuffer, dwOutSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize)
            => NET_DVR_GetConfigFile_V30(lUserID, sOutBuffer, dwOutSize, ref pReturnSize);

        int IHikHCNetSdkProxy.NET_DVR_GetDDrawDeviceTotalNums()
            => NET_DVR_GetDDrawDeviceTotalNums();

        bool IHikHCNetSdkProxy.NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus)
            => NET_DVR_GetDecCurLinkStatus(lUserID, lChannel, ref lpDecStatus);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo)
            => NET_DVR_GetDecInfo(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState)
            => NET_DVR_GetDecoderState(lUserID, lChannel, ref lpDecoderState);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort)
            => NET_DVR_GetDecTransPort(lUserID, ref lpTransPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength)
            => NET_DVR_GetDeviceAbility(lUserID, dwAbilityType, pInBuf, dwInLength, pOutBuf, dwOutLength);

        bool IHikHCNetSdkProxy.NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => NET_DVR_GetDeviceConfig(lUserID, dwCommand, dwCount, lpInBuffer, dwInBufferSize, lpStatusList, lpOutBuffer, dwOutBufferSize);

        int IHikHCNetSdkProxy.NET_DVR_GetDownloadPos(int lFileHandle)
            => NET_DVR_GetDownloadPos(lFileHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned)
            => NET_DVR_GetDVRConfig(lUserID, dwCommand, lChannel, lpOutBuffer, dwOutBufferSize, ref lpBytesReturned);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP)
            => NET_DVR_GetDVRIPByResolveSvr(sServerIP, wServerPort, sDVRName, wDVRNameLen, sDVRSerialNumber, wDVRSerialLen, pGetIP);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort)
            => NET_DVR_GetDVRIPByResolveSvr_EX(sServerIP, wServerPort, sDVRName, wDVRNameLen, sDVRSerialNumber, wDVRSerialLen, sGetIP, ref dwPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState)
            => NET_DVR_GetDVRWorkState(lUserID, ref lpWorkState);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState)
            => NET_DVR_GetDVRWorkState_V30(lUserID, pWorkState);

        IntPtr IHikHCNetSdkProxy.NET_DVR_GetErrorMsg(ref int pErrorNo)
            => NET_DVR_GetErrorMsg(ref pErrorNo);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName)
            => NET_DVR_GetFileByName(lUserID, sDVRFileName, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName)
            => NET_DVR_GetFileByTime(lUserID, lChannel, ref lpStartTime, ref lpStopTime, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond)
            => NET_DVR_GetFileByTime_V40(lUserID, sSavedFileName, ref pDownloadCond);

        bool IHikHCNetSdkProxy.NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic)
            => NET_DVR_GetFormatProgress(lFormatHandle, ref pCurrentFormatDisk, ref pCurrentDiskPos, ref pFormatStatic);

        bool IHikHCNetSdkProxy.NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList)
            => NET_DVR_GetInputSignalList_V40(lUserID, dwDevNum, ref lpInputSignalList);

        bool IHikHCNetSdkProxy.NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList)
            => NET_DVR_GetIPCProtoList(lUserID, ref lpProtoList);

        bool IHikHCNetSdkProxy.NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList)
            => NET_DVR_GetIPCProtoList_V41(lUserID, ref lpProtoList);

        uint IHikHCNetSdkProxy.NET_DVR_GetLastError()
            => NET_DVR_GetLastError();

        bool IHikHCNetSdkProxy.NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetLFTrackMode(lUserID, lChannel, ref lpTrackMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref bool pEnableBind)
            => NET_DVR_GetLocalIP(strIP, ref pValidNum, ref pEnableBind);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, int dwOutBuffSize)
            => NET_DVR_GetNextRemoteConfig(lHandle, lpOutBuff, dwOutBuffSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetParamSetMode(lUserID, ref dwParamSetMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetPicture(int lUserID, string sDVRFileName, string sSavedFileName)
            => NET_DVR_GetPicture(lUserID, sDVRFileName, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetPicUploadProgress(int lUploadHandle)
            => NET_DVR_GetPicUploadProgress(lUploadHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetPicUploadState(int lUploadHandle)
            => NET_DVR_GetPicUploadState(lUploadHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime)
            => NET_DVR_GetPlayBackOsdTime(lPlayHandle, ref lpOsdTime);

        int IHikHCNetSdkProxy.NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle)
            => NET_DVR_GetPlayBackPlayerIndex(lPlayHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetPlayBackPos(int lPlayHandle)
            => NET_DVR_GetPlayBackPos(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet)
            => NET_DVR_GetPTZCruise(lUserID, lChannel, lCruiseRoute, ref lpCruiseRet);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCtrl(int lRealHandle)
            => NET_DVR_GetPTZCtrl(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCtrl_Other(int lUserID, int lChannel)
            => NET_DVR_GetPTZCtrl_Other(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg)
            => NET_DVR_GetPTZProtocol(lUserID, ref pPtzcfg);

        bool IHikHCNetSdkProxy.NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpHeight) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetRealHeight(lUserID, lChannel, ref lpLine, ref lpHeight);

        bool IHikHCNetSdkProxy.NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpLength) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_GetRealLength(lUserID, lChannel, ref lpLine, ref lpLength);

        int IHikHCNetSdkProxy.NET_DVR_GetRealPlayerIndex(int lRealHandle)
            => NET_DVR_GetRealPlayerIndex(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState)
            => NET_DVR_GetRemoteConfigState(lHandle, pState);

        bool IHikHCNetSdkProxy.NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize)
            => NET_DVR_GetRtspConfig(lUserID, dwCommand, ref lpOutBuffer, dwOutBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale)
            => NET_DVR_GetScaleCFG(lUserID, ref lpOutScale);

        bool IHikHCNetSdkProxy.NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg)
            => NET_DVR_GetScaleCFG_V30(lUserID, ref pScalecfg);

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl)
            => NET_DVR_GetSDKAbility(ref pSDKAbl);

        uint IHikHCNetSdkProxy.NET_DVR_GetSDKBuildVersion()
            => NET_DVR_GetSDKBuildVersion();

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff)
            => NET_DVR_GetSDKLocalCfg(enumType, lpOutBuff);

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState)
            => NET_DVR_GetSDKState(ref pSDKState);

        uint IHikHCNetSdkProxy.NET_DVR_GetSDKVersion()
            => NET_DVR_GetSDKVersion();

        bool IHikHCNetSdkProxy.NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo)
            => NET_DVR_GetSerialNum_Card(lChannelNum, ref pDeviceSerialNo);

        bool IHikHCNetSdkProxy.NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam)
            => NET_DVR_GetSTDConfig(iUserID, dwCommand, ref lpConfigParam);

        int IHikHCNetSdkProxy.NET_DVR_GetUpgradeProgress(int lUpgradeHandle)
            => NET_DVR_GetUpgradeProgress(lUpgradeHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetUpgradeState(int lUpgradeHandle)
            => NET_DVR_GetUpgradeState(lUpgradeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => NET_DVR_GetUploadResult(lUploadHandle, lpOutBuffer, dwOutBufferSize);

        int IHikHCNetSdkProxy.NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress)
            => NET_DVR_GetUploadState(lUploadHandle, ref pProgress);

        bool IHikHCNetSdkProxy.NET_DVR_GetUpnpNatState(int lUserID, ref NET_DVR_UPNP_NAT_STATE lpState)
            => NET_DVR_GetUpnpNatState(lUserID, ref lpState);

        bool IHikHCNetSdkProxy.NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode)
            => NET_DVR_GetVCADrawMode(lUserID, lChannel, ref lpDrawMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue)
            => NET_DVR_GetVideoEffect(lUserID, lChannel, ref pBrightValue, ref pContrastValue, ref pSaturationValue, ref pHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_Init()
            => NET_DVR_Init();

        bool IHikHCNetSdkProxy.NET_DVR_InitDDrawDevice()
            => NET_DVR_InitDDrawDevice();

        bool IHikHCNetSdkProxy.NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey)
            => NET_DVR_InitDDraw_Card(hParent, colorKey);

        bool IHikHCNetSdkProxy.NET_DVR_InitDevice_Card(ref int pDeviceTotalChan)
            => NET_DVR_InitDevice_Card(ref pDeviceTotalChan);

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info)
        {
            if (Environment.Is64BitProcess) { return NET_DVR_InitG711Encoder(ref enc_info); }
            throw new NotSupportedException("未找到方法内容，不支持32位请求");
        }

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG722Decoder(int nBitrate)
            => NET_DVR_InitG722Decoder(nBitrate);

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG722Encoder()
            => NET_DVR_InitG722Encoder();

        bool IHikHCNetSdkProxy.NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn)
            => NET_DVR_InquestStartCDW_V30(lUserID, ref lpInquestRoom, bNotBurn);

        int IHikHCNetSdkProxy.NET_DVR_IsSupport()
            => NET_DVR_IsSupport();

        bool IHikHCNetSdkProxy.NET_DVR_LockFileByName(int lUserID, string sLockFileName)
            => NET_DVR_LockFileByName(lUserID, sLockFileName);

        bool IHikHCNetSdkProxy.NET_DVR_LockPanel(int lUserID)
            => NET_DVR_LockPanel(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo)
            => NET_DVR_Login(sDVRIP, wDVRPort, sUserName, sPassword, ref lpDeviceInfo);

        int IHikHCNetSdkProxy.NET_DVR_Login_V30(string sDVRIP, int wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo)
            => NET_DVR_Login_V30(sDVRIP, wDVRPort, sUserName, sPassword, ref lpDeviceInfo);

        int IHikHCNetSdkProxy.NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo)
            => NET_DVR_Login_V40(ref pLoginInfo, ref lpDeviceInfo);

        bool IHikHCNetSdkProxy.NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch)
            => NET_DVR_LogoSwitch(lUserID, dwDecChan, dwLogoSwitch);

        bool IHikHCNetSdkProxy.NET_DVR_Logout(int iUserID)
            => NET_DVR_Logout(iUserID);

        bool IHikHCNetSdkProxy.NET_DVR_Logout_V30(int lUserID)
            => NET_DVR_Logout_V30(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_MakeKeyFrame(int lUserID, int lChannel)
            => NET_DVR_MakeKeyFrame(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_MakeKeyFrameSub(int lUserID, int lChannel)
            => NET_DVR_MakeKeyFrameSub(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_ManualSnap(int lUserID, ref NET_DVR_MANUALSNAP lpInter, ref NET_DVR_PLATE_RESULT lpOuter)
            => NET_DVR_ManualSnap(lUserID, ref lpInter, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam)
            => NET_DVR_MatrixDiaplayControl(lUserID, dwDispChanNum, dwDispChanCmd, dwCmdParam);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable)
            => NET_DVR_MatrixGetDecChanEnable(lUserID, dwDecChanNum, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter)
            => NET_DVR_MatrixGetDecChanInfo(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter)
            => NET_DVR_MatrixGetDecChanInfo_V30(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter)
            => NET_DVR_MatrixGetDecChanInfo_V41(lUserID, dwDecChanNum, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter)
            => NET_DVR_MatrixGetDecChanStatus(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg)
            => NET_DVR_MatrixGetDeviceStatus(lUserID, ref lpDecoderCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg)
            => NET_DVR_MatrixGetDisplayCfg(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg)
            => NET_DVR_MatrixGetDisplayCfg_V41(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable)
            => NET_DVR_MatrixGetLoopDecChanEnable(lUserID, dwDecChanNum, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter)
            => NET_DVR_MatrixGetLoopDecChanInfo(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter)
            => NET_DVR_MatrixGetLoopDecChanInfo_V30(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable)
            => NET_DVR_MatrixGetLoopDecEnable(lUserID, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter)
            => NET_DVR_MatrixGetRemotePlayStatus(lUserID, dwDecChanNum, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg)
            => NET_DVR_MatrixGetSceneCfg(lUserID, dwSceneNum, ref lpSceneCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo)
            => NET_DVR_MatrixGetTranInfo(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo)
            => NET_DVR_MatrixGetTranInfo_V30(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSendData(int lPassiveHandle, IntPtr pSendBuf, uint dwBufSize)
            => NET_DVR_MatrixSendData(lPassiveHandle, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable)
            => NET_DVR_MatrixSetDecChanEnable(lUserID, dwDecChanNum, dwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg)
            => NET_DVR_MatrixSetDisplayCfg(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg)
            => NET_DVR_MatrixSetDisplayCfg_V41(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable)
            => NET_DVR_MatrixSetLoopDecChanEnable(lUserID, dwDecChanNum, dwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter)
            => NET_DVR_MatrixSetLoopDecChanInfo(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter)
            => NET_DVR_MatrixSetLoopDecChanInfo_V30(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter)
            => NET_DVR_MatrixSetRemotePlay(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue)
            => NET_DVR_MatrixSetRemotePlayControl(lUserID, dwDecChanNum, dwControlCode, dwInValue, ref LPOutValue);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg)
            => NET_DVR_MatrixSetSceneCfg(lUserID, dwSceneNum, ref lpSceneCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo)
            => NET_DVR_MatrixSetTranInfo(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo)
            => NET_DVR_MatrixSetTranInfo_V30(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo)
            => NET_DVR_MatrixStartDynamic(lUserID, dwDecChanNum, ref lpDynamicInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo)
            => NET_DVR_MatrixStartDynamic_V30(lUserID, dwDecChanNum, ref lpDynamicInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo)
            => NET_DVR_MatrixStartDynamic_V41(lUserID, dwDecChanNum, ref lpDynamicInfo);

        int IHikHCNetSdkProxy.NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode)
            => NET_DVR_MatrixStartPassiveDecode(lUserID, dwDecChanNum, ref lpPassiveMode);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum)
            => NET_DVR_MatrixStopDynamic(lUserID, dwDecChanNum);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle)
            => NET_DVR_MatrixStopPassiveDecode(lPassiveHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSound(int lRealHandle)
            => NET_DVR_OpenSound(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSoundShare(int lRealHandle)
            => NET_DVR_OpenSoundShare(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSound_Card(int lRealHandle)
            => NET_DVR_OpenSound_Card(lRealHandle);

        int IHikHCNetSdkProxy.NET_DVR_PicUpload(int lUserID, string sFileName, ref NET_DVR_PICTURECFG lpPictureCfg)
            => NET_DVR_PicUpload(lUserID, sFileName, ref lpPictureCfg);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd)
            => NET_DVR_PlayBackByName(lUserID, sPlayBackFileName, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, IntPtr hWnd)
            => NET_DVR_PlayBackByTime(lUserID, lChannel, ref lpStartTime, ref lpStopTime, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara)
            => NET_DVR_PlayBackByTime_V40(lUserID, ref pVodPara);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName)
            => NET_DVR_PlayBackCaptureFile(lPlayHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue)
            => NET_DVR_PlayBackControl(lPlayHandle, dwControlCode, dwInValue, ref LPOutValue);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue)
            => NET_DVR_PlayBackControl_V40(lPlayHandle, dwControlCode, lpInBuffer, dwInValue, lpOutBuffer, ref LPOutValue);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd)
            => NET_DVR_PlayBackReverseByName(lUserID, sPlayBackFileName, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond)
            => NET_DVR_PlayBackReverseByTime_V40(lUserID, hWnd, ref pPlayCond);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName)
            => NET_DVR_PlayBackSaveData(lPlayHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl(int lRealHandle, uint dwPTZCommand, uint dwStop)
            => NET_DVR_PTZControl(lRealHandle, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => NET_DVR_PTZControlWithSpeed(lRealHandle, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => NET_DVR_PTZControlWithSpeed_EX(lRealHandle, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => NET_DVR_PTZControlWithSpeed_Other(lUserID, lChannel, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop)
            => NET_DVR_PTZControl_EX(lRealHandle, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop)
            => NET_DVR_PTZControl_Other(lUserID, lChannel, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => NET_DVR_PTZCruise(lRealHandle, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => NET_DVR_PTZCruise_EX(lRealHandle, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => NET_DVR_PTZCruise_Other(lUserID, lChannel, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_PTZMltTrack(lRealHandle, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_PTZMltTrack_EX(lRealHandle, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_PTZMltTrack_Other(lUserID, lChannel, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex)
            => NET_DVR_PTZPreset(lRealHandle, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex)
            => NET_DVR_PTZPreset_EX(lRealHandle, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex)
            => NET_DVR_PTZPreset_Other(lUserID, lChannel, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame)
            => NET_DVR_PTZSelZoomIn(lRealHandle, ref pStruPointFrame);

        bool IHikHCNetSdkProxy.NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame)
            => NET_DVR_PTZSelZoomIn_EX(lUserID, lChannel, ref pStruPointFrame);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd)
            => NET_DVR_PTZTrack(lRealHandle, dwPTZTrackCmd);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd)
            => NET_DVR_PTZTrack_EX(lRealHandle, dwPTZTrackCmd);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd)
            => NET_DVR_PTZTrack_Other(lUserID, lChannel, dwPTZTrackCmd);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo)
            => NET_DVR_RealPlay(iUserID, ref lpClientInfo);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum)
            => NET_DVR_RealPlay_Card(lUserID, ref lpCardInfo, lChannelNum);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, uint bBlocked)
            => NET_DVR_RealPlay_V30(iUserID, ref lpClientInfo, fRealDataCallBack_V30, pUser, bBlocked);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser)
            => NET_DVR_RealPlay_V40(iUserID, ref lpPreviewInfo, fRealDataCallBack_V30, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_RebootDVR(int lUserID)
            => NET_DVR_RebootDVR(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_RefreshPlay(int lPlayHandle)
            => NET_DVR_RefreshPlay(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_RefreshSurface_Card()
            => NET_DVR_RefreshSurface_Card();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDDrawDevice()
            => NET_DVR_ReleaseDDrawDevice();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDDraw_Card()
            => NET_DVR_ReleaseDDraw_Card();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDevice_Card()
            => NET_DVR_ReleaseDevice_Card();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle)
        {
            if (Environment.Is64BitProcess) { return NET_DVR_ReleaseG711Encoder(pEncodeHandle); }
            throw new NotSupportedException("未找到方法内容，不支持32位请求");
        }

        void IHikHCNetSdkProxy.NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle)
            => NET_DVR_ReleaseG722Decoder(pDecHandle);

        void IHikHCNetSdkProxy.NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle)
            => NET_DVR_ReleaseG722Encoder(pEncodeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize)
            => NET_DVR_RemoteControl(lUserID, dwCommand, lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize)
            => NET_DVR_RemoteControl(lUserID, dwCommand, ref lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara)
            => NET_DVR_ResetPara_Card(lRealHandle, ref lpDisplayPara);

        bool IHikHCNetSdkProxy.NET_DVR_RestoreConfig(int lUserID)
            => NET_DVR_RestoreConfig(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_RestoreSurface_Card()
            => NET_DVR_RestoreSurface_Card();

        bool IHikHCNetSdkProxy.NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser)
            => NET_DVR_RigisterDrawFun(lRealHandle, fDrawFun, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SaveConfig(int lUserID)
            => NET_DVR_SaveConfig(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_SaveRealData(int lRealHandle, string sFileName)
            => NET_DVR_SaveRealData(lRealHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName)
            => NET_DVR_SaveRealData_V30(lRealHandle, dwTransType, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize)
            => NET_DVR_SendRemoteConfig(lHandle, dwDataType, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize)
            => NET_DVR_SendTo232Port(lUserID, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize)
            => NET_DVR_SendToSerialPort(lUserID, dwSerialPort, dwSerialIndex, pSendBuf, dwBufSize);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen)
            => NET_DVR_SendWithRecvRemoteConfig(lHandle, lpInBuff, dwInBuffSize, lpOutBuff, dwOutBuffSize, ref dwOutDataLen);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen)
            => NET_DVR_SendWithRecvRemoteConfig(lHandle, ref lpInBuff, dwInBuffSize, ref lpOutBuff, dwOutBuffSize, dwOutDataLen);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen)
            => NET_DVR_SendWithRecvRemoteConfig(lHandle, ref lpInBuff, dwInBuffSize, ref lpOutBuff, dwOutBuffSize, dwOutDataLen);

        bool IHikHCNetSdkProxy.NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize)
            => NET_DVR_SerialSend(lSerialHandle, lChannel, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser)
            => NET_DVR_SerialStart(lUserID, lSerialPort, fSerialDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SerialStop(int lSerialHandle)
            => NET_DVR_SerialStop(lSerialHandle);

        bool IHikHCNetSdkProxy.NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser)
            => NET_DVR_SetAlarmDeviceUser(lUserID, lUserIndex, ref lpDeviceUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic)
            => NET_DVR_SetAlarmOut(lUserID, lAlarmOutPort, lAlarmOutStatic);

        bool IHikHCNetSdkProxy.NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort)
            => NET_DVR_SetATMPortCFG(lUserID, wATMPort);

        bool IHikHCNetSdkProxy.NET_DVR_SetAudioMode(uint dwMode)
            => NET_DVR_SetAudioMode(dwMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue)
            => NET_DVR_SetBehaviorParamKey(lUserID, lChannel, dwParameterKey, nValue);

        bool IHikHCNetSdkProxy.NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_SetCCDCfg(lUserID, lChannel, ref lpCCDCfg);

        bool IHikHCNetSdkProxy.NET_DVR_SetConfigFile(int lUserID, string sFileName)
            => NET_DVR_SetConfigFile(lUserID, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize)
            => NET_DVR_SetConfigFile_EX(lUserID, sInBuffer, dwInSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes)
            => NET_DVR_SetConnectTime(dwWaitTime, dwTryTimes);

        bool IHikHCNetSdkProxy.NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum)
            => NET_DVR_SetDDrawDevice(lPlayPort, nDeviceNum);

        bool IHikHCNetSdkProxy.NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo)
            => NET_DVR_SetDecInfo(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort)
            => NET_DVR_SetDecTransPort(lUserID, ref lpTransPort);

        bool IHikHCNetSdkProxy.NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize)
            => NET_DVR_SetDeviceConfig(lUserID, dwCommand, dwCount, lpInBuffer, dwInBufferSize, lpStatusList, lpInParamBuffer, dwInParamBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetDeviceConfigEx(int lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam)
            => NET_DVR_SetDeviceConfigEx(lUserID, dwCommand, dwCount, ref lpInParam, ref lpOutParam);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize)
            => NET_DVR_SetDVRConfig(lUserID, dwCommand, lChannel, lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd)
            => NET_DVR_SetDVRMessage(nMessage, hWnd);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser)
            => NET_DVR_SetDVRMessageCallBack(fMessageCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser)
            => NET_DVR_SetDVRMessageCallBack_V30(fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser)
            => NET_DVR_SetDVRMessageCallBack_V31(fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser)
            => NET_DVR_SetDVRMessageCallBack_V50(iIndex, fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack)
            => NET_DVR_SetDVRMessCallBack(fMessCallBack);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX)
            => NET_DVR_SetDVRMessCallBack_EX(fMessCallBack_EX);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW)
            => NET_DVR_SetDVRMessCallBack_NEW(fMessCallBack_NEW);

        bool IHikHCNetSdkProxy.NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser)
            => NET_DVR_SetExceptionCallBack_V30(nMessage, hWnd, fExceptionCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode) => throw new NotImplementedException("未找到方法内容");
        // => NET_DVR_SetLFTrackMode(lUserID, lChannel, ref lpTrackMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel)
            => NET_DVR_SetLogToFile(nLogLevel, strLogDir, bAutoDel);

        bool IHikHCNetSdkProxy.NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel)
            => NET_DVR_SetNetworkEnvironment(dwEnvironmentLevel);

        bool IHikHCNetSdkProxy.NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser)
            => NET_DVR_SetPlayDataCallBack(lPlayHandle, fPlayDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetPlayerBufNumber(int lRealHandle, uint dwBufNum)
            => NET_DVR_SetPlayerBufNumber(lRealHandle, dwBufNum);

        bool IHikHCNetSdkProxy.NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser)
            => NET_DVR_SetRealDataCallBack(lRealHandle, fRealDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon)
            => NET_DVR_SetReconnect(dwInterval, bEnableRecon);

        bool IHikHCNetSdkProxy.NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize)
            => NET_DVR_SetRtspConfig(lUserID, dwCommand, ref lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetScaleCFG(int lUserID, uint dwScale)
            => NET_DVR_SetScaleCFG(lUserID, dwScale);

        bool IHikHCNetSdkProxy.NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg)
            => NET_DVR_SetScaleCFG_V30(lUserID, ref pScalecfg);

        bool IHikHCNetSdkProxy.NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff)
            => NET_DVR_SetSDKLocalCfg(enumType, lpInBuff);

        bool IHikHCNetSdkProxy.NET_DVR_SetShowMode(uint dwShowType, uint colorKey)
            => NET_DVR_SetShowMode(dwShowType, colorKey);

        bool IHikHCNetSdkProxy.NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser)
            => NET_DVR_SetStandardDataCallBack(lRealHandle, fStdDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam)
            => NET_DVR_SetSTDConfig(iUserID, dwCommand, ref lpConfigParam);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan(int lUserID)
            => NET_DVR_SetupAlarmChan(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan_V30(int lUserID)
            => NET_DVR_SetupAlarmChan_V30(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam)
            => NET_DVR_SetupAlarmChan_V41(lUserID, ref lpSetupParam);

        bool IHikHCNetSdkProxy.NET_DVR_SetValidIP(uint dwIPIndex, bool bEnableBind)
            => NET_DVR_SetValidIP(dwIPIndex, bEnableBind);

        bool IHikHCNetSdkProxy.NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode)
            => NET_DVR_SetVCADrawMode(lUserID, lChannel, ref lpDrawMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue)
            => NET_DVR_SetVideoEffect(lUserID, lChannel, dwBrightValue, dwContrastValue, dwSaturationValue, dwHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume)
            => NET_DVR_SetVoiceComClientVolume(lVoiceComHandle, wVolume);

        bool IHikHCNetSdkProxy.NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume)
            => NET_DVR_SetVolume_Card(lRealHandle, wVolume);

        bool IHikHCNetSdkProxy.NET_DVR_ShutDownDVR(int lUserID)
            => NET_DVR_ShutDownDVR(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo)
            => NET_DVR_StartDecode(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo)
            => NET_DVR_StartDecSpecialCon(lUserID, lChannel, ref lpDecChanInfo);

        bool IHikHCNetSdkProxy.NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType)
            => NET_DVR_StartDVRRecord(lUserID, lChannel, lRecordType);

        bool IHikHCNetSdkProxy.NET_DVR_StartListen(string sLocalIP, ushort wLocalPort)
            => NET_DVR_StartListen(sLocalIP, wLocalPort);

        int IHikHCNetSdkProxy.NET_DVR_StartListen_V30(string sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData)
            => NET_DVR_StartListen_V30(sLocalIP, wLocalPort, DataCallback, pUserData);

        int IHikHCNetSdkProxy.NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData)
            => NET_DVR_StartRemoteConfig(lUserID, dwCommand, lpInBuffer, dwInBufferLen, cbStateCallback, pUserData);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser)
            => NET_DVR_StartVoiceCom(lUserID, fVoiceDataCallBack, dwUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser)
            => NET_DVR_StartVoiceCom_MR(lUserID, fVoiceDataCallBack, dwUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser)
            => NET_DVR_StartVoiceCom_MR_V30(lUserID, dwVoiceChan, fVoiceDataCallBack, pUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser)
            => NET_DVR_StartVoiceCom_V30(lUserID, dwVoiceChan, bNeedCBNoEncData, fVoiceDataCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam)
            => NET_DVR_STDXMLConfig(lUserID, lpInputParam, lpOutputParam);

        bool IHikHCNetSdkProxy.NET_DVR_STDXMLConfig(int iUserID, ref NET_DVR_XML_CONFIG_INPUT lpInputParam, ref NET_DVR_XML_CONFIG_OUTPUT lpOutputParam)
            => NET_DVR_STDXMLConfig(iUserID, ref lpInputParam, ref lpOutputParam);

        bool IHikHCNetSdkProxy.NET_DVR_StopDecode(int lUserID, int lChannel)
            => NET_DVR_StopDecode(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo)
            => NET_DVR_StopDecSpecialCon(lUserID, lChannel, ref lpDecChanInfo);

        bool IHikHCNetSdkProxy.NET_DVR_StopDVRRecord(int lUserID, int lChannel)
            => NET_DVR_StopDVRRecord(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_StopGetFile(int lFileHandle)
            => NET_DVR_StopGetFile(lFileHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopListen()
            => NET_DVR_StopListen();

        bool IHikHCNetSdkProxy.NET_DVR_StopListen_V30(int lListenHandle)
            => NET_DVR_StopListen_V30(lListenHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopPlayBack(int lPlayHandle)
            => NET_DVR_StopPlayBack(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopPlayBackSave(int lPlayHandle)
            => NET_DVR_StopPlayBackSave(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopRealPlay(int iRealHandle)
            => NET_DVR_StopRealPlay(iRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopRemoteConfig(int lHandle)
            => NET_DVR_StopRemoteConfig(lHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopSaveRealData(int lRealHandle)
            => NET_DVR_StopSaveRealData(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopVoiceCom(int lVoiceComHandle)
            => NET_DVR_StopVoiceCom(lVoiceComHandle);

        bool IHikHCNetSdkProxy.NET_DVR_ThrowBFrame(int lRealHandle, uint dwNum)
            => NET_DVR_ThrowBFrame(lRealHandle, dwNum);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ(int lRealHandle, string pPTZCodeBuf, uint dwBufSize)
            => NET_DVR_TransPTZ(lRealHandle, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize)
            => NET_DVR_TransPTZ_EX(lRealHandle, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize)
            => NET_DVR_TransPTZ_Other(lUserID, lChannel, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName)
            => NET_DVR_UnlockFileByName(lUserID, sUnlockFileName);

        bool IHikHCNetSdkProxy.NET_DVR_UnLockPanel(int lUserID)
            => NET_DVR_UnLockPanel(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_Upgrade(int lUserID, string sFileName)
            => NET_DVR_Upgrade(lUserID, sFileName);

        int IHikHCNetSdkProxy.NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, int dwInBufferLen)
            => NET_DVR_Upgrade_V40(lUserID, dwUpgradeType, sFileName, pInbuffer, dwInBufferLen);

        bool IHikHCNetSdkProxy.NET_DVR_UploadClose(int lUploadHandle)
            => NET_DVR_UploadClose(lUploadHandle);

        int IHikHCNetSdkProxy.NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => NET_DVR_UploadFile_V40(lUserID, dwUploadType, lpInBuffer, dwInBufferSize, sFileName, lpOutBuffer, dwOutBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, IntPtr sLogoBuffer)
            => NET_DVR_UploadLogo(lUserID, dwDispChanNum, ref lpDispLogoCfg, sLogoBuffer);

        int IHikHCNetSdkProxy.NET_DVR_UploadSend(int lUploadHandle, ref NET_DVR_SEND_PARAM_IN pstruSendParamIN, IntPtr lpOutBuffer)
            => NET_DVR_UploadSend(lUploadHandle, ref pstruSendParamIN, lpOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize)
            => NET_DVR_VoiceComSendData(lVoiceComHandle, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_Volume(int lRealHandle, ushort wVolume)
            => NET_DVR_Volume(lRealHandle, wVolume);

        int IHikHCNetSdkProxy.NET_SDK_RealPlay(int iUserLogID, ref NET_DVR_CLIENTINFO lpDVRClientInfo) => throw new NotImplementedException("未找到方法内容");
        // => NET_SDK_RealPlay(iUserLogID, ref lpDVRClientInfo);

        bool IHikHCNetSdkProxy.NET_VCA_RestartLib(int lUserID, int lChannel)
            => NET_VCA_RestartLib(lUserID, lChannel);

        int IHikHCNetSdkProxy.PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam)
            => PostMessage(hWnd, Msg, wParam, lParam);
        #endregion 显示实现
    }
    internal class HikHCNetSdkLoader : ASdkDynamicLoader, IHikHCNetSdkProxy
    {
        #region // 委托定义
        private DCreater.NET_DVR_AddDVR _NET_DVR_AddDVR;
        private DCreater.NET_DVR_AddDVR_V30 _NET_DVR_AddDVR_V30;
        private DCreater.NET_DVR_AudioPreview_Card _NET_DVR_AudioPreview_Card;
        private DCreater.NET_DVR_CaptureJPEGPicture _NET_DVR_CaptureJPEGPicture;
        private DCreater.NET_DVR_CaptureJPEGPicture_NEW _NET_DVR_CaptureJPEGPicture_NEW;
        private DCreater.NET_DVR_CapturePicture _NET_DVR_CapturePicture;
        private DCreater.NET_DVR_CapturePictureBlock _NET_DVR_CapturePictureBlock;
        private DCreater.NET_DVR_CapturePicture_Card _NET_DVR_CapturePicture_Card;
        private DCreater.NET_DVR_Cleanup _NET_DVR_Cleanup;
        private DCreater.NET_DVR_ClearSurface_Card _NET_DVR_ClearSurface_Card;
        private DCreater.NET_DVR_ClickKey _NET_DVR_ClickKey;
        private DCreater.NET_DVR_ClientAudioStart _NET_DVR_ClientAudioStart;
        private DCreater.NET_DVR_ClientAudioStart_V30 _NET_DVR_ClientAudioStart_V30;
        private DCreater.NET_DVR_ClientAudioStop _NET_DVR_ClientAudioStop;
        private DCreater.NET_DVR_ClientGetframeformat _NET_DVR_ClientGetframeformat;
        private DCreater.NET_DVR_ClientGetVideoEffect _NET_DVR_ClientGetVideoEffect;
        private DCreater.NET_DVR_ClientSetframeformat _NET_DVR_ClientSetframeformat;
        private DCreater.NET_DVR_ClientSetVideoEffect _NET_DVR_ClientSetVideoEffect;
        private DCreater.NET_DVR_CloseAlarmChan _NET_DVR_CloseAlarmChan;
        private DCreater.NET_DVR_CloseAlarmChan_V30 _NET_DVR_CloseAlarmChan_V30;
        private DCreater.NET_DVR_CloseFindPicture _NET_DVR_CloseFindPicture;
        private DCreater.NET_DVR_CloseFormatHandle _NET_DVR_CloseFormatHandle;
        private DCreater.NET_DVR_CloseSound _NET_DVR_CloseSound;
        private DCreater.NET_DVR_CloseSoundShare _NET_DVR_CloseSoundShare;
        private DCreater.NET_DVR_CloseSound_Card _NET_DVR_CloseSound_Card;
        private DCreater.NET_DVR_CloseUpgradeHandle _NET_DVR_CloseUpgradeHandle;
        private DCreater.NET_DVR_CloseUploadHandle _NET_DVR_CloseUploadHandle;
        private DCreater.NET_DVR_ContinuousShoot _NET_DVR_ContinuousShoot;
        private DCreater.NET_DVR_ControlGateway _NET_DVR_ControlGateway;
        private DCreater.NET_DVR_DecCtrlDec _NET_DVR_DecCtrlDec;
        private DCreater.NET_DVR_DecCtrlScreen _NET_DVR_DecCtrlScreen;
        private DCreater.NET_DVR_DecodeG711Frame _NET_DVR_DecodeG711Frame;
        private DCreater.NET_DVR_DecodeG722Frame _NET_DVR_DecodeG722Frame;
        private DCreater.NET_DVR_DecPlayBackCtrl _NET_DVR_DecPlayBackCtrl;
        private DCreater.NET_DVR_DelDVR _NET_DVR_DelDVR;
        private DCreater.NET_DVR_DelDVR_V30 _NET_DVR_DelDVR_V30;
        private DCreater.NET_DVR_EmailTest _NET_DVR_EmailTest;
        private DCreater.NET_DVR_EncodeG711Frame _NET_DVR_EncodeG711Frame;
        private DCreater.NET_DVR_EncodeG722Frame _NET_DVR_EncodeG722Frame;
        private DCreater.NET_DVR_FindClose _NET_DVR_FindClose;
        private DCreater.NET_DVR_FindClose_V30 _NET_DVR_FindClose_V30;
        private DCreater.NET_DVR_FindDVRLog _NET_DVR_FindDVRLog;
        private DCreater.NET_DVR_FindDVRLog_Matrix _NET_DVR_FindDVRLog_Matrix;
        private DCreater.NET_DVR_FindDVRLog_V30 _NET_DVR_FindDVRLog_V30;
        private DCreater.NET_DVR_FindFile _NET_DVR_FindFile;
        private DCreater.NET_DVR_FindFileByCard _NET_DVR_FindFileByCard;
        private DCreater.NET_DVR_FindFileByEvent _NET_DVR_FindFileByEvent;
        private DCreater.NET_DVR_FindFileByEvent_V40 _NET_DVR_FindFileByEvent_V40;
        private DCreater.NET_DVR_FindFile_Card _NET_DVR_FindFile_Card;
        private DCreater.NET_DVR_FindFile_V30 _NET_DVR_FindFile_V30;
        private DCreater.NET_DVR_FindFile_V40 _NET_DVR_FindFile_V40;
        private DCreater.NET_DVR_FindLogClose _NET_DVR_FindLogClose;
        private DCreater.NET_DVR_FindLogClose_V30 _NET_DVR_FindLogClose_V30;
        private DCreater.NET_DVR_FindNextEvent _NET_DVR_FindNextEvent;
        private DCreater.NET_DVR_FindNextEvent_V40 _NET_DVR_FindNextEvent_V40;
        private DCreater.NET_DVR_FindNextFile _NET_DVR_FindNextFile;
        private DCreater.NET_DVR_FindNextFile_Card _NET_DVR_FindNextFile_Card;
        private DCreater.NET_DVR_FindNextFile_V30 _NET_DVR_FindNextFile_V30;
        private DCreater.NET_DVR_FindNextFile_V40 _NET_DVR_FindNextFile_V40;
        private DCreater.NET_DVR_FindNextLog _NET_DVR_FindNextLog;
        private DCreater.NET_DVR_FindNextLog_MATRIX _NET_DVR_FindNextLog_MATRIX;
        private DCreater.NET_DVR_FindNextLog_V30 _NET_DVR_FindNextLog_V30;
        private DCreater.NET_DVR_FindNextPicture_V50 _NET_DVR_FindNextPicture_V50;
        private DCreater.NET_DVR_FindPicture _NET_DVR_FindPicture;
        private DCreater.NET_DVR_FormatDisk _NET_DVR_FormatDisk;
        private DCreater.NET_DVR_GetAlarmDeviceUser _NET_DVR_GetAlarmDeviceUser;
        private DCreater.NET_DVR_GetAlarmOut _NET_DVR_GetAlarmOut;
        private DCreater.NET_DVR_GetAlarmOut_V30 _NET_DVR_GetAlarmOut_V30;
        private DCreater.NET_DVR_GetATMPortCFG _NET_DVR_GetATMPortCFG;
        private DCreater.NET_DVR_GetAtmProtocol _NET_DVR_GetAtmProtocol;
        private DCreater.NET_DVR_GetBehaviorParamKey _NET_DVR_GetBehaviorParamKey;
        private DCreater.NET_DVR_GetCardLastError_Card _NET_DVR_GetCardLastError_Card;
        private DCreater.NET_DVR_GetCCDCfg _NET_DVR_GetCCDCfg;
        private DCreater.NET_DVR_GetChanHandle_Card _NET_DVR_GetChanHandle_Card;
        private DCreater.NET_DVR_GetConfigFile _NET_DVR_GetConfigFile;
        private DCreater.NET_DVR_GetConfigFile_EX _NET_DVR_GetConfigFile_EX;
        private DCreater.NET_DVR_GetConfigFile_V30 _NET_DVR_GetConfigFile_V30;
        private DCreater.NET_DVR_GetDDrawDeviceTotalNums _NET_DVR_GetDDrawDeviceTotalNums;
        private DCreater.NET_DVR_GetDecCurLinkStatus _NET_DVR_GetDecCurLinkStatus;
        private DCreater.NET_DVR_GetDecInfo _NET_DVR_GetDecInfo;
        private DCreater.NET_DVR_GetDecoderState _NET_DVR_GetDecoderState;
        private DCreater.NET_DVR_GetDecTransPort _NET_DVR_GetDecTransPort;
        private DCreater.NET_DVR_GetDeviceAbility _NET_DVR_GetDeviceAbility;
        private DCreater.NET_DVR_GetDeviceConfig _NET_DVR_GetDeviceConfig;
        private DCreater.NET_DVR_GetDownloadPos _NET_DVR_GetDownloadPos;
        private DCreater.NET_DVR_GetDVRConfig _NET_DVR_GetDVRConfig;
        private DCreater.NET_DVR_GetDVRIPByResolveSvr _NET_DVR_GetDVRIPByResolveSvr;
        private DCreater.NET_DVR_GetDVRIPByResolveSvr_EX _NET_DVR_GetDVRIPByResolveSvr_EX;
        private DCreater.NET_DVR_GetDVRWorkState _NET_DVR_GetDVRWorkState;
        private DCreater.NET_DVR_GetDVRWorkState_V30 _NET_DVR_GetDVRWorkState_V30;
        private DCreater.NET_DVR_GetErrorMsg _NET_DVR_GetErrorMsg;
        private DCreater.NET_DVR_GetFileByName _NET_DVR_GetFileByName;
        private DCreater.NET_DVR_GetFileByTime _NET_DVR_GetFileByTime;
        private DCreater.NET_DVR_GetFileByTime_V40 _NET_DVR_GetFileByTime_V40;
        private DCreater.NET_DVR_GetFormatProgress _NET_DVR_GetFormatProgress;
        private DCreater.NET_DVR_GetInputSignalList_V40 _NET_DVR_GetInputSignalList_V40;
        private DCreater.NET_DVR_GetIPCProtoList _NET_DVR_GetIPCProtoList;
        private DCreater.NET_DVR_GetIPCProtoList_V41 _NET_DVR_GetIPCProtoList_V41;
        private DCreater.NET_DVR_GetLastError _NET_DVR_GetLastError;
        private DCreater.NET_DVR_GetLFTrackMode _NET_DVR_GetLFTrackMode;
        private DCreater.NET_DVR_GetLocalIP _NET_DVR_GetLocalIP;
        private DCreater.NET_DVR_GetNextRemoteConfig0 _NET_DVR_GetNextRemoteConfig0;
        private DCreater.NET_DVR_GetNextRemoteConfig1 _NET_DVR_GetNextRemoteConfig1;
        private DCreater.NET_DVR_GetNextRemoteConfig2 _NET_DVR_GetNextRemoteConfig2;
        private DCreater.NET_DVR_GetNextRemoteConfig3 _NET_DVR_GetNextRemoteConfig3;
        private DCreater.NET_DVR_GetNextRemoteConfig4 _NET_DVR_GetNextRemoteConfig4;
        private DCreater.NET_DVR_GetNextRemoteConfig5 _NET_DVR_GetNextRemoteConfig5;
        private DCreater.NET_DVR_GetNextRemoteConfig6 _NET_DVR_GetNextRemoteConfig6;
        private DCreater.NET_DVR_GetParamSetMode _NET_DVR_GetParamSetMode;
        private DCreater.NET_DVR_GetPicture _NET_DVR_GetPicture;
        private DCreater.NET_DVR_GetPicUploadProgress _NET_DVR_GetPicUploadProgress;
        private DCreater.NET_DVR_GetPicUploadState _NET_DVR_GetPicUploadState;
        private DCreater.NET_DVR_GetPlayBackOsdTime _NET_DVR_GetPlayBackOsdTime;
        private DCreater.NET_DVR_GetPlayBackPlayerIndex _NET_DVR_GetPlayBackPlayerIndex;
        private DCreater.NET_DVR_GetPlayBackPos _NET_DVR_GetPlayBackPos;
        private DCreater.NET_DVR_GetPTZCruise _NET_DVR_GetPTZCruise;
        private DCreater.NET_DVR_GetPTZCtrl _NET_DVR_GetPTZCtrl;
        private DCreater.NET_DVR_GetPTZCtrl_Other _NET_DVR_GetPTZCtrl_Other;
        private DCreater.NET_DVR_GetPTZProtocol _NET_DVR_GetPTZProtocol;
        private DCreater.NET_DVR_GetRealHeight _NET_DVR_GetRealHeight;
        private DCreater.NET_DVR_GetRealLength _NET_DVR_GetRealLength;
        private DCreater.NET_DVR_GetRealPlayerIndex _NET_DVR_GetRealPlayerIndex;
        private DCreater.NET_DVR_GetRemoteConfigState _NET_DVR_GetRemoteConfigState;
        private DCreater.NET_DVR_GetRtspConfig _NET_DVR_GetRtspConfig;
        private DCreater.NET_DVR_GetScaleCFG _NET_DVR_GetScaleCFG;
        private DCreater.NET_DVR_GetScaleCFG_V30 _NET_DVR_GetScaleCFG_V30;
        private DCreater.NET_DVR_GetSDKAbility _NET_DVR_GetSDKAbility;
        private DCreater.NET_DVR_GetSDKBuildVersion _NET_DVR_GetSDKBuildVersion;
        private DCreater.NET_DVR_GetSDKLocalCfg _NET_DVR_GetSDKLocalCfg;
        private DCreater.NET_DVR_GetSDKState _NET_DVR_GetSDKState;
        private DCreater.NET_DVR_GetSDKVersion _NET_DVR_GetSDKVersion;
        private DCreater.NET_DVR_GetSerialNum_Card _NET_DVR_GetSerialNum_Card;
        private DCreater.NET_DVR_GetSTDConfig _NET_DVR_GetSTDConfig;
        private DCreater.NET_DVR_GetUpgradeProgress _NET_DVR_GetUpgradeProgress;
        private DCreater.NET_DVR_GetUpgradeState _NET_DVR_GetUpgradeState;
        private DCreater.NET_DVR_GetUploadResult _NET_DVR_GetUploadResult;
        private DCreater.NET_DVR_GetUploadState _NET_DVR_GetUploadState;
        private DCreater.NET_DVR_GetUpnpNatState _NET_DVR_GetUpnpNatState;
        private DCreater.NET_DVR_GetVCADrawMode _NET_DVR_GetVCADrawMode;
        private DCreater.NET_DVR_GetVideoEffect _NET_DVR_GetVideoEffect;
        private DCreater.NET_DVR_Init _NET_DVR_Init;
        private DCreater.NET_DVR_InitDDrawDevice _NET_DVR_InitDDrawDevice;
        private DCreater.NET_DVR_InitDDraw_Card _NET_DVR_InitDDraw_Card;
        private DCreater.NET_DVR_InitDevice_Card _NET_DVR_InitDevice_Card;
        private DCreater.NET_DVR_InitG711Encoder _NET_DVR_InitG711Encoder;
        private DCreater.NET_DVR_InitG722Decoder _NET_DVR_InitG722Decoder;
        private DCreater.NET_DVR_InitG722Encoder _NET_DVR_InitG722Encoder;
        private DCreater.NET_DVR_InquestStartCDW_V30 _NET_DVR_InquestStartCDW_V30;
        private DCreater.NET_DVR_IsSupport _NET_DVR_IsSupport;
        private DCreater.NET_DVR_LockFileByName _NET_DVR_LockFileByName;
        private DCreater.NET_DVR_LockPanel _NET_DVR_LockPanel;
        private DCreater.NET_DVR_Login _NET_DVR_Login;
        private DCreater.NET_DVR_Login_V30 _NET_DVR_Login_V30;
        private DCreater.NET_DVR_Login_V40 _NET_DVR_Login_V40;
        private DCreater.NET_DVR_LogoSwitch _NET_DVR_LogoSwitch;
        private DCreater.NET_DVR_Logout _NET_DVR_Logout;
        private DCreater.NET_DVR_Logout_V30 _NET_DVR_Logout_V30;
        private DCreater.NET_DVR_MakeKeyFrame _NET_DVR_MakeKeyFrame;
        private DCreater.NET_DVR_MakeKeyFrameSub _NET_DVR_MakeKeyFrameSub;
        private DCreater.NET_DVR_ManualSnap _NET_DVR_ManualSnap;
        private DCreater.NET_DVR_MatrixDiaplayControl _NET_DVR_MatrixDiaplayControl;
        private DCreater.NET_DVR_MatrixGetDecChanEnable _NET_DVR_MatrixGetDecChanEnable;
        private DCreater.NET_DVR_MatrixGetDecChanInfo _NET_DVR_MatrixGetDecChanInfo;
        private DCreater.NET_DVR_MatrixGetDecChanInfo_V30 _NET_DVR_MatrixGetDecChanInfo_V30;
        private DCreater.NET_DVR_MatrixGetDecChanInfo_V41 _NET_DVR_MatrixGetDecChanInfo_V41;
        private DCreater.NET_DVR_MatrixGetDecChanStatus _NET_DVR_MatrixGetDecChanStatus;
        private DCreater.NET_DVR_MatrixGetDeviceStatus _NET_DVR_MatrixGetDeviceStatus;
        private DCreater.NET_DVR_MatrixGetDisplayCfg _NET_DVR_MatrixGetDisplayCfg;
        private DCreater.NET_DVR_MatrixGetDisplayCfg_V41 _NET_DVR_MatrixGetDisplayCfg_V41;
        private DCreater.NET_DVR_MatrixGetLoopDecChanEnable _NET_DVR_MatrixGetLoopDecChanEnable;
        private DCreater.NET_DVR_MatrixGetLoopDecChanInfo _NET_DVR_MatrixGetLoopDecChanInfo;
        private DCreater.NET_DVR_MatrixGetLoopDecChanInfo_V30 _NET_DVR_MatrixGetLoopDecChanInfo_V30;
        private DCreater.NET_DVR_MatrixGetLoopDecEnable _NET_DVR_MatrixGetLoopDecEnable;
        private DCreater.NET_DVR_MatrixGetRemotePlayStatus _NET_DVR_MatrixGetRemotePlayStatus;
        private DCreater.NET_DVR_MatrixGetSceneCfg _NET_DVR_MatrixGetSceneCfg;
        private DCreater.NET_DVR_MatrixGetTranInfo _NET_DVR_MatrixGetTranInfo;
        private DCreater.NET_DVR_MatrixGetTranInfo_V30 _NET_DVR_MatrixGetTranInfo_V30;
        private DCreater.NET_DVR_MatrixSendData _NET_DVR_MatrixSendData;
        private DCreater.NET_DVR_MatrixSetDecChanEnable _NET_DVR_MatrixSetDecChanEnable;
        private DCreater.NET_DVR_MatrixSetDisplayCfg _NET_DVR_MatrixSetDisplayCfg;
        private DCreater.NET_DVR_MatrixSetDisplayCfg_V41 _NET_DVR_MatrixSetDisplayCfg_V41;
        private DCreater.NET_DVR_MatrixSetLoopDecChanEnable _NET_DVR_MatrixSetLoopDecChanEnable;
        private DCreater.NET_DVR_MatrixSetLoopDecChanInfo _NET_DVR_MatrixSetLoopDecChanInfo;
        private DCreater.NET_DVR_MatrixSetLoopDecChanInfo_V30 _NET_DVR_MatrixSetLoopDecChanInfo_V30;
        private DCreater.NET_DVR_MatrixSetRemotePlay _NET_DVR_MatrixSetRemotePlay;
        private DCreater.NET_DVR_MatrixSetRemotePlayControl _NET_DVR_MatrixSetRemotePlayControl;
        private DCreater.NET_DVR_MatrixSetSceneCfg _NET_DVR_MatrixSetSceneCfg;
        private DCreater.NET_DVR_MatrixSetTranInfo _NET_DVR_MatrixSetTranInfo;
        private DCreater.NET_DVR_MatrixSetTranInfo_V30 _NET_DVR_MatrixSetTranInfo_V30;
        private DCreater.NET_DVR_MatrixStartDynamic _NET_DVR_MatrixStartDynamic;
        private DCreater.NET_DVR_MatrixStartDynamic_V30 _NET_DVR_MatrixStartDynamic_V30;
        private DCreater.NET_DVR_MatrixStartDynamic_V41 _NET_DVR_MatrixStartDynamic_V41;
        private DCreater.NET_DVR_MatrixStartPassiveDecode _NET_DVR_MatrixStartPassiveDecode;
        private DCreater.NET_DVR_MatrixStopDynamic _NET_DVR_MatrixStopDynamic;
        private DCreater.NET_DVR_MatrixStopPassiveDecode _NET_DVR_MatrixStopPassiveDecode;
        private DCreater.NET_DVR_OpenSound _NET_DVR_OpenSound;
        private DCreater.NET_DVR_OpenSoundShare _NET_DVR_OpenSoundShare;
        private DCreater.NET_DVR_OpenSound_Card _NET_DVR_OpenSound_Card;
        private DCreater.NET_DVR_PicUpload _NET_DVR_PicUpload;
        private DCreater.NET_DVR_PlayBackByName _NET_DVR_PlayBackByName;
        private DCreater.NET_DVR_PlayBackByTime _NET_DVR_PlayBackByTime;
        private DCreater.NET_DVR_PlayBackByTime_V40 _NET_DVR_PlayBackByTime_V40;
        private DCreater.NET_DVR_PlayBackCaptureFile _NET_DVR_PlayBackCaptureFile;
        private DCreater.NET_DVR_PlayBackControl _NET_DVR_PlayBackControl;
        private DCreater.NET_DVR_PlayBackControl_V40 _NET_DVR_PlayBackControl_V40;
        private DCreater.NET_DVR_PlayBackReverseByName _NET_DVR_PlayBackReverseByName;
        private DCreater.NET_DVR_PlayBackReverseByTime_V40 _NET_DVR_PlayBackReverseByTime_V40;
        private DCreater.NET_DVR_PlayBackSaveData _NET_DVR_PlayBackSaveData;
        private DCreater.NET_DVR_PTZControl _NET_DVR_PTZControl;
        private DCreater.NET_DVR_PTZControlWithSpeed _NET_DVR_PTZControlWithSpeed;
        private DCreater.NET_DVR_PTZControlWithSpeed_EX _NET_DVR_PTZControlWithSpeed_EX;
        private DCreater.NET_DVR_PTZControlWithSpeed_Other _NET_DVR_PTZControlWithSpeed_Other;
        private DCreater.NET_DVR_PTZControl_EX _NET_DVR_PTZControl_EX;
        private DCreater.NET_DVR_PTZControl_Other _NET_DVR_PTZControl_Other;
        private DCreater.NET_DVR_PTZCruise _NET_DVR_PTZCruise;
        private DCreater.NET_DVR_PTZCruise_EX _NET_DVR_PTZCruise_EX;
        private DCreater.NET_DVR_PTZCruise_Other _NET_DVR_PTZCruise_Other;
        private DCreater.NET_DVR_PTZMltTrack _NET_DVR_PTZMltTrack;
        private DCreater.NET_DVR_PTZMltTrack_EX _NET_DVR_PTZMltTrack_EX;
        private DCreater.NET_DVR_PTZMltTrack_Other _NET_DVR_PTZMltTrack_Other;
        private DCreater.NET_DVR_PTZPreset _NET_DVR_PTZPreset;
        private DCreater.NET_DVR_PTZPreset_EX _NET_DVR_PTZPreset_EX;
        private DCreater.NET_DVR_PTZPreset_Other _NET_DVR_PTZPreset_Other;
        private DCreater.NET_DVR_PTZSelZoomIn _NET_DVR_PTZSelZoomIn;
        private DCreater.NET_DVR_PTZSelZoomIn_EX _NET_DVR_PTZSelZoomIn_EX;
        private DCreater.NET_DVR_PTZTrack _NET_DVR_PTZTrack;
        private DCreater.NET_DVR_PTZTrack_EX _NET_DVR_PTZTrack_EX;
        private DCreater.NET_DVR_PTZTrack_Other _NET_DVR_PTZTrack_Other;
        private DCreater.NET_DVR_RealPlay _NET_DVR_RealPlay;
        private DCreater.NET_DVR_RealPlay_Card _NET_DVR_RealPlay_Card;
        private DCreater.NET_DVR_RealPlay_V30 _NET_DVR_RealPlay_V30;
        private DCreater.NET_DVR_RealPlay_V40 _NET_DVR_RealPlay_V40;
        private DCreater.NET_DVR_RebootDVR _NET_DVR_RebootDVR;
        private DCreater.NET_DVR_RefreshPlay _NET_DVR_RefreshPlay;
        private DCreater.NET_DVR_RefreshSurface_Card _NET_DVR_RefreshSurface_Card;
        private DCreater.NET_DVR_ReleaseDDrawDevice _NET_DVR_ReleaseDDrawDevice;
        private DCreater.NET_DVR_ReleaseDDraw_Card _NET_DVR_ReleaseDDraw_Card;
        private DCreater.NET_DVR_ReleaseDevice_Card _NET_DVR_ReleaseDevice_Card;
        private DCreater.NET_DVR_ReleaseG711Encoder _NET_DVR_ReleaseG711Encoder;
        private DCreater.NET_DVR_ReleaseG722Decoder _NET_DVR_ReleaseG722Decoder;
        private DCreater.NET_DVR_ReleaseG722Encoder _NET_DVR_ReleaseG722Encoder;
        private DCreater.NET_DVR_RemoteControl0 _NET_DVR_RemoteControl0;
        private DCreater.NET_DVR_RemoteControl1 _NET_DVR_RemoteControl1;
        private DCreater.NET_DVR_ResetPara_Card _NET_DVR_ResetPara_Card;
        private DCreater.NET_DVR_RestoreConfig _NET_DVR_RestoreConfig;
        private DCreater.NET_DVR_RestoreSurface_Card _NET_DVR_RestoreSurface_Card;
        private DCreater.NET_DVR_RigisterDrawFun _NET_DVR_RigisterDrawFun;
        private DCreater.NET_DVR_SaveConfig _NET_DVR_SaveConfig;
        private DCreater.NET_DVR_SaveRealData _NET_DVR_SaveRealData;
        private DCreater.NET_DVR_SaveRealData_V30 _NET_DVR_SaveRealData_V30;
        private DCreater.NET_DVR_SendRemoteConfig _NET_DVR_SendRemoteConfig;
        private DCreater.NET_DVR_SendTo232Port _NET_DVR_SendTo232Port;
        private DCreater.NET_DVR_SendToSerialPort _NET_DVR_SendToSerialPort;
        private DCreater.NET_DVR_SendWithRecvRemoteConfig0 _NET_DVR_SendWithRecvRemoteConfig0;
        private DCreater.NET_DVR_SendWithRecvRemoteConfig1 _NET_DVR_SendWithRecvRemoteConfig1;
        private DCreater.NET_DVR_SendWithRecvRemoteConfig2 _NET_DVR_SendWithRecvRemoteConfig2;
        private DCreater.NET_DVR_SerialSend _NET_DVR_SerialSend;
        private DCreater.NET_DVR_SerialStart _NET_DVR_SerialStart;
        private DCreater.NET_DVR_SerialStop _NET_DVR_SerialStop;
        private DCreater.NET_DVR_SetAlarmDeviceUser _NET_DVR_SetAlarmDeviceUser;
        private DCreater.NET_DVR_SetAlarmOut _NET_DVR_SetAlarmOut;
        private DCreater.NET_DVR_SetATMPortCFG _NET_DVR_SetATMPortCFG;
        private DCreater.NET_DVR_SetAudioMode _NET_DVR_SetAudioMode;
        private DCreater.NET_DVR_SetBehaviorParamKey _NET_DVR_SetBehaviorParamKey;
        private DCreater.NET_DVR_SetCCDCfg _NET_DVR_SetCCDCfg;
        private DCreater.NET_DVR_SetConfigFile _NET_DVR_SetConfigFile;
        private DCreater.NET_DVR_SetConfigFile_EX _NET_DVR_SetConfigFile_EX;
        private DCreater.NET_DVR_SetConnectTime _NET_DVR_SetConnectTime;
        private DCreater.NET_DVR_SetDDrawDevice _NET_DVR_SetDDrawDevice;
        private DCreater.NET_DVR_SetDecInfo _NET_DVR_SetDecInfo;
        private DCreater.NET_DVR_SetDecTransPort _NET_DVR_SetDecTransPort;
        private DCreater.NET_DVR_SetDeviceConfig _NET_DVR_SetDeviceConfig;
        private DCreater.NET_DVR_SetDeviceConfigEx _NET_DVR_SetDeviceConfigEx;
        private DCreater.NET_DVR_SetDVRConfig _NET_DVR_SetDVRConfig;
        private DCreater.NET_DVR_SetDVRMessage _NET_DVR_SetDVRMessage;
        private DCreater.NET_DVR_SetDVRMessageCallBack _NET_DVR_SetDVRMessageCallBack;
        private DCreater.NET_DVR_SetDVRMessageCallBack_V30 _NET_DVR_SetDVRMessageCallBack_V30;
        private DCreater.NET_DVR_SetDVRMessageCallBack_V31 _NET_DVR_SetDVRMessageCallBack_V31;
        private DCreater.NET_DVR_SetDVRMessageCallBack_V50 _NET_DVR_SetDVRMessageCallBack_V50;
        private DCreater.NET_DVR_SetDVRMessCallBack _NET_DVR_SetDVRMessCallBack;
        private DCreater.NET_DVR_SetDVRMessCallBack_EX _NET_DVR_SetDVRMessCallBack_EX;
        private DCreater.NET_DVR_SetDVRMessCallBack_NEW _NET_DVR_SetDVRMessCallBack_NEW;
        private DCreater.NET_DVR_SetExceptionCallBack_V30 _NET_DVR_SetExceptionCallBack_V30;
        private DCreater.NET_DVR_SetLFTrackMode _NET_DVR_SetLFTrackMode;
        private DCreater.NET_DVR_SetLogToFile _NET_DVR_SetLogToFile;
        private DCreater.NET_DVR_SetNetworkEnvironment _NET_DVR_SetNetworkEnvironment;
        private DCreater.NET_DVR_SetPlayDataCallBack _NET_DVR_SetPlayDataCallBack;
        private DCreater.NET_DVR_SetPlayerBufNumber _NET_DVR_SetPlayerBufNumber;
        private DCreater.NET_DVR_SetRealDataCallBack _NET_DVR_SetRealDataCallBack;
        private DCreater.NET_DVR_SetReconnect _NET_DVR_SetReconnect;
        private DCreater.NET_DVR_SetRtspConfig _NET_DVR_SetRtspConfig;
        private DCreater.NET_DVR_SetScaleCFG _NET_DVR_SetScaleCFG;
        private DCreater.NET_DVR_SetScaleCFG_V30 _NET_DVR_SetScaleCFG_V30;
        private DCreater.NET_DVR_SetSDKLocalCfg _NET_DVR_SetSDKLocalCfg;
        private DCreater.NET_DVR_SetShowMode _NET_DVR_SetShowMode;
        private DCreater.NET_DVR_SetStandardDataCallBack _NET_DVR_SetStandardDataCallBack;
        private DCreater.NET_DVR_SetSTDConfig _NET_DVR_SetSTDConfig;
        private DCreater.NET_DVR_SetupAlarmChan _NET_DVR_SetupAlarmChan;
        private DCreater.NET_DVR_SetupAlarmChan_V30 _NET_DVR_SetupAlarmChan_V30;
        private DCreater.NET_DVR_SetupAlarmChan_V41 _NET_DVR_SetupAlarmChan_V41;
        private DCreater.NET_DVR_SetValidIP _NET_DVR_SetValidIP;
        private DCreater.NET_DVR_SetVCADrawMode _NET_DVR_SetVCADrawMode;
        private DCreater.NET_DVR_SetVideoEffect _NET_DVR_SetVideoEffect;
        private DCreater.NET_DVR_SetVoiceComClientVolume _NET_DVR_SetVoiceComClientVolume;
        private DCreater.NET_DVR_SetVolume_Card _NET_DVR_SetVolume_Card;
        private DCreater.NET_DVR_ShutDownDVR _NET_DVR_ShutDownDVR;
        private DCreater.NET_DVR_StartDecode _NET_DVR_StartDecode;
        private DCreater.NET_DVR_StartDecSpecialCon _NET_DVR_StartDecSpecialCon;
        private DCreater.NET_DVR_StartDVRRecord _NET_DVR_StartDVRRecord;
        private DCreater.NET_DVR_StartListen _NET_DVR_StartListen;
        private DCreater.NET_DVR_StartListen_V30 _NET_DVR_StartListen_V30;
        private DCreater.NET_DVR_StartRemoteConfig _NET_DVR_StartRemoteConfig;
        private DCreater.NET_DVR_StartVoiceCom _NET_DVR_StartVoiceCom;
        private DCreater.NET_DVR_StartVoiceCom_MR _NET_DVR_StartVoiceCom_MR;
        private DCreater.NET_DVR_StartVoiceCom_MR_V30 _NET_DVR_StartVoiceCom_MR_V30;
        private DCreater.NET_DVR_StartVoiceCom_V30 _NET_DVR_StartVoiceCom_V30;
        private DCreater.NET_DVR_STDXMLConfig0 _NET_DVR_STDXMLConfig0;
        private DCreater.NET_DVR_STDXMLConfig1 _NET_DVR_STDXMLConfig1;
        private DCreater.NET_DVR_StopDecode _NET_DVR_StopDecode;
        private DCreater.NET_DVR_StopDecSpecialCon _NET_DVR_StopDecSpecialCon;
        private DCreater.NET_DVR_StopDVRRecord _NET_DVR_StopDVRRecord;
        private DCreater.NET_DVR_StopGetFile _NET_DVR_StopGetFile;
        private DCreater.NET_DVR_StopListen _NET_DVR_StopListen;
        private DCreater.NET_DVR_StopListen_V30 _NET_DVR_StopListen_V30;
        private DCreater.NET_DVR_StopPlayBack _NET_DVR_StopPlayBack;
        private DCreater.NET_DVR_StopPlayBackSave _NET_DVR_StopPlayBackSave;
        private DCreater.NET_DVR_StopRealPlay _NET_DVR_StopRealPlay;
        private DCreater.NET_DVR_StopRemoteConfig _NET_DVR_StopRemoteConfig;
        private DCreater.NET_DVR_StopSaveRealData _NET_DVR_StopSaveRealData;
        private DCreater.NET_DVR_StopVoiceCom _NET_DVR_StopVoiceCom;
        private DCreater.NET_DVR_ThrowBFrame _NET_DVR_ThrowBFrame;
        private DCreater.NET_DVR_TransPTZ _NET_DVR_TransPTZ;
        private DCreater.NET_DVR_TransPTZ_EX _NET_DVR_TransPTZ_EX;
        private DCreater.NET_DVR_TransPTZ_Other _NET_DVR_TransPTZ_Other;
        private DCreater.NET_DVR_UnlockFileByName _NET_DVR_UnlockFileByName;
        private DCreater.NET_DVR_UnLockPanel _NET_DVR_UnLockPanel;
        private DCreater.NET_DVR_Upgrade _NET_DVR_Upgrade;
        private DCreater.NET_DVR_Upgrade_V40 _NET_DVR_Upgrade_V40;
        private DCreater.NET_DVR_UploadClose _NET_DVR_UploadClose;
        private DCreater.NET_DVR_UploadFile_V40 _NET_DVR_UploadFile_V40;
        private DCreater.NET_DVR_UploadLogo _NET_DVR_UploadLogo;
        private DCreater.NET_DVR_UploadSend _NET_DVR_UploadSend;
        private DCreater.NET_DVR_VoiceComSendData _NET_DVR_VoiceComSendData;
        private DCreater.NET_DVR_Volume _NET_DVR_Volume;
        private DCreater.NET_SDK_RealPlay _NET_SDK_RealPlay;
        private DCreater.NET_VCA_RestartLib _NET_VCA_RestartLib;
        #endregion 委托定义
        public HikHCNetSdkLoader()
        {
            _NET_DVR_AddDVR = GetDelegate<DCreater.NET_DVR_AddDVR>(nameof(DCreater.NET_DVR_AddDVR));
            _NET_DVR_AddDVR_V30 = GetDelegate<DCreater.NET_DVR_AddDVR_V30>(nameof(DCreater.NET_DVR_AddDVR_V30));
            _NET_DVR_AudioPreview_Card = GetDelegate<DCreater.NET_DVR_AudioPreview_Card>(nameof(DCreater.NET_DVR_AudioPreview_Card));
            _NET_DVR_CaptureJPEGPicture = GetDelegate<DCreater.NET_DVR_CaptureJPEGPicture>(nameof(DCreater.NET_DVR_CaptureJPEGPicture));
            _NET_DVR_CaptureJPEGPicture_NEW = GetDelegate<DCreater.NET_DVR_CaptureJPEGPicture_NEW>(nameof(DCreater.NET_DVR_CaptureJPEGPicture_NEW));
            _NET_DVR_CapturePicture = GetDelegate<DCreater.NET_DVR_CapturePicture>(nameof(DCreater.NET_DVR_CapturePicture));
            _NET_DVR_CapturePictureBlock = GetDelegate<DCreater.NET_DVR_CapturePictureBlock>(nameof(DCreater.NET_DVR_CapturePictureBlock));
            _NET_DVR_CapturePicture_Card = GetDelegate<DCreater.NET_DVR_CapturePicture_Card>(nameof(DCreater.NET_DVR_CapturePicture_Card));
            _NET_DVR_Cleanup = GetDelegate<DCreater.NET_DVR_Cleanup>(nameof(DCreater.NET_DVR_Cleanup));
            _NET_DVR_ClearSurface_Card = GetDelegate<DCreater.NET_DVR_ClearSurface_Card>(nameof(DCreater.NET_DVR_ClearSurface_Card));
            _NET_DVR_ClickKey = GetDelegate<DCreater.NET_DVR_ClickKey>(nameof(DCreater.NET_DVR_ClickKey));
            _NET_DVR_ClientAudioStart = GetDelegate<DCreater.NET_DVR_ClientAudioStart>(nameof(DCreater.NET_DVR_ClientAudioStart));
            _NET_DVR_ClientAudioStart_V30 = GetDelegate<DCreater.NET_DVR_ClientAudioStart_V30>(nameof(DCreater.NET_DVR_ClientAudioStart_V30));
            _NET_DVR_ClientAudioStop = GetDelegate<DCreater.NET_DVR_ClientAudioStop>(nameof(DCreater.NET_DVR_ClientAudioStop));
            _NET_DVR_ClientGetframeformat = GetDelegate<DCreater.NET_DVR_ClientGetframeformat>(nameof(DCreater.NET_DVR_ClientGetframeformat));
            _NET_DVR_ClientGetVideoEffect = GetDelegate<DCreater.NET_DVR_ClientGetVideoEffect>(nameof(DCreater.NET_DVR_ClientGetVideoEffect));
            _NET_DVR_ClientSetframeformat = GetDelegate<DCreater.NET_DVR_ClientSetframeformat>(nameof(DCreater.NET_DVR_ClientSetframeformat));
            _NET_DVR_ClientSetVideoEffect = GetDelegate<DCreater.NET_DVR_ClientSetVideoEffect>(nameof(DCreater.NET_DVR_ClientSetVideoEffect));
            _NET_DVR_CloseAlarmChan = GetDelegate<DCreater.NET_DVR_CloseAlarmChan>(nameof(DCreater.NET_DVR_CloseAlarmChan));
            _NET_DVR_CloseAlarmChan_V30 = GetDelegate<DCreater.NET_DVR_CloseAlarmChan_V30>(nameof(DCreater.NET_DVR_CloseAlarmChan_V30));
            _NET_DVR_CloseFindPicture = GetDelegate<DCreater.NET_DVR_CloseFindPicture>(nameof(DCreater.NET_DVR_CloseFindPicture));
            _NET_DVR_CloseFormatHandle = GetDelegate<DCreater.NET_DVR_CloseFormatHandle>(nameof(DCreater.NET_DVR_CloseFormatHandle));
            _NET_DVR_CloseSound = GetDelegate<DCreater.NET_DVR_CloseSound>(nameof(DCreater.NET_DVR_CloseSound));
            _NET_DVR_CloseSoundShare = GetDelegate<DCreater.NET_DVR_CloseSoundShare>(nameof(DCreater.NET_DVR_CloseSoundShare));
            _NET_DVR_CloseSound_Card = GetDelegate<DCreater.NET_DVR_CloseSound_Card>(nameof(DCreater.NET_DVR_CloseSound_Card));
            _NET_DVR_CloseUpgradeHandle = GetDelegate<DCreater.NET_DVR_CloseUpgradeHandle>(nameof(DCreater.NET_DVR_CloseUpgradeHandle));
            _NET_DVR_CloseUploadHandle = GetDelegate<DCreater.NET_DVR_CloseUploadHandle>(nameof(DCreater.NET_DVR_CloseUploadHandle));
            _NET_DVR_ContinuousShoot = GetDelegate<DCreater.NET_DVR_ContinuousShoot>(nameof(DCreater.NET_DVR_ContinuousShoot));
            _NET_DVR_ControlGateway = GetDelegate<DCreater.NET_DVR_ControlGateway>(nameof(DCreater.NET_DVR_ControlGateway));
            _NET_DVR_DecCtrlDec = GetDelegate<DCreater.NET_DVR_DecCtrlDec>(nameof(DCreater.NET_DVR_DecCtrlDec));
            _NET_DVR_DecCtrlScreen = GetDelegate<DCreater.NET_DVR_DecCtrlScreen>(nameof(DCreater.NET_DVR_DecCtrlScreen));
            _NET_DVR_DecodeG711Frame = GetDelegate<DCreater.NET_DVR_DecodeG711Frame>(nameof(DCreater.NET_DVR_DecodeG711Frame));
            _NET_DVR_DecodeG722Frame = GetDelegate<DCreater.NET_DVR_DecodeG722Frame>(nameof(DCreater.NET_DVR_DecodeG722Frame));
            _NET_DVR_DecPlayBackCtrl = GetDelegate<DCreater.NET_DVR_DecPlayBackCtrl>(nameof(DCreater.NET_DVR_DecPlayBackCtrl));
            _NET_DVR_DelDVR = GetDelegate<DCreater.NET_DVR_DelDVR>(nameof(DCreater.NET_DVR_DelDVR));
            _NET_DVR_DelDVR_V30 = GetDelegate<DCreater.NET_DVR_DelDVR_V30>(nameof(DCreater.NET_DVR_DelDVR_V30));
            // _NET_DVR_EmailTest = GetDelegate<DCreater.NET_DVR_EmailTest>(nameof(DCreater.NET_DVR_EmailTest));
            _NET_DVR_EncodeG711Frame = GetDelegate<DCreater.NET_DVR_EncodeG711Frame>(nameof(DCreater.NET_DVR_EncodeG711Frame));
            _NET_DVR_EncodeG722Frame = GetDelegate<DCreater.NET_DVR_EncodeG722Frame>(nameof(DCreater.NET_DVR_EncodeG722Frame));
            _NET_DVR_FindClose = GetDelegate<DCreater.NET_DVR_FindClose>(nameof(DCreater.NET_DVR_FindClose));
            _NET_DVR_FindClose_V30 = GetDelegate<DCreater.NET_DVR_FindClose_V30>(nameof(DCreater.NET_DVR_FindClose_V30));
            _NET_DVR_FindDVRLog = GetDelegate<DCreater.NET_DVR_FindDVRLog>(nameof(DCreater.NET_DVR_FindDVRLog));
            _NET_DVR_FindDVRLog_Matrix = GetDelegate<DCreater.NET_DVR_FindDVRLog_Matrix>(nameof(DCreater.NET_DVR_FindDVRLog_Matrix));
            _NET_DVR_FindDVRLog_V30 = GetDelegate<DCreater.NET_DVR_FindDVRLog_V30>(nameof(DCreater.NET_DVR_FindDVRLog_V30));
            _NET_DVR_FindFile = GetDelegate<DCreater.NET_DVR_FindFile>(nameof(DCreater.NET_DVR_FindFile));
            _NET_DVR_FindFileByCard = GetDelegate<DCreater.NET_DVR_FindFileByCard>(nameof(DCreater.NET_DVR_FindFileByCard));
            _NET_DVR_FindFileByEvent = GetDelegate<DCreater.NET_DVR_FindFileByEvent>(nameof(DCreater.NET_DVR_FindFileByEvent));
            _NET_DVR_FindFileByEvent_V40 = GetDelegate<DCreater.NET_DVR_FindFileByEvent_V40>(nameof(DCreater.NET_DVR_FindFileByEvent_V40));
            // _NET_DVR_FindFile_Card = GetDelegate<DCreater.NET_DVR_FindFile_Card>(nameof(DCreater.NET_DVR_FindFile_Card));
            _NET_DVR_FindFile_V30 = GetDelegate<DCreater.NET_DVR_FindFile_V30>(nameof(DCreater.NET_DVR_FindFile_V30));
            _NET_DVR_FindFile_V40 = GetDelegate<DCreater.NET_DVR_FindFile_V40>(nameof(DCreater.NET_DVR_FindFile_V40));
            _NET_DVR_FindLogClose = GetDelegate<DCreater.NET_DVR_FindLogClose>(nameof(DCreater.NET_DVR_FindLogClose));
            _NET_DVR_FindLogClose_V30 = GetDelegate<DCreater.NET_DVR_FindLogClose_V30>(nameof(DCreater.NET_DVR_FindLogClose_V30));
            _NET_DVR_FindNextEvent = GetDelegate<DCreater.NET_DVR_FindNextEvent>(nameof(DCreater.NET_DVR_FindNextEvent));
            _NET_DVR_FindNextEvent_V40 = GetDelegate<DCreater.NET_DVR_FindNextEvent_V40>(nameof(DCreater.NET_DVR_FindNextEvent_V40));
            _NET_DVR_FindNextFile = GetDelegate<DCreater.NET_DVR_FindNextFile>(nameof(DCreater.NET_DVR_FindNextFile));
            _NET_DVR_FindNextFile_Card = GetDelegate<DCreater.NET_DVR_FindNextFile_Card>(nameof(DCreater.NET_DVR_FindNextFile_Card));
            _NET_DVR_FindNextFile_V30 = GetDelegate<DCreater.NET_DVR_FindNextFile_V30>(nameof(DCreater.NET_DVR_FindNextFile_V30));
            _NET_DVR_FindNextFile_V40 = GetDelegate<DCreater.NET_DVR_FindNextFile_V40>(nameof(DCreater.NET_DVR_FindNextFile_V40));
            _NET_DVR_FindNextLog = GetDelegate<DCreater.NET_DVR_FindNextLog>(nameof(DCreater.NET_DVR_FindNextLog));
            _NET_DVR_FindNextLog_MATRIX = GetDelegate<DCreater.NET_DVR_FindNextLog_MATRIX>(nameof(DCreater.NET_DVR_FindNextLog_MATRIX));
            _NET_DVR_FindNextLog_V30 = GetDelegate<DCreater.NET_DVR_FindNextLog_V30>(nameof(DCreater.NET_DVR_FindNextLog_V30));
            _NET_DVR_FindNextPicture_V50 = GetDelegate<DCreater.NET_DVR_FindNextPicture_V50>(nameof(DCreater.NET_DVR_FindNextPicture_V50));
            _NET_DVR_FindPicture = GetDelegate<DCreater.NET_DVR_FindPicture>(nameof(DCreater.NET_DVR_FindPicture));
            _NET_DVR_FormatDisk = GetDelegate<DCreater.NET_DVR_FormatDisk>(nameof(DCreater.NET_DVR_FormatDisk));
            _NET_DVR_GetAlarmDeviceUser = GetDelegate<DCreater.NET_DVR_GetAlarmDeviceUser>(nameof(DCreater.NET_DVR_GetAlarmDeviceUser));
            _NET_DVR_GetAlarmOut = GetDelegate<DCreater.NET_DVR_GetAlarmOut>(nameof(DCreater.NET_DVR_GetAlarmOut));
            _NET_DVR_GetAlarmOut_V30 = GetDelegate<DCreater.NET_DVR_GetAlarmOut_V30>(nameof(DCreater.NET_DVR_GetAlarmOut_V30));
            _NET_DVR_GetATMPortCFG = GetDelegate<DCreater.NET_DVR_GetATMPortCFG>(nameof(DCreater.NET_DVR_GetATMPortCFG));
            // _NET_DVR_GetAtmProtocol = GetDelegate<DCreater.NET_DVR_GetAtmProtocol>(nameof(DCreater.NET_DVR_GetAtmProtocol));
            _NET_DVR_GetBehaviorParamKey = GetDelegate<DCreater.NET_DVR_GetBehaviorParamKey>(nameof(DCreater.NET_DVR_GetBehaviorParamKey));
            _NET_DVR_GetCardLastError_Card = GetDelegate<DCreater.NET_DVR_GetCardLastError_Card>(nameof(DCreater.NET_DVR_GetCardLastError_Card));
            // _NET_DVR_GetCCDCfg = GetDelegate<DCreater.NET_DVR_GetCCDCfg>(nameof(DCreater.NET_DVR_GetCCDCfg));
            _NET_DVR_GetChanHandle_Card = GetDelegate<DCreater.NET_DVR_GetChanHandle_Card>(nameof(DCreater.NET_DVR_GetChanHandle_Card));
            _NET_DVR_GetConfigFile = GetDelegate<DCreater.NET_DVR_GetConfigFile>(nameof(DCreater.NET_DVR_GetConfigFile));
            _NET_DVR_GetConfigFile_EX = GetDelegate<DCreater.NET_DVR_GetConfigFile_EX>(nameof(DCreater.NET_DVR_GetConfigFile_EX));
            _NET_DVR_GetConfigFile_V30 = GetDelegate<DCreater.NET_DVR_GetConfigFile_V30>(nameof(DCreater.NET_DVR_GetConfigFile_V30));
            _NET_DVR_GetDDrawDeviceTotalNums = GetDelegate<DCreater.NET_DVR_GetDDrawDeviceTotalNums>(nameof(DCreater.NET_DVR_GetDDrawDeviceTotalNums));
            _NET_DVR_GetDecCurLinkStatus = GetDelegate<DCreater.NET_DVR_GetDecCurLinkStatus>(nameof(DCreater.NET_DVR_GetDecCurLinkStatus));
            _NET_DVR_GetDecInfo = GetDelegate<DCreater.NET_DVR_GetDecInfo>(nameof(DCreater.NET_DVR_GetDecInfo));
            _NET_DVR_GetDecoderState = GetDelegate<DCreater.NET_DVR_GetDecoderState>(nameof(DCreater.NET_DVR_GetDecoderState));
            _NET_DVR_GetDecTransPort = GetDelegate<DCreater.NET_DVR_GetDecTransPort>(nameof(DCreater.NET_DVR_GetDecTransPort));
            _NET_DVR_GetDeviceAbility = GetDelegate<DCreater.NET_DVR_GetDeviceAbility>(nameof(DCreater.NET_DVR_GetDeviceAbility));
            _NET_DVR_GetDeviceConfig = GetDelegate<DCreater.NET_DVR_GetDeviceConfig>(nameof(DCreater.NET_DVR_GetDeviceConfig));
            _NET_DVR_GetDownloadPos = GetDelegate<DCreater.NET_DVR_GetDownloadPos>(nameof(DCreater.NET_DVR_GetDownloadPos));
            _NET_DVR_GetDVRConfig = GetDelegate<DCreater.NET_DVR_GetDVRConfig>(nameof(DCreater.NET_DVR_GetDVRConfig));
            _NET_DVR_GetDVRIPByResolveSvr = GetDelegate<DCreater.NET_DVR_GetDVRIPByResolveSvr>(nameof(DCreater.NET_DVR_GetDVRIPByResolveSvr));
            _NET_DVR_GetDVRIPByResolveSvr_EX = GetDelegate<DCreater.NET_DVR_GetDVRIPByResolveSvr_EX>(nameof(DCreater.NET_DVR_GetDVRIPByResolveSvr_EX));
            _NET_DVR_GetDVRWorkState = GetDelegate<DCreater.NET_DVR_GetDVRWorkState>(nameof(DCreater.NET_DVR_GetDVRWorkState));
            _NET_DVR_GetDVRWorkState_V30 = GetDelegate<DCreater.NET_DVR_GetDVRWorkState_V30>(nameof(DCreater.NET_DVR_GetDVRWorkState_V30));
            _NET_DVR_GetErrorMsg = GetDelegate<DCreater.NET_DVR_GetErrorMsg>(nameof(DCreater.NET_DVR_GetErrorMsg));
            _NET_DVR_GetFileByName = GetDelegate<DCreater.NET_DVR_GetFileByName>(nameof(DCreater.NET_DVR_GetFileByName));
            _NET_DVR_GetFileByTime = GetDelegate<DCreater.NET_DVR_GetFileByTime>(nameof(DCreater.NET_DVR_GetFileByTime));
            _NET_DVR_GetFileByTime_V40 = GetDelegate<DCreater.NET_DVR_GetFileByTime_V40>(nameof(DCreater.NET_DVR_GetFileByTime_V40));
            _NET_DVR_GetFormatProgress = GetDelegate<DCreater.NET_DVR_GetFormatProgress>(nameof(DCreater.NET_DVR_GetFormatProgress));
            _NET_DVR_GetInputSignalList_V40 = GetDelegate<DCreater.NET_DVR_GetInputSignalList_V40>(nameof(DCreater.NET_DVR_GetInputSignalList_V40));
            _NET_DVR_GetIPCProtoList = GetDelegate<DCreater.NET_DVR_GetIPCProtoList>(nameof(DCreater.NET_DVR_GetIPCProtoList));
            _NET_DVR_GetIPCProtoList_V41 = GetDelegate<DCreater.NET_DVR_GetIPCProtoList_V41>(nameof(DCreater.NET_DVR_GetIPCProtoList_V41));
            _NET_DVR_GetLastError = GetDelegate<DCreater.NET_DVR_GetLastError>(nameof(DCreater.NET_DVR_GetLastError));
            // _NET_DVR_GetLFTrackMode = GetDelegate<DCreater.NET_DVR_GetLFTrackMode>(nameof(DCreater.NET_DVR_GetLFTrackMode));
            _NET_DVR_GetLocalIP = GetDelegate<DCreater.NET_DVR_GetLocalIP>(nameof(DCreater.NET_DVR_GetLocalIP));
            _NET_DVR_GetNextRemoteConfig0 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig0>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig1 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig1>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig2 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig2>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig3 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig3>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig4 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig4>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig5 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig5>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            _NET_DVR_GetNextRemoteConfig6 = GetDelegate<DCreater.NET_DVR_GetNextRemoteConfig6>(nameof(IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig));
            // _NET_DVR_GetParamSetMode = GetDelegate<DCreater.NET_DVR_GetParamSetMode>(nameof(DCreater.NET_DVR_GetParamSetMode));
            _NET_DVR_GetPicture = GetDelegate<DCreater.NET_DVR_GetPicture>(nameof(DCreater.NET_DVR_GetPicture));
            _NET_DVR_GetPicUploadProgress = GetDelegate<DCreater.NET_DVR_GetPicUploadProgress>(nameof(DCreater.NET_DVR_GetPicUploadProgress));
            _NET_DVR_GetPicUploadState = GetDelegate<DCreater.NET_DVR_GetPicUploadState>(nameof(DCreater.NET_DVR_GetPicUploadState));
            _NET_DVR_GetPlayBackOsdTime = GetDelegate<DCreater.NET_DVR_GetPlayBackOsdTime>(nameof(DCreater.NET_DVR_GetPlayBackOsdTime));
            _NET_DVR_GetPlayBackPlayerIndex = GetDelegate<DCreater.NET_DVR_GetPlayBackPlayerIndex>(nameof(DCreater.NET_DVR_GetPlayBackPlayerIndex));
            _NET_DVR_GetPlayBackPos = GetDelegate<DCreater.NET_DVR_GetPlayBackPos>(nameof(DCreater.NET_DVR_GetPlayBackPos));
            _NET_DVR_GetPTZCruise = GetDelegate<DCreater.NET_DVR_GetPTZCruise>(nameof(DCreater.NET_DVR_GetPTZCruise));
            _NET_DVR_GetPTZCtrl = GetDelegate<DCreater.NET_DVR_GetPTZCtrl>(nameof(DCreater.NET_DVR_GetPTZCtrl));
            _NET_DVR_GetPTZCtrl_Other = GetDelegate<DCreater.NET_DVR_GetPTZCtrl_Other>(nameof(DCreater.NET_DVR_GetPTZCtrl_Other));
            _NET_DVR_GetPTZProtocol = GetDelegate<DCreater.NET_DVR_GetPTZProtocol>(nameof(DCreater.NET_DVR_GetPTZProtocol));
            // _NET_DVR_GetRealHeight = GetDelegate<DCreater.NET_DVR_GetRealHeight>(nameof(DCreater.NET_DVR_GetRealHeight));
            // _NET_DVR_GetRealLength = GetDelegate<DCreater.NET_DVR_GetRealLength>(nameof(DCreater.NET_DVR_GetRealLength));
            _NET_DVR_GetRealPlayerIndex = GetDelegate<DCreater.NET_DVR_GetRealPlayerIndex>(nameof(DCreater.NET_DVR_GetRealPlayerIndex));
            _NET_DVR_GetRemoteConfigState = GetDelegate<DCreater.NET_DVR_GetRemoteConfigState>(nameof(DCreater.NET_DVR_GetRemoteConfigState));
            _NET_DVR_GetRtspConfig = GetDelegate<DCreater.NET_DVR_GetRtspConfig>(nameof(DCreater.NET_DVR_GetRtspConfig));
            _NET_DVR_GetScaleCFG = GetDelegate<DCreater.NET_DVR_GetScaleCFG>(nameof(DCreater.NET_DVR_GetScaleCFG));
            _NET_DVR_GetScaleCFG_V30 = GetDelegate<DCreater.NET_DVR_GetScaleCFG_V30>(nameof(DCreater.NET_DVR_GetScaleCFG_V30));
            _NET_DVR_GetSDKAbility = GetDelegate<DCreater.NET_DVR_GetSDKAbility>(nameof(DCreater.NET_DVR_GetSDKAbility));
            _NET_DVR_GetSDKBuildVersion = GetDelegate<DCreater.NET_DVR_GetSDKBuildVersion>(nameof(DCreater.NET_DVR_GetSDKBuildVersion));
            _NET_DVR_GetSDKLocalCfg = GetDelegate<DCreater.NET_DVR_GetSDKLocalCfg>(nameof(DCreater.NET_DVR_GetSDKLocalCfg));
            _NET_DVR_GetSDKState = GetDelegate<DCreater.NET_DVR_GetSDKState>(nameof(DCreater.NET_DVR_GetSDKState));
            _NET_DVR_GetSDKVersion = GetDelegate<DCreater.NET_DVR_GetSDKVersion>(nameof(DCreater.NET_DVR_GetSDKVersion));
            _NET_DVR_GetSerialNum_Card = GetDelegate<DCreater.NET_DVR_GetSerialNum_Card>(nameof(DCreater.NET_DVR_GetSerialNum_Card));
            _NET_DVR_GetSTDConfig = GetDelegate<DCreater.NET_DVR_GetSTDConfig>(nameof(DCreater.NET_DVR_GetSTDConfig));
            _NET_DVR_GetUpgradeProgress = GetDelegate<DCreater.NET_DVR_GetUpgradeProgress>(nameof(DCreater.NET_DVR_GetUpgradeProgress));
            _NET_DVR_GetUpgradeState = GetDelegate<DCreater.NET_DVR_GetUpgradeState>(nameof(DCreater.NET_DVR_GetUpgradeState));
            _NET_DVR_GetUploadResult = GetDelegate<DCreater.NET_DVR_GetUploadResult>(nameof(DCreater.NET_DVR_GetUploadResult));
            _NET_DVR_GetUploadState = GetDelegate<DCreater.NET_DVR_GetUploadState>(nameof(DCreater.NET_DVR_GetUploadState));
            _NET_DVR_GetUpnpNatState = GetDelegate<DCreater.NET_DVR_GetUpnpNatState>(nameof(DCreater.NET_DVR_GetUpnpNatState));
            _NET_DVR_GetVCADrawMode = GetDelegate<DCreater.NET_DVR_GetVCADrawMode>(nameof(DCreater.NET_DVR_GetVCADrawMode));
            _NET_DVR_GetVideoEffect = GetDelegate<DCreater.NET_DVR_GetVideoEffect>(nameof(DCreater.NET_DVR_GetVideoEffect));
            _NET_DVR_Init = GetDelegate<DCreater.NET_DVR_Init>(nameof(DCreater.NET_DVR_Init));
            _NET_DVR_InitDDrawDevice = GetDelegate<DCreater.NET_DVR_InitDDrawDevice>(nameof(DCreater.NET_DVR_InitDDrawDevice));
            _NET_DVR_InitDDraw_Card = GetDelegate<DCreater.NET_DVR_InitDDraw_Card>(nameof(DCreater.NET_DVR_InitDDraw_Card));
            _NET_DVR_InitDevice_Card = GetDelegate<DCreater.NET_DVR_InitDevice_Card>(nameof(DCreater.NET_DVR_InitDevice_Card));
            if (Environment.Is64BitProcess)
            {
                _NET_DVR_InitG711Encoder = GetDelegate<DCreater.NET_DVR_InitG711Encoder>(nameof(DCreater.NET_DVR_InitG711Encoder));
            }
            _NET_DVR_InitG722Decoder = GetDelegate<DCreater.NET_DVR_InitG722Decoder>(nameof(DCreater.NET_DVR_InitG722Decoder));
            _NET_DVR_InitG722Encoder = GetDelegate<DCreater.NET_DVR_InitG722Encoder>(nameof(DCreater.NET_DVR_InitG722Encoder));
            _NET_DVR_InquestStartCDW_V30 = GetDelegate<DCreater.NET_DVR_InquestStartCDW_V30>(nameof(DCreater.NET_DVR_InquestStartCDW_V30));
            _NET_DVR_IsSupport = GetDelegate<DCreater.NET_DVR_IsSupport>(nameof(DCreater.NET_DVR_IsSupport));
            _NET_DVR_LockFileByName = GetDelegate<DCreater.NET_DVR_LockFileByName>(nameof(DCreater.NET_DVR_LockFileByName));
            _NET_DVR_LockPanel = GetDelegate<DCreater.NET_DVR_LockPanel>(nameof(DCreater.NET_DVR_LockPanel));
            _NET_DVR_Login = GetDelegate<DCreater.NET_DVR_Login>(nameof(DCreater.NET_DVR_Login));
            _NET_DVR_Login_V30 = GetDelegate<DCreater.NET_DVR_Login_V30>(nameof(DCreater.NET_DVR_Login_V30));
            _NET_DVR_Login_V40 = GetDelegate<DCreater.NET_DVR_Login_V40>(nameof(DCreater.NET_DVR_Login_V40));
            _NET_DVR_LogoSwitch = GetDelegate<DCreater.NET_DVR_LogoSwitch>(nameof(DCreater.NET_DVR_LogoSwitch));
            _NET_DVR_Logout = GetDelegate<DCreater.NET_DVR_Logout>(nameof(DCreater.NET_DVR_Logout));
            _NET_DVR_Logout_V30 = GetDelegate<DCreater.NET_DVR_Logout_V30>(nameof(DCreater.NET_DVR_Logout_V30));
            _NET_DVR_MakeKeyFrame = GetDelegate<DCreater.NET_DVR_MakeKeyFrame>(nameof(DCreater.NET_DVR_MakeKeyFrame));
            _NET_DVR_MakeKeyFrameSub = GetDelegate<DCreater.NET_DVR_MakeKeyFrameSub>(nameof(DCreater.NET_DVR_MakeKeyFrameSub));
            _NET_DVR_ManualSnap = GetDelegate<DCreater.NET_DVR_ManualSnap>(nameof(DCreater.NET_DVR_ManualSnap));
            _NET_DVR_MatrixDiaplayControl = GetDelegate<DCreater.NET_DVR_MatrixDiaplayControl>(nameof(DCreater.NET_DVR_MatrixDiaplayControl));
            _NET_DVR_MatrixGetDecChanEnable = GetDelegate<DCreater.NET_DVR_MatrixGetDecChanEnable>(nameof(DCreater.NET_DVR_MatrixGetDecChanEnable));
            _NET_DVR_MatrixGetDecChanInfo = GetDelegate<DCreater.NET_DVR_MatrixGetDecChanInfo>(nameof(DCreater.NET_DVR_MatrixGetDecChanInfo));
            _NET_DVR_MatrixGetDecChanInfo_V30 = GetDelegate<DCreater.NET_DVR_MatrixGetDecChanInfo_V30>(nameof(DCreater.NET_DVR_MatrixGetDecChanInfo_V30));
            _NET_DVR_MatrixGetDecChanInfo_V41 = GetDelegate<DCreater.NET_DVR_MatrixGetDecChanInfo_V41>(nameof(DCreater.NET_DVR_MatrixGetDecChanInfo_V41));
            _NET_DVR_MatrixGetDecChanStatus = GetDelegate<DCreater.NET_DVR_MatrixGetDecChanStatus>(nameof(DCreater.NET_DVR_MatrixGetDecChanStatus));
            _NET_DVR_MatrixGetDeviceStatus = GetDelegate<DCreater.NET_DVR_MatrixGetDeviceStatus>(nameof(DCreater.NET_DVR_MatrixGetDeviceStatus));
            _NET_DVR_MatrixGetDisplayCfg = GetDelegate<DCreater.NET_DVR_MatrixGetDisplayCfg>(nameof(DCreater.NET_DVR_MatrixGetDisplayCfg));
            _NET_DVR_MatrixGetDisplayCfg_V41 = GetDelegate<DCreater.NET_DVR_MatrixGetDisplayCfg_V41>(nameof(DCreater.NET_DVR_MatrixGetDisplayCfg_V41));
            _NET_DVR_MatrixGetLoopDecChanEnable = GetDelegate<DCreater.NET_DVR_MatrixGetLoopDecChanEnable>(nameof(DCreater.NET_DVR_MatrixGetLoopDecChanEnable));
            _NET_DVR_MatrixGetLoopDecChanInfo = GetDelegate<DCreater.NET_DVR_MatrixGetLoopDecChanInfo>(nameof(DCreater.NET_DVR_MatrixGetLoopDecChanInfo));
            _NET_DVR_MatrixGetLoopDecChanInfo_V30 = GetDelegate<DCreater.NET_DVR_MatrixGetLoopDecChanInfo_V30>(nameof(DCreater.NET_DVR_MatrixGetLoopDecChanInfo_V30));
            _NET_DVR_MatrixGetLoopDecEnable = GetDelegate<DCreater.NET_DVR_MatrixGetLoopDecEnable>(nameof(DCreater.NET_DVR_MatrixGetLoopDecEnable));
            _NET_DVR_MatrixGetRemotePlayStatus = GetDelegate<DCreater.NET_DVR_MatrixGetRemotePlayStatus>(nameof(DCreater.NET_DVR_MatrixGetRemotePlayStatus));
            _NET_DVR_MatrixGetSceneCfg = GetDelegate<DCreater.NET_DVR_MatrixGetSceneCfg>(nameof(DCreater.NET_DVR_MatrixGetSceneCfg));
            _NET_DVR_MatrixGetTranInfo = GetDelegate<DCreater.NET_DVR_MatrixGetTranInfo>(nameof(DCreater.NET_DVR_MatrixGetTranInfo));
            _NET_DVR_MatrixGetTranInfo_V30 = GetDelegate<DCreater.NET_DVR_MatrixGetTranInfo_V30>(nameof(DCreater.NET_DVR_MatrixGetTranInfo_V30));
            _NET_DVR_MatrixSendData = GetDelegate<DCreater.NET_DVR_MatrixSendData>(nameof(DCreater.NET_DVR_MatrixSendData));
            _NET_DVR_MatrixSetDecChanEnable = GetDelegate<DCreater.NET_DVR_MatrixSetDecChanEnable>(nameof(DCreater.NET_DVR_MatrixSetDecChanEnable));
            _NET_DVR_MatrixSetDisplayCfg = GetDelegate<DCreater.NET_DVR_MatrixSetDisplayCfg>(nameof(DCreater.NET_DVR_MatrixSetDisplayCfg));
            _NET_DVR_MatrixSetDisplayCfg_V41 = GetDelegate<DCreater.NET_DVR_MatrixSetDisplayCfg_V41>(nameof(DCreater.NET_DVR_MatrixSetDisplayCfg_V41));
            _NET_DVR_MatrixSetLoopDecChanEnable = GetDelegate<DCreater.NET_DVR_MatrixSetLoopDecChanEnable>(nameof(DCreater.NET_DVR_MatrixSetLoopDecChanEnable));
            _NET_DVR_MatrixSetLoopDecChanInfo = GetDelegate<DCreater.NET_DVR_MatrixSetLoopDecChanInfo>(nameof(DCreater.NET_DVR_MatrixSetLoopDecChanInfo));
            _NET_DVR_MatrixSetLoopDecChanInfo_V30 = GetDelegate<DCreater.NET_DVR_MatrixSetLoopDecChanInfo_V30>(nameof(DCreater.NET_DVR_MatrixSetLoopDecChanInfo_V30));
            _NET_DVR_MatrixSetRemotePlay = GetDelegate<DCreater.NET_DVR_MatrixSetRemotePlay>(nameof(DCreater.NET_DVR_MatrixSetRemotePlay));
            _NET_DVR_MatrixSetRemotePlayControl = GetDelegate<DCreater.NET_DVR_MatrixSetRemotePlayControl>(nameof(DCreater.NET_DVR_MatrixSetRemotePlayControl));
            _NET_DVR_MatrixSetSceneCfg = GetDelegate<DCreater.NET_DVR_MatrixSetSceneCfg>(nameof(DCreater.NET_DVR_MatrixSetSceneCfg));
            _NET_DVR_MatrixSetTranInfo = GetDelegate<DCreater.NET_DVR_MatrixSetTranInfo>(nameof(DCreater.NET_DVR_MatrixSetTranInfo));
            _NET_DVR_MatrixSetTranInfo_V30 = GetDelegate<DCreater.NET_DVR_MatrixSetTranInfo_V30>(nameof(DCreater.NET_DVR_MatrixSetTranInfo_V30));
            _NET_DVR_MatrixStartDynamic = GetDelegate<DCreater.NET_DVR_MatrixStartDynamic>(nameof(DCreater.NET_DVR_MatrixStartDynamic));
            _NET_DVR_MatrixStartDynamic_V30 = GetDelegate<DCreater.NET_DVR_MatrixStartDynamic_V30>(nameof(DCreater.NET_DVR_MatrixStartDynamic_V30));
            _NET_DVR_MatrixStartDynamic_V41 = GetDelegate<DCreater.NET_DVR_MatrixStartDynamic_V41>(nameof(DCreater.NET_DVR_MatrixStartDynamic_V41));
            _NET_DVR_MatrixStartPassiveDecode = GetDelegate<DCreater.NET_DVR_MatrixStartPassiveDecode>(nameof(DCreater.NET_DVR_MatrixStartPassiveDecode));
            _NET_DVR_MatrixStopDynamic = GetDelegate<DCreater.NET_DVR_MatrixStopDynamic>(nameof(DCreater.NET_DVR_MatrixStopDynamic));
            _NET_DVR_MatrixStopPassiveDecode = GetDelegate<DCreater.NET_DVR_MatrixStopPassiveDecode>(nameof(DCreater.NET_DVR_MatrixStopPassiveDecode));
            _NET_DVR_OpenSound = GetDelegate<DCreater.NET_DVR_OpenSound>(nameof(DCreater.NET_DVR_OpenSound));
            _NET_DVR_OpenSoundShare = GetDelegate<DCreater.NET_DVR_OpenSoundShare>(nameof(DCreater.NET_DVR_OpenSoundShare));
            _NET_DVR_OpenSound_Card = GetDelegate<DCreater.NET_DVR_OpenSound_Card>(nameof(DCreater.NET_DVR_OpenSound_Card));
            _NET_DVR_PicUpload = GetDelegate<DCreater.NET_DVR_PicUpload>(nameof(DCreater.NET_DVR_PicUpload));
            _NET_DVR_PlayBackByName = GetDelegate<DCreater.NET_DVR_PlayBackByName>(nameof(DCreater.NET_DVR_PlayBackByName));
            _NET_DVR_PlayBackByTime = GetDelegate<DCreater.NET_DVR_PlayBackByTime>(nameof(DCreater.NET_DVR_PlayBackByTime));
            _NET_DVR_PlayBackByTime_V40 = GetDelegate<DCreater.NET_DVR_PlayBackByTime_V40>(nameof(DCreater.NET_DVR_PlayBackByTime_V40));
            _NET_DVR_PlayBackCaptureFile = GetDelegate<DCreater.NET_DVR_PlayBackCaptureFile>(nameof(DCreater.NET_DVR_PlayBackCaptureFile));
            _NET_DVR_PlayBackControl = GetDelegate<DCreater.NET_DVR_PlayBackControl>(nameof(DCreater.NET_DVR_PlayBackControl));
            _NET_DVR_PlayBackControl_V40 = GetDelegate<DCreater.NET_DVR_PlayBackControl_V40>(nameof(DCreater.NET_DVR_PlayBackControl_V40));
            _NET_DVR_PlayBackReverseByName = GetDelegate<DCreater.NET_DVR_PlayBackReverseByName>(nameof(DCreater.NET_DVR_PlayBackReverseByName));
            _NET_DVR_PlayBackReverseByTime_V40 = GetDelegate<DCreater.NET_DVR_PlayBackReverseByTime_V40>(nameof(DCreater.NET_DVR_PlayBackReverseByTime_V40));
            _NET_DVR_PlayBackSaveData = GetDelegate<DCreater.NET_DVR_PlayBackSaveData>(nameof(DCreater.NET_DVR_PlayBackSaveData));
            _NET_DVR_PTZControl = GetDelegate<DCreater.NET_DVR_PTZControl>(nameof(DCreater.NET_DVR_PTZControl));
            _NET_DVR_PTZControlWithSpeed = GetDelegate<DCreater.NET_DVR_PTZControlWithSpeed>(nameof(DCreater.NET_DVR_PTZControlWithSpeed));
            _NET_DVR_PTZControlWithSpeed_EX = GetDelegate<DCreater.NET_DVR_PTZControlWithSpeed_EX>(nameof(DCreater.NET_DVR_PTZControlWithSpeed_EX));
            _NET_DVR_PTZControlWithSpeed_Other = GetDelegate<DCreater.NET_DVR_PTZControlWithSpeed_Other>(nameof(DCreater.NET_DVR_PTZControlWithSpeed_Other));
            _NET_DVR_PTZControl_EX = GetDelegate<DCreater.NET_DVR_PTZControl_EX>(nameof(DCreater.NET_DVR_PTZControl_EX));
            _NET_DVR_PTZControl_Other = GetDelegate<DCreater.NET_DVR_PTZControl_Other>(nameof(DCreater.NET_DVR_PTZControl_Other));
            _NET_DVR_PTZCruise = GetDelegate<DCreater.NET_DVR_PTZCruise>(nameof(DCreater.NET_DVR_PTZCruise));
            _NET_DVR_PTZCruise_EX = GetDelegate<DCreater.NET_DVR_PTZCruise_EX>(nameof(DCreater.NET_DVR_PTZCruise_EX));
            _NET_DVR_PTZCruise_Other = GetDelegate<DCreater.NET_DVR_PTZCruise_Other>(nameof(DCreater.NET_DVR_PTZCruise_Other));
            // _NET_DVR_PTZMltTrack = GetDelegate<DCreater.NET_DVR_PTZMltTrack>(nameof(DCreater.NET_DVR_PTZMltTrack));
            // _NET_DVR_PTZMltTrack_EX = GetDelegate<DCreater.NET_DVR_PTZMltTrack_EX>(nameof(DCreater.NET_DVR_PTZMltTrack_EX));
            // _NET_DVR_PTZMltTrack_Other = GetDelegate<DCreater.NET_DVR_PTZMltTrack_Other>(nameof(DCreater.NET_DVR_PTZMltTrack_Other));
            _NET_DVR_PTZPreset = GetDelegate<DCreater.NET_DVR_PTZPreset>(nameof(DCreater.NET_DVR_PTZPreset));
            _NET_DVR_PTZPreset_EX = GetDelegate<DCreater.NET_DVR_PTZPreset_EX>(nameof(DCreater.NET_DVR_PTZPreset_EX));
            _NET_DVR_PTZPreset_Other = GetDelegate<DCreater.NET_DVR_PTZPreset_Other>(nameof(DCreater.NET_DVR_PTZPreset_Other));
            _NET_DVR_PTZSelZoomIn = GetDelegate<DCreater.NET_DVR_PTZSelZoomIn>(nameof(DCreater.NET_DVR_PTZSelZoomIn));
            _NET_DVR_PTZSelZoomIn_EX = GetDelegate<DCreater.NET_DVR_PTZSelZoomIn_EX>(nameof(DCreater.NET_DVR_PTZSelZoomIn_EX));
            _NET_DVR_PTZTrack = GetDelegate<DCreater.NET_DVR_PTZTrack>(nameof(DCreater.NET_DVR_PTZTrack));
            _NET_DVR_PTZTrack_EX = GetDelegate<DCreater.NET_DVR_PTZTrack_EX>(nameof(DCreater.NET_DVR_PTZTrack_EX));
            _NET_DVR_PTZTrack_Other = GetDelegate<DCreater.NET_DVR_PTZTrack_Other>(nameof(DCreater.NET_DVR_PTZTrack_Other));
            _NET_DVR_RealPlay = GetDelegate<DCreater.NET_DVR_RealPlay>(nameof(DCreater.NET_DVR_RealPlay));
            _NET_DVR_RealPlay_Card = GetDelegate<DCreater.NET_DVR_RealPlay_Card>(nameof(DCreater.NET_DVR_RealPlay_Card));
            _NET_DVR_RealPlay_V30 = GetDelegate<DCreater.NET_DVR_RealPlay_V30>(nameof(DCreater.NET_DVR_RealPlay_V30));
            _NET_DVR_RealPlay_V40 = GetDelegate<DCreater.NET_DVR_RealPlay_V40>(nameof(DCreater.NET_DVR_RealPlay_V40));
            _NET_DVR_RebootDVR = GetDelegate<DCreater.NET_DVR_RebootDVR>(nameof(DCreater.NET_DVR_RebootDVR));
            _NET_DVR_RefreshPlay = GetDelegate<DCreater.NET_DVR_RefreshPlay>(nameof(DCreater.NET_DVR_RefreshPlay));
            _NET_DVR_RefreshSurface_Card = GetDelegate<DCreater.NET_DVR_RefreshSurface_Card>(nameof(DCreater.NET_DVR_RefreshSurface_Card));
            _NET_DVR_ReleaseDDrawDevice = GetDelegate<DCreater.NET_DVR_ReleaseDDrawDevice>(nameof(DCreater.NET_DVR_ReleaseDDrawDevice));
            _NET_DVR_ReleaseDDraw_Card = GetDelegate<DCreater.NET_DVR_ReleaseDDraw_Card>(nameof(DCreater.NET_DVR_ReleaseDDraw_Card));
            _NET_DVR_ReleaseDevice_Card = GetDelegate<DCreater.NET_DVR_ReleaseDevice_Card>(nameof(DCreater.NET_DVR_ReleaseDevice_Card));
            if (Environment.Is64BitProcess)
            {
                _NET_DVR_ReleaseG711Encoder = GetDelegate<DCreater.NET_DVR_ReleaseG711Encoder>(nameof(DCreater.NET_DVR_ReleaseG711Encoder));
            }
            _NET_DVR_ReleaseG722Decoder = GetDelegate<DCreater.NET_DVR_ReleaseG722Decoder>(nameof(DCreater.NET_DVR_ReleaseG722Decoder));
            _NET_DVR_ReleaseG722Encoder = GetDelegate<DCreater.NET_DVR_ReleaseG722Encoder>(nameof(DCreater.NET_DVR_ReleaseG722Encoder));
            _NET_DVR_RemoteControl0 = GetDelegate<DCreater.NET_DVR_RemoteControl0>(nameof(IHikHCNetSdkProxy.NET_DVR_RemoteControl));
            _NET_DVR_RemoteControl1 = GetDelegate<DCreater.NET_DVR_RemoteControl1>(nameof(IHikHCNetSdkProxy.NET_DVR_RemoteControl));
            _NET_DVR_ResetPara_Card = GetDelegate<DCreater.NET_DVR_ResetPara_Card>(nameof(DCreater.NET_DVR_ResetPara_Card));
            _NET_DVR_RestoreConfig = GetDelegate<DCreater.NET_DVR_RestoreConfig>(nameof(DCreater.NET_DVR_RestoreConfig));
            _NET_DVR_RestoreSurface_Card = GetDelegate<DCreater.NET_DVR_RestoreSurface_Card>(nameof(DCreater.NET_DVR_RestoreSurface_Card));
            _NET_DVR_RigisterDrawFun = GetDelegate<DCreater.NET_DVR_RigisterDrawFun>(nameof(DCreater.NET_DVR_RigisterDrawFun));
            _NET_DVR_SaveConfig = GetDelegate<DCreater.NET_DVR_SaveConfig>(nameof(DCreater.NET_DVR_SaveConfig));
            _NET_DVR_SaveRealData = GetDelegate<DCreater.NET_DVR_SaveRealData>(nameof(DCreater.NET_DVR_SaveRealData));
            _NET_DVR_SaveRealData_V30 = GetDelegate<DCreater.NET_DVR_SaveRealData_V30>(nameof(DCreater.NET_DVR_SaveRealData_V30));
            _NET_DVR_SendRemoteConfig = GetDelegate<DCreater.NET_DVR_SendRemoteConfig>(nameof(DCreater.NET_DVR_SendRemoteConfig));
            _NET_DVR_SendTo232Port = GetDelegate<DCreater.NET_DVR_SendTo232Port>(nameof(DCreater.NET_DVR_SendTo232Port));
            _NET_DVR_SendToSerialPort = GetDelegate<DCreater.NET_DVR_SendToSerialPort>(nameof(DCreater.NET_DVR_SendToSerialPort));
            _NET_DVR_SendWithRecvRemoteConfig0 = GetDelegate<DCreater.NET_DVR_SendWithRecvRemoteConfig0>(nameof(IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig));
            _NET_DVR_SendWithRecvRemoteConfig1 = GetDelegate<DCreater.NET_DVR_SendWithRecvRemoteConfig1>(nameof(IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig));
            _NET_DVR_SendWithRecvRemoteConfig2 = GetDelegate<DCreater.NET_DVR_SendWithRecvRemoteConfig2>(nameof(IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig));
            _NET_DVR_SerialSend = GetDelegate<DCreater.NET_DVR_SerialSend>(nameof(DCreater.NET_DVR_SerialSend));
            _NET_DVR_SerialStart = GetDelegate<DCreater.NET_DVR_SerialStart>(nameof(DCreater.NET_DVR_SerialStart));
            _NET_DVR_SerialStop = GetDelegate<DCreater.NET_DVR_SerialStop>(nameof(DCreater.NET_DVR_SerialStop));
            _NET_DVR_SetAlarmDeviceUser = GetDelegate<DCreater.NET_DVR_SetAlarmDeviceUser>(nameof(DCreater.NET_DVR_SetAlarmDeviceUser));
            _NET_DVR_SetAlarmOut = GetDelegate<DCreater.NET_DVR_SetAlarmOut>(nameof(DCreater.NET_DVR_SetAlarmOut));
            _NET_DVR_SetATMPortCFG = GetDelegate<DCreater.NET_DVR_SetATMPortCFG>(nameof(DCreater.NET_DVR_SetATMPortCFG));
            _NET_DVR_SetAudioMode = GetDelegate<DCreater.NET_DVR_SetAudioMode>(nameof(DCreater.NET_DVR_SetAudioMode));
            _NET_DVR_SetBehaviorParamKey = GetDelegate<DCreater.NET_DVR_SetBehaviorParamKey>(nameof(DCreater.NET_DVR_SetBehaviorParamKey));
            // _NET_DVR_SetCCDCfg = GetDelegate<DCreater.NET_DVR_SetCCDCfg>(nameof(DCreater.NET_DVR_SetCCDCfg));
            _NET_DVR_SetConfigFile = GetDelegate<DCreater.NET_DVR_SetConfigFile>(nameof(DCreater.NET_DVR_SetConfigFile));
            _NET_DVR_SetConfigFile_EX = GetDelegate<DCreater.NET_DVR_SetConfigFile_EX>(nameof(DCreater.NET_DVR_SetConfigFile_EX));
            _NET_DVR_SetConnectTime = GetDelegate<DCreater.NET_DVR_SetConnectTime>(nameof(DCreater.NET_DVR_SetConnectTime));
            _NET_DVR_SetDDrawDevice = GetDelegate<DCreater.NET_DVR_SetDDrawDevice>(nameof(DCreater.NET_DVR_SetDDrawDevice));
            _NET_DVR_SetDecInfo = GetDelegate<DCreater.NET_DVR_SetDecInfo>(nameof(DCreater.NET_DVR_SetDecInfo));
            _NET_DVR_SetDecTransPort = GetDelegate<DCreater.NET_DVR_SetDecTransPort>(nameof(DCreater.NET_DVR_SetDecTransPort));
            _NET_DVR_SetDeviceConfig = GetDelegate<DCreater.NET_DVR_SetDeviceConfig>(nameof(DCreater.NET_DVR_SetDeviceConfig));
            _NET_DVR_SetDeviceConfigEx = GetDelegate<DCreater.NET_DVR_SetDeviceConfigEx>(nameof(DCreater.NET_DVR_SetDeviceConfigEx));
            _NET_DVR_SetDVRConfig = GetDelegate<DCreater.NET_DVR_SetDVRConfig>(nameof(DCreater.NET_DVR_SetDVRConfig));
            _NET_DVR_SetDVRMessage = GetDelegate<DCreater.NET_DVR_SetDVRMessage>(nameof(DCreater.NET_DVR_SetDVRMessage));
            _NET_DVR_SetDVRMessageCallBack = GetDelegate<DCreater.NET_DVR_SetDVRMessageCallBack>(nameof(DCreater.NET_DVR_SetDVRMessageCallBack));
            _NET_DVR_SetDVRMessageCallBack_V30 = GetDelegate<DCreater.NET_DVR_SetDVRMessageCallBack_V30>(nameof(DCreater.NET_DVR_SetDVRMessageCallBack_V30));
            _NET_DVR_SetDVRMessageCallBack_V31 = GetDelegate<DCreater.NET_DVR_SetDVRMessageCallBack_V31>(nameof(DCreater.NET_DVR_SetDVRMessageCallBack_V31));
            _NET_DVR_SetDVRMessageCallBack_V50 = GetDelegate<DCreater.NET_DVR_SetDVRMessageCallBack_V50>(nameof(DCreater.NET_DVR_SetDVRMessageCallBack_V50));
            _NET_DVR_SetDVRMessCallBack = GetDelegate<DCreater.NET_DVR_SetDVRMessCallBack>(nameof(DCreater.NET_DVR_SetDVRMessCallBack));
            _NET_DVR_SetDVRMessCallBack_EX = GetDelegate<DCreater.NET_DVR_SetDVRMessCallBack_EX>(nameof(DCreater.NET_DVR_SetDVRMessCallBack_EX));
            _NET_DVR_SetDVRMessCallBack_NEW = GetDelegate<DCreater.NET_DVR_SetDVRMessCallBack_NEW>(nameof(DCreater.NET_DVR_SetDVRMessCallBack_NEW));
            _NET_DVR_SetExceptionCallBack_V30 = GetDelegate<DCreater.NET_DVR_SetExceptionCallBack_V30>(nameof(DCreater.NET_DVR_SetExceptionCallBack_V30));
            // _NET_DVR_SetLFTrackMode = GetDelegate<DCreater.NET_DVR_SetLFTrackMode>(nameof(DCreater.NET_DVR_SetLFTrackMode));
            _NET_DVR_SetLogToFile = GetDelegate<DCreater.NET_DVR_SetLogToFile>(nameof(DCreater.NET_DVR_SetLogToFile));
            _NET_DVR_SetNetworkEnvironment = GetDelegate<DCreater.NET_DVR_SetNetworkEnvironment>(nameof(DCreater.NET_DVR_SetNetworkEnvironment));
            _NET_DVR_SetPlayDataCallBack = GetDelegate<DCreater.NET_DVR_SetPlayDataCallBack>(nameof(DCreater.NET_DVR_SetPlayDataCallBack));
            _NET_DVR_SetPlayerBufNumber = GetDelegate<DCreater.NET_DVR_SetPlayerBufNumber>(nameof(DCreater.NET_DVR_SetPlayerBufNumber));
            _NET_DVR_SetRealDataCallBack = GetDelegate<DCreater.NET_DVR_SetRealDataCallBack>(nameof(DCreater.NET_DVR_SetRealDataCallBack));
            _NET_DVR_SetReconnect = GetDelegate<DCreater.NET_DVR_SetReconnect>(nameof(DCreater.NET_DVR_SetReconnect));
            _NET_DVR_SetRtspConfig = GetDelegate<DCreater.NET_DVR_SetRtspConfig>(nameof(DCreater.NET_DVR_SetRtspConfig));
            _NET_DVR_SetScaleCFG = GetDelegate<DCreater.NET_DVR_SetScaleCFG>(nameof(DCreater.NET_DVR_SetScaleCFG));
            _NET_DVR_SetScaleCFG_V30 = GetDelegate<DCreater.NET_DVR_SetScaleCFG_V30>(nameof(DCreater.NET_DVR_SetScaleCFG_V30));
            _NET_DVR_SetSDKLocalCfg = GetDelegate<DCreater.NET_DVR_SetSDKLocalCfg>(nameof(DCreater.NET_DVR_SetSDKLocalCfg));
            _NET_DVR_SetShowMode = GetDelegate<DCreater.NET_DVR_SetShowMode>(nameof(DCreater.NET_DVR_SetShowMode));
            _NET_DVR_SetStandardDataCallBack = GetDelegate<DCreater.NET_DVR_SetStandardDataCallBack>(nameof(DCreater.NET_DVR_SetStandardDataCallBack));
            _NET_DVR_SetSTDConfig = GetDelegate<DCreater.NET_DVR_SetSTDConfig>(nameof(DCreater.NET_DVR_SetSTDConfig));
            _NET_DVR_SetupAlarmChan = GetDelegate<DCreater.NET_DVR_SetupAlarmChan>(nameof(DCreater.NET_DVR_SetupAlarmChan));
            _NET_DVR_SetupAlarmChan_V30 = GetDelegate<DCreater.NET_DVR_SetupAlarmChan_V30>(nameof(DCreater.NET_DVR_SetupAlarmChan_V30));
            _NET_DVR_SetupAlarmChan_V41 = GetDelegate<DCreater.NET_DVR_SetupAlarmChan_V41>(nameof(DCreater.NET_DVR_SetupAlarmChan_V41));
            _NET_DVR_SetValidIP = GetDelegate<DCreater.NET_DVR_SetValidIP>(nameof(DCreater.NET_DVR_SetValidIP));
            _NET_DVR_SetVCADrawMode = GetDelegate<DCreater.NET_DVR_SetVCADrawMode>(nameof(DCreater.NET_DVR_SetVCADrawMode));
            _NET_DVR_SetVideoEffect = GetDelegate<DCreater.NET_DVR_SetVideoEffect>(nameof(DCreater.NET_DVR_SetVideoEffect));
            _NET_DVR_SetVoiceComClientVolume = GetDelegate<DCreater.NET_DVR_SetVoiceComClientVolume>(nameof(DCreater.NET_DVR_SetVoiceComClientVolume));
            _NET_DVR_SetVolume_Card = GetDelegate<DCreater.NET_DVR_SetVolume_Card>(nameof(DCreater.NET_DVR_SetVolume_Card));
            _NET_DVR_ShutDownDVR = GetDelegate<DCreater.NET_DVR_ShutDownDVR>(nameof(DCreater.NET_DVR_ShutDownDVR));
            _NET_DVR_StartDecode = GetDelegate<DCreater.NET_DVR_StartDecode>(nameof(DCreater.NET_DVR_StartDecode));
            _NET_DVR_StartDecSpecialCon = GetDelegate<DCreater.NET_DVR_StartDecSpecialCon>(nameof(DCreater.NET_DVR_StartDecSpecialCon));
            _NET_DVR_StartDVRRecord = GetDelegate<DCreater.NET_DVR_StartDVRRecord>(nameof(DCreater.NET_DVR_StartDVRRecord));
            _NET_DVR_StartListen = GetDelegate<DCreater.NET_DVR_StartListen>(nameof(DCreater.NET_DVR_StartListen));
            _NET_DVR_StartListen_V30 = GetDelegate<DCreater.NET_DVR_StartListen_V30>(nameof(DCreater.NET_DVR_StartListen_V30));
            _NET_DVR_StartRemoteConfig = GetDelegate<DCreater.NET_DVR_StartRemoteConfig>(nameof(DCreater.NET_DVR_StartRemoteConfig));
            _NET_DVR_StartVoiceCom = GetDelegate<DCreater.NET_DVR_StartVoiceCom>(nameof(DCreater.NET_DVR_StartVoiceCom));
            _NET_DVR_StartVoiceCom_MR = GetDelegate<DCreater.NET_DVR_StartVoiceCom_MR>(nameof(DCreater.NET_DVR_StartVoiceCom_MR));
            _NET_DVR_StartVoiceCom_MR_V30 = GetDelegate<DCreater.NET_DVR_StartVoiceCom_MR_V30>(nameof(DCreater.NET_DVR_StartVoiceCom_MR_V30));
            _NET_DVR_StartVoiceCom_V30 = GetDelegate<DCreater.NET_DVR_StartVoiceCom_V30>(nameof(DCreater.NET_DVR_StartVoiceCom_V30));
            _NET_DVR_STDXMLConfig0 = GetDelegate<DCreater.NET_DVR_STDXMLConfig0>(nameof(IHikHCNetSdkProxy.NET_DVR_STDXMLConfig));
            _NET_DVR_STDXMLConfig1 = GetDelegate<DCreater.NET_DVR_STDXMLConfig1>(nameof(IHikHCNetSdkProxy.NET_DVR_STDXMLConfig));
            _NET_DVR_StopDecode = GetDelegate<DCreater.NET_DVR_StopDecode>(nameof(DCreater.NET_DVR_StopDecode));
            _NET_DVR_StopDecSpecialCon = GetDelegate<DCreater.NET_DVR_StopDecSpecialCon>(nameof(DCreater.NET_DVR_StopDecSpecialCon));
            _NET_DVR_StopDVRRecord = GetDelegate<DCreater.NET_DVR_StopDVRRecord>(nameof(DCreater.NET_DVR_StopDVRRecord));
            _NET_DVR_StopGetFile = GetDelegate<DCreater.NET_DVR_StopGetFile>(nameof(DCreater.NET_DVR_StopGetFile));
            _NET_DVR_StopListen = GetDelegate<DCreater.NET_DVR_StopListen>(nameof(DCreater.NET_DVR_StopListen));
            _NET_DVR_StopListen_V30 = GetDelegate<DCreater.NET_DVR_StopListen_V30>(nameof(DCreater.NET_DVR_StopListen_V30));
            _NET_DVR_StopPlayBack = GetDelegate<DCreater.NET_DVR_StopPlayBack>(nameof(DCreater.NET_DVR_StopPlayBack));
            _NET_DVR_StopPlayBackSave = GetDelegate<DCreater.NET_DVR_StopPlayBackSave>(nameof(DCreater.NET_DVR_StopPlayBackSave));
            _NET_DVR_StopRealPlay = GetDelegate<DCreater.NET_DVR_StopRealPlay>(nameof(DCreater.NET_DVR_StopRealPlay));
            _NET_DVR_StopRemoteConfig = GetDelegate<DCreater.NET_DVR_StopRemoteConfig>(nameof(DCreater.NET_DVR_StopRemoteConfig));
            _NET_DVR_StopSaveRealData = GetDelegate<DCreater.NET_DVR_StopSaveRealData>(nameof(DCreater.NET_DVR_StopSaveRealData));
            _NET_DVR_StopVoiceCom = GetDelegate<DCreater.NET_DVR_StopVoiceCom>(nameof(DCreater.NET_DVR_StopVoiceCom));
            _NET_DVR_ThrowBFrame = GetDelegate<DCreater.NET_DVR_ThrowBFrame>(nameof(DCreater.NET_DVR_ThrowBFrame));
            _NET_DVR_TransPTZ = GetDelegate<DCreater.NET_DVR_TransPTZ>(nameof(DCreater.NET_DVR_TransPTZ));
            _NET_DVR_TransPTZ_EX = GetDelegate<DCreater.NET_DVR_TransPTZ_EX>(nameof(DCreater.NET_DVR_TransPTZ_EX));
            _NET_DVR_TransPTZ_Other = GetDelegate<DCreater.NET_DVR_TransPTZ_Other>(nameof(DCreater.NET_DVR_TransPTZ_Other));
            _NET_DVR_UnlockFileByName = GetDelegate<DCreater.NET_DVR_UnlockFileByName>(nameof(DCreater.NET_DVR_UnlockFileByName));
            _NET_DVR_UnLockPanel = GetDelegate<DCreater.NET_DVR_UnLockPanel>(nameof(DCreater.NET_DVR_UnLockPanel));
            _NET_DVR_Upgrade = GetDelegate<DCreater.NET_DVR_Upgrade>(nameof(DCreater.NET_DVR_Upgrade));
            _NET_DVR_Upgrade_V40 = GetDelegate<DCreater.NET_DVR_Upgrade_V40>(nameof(DCreater.NET_DVR_Upgrade_V40));
            _NET_DVR_UploadClose = GetDelegate<DCreater.NET_DVR_UploadClose>(nameof(DCreater.NET_DVR_UploadClose));
            _NET_DVR_UploadFile_V40 = GetDelegate<DCreater.NET_DVR_UploadFile_V40>(nameof(DCreater.NET_DVR_UploadFile_V40));
            _NET_DVR_UploadLogo = GetDelegate<DCreater.NET_DVR_UploadLogo>(nameof(DCreater.NET_DVR_UploadLogo));
            _NET_DVR_UploadSend = GetDelegate<DCreater.NET_DVR_UploadSend>(nameof(DCreater.NET_DVR_UploadSend));
            _NET_DVR_VoiceComSendData = GetDelegate<DCreater.NET_DVR_VoiceComSendData>(nameof(DCreater.NET_DVR_VoiceComSendData));
            _NET_DVR_Volume = GetDelegate<DCreater.NET_DVR_Volume>(nameof(DCreater.NET_DVR_Volume));
            // _NET_SDK_RealPlay = GetDelegate<DCreater.NET_SDK_RealPlay>(nameof(DCreater.NET_SDK_RealPlay));
            _NET_VCA_RestartLib = GetDelegate<DCreater.NET_VCA_RestartLib>(nameof(DCreater.NET_VCA_RestartLib));
        }
        public override string GetFileFullName()
        {
            return HikHCNetSdk.DllFullName;
        }
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam);
        #region // 显示实现方法
        bool IHikHCNetSdkProxy.NET_DVR_AddDVR(int lUserID)
            => _NET_DVR_AddDVR.Invoke(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan)
            => _NET_DVR_AddDVR_V30.Invoke(lUserID, dwVoiceChan);

        bool IHikHCNetSdkProxy.NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable)
            => _NET_DVR_AudioPreview_Card.Invoke(lRealHandle, bEnable);

        bool IHikHCNetSdkProxy.NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName)
            => _NET_DVR_CaptureJPEGPicture.Invoke(lUserID, lChannel, ref lpJpegPara, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned)
            => _NET_DVR_CaptureJPEGPicture_NEW.Invoke(lUserID, lChannel, ref lpJpegPara, sJpegPicBuffer, dwPicSize, ref lpSizeReturned);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePicture(int lRealHandle, string sPicFileName)
            => _NET_DVR_CapturePicture.Invoke(lRealHandle, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePictureBlock(int lRealHandle, string sPicFileName, int dwTimeOut)
            => _NET_DVR_CapturePictureBlock.Invoke(lRealHandle, sPicFileName, dwTimeOut);

        bool IHikHCNetSdkProxy.NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName)
            => _NET_DVR_CapturePicture_Card.Invoke(lRealHandle, sPicFileName);

        bool IHikHCNetSdkProxy.NET_DVR_Cleanup()
            => _NET_DVR_Cleanup.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ClearSurface_Card()
            => _NET_DVR_ClearSurface_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ClickKey(int lUserID, int lKeyIndex)
            => _NET_DVR_ClickKey.Invoke(lUserID, lKeyIndex);

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStart()
            => _NET_DVR_ClientAudioStart.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser)
            => _NET_DVR_ClientAudioStart_V30.Invoke(fVoiceAudioStart, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_ClientAudioStop()
            => _NET_DVR_ClientAudioStop.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat)
            => _NET_DVR_ClientGetframeformat.Invoke(lUserID, ref lpFrameFormat);

        bool IHikHCNetSdkProxy.NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue)
            => _NET_DVR_ClientGetVideoEffect.Invoke(lRealHandle, ref pBrightValue, ref pContrastValue, ref pSaturationValue, ref pHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat)
            => _NET_DVR_ClientSetframeformat.Invoke(lUserID, ref lpFrameFormat);

        bool IHikHCNetSdkProxy.NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue)
            => _NET_DVR_ClientSetVideoEffect.Invoke(lRealHandle, dwBrightValue, dwContrastValue, dwSaturationValue, dwHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_CloseAlarmChan(int lAlarmHandle)
            => _NET_DVR_CloseAlarmChan.Invoke(lAlarmHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseAlarmChan_V30(int lAlarmHandle)
            => _NET_DVR_CloseAlarmChan_V30.Invoke(lAlarmHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseFindPicture(int lFindHandle)
            => _NET_DVR_CloseFindPicture.Invoke(lFindHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseFormatHandle(int lFormatHandle)
            => _NET_DVR_CloseFormatHandle.Invoke(lFormatHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseSound()
            => _NET_DVR_CloseSound.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_CloseSoundShare(int lRealHandle)
            => _NET_DVR_CloseSoundShare.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseSound_Card(int lRealHandle)
            => _NET_DVR_CloseSound_Card.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseUpgradeHandle(int lUpgradeHandle)
            => _NET_DVR_CloseUpgradeHandle.Invoke(lUpgradeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_CloseUploadHandle(int lUploadHandle)
            => _NET_DVR_CloseUploadHandle.Invoke(lUploadHandle);

        bool IHikHCNetSdkProxy.NET_DVR_ContinuousShoot(int lUserID, ref NET_DVR_SNAPCFG lpInter)
            => _NET_DVR_ContinuousShoot.Invoke(lUserID, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic)
            => _NET_DVR_ControlGateway.Invoke(lUserID, lGatewayIndex, dwStaic);

        bool IHikHCNetSdkProxy.NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode)
            => _NET_DVR_DecCtrlDec.Invoke(lUserID, lChannel, dwControlCode);

        bool IHikHCNetSdkProxy.NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl)
            => _NET_DVR_DecCtrlScreen.Invoke(lUserID, lChannel, dwControl);

        bool IHikHCNetSdkProxy.NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer)
            => _NET_DVR_DecodeG711Frame.Invoke(iType, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer)
            => _NET_DVR_DecodeG722Frame.Invoke(pDecHandle, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo)
            => _NET_DVR_DecPlayBackCtrl.Invoke(lUserID, lChannel, dwControlCode, dwInValue, ref LPOutValue, ref lpRemoteFileInfo);

        bool IHikHCNetSdkProxy.NET_DVR_DelDVR(int lUserID)
            => _NET_DVR_DelDVR.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_DelDVR_V30(int lVoiceHandle)
            => _NET_DVR_DelDVR_V30.Invoke(lVoiceHandle);

        bool IHikHCNetSdkProxy.NET_DVR_EmailTest(int lUserID) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_EmailTest.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param)
            => _NET_DVR_EncodeG711Frame.Invoke(handle, ref p_enc_proc_param);

        bool IHikHCNetSdkProxy.NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer)
            => _NET_DVR_EncodeG722Frame.Invoke(pEncodeHandle, ref pInBuffer, ref pOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_FindClose(int lFindHandle)
            => _NET_DVR_FindClose.Invoke(lFindHandle);

        bool IHikHCNetSdkProxy.NET_DVR_FindClose_V30(int lFindHandle)
            => _NET_DVR_FindClose_V30.Invoke(lFindHandle);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => _NET_DVR_FindDVRLog.Invoke(lUserID, lSelectMode, dwMajorType, dwMinorType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => _NET_DVR_FindDVRLog_Matrix.Invoke(iUserID, lSelectMode, dwMajorType, dwMinorType, ref lpVedioPlatLog, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart)
            => _NET_DVR_FindDVRLog_V30.Invoke(lUserID, lSelectMode, dwMajorType, dwMinorType, ref lpStartTime, ref lpStopTime, bOnlySmart);

        int IHikHCNetSdkProxy.NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => _NET_DVR_FindFile.Invoke(lUserID, lChannel, dwFileType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime)
            => _NET_DVR_FindFileByCard.Invoke(lUserID, lChannel, dwFileType, nFindType, ref sCardNumber, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam)
            => _NET_DVR_FindFileByEvent.Invoke(lUserID, ref lpSearchEventParam);

        int IHikHCNetSdkProxy.NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam)
            => _NET_DVR_FindFileByEvent_V40.Invoke(lUserID, ref lpSearchEventParam);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_FindFile_Card.Invoke(lUserID, lChannel, dwFileType, ref lpStartTime, ref lpStopTime);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond)
            => _NET_DVR_FindFile_V30.Invoke(lUserID, ref pFindCond);

        int IHikHCNetSdkProxy.NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond)
            => _NET_DVR_FindFile_V40.Invoke(lUserID, ref pFindCond);

        bool IHikHCNetSdkProxy.NET_DVR_FindLogClose(int lLogHandle)
            => _NET_DVR_FindLogClose.Invoke(lLogHandle);

        bool IHikHCNetSdkProxy.NET_DVR_FindLogClose_V30(int lLogHandle)
            => _NET_DVR_FindLogClose_V30.Invoke(lLogHandle);

        int IHikHCNetSdkProxy.NET_DVR_FindNextEvent(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET lpSearchEventRet)
            => _NET_DVR_FindNextEvent.Invoke(lSearchHandle, ref lpSearchEventRet);

        int IHikHCNetSdkProxy.NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet)
            => _NET_DVR_FindNextEvent_V40.Invoke(lSearchHandle, ref lpSearchEventRet);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData)
            => _NET_DVR_FindNextFile.Invoke(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData)
            => _NET_DVR_FindNextFile_Card.Invoke(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData)
            => _NET_DVR_FindNextFile_V30.Invoke(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData)
            => _NET_DVR_FindNextFile_V40.Invoke(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData)
            => _NET_DVR_FindNextLog.Invoke(lLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData)
            => _NET_DVR_FindNextLog_MATRIX.Invoke(iLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData)
            => _NET_DVR_FindNextLog_V30.Invoke(lLogHandle, ref lpLogData);

        int IHikHCNetSdkProxy.NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData)
            => _NET_DVR_FindNextPicture_V50.Invoke(lFindHandle, ref lpFindData);

        int IHikHCNetSdkProxy.NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam)
            => _NET_DVR_FindPicture.Invoke(lUserID, ref pFindParam);

        int IHikHCNetSdkProxy.NET_DVR_FormatDisk(int lUserID, int lDiskNumber)
            => _NET_DVR_FormatDisk.Invoke(lUserID, lDiskNumber);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser)
            => _NET_DVR_GetAlarmDeviceUser.Invoke(lUserID, lUserIndex, ref lpDeviceUser);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState)
            => _NET_DVR_GetAlarmOut.Invoke(lUserID, ref lpAlarmOutState);

        bool IHikHCNetSdkProxy.NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState)
            => _NET_DVR_GetAlarmOut_V30.Invoke(lUserID, lpAlarmOutState);

        bool IHikHCNetSdkProxy.NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort)
            => _NET_DVR_GetATMPortCFG.Invoke(lUserID, ref LPOutATMPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetAtmProtocol.Invoke(lUserID, ref lpAtmProtocol);

        bool IHikHCNetSdkProxy.NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue)
            => _NET_DVR_GetBehaviorParamKey.Invoke(lUserID, lChannel, dwParameterKey, ref pValue);

        int IHikHCNetSdkProxy.NET_DVR_GetCardLastError_Card()
            => _NET_DVR_GetCardLastError_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetCCDCfg.Invoke(lUserID, lChannel, ref lpCCDCfg);

        IntPtr IHikHCNetSdkProxy.NET_DVR_GetChanHandle_Card(int lRealHandle)
            => _NET_DVR_GetChanHandle_Card.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile(int lUserID, string sFileName)
            => _NET_DVR_GetConfigFile.Invoke(lUserID, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize)
            => _NET_DVR_GetConfigFile_EX.Invoke(lUserID, sOutBuffer, dwOutSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize)
            => _NET_DVR_GetConfigFile_V30.Invoke(lUserID, sOutBuffer, dwOutSize, ref pReturnSize);

        int IHikHCNetSdkProxy.NET_DVR_GetDDrawDeviceTotalNums()
            => _NET_DVR_GetDDrawDeviceTotalNums.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus)
            => _NET_DVR_GetDecCurLinkStatus.Invoke(lUserID, lChannel, ref lpDecStatus);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo)
            => _NET_DVR_GetDecInfo.Invoke(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState)
            => _NET_DVR_GetDecoderState.Invoke(lUserID, lChannel, ref lpDecoderState);

        bool IHikHCNetSdkProxy.NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort)
            => _NET_DVR_GetDecTransPort.Invoke(lUserID, ref lpTransPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength)
            => _NET_DVR_GetDeviceAbility.Invoke(lUserID, dwAbilityType, pInBuf, dwInLength, pOutBuf, dwOutLength);

        bool IHikHCNetSdkProxy.NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => _NET_DVR_GetDeviceConfig.Invoke(lUserID, dwCommand, dwCount, lpInBuffer, dwInBufferSize, lpStatusList, lpOutBuffer, dwOutBufferSize);

        int IHikHCNetSdkProxy.NET_DVR_GetDownloadPos(int lFileHandle)
            => _NET_DVR_GetDownloadPos.Invoke(lFileHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned)
            => _NET_DVR_GetDVRConfig.Invoke(lUserID, dwCommand, lChannel, lpOutBuffer, dwOutBufferSize, ref lpBytesReturned);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP)
            => _NET_DVR_GetDVRIPByResolveSvr.Invoke(sServerIP, wServerPort, sDVRName, wDVRNameLen, sDVRSerialNumber, wDVRSerialLen, pGetIP);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort)
            => _NET_DVR_GetDVRIPByResolveSvr_EX.Invoke(sServerIP, wServerPort, sDVRName, wDVRNameLen, sDVRSerialNumber, wDVRSerialLen, sGetIP, ref dwPort);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState)
            => _NET_DVR_GetDVRWorkState.Invoke(lUserID, ref lpWorkState);

        bool IHikHCNetSdkProxy.NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState)
            => _NET_DVR_GetDVRWorkState_V30.Invoke(lUserID, pWorkState);

        IntPtr IHikHCNetSdkProxy.NET_DVR_GetErrorMsg(ref int pErrorNo)
            => _NET_DVR_GetErrorMsg.Invoke(ref pErrorNo);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName)
            => _NET_DVR_GetFileByName.Invoke(lUserID, sDVRFileName, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName)
            => _NET_DVR_GetFileByTime.Invoke(lUserID, lChannel, ref lpStartTime, ref lpStopTime, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond)
            => _NET_DVR_GetFileByTime_V40.Invoke(lUserID, sSavedFileName, ref pDownloadCond);

        bool IHikHCNetSdkProxy.NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic)
            => _NET_DVR_GetFormatProgress.Invoke(lFormatHandle, ref pCurrentFormatDisk, ref pCurrentDiskPos, ref pFormatStatic);

        bool IHikHCNetSdkProxy.NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList)
            => _NET_DVR_GetInputSignalList_V40.Invoke(lUserID, dwDevNum, ref lpInputSignalList);

        bool IHikHCNetSdkProxy.NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList)
            => _NET_DVR_GetIPCProtoList.Invoke(lUserID, ref lpProtoList);

        bool IHikHCNetSdkProxy.NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList)
            => _NET_DVR_GetIPCProtoList_V41.Invoke(lUserID, ref lpProtoList);

        uint IHikHCNetSdkProxy.NET_DVR_GetLastError()
            => _NET_DVR_GetLastError.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetLFTrackMode.Invoke(lUserID, lChannel, ref lpTrackMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref bool pEnableBind)
            => _NET_DVR_GetLocalIP.Invoke(strIP, ref pValidNum, ref pEnableBind);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig0.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig1.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig2.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig3.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig4.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig5.Invoke(lHandle, ref lpOutBuff, dwOutBuffSize);

        int IHikHCNetSdkProxy.NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, int dwOutBuffSize)
            => _NET_DVR_GetNextRemoteConfig6.Invoke(lHandle, lpOutBuff, dwOutBuffSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetParamSetMode.Invoke(lUserID, ref dwParamSetMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetPicture(int lUserID, string sDVRFileName, string sSavedFileName)
            => _NET_DVR_GetPicture.Invoke(lUserID, sDVRFileName, sSavedFileName);

        int IHikHCNetSdkProxy.NET_DVR_GetPicUploadProgress(int lUploadHandle)
            => _NET_DVR_GetPicUploadProgress.Invoke(lUploadHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetPicUploadState(int lUploadHandle)
            => _NET_DVR_GetPicUploadState.Invoke(lUploadHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime)
            => _NET_DVR_GetPlayBackOsdTime.Invoke(lPlayHandle, ref lpOsdTime);

        int IHikHCNetSdkProxy.NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle)
            => _NET_DVR_GetPlayBackPlayerIndex.Invoke(lPlayHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetPlayBackPos(int lPlayHandle)
            => _NET_DVR_GetPlayBackPos.Invoke(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet)
            => _NET_DVR_GetPTZCruise.Invoke(lUserID, lChannel, lCruiseRoute, ref lpCruiseRet);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCtrl(int lRealHandle)
            => _NET_DVR_GetPTZCtrl.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZCtrl_Other(int lUserID, int lChannel)
            => _NET_DVR_GetPTZCtrl_Other.Invoke(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg)
            => _NET_DVR_GetPTZProtocol.Invoke(lUserID, ref pPtzcfg);

        bool IHikHCNetSdkProxy.NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpHeight) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetRealHeight.Invoke(lUserID, lChannel, ref lpLine, ref lpHeight);

        bool IHikHCNetSdkProxy.NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpLength) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_GetRealLength.Invoke(lUserID, lChannel, ref lpLine, ref lpLength);

        int IHikHCNetSdkProxy.NET_DVR_GetRealPlayerIndex(int lRealHandle)
            => _NET_DVR_GetRealPlayerIndex.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState)
            => _NET_DVR_GetRemoteConfigState.Invoke(lHandle, pState);

        bool IHikHCNetSdkProxy.NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize)
            => _NET_DVR_GetRtspConfig.Invoke(lUserID, dwCommand, ref lpOutBuffer, dwOutBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale)
            => _NET_DVR_GetScaleCFG.Invoke(lUserID, ref lpOutScale);

        bool IHikHCNetSdkProxy.NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg)
            => _NET_DVR_GetScaleCFG_V30.Invoke(lUserID, ref pScalecfg);

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl)
            => _NET_DVR_GetSDKAbility.Invoke(ref pSDKAbl);

        uint IHikHCNetSdkProxy.NET_DVR_GetSDKBuildVersion()
            => _NET_DVR_GetSDKBuildVersion.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff)
            => _NET_DVR_GetSDKLocalCfg.Invoke(enumType, lpOutBuff);

        bool IHikHCNetSdkProxy.NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState)
            => _NET_DVR_GetSDKState.Invoke(ref pSDKState);

        uint IHikHCNetSdkProxy.NET_DVR_GetSDKVersion()
            => _NET_DVR_GetSDKVersion.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo)
            => _NET_DVR_GetSerialNum_Card.Invoke(lChannelNum, ref pDeviceSerialNo);

        bool IHikHCNetSdkProxy.NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam)
            => _NET_DVR_GetSTDConfig.Invoke(iUserID, dwCommand, ref lpConfigParam);

        int IHikHCNetSdkProxy.NET_DVR_GetUpgradeProgress(int lUpgradeHandle)
            => _NET_DVR_GetUpgradeProgress.Invoke(lUpgradeHandle);

        int IHikHCNetSdkProxy.NET_DVR_GetUpgradeState(int lUpgradeHandle)
            => _NET_DVR_GetUpgradeState.Invoke(lUpgradeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => _NET_DVR_GetUploadResult.Invoke(lUploadHandle, lpOutBuffer, dwOutBufferSize);

        int IHikHCNetSdkProxy.NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress)
            => _NET_DVR_GetUploadState.Invoke(lUploadHandle, ref pProgress);

        bool IHikHCNetSdkProxy.NET_DVR_GetUpnpNatState(int lUserID, ref NET_DVR_UPNP_NAT_STATE lpState)
            => _NET_DVR_GetUpnpNatState.Invoke(lUserID, ref lpState);

        bool IHikHCNetSdkProxy.NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode)
            => _NET_DVR_GetVCADrawMode.Invoke(lUserID, lChannel, ref lpDrawMode);

        bool IHikHCNetSdkProxy.NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue)
            => _NET_DVR_GetVideoEffect.Invoke(lUserID, lChannel, ref pBrightValue, ref pContrastValue, ref pSaturationValue, ref pHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_Init()
            => _NET_DVR_Init.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_InitDDrawDevice()
            => _NET_DVR_InitDDrawDevice.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey)
            => _NET_DVR_InitDDraw_Card.Invoke(hParent, colorKey);

        bool IHikHCNetSdkProxy.NET_DVR_InitDevice_Card(ref int pDeviceTotalChan)
            => _NET_DVR_InitDevice_Card.Invoke(ref pDeviceTotalChan);

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info)
        {
            if (Environment.Is64BitProcess) { return _NET_DVR_InitG711Encoder.Invoke(ref enc_info); }
            throw new NotSupportedException("未找到方法内容，不支持32位请求");
        }

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG722Decoder(int nBitrate)
            => _NET_DVR_InitG722Decoder.Invoke(nBitrate);

        IntPtr IHikHCNetSdkProxy.NET_DVR_InitG722Encoder()
            => _NET_DVR_InitG722Encoder.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn)
            => _NET_DVR_InquestStartCDW_V30.Invoke(lUserID, ref lpInquestRoom, bNotBurn);

        int IHikHCNetSdkProxy.NET_DVR_IsSupport()
            => _NET_DVR_IsSupport.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_LockFileByName(int lUserID, string sLockFileName)
            => _NET_DVR_LockFileByName.Invoke(lUserID, sLockFileName);

        bool IHikHCNetSdkProxy.NET_DVR_LockPanel(int lUserID)
            => _NET_DVR_LockPanel.Invoke(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo)
            => _NET_DVR_Login.Invoke(sDVRIP, wDVRPort, sUserName, sPassword, ref lpDeviceInfo);

        int IHikHCNetSdkProxy.NET_DVR_Login_V30(string sDVRIP, int wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo)
            => _NET_DVR_Login_V30.Invoke(sDVRIP, wDVRPort, sUserName, sPassword, ref lpDeviceInfo);

        int IHikHCNetSdkProxy.NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo)
            => _NET_DVR_Login_V40.Invoke(ref pLoginInfo, ref lpDeviceInfo);

        bool IHikHCNetSdkProxy.NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch)
            => _NET_DVR_LogoSwitch.Invoke(lUserID, dwDecChan, dwLogoSwitch);

        bool IHikHCNetSdkProxy.NET_DVR_Logout(int iUserID)
            => _NET_DVR_Logout.Invoke(iUserID);

        bool IHikHCNetSdkProxy.NET_DVR_Logout_V30(int lUserID)
            => _NET_DVR_Logout_V30.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_MakeKeyFrame(int lUserID, int lChannel)
            => _NET_DVR_MakeKeyFrame.Invoke(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_MakeKeyFrameSub(int lUserID, int lChannel)
            => _NET_DVR_MakeKeyFrameSub.Invoke(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_ManualSnap(int lUserID, ref NET_DVR_MANUALSNAP lpInter, ref NET_DVR_PLATE_RESULT lpOuter)
            => _NET_DVR_ManualSnap.Invoke(lUserID, ref lpInter, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam)
            => _NET_DVR_MatrixDiaplayControl.Invoke(lUserID, dwDispChanNum, dwDispChanCmd, dwCmdParam);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable)
            => _NET_DVR_MatrixGetDecChanEnable.Invoke(lUserID, dwDecChanNum, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter)
            => _NET_DVR_MatrixGetDecChanInfo.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter)
            => _NET_DVR_MatrixGetDecChanInfo_V30.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter)
            => _NET_DVR_MatrixGetDecChanInfo_V41.Invoke(lUserID, dwDecChanNum, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter)
            => _NET_DVR_MatrixGetDecChanStatus.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg)
            => _NET_DVR_MatrixGetDeviceStatus.Invoke(lUserID, ref lpDecoderCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg)
            => _NET_DVR_MatrixGetDisplayCfg.Invoke(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg)
            => _NET_DVR_MatrixGetDisplayCfg_V41.Invoke(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable)
            => _NET_DVR_MatrixGetLoopDecChanEnable.Invoke(lUserID, dwDecChanNum, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter)
            => _NET_DVR_MatrixGetLoopDecChanInfo.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter)
            => _NET_DVR_MatrixGetLoopDecChanInfo_V30.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable)
            => _NET_DVR_MatrixGetLoopDecEnable.Invoke(lUserID, ref lpdwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter)
            => _NET_DVR_MatrixGetRemotePlayStatus.Invoke(lUserID, dwDecChanNum, ref lpOuter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg)
            => _NET_DVR_MatrixGetSceneCfg.Invoke(lUserID, dwSceneNum, ref lpSceneCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo)
            => _NET_DVR_MatrixGetTranInfo.Invoke(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo)
            => _NET_DVR_MatrixGetTranInfo_V30.Invoke(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSendData(int lPassiveHandle, IntPtr pSendBuf, uint dwBufSize)
            => _NET_DVR_MatrixSendData.Invoke(lPassiveHandle, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable)
            => _NET_DVR_MatrixSetDecChanEnable.Invoke(lUserID, dwDecChanNum, dwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg)
            => _NET_DVR_MatrixSetDisplayCfg.Invoke(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg)
            => _NET_DVR_MatrixSetDisplayCfg_V41.Invoke(lUserID, dwDispChanNum, ref lpDisplayCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable)
            => _NET_DVR_MatrixSetLoopDecChanEnable.Invoke(lUserID, dwDecChanNum, dwEnable);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter)
            => _NET_DVR_MatrixSetLoopDecChanInfo.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter)
            => _NET_DVR_MatrixSetLoopDecChanInfo_V30.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter)
            => _NET_DVR_MatrixSetRemotePlay.Invoke(lUserID, dwDecChanNum, ref lpInter);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue)
            => _NET_DVR_MatrixSetRemotePlayControl.Invoke(lUserID, dwDecChanNum, dwControlCode, dwInValue, ref LPOutValue);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg)
            => _NET_DVR_MatrixSetSceneCfg.Invoke(lUserID, dwSceneNum, ref lpSceneCfg);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo)
            => _NET_DVR_MatrixSetTranInfo.Invoke(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo)
            => _NET_DVR_MatrixSetTranInfo_V30.Invoke(lUserID, ref lpTranInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo)
            => _NET_DVR_MatrixStartDynamic.Invoke(lUserID, dwDecChanNum, ref lpDynamicInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo)
            => _NET_DVR_MatrixStartDynamic_V30.Invoke(lUserID, dwDecChanNum, ref lpDynamicInfo);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo)
            => _NET_DVR_MatrixStartDynamic_V41.Invoke(lUserID, dwDecChanNum, ref lpDynamicInfo);

        int IHikHCNetSdkProxy.NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode)
            => _NET_DVR_MatrixStartPassiveDecode.Invoke(lUserID, dwDecChanNum, ref lpPassiveMode);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum)
            => _NET_DVR_MatrixStopDynamic.Invoke(lUserID, dwDecChanNum);

        bool IHikHCNetSdkProxy.NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle)
            => _NET_DVR_MatrixStopPassiveDecode.Invoke(lPassiveHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSound(int lRealHandle)
            => _NET_DVR_OpenSound.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSoundShare(int lRealHandle)
            => _NET_DVR_OpenSoundShare.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_OpenSound_Card(int lRealHandle)
            => _NET_DVR_OpenSound_Card.Invoke(lRealHandle);

        int IHikHCNetSdkProxy.NET_DVR_PicUpload(int lUserID, string sFileName, ref NET_DVR_PICTURECFG lpPictureCfg)
            => _NET_DVR_PicUpload.Invoke(lUserID, sFileName, ref lpPictureCfg);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd)
            => _NET_DVR_PlayBackByName.Invoke(lUserID, sPlayBackFileName, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, IntPtr hWnd)
            => _NET_DVR_PlayBackByTime.Invoke(lUserID, lChannel, ref lpStartTime, ref lpStopTime, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara)
            => _NET_DVR_PlayBackByTime_V40.Invoke(lUserID, ref pVodPara);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName)
            => _NET_DVR_PlayBackCaptureFile.Invoke(lPlayHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue)
            => _NET_DVR_PlayBackControl.Invoke(lPlayHandle, dwControlCode, dwInValue, ref LPOutValue);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue)
            => _NET_DVR_PlayBackControl_V40.Invoke(lPlayHandle, dwControlCode, lpInBuffer, dwInValue, lpOutBuffer, ref LPOutValue);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd)
            => _NET_DVR_PlayBackReverseByName.Invoke(lUserID, sPlayBackFileName, hWnd);

        int IHikHCNetSdkProxy.NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond)
            => _NET_DVR_PlayBackReverseByTime_V40.Invoke(lUserID, hWnd, ref pPlayCond);

        bool IHikHCNetSdkProxy.NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName)
            => _NET_DVR_PlayBackSaveData.Invoke(lPlayHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl(int lRealHandle, uint dwPTZCommand, uint dwStop)
            => _NET_DVR_PTZControl.Invoke(lRealHandle, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => _NET_DVR_PTZControlWithSpeed.Invoke(lRealHandle, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => _NET_DVR_PTZControlWithSpeed_EX.Invoke(lRealHandle, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed)
            => _NET_DVR_PTZControlWithSpeed_Other.Invoke(lUserID, lChannel, dwPTZCommand, dwStop, dwSpeed);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop)
            => _NET_DVR_PTZControl_EX.Invoke(lRealHandle, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZControl_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop)
            => _NET_DVR_PTZControl_Other.Invoke(lUserID, lChannel, dwPTZCommand, dwStop);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => _NET_DVR_PTZCruise.Invoke(lRealHandle, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => _NET_DVR_PTZCruise_EX.Invoke(lRealHandle, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput)
            => _NET_DVR_PTZCruise_Other.Invoke(lUserID, lChannel, dwPTZCruiseCmd, byCruiseRoute, byCruisePoint, wInput);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_PTZMltTrack.Invoke(lRealHandle, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_PTZMltTrack_EX.Invoke(lRealHandle, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_PTZMltTrack_Other.Invoke(lUserID, lChannel, dwPTZTrackCmd, dwTrackIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex)
            => _NET_DVR_PTZPreset.Invoke(lRealHandle, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex)
            => _NET_DVR_PTZPreset_EX.Invoke(lRealHandle, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex)
            => _NET_DVR_PTZPreset_Other.Invoke(lUserID, lChannel, dwPTZPresetCmd, dwPresetIndex);

        bool IHikHCNetSdkProxy.NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame)
            => _NET_DVR_PTZSelZoomIn.Invoke(lRealHandle, ref pStruPointFrame);

        bool IHikHCNetSdkProxy.NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame)
            => _NET_DVR_PTZSelZoomIn_EX.Invoke(lUserID, lChannel, ref pStruPointFrame);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd)
            => _NET_DVR_PTZTrack.Invoke(lRealHandle, dwPTZTrackCmd);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd)
            => _NET_DVR_PTZTrack_EX.Invoke(lRealHandle, dwPTZTrackCmd);

        bool IHikHCNetSdkProxy.NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd)
            => _NET_DVR_PTZTrack_Other.Invoke(lUserID, lChannel, dwPTZTrackCmd);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo)
            => _NET_DVR_RealPlay.Invoke(iUserID, ref lpClientInfo);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum)
            => _NET_DVR_RealPlay_Card.Invoke(lUserID, ref lpCardInfo, lChannelNum);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, uint bBlocked)
            => _NET_DVR_RealPlay_V30.Invoke(iUserID, ref lpClientInfo, fRealDataCallBack_V30, pUser, bBlocked);

        int IHikHCNetSdkProxy.NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser)
            => _NET_DVR_RealPlay_V40.Invoke(iUserID, ref lpPreviewInfo, fRealDataCallBack_V30, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_RebootDVR(int lUserID)
            => _NET_DVR_RebootDVR.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_RefreshPlay(int lPlayHandle)
            => _NET_DVR_RefreshPlay.Invoke(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_RefreshSurface_Card()
            => _NET_DVR_RefreshSurface_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDDrawDevice()
            => _NET_DVR_ReleaseDDrawDevice.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDDraw_Card()
            => _NET_DVR_ReleaseDDraw_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseDevice_Card()
            => _NET_DVR_ReleaseDevice_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle)
        {
            if (Environment.Is64BitProcess) { return _NET_DVR_ReleaseG711Encoder(pEncodeHandle); }
            throw new NotSupportedException("未找到方法内容，不支持32位请求");
        }

        void IHikHCNetSdkProxy.NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle)
            => _NET_DVR_ReleaseG722Decoder.Invoke(pDecHandle);

        void IHikHCNetSdkProxy.NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle)
            => _NET_DVR_ReleaseG722Encoder.Invoke(pEncodeHandle);

        bool IHikHCNetSdkProxy.NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize)
            => _NET_DVR_RemoteControl0.Invoke(lUserID, dwCommand, lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize)
            => _NET_DVR_RemoteControl1.Invoke(lUserID, dwCommand, ref lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara)
            => _NET_DVR_ResetPara_Card.Invoke(lRealHandle, ref lpDisplayPara);

        bool IHikHCNetSdkProxy.NET_DVR_RestoreConfig(int lUserID)
            => _NET_DVR_RestoreConfig.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_RestoreSurface_Card()
            => _NET_DVR_RestoreSurface_Card.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser)
            => _NET_DVR_RigisterDrawFun.Invoke(lRealHandle, fDrawFun, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SaveConfig(int lUserID)
            => _NET_DVR_SaveConfig.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_SaveRealData(int lRealHandle, string sFileName)
            => _NET_DVR_SaveRealData.Invoke(lRealHandle, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName)
            => _NET_DVR_SaveRealData_V30.Invoke(lRealHandle, dwTransType, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize)
            => _NET_DVR_SendRemoteConfig.Invoke(lHandle, dwDataType, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize)
            => _NET_DVR_SendTo232Port.Invoke(lUserID, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize)
            => _NET_DVR_SendToSerialPort.Invoke(lUserID, dwSerialPort, dwSerialIndex, pSendBuf, dwBufSize);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen)
            => _NET_DVR_SendWithRecvRemoteConfig0.Invoke(lHandle, lpInBuff, dwInBuffSize, lpOutBuff, dwOutBuffSize, ref dwOutDataLen);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen)
            => _NET_DVR_SendWithRecvRemoteConfig1.Invoke(lHandle, ref lpInBuff, dwInBuffSize, ref lpOutBuff, dwOutBuffSize, dwOutDataLen);

        int IHikHCNetSdkProxy.NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen)
            => _NET_DVR_SendWithRecvRemoteConfig2.Invoke(lHandle, ref lpInBuff, dwInBuffSize, ref lpOutBuff, dwOutBuffSize, dwOutDataLen);

        bool IHikHCNetSdkProxy.NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize)
            => _NET_DVR_SerialSend.Invoke(lSerialHandle, lChannel, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser)
            => _NET_DVR_SerialStart.Invoke(lUserID, lSerialPort, fSerialDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SerialStop(int lSerialHandle)
            => _NET_DVR_SerialStop.Invoke(lSerialHandle);

        bool IHikHCNetSdkProxy.NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser)
            => _NET_DVR_SetAlarmDeviceUser.Invoke(lUserID, lUserIndex, ref lpDeviceUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic)
            => _NET_DVR_SetAlarmOut.Invoke(lUserID, lAlarmOutPort, lAlarmOutStatic);

        bool IHikHCNetSdkProxy.NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort)
            => _NET_DVR_SetATMPortCFG.Invoke(lUserID, wATMPort);

        bool IHikHCNetSdkProxy.NET_DVR_SetAudioMode(uint dwMode)
            => _NET_DVR_SetAudioMode.Invoke(dwMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue)
            => _NET_DVR_SetBehaviorParamKey.Invoke(lUserID, lChannel, dwParameterKey, nValue);

        bool IHikHCNetSdkProxy.NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_SetCCDCfg.Invoke(lUserID, lChannel, ref lpCCDCfg);

        bool IHikHCNetSdkProxy.NET_DVR_SetConfigFile(int lUserID, string sFileName)
            => _NET_DVR_SetConfigFile.Invoke(lUserID, sFileName);

        bool IHikHCNetSdkProxy.NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize)
            => _NET_DVR_SetConfigFile_EX.Invoke(lUserID, sInBuffer, dwInSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes)
            => _NET_DVR_SetConnectTime.Invoke(dwWaitTime, dwTryTimes);

        bool IHikHCNetSdkProxy.NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum)
            => _NET_DVR_SetDDrawDevice.Invoke(lPlayPort, nDeviceNum);

        bool IHikHCNetSdkProxy.NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo)
            => _NET_DVR_SetDecInfo.Invoke(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort)
            => _NET_DVR_SetDecTransPort.Invoke(lUserID, ref lpTransPort);

        bool IHikHCNetSdkProxy.NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize)
            => _NET_DVR_SetDeviceConfig.Invoke(lUserID, dwCommand, dwCount, lpInBuffer, dwInBufferSize, lpStatusList, lpInParamBuffer, dwInParamBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetDeviceConfigEx(int lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam)
            => _NET_DVR_SetDeviceConfigEx.Invoke(lUserID, dwCommand, dwCount, ref lpInParam, ref lpOutParam);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize)
            => _NET_DVR_SetDVRConfig.Invoke(lUserID, dwCommand, lChannel, lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd)
            => _NET_DVR_SetDVRMessage.Invoke(nMessage, hWnd);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser)
            => _NET_DVR_SetDVRMessageCallBack.Invoke(fMessageCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser)
            => _NET_DVR_SetDVRMessageCallBack_V30.Invoke(fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser)
            => _NET_DVR_SetDVRMessageCallBack_V31.Invoke(fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser)
            => _NET_DVR_SetDVRMessageCallBack_V50.Invoke(iIndex, fMessageCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack)
            => _NET_DVR_SetDVRMessCallBack.Invoke(fMessCallBack);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX)
            => _NET_DVR_SetDVRMessCallBack_EX.Invoke(fMessCallBack_EX);

        bool IHikHCNetSdkProxy.NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW)
            => _NET_DVR_SetDVRMessCallBack_NEW.Invoke(fMessCallBack_NEW);

        bool IHikHCNetSdkProxy.NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser)
            => _NET_DVR_SetExceptionCallBack_V30.Invoke(nMessage, hWnd, fExceptionCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode) => throw new NotImplementedException("未找到方法内容");
        // => _NET_DVR_SetLFTrackMode.Invoke(lUserID, lChannel, ref lpTrackMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel)
            => _NET_DVR_SetLogToFile.Invoke(nLogLevel, strLogDir, bAutoDel);

        bool IHikHCNetSdkProxy.NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel)
            => _NET_DVR_SetNetworkEnvironment.Invoke(dwEnvironmentLevel);

        bool IHikHCNetSdkProxy.NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser)
            => _NET_DVR_SetPlayDataCallBack.Invoke(lPlayHandle, fPlayDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetPlayerBufNumber(int lRealHandle, uint dwBufNum)
            => _NET_DVR_SetPlayerBufNumber.Invoke(lRealHandle, dwBufNum);

        bool IHikHCNetSdkProxy.NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser)
            => _NET_DVR_SetRealDataCallBack.Invoke(lRealHandle, fRealDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon)
            => _NET_DVR_SetReconnect.Invoke(dwInterval, bEnableRecon);

        bool IHikHCNetSdkProxy.NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize)
            => _NET_DVR_SetRtspConfig.Invoke(lUserID, dwCommand, ref lpInBuffer, dwInBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_SetScaleCFG(int lUserID, uint dwScale)
            => _NET_DVR_SetScaleCFG.Invoke(lUserID, dwScale);

        bool IHikHCNetSdkProxy.NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg)
            => _NET_DVR_SetScaleCFG_V30.Invoke(lUserID, ref pScalecfg);

        bool IHikHCNetSdkProxy.NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff)
            => _NET_DVR_SetSDKLocalCfg.Invoke(enumType, lpInBuff);

        bool IHikHCNetSdkProxy.NET_DVR_SetShowMode(uint dwShowType, uint colorKey)
            => _NET_DVR_SetShowMode.Invoke(dwShowType, colorKey);

        bool IHikHCNetSdkProxy.NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser)
            => _NET_DVR_SetStandardDataCallBack.Invoke(lRealHandle, fStdDataCallBack, dwUser);

        bool IHikHCNetSdkProxy.NET_DVR_SetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam)
            => _NET_DVR_SetSTDConfig.Invoke(iUserID, dwCommand, ref lpConfigParam);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan(int lUserID)
            => _NET_DVR_SetupAlarmChan.Invoke(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan_V30(int lUserID)
            => _NET_DVR_SetupAlarmChan_V30.Invoke(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam)
            => _NET_DVR_SetupAlarmChan_V41.Invoke(lUserID, ref lpSetupParam);

        bool IHikHCNetSdkProxy.NET_DVR_SetValidIP(uint dwIPIndex, bool bEnableBind)
            => _NET_DVR_SetValidIP.Invoke(dwIPIndex, bEnableBind);

        bool IHikHCNetSdkProxy.NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode)
            => _NET_DVR_SetVCADrawMode.Invoke(lUserID, lChannel, ref lpDrawMode);

        bool IHikHCNetSdkProxy.NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue)
            => _NET_DVR_SetVideoEffect.Invoke(lUserID, lChannel, dwBrightValue, dwContrastValue, dwSaturationValue, dwHueValue);

        bool IHikHCNetSdkProxy.NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume)
            => _NET_DVR_SetVoiceComClientVolume.Invoke(lVoiceComHandle, wVolume);

        bool IHikHCNetSdkProxy.NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume)
            => _NET_DVR_SetVolume_Card.Invoke(lRealHandle, wVolume);

        bool IHikHCNetSdkProxy.NET_DVR_ShutDownDVR(int lUserID)
            => _NET_DVR_ShutDownDVR.Invoke(lUserID);

        bool IHikHCNetSdkProxy.NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo)
            => _NET_DVR_StartDecode.Invoke(lUserID, lChannel, ref lpDecoderinfo);

        bool IHikHCNetSdkProxy.NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo)
            => _NET_DVR_StartDecSpecialCon.Invoke(lUserID, lChannel, ref lpDecChanInfo);

        bool IHikHCNetSdkProxy.NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType)
            => _NET_DVR_StartDVRRecord.Invoke(lUserID, lChannel, lRecordType);

        bool IHikHCNetSdkProxy.NET_DVR_StartListen(string sLocalIP, ushort wLocalPort)
            => _NET_DVR_StartListen.Invoke(sLocalIP, wLocalPort);

        int IHikHCNetSdkProxy.NET_DVR_StartListen_V30(string sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData)
            => _NET_DVR_StartListen_V30.Invoke(sLocalIP, wLocalPort, DataCallback, pUserData);

        int IHikHCNetSdkProxy.NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData)
            => _NET_DVR_StartRemoteConfig.Invoke(lUserID, dwCommand, lpInBuffer, dwInBufferLen, cbStateCallback, pUserData);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser)
            => _NET_DVR_StartVoiceCom.Invoke(lUserID, fVoiceDataCallBack, dwUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser)
            => _NET_DVR_StartVoiceCom_MR.Invoke(lUserID, fVoiceDataCallBack, dwUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser)
            => _NET_DVR_StartVoiceCom_MR_V30.Invoke(lUserID, dwVoiceChan, fVoiceDataCallBack, pUser);

        int IHikHCNetSdkProxy.NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser)
            => _NET_DVR_StartVoiceCom_V30.Invoke(lUserID, dwVoiceChan, bNeedCBNoEncData, fVoiceDataCallBack, pUser);

        bool IHikHCNetSdkProxy.NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam)
            => _NET_DVR_STDXMLConfig0.Invoke(lUserID, lpInputParam, lpOutputParam);

        bool IHikHCNetSdkProxy.NET_DVR_STDXMLConfig(int iUserID, ref NET_DVR_XML_CONFIG_INPUT lpInputParam, ref NET_DVR_XML_CONFIG_OUTPUT lpOutputParam)
            => _NET_DVR_STDXMLConfig1.Invoke(iUserID, ref lpInputParam, ref lpOutputParam);

        bool IHikHCNetSdkProxy.NET_DVR_StopDecode(int lUserID, int lChannel)
            => _NET_DVR_StopDecode.Invoke(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo)
            => _NET_DVR_StopDecSpecialCon.Invoke(lUserID, lChannel, ref lpDecChanInfo);

        bool IHikHCNetSdkProxy.NET_DVR_StopDVRRecord(int lUserID, int lChannel)
            => _NET_DVR_StopDVRRecord.Invoke(lUserID, lChannel);

        bool IHikHCNetSdkProxy.NET_DVR_StopGetFile(int lFileHandle)
            => _NET_DVR_StopGetFile.Invoke(lFileHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopListen()
            => _NET_DVR_StopListen.Invoke();

        bool IHikHCNetSdkProxy.NET_DVR_StopListen_V30(int lListenHandle)
            => _NET_DVR_StopListen_V30.Invoke(lListenHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopPlayBack(int lPlayHandle)
            => _NET_DVR_StopPlayBack.Invoke(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopPlayBackSave(int lPlayHandle)
            => _NET_DVR_StopPlayBackSave.Invoke(lPlayHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopRealPlay(int iRealHandle)
            => _NET_DVR_StopRealPlay.Invoke(iRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopRemoteConfig(int lHandle)
            => _NET_DVR_StopRemoteConfig.Invoke(lHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopSaveRealData(int lRealHandle)
            => _NET_DVR_StopSaveRealData.Invoke(lRealHandle);

        bool IHikHCNetSdkProxy.NET_DVR_StopVoiceCom(int lVoiceComHandle)
            => _NET_DVR_StopVoiceCom.Invoke(lVoiceComHandle);

        bool IHikHCNetSdkProxy.NET_DVR_ThrowBFrame(int lRealHandle, uint dwNum)
            => _NET_DVR_ThrowBFrame.Invoke(lRealHandle, dwNum);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ(int lRealHandle, string pPTZCodeBuf, uint dwBufSize)
            => _NET_DVR_TransPTZ.Invoke(lRealHandle, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize)
            => _NET_DVR_TransPTZ_EX.Invoke(lRealHandle, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize)
            => _NET_DVR_TransPTZ_Other.Invoke(lUserID, lChannel, pPTZCodeBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName)
            => _NET_DVR_UnlockFileByName.Invoke(lUserID, sUnlockFileName);

        bool IHikHCNetSdkProxy.NET_DVR_UnLockPanel(int lUserID)
            => _NET_DVR_UnLockPanel.Invoke(lUserID);

        int IHikHCNetSdkProxy.NET_DVR_Upgrade(int lUserID, string sFileName)
            => _NET_DVR_Upgrade.Invoke(lUserID, sFileName);

        int IHikHCNetSdkProxy.NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, int dwInBufferLen)
            => _NET_DVR_Upgrade_V40.Invoke(lUserID, dwUpgradeType, sFileName, pInbuffer, dwInBufferLen);

        bool IHikHCNetSdkProxy.NET_DVR_UploadClose(int lUploadHandle)
            => _NET_DVR_UploadClose.Invoke(lUploadHandle);

        int IHikHCNetSdkProxy.NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize)
            => _NET_DVR_UploadFile_V40.Invoke(lUserID, dwUploadType, lpInBuffer, dwInBufferSize, sFileName, lpOutBuffer, dwOutBufferSize);

        bool IHikHCNetSdkProxy.NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, IntPtr sLogoBuffer)
            => _NET_DVR_UploadLogo.Invoke(lUserID, dwDispChanNum, ref lpDispLogoCfg, sLogoBuffer);

        int IHikHCNetSdkProxy.NET_DVR_UploadSend(int lUploadHandle, ref NET_DVR_SEND_PARAM_IN pstruSendParamIN, IntPtr lpOutBuffer)
            => _NET_DVR_UploadSend.Invoke(lUploadHandle, ref pstruSendParamIN, lpOutBuffer);

        bool IHikHCNetSdkProxy.NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize)
            => _NET_DVR_VoiceComSendData.Invoke(lVoiceComHandle, pSendBuf, dwBufSize);

        bool IHikHCNetSdkProxy.NET_DVR_Volume(int lRealHandle, ushort wVolume)
            => _NET_DVR_Volume.Invoke(lRealHandle, wVolume);

        int IHikHCNetSdkProxy.NET_SDK_RealPlay(int iUserLogID, ref NET_DVR_CLIENTINFO lpDVRClientInfo) => throw new NotImplementedException("未找到方法内容");
        // => _NET_SDK_RealPlay.Invoke(iUserLogID, ref lpDVRClientInfo);

        bool IHikHCNetSdkProxy.NET_VCA_RestartLib(int lUserID, int lChannel)
            => _NET_VCA_RestartLib.Invoke(lUserID, lChannel);

        int IHikHCNetSdkProxy.PostMessage(IntPtr hWnd, int Msg, long wParam, long lParam)
            => PostMessage(hWnd, Msg, wParam, lParam);
        #endregion 显示实现
    }
}
