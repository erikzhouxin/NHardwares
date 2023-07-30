using System.Data.NHInterfaces;
using System.IO;

namespace System.Data.KangMeiIPGBSDK
{
    internal class IPGBPUSHSdkLoader : ASdkDynamicLoader, IIPGBPUSHSdkProxy
    {
        #region // 委托定义
        private DCreater.IPGBPUSHSTREAM_SetCallBackPushStatus _IPGBPUSHSTREAM_SetCallBackPushStatus;
        private DCreater.IPGBPUSHSTREAM_Init _IPGBPUSHSTREAM_Init;
        private DCreater.IPGBPUSHSTREAM_Cleanup _IPGBPUSHSTREAM_Cleanup;
        private DCreater.IPGBPUSHSTREAM_GetSysSoundCardINFO _IPGBPUSHSTREAM_GetSysSoundCardINFO;
        private DCreater.IPGBPUSHSTREAM_SetSysSoundCardVol _IPGBPUSHSTREAM_SetSysSoundCardVol;
        private DCreater.IPGBPUSHSTREAM_CreateSoundCardPushStream _IPGBPUSHSTREAM_CreateSoundCardPushStream;
        private DCreater.IPGBPUSHSTREAM_CreateThirdPushStream _IPGBPUSHSTREAM_CreateThirdPushStream;
        private DCreater.IPGBPUSHSTREAM_FillDataToThirdStream _IPGBPUSHSTREAM_FillDataToThirdStream;
        private DCreater.IPGBPUSHSTREAM_DelOnePushStream _IPGBPUSHSTREAM_DelOnePushStream;
        private DCreater.IPGBPUSHSTREAM_GetMp3FileInfo _IPGBPUSHSTREAM_GetMp3FileInfo;
        #endregion
        public IPGBPUSHSdkLoader()
        {
            _IPGBPUSHSTREAM_SetCallBackPushStatus = GetDelegate<DCreater.IPGBPUSHSTREAM_SetCallBackPushStatus>(nameof(DCreater.IPGBPUSHSTREAM_SetCallBackPushStatus));
            _IPGBPUSHSTREAM_Init = GetDelegate<DCreater.IPGBPUSHSTREAM_Init>(nameof(DCreater.IPGBPUSHSTREAM_Init));
            _IPGBPUSHSTREAM_Cleanup = GetDelegate<DCreater.IPGBPUSHSTREAM_Cleanup>(nameof(DCreater.IPGBPUSHSTREAM_Cleanup));
            _IPGBPUSHSTREAM_GetSysSoundCardINFO = GetDelegate<DCreater.IPGBPUSHSTREAM_GetSysSoundCardINFO>(nameof(DCreater.IPGBPUSHSTREAM_GetSysSoundCardINFO));
            _IPGBPUSHSTREAM_SetSysSoundCardVol = GetDelegate<DCreater.IPGBPUSHSTREAM_SetSysSoundCardVol>(nameof(DCreater.IPGBPUSHSTREAM_SetSysSoundCardVol));
            _IPGBPUSHSTREAM_CreateSoundCardPushStream = GetDelegate<DCreater.IPGBPUSHSTREAM_CreateSoundCardPushStream>(nameof(DCreater.IPGBPUSHSTREAM_CreateSoundCardPushStream));
            _IPGBPUSHSTREAM_CreateThirdPushStream = GetDelegate<DCreater.IPGBPUSHSTREAM_CreateThirdPushStream>(nameof(DCreater.IPGBPUSHSTREAM_CreateThirdPushStream));
            _IPGBPUSHSTREAM_FillDataToThirdStream = GetDelegate<DCreater.IPGBPUSHSTREAM_FillDataToThirdStream>(nameof(DCreater.IPGBPUSHSTREAM_FillDataToThirdStream));
            _IPGBPUSHSTREAM_DelOnePushStream = GetDelegate<DCreater.IPGBPUSHSTREAM_DelOnePushStream>(nameof(DCreater.IPGBPUSHSTREAM_DelOnePushStream));
            _IPGBPUSHSTREAM_GetMp3FileInfo = GetDelegate<DCreater.IPGBPUSHSTREAM_GetMp3FileInfo>(nameof(DCreater.IPGBPUSHSTREAM_GetMp3FileInfo));
        }
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? IPGBPUSHSdk.DllFileNameX64 : IPGBPUSHSdk.DllFileNameX86);
        }
        #region // 显示实现
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Cleanup() => _IPGBPUSHSTREAM_Cleanup.Invoke();
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo) => _IPGBPUSHSTREAM_CreateSoundCardPushStream.Invoke(pSrcinfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo) => _IPGBPUSHSTREAM_CreateThirdPushStream.Invoke(pSrcinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_DelOnePushStream(uint StreamId) => _IPGBPUSHSTREAM_DelOnePushStream.Invoke(StreamId);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len) => _IPGBPUSHSTREAM_FillDataToThirdStream.Invoke(StreamId, buf, len);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo) => _IPGBPUSHSTREAM_GetMp3FileInfo.Invoke(FilePath, out pMp3Fileinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo) => _IPGBPUSHSTREAM_GetSysSoundCardINFO.Invoke(out SoundInfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Init() => _IPGBPUSHSTREAM_Init.Invoke();
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser) => _IPGBPUSHSTREAM_SetCallBackPushStatus.Invoke(pFunc, puser);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal) => _IPGBPUSHSTREAM_SetSysSoundCardVol.Invoke(CapMixName, MVal);
        #endregion
    }
}
