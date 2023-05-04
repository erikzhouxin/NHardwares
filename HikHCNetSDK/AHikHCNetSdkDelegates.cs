using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lUserID"></param>
    /// <param name="dwResult"></param>
    /// <param name="lpDeviceInfo"></param>
    /// <param name="pUser"></param>
    public delegate void LOGINRESULTCALLBACK(int lUserID, int dwResult, IntPtr lpDeviceInfo, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dwType"></param>
    /// <param name="lUserID"></param>
    /// <param name="lHandle"></param>
    /// <param name="pUser"></param>
    public delegate void EXCEPYIONCALLBACK(uint dwType, int lUserID, int lHandle, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lCommand"></param>
    /// <param name="sDVRIP"></param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufLen"></param>
    /// <returns></returns>
    public delegate int MESSCALLBACK(int lCommand, string sDVRIP, string pBuf, uint dwBufLen);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="iCommand"></param>
    /// <param name="iUserID"></param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufLen"></param>
    /// <returns></returns>
    public delegate int MESSCALLBACKEX(int iCommand, int iUserID, string pBuf, uint dwBufLen);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lCommand"></param>
    /// <param name="sDVRIP"></param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufLen"></param>
    /// <param name="dwLinkDVRPort"></param>
    /// <returns></returns>
    public delegate int MESSCALLBACKNEW(int lCommand, string sDVRIP, string pBuf, uint dwBufLen, ushort dwLinkDVRPort);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lCommand"></param>
    /// <param name="sDVRIP"></param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufLen"></param>
    /// <param name="dwUser"></param>
    /// <returns></returns>
    public delegate int MESSAGECALLBACK(int lCommand, IntPtr sDVRIP, IntPtr pBuf, uint dwBufLen, uint dwUser);
    /// <summary>
    /// Alarm information callback function
    /// </summary>
    /// <param name="lCommand">message type upload(user manual for more details) entrance guard device : COMM_ALARM_ACS</param>
    /// <param name="pAlarmer">information of alarm device</param>
    /// <param name="pAlarmInfo">alarm information (NET_DVR_ACS_ALARM_INFO)</param>
    /// <param name="dwBufLen">size of pAlarmInfo</param>
    /// <param name="pUser">user data</param>
    public delegate void MSGCallBack(int lCommand, ref NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lCommand"></param>
    /// <param name="pAlarmer"></param>
    /// <param name="pAlarmInfo"></param>
    /// <param name="dwBufLen"></param>
    /// <param name="pUser"></param>
    /// <returns></returns>
    public delegate bool MSGCallBack_V31(int lCommand, ref NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);
    /// <summary>
    /// 预览回调
    /// </summary>
    /// <param name="lRealHandle">当前的预览句柄</param>
    /// <param name="dwDataType">数据类型</param>
    /// <param name="pBuffer">存放数据的缓冲区指针</param>
    /// <param name="dwBufSize">缓冲区大小</param>
    /// <param name="pUser">用户数据</param>
    public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser);
    // public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser);
    // public delegate void RealDataCallBack(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lRealHandle"></param>
    /// <param name="hDc"></param>
    /// <param name="dwUser"></param>
    public delegate void DRAWFUN(int lRealHandle, IntPtr hDc, uint dwUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lRealHandle"></param>
    /// <param name="dwDataType"></param>
    /// <param name="pBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void SETREALDATACALLBACK(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, uint dwUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lRealHandle"></param>
    /// <param name="dwDataType"></param>
    /// <param name="pBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void STDDATACALLBACK(int lRealHandle, uint dwDataType, ref byte pBuffer, uint dwBufSize, uint dwUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lPlayHandle"></param>
    /// <param name="dwDataType"></param>
    /// <param name="pBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void PLAYDATACALLBACK(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, uint dwUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lVoiceComHandle"></param>
    /// <param name="pRecvDataBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="byAudioFlag"></param>
    /// <param name="dwUser"></param>
    public delegate void VOICEDATACALLBACK(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, uint dwUser);
    /// <summary>
    /// 声音数据回调
    /// </summary>
    /// <param name="lVoiceComHandle"></param>
    /// <param name="pRecvDataBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="byAudioFlag"></param>
    /// <param name="pUser"></param>
    public delegate void VOICEDATACALLBACKV30(int lVoiceComHandle, IntPtr pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, IntPtr pUser);
    // public delegate void VOICEDATACALLBACKV30(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pRecvDataBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="pUser"></param>
    public delegate void VOICEAUDIOSTART(string pRecvDataBuffer, uint dwBufSize, IntPtr pUser);
    /// <summary>
    /// 透明通道设置 SERIALDATACALLBACK
    /// </summary>
    /// <param name="lSerialHandle"></param>
    /// <param name="pRecvDataBuffer"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void SERIALDATACALLBACK(int lSerialHandle, string pRecvDataBuffer, uint dwBufSize, uint dwUser);
    /// <summary>
    /// Long connection call back function
    /// </summary>
    /// <param name="dwType">refer enum NET_SDK_CALLBACK_TYPE</param>
    /// <param name="lpBuffer">pointer to data buffer(user manual for more details)</param>
    /// <param name="dwBufLen">the buffer size</param>
    /// <param name="pUserData">pointer to user input data</param>
    public delegate void RemoteConfigCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData);
    /// <summary>
    /// 异常回调函数
    /// </summary>
    /// <param name="hSession"></param>
    /// <param name="dwUser"></param>
    /// <param name="lErrorType"></param>
    public delegate void ErrorCallback(IntPtr hSession, uint dwUser, int lErrorType);
    /// <summary>
    /// 帧数据回调函数
    /// </summary>
    /// <param name="hStream"></param>
    /// <param name="dwUser"></param>
    /// <param name="lFrameType"></param>
    /// <param name="pBuffer"></param>
    /// <param name="dwSize"></param>
    public delegate void VodStreamFrameData(IntPtr hStream, uint dwUser, int lFrameType, IntPtr pBuffer, uint dwSize);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="iMessageType"></param>
    /// <param name="pBuf"></param>
    /// <param name="iBufLen"></param>
    /// <returns></returns>
    public delegate int CALLBACKFUN_MESSAGE(int iMessageType, IntPtr pBuf, int iBufLen);

    internal class DCreater
    {
        public delegate bool NET_DVR_AddDVR(int lUserID);

        public delegate int NET_DVR_AddDVR_V30(int lUserID, uint dwVoiceChan);

        public delegate bool NET_DVR_AudioPreview_Card(int lRealHandle, int bEnable);

        public delegate bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, string sPicFileName);

        public delegate bool NET_DVR_CaptureJPEGPicture_NEW(int lUserID, int lChannel, ref NET_DVR_JPEGPARA lpJpegPara, byte[] sJpegPicBuffer, uint dwPicSize, ref uint lpSizeReturned);

        public delegate bool NET_DVR_CapturePicture(int lRealHandle, string sPicFileName);

        public delegate bool NET_DVR_CapturePictureBlock(int lRealHandle, string sPicFileName, int dwTimeOut);

        public delegate bool NET_DVR_CapturePicture_Card(int lRealHandle, string sPicFileName);

        public delegate bool NET_DVR_Cleanup();

        public delegate bool NET_DVR_ClearSurface_Card();

        public delegate bool NET_DVR_ClickKey(int lUserID, int lKeyIndex);

        public delegate bool NET_DVR_ClientAudioStart();

        public delegate bool NET_DVR_ClientAudioStart_V30(VOICEAUDIOSTART fVoiceAudioStart, IntPtr pUser);

        public delegate bool NET_DVR_ClientAudioStop();

        public delegate bool NET_DVR_ClientGetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        public delegate bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        public delegate bool NET_DVR_ClientSetframeformat(int lUserID, ref NET_DVR_FRAMEFORMAT lpFrameFormat);

        public delegate bool NET_DVR_ClientSetVideoEffect(int lRealHandle, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        public delegate bool NET_DVR_CloseAlarmChan(int lAlarmHandle);

        public delegate bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);

        public delegate bool NET_DVR_CloseFindPicture(int lFindHandle);

        public delegate bool NET_DVR_CloseFormatHandle(int lFormatHandle);

        public delegate bool NET_DVR_CloseSound();

        public delegate bool NET_DVR_CloseSoundShare(int lRealHandle);

        public delegate bool NET_DVR_CloseSound_Card(int lRealHandle);

        public delegate bool NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        public delegate bool NET_DVR_CloseUploadHandle(int lUploadHandle);

        public delegate bool NET_DVR_ContinuousShoot(int lUserID, ref NET_DVR_SNAPCFG lpInter);

        public delegate bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);

        public delegate bool NET_DVR_DecCtrlDec(int lUserID, int lChannel, uint dwControlCode);

        public delegate bool NET_DVR_DecCtrlScreen(int lUserID, int lChannel, uint dwControl);

        public delegate bool NET_DVR_DecodeG711Frame(uint iType, ref byte pInBuffer, ref byte pOutBuffer);

        public delegate bool NET_DVR_DecodeG722Frame(IntPtr pDecHandle, ref byte pInBuffer, ref byte pOutBuffer);

        public delegate bool NET_DVR_DecPlayBackCtrl(int lUserID, int lChannel, uint dwControlCode, uint dwInValue, ref uint LPOutValue, ref NET_DVR_PLAYREMOTEFILE lpRemoteFileInfo);

        public delegate bool NET_DVR_DelDVR(int lUserID);

        public delegate bool NET_DVR_DelDVR_V30(int lVoiceHandle);

        public delegate bool NET_DVR_EmailTest(int lUserID);

        public delegate bool NET_DVR_EncodeG711Frame(IntPtr handle, ref NET_DVR_AUDIOENC_PROCESS_PARAM p_enc_proc_param);

        public delegate bool NET_DVR_EncodeG722Frame(IntPtr pEncodeHandle, ref byte pInBuffer, ref byte pOutBuffer);

        public delegate bool NET_DVR_FindClose(int lFindHandle);

        public delegate bool NET_DVR_FindClose_V30(int lFindHandle);

        public delegate int NET_DVR_FindDVRLog(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        public delegate int NET_DVR_FindDVRLog_Matrix(int iUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref tagVEDIOPLATLOG lpVedioPlatLog, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        public delegate int NET_DVR_FindDVRLog_V30(int lUserID, int lSelectMode, uint dwMajorType, uint dwMinorType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, bool bOnlySmart);

        public delegate int NET_DVR_FindFile(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        public delegate int NET_DVR_FindFileByCard(int lUserID, int lChannel, uint dwFileType, int nFindType, ref byte sCardNumber, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        public delegate int NET_DVR_FindFileByEvent(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM lpSearchEventParam);

        public delegate int NET_DVR_FindFileByEvent_V40(int lUserID, ref NET_DVR_SEARCH_EVENT_PARAM_V40 lpSearchEventParam);

        public delegate int NET_DVR_FindFile_Card(int lUserID, int lChannel, uint dwFileType, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime);

        public delegate int NET_DVR_FindFile_V30(int lUserID, ref NET_DVR_FILECOND pFindCond);

        public delegate int NET_DVR_FindFile_V40(int lUserID, ref NET_DVR_FILECOND_V40 pFindCond);

        public delegate bool NET_DVR_FindLogClose(int lLogHandle);

        public delegate bool NET_DVR_FindLogClose_V30(int lLogHandle);

        public delegate int NET_DVR_FindNextEvent(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET lpSearchEventRet);

        public delegate int NET_DVR_FindNextEvent_V40(int lSearchHandle, ref NET_DVR_SEARCH_EVENT_RET_V40 lpSearchEventRet);

        public delegate int NET_DVR_FindNextFile(int lFindHandle, ref NET_DVR_FIND_DATA lpFindData);

        public delegate int NET_DVR_FindNextFile_Card(int lFindHandle, ref NET_DVR_FINDDATA_CARD lpFindData);

        public delegate int NET_DVR_FindNextFile_V30(int lFindHandle, ref NET_DVR_FINDDATA_V30 lpFindData);

        public delegate int NET_DVR_FindNextFile_V40(int lFindHandle, ref NET_DVR_FINDDATA_V40 lpFindData);

        public delegate int NET_DVR_FindNextLog(int lLogHandle, ref NET_DVR_LOG lpLogData);

        public delegate int NET_DVR_FindNextLog_MATRIX(int iLogHandle, ref NET_DVR_LOG_MATRIX lpLogData);

        public delegate int NET_DVR_FindNextLog_V30(int lLogHandle, ref NET_DVR_LOG_V30 lpLogData);

        public delegate int NET_DVR_FindNextPicture_V50(int lFindHandle, ref NET_DVR_FIND_PICTURE_V50 lpFindData);

        public delegate int NET_DVR_FindPicture(int lUserID, ref NET_DVR_FIND_PICTURE_PARAM pFindParam);

        public delegate int NET_DVR_FormatDisk(int lUserID, int lDiskNumber);

        public delegate bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        public delegate bool NET_DVR_GetAlarmOut(int lUserID, ref NET_DVR_ALARMOUTSTATUS lpAlarmOutState);

        public delegate bool NET_DVR_GetAlarmOut_V30(int lUserID, IntPtr lpAlarmOutState);

        public delegate bool NET_DVR_GetATMPortCFG(int lUserID, ref ushort LPOutATMPort);

        public delegate bool NET_DVR_GetAtmProtocol(int lUserID, ref NET_DVR_ATM_PROTOCOL lpAtmProtocol);

        public delegate bool NET_DVR_GetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, ref int pValue);

        public delegate int NET_DVR_GetCardLastError_Card();

        public delegate bool NET_DVR_GetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        public delegate IntPtr NET_DVR_GetChanHandle_Card(int lRealHandle);

        public delegate bool NET_DVR_GetConfigFile(int lUserID, string sFileName);

        public delegate bool NET_DVR_GetConfigFile_EX(int lUserID, string sOutBuffer, uint dwOutSize);

        public delegate bool NET_DVR_GetConfigFile_V30(int lUserID, string sOutBuffer, uint dwOutSize, ref uint pReturnSize);

        public delegate int NET_DVR_GetDDrawDeviceTotalNums();

        public delegate bool NET_DVR_GetDecCurLinkStatus(int lUserID, int lChannel, ref NET_DVR_DECSTATUS lpDecStatus);

        public delegate bool NET_DVR_GetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        public delegate bool NET_DVR_GetDecoderState(int lUserID, int lChannel, ref NET_DVR_DECODERSTATE lpDecoderState);

        public delegate bool NET_DVR_GetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        public delegate bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        public delegate bool NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize);

        public delegate int NET_DVR_GetDownloadPos(int lFileHandle);

        public delegate bool NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

        public delegate bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, IntPtr pGetIP);

        public delegate bool NET_DVR_GetDVRIPByResolveSvr_EX(string sServerIP, ushort wServerPort, byte[] sDVRName, ushort wDVRNameLen, byte[] sDVRSerialNumber, ushort wDVRSerialLen, byte[] sGetIP, ref uint dwPort);

        public delegate bool NET_DVR_GetDVRWorkState(int lUserID, ref NET_DVR_WORKSTATE lpWorkState);

        public delegate bool NET_DVR_GetDVRWorkState_V30(int lUserID, IntPtr pWorkState);

        public delegate IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);

        public delegate int NET_DVR_GetFileByName(int lUserID, string sDVRFileName, string sSavedFileName);

        public delegate int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        public delegate int NET_DVR_GetFileByTime_V40(int lUserID, string sSavedFileName, ref NET_DVR_PLAYCOND pDownloadCond);

        public delegate bool NET_DVR_GetFormatProgress(int lFormatHandle, ref int pCurrentFormatDisk, ref int pCurrentDiskPos, ref int pFormatStatic);

        public delegate bool NET_DVR_GetInputSignalList_V40(int lUserID, uint dwDevNum, ref NET_DVR_INPUT_SIGNAL_LIST lpInputSignalList);

        public delegate bool NET_DVR_GetIPCProtoList(int lUserID, ref NET_DVR_IPC_PROTO_LIST lpProtoList);

        public delegate bool NET_DVR_GetIPCProtoList_V41(int lUserID, ref NET_DVR_IPC_PROTO_LIST_V41 lpProtoList);

        public delegate uint NET_DVR_GetLastError();

        public delegate bool NET_DVR_GetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        public delegate bool NET_DVR_GetLocalIP(byte[] strIP, ref uint pValidNum, ref bool pEnableBind);

        public delegate int NET_DVR_GetNextRemoteConfig0(int lHandle, ref NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig1(int lHandle, ref NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig2(int lHandle, ref NET_DVR_ACS_EVENT_CFG lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig3(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig4(int lHandle, ref NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig5(int lHandle, ref NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);

        public delegate int NET_DVR_GetNextRemoteConfig6(int lHandle, IntPtr lpOutBuff, int dwOutBuffSize);

        public delegate bool NET_DVR_GetParamSetMode(int lUserID, ref uint dwParamSetMode);

        public delegate bool NET_DVR_GetPicture(int lUserID, string sDVRFileName, string sSavedFileName);

        public delegate int NET_DVR_GetPicUploadProgress(int lUploadHandle);

        public delegate int NET_DVR_GetPicUploadState(int lUploadHandle);

        public delegate bool NET_DVR_GetPlayBackOsdTime(int lPlayHandle, ref NET_DVR_TIME lpOsdTime);

        public delegate int NET_DVR_GetPlayBackPlayerIndex(int lPlayHandle);

        public delegate int NET_DVR_GetPlayBackPos(int lPlayHandle);

        public delegate bool NET_DVR_GetPTZCruise(int lUserID, int lChannel, int lCruiseRoute, ref NET_DVR_CRUISE_RET lpCruiseRet);

        public delegate bool NET_DVR_GetPTZCtrl(int lRealHandle);

        public delegate bool NET_DVR_GetPTZCtrl_Other(int lUserID, int lChannel);

        public delegate bool NET_DVR_GetPTZProtocol(int lUserID, ref NET_DVR_PTZCFG pPtzcfg);

        public delegate bool NET_DVR_GetRealHeight(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpHeight);

        public delegate bool NET_DVR_GetRealLength(int lUserID, int lChannel, ref NET_VCA_LINE lpLine, ref float lpLength);

        public delegate int NET_DVR_GetRealPlayerIndex(int lRealHandle);

        public delegate bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);

        public delegate bool NET_DVR_GetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpOutBuffer, uint dwOutBufferSize);

        public delegate bool NET_DVR_GetScaleCFG(int lUserID, ref uint lpOutScale);

        public delegate bool NET_DVR_GetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        public delegate bool NET_DVR_GetSDKAbility(ref NET_DVR_SDKABL pSDKAbl);

        public delegate uint NET_DVR_GetSDKBuildVersion();

        public delegate bool NET_DVR_GetSDKLocalCfg(int enumType, IntPtr lpOutBuff);

        public delegate bool NET_DVR_GetSDKState(ref NET_DVR_SDKSTATE pSDKState);

        public delegate uint NET_DVR_GetSDKVersion();

        public delegate bool NET_DVR_GetSerialNum_Card(int lChannelNum, ref uint pDeviceSerialNo);

        public delegate bool NET_DVR_GetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        public delegate int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        public delegate int NET_DVR_GetUpgradeState(int lUpgradeHandle);

        public delegate bool NET_DVR_GetUploadResult(int lUploadHandle, IntPtr lpOutBuffer, uint dwOutBufferSize);

        public delegate int NET_DVR_GetUploadState(int lUploadHandle, ref uint pProgress);

        public delegate bool NET_DVR_GetUpnpNatState(int lUserID, ref NET_DVR_UPNP_NAT_STATE lpState);

        public delegate bool NET_DVR_GetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        public delegate bool NET_DVR_GetVideoEffect(int lUserID, int lChannel, ref uint pBrightValue, ref uint pContrastValue, ref uint pSaturationValue, ref uint pHueValue);

        public delegate bool NET_DVR_Init();

        public delegate bool NET_DVR_InitDDrawDevice();

        public delegate bool NET_DVR_InitDDraw_Card(IntPtr hParent, uint colorKey);

        public delegate bool NET_DVR_InitDevice_Card(ref int pDeviceTotalChan);

        public delegate IntPtr NET_DVR_InitG711Encoder(ref NET_DVR_AUDIOENC_INFO enc_info);

        public delegate IntPtr NET_DVR_InitG722Decoder(int nBitrate);

        public delegate IntPtr NET_DVR_InitG722Encoder();

        public delegate bool NET_DVR_InquestStartCDW_V30(int lUserID, ref NET_DVR_INQUEST_ROOM lpInquestRoom, bool bNotBurn);

        public delegate int NET_DVR_IsSupport();

        public delegate bool NET_DVR_LockFileByName(int lUserID, string sLockFileName);

        public delegate bool NET_DVR_LockPanel(int lUserID);

        public delegate int NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO lpDeviceInfo);

        public delegate int NET_DVR_Login_V30(string sDVRIP, int wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);

        public delegate int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        public delegate bool NET_DVR_LogoSwitch(int lUserID, uint dwDecChan, uint dwLogoSwitch);

        public delegate bool NET_DVR_Logout(int iUserID);

        public delegate bool NET_DVR_Logout_V30(int lUserID);

        public delegate bool NET_DVR_MakeKeyFrame(int lUserID, int lChannel);

        public delegate bool NET_DVR_MakeKeyFrameSub(int lUserID, int lChannel);

        public delegate bool NET_DVR_ManualSnap(int lUserID, ref NET_DVR_MANUALSNAP lpInter, ref NET_DVR_PLATE_RESULT lpOuter);

        public delegate bool NET_DVR_MatrixDiaplayControl(int lUserID, uint dwDispChanNum, uint dwDispChanCmd, uint dwCmdParam);

        public delegate bool NET_DVR_MatrixGetDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        public delegate bool NET_DVR_MatrixGetDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO lpInter);

        public delegate bool NET_DVR_MatrixGetDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V30 lpInter);

        public delegate bool NET_DVR_MatrixGetDecChanInfo_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_INFO_V41 lpOuter);

        public delegate bool NET_DVR_MatrixGetDecChanStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_CHAN_STATUS lpInter);

        public delegate bool NET_DVR_MatrixGetDeviceStatus(int lUserID, ref NET_DVR_DECODER_WORK_STATUS lpDecoderCfg);

        public delegate bool NET_DVR_MatrixGetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        public delegate bool NET_DVR_MatrixGetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        public delegate bool NET_DVR_MatrixGetLoopDecChanEnable(int lUserID, uint dwDecChanNum, ref uint lpdwEnable);

        public delegate bool NET_DVR_MatrixGetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        public delegate bool NET_DVR_MatrixGetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        public delegate bool NET_DVR_MatrixGetLoopDecEnable(int lUserID, ref uint lpdwEnable);

        public delegate bool NET_DVR_MatrixGetRemotePlayStatus(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS lpOuter);

        public delegate bool NET_DVR_MatrixGetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);

        public delegate bool NET_DVR_MatrixGetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        public delegate bool NET_DVR_MatrixGetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        public delegate bool NET_DVR_MatrixSendData(int lPassiveHandle, IntPtr pSendBuf, uint dwBufSize);

        public delegate bool NET_DVR_MatrixSetDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        public delegate bool NET_DVR_MatrixSetDisplayCfg(int lUserID, uint dwDispChanNum, ref NET_DVR_VGA_DISP_CHAN_CFG lpDisplayCfg);

        public delegate bool NET_DVR_MatrixSetDisplayCfg_V41(int lUserID, uint dwDispChanNum, ref NET_DVR_MATRIX_VOUTCFG lpDisplayCfg);

        public delegate bool NET_DVR_MatrixSetLoopDecChanEnable(int lUserID, uint dwDecChanNum, uint dwEnable);

        public delegate bool NET_DVR_MatrixSetLoopDecChanInfo(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO lpInter);

        public delegate bool NET_DVR_MatrixSetLoopDecChanInfo_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_LOOP_DECINFO_V30 lpInter);

        public delegate bool NET_DVR_MatrixSetRemotePlay(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DEC_REMOTE_PLAY lpInter);

        public delegate bool NET_DVR_MatrixSetRemotePlayControl(int lUserID, uint dwDecChanNum, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        public delegate bool NET_DVR_MatrixSetSceneCfg(int lUserID, uint dwSceneNum, ref NET_DVR_MATRIX_SCENECFG lpSceneCfg);

        public delegate bool NET_DVR_MatrixSetTranInfo(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG lpTranInfo);

        public delegate bool NET_DVR_MatrixSetTranInfo_V30(int lUserID, ref NET_DVR_MATRIX_TRAN_CHAN_CONFIG_V30 lpTranInfo);

        public delegate bool NET_DVR_MatrixStartDynamic(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_DYNAMIC_DEC lpDynamicInfo);

        public delegate bool NET_DVR_MatrixStartDynamic_V30(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG lpDynamicInfo);

        public delegate bool NET_DVR_MatrixStartDynamic_V41(int lUserID, uint dwDecChanNum, ref NET_DVR_PU_STREAM_CFG_V41 lpDynamicInfo);

        public delegate int NET_DVR_MatrixStartPassiveDecode(int lUserID, uint dwDecChanNum, ref NET_DVR_MATRIX_PASSIVEMODE lpPassiveMode);

        public delegate bool NET_DVR_MatrixStopDynamic(int lUserID, uint dwDecChanNum);

        public delegate bool NET_DVR_MatrixStopPassiveDecode(int lPassiveHandle);

        public delegate bool NET_DVR_OpenSound(int lRealHandle);

        public delegate bool NET_DVR_OpenSoundShare(int lRealHandle);

        public delegate bool NET_DVR_OpenSound_Card(int lRealHandle);

        public delegate int NET_DVR_PicUpload(int lUserID, string sFileName, ref NET_DVR_PICTURECFG lpPictureCfg);

        public delegate int NET_DVR_PlayBackByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        public delegate int NET_DVR_PlayBackByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, IntPtr hWnd);

        public delegate int NET_DVR_PlayBackByTime_V40(int lUserID, ref NET_DVR_VOD_PARA pVodPara);

        public delegate bool NET_DVR_PlayBackCaptureFile(int lPlayHandle, string sFileName);

        public delegate bool NET_DVR_PlayBackControl(int lPlayHandle, uint dwControlCode, uint dwInValue, ref uint LPOutValue);

        public delegate bool NET_DVR_PlayBackControl_V40(int lPlayHandle, uint dwControlCode, IntPtr lpInBuffer, uint dwInValue, IntPtr lpOutBuffer, ref uint LPOutValue);

        public delegate int NET_DVR_PlayBackReverseByName(int lUserID, string sPlayBackFileName, IntPtr hWnd);

        public delegate int NET_DVR_PlayBackReverseByTime_V40(int lUserID, IntPtr hWnd, ref NET_DVR_PLAYCOND pPlayCond);

        public delegate bool NET_DVR_PlayBackSaveData(int lPlayHandle, string sFileName);

        public delegate bool NET_DVR_PTZControl(int lRealHandle, uint dwPTZCommand, uint dwStop);

        public delegate bool NET_DVR_PTZControlWithSpeed(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        public delegate bool NET_DVR_PTZControlWithSpeed_EX(int lRealHandle, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        public delegate bool NET_DVR_PTZControlWithSpeed_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop, uint dwSpeed);

        public delegate bool NET_DVR_PTZControl_EX(int lRealHandle, uint dwPTZCommand, uint dwStop);

        public delegate bool NET_DVR_PTZControl_Other(int lUserID, int lChannel, uint dwPTZCommand, uint dwStop);

        public delegate bool NET_DVR_PTZCruise(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        public delegate bool NET_DVR_PTZCruise_EX(int lRealHandle, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        public delegate bool NET_DVR_PTZCruise_Other(int lUserID, int lChannel, uint dwPTZCruiseCmd, byte byCruiseRoute, byte byCruisePoint, ushort wInput);

        public delegate bool NET_DVR_PTZMltTrack(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        public delegate bool NET_DVR_PTZMltTrack_EX(int lRealHandle, uint dwPTZTrackCmd, uint dwTrackIndex);

        public delegate bool NET_DVR_PTZMltTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd, uint dwTrackIndex);

        public delegate bool NET_DVR_PTZPreset(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        public delegate bool NET_DVR_PTZPreset_EX(int lRealHandle, uint dwPTZPresetCmd, uint dwPresetIndex);

        public delegate bool NET_DVR_PTZPreset_Other(int lUserID, int lChannel, uint dwPTZPresetCmd, uint dwPresetIndex);

        public delegate bool NET_DVR_PTZSelZoomIn(int lRealHandle, ref NET_DVR_POINT_FRAME pStruPointFrame);

        public delegate bool NET_DVR_PTZSelZoomIn_EX(int lUserID, int lChannel, ref NET_DVR_POINT_FRAME pStruPointFrame);

        public delegate bool NET_DVR_PTZTrack(int lRealHandle, uint dwPTZTrackCmd);

        public delegate bool NET_DVR_PTZTrack_EX(int lRealHandle, uint dwPTZTrackCmd);

        public delegate bool NET_DVR_PTZTrack_Other(int lUserID, int lChannel, uint dwPTZTrackCmd);

        public delegate int NET_DVR_RealPlay(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo);

        public delegate int NET_DVR_RealPlay_Card(int lUserID, ref NET_DVR_CARDINFO lpCardInfo, int lChannelNum);

        public delegate int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, uint bBlocked);

        public delegate int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser);

        public delegate bool NET_DVR_RebootDVR(int lUserID);

        public delegate bool NET_DVR_RefreshPlay(int lPlayHandle);

        public delegate bool NET_DVR_RefreshSurface_Card();

        public delegate bool NET_DVR_ReleaseDDrawDevice();

        public delegate bool NET_DVR_ReleaseDDraw_Card();

        public delegate bool NET_DVR_ReleaseDevice_Card();

        public delegate bool NET_DVR_ReleaseG711Encoder(IntPtr pEncodeHandle);

        public delegate void NET_DVR_ReleaseG722Decoder(IntPtr pDecHandle);

        public delegate void NET_DVR_ReleaseG722Encoder(IntPtr pEncodeHandle);

        public delegate bool NET_DVR_RemoteControl0(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferSize);

        public delegate bool NET_DVR_RemoteControl1(int lUserID, int dwCommand, ref NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);

        public delegate bool NET_DVR_ResetPara_Card(int lRealHandle, ref NET_DVR_DISPLAY_PARA lpDisplayPara);

        public delegate bool NET_DVR_RestoreConfig(int lUserID);

        public delegate bool NET_DVR_RestoreSurface_Card();

        public delegate bool NET_DVR_RigisterDrawFun(int lRealHandle, DRAWFUN fDrawFun, uint dwUser);

        public delegate bool NET_DVR_SaveConfig(int lUserID);

        public delegate bool NET_DVR_SaveRealData(int lRealHandle, string sFileName);

        public delegate bool NET_DVR_SaveRealData_V30(int lRealHandle, uint dwTransType, string sFileName);

        public delegate bool NET_DVR_SendRemoteConfig(int lHandle, int dwDataType, IntPtr pSendBuf, int dwBufSize);

        public delegate bool NET_DVR_SendTo232Port(int lUserID, string pSendBuf, uint dwBufSize);

        public delegate bool NET_DVR_SendToSerialPort(int lUserID, uint dwSerialPort, uint dwSerialIndex, string pSendBuf, uint dwBufSize);

        public delegate int NET_DVR_SendWithRecvRemoteConfig0(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);

        public delegate int NET_DVR_SendWithRecvRemoteConfig1(int lHandle, ref NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        public delegate int NET_DVR_SendWithRecvRemoteConfig2(int lHandle, ref NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        public delegate bool NET_DVR_SerialSend(int lSerialHandle, int lChannel, string pSendBuf, uint dwBufSize);

        public delegate bool NET_DVR_SerialStart(int lUserID, int lSerialPort, SERIALDATACALLBACK fSerialDataCallBack, uint dwUser);

        public delegate bool NET_DVR_SerialStop(int lSerialHandle);

        public delegate bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        public delegate bool NET_DVR_SetAlarmOut(int lUserID, int lAlarmOutPort, int lAlarmOutStatic);

        public delegate bool NET_DVR_SetATMPortCFG(int lUserID, ushort wATMPort);

        public delegate bool NET_DVR_SetAudioMode(uint dwMode);

        public delegate bool NET_DVR_SetBehaviorParamKey(int lUserID, int lChannel, uint dwParameterKey, int nValue);

        public delegate bool NET_DVR_SetCCDCfg(int lUserID, int lChannel, ref NET_DVR_CCD_CFG lpCCDCfg);

        public delegate bool NET_DVR_SetConfigFile(int lUserID, string sFileName);

        public delegate bool NET_DVR_SetConfigFile_EX(int lUserID, string sInBuffer, uint dwInSize);

        public delegate bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

        public delegate bool NET_DVR_SetDDrawDevice(int lPlayPort, uint nDeviceNum);

        public delegate bool NET_DVR_SetDecInfo(int lUserID, int lChannel, ref NET_DVR_DECCFG lpDecoderinfo);

        public delegate bool NET_DVR_SetDecTransPort(int lUserID, ref NET_DVR_PORTCFG lpTransPort);

        public delegate bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);

        public delegate bool NET_DVR_SetDeviceConfigEx(int lUserID, uint dwCommand, uint dwCount, ref NET_DVR_IN_PARAM lpInParam, ref NET_DVR_OUT_PARAM lpOutParam);

        public delegate bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);

        public delegate bool NET_DVR_SetDVRMessage(uint nMessage, IntPtr hWnd);

        public delegate bool NET_DVR_SetDVRMessageCallBack(MESSAGECALLBACK fMessageCallBack, uint dwUser);

        public delegate bool NET_DVR_SetDVRMessageCallBack_V30(MSGCallBack fMessageCallBack, IntPtr pUser);

        public delegate bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);

        public delegate bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);

        public delegate bool NET_DVR_SetDVRMessCallBack(MESSCALLBACK fMessCallBack);

        public delegate bool NET_DVR_SetDVRMessCallBack_EX(MESSCALLBACKEX fMessCallBack_EX);

        public delegate bool NET_DVR_SetDVRMessCallBack_NEW(MESSCALLBACKNEW fMessCallBack_NEW);

        public delegate bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd, EXCEPYIONCALLBACK fExceptionCallBack, IntPtr pUser);

        public delegate bool NET_DVR_SetLFTrackMode(int lUserID, int lChannel, ref NET_DVR_LF_TRACK_MODE lpTrackMode);

        public delegate bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        public delegate bool NET_DVR_SetNetworkEnvironment(uint dwEnvironmentLevel);

        public delegate bool NET_DVR_SetPlayDataCallBack(int lPlayHandle, PLAYDATACALLBACK fPlayDataCallBack, uint dwUser);

        public delegate bool NET_DVR_SetPlayerBufNumber(int lRealHandle, uint dwBufNum);

        public delegate bool NET_DVR_SetRealDataCallBack(int lRealHandle, SETREALDATACALLBACK fRealDataCallBack, uint dwUser);

        public delegate bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

        public delegate bool NET_DVR_SetRtspConfig(int lUserID, uint dwCommand, ref NET_DVR_RTSPCFG lpInBuffer, uint dwInBufferSize);

        public delegate bool NET_DVR_SetScaleCFG(int lUserID, uint dwScale);

        public delegate bool NET_DVR_SetScaleCFG_V30(int lUserID, ref NET_DVR_SCALECFG pScalecfg);

        public delegate bool NET_DVR_SetSDKLocalCfg(int enumType, IntPtr lpInBuff);

        public delegate bool NET_DVR_SetShowMode(uint dwShowType, uint colorKey);

        public delegate bool NET_DVR_SetStandardDataCallBack(int lRealHandle, STDDATACALLBACK fStdDataCallBack, uint dwUser);

        public delegate bool NET_DVR_SetSTDConfig(int iUserID, uint dwCommand, ref NET_DVR_STD_CONFIG lpConfigParam);

        public delegate int NET_DVR_SetupAlarmChan(int lUserID);

        public delegate int NET_DVR_SetupAlarmChan_V30(int lUserID);

        public delegate int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);

        public delegate bool NET_DVR_SetValidIP(uint dwIPIndex, bool bEnableBind);

        public delegate bool NET_DVR_SetVCADrawMode(int lUserID, int lChannel, ref NET_VCA_DRAW_MODE lpDrawMode);

        public delegate bool NET_DVR_SetVideoEffect(int lUserID, int lChannel, uint dwBrightValue, uint dwContrastValue, uint dwSaturationValue, uint dwHueValue);

        public delegate bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        public delegate bool NET_DVR_SetVolume_Card(int lRealHandle, ushort wVolume);

        public delegate bool NET_DVR_ShutDownDVR(int lUserID);

        public delegate bool NET_DVR_StartDecode(int lUserID, int lChannel, ref NET_DVR_DECODERINFO lpDecoderinfo);

        public delegate bool NET_DVR_StartDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        public delegate bool NET_DVR_StartDVRRecord(int lUserID, int lChannel, int lRecordType);

        public delegate bool NET_DVR_StartListen(string sLocalIP, ushort wLocalPort);

        public delegate int NET_DVR_StartListen_V30(string sLocalIP, ushort wLocalPort, MSGCallBack DataCallback, IntPtr pUserData);

        public delegate int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        public delegate int NET_DVR_StartVoiceCom(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        public delegate int NET_DVR_StartVoiceCom_MR(int lUserID, VOICEDATACALLBACK fVoiceDataCallBack, uint dwUser);

        public delegate int NET_DVR_StartVoiceCom_MR_V30(int lUserID, uint dwVoiceChan, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        public delegate int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        public delegate bool NET_DVR_STDXMLConfig0(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);

        public delegate bool NET_DVR_STDXMLConfig1(int iUserID, ref NET_DVR_XML_CONFIG_INPUT lpInputParam, ref NET_DVR_XML_CONFIG_OUTPUT lpOutputParam);

        public delegate bool NET_DVR_StopDecode(int lUserID, int lChannel);

        public delegate bool NET_DVR_StopDecSpecialCon(int lUserID, int lChannel, ref NET_DVR_DECCHANINFO lpDecChanInfo);

        public delegate bool NET_DVR_StopDVRRecord(int lUserID, int lChannel);

        public delegate bool NET_DVR_StopGetFile(int lFileHandle);

        public delegate bool NET_DVR_StopListen();

        public delegate bool NET_DVR_StopListen_V30(int lListenHandle);

        public delegate bool NET_DVR_StopPlayBack(int lPlayHandle);

        public delegate bool NET_DVR_StopPlayBackSave(int lPlayHandle);

        public delegate bool NET_DVR_StopRealPlay(int iRealHandle);

        public delegate bool NET_DVR_StopRemoteConfig(int lHandle);

        public delegate bool NET_DVR_StopSaveRealData(int lRealHandle);

        public delegate bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        public delegate bool NET_DVR_ThrowBFrame(int lRealHandle, uint dwNum);

        public delegate bool NET_DVR_TransPTZ(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        public delegate bool NET_DVR_TransPTZ_EX(int lRealHandle, string pPTZCodeBuf, uint dwBufSize);

        public delegate bool NET_DVR_TransPTZ_Other(int lUserID, int lChannel, string pPTZCodeBuf, uint dwBufSize);

        public delegate bool NET_DVR_UnlockFileByName(int lUserID, string sUnlockFileName);

        public delegate bool NET_DVR_UnLockPanel(int lUserID);

        public delegate int NET_DVR_Upgrade(int lUserID, string sFileName);

        public delegate int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, int dwInBufferLen);

        public delegate bool NET_DVR_UploadClose(int lUploadHandle);

        public delegate int NET_DVR_UploadFile_V40(int lUserID, uint dwUploadType, IntPtr lpInBuffer, uint dwInBufferSize, string sFileName, IntPtr lpOutBuffer, uint dwOutBufferSize);

        public delegate bool NET_DVR_UploadLogo(int lUserID, uint dwDispChanNum, ref NET_DVR_DISP_LOGOCFG lpDispLogoCfg, IntPtr sLogoBuffer);

        public delegate int NET_DVR_UploadSend(int lUploadHandle, ref NET_DVR_SEND_PARAM_IN pstruSendParamIN, IntPtr lpOutBuffer);

        public delegate bool NET_DVR_VoiceComSendData(int lVoiceComHandle, string pSendBuf, uint dwBufSize);

        public delegate bool NET_DVR_Volume(int lRealHandle, ushort wVolume);

        public delegate int NET_SDK_RealPlay(int iUserLogID, ref NET_DVR_CLIENTINFO lpDVRClientInfo);

        public delegate bool NET_VCA_RestartLib(int lUserID, int lChannel);

        public delegate int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
