using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaLpnrSDK
{
    internal class RWLPNRSdkDllerX64 : IRWLPNRSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IRWLPNRSdkProxy Instance { get; } = new RWLPNRSdkDllerX64();
        private RWLPNRSdkDllerX64() { }
        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static IntPtr LPNR_Init(byte[] ip);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_Terminate(IntPtr handle);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetPlateNumber(IntPtr lib, byte[] funcName);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SyncTime(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_EnableLiveFrame(IntPtr lib, int en);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_IsOnline(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImageSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrame(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrameSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImage(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileNameX64, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SoftTrigger(IntPtr lib);
        #region // 显示实现
        int IRWLPNRSdkProxy.LPNR_EnableLiveFrame(IntPtr lib, int en) => LPNR_EnableLiveFrame(lib, en);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImage(IntPtr lib, byte[] date) => LPNR_GetCapturedImage(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImageSize(IntPtr lib) => LPNR_GetCapturedImageSize(lib);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrame(IntPtr lib, byte[] date) => LPNR_GetLiveFrame(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrameSize(IntPtr lib) => LPNR_GetLiveFrameSize(lib);
        int IRWLPNRSdkProxy.LPNR_GetPlateNumber(IntPtr lib, byte[] funcName) => LPNR_GetPlateNumber(lib, funcName);
        IntPtr IRWLPNRSdkProxy.LPNR_Init(byte[] ip) => LPNR_Init(ip);
        int IRWLPNRSdkProxy.LPNR_IsOnline(IntPtr lib) => LPNR_IsOnline(lib);
        int IRWLPNRSdkProxy.LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb) => LPNR_SetCallBack(lib, cb);
        int IRWLPNRSdkProxy.LPNR_SoftTrigger(IntPtr lib) => LPNR_SoftTrigger(lib);
        int IRWLPNRSdkProxy.LPNR_SyncTime(IntPtr lib) => LPNR_SyncTime(lib);
        int IRWLPNRSdkProxy.LPNR_Terminate(IntPtr handle) => LPNR_Terminate(handle);
        #endregion
    }
    internal class RWLPNRSdkDllerX86 : IRWLPNRSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IRWLPNRSdkProxy Instance { get; } = new RWLPNRSdkDllerX86();
        private RWLPNRSdkDllerX86() { }
        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static IntPtr LPNR_Init(byte[] ip);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_Terminate(IntPtr handle);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetPlateNumber(IntPtr lib, byte[] funcName);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SyncTime(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_EnableLiveFrame(IntPtr lib, int en);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_IsOnline(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImageSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrame(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrameSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImage(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileNameX86, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SoftTrigger(IntPtr lib);
        #region // 显示实现
        int IRWLPNRSdkProxy.LPNR_EnableLiveFrame(IntPtr lib, int en) => LPNR_EnableLiveFrame(lib, en);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImage(IntPtr lib, byte[] date) => LPNR_GetCapturedImage(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetCapturedImageSize(IntPtr lib) => LPNR_GetCapturedImageSize(lib);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrame(IntPtr lib, byte[] date) => LPNR_GetLiveFrame(lib, date);
        int IRWLPNRSdkProxy.LPNR_GetLiveFrameSize(IntPtr lib) => LPNR_GetLiveFrameSize(lib);
        int IRWLPNRSdkProxy.LPNR_GetPlateNumber(IntPtr lib, byte[] funcName) => LPNR_GetPlateNumber(lib, funcName);
        IntPtr IRWLPNRSdkProxy.LPNR_Init(byte[] ip) => LPNR_Init(ip);
        int IRWLPNRSdkProxy.LPNR_IsOnline(IntPtr lib) => LPNR_IsOnline(lib);
        int IRWLPNRSdkProxy.LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb) => LPNR_SetCallBack(lib, cb);
        int IRWLPNRSdkProxy.LPNR_SoftTrigger(IntPtr lib) => LPNR_SoftTrigger(lib);
        int IRWLPNRSdkProxy.LPNR_SyncTime(IntPtr lib) => LPNR_SyncTime(lib);
        int IRWLPNRSdkProxy.LPNR_Terminate(IntPtr handle) => LPNR_Terminate(handle);
        #endregion
    }
}
