using System.Data.NHInterfaces;
using System.IO;

namespace System.Data.DeYaLpnrSDK
{
    internal class RWLPNRSdkLoader : ASdkDynamicLoader, IRWLPNRSdkProxy
    {
        #region // 委托定义        
        private DCreater.LPNR_EnableLiveFrame _LPNR_EnableLiveFrame;
        private DCreater.LPNR_GetCapturedImage _LPNR_GetCapturedImage;
        private DCreater.LPNR_GetCapturedImageSize _LPNR_GetCapturedImageSize;
        private DCreater.LPNR_GetLiveFrame _LPNR_GetLiveFrame;
        private DCreater.LPNR_GetLiveFrameSize _LPNR_GetLiveFrameSize;
        private DCreater.LPNR_GetPlateNumber _LPNR_GetPlateNumber;
        private DCreater.LPNR_Init _LPNR_Init;
        private DCreater.LPNR_IsOnline _LPNR_IsOnline;
        private DCreater.LPNR_SetCallBack _LPNR_SetCallBack;
        private DCreater.LPNR_SoftTrigger _LPNR_SoftTrigger;
        private DCreater.LPNR_SyncTime _LPNR_SyncTime;
        private DCreater.LPNR_Terminate _LPNR_Terminate;
        #endregion
        public RWLPNRSdkLoader()
        {
            _LPNR_EnableLiveFrame = GetDelegate<DCreater.LPNR_EnableLiveFrame>(nameof(DCreater.LPNR_EnableLiveFrame));
            _LPNR_GetCapturedImage = GetDelegate<DCreater.LPNR_GetCapturedImage>(nameof(DCreater.LPNR_GetCapturedImage));
            _LPNR_GetCapturedImageSize = GetDelegate<DCreater.LPNR_GetCapturedImageSize>(nameof(DCreater.LPNR_GetCapturedImageSize));
            _LPNR_GetLiveFrame = GetDelegate<DCreater.LPNR_GetLiveFrame>(nameof(DCreater.LPNR_GetLiveFrame));
            _LPNR_GetLiveFrameSize = GetDelegate<DCreater.LPNR_GetLiveFrameSize>(nameof(DCreater.LPNR_GetLiveFrameSize));
            _LPNR_GetPlateNumber = GetDelegate<DCreater.LPNR_GetPlateNumber>(nameof(DCreater.LPNR_GetPlateNumber));
            _LPNR_Init = GetDelegate<DCreater.LPNR_Init>(nameof(DCreater.LPNR_Init));
            _LPNR_IsOnline = GetDelegate<DCreater.LPNR_IsOnline>(nameof(DCreater.LPNR_IsOnline));
            _LPNR_SetCallBack = GetDelegate<DCreater.LPNR_SetCallBack>(nameof(DCreater.LPNR_SetCallBack));
            _LPNR_SoftTrigger = GetDelegate<DCreater.LPNR_SoftTrigger>(nameof(DCreater.LPNR_SoftTrigger));
            _LPNR_SyncTime = GetDelegate<DCreater.LPNR_SyncTime>(nameof(DCreater.LPNR_SyncTime));
            _LPNR_Terminate = GetDelegate<DCreater.LPNR_Terminate>(nameof(DCreater.LPNR_Terminate));
        }
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? RWLPNRSdk.DllFileNameX64 : RWLPNRSdk.DllFileNameX86);
        }
        #region // 显示实现
        int IRWLPNRSdkProxy.LPNR_EnableLiveFrame(IntPtr lib, int en) => _LPNR_EnableLiveFrame.Invoke(lib, en);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImage(IntPtr lib, byte[] date) => _LPNR_GetCapturedImage.Invoke(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImageSize(IntPtr lib) => _LPNR_GetCapturedImageSize.Invoke(lib);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrame(IntPtr lib, byte[] date) => _LPNR_GetLiveFrame.Invoke(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrameSize(IntPtr lib) => _LPNR_GetLiveFrameSize.Invoke(lib);
        int IRWLPNRSdkProxy.LPNR_GetPlateNumber(IntPtr lib, byte[] funcName) => _LPNR_GetPlateNumber.Invoke(lib, funcName);
        IntPtr IRWLPNRSdkProxy.LPNR_Init(byte[] ip) => _LPNR_Init.Invoke(ip);
        int IRWLPNRSdkProxy.LPNR_IsOnline(IntPtr lib) => _LPNR_IsOnline.Invoke(lib);
        int IRWLPNRSdkProxy.LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb) => _LPNR_SetCallBack.Invoke(lib, cb);
        int IRWLPNRSdkProxy.LPNR_SoftTrigger(IntPtr lib) => _LPNR_SoftTrigger.Invoke(lib);
        int IRWLPNRSdkProxy.LPNR_SyncTime(IntPtr lib) => _LPNR_SyncTime.Invoke(lib);
        int IRWLPNRSdkProxy.LPNR_Terminate(IntPtr handle) => _LPNR_Terminate.Invoke(handle);
        #endregion
    }
}
