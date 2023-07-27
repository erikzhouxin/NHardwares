using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiNetDevSDK
{
    /// <summary>
    /// SDK代理类
    /// </summary>
    public interface INetDevSdkProxy
    {
        void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝
        void OutputDebugString(string message);

        Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_Init();

        Int32 NETDEV_Cleanup();

        Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        Int32 NETDEV_GetSDKVersion();

        IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        Int32 NETDEV_Logout(IntPtr lpUserID);

        [Obsolete("SDK中未找到对应函数")]
        Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [Obsolete("SDK中未找到对应函数")]
        Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        Int32 NETDEV_Reboot(IntPtr lpUserID);

        Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        Int32 NETDEV_GetLastError();

        Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        Int32 NETDEV_SetLogPath(String strLogPath);

        Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [Obsolete("SDK中未找到对应函数")]
        Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        Int32 NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList);
    }
}
