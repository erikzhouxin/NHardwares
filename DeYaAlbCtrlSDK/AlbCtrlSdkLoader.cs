using System.Data.NHInterfaces;
using System.IO;

namespace System.Data.DeYaAlbCtrlSDK
{
    internal class AlbCtrlSdkLoader : ASdkDynamicLoader, IAlbCtrlSdkProxy
    {
        #region // 委托定义        
        private DCreater.DEV_Open _DEV_Open;
        private DCreater.DEV_Close _DEV_Close;
        private DCreater.DEV_ALB_Ctrl _DEV_ALB_Ctrl;
        private DCreater.DEV_SetEventHandle _DEV_SetEventHandle;
        private DCreater.DEV_EnableEventMessageEx _DEV_EnableEventMessageEx;
        private DCreater.DEV_GetStatus _DEV_GetStatus;
        //private DCreater.DEV_GetFaultBits _DEV_GetFaultBits;
        private DCreater.DEV_EnableLog _DEV_EnableLog;
        private DCreater.DEV_SetLogPath _DEV_SetLogPath;
        private DCreater.DEV_GetVersion _DEV_GetVersion;
        private DCreater.DEV_Queue _DEV_Queue;
        #endregion
        public AlbCtrlSdkLoader()
        {
            _DEV_Open = GetDelegate<DCreater.DEV_Open>(nameof(DCreater.DEV_Open));
            _DEV_Close = GetDelegate<DCreater.DEV_Close>(nameof(DCreater.DEV_Close));
            _DEV_ALB_Ctrl = GetDelegate<DCreater.DEV_ALB_Ctrl>(nameof(DCreater.DEV_ALB_Ctrl));
            _DEV_SetEventHandle = GetDelegate<DCreater.DEV_SetEventHandle>(nameof(DCreater.DEV_SetEventHandle));
            _DEV_EnableEventMessageEx = GetDelegate<DCreater.DEV_EnableEventMessageEx>(nameof(DCreater.DEV_EnableEventMessageEx));
            _DEV_GetStatus = GetDelegate<DCreater.DEV_GetStatus>(nameof(DCreater.DEV_GetStatus));
            //_DEV_GetFaultBits = GetDelegate<DCreater.DEV_GetFaultBits>(nameof(DCreater.DEV_GetFaultBits));
            _DEV_EnableLog = GetDelegate<DCreater.DEV_EnableLog>(nameof(DCreater.DEV_EnableLog));
            _DEV_SetLogPath = GetDelegate<DCreater.DEV_SetLogPath>(nameof(DCreater.DEV_SetLogPath));
            _DEV_GetVersion = GetDelegate<DCreater.DEV_GetVersion>(nameof(DCreater.DEV_GetVersion));
            _DEV_Queue = GetDelegate<DCreater.DEV_Queue>(nameof(DCreater.DEV_Queue));
        }
        /// <inheritdoc />
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? AlbCtrlSdk.DllFileNameX64 : AlbCtrlSdk.DllFileNameX86);
        }
        #region // 显示实现
        IntPtr IAlbCtrlSdkProxy.DEV_Open(string strIP) => _DEV_Open.Invoke(strIP);
        bool IAlbCtrlSdkProxy.DEV_Close(IntPtr h) => _DEV_Close.Invoke(h);
        bool IAlbCtrlSdkProxy.DEV_ALB_Ctrl(IntPtr h, bool bOpen) => _DEV_ALB_Ctrl.Invoke(h, bOpen);
        bool IAlbCtrlSdkProxy.DEV_SetEventHandle(IntPtr h, DEVEventCallBack pCallback) => _DEV_SetEventHandle.Invoke(h, pCallback);
        bool IAlbCtrlSdkProxy.DEV_EnableEventMessageEx(IntPtr h, IntPtr hWnd, int MsgID) => _DEV_EnableEventMessageEx.Invoke(h, hWnd, MsgID);
        bool IAlbCtrlSdkProxy.DEV_GetStatus(IntPtr h, out uint dwStatus) => _DEV_GetStatus.Invoke(h, out dwStatus);
        bool IAlbCtrlSdkProxy.DEV_GetFaultBits(IntPtr h, int dwFaultBits) => throw new NotSupportedException("替代方案:[DEV_GetStatus]此方法已弃用去除");
        bool IAlbCtrlSdkProxy.DEV_EnableLog(IntPtr h, bool bEnable) => _DEV_EnableLog.Invoke(h, bEnable);
        bool IAlbCtrlSdkProxy.DEV_SetLogPath(IntPtr h, string Path) => _DEV_SetLogPath.Invoke(h, Path);
        bool IAlbCtrlSdkProxy.DEV_GetVersion(IntPtr h, out long Version) => _DEV_GetVersion.Invoke(h, out Version);
        bool IAlbCtrlSdkProxy.DEV_Queue(IntPtr h, bool bOpen) => _DEV_Queue.Invoke(h, bOpen);
        #endregion
    }
}
