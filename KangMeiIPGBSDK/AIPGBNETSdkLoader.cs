using System.Data.NHInterfaces;
using System.IO;

namespace System.Data.KangMeiIPGBSDK
{
    internal class IPGBNETSdkLoader : ASdkDynamicLoader, IIPGBNETSdkProxy
    {
        #region // 委托定义
        private DCreater.IPGBNETSDK_SetConnStatusCallBack _IPGBNETSDK_SetConnStatusCallBack;
        private DCreater.IPGBNETSDK_SetTerminalStatusCallBack _IPGBNETSDK_SetTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack _IPGBNETSDK_SetBatchTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack _IPGBNETSDK_SetEncTerminalStatusCallBack;
        private DCreater.IPGBNETSDK_SetGbStreamStatusCallBack _IPGBNETSDK_SetGbStreamStatusCallBack;
        private DCreater.IPGBNETSDK_SetFireStaCallBack _IPGBNETSDK_SetFireStaCallBack;
        private DCreater.IPGBNETSDK_Init _IPGBNETSDK_Init;
        private DCreater.IPGBNETSDK_Cleanup _IPGBNETSDK_Cleanup;
        private DCreater.IPGBNETSDK_GetSdkVer _IPGBNETSDK_GetSdkVer;
        private DCreater.IPGBNETSDK_LogIn _IPGBNETSDK_LogIn;
        private DCreater.IPGBNETSDK_LogOut _IPGBNETSDK_LogOut;
        private DCreater.IPGBNETSDK_GetConnStatusInfo _IPGBNETSDK_GetConnStatusInfo;
        private DCreater.IPGBNETSDK_GetOneSerFileInfo _IPGBNETSDK_GetOneSerFileInfo;
        private DCreater.IPGBNETSDK_GetSysSoundCardINFO _IPGBNETSDK_GetSysSoundCardINFO;
        private DCreater.IPGBNETSDK_SetSysSoundCardMix _IPGBNETSDK_SetSysSoundCardMix;
        private DCreater.IPGBNETSDK_CreateSerFileGbStream _IPGBNETSDK_CreateSerFileGbStream;
        private DCreater.IPGBNETSDK_CreateLcaFileGbStream _IPGBNETSDK_CreateLcaFileGbStream;
        private DCreater.IPGBNETSDK_CreateTextGbStream _IPGBNETSDK_CreateTextGbStream;
        private DCreater.IPGBNETSDK_CreateTerminalCbStream _IPGBNETSDK_CreateTerminalCbStream;
        private DCreater.IPGBNETSDK_CreateEncTerminalCbStream _IPGBNETSDK_CreateEncTerminalCbStream;
        private DCreater.IPGBNETSDK_CreateSoundCarSrcChannel _IPGBNETSDK_CreateSoundCarSrcChannel;
        private DCreater.IPGBNETSDK_CreateSoundCarGbStream _IPGBNETSDK_CreateSoundCarGbStream;
        private DCreater.IPGBNETSDK_CreateThirdRealSrcChannel _IPGBNETSDK_CreateThirdRealSrcChannel;
        private DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel _IPGBNETSDK_FillDataToThirdRealSrcChannel;
        private DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream _IPGBNETSDK_CreateThirdRealAudioGbStream;
        private DCreater.IPGBNETSDK_DelOneAudioSrcChannel _IPGBNETSDK_DelOneAudioSrcChannel;
        private DCreater.IPGBNETSDK_DelOneStream _IPGBNETSDK_DelOneStream;
        private DCreater.IPGBNETSDK_SetTmOutVol _IPGBNETSDK_SetTmOutVol;
        private DCreater.IPGBNETSDK_ThreeFireArm _IPGBNETSDK_ThreeFireArm;
        private DCreater.IPGBNETSDK_GetMp3FileInfo _IPGBNETSDK_GetMp3FileInfo;
        private DCreater.IPGBNETSDK_CtrlAnyTmForCall _IPGBNETSDK_CtrlAnyTmForCall;
        private DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus _IPGBNETSDK_CtrlAnyTmTalkStatus;
        private DCreater.IPGBNETSDK_GetUserFqInfo _IPGBNETSDK_GetUserFqInfo;
        #endregion
        public IPGBNETSdkLoader()
        {
            _IPGBNETSDK_SetConnStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetConnStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetConnStatusCallBack));
            _IPGBNETSDK_SetTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetTerminalStatusCallBack));
            _IPGBNETSDK_SetBatchTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetBatchTerminalStatusCallBack));
            _IPGBNETSDK_SetEncTerminalStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetEncTerminalStatusCallBack));
            _IPGBNETSDK_SetGbStreamStatusCallBack = GetDelegate<DCreater.IPGBNETSDK_SetGbStreamStatusCallBack>(nameof(DCreater.IPGBNETSDK_SetGbStreamStatusCallBack));
            _IPGBNETSDK_SetFireStaCallBack = GetDelegate<DCreater.IPGBNETSDK_SetFireStaCallBack>(nameof(DCreater.IPGBNETSDK_SetFireStaCallBack));
            _IPGBNETSDK_Init = GetDelegate<DCreater.IPGBNETSDK_Init>(nameof(DCreater.IPGBNETSDK_Init));
            _IPGBNETSDK_Cleanup = GetDelegate<DCreater.IPGBNETSDK_Cleanup>(nameof(DCreater.IPGBNETSDK_Cleanup));
            _IPGBNETSDK_GetSdkVer = GetDelegate<DCreater.IPGBNETSDK_GetSdkVer>(nameof(DCreater.IPGBNETSDK_GetSdkVer));
            _IPGBNETSDK_LogIn = GetDelegate<DCreater.IPGBNETSDK_LogIn>(nameof(DCreater.IPGBNETSDK_LogIn));
            _IPGBNETSDK_LogOut = GetDelegate<DCreater.IPGBNETSDK_LogOut>(nameof(DCreater.IPGBNETSDK_LogOut));
            _IPGBNETSDK_GetConnStatusInfo = GetDelegate<DCreater.IPGBNETSDK_GetConnStatusInfo>(nameof(DCreater.IPGBNETSDK_GetConnStatusInfo));
            _IPGBNETSDK_GetOneSerFileInfo = GetDelegate<DCreater.IPGBNETSDK_GetOneSerFileInfo>(nameof(DCreater.IPGBNETSDK_GetOneSerFileInfo));
            _IPGBNETSDK_GetSysSoundCardINFO = GetDelegate<DCreater.IPGBNETSDK_GetSysSoundCardINFO>(nameof(DCreater.IPGBNETSDK_GetSysSoundCardINFO));
            _IPGBNETSDK_SetSysSoundCardMix = GetDelegate<DCreater.IPGBNETSDK_SetSysSoundCardMix>(nameof(DCreater.IPGBNETSDK_SetSysSoundCardMix));
            _IPGBNETSDK_CreateSerFileGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateSerFileGbStream>(nameof(DCreater.IPGBNETSDK_CreateSerFileGbStream));
            _IPGBNETSDK_CreateLcaFileGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateLcaFileGbStream>(nameof(DCreater.IPGBNETSDK_CreateLcaFileGbStream));
            _IPGBNETSDK_CreateTextGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateTextGbStream>(nameof(DCreater.IPGBNETSDK_CreateTextGbStream));
            _IPGBNETSDK_CreateTerminalCbStream = GetDelegate<DCreater.IPGBNETSDK_CreateTerminalCbStream>(nameof(DCreater.IPGBNETSDK_CreateTerminalCbStream));
            _IPGBNETSDK_CreateEncTerminalCbStream = GetDelegate<DCreater.IPGBNETSDK_CreateEncTerminalCbStream>(nameof(DCreater.IPGBNETSDK_CreateEncTerminalCbStream));
            _IPGBNETSDK_CreateSoundCarSrcChannel = GetDelegate<DCreater.IPGBNETSDK_CreateSoundCarSrcChannel>(nameof(DCreater.IPGBNETSDK_CreateSoundCarSrcChannel));
            _IPGBNETSDK_CreateSoundCarGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateSoundCarGbStream>(nameof(DCreater.IPGBNETSDK_CreateSoundCarGbStream));
            _IPGBNETSDK_CreateThirdRealSrcChannel = GetDelegate<DCreater.IPGBNETSDK_CreateThirdRealSrcChannel>(nameof(DCreater.IPGBNETSDK_CreateThirdRealSrcChannel));
            _IPGBNETSDK_FillDataToThirdRealSrcChannel = GetDelegate<DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel>(nameof(DCreater.IPGBNETSDK_FillDataToThirdRealSrcChannel));
            _IPGBNETSDK_CreateThirdRealAudioGbStream = GetDelegate<DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream>(nameof(DCreater.IPGBNETSDK_CreateThirdRealAudioGbStream));
            _IPGBNETSDK_DelOneAudioSrcChannel = GetDelegate<DCreater.IPGBNETSDK_DelOneAudioSrcChannel>(nameof(DCreater.IPGBNETSDK_DelOneAudioSrcChannel));
            _IPGBNETSDK_DelOneStream = GetDelegate<DCreater.IPGBNETSDK_DelOneStream>(nameof(DCreater.IPGBNETSDK_DelOneStream));
            _IPGBNETSDK_SetTmOutVol = GetDelegate<DCreater.IPGBNETSDK_SetTmOutVol>(nameof(DCreater.IPGBNETSDK_SetTmOutVol));
            _IPGBNETSDK_ThreeFireArm = GetDelegate<DCreater.IPGBNETSDK_ThreeFireArm>(nameof(DCreater.IPGBNETSDK_ThreeFireArm));
            _IPGBNETSDK_GetMp3FileInfo = GetDelegate<DCreater.IPGBNETSDK_GetMp3FileInfo>(nameof(DCreater.IPGBNETSDK_GetMp3FileInfo));
            _IPGBNETSDK_CtrlAnyTmForCall = GetDelegate<DCreater.IPGBNETSDK_CtrlAnyTmForCall>(nameof(DCreater.IPGBNETSDK_CtrlAnyTmForCall));
            _IPGBNETSDK_CtrlAnyTmTalkStatus = GetDelegate<DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus>(nameof(DCreater.IPGBNETSDK_CtrlAnyTmTalkStatus));
            _IPGBNETSDK_GetUserFqInfo = GetDelegate<DCreater.IPGBNETSDK_GetUserFqInfo>(nameof(DCreater.IPGBNETSDK_GetUserFqInfo));
        }
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? IPGBNETSdk.DllFileNameX64 : IPGBNETSdk.DllFileNameX86);
        }
        #region // 显示实现
        void IIPGBNETSdkProxy.IPGBNETSDK_Cleanup() => _IPGBNETSDK_Cleanup.Invoke();
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateEncTerminalCbStream(uint UserId, IPGBSDK_GBENCTMCBINFO pGbinfo) => _IPGBNETSDK_CreateEncTerminalCbStream.Invoke(UserId, pGbinfo);

        int IIPGBNETSdkProxy.IPGBNETSDK_CreateLcaFileGbStream(uint UserId, IPGBSDK_GBLCAFILEINFO pGbinfo) => _IPGBNETSDK_CreateLcaFileGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSerFileGbStream(uint UserId, IPGBSDK_GBSERFILEINFO pGbinfo) => _IPGBNETSDK_CreateSerFileGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarGbStream(uint UserId, IPGBSDK_GBSoundCarINFO pGbinfo) => _IPGBNETSDK_CreateSoundCarGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateSoundCarSrcChannel(IPGBSDK_SoundCarSrcINFO pSrcinfo) => _IPGBNETSDK_CreateSoundCarSrcChannel.Invoke(pSrcinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTerminalCbStream(uint UserId, IPGBSDK_GBTMCBINFO pGbinfo) => _IPGBNETSDK_CreateTerminalCbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateTextGbStream(uint UserId, IPGBSDK_GBTEXTINFO pGbinfo) => _IPGBNETSDK_CreateTextGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealAudioGbStream(uint UserId, IPGBSDK_GBTHIRDREALAUDIOINFO pGbinfo) => _IPGBNETSDK_CreateThirdRealAudioGbStream.Invoke(UserId, pGbinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_CreateThirdRealSrcChannel(IPGBSDK_ThirdRealSrcINFO pSrcinfo, out string outdesb) => _IPGBNETSDK_CreateThirdRealSrcChannel.Invoke(pSrcinfo, out outdesb);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmForCall(uint UserId, uint MainTmID, uint otherTmid) => _IPGBNETSDK_CtrlAnyTmForCall.Invoke(UserId, MainTmID, otherTmid);
        int IIPGBNETSdkProxy.IPGBNETSDK_CtrlAnyTmTalkStatus(uint UserId, uint TmID, byte CtlType) => _IPGBNETSDK_CtrlAnyTmTalkStatus.Invoke(UserId, TmID, CtlType);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneAudioSrcChannel(uint ASrcId) => _IPGBNETSDK_DelOneAudioSrcChannel.Invoke(ASrcId);
        int IIPGBNETSdkProxy.IPGBNETSDK_DelOneStream(uint UserId, uint StreamId) => _IPGBNETSDK_DelOneStream.Invoke(UserId, StreamId);
        int IIPGBNETSdkProxy.IPGBNETSDK_FillDataToThirdRealSrcChannel(uint ASrcId, string buf, int len) => _IPGBNETSDK_FillDataToThirdRealSrcChannel.Invoke(ASrcId, buf, len);
        NETEM_SDKLOGSTA_TYPE IIPGBNETSdkProxy.IPGBNETSDK_GetConnStatusInfo(uint UserId, out IPGBSDK_USERINFO lpUserInfo) => _IPGBNETSDK_GetConnStatusInfo.Invoke(UserId, out lpUserInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetMp3FileInfo(string FilePath, out IPGBSDK_LCA_MP3INFO pMp3Fileinfo) => _IPGBNETSDK_GetMp3FileInfo.Invoke(FilePath, out pMp3Fileinfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetOneSerFileInfo(uint UserId, out IPGBSDK_SER_ONEFILEINFO Finfo, bool ISFirst) => _IPGBNETSDK_GetOneSerFileInfo.Invoke(UserId, out Finfo, ISFirst);
        uint IIPGBNETSdkProxy.IPGBNETSDK_GetSdkVer() => _IPGBNETSDK_GetSdkVer.Invoke();
        void IIPGBNETSdkProxy.IPGBNETSDK_GetSysSoundCardINFO(out IPGBSDK_SOUNDCARDINFO SoundInfo) => _IPGBNETSDK_GetSysSoundCardINFO.Invoke(out SoundInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_GetUserFqInfo(uint UserId, out IPGBSDK_USERFQINFO pFqInfo) => _IPGBNETSDK_GetUserFqInfo.Invoke(UserId, out pFqInfo);
        int IIPGBNETSdkProxy.IPGBNETSDK_Init(ushort Aport) => _IPGBNETSDK_Init.Invoke(Aport);
        int IIPGBNETSdkProxy.IPGBNETSDK_LogIn(IPGBSDK_LOGSERVER lpSer) => _IPGBNETSDK_LogIn.Invoke(lpSer);
        void IIPGBNETSdkProxy.IPGBNETSDK_LogOut(uint UserId) => _IPGBNETSDK_LogOut.Invoke(UserId);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetBatchTerminalStatusCallBack(SDKfBatchTerminalStatus TerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetBatchTerminalStatusCallBack.Invoke(TerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetConnStatusCallBack(SDKfConnectStatus ConnStaCallBack, long dwUser) => _IPGBNETSDK_SetConnStatusCallBack.Invoke(ConnStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetEncTerminalStatusCallBack(SDKfEncTerminalStatus EncTerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetEncTerminalStatusCallBack.Invoke(EncTerminalStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetFireStaCallBack(SDKfFireSta FireStaCallBack, long dwUser) => _IPGBNETSDK_SetFireStaCallBack.Invoke(FireStaCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetGbStreamStatusCallBack(SDKfGbStreamStatus StreamStatusCallBack, long dwUser) => _IPGBNETSDK_SetGbStreamStatusCallBack.Invoke(StreamStatusCallBack, dwUser);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetSysSoundCardMix(string CapMixName, byte SetType, uint MVal) => _IPGBNETSDK_SetSysSoundCardMix.Invoke(CapMixName, SetType, MVal);
        void IIPGBNETSdkProxy.IPGBNETSDK_SetTerminalStatusCallBack(SDKfTerminalStatus TerminalStatusCallBack, long dwUser) => _IPGBNETSDK_SetTerminalStatusCallBack.Invoke(TerminalStatusCallBack, dwUser);
        int IIPGBNETSdkProxy.IPGBNETSDK_SetTmOutVol(uint UserId, IPGBSDK_SET_TMVOL pVol) => _IPGBNETSDK_SetTmOutVol.Invoke(UserId, pVol);
        int IIPGBNETSdkProxy.IPGBNETSDK_ThreeFireArm(uint UserId, IPGBSDK_THREEFIRINFO FirePinInfo, byte PinType) => _IPGBNETSDK_ThreeFireArm.Invoke(UserId, FirePinInfo, PinType);
        #endregion
    }
}
