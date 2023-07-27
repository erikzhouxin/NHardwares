using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    internal class NetDevSdkDllerX64 : INetDevSdkProxy
    {
        public static INetDevSdkProxy Instance { get; } = new NetDevSdkDllerX64();
        private NetDevSdkDllerX64() { }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
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
    internal class NetDevSdkDllerX86 : INetDevSdkProxy
    {
        public static INetDevSdkProxy Instance { get; } = new NetDevSdkDllerX86();
        private NetDevSdkDllerX86() { }
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void MemCopy(byte[] dest, IntPtr src, int count);//字节数组到字节数组的拷贝

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetFaceSnapshotCallBack(IntPtr lpUserID, NETDEV_FaceSnapshotCallBack_PF cbFaceSnapshotCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack_V30(IntPtr lpUserID, NETDEV_AlarmMessCallBack_PF_V30 cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(NETDEV_ExceptionCallBack_PF cbExceptionCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPassengerFlowStatisticCallBack(IntPtr lpUserID, NETDEV_PassengerFlowStatisticCallBack_PF cbPassengerFlowStatisticCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonAlarmCallBack(IntPtr lpUserID, NETDEV_PersonAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetStructAlarmCallBack(IntPtr lpUserID, NETDEV_StructAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleAlarmCallBack(IntPtr lpUserID, NETDEV_VehicleAlarmMessCallBack_PF cbVehicleAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmFGCallBack(IntPtr lpUserID, NETDEV_AlarmMessFGCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_QueryVideoChlDetailList(IntPtr lpUserID, ref int pdwChlCount, IntPtr pstVideoChlList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetBitRate(IntPtr lpRealHandle, ref int pdwBitRate);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFrameRate(IntPtr lpRealHandle, ref int pdwFrameRate);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEncodeFmt(IntPtr lpRealHandle, ref int pdwVideoEncFmt);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetResolution(IntPtr lpRealHandle, ref int pdwWidth, ref int pdwHeight);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLostPacketRate(IntPtr lpRealHandle, ref int pulRecvPktNum, ref int pulLostPktNum);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl(IntPtr lpPlayHandle, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, byte[] szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SaveRealData(IntPtr lpRealHandle, byte[] szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopSaveRealData(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFile(IntPtr lpUserID, ref NETDEV_FILECOND_S pFindCond);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFile(IntPtr lpFindHandle, ref NETDEV_FINDDATA_S lpFindData); /*NETDEV_FINDDATA_S*/

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClose(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlayBackControl(IntPtr lpPlayHandle, Int32 dwControlCode, ref Int64 pdwBuffer);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackCond, byte[] pszSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopGetFile(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, byte[] szPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZPresetList(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref int index, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEFOGGING_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_MOTION_ALARM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TAMPER_ALARM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatistic(IntPtr lpUserID, ref NETDEV_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref NETDEV_TRAFFIC_STATISTICS_DATA_S pstTrafficStatistic);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartMultiTrafficStatistic(IntPtr lpUserID, ref NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S pstStatisticCond, ref UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopTrafficStatistic(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTrafficStatisticProgress(IntPtr lpUserID, UInt32 udwSearchID, ref UInt32 pudwProgress);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindTrafficStatisticInfoList(IntPtr lpUserID, UInt32 udwSearchID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTrafficStatisticInfo(IntPtr lpFindHandle, ref NETDEV_TRAFFIC_STATISTICS_INFO_S pstStatisticInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTrafficStatisticInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConnectTime(Int32 dwWaitTime, Int32 dwTrytimes);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPictureFluency(IntPtr lpPlayHandle, Int32 dwFluency);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MakeKeyFrame(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSoundVolume(IntPtr lpPlayHandle, ref Int32 pdwVolume);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SoundVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMicVolume(IntPtr lpPlayHandle, ref Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_MicVolumeControl(IntPtr lpPlayHandle, Int32 dwVolume);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseMic(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartInputVoiceSrv(IntPtr lpUserID, Int32 dwChannelID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopInputVoiceSrv(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_InputVoiceData(IntPtr lpUserID, byte[] lpDataBuf, Int32 dwDataLen, ref NETDEV_AUDIO_SAMPLE_PARAM_S pstVoiceParam);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlaySound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ResetLostPacketRate(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CaptureNoPreview(IntPtr lpUserID, Int32 dwChannelID, Int32 dwStreamType, String szFileName, Int32 dwCaptureMode);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRenderScale(IntPtr lpRealHandle, Int32 enRenderScale); /*NETDEV_RENDER_SCALE_E*/

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_PlayBackByTime(IntPtr lpUserID, ref NETDEV_PLAYBACKCOND_S pstPlayBackInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPlayBack(IntPtr lpPlayHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_GetFileByName(IntPtr lpUserID, ref NETDEV_PLAYBACKINFO_S pstPlayBackInfo, String szSaveFileName, Int32 dwFormat);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset(IntPtr lpPlayHandle, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Reboot(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_OpenSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CloseSound(IntPtr lpRealHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZSelZoomIn_Other(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_OPERATEAREA_S pstPtzOperateArea);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login_V30(ref NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo, ref NETDEV_SELOG_INFO_S pstSELogInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindOrgInfoList(IntPtr lpUserID, ref NETDEV_ORG_FIND_COND_S pstFindCond);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextOrgInfo(IntPtr lpFindHandle, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseOrgInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo, ref Int32 pdwOrgID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyOrgInfo(IntPtr lpUserID, ref NETDEV_ORG_INFO_S pstOrgInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeleteOrgInfo(IntPtr lpUserID, ref NETDEV_DEL_ORG_INFO_S pstOrgDelInfo, ref NETDEV_ORG_BATCH_DEL_INFO_S pstOrgDelResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevList(IntPtr lpUserID, Int32 dwDevType);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevInfo(IntPtr lpFindHandle, ref NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindDevChnList(IntPtr lpUserID, Int32 dwDevID, Int32 dwChnType);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextDevChn(IntPtr lpFindHandle, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseDevChn(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo(IntPtr lpUserID, ref NETDEV_DEVICE_INFO_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDeviceInfo_V30(IntPtr lpUserID, Int32 dwDevID, ref NETDEV_DEV_INFO_V30_S pstDevInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnType(IntPtr lpUserID, Int32 dwChnID, ref Int32 pdwChnType);// pdwChnType: see NETDEV_CHN_TYPE_E

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetChnDetailByChnType(IntPtr lpUserID, Int32 dwChnID, Int32 dwChnType, IntPtr lpOutBuffer, int dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetTrackCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_TRACK_INFO_S pstTrackCruiseInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZTrackCruise(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZTrackCruiseCmd, string pszTrackCruiseName);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCalibrate(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_ORIENTATION_INFO_S pstOrientationInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_STREAM_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_SETTING_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_RECORD_PLAN_CFG_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_TRIGGER_ALARM_OUTPUT_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_VIDEO_OSD_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_INPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_ALARM_OUTPUT_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DISK_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_SYSTEM_NTP_INFO_LIST_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IMAGE_EXPOSURE_S lpInBuffer, Int32 dwOutBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PRIVACY_MASK_CFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_IRCUT_FILTER_INFO_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_RestoreConfig(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVideoEffect(IntPtr lpRealHandle, ref NETDEV_VIDEO_EFFECT_S pstImageInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDigitalZoom(IntPtr lpRealHandle, IntPtr hWnd, IntPtr pstRect);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUpnpNatState(IntPtr lpUserID, ref NETDEV_UPNP_NAT_STATE_S pstNatState);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyDeviceName(IntPtr lpUserID, byte[] strDeviceName);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetSystemTimeCfg(IntPtr lpUserID, ref NETDEV_TIME_CFG_S pstSystemTimeInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetRevTimeOut(ref NETDEV_REV_TIMEOUT_S pstRevTimeout);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDecodeVideoCB(IntPtr lpRealHandle, NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDataCallBack(IntPtr lpRealHandle, IntPtr cbPlayDataCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayDisplayCB(IntPtr lpRealHandle, IntPtr cbPlayDisplayCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPlayParseCB(IntPtr lpRealHandle, IntPtr cbPlayParseCallBack, Int32 bContinue, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_StartVoiceCom(IntPtr lpUserID, Int32 dwChannelID, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopVoiceCom(IntPtr lpVoiceComHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailList(IntPtr lpUserID, IntPtr pstUserDetailList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUser(IntPtr lpUserID, String strUserName);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreateUser(IntPtr lpUserID, IntPtr stUserInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUser(IntPtr lpUserID, IntPtr pstUserInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetCompassInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fCompassInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetGeolocationInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_GEOLACATION_INFO_S pstGPSInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConfigFile(IntPtr lpUserID, String strConfigPath);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAEnable(IntPtr lpUserID, Int32 dwEnableIVA);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetIVAShowParam(Int32 dwShowParam);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonLibCapacity(IntPtr lpUserID, Int32 dwTimeOut, ref NETDEV_PERSON_LIB_CAP_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CreatePersonLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstPersonLibInfo, ref UInt32 pudwID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstPersonLibInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstPersonLibList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonLibInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstFlagInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstQueryResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonInfo(IntPtr lpFindHandle, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMemberInfo(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_PERSON_INFO_S pstPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyPersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_PERSON_INFO_LIST_S pstPersonInfoList, ref NETDEV_PERSON_RESULT_LIST_S pstPersonResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfo(IntPtr lpUserID, UInt32 udwPersonLibID, UInt32 udwPersonID, UInt32 udwLastChange);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeletePersonInfoList(IntPtr lpUserID, UInt32 udwPersonLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindFaceRecordDetailList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextFaceRecordDetail(IntPtr lpFindHandle, ref NETDEV_FACE_RECORD_SNAPSHOT_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseFaceRecordDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetFaceRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, UInt32 udwFaceImageType, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPersonMonitorList(IntPtr lpUserID, UInt32 udwChannelID, ref NETDEV_MONITOR_QUERY_INFO_S pstQueryInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPersonMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePersonMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddPersonMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo, ref NETDEV_MONITOR_RESULT_INFO_S pstMonitorResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_BatchDeletePersonMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPersonMonitorRuleInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorProgress(IntPtr lpUserID, ref UInt32 pudwProgressRate);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindMonitorStatusList(IntPtr lpUserID, Int32 enType, ref UInt32 udwMonitorID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindLimit, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextMonitorStatusInfo(IntPtr lpFindHandle, ref NETDEV_MONITOR_MEMBER_INFO_S pstMonitorStats);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseMonitorStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetMonitorCapacity(IntPtr lpUserID, ref NETDEV_MONITOR_CAPACITY_INFO_S pstCapacityInfo, ref NETDEV_MONITOR_CAPACITY_LIST_S pstCapacityList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleLibList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleLibInfo(IntPtr lpFindHandle, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleLibList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibInfo(IntPtr lpUserID, ref NETDEV_LIB_INFO_S pstVehicleLibInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleLibInfo(IntPtr lpUserID, ref NETDEV_PERSON_LIB_LIST_S pstVehicleLibList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_DELETE_DB_FLAG_INFO_S pstDelLibFlag);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMemberList(IntPtr lpUserID, UInt32 udwLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyVehicleMemberInfo(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DelVehicleMemberList(IntPtr lpUserID, UInt32 udwLib, ref NETDEV_VEHICLE_INFO_LIST_S pstVehicleMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMemberDetailList(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_PERSON_QUERY_INFO_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstDBMemberList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMemberDetail(IntPtr lpFindHandle, ref NETDEV_VEHICLE_DETAIL_INFO_S pstVehicleMemberInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMemberDetail(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleRecordInfoList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_SMART_ALARM_LOG_RESULT_INFO_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleRecordInfo(IntPtr lpFindHandle, ref NETDEV_VEHICLE_RECORD_INFO_S pstRecordInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleRecordList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleRecordImageInfo(IntPtr lpUserID, UInt32 udwRecordID, ref NETDEV_FILE_INFO_S pstFileInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleLibMember(IntPtr lpUserID, UInt32 udwVehicleLibID, ref NETDEV_BATCH_OPERATE_MEMBER_LIST_S pstMemberList, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_MONITION_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteVehicleMonitorInfo(IntPtr lpUserID, ref NETDEV_BATCH_OPERATOR_LIST_S pstBatchList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindVehicleMonitorList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextVehicleMonitorInfo(IntPtr lpFindHandle, ref NETDEV_MONITION_INFO_S pstVehicleMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseVehicleMonitorList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetVehicleMonitorInfo(IntPtr lpUserID, UInt32 udwID, ref NETDEV_MONITION_RULE_INFO_S pstMonitorInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscribeSmart(IntPtr lpUserID, ref NETDEV_SUBSCRIBE_SMART_INFO_S pstSubscribeInfo, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnsubscribeSmart(IntPtr lpUserID, ref NETDEV_SMART_INFO_S pstSmartInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SubscibeLapiAlarm(IntPtr lpUserID, ref NETDEV_LAPI_SUB_INFO_S pstSubInfo, ref NETDEV_SUBSCRIBE_SUCC_INFO_S pstSubSuccInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_UnSubLapiAlarm(IntPtr lpUserID, UInt32 udwID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BASE_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonInfo(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ACSPersonCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_ACS_PERSON_INFO_S pstACSPersonInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_LIST_S pstACSPersonList, ref NETDEV_XW_BATCH_RESULT_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonList(IntPtr lpUserID, ref NETDEV_FACE_BATCH_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateList(IntPtr lpUserID, Int32 dwTamplateType, ref NETDEV_TIME_TEMPLATE_LIST_S pstTemplateList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplateInfo(IntPtr lpUserID, Int32 dwTemplateID, ref NETDEV_TIME_TEMPLATE_INFO_V30_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPermissionGroupList(IntPtr lpUserID, ref NETDEV_PERSON_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPermissionGroupInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERMISSION_INFO_S pstACSPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPermissionGroupList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionGroupInfo, ref UInt32 pUdwGroupID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_ACS_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonPermissionGroup(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstPermissionIDList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResutList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSinglePermGroupInfo(IntPtr lpUserID, UInt32 udwPermissionGroupID, ref NETDEV_ACS_PERMISSION_INFO_S pstAcsPerssionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindPermStatusList(IntPtr lpUserID, ref UInt32 udwPermGroupID, ref NETDEV_ALARM_LOG_COND_LIST_S pstQueryInfo, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextPermStatusInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERM_STATUS_S pstACSPermStatus);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindClosePermStatusList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetACSPersonPermission(IntPtr lpUserID, UInt32 udwPersonID, ref NETDEV_ACS_DOOR_PERMISSION_INFO_S pstPermissionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorCtrl(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DoorBatchCtrl(IntPtr lpUserID, Int32 dwCommand, ref NETDEV_OPERATE_LIST_S pstBatchCtrlInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSVisitLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSVisitLog(IntPtr lpFindHandle, ref NETDEV_ACS_VISIT_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSVisitLog(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSPersonBlackList(IntPtr lpUserID, ref NETDEV_PAGED_QUERY_INFO_S pstQueryCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSPersonBlackListInfo(IntPtr lpFindHandle, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSPersonBlackList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo, ref UInt32 pUdwBlackListID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteACSPersonBlackList(IntPtr lpUserID, ref NETDEV_OPERATE_LIST_S pstBlackList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetACSPersonBlackList(IntPtr lpUserID, ref NETDEV_ACS_PERSON_BLACKLIST_INFO_S pstBlackListInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_FindACSAttendanceLogList(IntPtr lpUserID, ref NETDEV_ALARM_LOG_COND_LIST_S pstFindCond, ref NETDEV_BATCH_OPERATE_BASIC_S pstResultInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextACSAttendanceLog(IntPtr lpFindHandle, ref NETDEV_ACS_ATTENDANCE_LOG_INFO_S pstACSLogInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseACSAttendanceLogList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSystemPicture(IntPtr lpUserID, string pszURL, UInt32 udwSize, IntPtr pszdata);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleInfoList(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleInfo(IntPtr lpFindHandle, ref NETDEV_ROLE_INFO_S pstRoleInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleInfoList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindTimeTemplateByTypeList(IntPtr lpUserID, UInt32 udwTemplateType);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextTimeTemplateByTypeInfo(IntPtr lpFindHandle, ref NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseTimeTemplateByTypeList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindUserDetailInfoListV30(IntPtr lpUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseUserDetailInfoListV30(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindRoleBaseInfoOfUserList(IntPtr lpUserID, UInt32 udwUserID);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindNextRoleBaseInfoOfUser(IntPtr lpFindHandle, ref NETDEV_ROLE_BASE_INFO_S pstRoleBaseInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_FindCloseRoleBaseInfoOfUserList(IntPtr lpFindHandle);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetTimeTemplate(IntPtr lpFindHandle, ref NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_DeleteUserV30(IntPtr lpFindHandle, UInt32 udwUserNum, ref NETDEV_USER_NAME_INFO_LIST_S pstUserNameList, ref NETDEV_BATCH_OPERATOR_LIST_S pstResultList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyRoleInfoOfUser(IntPtr lpFindHandle, UInt32 udwUserID, ref NETDEV_ID_LIST_S pstRoleList);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetUserDetailInfoV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_ModifyCurrentPin(IntPtr lpFindHandle, String szOldPassword, String szNewPassword);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_AddUserV30(IntPtr lpFindHandle, ref NETDEV_USER_DETAIL_INFO_V30_S pstUserModifyInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetStatus(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_STATUS_S pstPTZStaus);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZAbsoluteMove(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_ABSOLUTE_MOVE_S pstAbsoluteMove);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsolutePTInfo(IntPtr lpUserID, Int32 dwChannelID, NETDEV_PTZ_PT_POSITION_INFO_S pstPTPositionInfo);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, ref float fZoomRatio);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetPTZAbsoluteZoomInfo(IntPtr lpUserID, Int32 dwChannelID, float fZoomRatio);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetVideoDayNums(IntPtr lpUserID, Int32 dwChannelID, ref Int32 dwDayNums);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetConflagrationAlarmCallBack(IntPtr lpUserID, NETDEV_ConflagrationAlarmMessCallBack_PF cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetCarPlateCallBack(IntPtr lpUserID, NETDEV_CarPlateCallBack_PF cbCarPlateCallBack, IntPtr lpUserData);

        [DllImport(NetDevSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
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
}
