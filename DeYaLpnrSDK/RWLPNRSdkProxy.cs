using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaLpnrSDK
{
    /// <summary>
    /// 德亚道闸SDK代理
    /// </summary>
    public interface IRWLPNRSdkProxy
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        IntPtr LPNR_Init(byte[] ip);
        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        int LPNR_Terminate(IntPtr handle);
        /// <summary>
        /// 设置回调
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="cb"></param>
        /// <returns></returns>
        int LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb);
        /// <summary>
        /// 获取车牌
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="funcName"></param>
        /// <returns></returns>
        int LPNR_GetPlateNumber(IntPtr lib, byte[] funcName);
        /// <summary>
        /// 同步时间
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_SyncTime(IntPtr lib);
        /// <summary>
        /// 启用感应线圈
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        int LPNR_EnableLiveFrame(IntPtr lib, int en);
        /// <summary>
        /// 是在线
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_IsOnline(IntPtr lib);
        /// <summary>
        /// 获取截图大小
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_GetCapturedImageSize(IntPtr lib);
        /// <summary>
        /// 获取感应线圈
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int LPNR_GetLiveFrame(IntPtr lib, byte[] date);
        /// <summary>
        /// 获取感应线圈大小
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_GetLiveFrameSize(IntPtr lib);
        /// <summary>
        /// 获取截图
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        int LPNR_GetCapturedImage(IntPtr lib, byte[] date);
        /// <summary>
        /// 触发器
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        int LPNR_SoftTrigger(IntPtr lib);
    }
    internal class RWLPNRSdkDller : IRWLPNRSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IRWLPNRSdkProxy Instance { get; } = new RWLPNRSdkDller();
        private RWLPNRSdkDller() { }
        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static IntPtr LPNR_Init(byte[] ip);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_Terminate(IntPtr handle);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SetCallBack(IntPtr lib, LPNRCallBack cb);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetPlateNumber(IntPtr lib, byte[] funcName);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_SyncTime(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_EnableLiveFrame(IntPtr lib, int en);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_IsOnline(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImageSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrame(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetLiveFrameSize(IntPtr lib);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static int LPNR_GetCapturedImage(IntPtr lib, byte[] date);

        [DllImport(RWLPNRSdk.DllFileName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
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
            return RWLPNRSdk.DllFullName;
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
