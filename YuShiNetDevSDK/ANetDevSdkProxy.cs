﻿using System;
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
    internal class NetDevSdkDller : INetDevSdkProxy
    {
        public static INetDevSdkProxy Instance { get; } = new NetDevSdkDller();
        private NetDevSdkDller() { }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList);

        #region // 显示实现
        void INetDevSdkProxy.MemCopy(byte[] dest, IntPtr src, int count) => MemCopy(dest, src, count);
        int INetDevSdkProxy.NETDEV_ACSPersonCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo) => NETDEV_ACSPersonCtrl(lpUserID, dwCommand, ref pstACSPersonInfo);
        int INetDevSdkProxy.NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref uint pUdwBlackListID) => NETDEV_AddACSPersonBlackList(lpUserID, ref pstBlackListInfo, ref pUdwBlackListID);
        int INetDevSdkProxy.NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList) => NETDEV_AddACSPersonList(lpUserID, ref pstACSPersonList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref uint pUdwGroupID) => NETDEV_AddACSPersonPermissionGroup(lpUserID, ref pstPermissionGroupInfo, ref pUdwGroupID);
        int INetDevSdkProxy.NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref int pdwOrgID) => NETDEV_AddOrgInfo(lpUserID, ref pstOrgInfo, ref pdwOrgID);
        int INetDevSdkProxy.NETDEV_AddPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => NETDEV_AddPersonInfo(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int INetDevSdkProxy.NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo) => NETDEV_AddPersonMonitorInfo(lpUserID, ref pstMonitorInfo, ref pstMonitorResultInfo);
        int INetDevSdkProxy.NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo) => NETDEV_AddUserV30(lpFindHandle, ref pstUserModifyInfo);
        int INetDevSdkProxy.NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => NETDEV_AddVehicleLibInfo(lpUserID, ref pstVehicleLibInfo);
        int INetDevSdkProxy.NETDEV_AddVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => NETDEV_AddVehicleLibMember(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int INetDevSdkProxy.NETDEV_AddVehicleMemberList(IntPtr lpUserID, uint udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_AddVehicleMemberList(lpUserID, udwLibID, ref pstVehicleMemberList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_AddVehicleMonitorInfo(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo) => NETDEV_BatchDeleteOrgInfo(lpUserID, ref pstOrgDelInfo, ref pstOrgDelResultInfo);
        int INetDevSdkProxy.NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_BatchDeletePersonMonitorInfo(lpUserID, ref pstResultList);
        int INetDevSdkProxy.NETDEV_CaptureNoPreview(IntPtr lpUserID, int dwChannelID, int dwStreamType, string szFileName, int dwCaptureMode) => NETDEV_CaptureNoPreview(lpUserID, dwChannelID, dwStreamType, szFileName, dwCaptureMode);
        int INetDevSdkProxy.NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, int dwCaptureMode) => NETDEV_CapturePicture(lpRealHandle, szFileName, dwCaptureMode);
        int INetDevSdkProxy.NETDEV_Cleanup() => NETDEV_Cleanup();
        int INetDevSdkProxy.NETDEV_CloseMic(IntPtr lpPlayHandle) => NETDEV_CloseMic(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_CloseSound(IntPtr lpRealHandle) => NETDEV_CloseSound(lpRealHandle);
        int INetDevSdkProxy.NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref uint pudwID) => NETDEV_CreatePersonLibInfo(lpUserID, ref pstPersonLibInfo, ref pudwID);
        int INetDevSdkProxy.NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo) => NETDEV_CreateUser(lpUserID, stUserInfo);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList) => NETDEV_DeleteACSPersonBlackList(lpUserID, ref pstBlackList);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo) => NETDEV_DeleteACSPersonList(lpUserID, ref pstBatchCtrlInfo);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => NETDEV_DeleteACSPersonPermissionGroup(lpUserID, ref pstPermissionIDList, ref pstResutList);
        int INetDevSdkProxy.NETDEV_DeletePersonInfo(IntPtr lpUserID, uint udwPersonLibID, uint udwPersonID, uint udwLastChange) => NETDEV_DeletePersonInfo(lpUserID, udwPersonLibID, udwPersonID, udwLastChange);
        int INetDevSdkProxy.NETDEV_DeletePersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => NETDEV_DeletePersonInfoList(lpUserID, udwPersonLibID, ref pstIDList, ref pstResutList);
        int INetDevSdkProxy.NETDEV_DeletePersonLibInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo) => NETDEV_DeletePersonLibInfo(lpUserID, udwPersonLibID, ref pstFlagInfo);
        int INetDevSdkProxy.NETDEV_DeleteUser(IntPtr lpUserID, string strUserName) => NETDEV_DeleteUser(lpUserID, strUserName);
        int INetDevSdkProxy.NETDEV_DeleteUserV30(IntPtr lpFindHandle, uint udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_DeleteUserV30(lpFindHandle, udwUserNum, ref pstUserNameList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag) => NETDEV_DeleteVehicleLibInfo(lpUserID, udwVehicleLibID, ref pstDelLibFlag);
        int INetDevSdkProxy.NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => NETDEV_DeleteVehicleLibMember(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int INetDevSdkProxy.NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => NETDEV_DeleteVehicleMonitorInfo(lpUserID, ref pstBatchList);
        int INetDevSdkProxy.NETDEV_DelVehicleMemberList(IntPtr lpUserID, uint udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => NETDEV_DelVehicleMemberList(lpUserID, udwLib, ref pstVehicleMemberList, ref pstBatchList);
        int INetDevSdkProxy.NETDEV_Discovery(string pszBeginIP, string pszEndIP) => NETDEV_Discovery(pszBeginIP, pszEndIP);
        int INetDevSdkProxy.NETDEV_DoorBatchCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo) => NETDEV_DoorBatchCtrl(lpUserID, dwCommand, ref pstBatchCtrlInfo);
        int INetDevSdkProxy.NETDEV_DoorCtrl(IntPtr lpUserID, int dwChannelID, int dwCommand) => NETDEV_DoorCtrl(lpUserID, dwChannelID, dwCommand);
        IntPtr INetDevSdkProxy.NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSAttendanceLogList(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPermissionGroupList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPersonBlackList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSPersonList(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindACSVisitLogList(lpUserID, ref pstFindCond, ref pstResultInfo);
        int INetDevSdkProxy.NETDEV_FindClose(IntPtr lpFindHandle) => NETDEV_FindClose(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle) => NETDEV_FindCloseACSAttendanceLogList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle) => NETDEV_FindCloseACSPermissionGroupList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle) => NETDEV_FindCloseACSPersonBlackList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle) => NETDEV_FindCloseACSPersonInfo(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle) => NETDEV_FindCloseACSVisitLog(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseDevChn(IntPtr lpFindHandle) => NETDEV_FindCloseDevChn(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseDevInfo(IntPtr lpFindHandle) => NETDEV_FindCloseDevInfo(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle) => NETDEV_FindCloseFaceRecordDetail(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle) => NETDEV_FindCloseMonitorStatusList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle) => NETDEV_FindCloseOrgInfo(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePermStatusList(IntPtr lpFindHandle) => NETDEV_FindClosePermStatusList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle) => NETDEV_FindClosePersonInfoList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonLibList(IntPtr lpFindHandle) => NETDEV_FindClosePersonLibList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle) => NETDEV_FindClosePersonMonitorList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle) => NETDEV_FindCloseRoleBaseInfoOfUserList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle) => NETDEV_FindCloseRoleInfoList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle) => NETDEV_FindCloseTimeTemplateByTypeList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle) => NETDEV_FindCloseTrafficStatisticInfo(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle) => NETDEV_FindCloseUserDetailInfoListV30(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleLibList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleMemberDetail(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleMonitorList(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle) => NETDEV_FindCloseVehicleRecordList(lpFindHandle);
        IntPtr INetDevSdkProxy.NETDEV_FindDevChnList(IntPtr lpUserID, int dwDevID, int dwChnType) => NETDEV_FindDevChnList(lpUserID, dwDevID, dwChnType);
        IntPtr INetDevSdkProxy.NETDEV_FindDevList(IntPtr lpUserID, int dwDevType) => NETDEV_FindDevList(lpUserID, dwDevType);
        IntPtr INetDevSdkProxy.NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => NETDEV_FindFaceRecordDetailList(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond) => NETDEV_FindFile(lpUserID, ref pFindCond);
        IntPtr INetDevSdkProxy.NETDEV_FindMonitorStatusList(IntPtr lpUserID, int enType, ref uint udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList) => NETDEV_FindMonitorStatusList(lpUserID, enType, ref udwMonitorID, ref pstFindLimit, ref pstList);
        int INetDevSdkProxy.NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo) => NETDEV_FindNextACSAttendanceLog(lpFindHandle, ref pstACSLogInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo) => NETDEV_FindNextACSPermissionGroupInfo(lpFindHandle, ref pstACSPermissionInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_FindNextACSPersonBlackListInfo(lpFindHandle, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo) => NETDEV_FindNextACSPersonInfo(lpFindHandle, ref pstACSPersonInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo) => NETDEV_FindNextACSVisitLog(lpFindHandle, ref pstACSLogInfo);
        int INetDevSdkProxy.NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_FindNextDevChn(lpFindHandle, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo) => NETDEV_FindNextDevInfo(lpFindHandle, ref pstDevBasicInfo);
        int INetDevSdkProxy.NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo) => NETDEV_FindNextFaceRecordDetail(lpFindHandle, ref pstRecordInfo);
        int INetDevSdkProxy.NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData) => NETDEV_FindNextFile(lpFindHandle, ref lpFindData);
        int INetDevSdkProxy.NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats) => NETDEV_FindNextMonitorStatusInfo(lpFindHandle, ref pstMonitorStats);
        int INetDevSdkProxy.NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo) => NETDEV_FindNextOrgInfo(lpFindHandle, ref pstOrgInfo);
        int INetDevSdkProxy.NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus) => NETDEV_FindNextPermStatusInfo(lpFindHandle, ref pstACSPermStatus);
        int INetDevSdkProxy.NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo) => NETDEV_FindNextPersonInfo(lpFindHandle, ref pstPersonInfo);
        int INetDevSdkProxy.NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo) => NETDEV_FindNextPersonLibInfo(lpFindHandle, ref pstPersonLibInfo);
        int INetDevSdkProxy.NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_FindNextPersonMonitorInfo(lpFindHandle, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo) => NETDEV_FindNextRoleBaseInfoOfUser(lpFindHandle, ref pstRoleBaseInfo);
        int INetDevSdkProxy.NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo) => NETDEV_FindNextRoleInfo(lpFindHandle, ref pstRoleInfo);
        int INetDevSdkProxy.NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo) => NETDEV_FindNextTimeTemplateByTypeInfo(lpFindHandle, ref pstTimeTemplateInfo);
        int INetDevSdkProxy.NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo) => NETDEV_FindNextTrafficStatisticInfo(lpFindHandle, ref pstStatisticInfo);
        int INetDevSdkProxy.NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo) => NETDEV_FindNextUserDetailInfoV30(lpFindHandle, ref pstUserDetailInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => NETDEV_FindNextVehicleLibInfo(lpFindHandle, ref pstVehicleLibInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo) => NETDEV_FindNextVehicleMemberDetail(lpFindHandle, ref pstVehicleMemberInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo) => NETDEV_FindNextVehicleMonitorInfo(lpFindHandle, ref pstVehicleMonitorInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo) => NETDEV_FindNextVehicleRecordInfo(lpFindHandle, ref pstRecordInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond) => NETDEV_FindOrgInfoList(lpUserID, ref pstFindCond);
        IntPtr INetDevSdkProxy.NETDEV_FindPermStatusList(IntPtr lpUserID, ref uint udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => NETDEV_FindPermStatusList(lpUserID, ref udwPermGroupID, ref pstQueryInfo, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo) => NETDEV_FindPersonInfoList(lpUserID, udwPersonLibID, ref pstQueryInfo, ref pstQueryResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonLibList(IntPtr lpUserID) => NETDEV_FindPersonLibList(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonMonitorList(IntPtr lpUserID, uint udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo) => NETDEV_FindPersonMonitorList(lpUserID, udwChannelID, ref pstQueryInfo);
        int INetDevSdkProxy.NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, uint udwUserID) => NETDEV_FindRoleBaseInfoOfUserList(lpUserID, udwUserID);
        int INetDevSdkProxy.NETDEV_FindRoleInfoList(IntPtr lpUserID) => NETDEV_FindRoleInfoList(lpUserID);
        int INetDevSdkProxy.NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, uint udwTemplateType) => NETDEV_FindTimeTemplateByTypeList(lpUserID, udwTemplateType);
        IntPtr INetDevSdkProxy.NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, uint udwSearchID) => NETDEV_FindTrafficStatisticInfoList(lpUserID, udwSearchID);
        int INetDevSdkProxy.NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID) => NETDEV_FindUserDetailInfoListV30(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleLibList(IntPtr lpUserID) => NETDEV_FindVehicleLibList(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList) => NETDEV_FindVehicleMemberDetailList(lpUserID, udwVehicleLibID, ref pstFindCond, ref pstDBMemberList);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleMonitorList(IntPtr lpUserID) => NETDEV_FindVehicleMonitorList(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => NETDEV_FindVehicleRecordInfoList(lpUserID, ref pstFindCond, ref pstResultInfo);
        int INetDevSdkProxy.NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_GetACSPersonBlackList(lpUserID, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_GetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_GetACSPersonPermission(lpUserID, udwPersonID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate) => NETDEV_GetBitRate(lpRealHandle, ref pdwBitRate);
        int INetDevSdkProxy.NETDEV_GetChnDetailByChnType(IntPtr lpUserID, int dwChnID, int dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetChnDetailByChnType(lpUserID, dwChnID, dwChnType, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetChnType(IntPtr lpUserID, int dwChnID, ref int pdwChnType) => NETDEV_GetChnType(lpUserID, dwChnID, ref pdwChnType);
        int INetDevSdkProxy.NETDEV_GetCompassInfo(IntPtr lpUserID, int dwChannelID, ref float fCompassInfo) => NETDEV_GetCompassInfo(lpUserID, dwChannelID, ref fCompassInfo);
        int INetDevSdkProxy.NETDEV_GetConfigFile(IntPtr lpUserID, string strConfigPath) => NETDEV_GetConfigFile(lpUserID, strConfigPath);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => NETDEV_GetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo) => NETDEV_GetDeviceInfo(lpUserID, ref pstDevInfo);
        int INetDevSdkProxy.NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, int dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo) => NETDEV_GetDeviceInfo_V30(lpUserID, dwDevID, ref pstDevInfo);
        int INetDevSdkProxy.NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, uint udwRecordID, uint udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo) => NETDEV_GetFaceRecordImageInfo(lpUserID, udwRecordID, udwFaceImageType, ref pstFileInfo);
        IntPtr INetDevSdkProxy.NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, string szSaveFileName, int dwFormat) => NETDEV_GetFileByName(lpUserID, ref pstPlayBackInfo, szSaveFileName, dwFormat);
        IntPtr INetDevSdkProxy.NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, int dwFormat) => NETDEV_GetFileByTime(lpUserID, ref pstPlayBackCond, pszSaveFileName, dwFormat);
        int INetDevSdkProxy.NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate) => NETDEV_GetFrameRate(lpRealHandle, ref pdwFrameRate);
        int INetDevSdkProxy.NETDEV_GetGeolocationInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo) => NETDEV_GetGeolocationInfo(lpUserID, dwChannelID, ref pstGPSInfo);
        int INetDevSdkProxy.NETDEV_GetLastError() => NETDEV_GetLastError();
        int INetDevSdkProxy.NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum) => NETDEV_GetLostPacketRate(lpRealHandle, ref pulRecvPktNum, ref pulLostPktNum);
        int INetDevSdkProxy.NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref int dwVolume) => NETDEV_GetMicVolume(lpPlayHandle, ref dwVolume);
        int INetDevSdkProxy.NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList) => NETDEV_GetMonitorCapacity(lpUserID, ref pstCapacityInfo, ref pstCapacityList);
        int INetDevSdkProxy.NETDEV_GetMonitorProgress(IntPtr lpUserID, ref uint pudwProgressRate) => NETDEV_GetMonitorProgress(lpUserID, ref pudwProgressRate);
        int INetDevSdkProxy.NETDEV_GetPersonLibCapacity(IntPtr lpUserID, int dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList) => NETDEV_GetPersonLibCapacity(lpUserID, dwTimeOut, ref pstCapacityList);
        int INetDevSdkProxy.NETDEV_GetPersonMemberInfo(IntPtr lpUserID, uint udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo) => NETDEV_GetPersonMemberInfo(lpUserID, udwPersonID, ref pstPersonInfo);
        int INetDevSdkProxy.NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_GetPersonMonitorRuleInfo(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo) => NETDEV_GetPTZAbsolutePTInfo(lpUserID, dwChannelID, ref pstPTPositionInfo);
        int INetDevSdkProxy.NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, int dwChannelID, ref float fZoomRatio) => NETDEV_GetPTZAbsoluteZoomInfo(lpUserID, dwChannelID, ref fZoomRatio);
        int INetDevSdkProxy.NETDEV_GetPTZPresetList(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer) => NETDEV_GetPTZPresetList(lpUserID, dwChannelID, ref lpOutBuffer);
        int INetDevSdkProxy.NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight) => NETDEV_GetResolution(lpRealHandle, ref pdwWidth, ref pdwHeight);
        int INetDevSdkProxy.NETDEV_GetSDKVersion() => NETDEV_GetSDKVersion();
        int INetDevSdkProxy.NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, uint udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo) => NETDEV_GetSinglePermGroupInfo(lpUserID, udwPermissionGroupID, ref pstAcsPerssionInfo);
        int INetDevSdkProxy.NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref int pdwVolume) => NETDEV_GetSoundVolume(lpPlayHandle, ref pdwVolume);
        int INetDevSdkProxy.NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, uint udwSize, IntPtr pszdata) => NETDEV_GetSystemPicture(lpUserID, pszURL, udwSize, pszdata);
        int INetDevSdkProxy.NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => NETDEV_GetSystemTimeCfg(lpUserID, ref pstSystemTimeInfo);
        int INetDevSdkProxy.NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate) => NETDEV_GetTimeTemplate(lpFindHandle, ref pstTimeTemplate);
        int INetDevSdkProxy.NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, int dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo) => NETDEV_GetTimeTemplateInfo(lpUserID, dwTemplateID, ref pstTimeTemplateInfo);
        int INetDevSdkProxy.NETDEV_GetTimeTemplateList(IntPtr lpUserID, int dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList) => NETDEV_GetTimeTemplateList(lpUserID, dwTamplateType, ref pstTemplateList);
        int INetDevSdkProxy.NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic) => NETDEV_GetTrafficStatistic(lpUserID, ref pstStatisticCond, ref pstTrafficStatistic);
        int INetDevSdkProxy.NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, uint udwSearchID, ref uint pudwProgress) => NETDEV_GetTrafficStatisticProgress(lpUserID, udwSearchID, ref pudwProgress);
        int INetDevSdkProxy.NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => NETDEV_GetUpnpNatState(lpUserID, ref pstNatState);
        int INetDevSdkProxy.NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo) => NETDEV_GetUserDetailInfoV30(lpFindHandle, ref pstUserDetailInfo);
        int INetDevSdkProxy.NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList) => NETDEV_GetUserDetailList(lpUserID, pstUserDetailList);
        int INetDevSdkProxy.NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => NETDEV_GetVehicleMonitorInfo(lpUserID, udwID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, uint udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo) => NETDEV_GetVehicleRecordImageInfo(lpUserID, udwRecordID, ref pstFileInfo);
        int INetDevSdkProxy.NETDEV_GetVideoDayNums(IntPtr lpUserID, int dwChannelID, ref int dwDayNums) => NETDEV_GetVideoDayNums(lpUserID, dwChannelID, ref dwDayNums);
        int INetDevSdkProxy.NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => NETDEV_GetVideoEffect(lpRealHandle, ref pstImageInfo);
        int INetDevSdkProxy.NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt) => NETDEV_GetVideoEncodeFmt(lpRealHandle, ref pdwVideoEncFmt);
        int INetDevSdkProxy.NETDEV_Init() => NETDEV_Init();
        int INetDevSdkProxy.NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, int dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam) => NETDEV_InputVoiceData(lpUserID, lpDataBuf, dwDataLen, ref pstVoiceParam);
        IntPtr INetDevSdkProxy.NETDEV_Login(string szDevIP, short wDevPort, string szUserName, string szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo) => NETDEV_Login(szDevIP, wDevPort, szUserName, szPassword, ref pstDevInfo);
        IntPtr INetDevSdkProxy.NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo) => NETDEV_Login_V30(ref pstDevLoginInfo, ref pstSELogInfo);
        int INetDevSdkProxy.NETDEV_Logout(IntPtr lpUserID) => NETDEV_Logout(lpUserID);
        int INetDevSdkProxy.NETDEV_MakeKeyFrame(IntPtr lpUserID, int dwChannelID, int dwStreamType) => NETDEV_MakeKeyFrame(lpUserID, dwChannelID, dwStreamType);
        int INetDevSdkProxy.NETDEV_MicVolumeControl(IntPtr lpPlayHandle, int dwVolume) => NETDEV_MicVolumeControl(lpPlayHandle, dwVolume);
        int INetDevSdkProxy.NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => NETDEV_ModifyACSPersonBlackList(lpUserID, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_ModifyACSPersonPermissionGroup(lpUserID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, string szOldPassword, string szNewPassword) => NETDEV_ModifyCurrentPin(lpFindHandle, szOldPassword, szNewPassword);
        int INetDevSdkProxy.NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName) => NETDEV_ModifyDeviceName(lpUserID, strDeviceName);
        int INetDevSdkProxy.NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo) => NETDEV_ModifyOrgInfo(lpUserID, ref pstOrgInfo);
        int INetDevSdkProxy.NETDEV_ModifyPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => NETDEV_ModifyPersonInfo(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int INetDevSdkProxy.NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList) => NETDEV_ModifyPersonLibInfo(lpUserID, ref pstPersonLibList);
        int INetDevSdkProxy.NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, uint udwUserID, ref NETDEV_ID_LIST_S pstRoleList) => NETDEV_ModifyRoleInfoOfUser(lpFindHandle, udwUserID, ref pstRoleList);
        int INetDevSdkProxy.NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo) => NETDEV_ModifyUser(lpUserID, pstUserInfo);
        int INetDevSdkProxy.NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo) => NETDEV_ModifyUserV30(lpFindHandle, ref pstUserModifyInfo);
        int INetDevSdkProxy.NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList) => NETDEV_ModifyVehicleLibInfo(lpUserID, ref pstVehicleLibList);
        int INetDevSdkProxy.NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => NETDEV_ModifyVehicleMemberInfo(lpUserID, udwVehicleLibID, ref pstVehicleMemberList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_OpenMic(IntPtr lpPlayHandle) => NETDEV_OpenMic(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_OpenSound(IntPtr lpRealHandle) => NETDEV_OpenSound(lpRealHandle);
        IntPtr INetDevSdkProxy.NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo) => NETDEV_PlayBackByName(lpUserID, ref pstPlayBackInfo);
        IntPtr INetDevSdkProxy.NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo) => NETDEV_PlayBackByTime(lpUserID, ref pstPlayBackInfo);
        int INetDevSdkProxy.NETDEV_PlayBackControl(IntPtr lpPlayHandle, int dwControlCode, ref long pdwBuffer) => NETDEV_PlayBackControl(lpPlayHandle, dwControlCode, ref pdwBuffer);
        int INetDevSdkProxy.NETDEV_PlaySound(IntPtr lpRealHandle) => NETDEV_PlaySound(lpRealHandle);
        int INetDevSdkProxy.NETDEV_PTZAbsoluteMove(IntPtr lpUserID, int dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove) => NETDEV_PTZAbsoluteMove(lpUserID, dwChannelID, pstAbsoluteMove);
        int INetDevSdkProxy.NETDEV_PTZCalibrate(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo) => NETDEV_PTZCalibrate(lpUserID, dwChannelID, ref pstOrientationInfo);
        int INetDevSdkProxy.NETDEV_PTZControl(IntPtr lpPlayHandle, int dwPTZCommand, int dwSpeed) => NETDEV_PTZControl(lpPlayHandle, dwPTZCommand, dwSpeed);
        int INetDevSdkProxy.NETDEV_PTZControl_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCommand, int dwSpeed) => NETDEV_PTZControl_Other(lpUserID, dwChannelID, dwPTZCommand, dwSpeed);
        int INetDevSdkProxy.NETDEV_PTZCruise_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo) => NETDEV_PTZCruise_Other(lpUserID, dwChannelID, dwPTZCruiseCmd, ref pstCruiseInfo);
        int INetDevSdkProxy.NETDEV_PTZGetCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList) => NETDEV_PTZGetCruise(lpUserID, dwChannelID, ref pstCruiseList);
        int INetDevSdkProxy.NETDEV_PTZGetStatus(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus) => NETDEV_PTZGetStatus(lpUserID, dwChannelID, ref pstPTZStaus);
        int INetDevSdkProxy.NETDEV_PTZGetTrackCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo) => NETDEV_PTZGetTrackCruise(lpUserID, dwChannelID, ref pstTrackCruiseInfo);
        int INetDevSdkProxy.NETDEV_PTZPreset(IntPtr lpPlayHandle, int dwPTZPresetCmd, string pszPresetName, int dwPresetID) => NETDEV_PTZPreset(lpPlayHandle, dwPTZPresetCmd, pszPresetName, dwPresetID);
        int INetDevSdkProxy.NETDEV_PTZPreset_Other(IntPtr lpUserID, int dwChannelID, int dwPTZPresetCmd, byte[] szPresetName, int dwPresetID) => NETDEV_PTZPreset_Other(lpUserID, dwChannelID, dwPTZPresetCmd, szPresetName, dwPresetID);
        int INetDevSdkProxy.NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea) => NETDEV_PTZSelZoomIn_Other(lpUserID, dwChannelID, ref pstPtzOperateArea);
        int INetDevSdkProxy.NETDEV_PTZTrackCruise(IntPtr lpUserID, int dwChannelID, int dwPTZTrackCruiseCmd, string pszTrackCruiseName) => NETDEV_PTZTrackCruise(lpUserID, dwChannelID, dwPTZTrackCruiseCmd, pszTrackCruiseName);
        int INetDevSdkProxy.NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList) => NETDEV_QueryRecordRange(lpUserID, ref pstChlList, ref pstRecordTimeList);
        int INetDevSdkProxy.NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList) => NETDEV_QueryVideoChlDetailList(lpUserID, ref pdwChlCount, pstVideoChlList);
        IntPtr INetDevSdkProxy.NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => NETDEV_RealPlay(lpUserID, ref pstPreviewInfo, cbPlayDataCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_Reboot(IntPtr lpUserID) => NETDEV_Reboot(lpUserID);
        int INetDevSdkProxy.NETDEV_ResetLostPacketRate(IntPtr lpRealHandle) => NETDEV_ResetLostPacketRate(lpRealHandle);
        int INetDevSdkProxy.NETDEV_RestoreConfig(IntPtr lpUserID) => NETDEV_RestoreConfig(lpUserID);
        int INetDevSdkProxy.NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, int dwFormat) => NETDEV_SaveRealData(lpRealHandle, szSaveFileName, dwFormat);
        int INetDevSdkProxy.NETDEV_SetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => NETDEV_SetACSPersonPermission(lpUserID, udwPersonID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmCallBack_V30(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetAlarmFGCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData) => NETDEV_SetCarPlateCallBack(lpUserID, cbCarPlateCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetConfigFile(IntPtr lpUserID, string strConfigPath) => NETDEV_SetConfigFile(lpUserID, strConfigPath);
        int INetDevSdkProxy.NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetConflagrationAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetConnectTime(int dwWaitTime, int dwTrytimes) => NETDEV_SetConnectTime(dwWaitTime, dwTrytimes);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref int index, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref index, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, lpInBuffer, ref dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwInBufferSize) => NETDEV_SetDevConfig(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect) => NETDEV_SetDigitalZoom(lpRealHandle, hWnd, pstRect);
        int INetDevSdkProxy.NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData) => NETDEV_SetDiscoveryCallBack(cbDiscoveryCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData) => NETDEV_SetExceptionCallBack(cbExceptionCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData) => NETDEV_SetFaceSnapshotCallBack(lpUserID, cbFaceSnapshotCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetIVAEnable(IntPtr lpUserID, int dwEnableIVA) => NETDEV_SetIVAEnable(lpUserID, dwEnableIVA);
        int INetDevSdkProxy.NETDEV_SetIVAShowParam(int dwShowParam) => NETDEV_SetIVAShowParam(dwShowParam);
        int INetDevSdkProxy.NETDEV_SetLogPath(string strLogPath) => NETDEV_SetLogPath(strLogPath);
        int INetDevSdkProxy.NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData) => NETDEV_SetPassengerFlowStatisticCallBack(lpUserID, cbPassengerFlowStatisticCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetPersonAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => NETDEV_SetPersonMonitorRuleInfo(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_SetPictureFluency(IntPtr lpPlayHandle, int dwFluency) => NETDEV_SetPictureFluency(lpPlayHandle, dwFluency);
        int INetDevSdkProxy.NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayDataCallBack(lpRealHandle, cbPlayDataCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayDecodeVideoCB(lpRealHandle, cbPlayDecodeVideoCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData) => NETDEV_SetPlayDisplayCB(lpRealHandle, cbPlayDisplayCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, int bContinue, IntPtr lpUserData) => NETDEV_SetPlayParseCB(lpRealHandle, cbPlayParseCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, int dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo) => NETDEV_SetPTZAbsolutePTInfo(lpUserID, dwChannelID, pstPTPositionInfo);
        int INetDevSdkProxy.NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, int dwChannelID, float fZoomRatio) => NETDEV_SetPTZAbsoluteZoomInfo(lpUserID, dwChannelID, fZoomRatio);
        int INetDevSdkProxy.NETDEV_SetRenderScale(IntPtr lpRealHandle, int enRenderScale) => NETDEV_SetRenderScale(lpRealHandle, enRenderScale);
        int INetDevSdkProxy.NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout) => NETDEV_SetRevTimeOut(ref pstRevTimeout);
        int INetDevSdkProxy.NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetStructAlarmCallBack(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => NETDEV_SetSystemTimeCfg(lpUserID, ref pstSystemTimeInfo);
        int INetDevSdkProxy.NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => NETDEV_SetUpnpNatState(lpUserID, ref pstNatState);
        int INetDevSdkProxy.NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData) => NETDEV_SetVehicleAlarmCallBack(lpUserID, cbVehicleAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => NETDEV_SetVehicleMonitorInfo(lpUserID, udwID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => NETDEV_SetVideoEffect(lpRealHandle, ref pstImageInfo);
        int INetDevSdkProxy.NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, int dwVolume) => NETDEV_SoundVolumeControl(lpPlayHandle, dwVolume);
        IntPtr INetDevSdkProxy.NETDEV_StartInputVoiceSrv(IntPtr lpUserID, int dwChannelID) => NETDEV_StartInputVoiceSrv(lpUserID, dwChannelID);
        int INetDevSdkProxy.NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref uint udwSearchID) => NETDEV_StartMultiTrafficStatistic(lpUserID, ref pstStatisticCond, ref udwSearchID);
        IntPtr INetDevSdkProxy.NETDEV_StartVoiceCom(IntPtr lpUserID, int dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => NETDEV_StartVoiceCom(lpUserID, dwChannelID, cbPlayDataCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_StopGetFile(IntPtr lpPlayHandle) => NETDEV_StopGetFile(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle) => NETDEV_StopInputVoiceSrv(lpVoiceComHandle);
        int INetDevSdkProxy.NETDEV_StopPlayBack(IntPtr lpPlayHandle) => NETDEV_StopPlayBack(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_StopPlaySound(IntPtr lpRealHandle) => NETDEV_StopPlaySound(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopRealPlay(IntPtr lpRealHandle) => NETDEV_StopRealPlay(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopSaveRealData(IntPtr lpRealHandle) => NETDEV_StopSaveRealData(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopTrafficStatistic(IntPtr lpUserID, uint udwSearchID) => NETDEV_StopTrafficStatistic(lpUserID, udwSearchID);
        int INetDevSdkProxy.NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle) => NETDEV_StopVoiceCom(lpVoiceComHandle);
        int INetDevSdkProxy.NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo) => NETDEV_SubscibeLapiAlarm(lpUserID, ref pstSubInfo, ref pstSubSuccInfo);
        int INetDevSdkProxy.NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo) => NETDEV_SubscribeSmart(lpUserID, ref pstSubscribeInfo, ref pstSmartInfo);
        int INetDevSdkProxy.NETDEV_UnSubLapiAlarm(IntPtr lpUserID, uint udwID) => NETDEV_UnSubLapiAlarm(lpUserID, udwID);
        int INetDevSdkProxy.NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo) => NETDEV_UnsubscribeSmart(lpUserID, ref pstSmartInfo);
        void INetDevSdkProxy.OutputDebugString(string message) => OutputDebugString(message);
        #endregion // 显示实现
    }
    internal class NetDevSdkLoader : ASdkDynamicLoader, INetDevSdkProxy
    {
        #region // 委托定义
        private DCreater.MemCopy _MemCopy;
        private DCreater.OutputDebugString _OutputDebugString;
        private DCreater.NETDEV_ACSPersonCtrl _NETDEV_ACSPersonCtrl;
        private DCreater.NETDEV_AddACSPersonBlackList _NETDEV_AddACSPersonBlackList;
        private DCreater.NETDEV_AddACSPersonList _NETDEV_AddACSPersonList;
        private DCreater.NETDEV_AddACSPersonPermissionGroup _NETDEV_AddACSPersonPermissionGroup;
        private DCreater.NETDEV_AddOrgInfo _NETDEV_AddOrgInfo;
        private DCreater.NETDEV_AddPersonInfo _NETDEV_AddPersonInfo;
        private DCreater.NETDEV_AddPersonMonitorInfo _NETDEV_AddPersonMonitorInfo;
        private DCreater.NETDEV_AddUserV30 _NETDEV_AddUserV30;
        private DCreater.NETDEV_AddVehicleLibInfo _NETDEV_AddVehicleLibInfo;
        private DCreater.NETDEV_AddVehicleLibMember _NETDEV_AddVehicleLibMember;
        private DCreater.NETDEV_AddVehicleMemberList _NETDEV_AddVehicleMemberList;
        private DCreater.NETDEV_AddVehicleMonitorInfo _NETDEV_AddVehicleMonitorInfo;
        private DCreater.NETDEV_BatchDeleteOrgInfo _NETDEV_BatchDeleteOrgInfo;
        private DCreater.NETDEV_BatchDeletePersonMonitorInfo _NETDEV_BatchDeletePersonMonitorInfo;
        private DCreater.NETDEV_CaptureNoPreview _NETDEV_CaptureNoPreview;
        private DCreater.NETDEV_CapturePicture _NETDEV_CapturePicture;
        private DCreater.NETDEV_Cleanup _NETDEV_Cleanup;
        private DCreater.NETDEV_CloseMic _NETDEV_CloseMic;
        private DCreater.NETDEV_CloseSound _NETDEV_CloseSound;
        private DCreater.NETDEV_CreatePersonLibInfo _NETDEV_CreatePersonLibInfo;
        private DCreater.NETDEV_CreateUser _NETDEV_CreateUser;
        private DCreater.NETDEV_DeleteACSPersonBlackList _NETDEV_DeleteACSPersonBlackList;
        private DCreater.NETDEV_DeleteACSPersonList _NETDEV_DeleteACSPersonList;
        private DCreater.NETDEV_DeleteACSPersonPermissionGroup _NETDEV_DeleteACSPersonPermissionGroup;
        private DCreater.NETDEV_DeletePersonInfo _NETDEV_DeletePersonInfo;
        private DCreater.NETDEV_DeletePersonInfoList _NETDEV_DeletePersonInfoList;
        private DCreater.NETDEV_DeletePersonLibInfo _NETDEV_DeletePersonLibInfo;
        private DCreater.NETDEV_DeleteUser _NETDEV_DeleteUser;
        private DCreater.NETDEV_DeleteUserV30 _NETDEV_DeleteUserV30;
        private DCreater.NETDEV_DeleteVehicleLibInfo _NETDEV_DeleteVehicleLibInfo;
        private DCreater.NETDEV_DeleteVehicleLibMember _NETDEV_DeleteVehicleLibMember;
        private DCreater.NETDEV_DeleteVehicleMonitorInfo _NETDEV_DeleteVehicleMonitorInfo;
        private DCreater.NETDEV_DelVehicleMemberList _NETDEV_DelVehicleMemberList;
        private DCreater.NETDEV_Discovery _NETDEV_Discovery;
        private DCreater.NETDEV_DoorBatchCtrl _NETDEV_DoorBatchCtrl;
        private DCreater.NETDEV_DoorCtrl _NETDEV_DoorCtrl;
        private DCreater.NETDEV_FindACSAttendanceLogList _NETDEV_FindACSAttendanceLogList;
        private DCreater.NETDEV_FindACSPermissionGroupList _NETDEV_FindACSPermissionGroupList;
        private DCreater.NETDEV_FindACSPersonBlackList _NETDEV_FindACSPersonBlackList;
        private DCreater.NETDEV_FindACSPersonList _NETDEV_FindACSPersonList;
        private DCreater.NETDEV_FindACSVisitLogList _NETDEV_FindACSVisitLogList;
        private DCreater.NETDEV_FindClose _NETDEV_FindClose;
        private DCreater.NETDEV_FindCloseACSAttendanceLogList _NETDEV_FindCloseACSAttendanceLogList;
        private DCreater.NETDEV_FindCloseACSPermissionGroupList _NETDEV_FindCloseACSPermissionGroupList;
        private DCreater.NETDEV_FindCloseACSPersonBlackList _NETDEV_FindCloseACSPersonBlackList;
        private DCreater.NETDEV_FindCloseACSPersonInfo _NETDEV_FindCloseACSPersonInfo;
        private DCreater.NETDEV_FindCloseACSVisitLog _NETDEV_FindCloseACSVisitLog;
        private DCreater.NETDEV_FindCloseDevChn _NETDEV_FindCloseDevChn;
        private DCreater.NETDEV_FindCloseDevInfo _NETDEV_FindCloseDevInfo;
        private DCreater.NETDEV_FindCloseFaceRecordDetail _NETDEV_FindCloseFaceRecordDetail;
        private DCreater.NETDEV_FindCloseMonitorStatusList _NETDEV_FindCloseMonitorStatusList;
        private DCreater.NETDEV_FindCloseOrgInfo _NETDEV_FindCloseOrgInfo;
        private DCreater.NETDEV_FindClosePermStatusList _NETDEV_FindClosePermStatusList;
        private DCreater.NETDEV_FindClosePersonInfoList _NETDEV_FindClosePersonInfoList;
        private DCreater.NETDEV_FindClosePersonLibList _NETDEV_FindClosePersonLibList;
        private DCreater.NETDEV_FindClosePersonMonitorList _NETDEV_FindClosePersonMonitorList;
        private DCreater.NETDEV_FindCloseRoleBaseInfoOfUserList _NETDEV_FindCloseRoleBaseInfoOfUserList;
        private DCreater.NETDEV_FindCloseRoleInfoList _NETDEV_FindCloseRoleInfoList;
        private DCreater.NETDEV_FindCloseTimeTemplateByTypeList _NETDEV_FindCloseTimeTemplateByTypeList;
        private DCreater.NETDEV_FindCloseTrafficStatisticInfo _NETDEV_FindCloseTrafficStatisticInfo;
        private DCreater.NETDEV_FindCloseUserDetailInfoListV30 _NETDEV_FindCloseUserDetailInfoListV30;
        private DCreater.NETDEV_FindCloseVehicleLibList _NETDEV_FindCloseVehicleLibList;
        private DCreater.NETDEV_FindCloseVehicleMemberDetail _NETDEV_FindCloseVehicleMemberDetail;
        private DCreater.NETDEV_FindCloseVehicleMonitorList _NETDEV_FindCloseVehicleMonitorList;
        private DCreater.NETDEV_FindCloseVehicleRecordList _NETDEV_FindCloseVehicleRecordList;
        private DCreater.NETDEV_FindDevChnList _NETDEV_FindDevChnList;
        private DCreater.NETDEV_FindDevList _NETDEV_FindDevList;
        private DCreater.NETDEV_FindFaceRecordDetailList _NETDEV_FindFaceRecordDetailList;
        private DCreater.NETDEV_FindFile _NETDEV_FindFile;
        private DCreater.NETDEV_FindMonitorStatusList _NETDEV_FindMonitorStatusList;
        private DCreater.NETDEV_FindNextACSAttendanceLog _NETDEV_FindNextACSAttendanceLog;
        private DCreater.NETDEV_FindNextACSPermissionGroupInfo _NETDEV_FindNextACSPermissionGroupInfo;
        private DCreater.NETDEV_FindNextACSPersonBlackListInfo _NETDEV_FindNextACSPersonBlackListInfo;
        private DCreater.NETDEV_FindNextACSPersonInfo _NETDEV_FindNextACSPersonInfo;
        private DCreater.NETDEV_FindNextACSVisitLog _NETDEV_FindNextACSVisitLog;
        private DCreater.NETDEV_FindNextDevChn _NETDEV_FindNextDevChn;
        private DCreater.NETDEV_FindNextDevInfo _NETDEV_FindNextDevInfo;
        private DCreater.NETDEV_FindNextFaceRecordDetail _NETDEV_FindNextFaceRecordDetail;
        private DCreater.NETDEV_FindNextFile _NETDEV_FindNextFile;
        private DCreater.NETDEV_FindNextMonitorStatusInfo _NETDEV_FindNextMonitorStatusInfo;
        private DCreater.NETDEV_FindNextOrgInfo _NETDEV_FindNextOrgInfo;
        private DCreater.NETDEV_FindNextPermStatusInfo _NETDEV_FindNextPermStatusInfo;
        private DCreater.NETDEV_FindNextPersonInfo _NETDEV_FindNextPersonInfo;
        private DCreater.NETDEV_FindNextPersonLibInfo _NETDEV_FindNextPersonLibInfo;
        private DCreater.NETDEV_FindNextPersonMonitorInfo _NETDEV_FindNextPersonMonitorInfo;
        private DCreater.NETDEV_FindNextRoleBaseInfoOfUser _NETDEV_FindNextRoleBaseInfoOfUser;
        private DCreater.NETDEV_FindNextRoleInfo _NETDEV_FindNextRoleInfo;
        private DCreater.NETDEV_FindNextTimeTemplateByTypeInfo _NETDEV_FindNextTimeTemplateByTypeInfo;
        private DCreater.NETDEV_FindNextTrafficStatisticInfo _NETDEV_FindNextTrafficStatisticInfo;
        private DCreater.NETDEV_FindNextUserDetailInfoV30 _NETDEV_FindNextUserDetailInfoV30;
        private DCreater.NETDEV_FindNextVehicleLibInfo _NETDEV_FindNextVehicleLibInfo;
        private DCreater.NETDEV_FindNextVehicleMemberDetail _NETDEV_FindNextVehicleMemberDetail;
        private DCreater.NETDEV_FindNextVehicleMonitorInfo _NETDEV_FindNextVehicleMonitorInfo;
        private DCreater.NETDEV_FindNextVehicleRecordInfo _NETDEV_FindNextVehicleRecordInfo;
        private DCreater.NETDEV_FindOrgInfoList _NETDEV_FindOrgInfoList;
        private DCreater.NETDEV_FindPermStatusList _NETDEV_FindPermStatusList;
        private DCreater.NETDEV_FindPersonInfoList _NETDEV_FindPersonInfoList;
        private DCreater.NETDEV_FindPersonLibList _NETDEV_FindPersonLibList;
        private DCreater.NETDEV_FindPersonMonitorList _NETDEV_FindPersonMonitorList;
        private DCreater.NETDEV_FindRoleBaseInfoOfUserList _NETDEV_FindRoleBaseInfoOfUserList;
        private DCreater.NETDEV_FindRoleInfoList _NETDEV_FindRoleInfoList;
        private DCreater.NETDEV_FindTimeTemplateByTypeList _NETDEV_FindTimeTemplateByTypeList;
        private DCreater.NETDEV_FindTrafficStatisticInfoList _NETDEV_FindTrafficStatisticInfoList;
        private DCreater.NETDEV_FindUserDetailInfoListV30 _NETDEV_FindUserDetailInfoListV30;
        private DCreater.NETDEV_FindVehicleLibList _NETDEV_FindVehicleLibList;
        private DCreater.NETDEV_FindVehicleMemberDetailList _NETDEV_FindVehicleMemberDetailList;
        private DCreater.NETDEV_FindVehicleMonitorList _NETDEV_FindVehicleMonitorList;
        private DCreater.NETDEV_FindVehicleRecordInfoList _NETDEV_FindVehicleRecordInfoList;
        private DCreater.NETDEV_GetACSPersonBlackList _NETDEV_GetACSPersonBlackList;
        private DCreater.NETDEV_GetACSPersonPermission _NETDEV_GetACSPersonPermission;
        private DCreater.NETDEV_GetBitRate _NETDEV_GetBitRate;
        private DCreater.NETDEV_GetChnDetailByChnType _NETDEV_GetChnDetailByChnType;
        private DCreater.NETDEV_GetChnType _NETDEV_GetChnType;
        private DCreater.NETDEV_GetCompassInfo _NETDEV_GetCompassInfo;
        private DCreater.NETDEV_GetConfigFile _NETDEV_GetConfigFile;
        private DCreater.NETDEV_GetDevConfig1 _NETDEV_GetDevConfig1;
        private DCreater.NETDEV_GetDevConfig2 _NETDEV_GetDevConfig2;
        private DCreater.NETDEV_GetDevConfig3 _NETDEV_GetDevConfig3;
        private DCreater.NETDEV_GetDevConfig4 _NETDEV_GetDevConfig4;
        private DCreater.NETDEV_GetDevConfig5 _NETDEV_GetDevConfig5;
        private DCreater.NETDEV_GetDevConfig6 _NETDEV_GetDevConfig6;
        private DCreater.NETDEV_GetDevConfig7 _NETDEV_GetDevConfig7;
        private DCreater.NETDEV_GetDevConfig8 _NETDEV_GetDevConfig8;
        private DCreater.NETDEV_GetDevConfig9 _NETDEV_GetDevConfig9;
        private DCreater.NETDEV_GetDevConfigA _NETDEV_GetDevConfigA;
        private DCreater.NETDEV_GetDevConfigB _NETDEV_GetDevConfigB;
        private DCreater.NETDEV_GetDevConfigC _NETDEV_GetDevConfigC;
        private DCreater.NETDEV_GetDevConfigD _NETDEV_GetDevConfigD;
        private DCreater.NETDEV_GetDevConfigE _NETDEV_GetDevConfigE;
        private DCreater.NETDEV_GetDevConfigF _NETDEV_GetDevConfigF;
        private DCreater.NETDEV_GetDevConfigG _NETDEV_GetDevConfigG;
        private DCreater.NETDEV_GetDevConfigH _NETDEV_GetDevConfigH;
        private DCreater.NETDEV_GetDevConfigI _NETDEV_GetDevConfigI;
        private DCreater.NETDEV_GetDevConfigJ _NETDEV_GetDevConfigJ;
        private DCreater.NETDEV_GetDevConfigK _NETDEV_GetDevConfigK;
        private DCreater.NETDEV_GetDeviceInfo _NETDEV_GetDeviceInfo;
        private DCreater.NETDEV_GetDeviceInfo_V30 _NETDEV_GetDeviceInfo_V30;
        private DCreater.NETDEV_GetFaceRecordImageInfo _NETDEV_GetFaceRecordImageInfo;
        private DCreater.NETDEV_GetFileByName _NETDEV_GetFileByName;
        private DCreater.NETDEV_GetFileByTime _NETDEV_GetFileByTime;
        private DCreater.NETDEV_GetFrameRate _NETDEV_GetFrameRate;
        private DCreater.NETDEV_GetGeolocationInfo _NETDEV_GetGeolocationInfo;
        private DCreater.NETDEV_GetLastError _NETDEV_GetLastError;
        private DCreater.NETDEV_GetLostPacketRate _NETDEV_GetLostPacketRate;
        private DCreater.NETDEV_GetMicVolume _NETDEV_GetMicVolume;
        private DCreater.NETDEV_GetMonitorCapacity _NETDEV_GetMonitorCapacity;
        private DCreater.NETDEV_GetMonitorProgress _NETDEV_GetMonitorProgress;
        private DCreater.NETDEV_GetPersonLibCapacity _NETDEV_GetPersonLibCapacity;
        private DCreater.NETDEV_GetPersonMemberInfo _NETDEV_GetPersonMemberInfo;
        private DCreater.NETDEV_GetPersonMonitorRuleInfo _NETDEV_GetPersonMonitorRuleInfo;
        private DCreater.NETDEV_GetPTZAbsolutePTInfo _NETDEV_GetPTZAbsolutePTInfo;
        private DCreater.NETDEV_GetPTZAbsoluteZoomInfo _NETDEV_GetPTZAbsoluteZoomInfo;
        private DCreater.NETDEV_GetPTZPresetList _NETDEV_GetPTZPresetList;
        private DCreater.NETDEV_GetResolution _NETDEV_GetResolution;
        private DCreater.NETDEV_GetSDKVersion _NETDEV_GetSDKVersion;
        private DCreater.NETDEV_GetSinglePermGroupInfo _NETDEV_GetSinglePermGroupInfo;
        private DCreater.NETDEV_GetSoundVolume _NETDEV_GetSoundVolume;
        private DCreater.NETDEV_GetSystemPicture _NETDEV_GetSystemPicture;
        private DCreater.NETDEV_GetSystemTimeCfg _NETDEV_GetSystemTimeCfg;
        private DCreater.NETDEV_GetTimeTemplate _NETDEV_GetTimeTemplate;
        private DCreater.NETDEV_GetTimeTemplateInfo _NETDEV_GetTimeTemplateInfo;
        private DCreater.NETDEV_GetTimeTemplateList _NETDEV_GetTimeTemplateList;
        private DCreater.NETDEV_GetTrafficStatistic _NETDEV_GetTrafficStatistic;
        private DCreater.NETDEV_GetTrafficStatisticProgress _NETDEV_GetTrafficStatisticProgress;
        private DCreater.NETDEV_GetUpnpNatState _NETDEV_GetUpnpNatState;
        private DCreater.NETDEV_GetUserDetailInfoV30 _NETDEV_GetUserDetailInfoV30;
        private DCreater.NETDEV_GetUserDetailList _NETDEV_GetUserDetailList;
        private DCreater.NETDEV_GetVehicleMonitorInfo _NETDEV_GetVehicleMonitorInfo;
        private DCreater.NETDEV_GetVehicleRecordImageInfo _NETDEV_GetVehicleRecordImageInfo;
        private DCreater.NETDEV_GetVideoDayNums _NETDEV_GetVideoDayNums;
        private DCreater.NETDEV_GetVideoEffect _NETDEV_GetVideoEffect;
        private DCreater.NETDEV_GetVideoEncodeFmt _NETDEV_GetVideoEncodeFmt;
        private DCreater.NETDEV_Init _NETDEV_Init;
        private DCreater.NETDEV_InputVoiceData _NETDEV_InputVoiceData;
        private DCreater.NETDEV_Login _NETDEV_Login;
        private DCreater.NETDEV_Login_V30 _NETDEV_Login_V30;
        private DCreater.NETDEV_Logout _NETDEV_Logout;
        private DCreater.NETDEV_MakeKeyFrame _NETDEV_MakeKeyFrame;
        private DCreater.NETDEV_MicVolumeControl _NETDEV_MicVolumeControl;
        private DCreater.NETDEV_ModifyACSPersonBlackList _NETDEV_ModifyACSPersonBlackList;
        private DCreater.NETDEV_ModifyACSPersonPermissionGroup _NETDEV_ModifyACSPersonPermissionGroup;
        private DCreater.NETDEV_ModifyCurrentPin _NETDEV_ModifyCurrentPin;
        private DCreater.NETDEV_ModifyDeviceName _NETDEV_ModifyDeviceName;
        private DCreater.NETDEV_ModifyOrgInfo _NETDEV_ModifyOrgInfo;
        private DCreater.NETDEV_ModifyPersonInfo _NETDEV_ModifyPersonInfo;
        private DCreater.NETDEV_ModifyPersonLibInfo _NETDEV_ModifyPersonLibInfo;
        private DCreater.NETDEV_ModifyRoleInfoOfUser _NETDEV_ModifyRoleInfoOfUser;
        private DCreater.NETDEV_ModifyUser _NETDEV_ModifyUser;
        private DCreater.NETDEV_ModifyUserV30 _NETDEV_ModifyUserV30;
        private DCreater.NETDEV_ModifyVehicleLibInfo _NETDEV_ModifyVehicleLibInfo;
        private DCreater.NETDEV_ModifyVehicleMemberInfo _NETDEV_ModifyVehicleMemberInfo;
        private DCreater.NETDEV_OpenMic _NETDEV_OpenMic;
        private DCreater.NETDEV_OpenSound _NETDEV_OpenSound;
        private DCreater.NETDEV_PlayBackByName _NETDEV_PlayBackByName;
        private DCreater.NETDEV_PlayBackByTime _NETDEV_PlayBackByTime;
        private DCreater.NETDEV_PlayBackControl _NETDEV_PlayBackControl;
        private DCreater.NETDEV_PlaySound _NETDEV_PlaySound;
        private DCreater.NETDEV_PTZAbsoluteMove _NETDEV_PTZAbsoluteMove;
        private DCreater.NETDEV_PTZCalibrate _NETDEV_PTZCalibrate;
        private DCreater.NETDEV_PTZControl _NETDEV_PTZControl;
        private DCreater.NETDEV_PTZControl_Other _NETDEV_PTZControl_Other;
        private DCreater.NETDEV_PTZCruise_Other _NETDEV_PTZCruise_Other;
        private DCreater.NETDEV_PTZGetCruise _NETDEV_PTZGetCruise;
        private DCreater.NETDEV_PTZGetStatus _NETDEV_PTZGetStatus;
        private DCreater.NETDEV_PTZGetTrackCruise _NETDEV_PTZGetTrackCruise;
        private DCreater.NETDEV_PTZPreset _NETDEV_PTZPreset;
        private DCreater.NETDEV_PTZPreset_Other _NETDEV_PTZPreset_Other;
        private DCreater.NETDEV_PTZSelZoomIn_Other _NETDEV_PTZSelZoomIn_Other;
        private DCreater.NETDEV_PTZTrackCruise _NETDEV_PTZTrackCruise;
        private DCreater.NETDEV_QueryRecordRange _NETDEV_QueryRecordRange;
        private DCreater.NETDEV_QueryVideoChlDetailList _NETDEV_QueryVideoChlDetailList;
        private DCreater.NETDEV_RealPlay _NETDEV_RealPlay;
        private DCreater.NETDEV_Reboot _NETDEV_Reboot;
        private DCreater.NETDEV_ResetLostPacketRate _NETDEV_ResetLostPacketRate;
        private DCreater.NETDEV_RestoreConfig _NETDEV_RestoreConfig;
        private DCreater.NETDEV_SaveRealData _NETDEV_SaveRealData;
        private DCreater.NETDEV_SetACSPersonPermission _NETDEV_SetACSPersonPermission;
        private DCreater.NETDEV_SetAlarmCallBack _NETDEV_SetAlarmCallBack;
        private DCreater.NETDEV_SetAlarmCallBack_V30 _NETDEV_SetAlarmCallBack_V30;
        private DCreater.NETDEV_SetAlarmFGCallBack _NETDEV_SetAlarmFGCallBack;
        private DCreater.NETDEV_SetCarPlateCallBack _NETDEV_SetCarPlateCallBack;
        private DCreater.NETDEV_SetConfigFile _NETDEV_SetConfigFile;
        private DCreater.NETDEV_SetConflagrationAlarmCallBack _NETDEV_SetConflagrationAlarmCallBack;
        private DCreater.NETDEV_SetConnectTime _NETDEV_SetConnectTime;
        private DCreater.NETDEV_SetDevConfig1 _NETDEV_SetDevConfig1;
        private DCreater.NETDEV_SetDevConfig2 _NETDEV_SetDevConfig2;
        private DCreater.NETDEV_SetDevConfig3 _NETDEV_SetDevConfig3;
        private DCreater.NETDEV_SetDevConfig4 _NETDEV_SetDevConfig4;
        private DCreater.NETDEV_SetDevConfig5 _NETDEV_SetDevConfig5;
        private DCreater.NETDEV_SetDevConfig6 _NETDEV_SetDevConfig6;
        private DCreater.NETDEV_SetDevConfig7 _NETDEV_SetDevConfig7;
        private DCreater.NETDEV_SetDevConfig8 _NETDEV_SetDevConfig8;
        private DCreater.NETDEV_SetDevConfig9 _NETDEV_SetDevConfig9;
        private DCreater.NETDEV_SetDevConfigA _NETDEV_SetDevConfigA;
        private DCreater.NETDEV_SetDevConfigB _NETDEV_SetDevConfigB;
        private DCreater.NETDEV_SetDevConfigC _NETDEV_SetDevConfigC;
        private DCreater.NETDEV_SetDevConfigD _NETDEV_SetDevConfigD;
        private DCreater.NETDEV_SetDevConfigE _NETDEV_SetDevConfigE;
        private DCreater.NETDEV_SetDevConfigF _NETDEV_SetDevConfigF;
        private DCreater.NETDEV_SetDevConfigG _NETDEV_SetDevConfigG;
        private DCreater.NETDEV_SetDevConfigH _NETDEV_SetDevConfigH;
        private DCreater.NETDEV_SetDigitalZoom _NETDEV_SetDigitalZoom;
        private DCreater.NETDEV_SetDiscoveryCallBack _NETDEV_SetDiscoveryCallBack;
        private DCreater.NETDEV_SetExceptionCallBack _NETDEV_SetExceptionCallBack;
        private DCreater.NETDEV_SetFaceSnapshotCallBack _NETDEV_SetFaceSnapshotCallBack;
        private DCreater.NETDEV_SetIVAEnable _NETDEV_SetIVAEnable;
        private DCreater.NETDEV_SetIVAShowParam _NETDEV_SetIVAShowParam;
        private DCreater.NETDEV_SetLogPath _NETDEV_SetLogPath;
        private DCreater.NETDEV_SetPassengerFlowStatisticCallBack _NETDEV_SetPassengerFlowStatisticCallBack;
        private DCreater.NETDEV_SetPersonAlarmCallBack _NETDEV_SetPersonAlarmCallBack;
        private DCreater.NETDEV_SetPersonMonitorRuleInfo _NETDEV_SetPersonMonitorRuleInfo;
        private DCreater.NETDEV_SetPictureFluency _NETDEV_SetPictureFluency;
        private DCreater.NETDEV_SetPlayDataCallBack _NETDEV_SetPlayDataCallBack;
        private DCreater.NETDEV_SetPlayDecodeVideoCB _NETDEV_SetPlayDecodeVideoCB;
        private DCreater.NETDEV_SetPlayDisplayCB _NETDEV_SetPlayDisplayCB;
        private DCreater.NETDEV_SetPlayParseCB _NETDEV_SetPlayParseCB;
        private DCreater.NETDEV_SetPTZAbsolutePTInfo _NETDEV_SetPTZAbsolutePTInfo;
        private DCreater.NETDEV_SetPTZAbsoluteZoomInfo _NETDEV_SetPTZAbsoluteZoomInfo;
        private DCreater.NETDEV_SetRenderScale _NETDEV_SetRenderScale;
        private DCreater.NETDEV_SetRevTimeOut _NETDEV_SetRevTimeOut;
        private DCreater.NETDEV_SetStructAlarmCallBack _NETDEV_SetStructAlarmCallBack;
        private DCreater.NETDEV_SetSystemTimeCfg _NETDEV_SetSystemTimeCfg;
        private DCreater.NETDEV_SetUpnpNatState _NETDEV_SetUpnpNatState;
        private DCreater.NETDEV_SetVehicleAlarmCallBack _NETDEV_SetVehicleAlarmCallBack;
        private DCreater.NETDEV_SetVehicleMonitorInfo _NETDEV_SetVehicleMonitorInfo;
        private DCreater.NETDEV_SetVideoEffect _NETDEV_SetVideoEffect;
        private DCreater.NETDEV_SoundVolumeControl _NETDEV_SoundVolumeControl;
        private DCreater.NETDEV_StartInputVoiceSrv _NETDEV_StartInputVoiceSrv;
        private DCreater.NETDEV_StartMultiTrafficStatistic _NETDEV_StartMultiTrafficStatistic;
        private DCreater.NETDEV_StartVoiceCom _NETDEV_StartVoiceCom;
        private DCreater.NETDEV_StopGetFile _NETDEV_StopGetFile;
        private DCreater.NETDEV_StopInputVoiceSrv _NETDEV_StopInputVoiceSrv;
        private DCreater.NETDEV_StopPlayBack _NETDEV_StopPlayBack;
        private DCreater.NETDEV_StopPlaySound _NETDEV_StopPlaySound;
        private DCreater.NETDEV_StopRealPlay _NETDEV_StopRealPlay;
        private DCreater.NETDEV_StopSaveRealData _NETDEV_StopSaveRealData;
        private DCreater.NETDEV_StopTrafficStatistic _NETDEV_StopTrafficStatistic;
        private DCreater.NETDEV_StopVoiceCom _NETDEV_StopVoiceCom;
        private DCreater.NETDEV_SubscibeLapiAlarm _NETDEV_SubscibeLapiAlarm;
        private DCreater.NETDEV_SubscribeSmart _NETDEV_SubscribeSmart;
        private DCreater.NETDEV_UnSubLapiAlarm _NETDEV_UnSubLapiAlarm;
        private DCreater.NETDEV_UnsubscribeSmart _NETDEV_UnsubscribeSmart;
        #endregion
        public NetDevSdkLoader()
        {
            //_MemCopy = GetDelegate<DCreater.MemCopy>(nameof(DCreater.MemCopy));
            //_OutputDebugString = GetDelegate<DCreater.OutputDebugString>(nameof(DCreater.OutputDebugString));
            _NETDEV_ACSPersonCtrl = GetDelegate<DCreater.NETDEV_ACSPersonCtrl>(nameof(DCreater.NETDEV_ACSPersonCtrl));
            _NETDEV_AddACSPersonBlackList = GetDelegate<DCreater.NETDEV_AddACSPersonBlackList>(nameof(DCreater.NETDEV_AddACSPersonBlackList));
            _NETDEV_AddACSPersonList = GetDelegate<DCreater.NETDEV_AddACSPersonList>(nameof(DCreater.NETDEV_AddACSPersonList));
            _NETDEV_AddACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_AddACSPersonPermissionGroup>(nameof(DCreater.NETDEV_AddACSPersonPermissionGroup));
            _NETDEV_AddOrgInfo = GetDelegate<DCreater.NETDEV_AddOrgInfo>(nameof(DCreater.NETDEV_AddOrgInfo));
            _NETDEV_AddPersonInfo = GetDelegate<DCreater.NETDEV_AddPersonInfo>(nameof(DCreater.NETDEV_AddPersonInfo));
            _NETDEV_AddPersonMonitorInfo = GetDelegate<DCreater.NETDEV_AddPersonMonitorInfo>(nameof(DCreater.NETDEV_AddPersonMonitorInfo));
            _NETDEV_AddUserV30 = GetDelegate<DCreater.NETDEV_AddUserV30>(nameof(DCreater.NETDEV_AddUserV30));
            _NETDEV_AddVehicleLibInfo = GetDelegate<DCreater.NETDEV_AddVehicleLibInfo>(nameof(DCreater.NETDEV_AddVehicleLibInfo));
            _NETDEV_AddVehicleLibMember = GetDelegate<DCreater.NETDEV_AddVehicleLibMember>(nameof(DCreater.NETDEV_AddVehicleLibMember));
            _NETDEV_AddVehicleMemberList = GetDelegate<DCreater.NETDEV_AddVehicleMemberList>(nameof(DCreater.NETDEV_AddVehicleMemberList));
            _NETDEV_AddVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_AddVehicleMonitorInfo>(nameof(DCreater.NETDEV_AddVehicleMonitorInfo));
            _NETDEV_BatchDeleteOrgInfo = GetDelegate<DCreater.NETDEV_BatchDeleteOrgInfo>(nameof(DCreater.NETDEV_BatchDeleteOrgInfo));
            _NETDEV_BatchDeletePersonMonitorInfo = GetDelegate<DCreater.NETDEV_BatchDeletePersonMonitorInfo>(nameof(DCreater.NETDEV_BatchDeletePersonMonitorInfo));
            _NETDEV_CaptureNoPreview = GetDelegate<DCreater.NETDEV_CaptureNoPreview>(nameof(DCreater.NETDEV_CaptureNoPreview));
            _NETDEV_CapturePicture = GetDelegate<DCreater.NETDEV_CapturePicture>(nameof(DCreater.NETDEV_CapturePicture));
            _NETDEV_Cleanup = GetDelegate<DCreater.NETDEV_Cleanup>(nameof(DCreater.NETDEV_Cleanup));
            _NETDEV_CloseMic = GetDelegate<DCreater.NETDEV_CloseMic>(nameof(DCreater.NETDEV_CloseMic));
            _NETDEV_CloseSound = GetDelegate<DCreater.NETDEV_CloseSound>(nameof(DCreater.NETDEV_CloseSound));
            _NETDEV_CreatePersonLibInfo = GetDelegate<DCreater.NETDEV_CreatePersonLibInfo>(nameof(DCreater.NETDEV_CreatePersonLibInfo));
            _NETDEV_CreateUser = GetDelegate<DCreater.NETDEV_CreateUser>(nameof(DCreater.NETDEV_CreateUser));
            _NETDEV_DeleteACSPersonBlackList = GetDelegate<DCreater.NETDEV_DeleteACSPersonBlackList>(nameof(DCreater.NETDEV_DeleteACSPersonBlackList));
            _NETDEV_DeleteACSPersonList = GetDelegate<DCreater.NETDEV_DeleteACSPersonList>(nameof(DCreater.NETDEV_DeleteACSPersonList));
            _NETDEV_DeleteACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_DeleteACSPersonPermissionGroup>(nameof(DCreater.NETDEV_DeleteACSPersonPermissionGroup));
            _NETDEV_DeletePersonInfo = GetDelegate<DCreater.NETDEV_DeletePersonInfo>(nameof(DCreater.NETDEV_DeletePersonInfo));
            _NETDEV_DeletePersonInfoList = GetDelegate<DCreater.NETDEV_DeletePersonInfoList>(nameof(DCreater.NETDEV_DeletePersonInfoList));
            _NETDEV_DeletePersonLibInfo = GetDelegate<DCreater.NETDEV_DeletePersonLibInfo>(nameof(DCreater.NETDEV_DeletePersonLibInfo));
            _NETDEV_DeleteUser = GetDelegate<DCreater.NETDEV_DeleteUser>(nameof(DCreater.NETDEV_DeleteUser));
            _NETDEV_DeleteUserV30 = GetDelegate<DCreater.NETDEV_DeleteUserV30>(nameof(DCreater.NETDEV_DeleteUserV30));
            _NETDEV_DeleteVehicleLibInfo = GetDelegate<DCreater.NETDEV_DeleteVehicleLibInfo>(nameof(DCreater.NETDEV_DeleteVehicleLibInfo));
            _NETDEV_DeleteVehicleLibMember = GetDelegate<DCreater.NETDEV_DeleteVehicleLibMember>(nameof(DCreater.NETDEV_DeleteVehicleLibMember));
            _NETDEV_DeleteVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_DeleteVehicleMonitorInfo>(nameof(DCreater.NETDEV_DeleteVehicleMonitorInfo));
            _NETDEV_DelVehicleMemberList = GetDelegate<DCreater.NETDEV_DelVehicleMemberList>(nameof(DCreater.NETDEV_DelVehicleMemberList));
            _NETDEV_Discovery = GetDelegate<DCreater.NETDEV_Discovery>(nameof(DCreater.NETDEV_Discovery));
            _NETDEV_DoorBatchCtrl = GetDelegate<DCreater.NETDEV_DoorBatchCtrl>(nameof(DCreater.NETDEV_DoorBatchCtrl));
            _NETDEV_DoorCtrl = GetDelegate<DCreater.NETDEV_DoorCtrl>(nameof(DCreater.NETDEV_DoorCtrl));
            _NETDEV_FindACSAttendanceLogList = GetDelegate<DCreater.NETDEV_FindACSAttendanceLogList>(nameof(DCreater.NETDEV_FindACSAttendanceLogList));
            _NETDEV_FindACSPermissionGroupList = GetDelegate<DCreater.NETDEV_FindACSPermissionGroupList>(nameof(DCreater.NETDEV_FindACSPermissionGroupList));
            _NETDEV_FindACSPersonBlackList = GetDelegate<DCreater.NETDEV_FindACSPersonBlackList>(nameof(DCreater.NETDEV_FindACSPersonBlackList));
            _NETDEV_FindACSPersonList = GetDelegate<DCreater.NETDEV_FindACSPersonList>(nameof(DCreater.NETDEV_FindACSPersonList));
            _NETDEV_FindACSVisitLogList = GetDelegate<DCreater.NETDEV_FindACSVisitLogList>(nameof(DCreater.NETDEV_FindACSVisitLogList));
            _NETDEV_FindClose = GetDelegate<DCreater.NETDEV_FindClose>(nameof(DCreater.NETDEV_FindClose));
            _NETDEV_FindCloseACSAttendanceLogList = GetDelegate<DCreater.NETDEV_FindCloseACSAttendanceLogList>(nameof(DCreater.NETDEV_FindCloseACSAttendanceLogList));
            _NETDEV_FindCloseACSPermissionGroupList = GetDelegate<DCreater.NETDEV_FindCloseACSPermissionGroupList>(nameof(DCreater.NETDEV_FindCloseACSPermissionGroupList));
            _NETDEV_FindCloseACSPersonBlackList = GetDelegate<DCreater.NETDEV_FindCloseACSPersonBlackList>(nameof(DCreater.NETDEV_FindCloseACSPersonBlackList));
            _NETDEV_FindCloseACSPersonInfo = GetDelegate<DCreater.NETDEV_FindCloseACSPersonInfo>(nameof(DCreater.NETDEV_FindCloseACSPersonInfo));
            _NETDEV_FindCloseACSVisitLog = GetDelegate<DCreater.NETDEV_FindCloseACSVisitLog>(nameof(DCreater.NETDEV_FindCloseACSVisitLog));
            _NETDEV_FindCloseDevChn = GetDelegate<DCreater.NETDEV_FindCloseDevChn>(nameof(DCreater.NETDEV_FindCloseDevChn));
            _NETDEV_FindCloseDevInfo = GetDelegate<DCreater.NETDEV_FindCloseDevInfo>(nameof(DCreater.NETDEV_FindCloseDevInfo));
            _NETDEV_FindCloseFaceRecordDetail = GetDelegate<DCreater.NETDEV_FindCloseFaceRecordDetail>(nameof(DCreater.NETDEV_FindCloseFaceRecordDetail));
            _NETDEV_FindCloseMonitorStatusList = GetDelegate<DCreater.NETDEV_FindCloseMonitorStatusList>(nameof(DCreater.NETDEV_FindCloseMonitorStatusList));
            _NETDEV_FindCloseOrgInfo = GetDelegate<DCreater.NETDEV_FindCloseOrgInfo>(nameof(DCreater.NETDEV_FindCloseOrgInfo));
            _NETDEV_FindClosePermStatusList = GetDelegate<DCreater.NETDEV_FindClosePermStatusList>(nameof(DCreater.NETDEV_FindClosePermStatusList));
            _NETDEV_FindClosePersonInfoList = GetDelegate<DCreater.NETDEV_FindClosePersonInfoList>(nameof(DCreater.NETDEV_FindClosePersonInfoList));
            _NETDEV_FindClosePersonLibList = GetDelegate<DCreater.NETDEV_FindClosePersonLibList>(nameof(DCreater.NETDEV_FindClosePersonLibList));
            _NETDEV_FindClosePersonMonitorList = GetDelegate<DCreater.NETDEV_FindClosePersonMonitorList>(nameof(DCreater.NETDEV_FindClosePersonMonitorList));
            _NETDEV_FindCloseRoleBaseInfoOfUserList = GetDelegate<DCreater.NETDEV_FindCloseRoleBaseInfoOfUserList>(nameof(DCreater.NETDEV_FindCloseRoleBaseInfoOfUserList));
            _NETDEV_FindCloseRoleInfoList = GetDelegate<DCreater.NETDEV_FindCloseRoleInfoList>(nameof(DCreater.NETDEV_FindCloseRoleInfoList));
            _NETDEV_FindCloseTimeTemplateByTypeList = GetDelegate<DCreater.NETDEV_FindCloseTimeTemplateByTypeList>(nameof(DCreater.NETDEV_FindCloseTimeTemplateByTypeList));
            _NETDEV_FindCloseTrafficStatisticInfo = GetDelegate<DCreater.NETDEV_FindCloseTrafficStatisticInfo>(nameof(DCreater.NETDEV_FindCloseTrafficStatisticInfo));
            _NETDEV_FindCloseUserDetailInfoListV30 = GetDelegate<DCreater.NETDEV_FindCloseUserDetailInfoListV30>(nameof(DCreater.NETDEV_FindCloseUserDetailInfoListV30));
            _NETDEV_FindCloseVehicleLibList = GetDelegate<DCreater.NETDEV_FindCloseVehicleLibList>(nameof(DCreater.NETDEV_FindCloseVehicleLibList));
            _NETDEV_FindCloseVehicleMemberDetail = GetDelegate<DCreater.NETDEV_FindCloseVehicleMemberDetail>(nameof(DCreater.NETDEV_FindCloseVehicleMemberDetail));
            _NETDEV_FindCloseVehicleMonitorList = GetDelegate<DCreater.NETDEV_FindCloseVehicleMonitorList>(nameof(DCreater.NETDEV_FindCloseVehicleMonitorList));
            _NETDEV_FindCloseVehicleRecordList = GetDelegate<DCreater.NETDEV_FindCloseVehicleRecordList>(nameof(DCreater.NETDEV_FindCloseVehicleRecordList));
            _NETDEV_FindDevChnList = GetDelegate<DCreater.NETDEV_FindDevChnList>(nameof(DCreater.NETDEV_FindDevChnList));
            _NETDEV_FindDevList = GetDelegate<DCreater.NETDEV_FindDevList>(nameof(DCreater.NETDEV_FindDevList));
            _NETDEV_FindFaceRecordDetailList = GetDelegate<DCreater.NETDEV_FindFaceRecordDetailList>(nameof(DCreater.NETDEV_FindFaceRecordDetailList));
            _NETDEV_FindFile = GetDelegate<DCreater.NETDEV_FindFile>(nameof(DCreater.NETDEV_FindFile));
            _NETDEV_FindMonitorStatusList = GetDelegate<DCreater.NETDEV_FindMonitorStatusList>(nameof(DCreater.NETDEV_FindMonitorStatusList));
            _NETDEV_FindNextACSAttendanceLog = GetDelegate<DCreater.NETDEV_FindNextACSAttendanceLog>(nameof(DCreater.NETDEV_FindNextACSAttendanceLog));
            _NETDEV_FindNextACSPermissionGroupInfo = GetDelegate<DCreater.NETDEV_FindNextACSPermissionGroupInfo>(nameof(DCreater.NETDEV_FindNextACSPermissionGroupInfo));
            _NETDEV_FindNextACSPersonBlackListInfo = GetDelegate<DCreater.NETDEV_FindNextACSPersonBlackListInfo>(nameof(DCreater.NETDEV_FindNextACSPersonBlackListInfo));
            _NETDEV_FindNextACSPersonInfo = GetDelegate<DCreater.NETDEV_FindNextACSPersonInfo>(nameof(DCreater.NETDEV_FindNextACSPersonInfo));
            _NETDEV_FindNextACSVisitLog = GetDelegate<DCreater.NETDEV_FindNextACSVisitLog>(nameof(DCreater.NETDEV_FindNextACSVisitLog));
            _NETDEV_FindNextDevChn = GetDelegate<DCreater.NETDEV_FindNextDevChn>(nameof(DCreater.NETDEV_FindNextDevChn));
            _NETDEV_FindNextDevInfo = GetDelegate<DCreater.NETDEV_FindNextDevInfo>(nameof(DCreater.NETDEV_FindNextDevInfo));
            _NETDEV_FindNextFaceRecordDetail = GetDelegate<DCreater.NETDEV_FindNextFaceRecordDetail>(nameof(DCreater.NETDEV_FindNextFaceRecordDetail));
            _NETDEV_FindNextFile = GetDelegate<DCreater.NETDEV_FindNextFile>(nameof(DCreater.NETDEV_FindNextFile));
            _NETDEV_FindNextMonitorStatusInfo = GetDelegate<DCreater.NETDEV_FindNextMonitorStatusInfo>(nameof(DCreater.NETDEV_FindNextMonitorStatusInfo));
            _NETDEV_FindNextOrgInfo = GetDelegate<DCreater.NETDEV_FindNextOrgInfo>(nameof(DCreater.NETDEV_FindNextOrgInfo));
            _NETDEV_FindNextPermStatusInfo = GetDelegate<DCreater.NETDEV_FindNextPermStatusInfo>(nameof(DCreater.NETDEV_FindNextPermStatusInfo));
            _NETDEV_FindNextPersonInfo = GetDelegate<DCreater.NETDEV_FindNextPersonInfo>(nameof(DCreater.NETDEV_FindNextPersonInfo));
            _NETDEV_FindNextPersonLibInfo = GetDelegate<DCreater.NETDEV_FindNextPersonLibInfo>(nameof(DCreater.NETDEV_FindNextPersonLibInfo));
            _NETDEV_FindNextPersonMonitorInfo = GetDelegate<DCreater.NETDEV_FindNextPersonMonitorInfo>(nameof(DCreater.NETDEV_FindNextPersonMonitorInfo));
            _NETDEV_FindNextRoleBaseInfoOfUser = GetDelegate<DCreater.NETDEV_FindNextRoleBaseInfoOfUser>(nameof(DCreater.NETDEV_FindNextRoleBaseInfoOfUser));
            _NETDEV_FindNextRoleInfo = GetDelegate<DCreater.NETDEV_FindNextRoleInfo>(nameof(DCreater.NETDEV_FindNextRoleInfo));
            _NETDEV_FindNextTimeTemplateByTypeInfo = GetDelegate<DCreater.NETDEV_FindNextTimeTemplateByTypeInfo>(nameof(DCreater.NETDEV_FindNextTimeTemplateByTypeInfo));
            _NETDEV_FindNextTrafficStatisticInfo = GetDelegate<DCreater.NETDEV_FindNextTrafficStatisticInfo>(nameof(DCreater.NETDEV_FindNextTrafficStatisticInfo));
            _NETDEV_FindNextUserDetailInfoV30 = GetDelegate<DCreater.NETDEV_FindNextUserDetailInfoV30>(nameof(DCreater.NETDEV_FindNextUserDetailInfoV30));
            _NETDEV_FindNextVehicleLibInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleLibInfo>(nameof(DCreater.NETDEV_FindNextVehicleLibInfo));
            _NETDEV_FindNextVehicleMemberDetail = GetDelegate<DCreater.NETDEV_FindNextVehicleMemberDetail>(nameof(DCreater.NETDEV_FindNextVehicleMemberDetail));
            _NETDEV_FindNextVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleMonitorInfo>(nameof(DCreater.NETDEV_FindNextVehicleMonitorInfo));
            _NETDEV_FindNextVehicleRecordInfo = GetDelegate<DCreater.NETDEV_FindNextVehicleRecordInfo>(nameof(DCreater.NETDEV_FindNextVehicleRecordInfo));
            _NETDEV_FindOrgInfoList = GetDelegate<DCreater.NETDEV_FindOrgInfoList>(nameof(DCreater.NETDEV_FindOrgInfoList));
            _NETDEV_FindPermStatusList = GetDelegate<DCreater.NETDEV_FindPermStatusList>(nameof(DCreater.NETDEV_FindPermStatusList));
            _NETDEV_FindPersonInfoList = GetDelegate<DCreater.NETDEV_FindPersonInfoList>(nameof(DCreater.NETDEV_FindPersonInfoList));
            _NETDEV_FindPersonLibList = GetDelegate<DCreater.NETDEV_FindPersonLibList>(nameof(DCreater.NETDEV_FindPersonLibList));
            _NETDEV_FindPersonMonitorList = GetDelegate<DCreater.NETDEV_FindPersonMonitorList>(nameof(DCreater.NETDEV_FindPersonMonitorList));
            _NETDEV_FindRoleBaseInfoOfUserList = GetDelegate<DCreater.NETDEV_FindRoleBaseInfoOfUserList>(nameof(DCreater.NETDEV_FindRoleBaseInfoOfUserList));
            _NETDEV_FindRoleInfoList = GetDelegate<DCreater.NETDEV_FindRoleInfoList>(nameof(DCreater.NETDEV_FindRoleInfoList));
            _NETDEV_FindTimeTemplateByTypeList = GetDelegate<DCreater.NETDEV_FindTimeTemplateByTypeList>(nameof(DCreater.NETDEV_FindTimeTemplateByTypeList));
            _NETDEV_FindTrafficStatisticInfoList = GetDelegate<DCreater.NETDEV_FindTrafficStatisticInfoList>(nameof(DCreater.NETDEV_FindTrafficStatisticInfoList));
            _NETDEV_FindUserDetailInfoListV30 = GetDelegate<DCreater.NETDEV_FindUserDetailInfoListV30>(nameof(DCreater.NETDEV_FindUserDetailInfoListV30));
            _NETDEV_FindVehicleLibList = GetDelegate<DCreater.NETDEV_FindVehicleLibList>(nameof(DCreater.NETDEV_FindVehicleLibList));
            _NETDEV_FindVehicleMemberDetailList = GetDelegate<DCreater.NETDEV_FindVehicleMemberDetailList>(nameof(DCreater.NETDEV_FindVehicleMemberDetailList));
            _NETDEV_FindVehicleMonitorList = GetDelegate<DCreater.NETDEV_FindVehicleMonitorList>(nameof(DCreater.NETDEV_FindVehicleMonitorList));
            _NETDEV_FindVehicleRecordInfoList = GetDelegate<DCreater.NETDEV_FindVehicleRecordInfoList>(nameof(DCreater.NETDEV_FindVehicleRecordInfoList));
            _NETDEV_GetACSPersonBlackList = GetDelegate<DCreater.NETDEV_GetACSPersonBlackList>(nameof(DCreater.NETDEV_GetACSPersonBlackList));
            _NETDEV_GetACSPersonPermission = GetDelegate<DCreater.NETDEV_GetACSPersonPermission>(nameof(DCreater.NETDEV_GetACSPersonPermission));
            _NETDEV_GetBitRate = GetDelegate<DCreater.NETDEV_GetBitRate>(nameof(DCreater.NETDEV_GetBitRate));
            _NETDEV_GetChnDetailByChnType = GetDelegate<DCreater.NETDEV_GetChnDetailByChnType>(nameof(DCreater.NETDEV_GetChnDetailByChnType));
            _NETDEV_GetChnType = GetDelegate<DCreater.NETDEV_GetChnType>(nameof(DCreater.NETDEV_GetChnType));
            _NETDEV_GetCompassInfo = GetDelegate<DCreater.NETDEV_GetCompassInfo>(nameof(DCreater.NETDEV_GetCompassInfo));
            _NETDEV_GetConfigFile = GetDelegate<DCreater.NETDEV_GetConfigFile>(nameof(DCreater.NETDEV_GetConfigFile));
            _NETDEV_GetDevConfig1 = GetDelegate<DCreater.NETDEV_GetDevConfig1>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig2 = GetDelegate<DCreater.NETDEV_GetDevConfig2>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig3 = GetDelegate<DCreater.NETDEV_GetDevConfig3>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig4 = GetDelegate<DCreater.NETDEV_GetDevConfig4>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig5 = GetDelegate<DCreater.NETDEV_GetDevConfig5>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig6 = GetDelegate<DCreater.NETDEV_GetDevConfig6>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig7 = GetDelegate<DCreater.NETDEV_GetDevConfig7>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig8 = GetDelegate<DCreater.NETDEV_GetDevConfig8>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfig9 = GetDelegate<DCreater.NETDEV_GetDevConfig9>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigA = GetDelegate<DCreater.NETDEV_GetDevConfigA>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigB = GetDelegate<DCreater.NETDEV_GetDevConfigB>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigC = GetDelegate<DCreater.NETDEV_GetDevConfigC>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigD = GetDelegate<DCreater.NETDEV_GetDevConfigD>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigE = GetDelegate<DCreater.NETDEV_GetDevConfigE>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigF = GetDelegate<DCreater.NETDEV_GetDevConfigF>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigG = GetDelegate<DCreater.NETDEV_GetDevConfigG>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigH = GetDelegate<DCreater.NETDEV_GetDevConfigH>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigI = GetDelegate<DCreater.NETDEV_GetDevConfigI>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigJ = GetDelegate<DCreater.NETDEV_GetDevConfigJ>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDevConfigK = GetDelegate<DCreater.NETDEV_GetDevConfigK>(nameof(INetDevSdkProxy.NETDEV_GetDevConfig));
            _NETDEV_GetDeviceInfo = GetDelegate<DCreater.NETDEV_GetDeviceInfo>(nameof(DCreater.NETDEV_GetDeviceInfo));
            _NETDEV_GetDeviceInfo_V30 = GetDelegate<DCreater.NETDEV_GetDeviceInfo_V30>(nameof(DCreater.NETDEV_GetDeviceInfo_V30));
            _NETDEV_GetFaceRecordImageInfo = GetDelegate<DCreater.NETDEV_GetFaceRecordImageInfo>(nameof(DCreater.NETDEV_GetFaceRecordImageInfo));
            _NETDEV_GetFileByName = GetDelegate<DCreater.NETDEV_GetFileByName>(nameof(DCreater.NETDEV_GetFileByName));
            _NETDEV_GetFileByTime = GetDelegate<DCreater.NETDEV_GetFileByTime>(nameof(DCreater.NETDEV_GetFileByTime));
            _NETDEV_GetFrameRate = GetDelegate<DCreater.NETDEV_GetFrameRate>(nameof(DCreater.NETDEV_GetFrameRate));
            _NETDEV_GetGeolocationInfo = GetDelegate<DCreater.NETDEV_GetGeolocationInfo>(nameof(DCreater.NETDEV_GetGeolocationInfo));
            _NETDEV_GetLastError = GetDelegate<DCreater.NETDEV_GetLastError>(nameof(DCreater.NETDEV_GetLastError));
            _NETDEV_GetLostPacketRate = GetDelegate<DCreater.NETDEV_GetLostPacketRate>(nameof(DCreater.NETDEV_GetLostPacketRate));
            _NETDEV_GetMicVolume = GetDelegate<DCreater.NETDEV_GetMicVolume>(nameof(DCreater.NETDEV_GetMicVolume));
            _NETDEV_GetMonitorCapacity = GetDelegate<DCreater.NETDEV_GetMonitorCapacity>(nameof(DCreater.NETDEV_GetMonitorCapacity));
            //_NETDEV_GetMonitorProgress = GetDelegate<DCreater.NETDEV_GetMonitorProgress>(nameof(DCreater.NETDEV_GetMonitorProgress));
            _NETDEV_GetPersonLibCapacity = GetDelegate<DCreater.NETDEV_GetPersonLibCapacity>(nameof(DCreater.NETDEV_GetPersonLibCapacity));
            _NETDEV_GetPersonMemberInfo = GetDelegate<DCreater.NETDEV_GetPersonMemberInfo>(nameof(DCreater.NETDEV_GetPersonMemberInfo));
            _NETDEV_GetPersonMonitorRuleInfo = GetDelegate<DCreater.NETDEV_GetPersonMonitorRuleInfo>(nameof(DCreater.NETDEV_GetPersonMonitorRuleInfo));
            _NETDEV_GetPTZAbsolutePTInfo = GetDelegate<DCreater.NETDEV_GetPTZAbsolutePTInfo>(nameof(DCreater.NETDEV_GetPTZAbsolutePTInfo));
            _NETDEV_GetPTZAbsoluteZoomInfo = GetDelegate<DCreater.NETDEV_GetPTZAbsoluteZoomInfo>(nameof(DCreater.NETDEV_GetPTZAbsoluteZoomInfo));
            _NETDEV_GetPTZPresetList = GetDelegate<DCreater.NETDEV_GetPTZPresetList>(nameof(DCreater.NETDEV_GetPTZPresetList));
            _NETDEV_GetResolution = GetDelegate<DCreater.NETDEV_GetResolution>(nameof(DCreater.NETDEV_GetResolution));
            _NETDEV_GetSDKVersion = GetDelegate<DCreater.NETDEV_GetSDKVersion>(nameof(DCreater.NETDEV_GetSDKVersion));
            _NETDEV_GetSinglePermGroupInfo = GetDelegate<DCreater.NETDEV_GetSinglePermGroupInfo>(nameof(DCreater.NETDEV_GetSinglePermGroupInfo));
            _NETDEV_GetSoundVolume = GetDelegate<DCreater.NETDEV_GetSoundVolume>(nameof(DCreater.NETDEV_GetSoundVolume));
            _NETDEV_GetSystemPicture = GetDelegate<DCreater.NETDEV_GetSystemPicture>(nameof(DCreater.NETDEV_GetSystemPicture));
            _NETDEV_GetSystemTimeCfg = GetDelegate<DCreater.NETDEV_GetSystemTimeCfg>(nameof(DCreater.NETDEV_GetSystemTimeCfg));
            _NETDEV_GetTimeTemplate = GetDelegate<DCreater.NETDEV_GetTimeTemplate>(nameof(DCreater.NETDEV_GetTimeTemplate));
            _NETDEV_GetTimeTemplateInfo = GetDelegate<DCreater.NETDEV_GetTimeTemplateInfo>(nameof(DCreater.NETDEV_GetTimeTemplateInfo));
            _NETDEV_GetTimeTemplateList = GetDelegate<DCreater.NETDEV_GetTimeTemplateList>(nameof(DCreater.NETDEV_GetTimeTemplateList));
            _NETDEV_GetTrafficStatistic = GetDelegate<DCreater.NETDEV_GetTrafficStatistic>(nameof(DCreater.NETDEV_GetTrafficStatistic));
            _NETDEV_GetTrafficStatisticProgress = GetDelegate<DCreater.NETDEV_GetTrafficStatisticProgress>(nameof(DCreater.NETDEV_GetTrafficStatisticProgress));
            _NETDEV_GetUpnpNatState = GetDelegate<DCreater.NETDEV_GetUpnpNatState>(nameof(DCreater.NETDEV_GetUpnpNatState));
            _NETDEV_GetUserDetailInfoV30 = GetDelegate<DCreater.NETDEV_GetUserDetailInfoV30>(nameof(DCreater.NETDEV_GetUserDetailInfoV30));
            _NETDEV_GetUserDetailList = GetDelegate<DCreater.NETDEV_GetUserDetailList>(nameof(DCreater.NETDEV_GetUserDetailList));
            _NETDEV_GetVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_GetVehicleMonitorInfo>(nameof(DCreater.NETDEV_GetVehicleMonitorInfo));
            _NETDEV_GetVehicleRecordImageInfo = GetDelegate<DCreater.NETDEV_GetVehicleRecordImageInfo>(nameof(DCreater.NETDEV_GetVehicleRecordImageInfo));
            _NETDEV_GetVideoDayNums = GetDelegate<DCreater.NETDEV_GetVideoDayNums>(nameof(DCreater.NETDEV_GetVideoDayNums));
            _NETDEV_GetVideoEffect = GetDelegate<DCreater.NETDEV_GetVideoEffect>(nameof(DCreater.NETDEV_GetVideoEffect));
            _NETDEV_GetVideoEncodeFmt = GetDelegate<DCreater.NETDEV_GetVideoEncodeFmt>(nameof(DCreater.NETDEV_GetVideoEncodeFmt));
            _NETDEV_Init = GetDelegate<DCreater.NETDEV_Init>(nameof(DCreater.NETDEV_Init));
            _NETDEV_InputVoiceData = GetDelegate<DCreater.NETDEV_InputVoiceData>(nameof(DCreater.NETDEV_InputVoiceData));
            _NETDEV_Login = GetDelegate<DCreater.NETDEV_Login>(nameof(DCreater.NETDEV_Login));
            _NETDEV_Login_V30 = GetDelegate<DCreater.NETDEV_Login_V30>(nameof(DCreater.NETDEV_Login_V30));
            _NETDEV_Logout = GetDelegate<DCreater.NETDEV_Logout>(nameof(DCreater.NETDEV_Logout));
            _NETDEV_MakeKeyFrame = GetDelegate<DCreater.NETDEV_MakeKeyFrame>(nameof(DCreater.NETDEV_MakeKeyFrame));
            _NETDEV_MicVolumeControl = GetDelegate<DCreater.NETDEV_MicVolumeControl>(nameof(DCreater.NETDEV_MicVolumeControl));
            _NETDEV_ModifyACSPersonBlackList = GetDelegate<DCreater.NETDEV_ModifyACSPersonBlackList>(nameof(DCreater.NETDEV_ModifyACSPersonBlackList));
            _NETDEV_ModifyACSPersonPermissionGroup = GetDelegate<DCreater.NETDEV_ModifyACSPersonPermissionGroup>(nameof(DCreater.NETDEV_ModifyACSPersonPermissionGroup));
            _NETDEV_ModifyCurrentPin = GetDelegate<DCreater.NETDEV_ModifyCurrentPin>(nameof(DCreater.NETDEV_ModifyCurrentPin));
            _NETDEV_ModifyDeviceName = GetDelegate<DCreater.NETDEV_ModifyDeviceName>(nameof(DCreater.NETDEV_ModifyDeviceName));
            _NETDEV_ModifyOrgInfo = GetDelegate<DCreater.NETDEV_ModifyOrgInfo>(nameof(DCreater.NETDEV_ModifyOrgInfo));
            _NETDEV_ModifyPersonInfo = GetDelegate<DCreater.NETDEV_ModifyPersonInfo>(nameof(DCreater.NETDEV_ModifyPersonInfo));
            _NETDEV_ModifyPersonLibInfo = GetDelegate<DCreater.NETDEV_ModifyPersonLibInfo>(nameof(DCreater.NETDEV_ModifyPersonLibInfo));
            _NETDEV_ModifyRoleInfoOfUser = GetDelegate<DCreater.NETDEV_ModifyRoleInfoOfUser>(nameof(DCreater.NETDEV_ModifyRoleInfoOfUser));
            _NETDEV_ModifyUser = GetDelegate<DCreater.NETDEV_ModifyUser>(nameof(DCreater.NETDEV_ModifyUser));
            _NETDEV_ModifyUserV30 = GetDelegate<DCreater.NETDEV_ModifyUserV30>(nameof(DCreater.NETDEV_ModifyUserV30));
            _NETDEV_ModifyVehicleLibInfo = GetDelegate<DCreater.NETDEV_ModifyVehicleLibInfo>(nameof(DCreater.NETDEV_ModifyVehicleLibInfo));
            _NETDEV_ModifyVehicleMemberInfo = GetDelegate<DCreater.NETDEV_ModifyVehicleMemberInfo>(nameof(DCreater.NETDEV_ModifyVehicleMemberInfo));
            _NETDEV_OpenMic = GetDelegate<DCreater.NETDEV_OpenMic>(nameof(DCreater.NETDEV_OpenMic));
            _NETDEV_OpenSound = GetDelegate<DCreater.NETDEV_OpenSound>(nameof(DCreater.NETDEV_OpenSound));
            _NETDEV_PlayBackByName = GetDelegate<DCreater.NETDEV_PlayBackByName>(nameof(DCreater.NETDEV_PlayBackByName));
            _NETDEV_PlayBackByTime = GetDelegate<DCreater.NETDEV_PlayBackByTime>(nameof(DCreater.NETDEV_PlayBackByTime));
            _NETDEV_PlayBackControl = GetDelegate<DCreater.NETDEV_PlayBackControl>(nameof(DCreater.NETDEV_PlayBackControl));
            //_NETDEV_PlaySound = GetDelegate<DCreater.NETDEV_PlaySound>(nameof(DCreater.NETDEV_PlaySound));
            _NETDEV_PTZAbsoluteMove = GetDelegate<DCreater.NETDEV_PTZAbsoluteMove>(nameof(DCreater.NETDEV_PTZAbsoluteMove));
            _NETDEV_PTZCalibrate = GetDelegate<DCreater.NETDEV_PTZCalibrate>(nameof(DCreater.NETDEV_PTZCalibrate));
            _NETDEV_PTZControl = GetDelegate<DCreater.NETDEV_PTZControl>(nameof(DCreater.NETDEV_PTZControl));
            _NETDEV_PTZControl_Other = GetDelegate<DCreater.NETDEV_PTZControl_Other>(nameof(DCreater.NETDEV_PTZControl_Other));
            _NETDEV_PTZCruise_Other = GetDelegate<DCreater.NETDEV_PTZCruise_Other>(nameof(DCreater.NETDEV_PTZCruise_Other));
            _NETDEV_PTZGetCruise = GetDelegate<DCreater.NETDEV_PTZGetCruise>(nameof(DCreater.NETDEV_PTZGetCruise));
            _NETDEV_PTZGetStatus = GetDelegate<DCreater.NETDEV_PTZGetStatus>(nameof(DCreater.NETDEV_PTZGetStatus));
            _NETDEV_PTZGetTrackCruise = GetDelegate<DCreater.NETDEV_PTZGetTrackCruise>(nameof(DCreater.NETDEV_PTZGetTrackCruise));
            _NETDEV_PTZPreset = GetDelegate<DCreater.NETDEV_PTZPreset>(nameof(DCreater.NETDEV_PTZPreset));
            _NETDEV_PTZPreset_Other = GetDelegate<DCreater.NETDEV_PTZPreset_Other>(nameof(DCreater.NETDEV_PTZPreset_Other));
            _NETDEV_PTZSelZoomIn_Other = GetDelegate<DCreater.NETDEV_PTZSelZoomIn_Other>(nameof(DCreater.NETDEV_PTZSelZoomIn_Other));
            _NETDEV_PTZTrackCruise = GetDelegate<DCreater.NETDEV_PTZTrackCruise>(nameof(DCreater.NETDEV_PTZTrackCruise));
            _NETDEV_QueryRecordRange = GetDelegate<DCreater.NETDEV_QueryRecordRange>(nameof(DCreater.NETDEV_QueryRecordRange));
            _NETDEV_QueryVideoChlDetailList = GetDelegate<DCreater.NETDEV_QueryVideoChlDetailList>(nameof(DCreater.NETDEV_QueryVideoChlDetailList));
            _NETDEV_RealPlay = GetDelegate<DCreater.NETDEV_RealPlay>(nameof(DCreater.NETDEV_RealPlay));
            _NETDEV_Reboot = GetDelegate<DCreater.NETDEV_Reboot>(nameof(DCreater.NETDEV_Reboot));
            _NETDEV_ResetLostPacketRate = GetDelegate<DCreater.NETDEV_ResetLostPacketRate>(nameof(DCreater.NETDEV_ResetLostPacketRate));
            _NETDEV_RestoreConfig = GetDelegate<DCreater.NETDEV_RestoreConfig>(nameof(DCreater.NETDEV_RestoreConfig));
            _NETDEV_SaveRealData = GetDelegate<DCreater.NETDEV_SaveRealData>(nameof(DCreater.NETDEV_SaveRealData));
            _NETDEV_SetACSPersonPermission = GetDelegate<DCreater.NETDEV_SetACSPersonPermission>(nameof(DCreater.NETDEV_SetACSPersonPermission));
            _NETDEV_SetAlarmCallBack = GetDelegate<DCreater.NETDEV_SetAlarmCallBack>(nameof(DCreater.NETDEV_SetAlarmCallBack));
            _NETDEV_SetAlarmCallBack_V30 = GetDelegate<DCreater.NETDEV_SetAlarmCallBack_V30>(nameof(DCreater.NETDEV_SetAlarmCallBack_V30));
            _NETDEV_SetAlarmFGCallBack = GetDelegate<DCreater.NETDEV_SetAlarmFGCallBack>(nameof(DCreater.NETDEV_SetAlarmFGCallBack));
            _NETDEV_SetCarPlateCallBack = GetDelegate<DCreater.NETDEV_SetCarPlateCallBack>(nameof(DCreater.NETDEV_SetCarPlateCallBack));
            _NETDEV_SetConfigFile = GetDelegate<DCreater.NETDEV_SetConfigFile>(nameof(DCreater.NETDEV_SetConfigFile));
            _NETDEV_SetConflagrationAlarmCallBack = GetDelegate<DCreater.NETDEV_SetConflagrationAlarmCallBack>(nameof(DCreater.NETDEV_SetConflagrationAlarmCallBack));
            _NETDEV_SetConnectTime = GetDelegate<DCreater.NETDEV_SetConnectTime>(nameof(DCreater.NETDEV_SetConnectTime));
            _NETDEV_SetDevConfig1 = GetDelegate<DCreater.NETDEV_SetDevConfig1>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig2 = GetDelegate<DCreater.NETDEV_SetDevConfig2>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig3 = GetDelegate<DCreater.NETDEV_SetDevConfig3>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig4 = GetDelegate<DCreater.NETDEV_SetDevConfig4>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig5 = GetDelegate<DCreater.NETDEV_SetDevConfig5>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig6 = GetDelegate<DCreater.NETDEV_SetDevConfig6>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig7 = GetDelegate<DCreater.NETDEV_SetDevConfig7>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig8 = GetDelegate<DCreater.NETDEV_SetDevConfig8>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfig9 = GetDelegate<DCreater.NETDEV_SetDevConfig9>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigA = GetDelegate<DCreater.NETDEV_SetDevConfigA>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigB = GetDelegate<DCreater.NETDEV_SetDevConfigB>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigC = GetDelegate<DCreater.NETDEV_SetDevConfigC>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigD = GetDelegate<DCreater.NETDEV_SetDevConfigD>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigE = GetDelegate<DCreater.NETDEV_SetDevConfigE>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigF = GetDelegate<DCreater.NETDEV_SetDevConfigF>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigG = GetDelegate<DCreater.NETDEV_SetDevConfigG>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDevConfigH = GetDelegate<DCreater.NETDEV_SetDevConfigH>(nameof(INetDevSdkProxy.NETDEV_SetDevConfig));
            _NETDEV_SetDigitalZoom = GetDelegate<DCreater.NETDEV_SetDigitalZoom>(nameof(DCreater.NETDEV_SetDigitalZoom));
            _NETDEV_SetDiscoveryCallBack = GetDelegate<DCreater.NETDEV_SetDiscoveryCallBack>(nameof(DCreater.NETDEV_SetDiscoveryCallBack));
            _NETDEV_SetExceptionCallBack = GetDelegate<DCreater.NETDEV_SetExceptionCallBack>(nameof(DCreater.NETDEV_SetExceptionCallBack));
            _NETDEV_SetFaceSnapshotCallBack = GetDelegate<DCreater.NETDEV_SetFaceSnapshotCallBack>(nameof(DCreater.NETDEV_SetFaceSnapshotCallBack));
            _NETDEV_SetIVAEnable = GetDelegate<DCreater.NETDEV_SetIVAEnable>(nameof(DCreater.NETDEV_SetIVAEnable));
            _NETDEV_SetIVAShowParam = GetDelegate<DCreater.NETDEV_SetIVAShowParam>(nameof(DCreater.NETDEV_SetIVAShowParam));
            _NETDEV_SetLogPath = GetDelegate<DCreater.NETDEV_SetLogPath>(nameof(DCreater.NETDEV_SetLogPath));
            _NETDEV_SetPassengerFlowStatisticCallBack = GetDelegate<DCreater.NETDEV_SetPassengerFlowStatisticCallBack>(nameof(DCreater.NETDEV_SetPassengerFlowStatisticCallBack));
            _NETDEV_SetPersonAlarmCallBack = GetDelegate<DCreater.NETDEV_SetPersonAlarmCallBack>(nameof(DCreater.NETDEV_SetPersonAlarmCallBack));
            _NETDEV_SetPersonMonitorRuleInfo = GetDelegate<DCreater.NETDEV_SetPersonMonitorRuleInfo>(nameof(DCreater.NETDEV_SetPersonMonitorRuleInfo));
            _NETDEV_SetPictureFluency = GetDelegate<DCreater.NETDEV_SetPictureFluency>(nameof(DCreater.NETDEV_SetPictureFluency));
            _NETDEV_SetPlayDataCallBack = GetDelegate<DCreater.NETDEV_SetPlayDataCallBack>(nameof(DCreater.NETDEV_SetPlayDataCallBack));
            _NETDEV_SetPlayDecodeVideoCB = GetDelegate<DCreater.NETDEV_SetPlayDecodeVideoCB>(nameof(DCreater.NETDEV_SetPlayDecodeVideoCB));
            _NETDEV_SetPlayDisplayCB = GetDelegate<DCreater.NETDEV_SetPlayDisplayCB>(nameof(DCreater.NETDEV_SetPlayDisplayCB));
            _NETDEV_SetPlayParseCB = GetDelegate<DCreater.NETDEV_SetPlayParseCB>(nameof(DCreater.NETDEV_SetPlayParseCB));
            _NETDEV_SetPTZAbsolutePTInfo = GetDelegate<DCreater.NETDEV_SetPTZAbsolutePTInfo>(nameof(DCreater.NETDEV_SetPTZAbsolutePTInfo));
            _NETDEV_SetPTZAbsoluteZoomInfo = GetDelegate<DCreater.NETDEV_SetPTZAbsoluteZoomInfo>(nameof(DCreater.NETDEV_SetPTZAbsoluteZoomInfo));
            _NETDEV_SetRenderScale = GetDelegate<DCreater.NETDEV_SetRenderScale>(nameof(DCreater.NETDEV_SetRenderScale));
            _NETDEV_SetRevTimeOut = GetDelegate<DCreater.NETDEV_SetRevTimeOut>(nameof(DCreater.NETDEV_SetRevTimeOut));
            _NETDEV_SetStructAlarmCallBack = GetDelegate<DCreater.NETDEV_SetStructAlarmCallBack>(nameof(DCreater.NETDEV_SetStructAlarmCallBack));
            _NETDEV_SetSystemTimeCfg = GetDelegate<DCreater.NETDEV_SetSystemTimeCfg>(nameof(DCreater.NETDEV_SetSystemTimeCfg));
            _NETDEV_SetUpnpNatState = GetDelegate<DCreater.NETDEV_SetUpnpNatState>(nameof(DCreater.NETDEV_SetUpnpNatState));
            _NETDEV_SetVehicleAlarmCallBack = GetDelegate<DCreater.NETDEV_SetVehicleAlarmCallBack>(nameof(DCreater.NETDEV_SetVehicleAlarmCallBack));
            _NETDEV_SetVehicleMonitorInfo = GetDelegate<DCreater.NETDEV_SetVehicleMonitorInfo>(nameof(DCreater.NETDEV_SetVehicleMonitorInfo));
            _NETDEV_SetVideoEffect = GetDelegate<DCreater.NETDEV_SetVideoEffect>(nameof(DCreater.NETDEV_SetVideoEffect));
            _NETDEV_SoundVolumeControl = GetDelegate<DCreater.NETDEV_SoundVolumeControl>(nameof(DCreater.NETDEV_SoundVolumeControl));
            _NETDEV_StartInputVoiceSrv = GetDelegate<DCreater.NETDEV_StartInputVoiceSrv>(nameof(DCreater.NETDEV_StartInputVoiceSrv));
            _NETDEV_StartMultiTrafficStatistic = GetDelegate<DCreater.NETDEV_StartMultiTrafficStatistic>(nameof(DCreater.NETDEV_StartMultiTrafficStatistic));
            _NETDEV_StartVoiceCom = GetDelegate<DCreater.NETDEV_StartVoiceCom>(nameof(DCreater.NETDEV_StartVoiceCom));
            _NETDEV_StopGetFile = GetDelegate<DCreater.NETDEV_StopGetFile>(nameof(DCreater.NETDEV_StopGetFile));
            _NETDEV_StopInputVoiceSrv = GetDelegate<DCreater.NETDEV_StopInputVoiceSrv>(nameof(DCreater.NETDEV_StopInputVoiceSrv));
            _NETDEV_StopPlayBack = GetDelegate<DCreater.NETDEV_StopPlayBack>(nameof(DCreater.NETDEV_StopPlayBack));
            //_NETDEV_StopPlaySound = GetDelegate<DCreater.NETDEV_StopPlaySound>(nameof(DCreater.NETDEV_StopPlaySound));
            _NETDEV_StopRealPlay = GetDelegate<DCreater.NETDEV_StopRealPlay>(nameof(DCreater.NETDEV_StopRealPlay));
            _NETDEV_StopSaveRealData = GetDelegate<DCreater.NETDEV_StopSaveRealData>(nameof(DCreater.NETDEV_StopSaveRealData));
            _NETDEV_StopTrafficStatistic = GetDelegate<DCreater.NETDEV_StopTrafficStatistic>(nameof(DCreater.NETDEV_StopTrafficStatistic));
            _NETDEV_StopVoiceCom = GetDelegate<DCreater.NETDEV_StopVoiceCom>(nameof(DCreater.NETDEV_StopVoiceCom));
            _NETDEV_SubscibeLapiAlarm = GetDelegate<DCreater.NETDEV_SubscibeLapiAlarm>(nameof(DCreater.NETDEV_SubscibeLapiAlarm));
            _NETDEV_SubscribeSmart = GetDelegate<DCreater.NETDEV_SubscribeSmart>(nameof(DCreater.NETDEV_SubscribeSmart));
            _NETDEV_UnSubLapiAlarm = GetDelegate<DCreater.NETDEV_UnSubLapiAlarm>(nameof(DCreater.NETDEV_UnSubLapiAlarm));
            _NETDEV_UnsubscribeSmart = GetDelegate<DCreater.NETDEV_UnsubscribeSmart>(nameof(DCreater.NETDEV_UnsubscribeSmart));
        }
        public override string GetFileFullName()
        {
            return NetDevSdk.DllFullName;
        }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);
        #region // 显示实现
        void INetDevSdkProxy.MemCopy(byte[] dest, IntPtr src, int count) => MemCopy(dest, src, count);
        void INetDevSdkProxy.OutputDebugString(string message) => OutputDebugString(message);
        int INetDevSdkProxy.NETDEV_ACSPersonCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo) => _NETDEV_ACSPersonCtrl.Invoke(lpUserID, dwCommand, ref pstACSPersonInfo);
        int INetDevSdkProxy.NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref uint pUdwBlackListID) => _NETDEV_AddACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo, ref pUdwBlackListID);
        int INetDevSdkProxy.NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList) => _NETDEV_AddACSPersonList.Invoke(lpUserID, ref pstACSPersonList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref uint pUdwGroupID) => _NETDEV_AddACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionGroupInfo, ref pUdwGroupID);
        int INetDevSdkProxy.NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref int pdwOrgID) => _NETDEV_AddOrgInfo.Invoke(lpUserID, ref pstOrgInfo, ref pdwOrgID);
        int INetDevSdkProxy.NETDEV_AddPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => _NETDEV_AddPersonInfo.Invoke(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int INetDevSdkProxy.NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo) => _NETDEV_AddPersonMonitorInfo.Invoke(lpUserID, ref pstMonitorInfo, ref pstMonitorResultInfo);
        int INetDevSdkProxy.NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo) => _NETDEV_AddUserV30.Invoke(lpFindHandle, ref pstUserModifyInfo);
        int INetDevSdkProxy.NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => _NETDEV_AddVehicleLibInfo.Invoke(lpUserID, ref pstVehicleLibInfo);
        int INetDevSdkProxy.NETDEV_AddVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => _NETDEV_AddVehicleLibMember.Invoke(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int INetDevSdkProxy.NETDEV_AddVehicleMemberList(IntPtr lpUserID, uint udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_AddVehicleMemberList.Invoke(lpUserID, udwLibID, ref pstVehicleMemberList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_AddVehicleMonitorInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo) => _NETDEV_BatchDeleteOrgInfo.Invoke(lpUserID, ref pstOrgDelInfo, ref pstOrgDelResultInfo);
        int INetDevSdkProxy.NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_BatchDeletePersonMonitorInfo.Invoke(lpUserID, ref pstResultList);
        int INetDevSdkProxy.NETDEV_CaptureNoPreview(IntPtr lpUserID, int dwChannelID, int dwStreamType, string szFileName, int dwCaptureMode) => _NETDEV_CaptureNoPreview.Invoke(lpUserID, dwChannelID, dwStreamType, szFileName, dwCaptureMode);
        int INetDevSdkProxy.NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, int dwCaptureMode) => _NETDEV_CapturePicture.Invoke(lpRealHandle, szFileName, dwCaptureMode);
        int INetDevSdkProxy.NETDEV_Cleanup() => _NETDEV_Cleanup.Invoke();
        int INetDevSdkProxy.NETDEV_CloseMic(IntPtr lpPlayHandle) => _NETDEV_CloseMic.Invoke(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_CloseSound(IntPtr lpRealHandle) => _NETDEV_CloseSound.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref uint pudwID) => _NETDEV_CreatePersonLibInfo.Invoke(lpUserID, ref pstPersonLibInfo, ref pudwID);
        int INetDevSdkProxy.NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo) => _NETDEV_CreateUser.Invoke(lpUserID, stUserInfo);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList) => _NETDEV_DeleteACSPersonBlackList.Invoke(lpUserID, ref pstBlackList);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo) => _NETDEV_DeleteACSPersonList.Invoke(lpUserID, ref pstBatchCtrlInfo);
        int INetDevSdkProxy.NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => _NETDEV_DeleteACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionIDList, ref pstResutList);
        int INetDevSdkProxy.NETDEV_DeletePersonInfo(IntPtr lpUserID, uint udwPersonLibID, uint udwPersonID, uint udwLastChange) => _NETDEV_DeletePersonInfo.Invoke(lpUserID, udwPersonLibID, udwPersonID, udwLastChange);
        int INetDevSdkProxy.NETDEV_DeletePersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList) => _NETDEV_DeletePersonInfoList.Invoke(lpUserID, udwPersonLibID, ref pstIDList, ref pstResutList);
        int INetDevSdkProxy.NETDEV_DeletePersonLibInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo) => _NETDEV_DeletePersonLibInfo.Invoke(lpUserID, udwPersonLibID, ref pstFlagInfo);
        int INetDevSdkProxy.NETDEV_DeleteUser(IntPtr lpUserID, string strUserName) => _NETDEV_DeleteUser.Invoke(lpUserID, strUserName);
        int INetDevSdkProxy.NETDEV_DeleteUserV30(IntPtr lpFindHandle, uint udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_DeleteUserV30.Invoke(lpFindHandle, udwUserNum, ref pstUserNameList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag) => _NETDEV_DeleteVehicleLibInfo.Invoke(lpUserID, udwVehicleLibID, ref pstDelLibFlag);
        int INetDevSdkProxy.NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList) => _NETDEV_DeleteVehicleLibMember.Invoke(lpUserID, udwVehicleLibID, ref pstMemberList, ref pstBatchResultList);
        int INetDevSdkProxy.NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => _NETDEV_DeleteVehicleMonitorInfo.Invoke(lpUserID, ref pstBatchList);
        int INetDevSdkProxy.NETDEV_DelVehicleMemberList(IntPtr lpUserID, uint udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList) => _NETDEV_DelVehicleMemberList.Invoke(lpUserID, udwLib, ref pstVehicleMemberList, ref pstBatchList);
        int INetDevSdkProxy.NETDEV_Discovery(string pszBeginIP, string pszEndIP) => _NETDEV_Discovery.Invoke(pszBeginIP, pszEndIP);
        int INetDevSdkProxy.NETDEV_DoorBatchCtrl(IntPtr lpUserID, int dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo) => _NETDEV_DoorBatchCtrl.Invoke(lpUserID, dwCommand, ref pstBatchCtrlInfo);
        int INetDevSdkProxy.NETDEV_DoorCtrl(IntPtr lpUserID, int dwChannelID, int dwCommand) => _NETDEV_DoorCtrl.Invoke(lpUserID, dwChannelID, dwCommand);
        IntPtr INetDevSdkProxy.NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSAttendanceLogList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPermissionGroupList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPersonBlackList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSPersonList.Invoke(lpUserID, ref pstQueryCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindACSVisitLogList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        int INetDevSdkProxy.NETDEV_FindClose(IntPtr lpFindHandle) => _NETDEV_FindClose.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSAttendanceLogList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPermissionGroupList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPersonBlackList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseACSPersonInfo.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle) => _NETDEV_FindCloseACSVisitLog.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseDevChn(IntPtr lpFindHandle) => _NETDEV_FindCloseDevChn.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseDevInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseDevInfo.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle) => _NETDEV_FindCloseFaceRecordDetail.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle) => _NETDEV_FindCloseMonitorStatusList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseOrgInfo.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePermStatusList(IntPtr lpFindHandle) => _NETDEV_FindClosePermStatusList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonInfoList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonLibList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonLibList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle) => _NETDEV_FindClosePersonMonitorList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle) => _NETDEV_FindCloseRoleBaseInfoOfUserList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle) => _NETDEV_FindCloseRoleInfoList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle) => _NETDEV_FindCloseTimeTemplateByTypeList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle) => _NETDEV_FindCloseTrafficStatisticInfo.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle) => _NETDEV_FindCloseUserDetailInfoListV30.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleLibList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleMemberDetail.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleMonitorList.Invoke(lpFindHandle);
        int INetDevSdkProxy.NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle) => _NETDEV_FindCloseVehicleRecordList.Invoke(lpFindHandle);
        IntPtr INetDevSdkProxy.NETDEV_FindDevChnList(IntPtr lpUserID, int dwDevID, int dwChnType) => _NETDEV_FindDevChnList.Invoke(lpUserID, dwDevID, dwChnType);
        IntPtr INetDevSdkProxy.NETDEV_FindDevList(IntPtr lpUserID, int dwDevType) => _NETDEV_FindDevList.Invoke(lpUserID, dwDevType);
        IntPtr INetDevSdkProxy.NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => _NETDEV_FindFaceRecordDetailList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond) => _NETDEV_FindFile.Invoke(lpUserID, ref pFindCond);
        IntPtr INetDevSdkProxy.NETDEV_FindMonitorStatusList(IntPtr lpUserID, int enType, ref uint udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList) => _NETDEV_FindMonitorStatusList.Invoke(lpUserID, enType, ref udwMonitorID, ref pstFindLimit, ref pstList);
        int INetDevSdkProxy.NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo) => _NETDEV_FindNextACSAttendanceLog.Invoke(lpFindHandle, ref pstACSLogInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo) => _NETDEV_FindNextACSPermissionGroupInfo.Invoke(lpFindHandle, ref pstACSPermissionInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_FindNextACSPersonBlackListInfo.Invoke(lpFindHandle, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo) => _NETDEV_FindNextACSPersonInfo.Invoke(lpFindHandle, ref pstACSPersonInfo);
        int INetDevSdkProxy.NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo) => _NETDEV_FindNextACSVisitLog.Invoke(lpFindHandle, ref pstACSLogInfo);
        int INetDevSdkProxy.NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_FindNextDevChn.Invoke(lpFindHandle, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo) => _NETDEV_FindNextDevInfo.Invoke(lpFindHandle, ref pstDevBasicInfo);
        int INetDevSdkProxy.NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo) => _NETDEV_FindNextFaceRecordDetail.Invoke(lpFindHandle, ref pstRecordInfo);
        int INetDevSdkProxy.NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData) => _NETDEV_FindNextFile.Invoke(lpFindHandle, ref lpFindData);
        int INetDevSdkProxy.NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats) => _NETDEV_FindNextMonitorStatusInfo.Invoke(lpFindHandle, ref pstMonitorStats);
        int INetDevSdkProxy.NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo) => _NETDEV_FindNextOrgInfo.Invoke(lpFindHandle, ref pstOrgInfo);
        int INetDevSdkProxy.NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus) => _NETDEV_FindNextPermStatusInfo.Invoke(lpFindHandle, ref pstACSPermStatus);
        int INetDevSdkProxy.NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo) => _NETDEV_FindNextPersonInfo.Invoke(lpFindHandle, ref pstPersonInfo);
        int INetDevSdkProxy.NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo) => _NETDEV_FindNextPersonLibInfo.Invoke(lpFindHandle, ref pstPersonLibInfo);
        int INetDevSdkProxy.NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_FindNextPersonMonitorInfo.Invoke(lpFindHandle, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo) => _NETDEV_FindNextRoleBaseInfoOfUser.Invoke(lpFindHandle, ref pstRoleBaseInfo);
        int INetDevSdkProxy.NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo) => _NETDEV_FindNextRoleInfo.Invoke(lpFindHandle, ref pstRoleInfo);
        int INetDevSdkProxy.NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo) => _NETDEV_FindNextTimeTemplateByTypeInfo.Invoke(lpFindHandle, ref pstTimeTemplateInfo);
        int INetDevSdkProxy.NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo) => _NETDEV_FindNextTrafficStatisticInfo.Invoke(lpFindHandle, ref pstStatisticInfo);
        int INetDevSdkProxy.NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo) => _NETDEV_FindNextUserDetailInfoV30.Invoke(lpFindHandle, ref pstUserDetailInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo) => _NETDEV_FindNextVehicleLibInfo.Invoke(lpFindHandle, ref pstVehicleLibInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo) => _NETDEV_FindNextVehicleMemberDetail.Invoke(lpFindHandle, ref pstVehicleMemberInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo) => _NETDEV_FindNextVehicleMonitorInfo.Invoke(lpFindHandle, ref pstVehicleMonitorInfo);
        int INetDevSdkProxy.NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo) => _NETDEV_FindNextVehicleRecordInfo.Invoke(lpFindHandle, ref pstRecordInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond) => _NETDEV_FindOrgInfoList.Invoke(lpUserID, ref pstFindCond);
        IntPtr INetDevSdkProxy.NETDEV_FindPermStatusList(IntPtr lpUserID, ref uint udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo) => _NETDEV_FindPermStatusList.Invoke(lpUserID, ref udwPermGroupID, ref pstQueryInfo, ref pstResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonInfoList(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo) => _NETDEV_FindPersonInfoList.Invoke(lpUserID, udwPersonLibID, ref pstQueryInfo, ref pstQueryResultInfo);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonLibList(IntPtr lpUserID) => _NETDEV_FindPersonLibList.Invoke(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindPersonMonitorList(IntPtr lpUserID, uint udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo) => _NETDEV_FindPersonMonitorList.Invoke(lpUserID, udwChannelID, ref pstQueryInfo);
        int INetDevSdkProxy.NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, uint udwUserID) => _NETDEV_FindRoleBaseInfoOfUserList.Invoke(lpUserID, udwUserID);
        int INetDevSdkProxy.NETDEV_FindRoleInfoList(IntPtr lpUserID) => _NETDEV_FindRoleInfoList.Invoke(lpUserID);
        int INetDevSdkProxy.NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, uint udwTemplateType) => _NETDEV_FindTimeTemplateByTypeList.Invoke(lpUserID, udwTemplateType);
        IntPtr INetDevSdkProxy.NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, uint udwSearchID) => _NETDEV_FindTrafficStatisticInfoList.Invoke(lpUserID, udwSearchID);
        int INetDevSdkProxy.NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID) => _NETDEV_FindUserDetailInfoListV30.Invoke(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleLibList(IntPtr lpUserID) => _NETDEV_FindVehicleLibList.Invoke(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList) => _NETDEV_FindVehicleMemberDetailList.Invoke(lpUserID, udwVehicleLibID, ref pstFindCond, ref pstDBMemberList);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleMonitorList(IntPtr lpUserID) => _NETDEV_FindVehicleMonitorList.Invoke(lpUserID);
        IntPtr INetDevSdkProxy.NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo) => _NETDEV_FindVehicleRecordInfoList.Invoke(lpUserID, ref pstFindCond, ref pstResultInfo);
        int INetDevSdkProxy.NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_GetACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_GetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_GetACSPersonPermission.Invoke(lpUserID, udwPersonID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate) => _NETDEV_GetBitRate.Invoke(lpRealHandle, ref pdwBitRate);
        int INetDevSdkProxy.NETDEV_GetChnDetailByChnType(IntPtr lpUserID, int dwChnID, int dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetChnDetailByChnType.Invoke(lpUserID, dwChnID, dwChnType, lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetChnType(IntPtr lpUserID, int dwChnID, ref int pdwChnType) => _NETDEV_GetChnType.Invoke(lpUserID, dwChnID, ref pdwChnType);
        int INetDevSdkProxy.NETDEV_GetCompassInfo(IntPtr lpUserID, int dwChannelID, ref float fCompassInfo) => _NETDEV_GetCompassInfo.Invoke(lpUserID, dwChannelID, ref fCompassInfo);
        int INetDevSdkProxy.NETDEV_GetConfigFile(IntPtr lpUserID, string strConfigPath) => _NETDEV_GetConfigFile.Invoke(lpUserID, strConfigPath);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig1.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig2.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig3.Invoke(lpUserID, dwChannelID, dwCommand, ref lpOutBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig4.Invoke(lpUserID, dwChannelID, dwCommand, lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig5.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig6.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig7.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig8.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfig9.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigA.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigB.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigC.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigD.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigE.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigF.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigG.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigH.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigI.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigJ.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwOutBufferSize, ref int pdwBytesReturned) => _NETDEV_GetDevConfigK.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize, ref pdwBytesReturned);
        int INetDevSdkProxy.NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo) => _NETDEV_GetDeviceInfo.Invoke(lpUserID, ref pstDevInfo);
        int INetDevSdkProxy.NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, int dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo) => _NETDEV_GetDeviceInfo_V30.Invoke(lpUserID, dwDevID, ref pstDevInfo);
        int INetDevSdkProxy.NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, uint udwRecordID, uint udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo) => _NETDEV_GetFaceRecordImageInfo.Invoke(lpUserID, udwRecordID, udwFaceImageType, ref pstFileInfo);
        IntPtr INetDevSdkProxy.NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, string szSaveFileName, int dwFormat) => _NETDEV_GetFileByName.Invoke(lpUserID, ref pstPlayBackInfo, szSaveFileName, dwFormat);
        IntPtr INetDevSdkProxy.NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, int dwFormat) => _NETDEV_GetFileByTime.Invoke(lpUserID, ref pstPlayBackCond, pszSaveFileName, dwFormat);
        int INetDevSdkProxy.NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate) => _NETDEV_GetFrameRate.Invoke(lpRealHandle, ref pdwFrameRate);
        int INetDevSdkProxy.NETDEV_GetGeolocationInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo) => _NETDEV_GetGeolocationInfo.Invoke(lpUserID, dwChannelID, ref pstGPSInfo);
        int INetDevSdkProxy.NETDEV_GetLastError() => _NETDEV_GetLastError.Invoke();
        int INetDevSdkProxy.NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum) => _NETDEV_GetLostPacketRate.Invoke(lpRealHandle, ref pulRecvPktNum, ref pulLostPktNum);
        int INetDevSdkProxy.NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref int dwVolume) => _NETDEV_GetMicVolume.Invoke(lpPlayHandle, ref dwVolume);
        int INetDevSdkProxy.NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList) => _NETDEV_GetMonitorCapacity.Invoke(lpUserID, ref pstCapacityInfo, ref pstCapacityList);
        int INetDevSdkProxy.NETDEV_GetMonitorProgress(IntPtr lpUserID, ref uint pudwProgressRate) => _NETDEV_GetMonitorProgress.Invoke(lpUserID, ref pudwProgressRate);
        int INetDevSdkProxy.NETDEV_GetPersonLibCapacity(IntPtr lpUserID, int dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList) => _NETDEV_GetPersonLibCapacity.Invoke(lpUserID, dwTimeOut, ref pstCapacityList);
        int INetDevSdkProxy.NETDEV_GetPersonMemberInfo(IntPtr lpUserID, uint udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo) => _NETDEV_GetPersonMemberInfo.Invoke(lpUserID, udwPersonID, ref pstPersonInfo);
        int INetDevSdkProxy.NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_GetPersonMonitorRuleInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo) => _NETDEV_GetPTZAbsolutePTInfo.Invoke(lpUserID, dwChannelID, ref pstPTPositionInfo);
        int INetDevSdkProxy.NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, int dwChannelID, ref float fZoomRatio) => _NETDEV_GetPTZAbsoluteZoomInfo.Invoke(lpUserID, dwChannelID, ref fZoomRatio);
        int INetDevSdkProxy.NETDEV_GetPTZPresetList(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer) => _NETDEV_GetPTZPresetList.Invoke(lpUserID, dwChannelID, ref lpOutBuffer);
        int INetDevSdkProxy.NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight) => _NETDEV_GetResolution.Invoke(lpRealHandle, ref pdwWidth, ref pdwHeight);
        int INetDevSdkProxy.NETDEV_GetSDKVersion() => _NETDEV_GetSDKVersion.Invoke();
        int INetDevSdkProxy.NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, uint udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo) => _NETDEV_GetSinglePermGroupInfo.Invoke(lpUserID, udwPermissionGroupID, ref pstAcsPerssionInfo);
        int INetDevSdkProxy.NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref int pdwVolume) => _NETDEV_GetSoundVolume.Invoke(lpPlayHandle, ref pdwVolume);
        int INetDevSdkProxy.NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, uint udwSize, IntPtr pszdata) => _NETDEV_GetSystemPicture.Invoke(lpUserID, pszURL, udwSize, pszdata);
        int INetDevSdkProxy.NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => _NETDEV_GetSystemTimeCfg.Invoke(lpUserID, ref pstSystemTimeInfo);
        int INetDevSdkProxy.NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate) => _NETDEV_GetTimeTemplate.Invoke(lpFindHandle, ref pstTimeTemplate);
        int INetDevSdkProxy.NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, int dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo) => _NETDEV_GetTimeTemplateInfo.Invoke(lpUserID, dwTemplateID, ref pstTimeTemplateInfo);
        int INetDevSdkProxy.NETDEV_GetTimeTemplateList(IntPtr lpUserID, int dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList) => _NETDEV_GetTimeTemplateList.Invoke(lpUserID, dwTamplateType, ref pstTemplateList);
        int INetDevSdkProxy.NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic) => _NETDEV_GetTrafficStatistic.Invoke(lpUserID, ref pstStatisticCond, ref pstTrafficStatistic);
        int INetDevSdkProxy.NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, uint udwSearchID, ref uint pudwProgress) => _NETDEV_GetTrafficStatisticProgress.Invoke(lpUserID, udwSearchID, ref pudwProgress);
        int INetDevSdkProxy.NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => _NETDEV_GetUpnpNatState.Invoke(lpUserID, ref pstNatState);
        int INetDevSdkProxy.NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo) => _NETDEV_GetUserDetailInfoV30.Invoke(lpFindHandle, ref pstUserDetailInfo);
        int INetDevSdkProxy.NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList) => _NETDEV_GetUserDetailList.Invoke(lpUserID, pstUserDetailList);
        int INetDevSdkProxy.NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => _NETDEV_GetVehicleMonitorInfo.Invoke(lpUserID, udwID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, uint udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo) => _NETDEV_GetVehicleRecordImageInfo.Invoke(lpUserID, udwRecordID, ref pstFileInfo);
        int INetDevSdkProxy.NETDEV_GetVideoDayNums(IntPtr lpUserID, int dwChannelID, ref int dwDayNums) => _NETDEV_GetVideoDayNums.Invoke(lpUserID, dwChannelID, ref dwDayNums);
        int INetDevSdkProxy.NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => _NETDEV_GetVideoEffect.Invoke(lpRealHandle, ref pstImageInfo);
        int INetDevSdkProxy.NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt) => _NETDEV_GetVideoEncodeFmt.Invoke(lpRealHandle, ref pdwVideoEncFmt);
        int INetDevSdkProxy.NETDEV_Init() => _NETDEV_Init.Invoke();
        int INetDevSdkProxy.NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, int dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam) => _NETDEV_InputVoiceData.Invoke(lpUserID, lpDataBuf, dwDataLen, ref pstVoiceParam);
        IntPtr INetDevSdkProxy.NETDEV_Login(string szDevIP, short wDevPort, string szUserName, string szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo) => _NETDEV_Login.Invoke(szDevIP, wDevPort, szUserName, szPassword, ref pstDevInfo);
        IntPtr INetDevSdkProxy.NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo) => _NETDEV_Login_V30.Invoke(ref pstDevLoginInfo, ref pstSELogInfo);
        int INetDevSdkProxy.NETDEV_Logout(IntPtr lpUserID) => _NETDEV_Logout.Invoke(lpUserID);
        int INetDevSdkProxy.NETDEV_MakeKeyFrame(IntPtr lpUserID, int dwChannelID, int dwStreamType) => _NETDEV_MakeKeyFrame.Invoke(lpUserID, dwChannelID, dwStreamType);
        int INetDevSdkProxy.NETDEV_MicVolumeControl(IntPtr lpPlayHandle, int dwVolume) => _NETDEV_MicVolumeControl.Invoke(lpPlayHandle, dwVolume);
        int INetDevSdkProxy.NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo) => _NETDEV_ModifyACSPersonBlackList.Invoke(lpUserID, ref pstBlackListInfo);
        int INetDevSdkProxy.NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_ModifyACSPersonPermissionGroup.Invoke(lpUserID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, string szOldPassword, string szNewPassword) => _NETDEV_ModifyCurrentPin.Invoke(lpFindHandle, szOldPassword, szNewPassword);
        int INetDevSdkProxy.NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName) => _NETDEV_ModifyDeviceName.Invoke(lpUserID, strDeviceName);
        int INetDevSdkProxy.NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo) => _NETDEV_ModifyOrgInfo.Invoke(lpUserID, ref pstOrgInfo);
        int INetDevSdkProxy.NETDEV_ModifyPersonInfo(IntPtr lpUserID, uint udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList) => _NETDEV_ModifyPersonInfo.Invoke(lpUserID, udwPersonLibID, ref pstPersonInfoList, ref pstPersonResultList);
        int INetDevSdkProxy.NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList) => _NETDEV_ModifyPersonLibInfo.Invoke(lpUserID, ref pstPersonLibList);
        int INetDevSdkProxy.NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, uint udwUserID, ref NETDEV_ID_LIST_S pstRoleList) => _NETDEV_ModifyRoleInfoOfUser.Invoke(lpFindHandle, udwUserID, ref pstRoleList);
        int INetDevSdkProxy.NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo) => _NETDEV_ModifyUser.Invoke(lpUserID, pstUserInfo);
        int INetDevSdkProxy.NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo) => _NETDEV_ModifyUserV30.Invoke(lpFindHandle, ref pstUserModifyInfo);
        int INetDevSdkProxy.NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList) => _NETDEV_ModifyVehicleLibInfo.Invoke(lpUserID, ref pstVehicleLibList);
        int INetDevSdkProxy.NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, uint udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList) => _NETDEV_ModifyVehicleMemberInfo.Invoke(lpUserID, udwVehicleLibID, ref pstVehicleMemberList, ref pstResultList);
        int INetDevSdkProxy.NETDEV_OpenMic(IntPtr lpPlayHandle) => _NETDEV_OpenMic.Invoke(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_OpenSound(IntPtr lpRealHandle) => _NETDEV_OpenSound.Invoke(lpRealHandle);
        IntPtr INetDevSdkProxy.NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo) => _NETDEV_PlayBackByName.Invoke(lpUserID, ref pstPlayBackInfo);
        IntPtr INetDevSdkProxy.NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo) => _NETDEV_PlayBackByTime.Invoke(lpUserID, ref pstPlayBackInfo);
        int INetDevSdkProxy.NETDEV_PlayBackControl(IntPtr lpPlayHandle, int dwControlCode, ref long pdwBuffer) => _NETDEV_PlayBackControl.Invoke(lpPlayHandle, dwControlCode, ref pdwBuffer);
        int INetDevSdkProxy.NETDEV_PlaySound(IntPtr lpRealHandle) => _NETDEV_PlaySound.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_PTZAbsoluteMove(IntPtr lpUserID, int dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove) => _NETDEV_PTZAbsoluteMove.Invoke(lpUserID, dwChannelID, pstAbsoluteMove);
        int INetDevSdkProxy.NETDEV_PTZCalibrate(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo) => _NETDEV_PTZCalibrate.Invoke(lpUserID, dwChannelID, ref pstOrientationInfo);
        int INetDevSdkProxy.NETDEV_PTZControl(IntPtr lpPlayHandle, int dwPTZCommand, int dwSpeed) => _NETDEV_PTZControl.Invoke(lpPlayHandle, dwPTZCommand, dwSpeed);
        int INetDevSdkProxy.NETDEV_PTZControl_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCommand, int dwSpeed) => _NETDEV_PTZControl_Other.Invoke(lpUserID, dwChannelID, dwPTZCommand, dwSpeed);
        int INetDevSdkProxy.NETDEV_PTZCruise_Other(IntPtr lpUserID, int dwChannelID, int dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo) => _NETDEV_PTZCruise_Other.Invoke(lpUserID, dwChannelID, dwPTZCruiseCmd, ref pstCruiseInfo);
        int INetDevSdkProxy.NETDEV_PTZGetCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList) => _NETDEV_PTZGetCruise.Invoke(lpUserID, dwChannelID, ref pstCruiseList);
        int INetDevSdkProxy.NETDEV_PTZGetStatus(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus) => _NETDEV_PTZGetStatus.Invoke(lpUserID, dwChannelID, ref pstPTZStaus);
        int INetDevSdkProxy.NETDEV_PTZGetTrackCruise(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo) => _NETDEV_PTZGetTrackCruise.Invoke(lpUserID, dwChannelID, ref pstTrackCruiseInfo);
        int INetDevSdkProxy.NETDEV_PTZPreset(IntPtr lpPlayHandle, int dwPTZPresetCmd, string pszPresetName, int dwPresetID) => _NETDEV_PTZPreset.Invoke(lpPlayHandle, dwPTZPresetCmd, pszPresetName, dwPresetID);
        int INetDevSdkProxy.NETDEV_PTZPreset_Other(IntPtr lpUserID, int dwChannelID, int dwPTZPresetCmd, byte[] szPresetName, int dwPresetID) => _NETDEV_PTZPreset_Other.Invoke(lpUserID, dwChannelID, dwPTZPresetCmd, szPresetName, dwPresetID);
        int INetDevSdkProxy.NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, int dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea) => _NETDEV_PTZSelZoomIn_Other.Invoke(lpUserID, dwChannelID, ref pstPtzOperateArea);
        int INetDevSdkProxy.NETDEV_PTZTrackCruise(IntPtr lpUserID, int dwChannelID, int dwPTZTrackCruiseCmd, string pszTrackCruiseName) => _NETDEV_PTZTrackCruise.Invoke(lpUserID, dwChannelID, dwPTZTrackCruiseCmd, pszTrackCruiseName);
        int INetDevSdkProxy.NETDEV_QueryRecordRange(IntPtr lpUserID, ref NETDEV_CHANNEL_LIST_S pstChlList, ref NETDEV_RECORD_TIME_LIST_S pstRecordTimeList) => _NETDEV_QueryRecordRange.Invoke(lpUserID, ref pstChlList, ref pstRecordTimeList);
        int INetDevSdkProxy.NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList) => _NETDEV_QueryVideoChlDetailList.Invoke(lpUserID, ref pdwChlCount, pstVideoChlList);
        IntPtr INetDevSdkProxy.NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => _NETDEV_RealPlay.Invoke(lpUserID, ref pstPreviewInfo, cbPlayDataCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_Reboot(IntPtr lpUserID) => _NETDEV_Reboot.Invoke(lpUserID);
        int INetDevSdkProxy.NETDEV_ResetLostPacketRate(IntPtr lpRealHandle) => _NETDEV_ResetLostPacketRate.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_RestoreConfig(IntPtr lpUserID) => _NETDEV_RestoreConfig.Invoke(lpUserID);
        int INetDevSdkProxy.NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, int dwFormat) => _NETDEV_SaveRealData.Invoke(lpRealHandle, szSaveFileName, dwFormat);
        int INetDevSdkProxy.NETDEV_SetACSPersonPermission(IntPtr lpUserID, uint udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo) => _NETDEV_SetACSPersonPermission.Invoke(lpUserID, udwPersonID, ref pstPermissionInfo);
        int INetDevSdkProxy.NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmCallBack_V30.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetAlarmFGCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData) => _NETDEV_SetCarPlateCallBack.Invoke(lpUserID, cbCarPlateCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetConfigFile(IntPtr lpUserID, string strConfigPath) => _NETDEV_SetConfigFile.Invoke(lpUserID, strConfigPath);
        int INetDevSdkProxy.NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetConflagrationAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetConnectTime(int dwWaitTime, int dwTrytimes) => _NETDEV_SetConnectTime.Invoke(dwWaitTime, dwTrytimes);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref int index, int dwInBufferSize) => _NETDEV_SetDevConfig1.Invoke(lpUserID, dwChannelID, dwCommand, ref index, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig2.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig3.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig4.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig5.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize) => _NETDEV_SetDevConfig6.Invoke(lpUserID, dwChannelID, dwCommand, lpInBuffer, ref dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig7.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig8.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfig9.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigA.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigB.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigC.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigD.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigE.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, int dwOutBufferSize) => _NETDEV_SetDevConfigF.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwOutBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigG.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDevConfig(IntPtr lpUserID, int dwChannelID, int dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, int dwInBufferSize) => _NETDEV_SetDevConfigH.Invoke(lpUserID, dwChannelID, dwCommand, ref lpInBuffer, dwInBufferSize);
        int INetDevSdkProxy.NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect) => _NETDEV_SetDigitalZoom.Invoke(lpRealHandle, hWnd, pstRect);
        int INetDevSdkProxy.NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData) => _NETDEV_SetDiscoveryCallBack.Invoke(cbDiscoveryCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData) => _NETDEV_SetExceptionCallBack.Invoke(cbExceptionCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData) => _NETDEV_SetFaceSnapshotCallBack.Invoke(lpUserID, cbFaceSnapshotCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetIVAEnable(IntPtr lpUserID, int dwEnableIVA) => _NETDEV_SetIVAEnable.Invoke(lpUserID, dwEnableIVA);
        int INetDevSdkProxy.NETDEV_SetIVAShowParam(int dwShowParam) => _NETDEV_SetIVAShowParam.Invoke(dwShowParam);
        int INetDevSdkProxy.NETDEV_SetLogPath(string strLogPath) => _NETDEV_SetLogPath.Invoke(strLogPath);
        int INetDevSdkProxy.NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData) => _NETDEV_SetPassengerFlowStatisticCallBack.Invoke(lpUserID, cbPassengerFlowStatisticCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetPersonAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo) => _NETDEV_SetPersonMonitorRuleInfo.Invoke(lpUserID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_SetPictureFluency(IntPtr lpPlayHandle, int dwFluency) => _NETDEV_SetPictureFluency.Invoke(lpPlayHandle, dwFluency);
        int INetDevSdkProxy.NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayDataCallBack.Invoke(lpRealHandle, cbPlayDataCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayDecodeVideoCB.Invoke(lpRealHandle, cbPlayDecodeVideoCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData) => _NETDEV_SetPlayDisplayCB.Invoke(lpRealHandle, cbPlayDisplayCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, int bContinue, IntPtr lpUserData) => _NETDEV_SetPlayParseCB.Invoke(lpRealHandle, cbPlayParseCallBack, bContinue, lpUserData);
        int INetDevSdkProxy.NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, int dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo) => _NETDEV_SetPTZAbsolutePTInfo.Invoke(lpUserID, dwChannelID, pstPTPositionInfo);
        int INetDevSdkProxy.NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, int dwChannelID, float fZoomRatio) => _NETDEV_SetPTZAbsoluteZoomInfo.Invoke(lpUserID, dwChannelID, fZoomRatio);
        int INetDevSdkProxy.NETDEV_SetRenderScale(IntPtr lpRealHandle, int enRenderScale) => _NETDEV_SetRenderScale.Invoke(lpRealHandle, enRenderScale);
        int INetDevSdkProxy.NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout) => _NETDEV_SetRevTimeOut.Invoke(ref pstRevTimeout);
        int INetDevSdkProxy.NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetStructAlarmCallBack.Invoke(lpUserID, cbAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo) => _NETDEV_SetSystemTimeCfg.Invoke(lpUserID, ref pstSystemTimeInfo);
        int INetDevSdkProxy.NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState) => _NETDEV_SetUpnpNatState.Invoke(lpUserID, ref pstNatState);
        int INetDevSdkProxy.NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData) => _NETDEV_SetVehicleAlarmCallBack.Invoke(lpUserID, cbVehicleAlarmMessCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, uint udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo) => _NETDEV_SetVehicleMonitorInfo.Invoke(lpUserID, udwID, ref pstMonitorInfo);
        int INetDevSdkProxy.NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo) => _NETDEV_SetVideoEffect.Invoke(lpRealHandle, ref pstImageInfo);
        int INetDevSdkProxy.NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, int dwVolume) => _NETDEV_SoundVolumeControl.Invoke(lpPlayHandle, dwVolume);
        IntPtr INetDevSdkProxy.NETDEV_StartInputVoiceSrv(IntPtr lpUserID, int dwChannelID) => _NETDEV_StartInputVoiceSrv.Invoke(lpUserID, dwChannelID);
        int INetDevSdkProxy.NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref uint udwSearchID) => _NETDEV_StartMultiTrafficStatistic.Invoke(lpUserID, ref pstStatisticCond, ref udwSearchID);
        IntPtr INetDevSdkProxy.NETDEV_StartVoiceCom(IntPtr lpUserID, int dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData) => _NETDEV_StartVoiceCom.Invoke(lpUserID, dwChannelID, cbPlayDataCallBack, lpUserData);
        int INetDevSdkProxy.NETDEV_StopGetFile(IntPtr lpPlayHandle) => _NETDEV_StopGetFile.Invoke(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle) => _NETDEV_StopInputVoiceSrv.Invoke(lpVoiceComHandle);
        int INetDevSdkProxy.NETDEV_StopPlayBack(IntPtr lpPlayHandle) => _NETDEV_StopPlayBack.Invoke(lpPlayHandle);
        int INetDevSdkProxy.NETDEV_StopPlaySound(IntPtr lpRealHandle) => _NETDEV_StopPlaySound.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopRealPlay(IntPtr lpRealHandle) => _NETDEV_StopRealPlay.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopSaveRealData(IntPtr lpRealHandle) => _NETDEV_StopSaveRealData.Invoke(lpRealHandle);
        int INetDevSdkProxy.NETDEV_StopTrafficStatistic(IntPtr lpUserID, uint udwSearchID) => _NETDEV_StopTrafficStatistic.Invoke(lpUserID, udwSearchID);
        int INetDevSdkProxy.NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle) => _NETDEV_StopVoiceCom.Invoke(lpVoiceComHandle);
        int INetDevSdkProxy.NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo) => _NETDEV_SubscibeLapiAlarm.Invoke(lpUserID, ref pstSubInfo, ref pstSubSuccInfo);
        int INetDevSdkProxy.NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo) => _NETDEV_SubscribeSmart.Invoke(lpUserID, ref pstSubscribeInfo, ref pstSmartInfo);
        int INetDevSdkProxy.NETDEV_UnSubLapiAlarm(IntPtr lpUserID, uint udwID) => _NETDEV_UnSubLapiAlarm.Invoke(lpUserID, udwID);
        int INetDevSdkProxy.NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo) => _NETDEV_UnsubscribeSmart.Invoke(lpUserID, ref pstSmartInfo);
        #endregion // 显示实现
    }
}
