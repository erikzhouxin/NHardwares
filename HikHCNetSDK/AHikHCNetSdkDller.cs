using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    internal class HikHCNetSdkDllerX64 : IHikHCNetSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IHikHCNetSdkProxy Instance { get; } = new HikHCNetSdkDllerX64();
        private HikHCNetSdkDllerX64() { }
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);

        /// <summary>
        /// remote control gateway
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lGatewayIndex">1-begin 0xffffffff-all</param>
        /// <param name="dwStaic">0-close，1-open，2-always open，3-always close</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);

        /// <summary>
        /// Alarm information registered callback function
        /// </summary>
        /// <param name="iIndex">iIndex, scope:[0,15] </param>
        /// <param name="fMessageCallBack">callback function</param>
        /// <param name="pUser">user data</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);

        /*********************************************************
        Function:	NET_DVR_Init
        Desc:		初始化SDK，调用其他SDK函数的前提。
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败。
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_Init();

        /*********************************************************
        Function:	NET_DVR_Cleanup
        Desc:		释放SDK资源，在结束之前最后调用
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_Cleanup();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref Boolean pEnableBind);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetValidIP(uint dwIPIndex, Boolean bEnableBind);
        /// <summary>
        /// Get to the SDK version information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern uint NET_DVR_GetSDKVersion();
        /// <summary>
        /// Get version number of the SDK and build information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern uint NET_DVR_GetSDKBuildVersion();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_IsSupport();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopListen();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartListen_V30(String sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopListen_V30(Int32 lListenHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_Logout(int iUserID);
        /// <summary>
        /// 获取最后一次错误
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern uint NET_DVR_GetLastError();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="pErrorNo"></param>
        /// <returns>Returns the last error code information of the operation</returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort);
        /// <summary>
        /// 预览相关接口
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpClientInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);

        /// <summary>
        /// 实时预览扩展接口
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpPreviewInfo">预览参数</param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">用户数据</param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        //[DllImport(HikHCNetSdk.DllFileNameX64)]
        //public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        /// <summary>
        /// 停止预览
        /// </summary>
        /// <param name="iRealHandle">预览句柄，NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ThrowBFrame(Int32 lRealHandle, uint dwNum);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetAudioMode(uint dwMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_OpenSound(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseSound();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_OpenSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_Volume(Int32 lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SaveRealData(Int32 lRealHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopSaveRealData(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CapturePictureBlock(Int32 lRealHandle, string sPicFileName, int dwTimeOut);

        /// <summary>
        /// 动态生成I帧
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MakeKeyFrame(Int32 lUserID, Int32 lChannel);//主码流

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MakeKeyFrameSub(Int32 lUserID, Int32 lChannel);//子码流

        /// <summary>
        /// 云台控制相关接口
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPTZCtrl(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPTZCtrl_Other(Int32 lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControl_Other(Int32 lUserID, Int32 lChannel, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_TransPTZ(Int32 lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_FindClose(int lFindHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_FindClose_V30(int lFindHandle);

        /// <summary>
        /// 增加查询结果带卡号的文件查找
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, System.IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopPlayBack(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopPlayBackSave(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopGetFile(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetDownloadPos(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetPlayBackPos(int lPlayHandle);

        /// <summary>
        /// 图片查找
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindParam"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseFindPicture(int lFindHandle);
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPicture(int lUserID, String sDVRFileName, String sSavedFileName);

        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_Upgrade(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, Int32 dwInBufferLen);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetUpgradeState(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);

        /// <summary>
        /// 远程格式化硬盘
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lDiskNumber"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseFormatHandle(int lFormatHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList);
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList);

        /// <summary>
        /// 报警
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SetupAlarmChan(int lUserID);
        /// <summary>
        /// shut down alarm upload channel, to obtain the information such as alarm
        /// </summary>
        /// <param name="lAlarmHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseAlarmChan(int lAlarmHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SetupAlarmChan_V30(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);

        /// <summary>
        /// 语音对讲
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        /// <summary>
        /// 语音转发
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 语音广播
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientAudioStart();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);


        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientAudioStop();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_AddDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DelDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DelDVR_V30(int lVoiceHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);

        /// <summary>
        /// 485作为透明通道时，需要指明通道号，因为不同通道号485的设置可以不同(比如波特率)
        /// </summary>
        /// <param name="lSerialHandle"></param>
        /// <param name="lChannel"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SerialStop(int lSerialHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 解码 nBitrate = 16000
        /// </summary>
        /// <param name="nBitrate"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern System.IntPtr NET_DVR_InitG722Decoder(int nBitrate);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern IntPtr NET_DVR_InitG722Encoder();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        /// <summary>
        /// 远程控制本地显示
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lKeyIndex"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        /// <summary>
        /// 远程控制设备端手动录像
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lRecordType"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);

        /// <summary>
        /// 解码卡
        /// </summary>
        /// <param name="pDeviceTotalChan"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ReleaseDevice_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ReleaseDDraw_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RefreshSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClearSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RestoreSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_OpenSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetCardLastError_Card();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern System.IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);

        /// <summary>
        /// 获取解码卡序列号此接口无效，改用GetBoardDetail接口获得(2005-12-08支持)
        /// </summary>
        /// <param name="lChannelNum"></param>
        /// <param name="pDeviceSerialNo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_FindLogClose(int lLogHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);

        /// <summary>
        /// 人脸识别上传文件发送数据
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="pstruSendParamIN"></param>
        /// <param name="lpOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress);

        /// <summary>
        /// 获取当前上传的结果信息。
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_UploadClose(int lUploadHandle);

        /// <summary>
        /// 704-640 缩放配置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwScale"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        /// <summary>
        /// ATM机端口设置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="wATMPort"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);

        /// <summary>
        /// 支持显卡辅助输出
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_InitDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ReleaseDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetDDrawDeviceTotalNums();

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);

        /// <summary>
        /// 解码设备DS-6001D/DS-6001F
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopDecode(int lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        /// <summary>
        /// 多路解码器V211支持以下接口 //11
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);

        /// <summary>
        /// 增加支持接口 //18
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSendData(int lPassiveHandle, System.IntPtr pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, System.IntPtr sLogoBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_PicUpload(int lUserID, String sFileName, ref NET_DVR_PICTURECFG lpPictureCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetPicUploadProgress(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_CloseUploadHandle(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_GetPicUploadState(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RefreshPlay(int lPlayHandle);

        /// <summary>
        /// 恢复默认值
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RestoreConfig(int lUserID);

        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SaveConfig(int lUserID);

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RebootDVR(int lUserID);

        /// <summary>
        /// 关闭DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);

        /// <summary>
        /// Alarm host device user configuration function(following two:get and set)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lUserIndex">index of user</param>
        /// <param name="lpDeviceUser">lookup NET_DVR_ALARM_DEVICE_USER definition</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        /// <summary>
        /// 获取UPNP端口映射状态
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpState"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);

        /// <summary>
        /// 启用日志文件写入接口
        /// </summary>
        /// <param name="nLogLevel">(default 0) - log level, 0:close, 1:ERROR, 2:ERROR and DEBUG, 3-ALL</param>
        /// <param name="strLogDir">file directory to save, default:"C:\\SdkLog\\"(win)and "/home/sdklog/"(linux)</param>
        /// <param name="bAutoDel">whether to delete log file by auto, TRUE is default</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);

        /// <summary>
        /// 前面板锁定
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_LockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_UnLockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// 视频综合平台
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSceneNum"></param>
        /// <param name="lpSceneCfg"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpHeight);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpLength);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);

        /// <summary>
        /// Win32位定义
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_EncodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern IntPtr NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        //邮件服务测试 9000_1.1
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_EmailTest(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// <summary>
        /// login
        /// </summary>
        /// <param name="pLoginInfo">login parameters</param>
        /// <param name="lpDeviceInfo">device informations</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        /// <summary>
        /// 用户注册设备
        /// </summary>
        /// <param name="lUserID">用户ID号</param>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);


        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetDeviceConfigEx(Int32 lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);
        // public static extern int NET_DVR_StartRemoteConfig(int lUserID, uint dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        /// <summary>
        /// get long connection configuration status
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="pState">the return status pointer</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);
        /// <summary>
        /// obtain the result of the information one by one
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="lpOutBuff">a pointer to a buffer to receive data(user manual for more details)</param>
        /// <param name="dwOutBuffSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize);
        // public static extern bool NET_DVR_SendRemoteConfig(int lHandle, uint dwDataType, IntPtr pSendBuf, uint dwBufSize);
        /// <summary>
        /// stop a long connection
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize);
        //public static extern bool NET_DVR_RemoteControl(int lUserID, uint dwCommand, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_ContinuousShoot(Int32 lUserID, ref NET_DVR_SNAPCFG lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        /// <summary>
        /// 设置/获取参数关键字
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwParameterKey"></param>
        /// <param name="nValue"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);

        /// <summary>
        /// 获取/设置行为分析目标叠加接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDrawMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        /// <summary>
        /// 双摄像机跟踪模式设置接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpTrackMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);

        [DllImport(HikHCNetSdk.DllFileNameX64)]
        public static extern bool NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn);
        /// <summary>
        /// 重启智能库
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX64)]
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
    internal class HikHCNetSdkDllerX86 : IHikHCNetSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IHikHCNetSdkProxy Instance { get; } = new HikHCNetSdkDllerX86();
        private HikHCNetSdkDllerX86() { }
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);

        /// <summary>
        /// remote control gateway
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lGatewayIndex">1-begin 0xffffffff-all</param>
        /// <param name="dwStaic">0-close，1-open，2-always open，3-always close</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);

        /// <summary>
        /// Alarm information registered callback function
        /// </summary>
        /// <param name="iIndex">iIndex, scope:[0,15] </param>
        /// <param name="fMessageCallBack">callback function</param>
        /// <param name="pUser">user data</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);

        /*********************************************************
        Function:	NET_DVR_Init
        Desc:		初始化SDK，调用其他SDK函数的前提。
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败。
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_Init();

        /*********************************************************
        Function:	NET_DVR_Cleanup
        Desc:		释放SDK资源，在结束之前最后调用
        Input:	
        Output:	
        Return:	TRUE表示成功，FALSE表示失败
        **********************************************************/
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_Cleanup();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref Boolean pEnableBind);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetValidIP(uint dwIPIndex, Boolean bEnableBind);
        /// <summary>
        /// Get to the SDK version information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern uint NET_DVR_GetSDKVersion();
        /// <summary>
        /// Get version number of the SDK and build information
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern uint NET_DVR_GetSDKBuildVersion();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_IsSupport();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopListen();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartListen_V30(String sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopListen_V30(Int32 lListenHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_Logout(int iUserID);
        /// <summary>
        /// 获取最后一次错误
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern uint NET_DVR_GetLastError();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="pErrorNo"></param>
        /// <returns>Returns the last error code information of the operation</returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort);
        /// <summary>
        /// 预览相关接口
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="lpClientInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);

        /// <summary>
        /// 实时预览扩展接口
        /// </summary>
        /// <param name="iUserID">NET_DVR_Login()或NET_DVR_Login_V30()的返回值 </param>
        /// <param name="lpPreviewInfo">预览参数</param>
        /// <param name="fRealDataCallBack_V30">码流数据回调函数</param>
        /// <param name="pUser">用户数据</param>
        /// <returns>1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        //[DllImport(HikHCNetSdk.DllFileNameX86)]
        //public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        /// <summary>
        /// 停止预览
        /// </summary>
        /// <param name="iRealHandle">预览句柄，NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ThrowBFrame(Int32 lRealHandle, uint dwNum);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetAudioMode(uint dwMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_OpenSound(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseSound();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_OpenSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseSoundShare(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_Volume(Int32 lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SaveRealData(Int32 lRealHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopSaveRealData(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CapturePictureBlock(Int32 lRealHandle, string sPicFileName, int dwTimeOut);

        /// <summary>
        /// 动态生成I帧
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MakeKeyFrame(Int32 lUserID, Int32 lChannel);//主码流

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MakeKeyFrameSub(Int32 lUserID, Int32 lChannel);//子码流

        /// <summary>
        /// 云台控制相关接口
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPTZCtrl(Int32 lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPTZCtrl_Other(Int32 lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControl_Other(Int32 lUserID, Int32 lChannel, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_TransPTZ(Int32 lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_FindClose(int lFindHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_FindClose_V30(int lFindHandle);

        /// <summary>
        /// 增加查询结果带卡号的文件查找
        /// </summary>
        /// <param name="lFindHandle"></param>
        /// <param name="lpFindData"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, System.IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopPlayBack(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopPlayBackSave(int lPlayHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopGetFile(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetDownloadPos(int lFileHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetPlayBackPos(int lPlayHandle);

        /// <summary>
        /// 图片查找
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="pFindParam"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseFindPicture(int lFindHandle);
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPicture(int lUserID, String sDVRFileName, String sSavedFileName);

        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_Upgrade(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, Int32 dwInBufferLen);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetUpgradeState(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);

        /// <summary>
        /// 远程格式化硬盘
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lDiskNumber"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseFormatHandle(int lFormatHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList);
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList);

        /// <summary>
        /// 报警
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SetupAlarmChan(int lUserID);
        /// <summary>
        /// shut down alarm upload channel, to obtain the information such as alarm
        /// </summary>
        /// <param name="lAlarmHandle"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseAlarmChan(int lAlarmHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SetupAlarmChan_V30(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);

        /// <summary>
        /// 语音对讲
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        /// <summary>
        /// 语音转发
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="fVoiceDataCallBack"></param>
        /// <param name="dwUser"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 语音广播
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientAudioStart();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);


        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientAudioStop();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_AddDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DelDVR(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DelDVR_V30(int lVoiceHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);

        /// <summary>
        /// 485作为透明通道时，需要指明通道号，因为不同通道号485的设置可以不同(比如波特率)
        /// </summary>
        /// <param name="lSerialHandle"></param>
        /// <param name="lChannel"></param>
        /// <param name="pSendBuf"></param>
        /// <param name="dwBufSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SerialStop(int lSerialHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);

        /// <summary>
        /// 解码 nBitrate = 16000
        /// </summary>
        /// <param name="nBitrate"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern System.IntPtr NET_DVR_InitG722Decoder(int nBitrate);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern IntPtr NET_DVR_InitG722Encoder();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        /// <summary>
        /// 远程控制本地显示
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lKeyIndex"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        /// <summary>
        /// 远程控制设备端手动录像
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lRecordType"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);

        /// <summary>
        /// 解码卡
        /// </summary>
        /// <param name="pDeviceTotalChan"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ReleaseDevice_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ReleaseDDraw_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RefreshSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClearSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RestoreSurface_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_OpenSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseSound_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetCardLastError_Card();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern System.IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);

        /// <summary>
        /// 获取解码卡序列号此接口无效，改用GetBoardDetail接口获得(2005-12-08支持)
        /// </summary>
        /// <param name="lChannelNum"></param>
        /// <param name="pDeviceSerialNo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_FindLogClose(int lLogHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);

        /// <summary>
        /// 人脸识别上传文件发送数据
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="pstruSendParamIN"></param>
        /// <param name="lpOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress);

        /// <summary>
        /// 获取当前上传的结果信息。
        /// </summary>
        /// <param name="lUploadHandle"></param>
        /// <param name="lpOutBuffer"></param>
        /// <param name="dwOutBufferSize"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_UploadClose(int lUploadHandle);

        /// <summary>
        /// 704-640 缩放配置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwScale"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        /// <summary>
        /// ATM机端口设置
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="wATMPort"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);

        /// <summary>
        /// 支持显卡辅助输出
        /// </summary>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_InitDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ReleaseDDrawDevice();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetDDrawDeviceTotalNums();

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);

        /// <summary>
        /// 解码设备DS-6001D/DS-6001F
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDecoderinfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopDecode(int lUserID, int lChannel);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        /// <summary>
        /// 多路解码器V211支持以下接口 //11
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwDecChanNum"></param>
        /// <param name="lpDynamicInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);

        /// <summary>
        /// 增加支持接口 //18
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpTranInfo"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSendData(int lPassiveHandle, System.IntPtr pSendBuf, uint dwBufSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, System.IntPtr sLogoBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_PicUpload(int lUserID, String sFileName, ref NET_DVR_PICTURECFG lpPictureCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetPicUploadProgress(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_CloseUploadHandle(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_GetPicUploadState(int lUploadHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RefreshPlay(int lPlayHandle);

        /// <summary>
        /// 恢复默认值
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RestoreConfig(int lUserID);

        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SaveConfig(int lUserID);

        /// <summary>
        /// 重启
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RebootDVR(int lUserID);

        /// <summary>
        /// 关闭DVR
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);

        /// <summary>
        /// Alarm host device user configuration function(following two:get and set)
        /// </summary>
        /// <param name="lUserID">NET_DVR_Login_V40 return value</param>
        /// <param name="lUserIndex">index of user</param>
        /// <param name="lpDeviceUser">lookup NET_DVR_ALARM_DEVICE_USER definition</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        /// <summary>
        /// 获取UPNP端口映射状态
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lpState"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetConfigFile(int lUserID, string sFileName);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);

        /// <summary>
        /// 启用日志文件写入接口
        /// </summary>
        /// <param name="nLogLevel">(default 0) - log level, 0:close, 1:ERROR, 2:ERROR and DEBUG, 3-ALL</param>
        /// <param name="strLogDir">file directory to save, default:"C:\\SdkLog\\"(win)and "/home/sdklog/"(linux)</param>
        /// <param name="bAutoDel">whether to delete log file by auto, TRUE is default</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);

        /// <summary>
        /// 前面板锁定
        /// </summary>
        /// <param name="lUserID"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_LockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_UnLockPanel(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);

        /// <summary>
        /// 视频综合平台
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="dwSceneNum"></param>
        /// <param name="lpSceneCfg"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpHeight);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref Single lpLength);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);

        /// <summary>
        /// Win32位定义
        /// </summary>
        /// <param name="iType"></param>
        /// <param name="pInBuffer"></param>
        /// <param name="pOutBuffer"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_EncodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern IntPtr NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        //邮件服务测试 9000_1.1
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_EmailTest(int lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// <summary>
        /// login
        /// </summary>
        /// <param name="pLoginInfo">login parameters</param>
        /// <param name="lpDeviceInfo">device informations</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        /// <summary>
        /// 用户注册设备
        /// </summary>
        /// <param name="lUserID">用户ID号</param>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);


        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetDeviceConfigEx(Int32 lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);
        // public static extern int NET_DVR_StartRemoteConfig(int lUserID, uint dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        /// <summary>
        /// get long connection configuration status
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="pState">the return status pointer</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);
        /// <summary>
        /// obtain the result of the information one by one
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <param name="lpOutBuff">a pointer to a buffer to receive data(user manual for more details)</param>
        /// <param name="dwOutBuffSize">the receive data buffer size, unit:byte</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize);
        // public static extern bool NET_DVR_SendRemoteConfig(int lHandle, uint dwDataType, IntPtr pSendBuf, uint dwBufSize);
        /// <summary>
        /// stop a long connection
        /// </summary>
        /// <param name="lHandle">handle ,NET_DVR_StartRemoteConfig return value</param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize);
        //public static extern bool NET_DVR_RemoteControl(int lUserID, uint dwCommand, IntPtr lpInBuffer, uint dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_ContinuousShoot(Int32 lUserID, ref NET_DVR_SNAPCFG lpInter);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        /// <summary>
        /// 设置/获取参数关键字
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="dwParameterKey"></param>
        /// <param name="nValue"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);

        /// <summary>
        /// 获取/设置行为分析目标叠加接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpDrawMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        /// <summary>
        /// 双摄像机跟踪模式设置接口
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <param name="lpTrackMode"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);

        [DllImport(HikHCNetSdk.DllFileNameX86)]
        public static extern bool NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn);
        /// <summary>
        /// 重启智能库
        /// </summary>
        /// <param name="lUserID"></param>
        /// <param name="lChannel"></param>
        /// <returns></returns>
        [DllImport(HikHCNetSdk.DllFileNameX86)]
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
}
