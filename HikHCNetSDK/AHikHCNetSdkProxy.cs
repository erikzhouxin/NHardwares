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
}
