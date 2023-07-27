using System.Data.NHInterfaces;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
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
            return Path.GetFullPath(Environment.Is64BitProcess ? HikHCNetSdk.DllFileNameX64 : HikHCNetSdk.DllFileNameX86);
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
