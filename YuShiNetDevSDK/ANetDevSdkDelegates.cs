using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiNetDevSDK
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_FaceSnapshotCallBack_PF(IntPtr lpHandle, ref NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S pstFaceSnapShotData, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_AlarmMessCallBack_PF(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_AlarmMessCallBack_PF_V30(IntPtr lpUserID, ref NETDEV_REPORT_INFO_S pstReportInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_ExceptionCallBack_PF(IntPtr lpUserID, Int32 dwType, IntPtr lpExpHandle, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_DISCOVERY_CALLBACK_PF(IntPtr pstDevInfo, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_PassengerFlowStatisticCallBack_PF(IntPtr lpUserID, IntPtr pstPassengerFlowData, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_PersonAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_PERSON_EVENT_INFO_S pstAlarmData, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_VehicleAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_VEH_RECOGNITION_EVENT_S pstVehicleAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_StructAlarmMessCallBack_PF(IntPtr lpUserID, ref NETDEV_STRUCT_ALARM_INFO_S pstAlarmInfo, ref NETDEV_STRUCT_DATA_INFO_S pstAlarmData, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_AlarmMessFGCallBack_PF(IntPtr lpUserID, ref NETDEV_PERSON_VERIFICATION_S pstAlarmData, IntPtr lpUserData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_SOURCE_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref byte pucBuffer, IntPtr dwBufSize, Int32 dwMediaDataType, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_DISPLAY_CALLBACK_PF(IntPtr lpRealHandle, IntPtr hdc, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_S pstParseVideoData, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_ConflagrationAlarmMessCallBack_PF(IntPtr lpHandle, ref NETDEV_CONFLAGRATION_ALARM_INFO_S pstAlarmInfo, IntPtr lpUserParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public delegate void NETDEV_CarPlateCallBack_PF(IntPtr lpHandle, ref NETDEV_TMS_CAR_PLATE_INFO_S pstCarPlateData, IntPtr lpUserParam);

    internal class DCreater
    {
        public delegate void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝
        public delegate void OutputDebugString(string message);

        public delegate Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_Init();

        public delegate Int32 NETDEV_Cleanup();

        public delegate Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        public delegate Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        public delegate IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        public delegate Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        public delegate Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        public delegate Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        public delegate Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        public delegate Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        public delegate Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        public delegate Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        public delegate Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        public delegate Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        public delegate IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        public delegate Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        public delegate Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        public delegate IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        public delegate Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        public delegate Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        public delegate Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        public delegate Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        public delegate Int32 NETDEV_SetDevConfig1(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        public delegate Int32 NETDEV_SetDevConfig2(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig1(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfig3(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig2(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfig3(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfig4(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_SetDevConfig5(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        public delegate Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        public delegate Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        public delegate Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        public delegate IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        public delegate Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        public delegate Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        public delegate Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        public delegate Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        public delegate Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        public delegate Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        public delegate Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        public delegate Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        public delegate Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        public delegate Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        public delegate IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        public delegate Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        public delegate Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        public delegate Int32 NETDEV_GetSDKVersion();

        public delegate IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        public delegate Int32 NETDEV_Logout(IntPtr lpUserID);

        public delegate Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        public delegate Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        public delegate IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        public delegate IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        public delegate Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        public delegate IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        public delegate Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        public delegate Int32 NETDEV_GetDevConfig4(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfig6(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        public delegate Int32 NETDEV_Reboot(IntPtr lpUserID);

        public delegate Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        public delegate Int32 NETDEV_GetLastError();

        public delegate Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        public delegate IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        public delegate IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        public delegate Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        public delegate Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        public delegate Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        public delegate Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        public delegate IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        public delegate Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        public delegate Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        public delegate IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        public delegate Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        public delegate Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        public delegate Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        public delegate Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        public delegate Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        public delegate Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        public delegate Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        public delegate Int32 NETDEV_SetDevConfig7(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        public delegate Int32 NETDEV_GetDevConfig5(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfig8(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig6(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfig9(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig7(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigA(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig8(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigB(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfig9(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigC(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfigA(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigD(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfigB(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigE(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfigC(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigD(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigE(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigF(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigG(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigH(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigI(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_GetDevConfigJ(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigF(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        public delegate Int32 NETDEV_SetDevConfigG(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_GetDevConfigK(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        public delegate Int32 NETDEV_SetDevConfigH(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        public delegate Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        public delegate Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        public delegate Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        public delegate Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        public delegate Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        public delegate Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        public delegate Int32 NETDEV_SetLogPath(String strLogPath);

        public delegate Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        public delegate Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        public delegate Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        public delegate Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        public delegate IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        public delegate Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        public delegate Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        public delegate Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        public delegate Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        public delegate Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        public delegate Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        public delegate Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        public delegate Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        public delegate Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        public delegate Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        public delegate Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        public delegate Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        public delegate IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        public delegate Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        public delegate Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        public delegate Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        public delegate IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        public delegate Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        public delegate Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        public delegate Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        public delegate Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        public delegate Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        public delegate Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        public delegate IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        public delegate Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        public delegate IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        public delegate Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        public delegate Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        public delegate Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        public delegate IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        public delegate Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        public delegate Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        public delegate IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        public delegate Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        public delegate Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        public delegate Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        public delegate Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        public delegate Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        public delegate Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        public delegate Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        public delegate IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        public delegate Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        public delegate Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        public delegate IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        public delegate Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        public delegate Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        public delegate Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        public delegate Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        public delegate IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        public delegate Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        public delegate Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        public delegate Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        public delegate Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        public delegate Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        public delegate Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        public delegate IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        public delegate Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        public delegate Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        public delegate Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        public delegate Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        public delegate Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        public delegate IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        public delegate Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        public delegate Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        public delegate Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        public delegate Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        public delegate IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        public delegate Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        public delegate Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        public delegate Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        public delegate Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        public delegate IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        public delegate Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        public delegate IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        public delegate Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        public delegate Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        public delegate Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        public delegate Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        public delegate IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        public delegate Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        public delegate Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        public delegate Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        public delegate Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        public delegate Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        public delegate Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        public delegate Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        public delegate Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        public delegate Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        public delegate Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        public delegate Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        public delegate Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        public delegate Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        public delegate Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        public delegate Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        public delegate Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        public delegate Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        public delegate Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        public delegate Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        public delegate Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        public delegate Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        public delegate Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        public delegate Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        public delegate Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        public delegate Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        public delegate Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        public delegate Int32 NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList);
    }
}
