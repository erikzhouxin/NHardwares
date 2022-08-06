using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.KangMeiIPGBSDK
{
    /// <summary>
    /// 推流SDK代理
    /// </summary>
    public interface IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 设置推流状态回调函数
        /// </summary>
        /// <param name="pFunc">回调函数地址</param>
        /// <param name="puser">用户类指针</param>
        void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /// <summary>
        /// SDK初始化
        /// </summary>
        /// <returns>返回0成功</returns>
        int IPGBPUSHSTREAM_Init();
        /// <summary>
        /// SDK退出清理
        /// </summary>
        void IPGBPUSHSTREAM_Cleanup();
        /// <summary>
        /// 获取得到系统的声卡信息
        /// </summary>
        /// <param name="SoundInfo">输出系统声卡混音接口</param>
        void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /// <summary>
        /// 设置系统声卡混音接口音量
        /// </summary>
        /// <param name="CapMixName">混音接口名</param>
        /// <param name="MVal">音量值 0-100</param>
        void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /// <summary>
        /// 创建实时声卡采集推流
        /// </summary>
        /// <param name="pSrcinfo">推流信息</param>
        /// <returns>成功返回推流ID（大于0）</returns>
        int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /// <summary>
        /// 创建本地第三方音频流推流
        /// </summary>
        /// <param name="pSrcinfo">推流信息</param>
        /// <returns>成功返回推流ID（大于0）</returns>
        int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /// <summary>
        /// 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
        /// </summary>
        /// <param name="StreamId">推流ID</param>
        /// <param name="buf">音频数据</param>
        /// <param name="len">音频数据长度</param>
        /// <returns>成功返回等于len</returns>
        int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /// <summary>
        /// 删除一个推流
        /// </summary>
        /// <param name="StreamId">推流ID</param>
        void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /// <summary>
        /// 分析本地MP3文件信息
        /// </summary>
        /// <param name="FilePath">本地MP3文件目录</param>
        /// <param name="pMp3Fileinfo">输出文件信息</param>
        /// <returns>成功返回0</returns>
        int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
    }
    internal class IPGBPUSHSdkDller : IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIPGBPUSHSdkProxy Instance { get; } = new IPGBPUSHSdkDller();
        private IPGBPUSHSdkDller() { }
        public const String DllFileName = "IPGBPushStream.dll";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.GetFullPath(DllFileName);
        /**
         * 设置推流状态回调函数
         * @param  pFunc               (in)   回调函数地址
         * @param  puser               (in)   用户类指针
         * @return  
         **/
        [DllImport(DllFileName)]
        public static extern void IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser);
        /**
         * SDK初始化
         * @return ->返回0成功
         **/
        [DllImport(DllFileName)]
        public static extern int IPGBPUSHSTREAM_Init();
        /**
         * SDK退出清理
         * @return 
         **/
        [DllImport(DllFileName)]
        public static extern void IPGBPUSHSTREAM_Cleanup();
        /**
         * 获取得到系统的声卡信息
         * @param  SoundInfo           (out)   输出系统声卡混音接口
         * @return  
         **/
        [DllImport(DllFileName)]
        public static extern void IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo);
        /**
         * 设置系统声卡混音接口音量
         * @param  CapMixName              (in)    混音接口名
         * @param  MVal                    (in)    音量值 0-100
         * @return   
         **/
        [DllImport(DllFileName)]
        public static extern void IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal);
        /**
         * 创建实时声卡采集推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(DllFileName)]
        public static extern int IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo);
        /**
         * 创建本地第三方音频流推流
         * @param  pSrcinfo             (in)    推流信息
         * @return   ->成功返回推流ID（大于0）
         **/
        [DllImport(DllFileName)]
        public static extern int IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo);
        /**
         * 向本地第三方音频流推流通道输入相应格式的音频数据(注意：只对StreamType=1有效)
         * @param  StreamId        (in)    推流ID
         * @param  buf             (in)    音频数据
         * @param  len             (in)    音频数据长度
         * @return   ->成功返回等于len
         **/
        [DllImport(DllFileName)]
        public static extern int IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len);
        /**
         * 删除一个推流
         * @param  StreamId             (in)    推流ID
         * @return 
         **/
        [DllImport(DllFileName)]
        public static extern void IPGBPUSHSTREAM_DelOnePushStream(uint StreamId);
        /**
         * 分析本地MP3文件信息
         * @param  FilePath              (in)      本地MP3文件目录
         * @param  pMp3Fileinfo          (out)     输出文件信息
         * @return   ->成功返回0
         **/
        [DllImport(DllFileName)]
        public static extern int IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo);
        #region // 显示实现
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Cleanup() => IPGBPUSHSTREAM_Cleanup();
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateSoundCardPushStream(IPGBPUSH_SoundCarPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateSoundCardPushStream(pSrcinfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_CreateThirdPushStream(IPGBPUSH_ThirdPushStream pSrcinfo) => IPGBPUSHSTREAM_CreateThirdPushStream(pSrcinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_DelOnePushStream(uint StreamId) => IPGBPUSHSTREAM_DelOnePushStream(StreamId);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_FillDataToThirdStream(uint StreamId, string buf, int len) => IPGBPUSHSTREAM_FillDataToThirdStream(StreamId, buf, len);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetMp3FileInfo(string FilePath, out IPGBPUSH_LCA_MP3INFO pMp3Fileinfo) => IPGBPUSHSTREAM_GetMp3FileInfo(FilePath, out pMp3Fileinfo);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_GetSysSoundCardINFO(out IPGBPUSH_SOUNDCARDINFO SoundInfo) => IPGBPUSHSTREAM_GetSysSoundCardINFO(out SoundInfo);
        int IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_Init() => IPGBPUSHSTREAM_Init();
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetCallBackPushStatus(SDKfPushStatus pFunc, long puser) => IPGBPUSHSTREAM_SetCallBackPushStatus(pFunc, puser);
        void IIPGBPUSHSdkProxy.IPGBPUSHSTREAM_SetSysSoundCardVol(string CapMixName, uint MVal) => IPGBPUSHSTREAM_SetSysSoundCardVol(CapMixName, MVal);
        #endregion
    }
    internal class IPGBPUSHSdkLoader : IIPGBPUSHSdkProxy
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllPath = @"plugins\kangmeiipgbsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(Path.GetFullPath(DllPath), IPGBPUSHSdkDller.DllFileName);
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
            hModule = LoadLibraryEx(DllFullName, IntPtr.Zero, LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);

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
        #region // 动态内容
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();
        /// <summary>
        /// API LoadLibraryEx
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="hReservedNull"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryEx", SetLastError = true)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr LoadLibrary(string lpFileName, int h, int flags);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lProcName);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool FreeLibrary(IntPtr hModule);
        IntPtr hModule;
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            FreeLibrary(hModule);
        }
        public Delegate GetMethod(string procName, Type type)
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(func, type);
        }
        public T GetDelegate<T>(string procName) where T : Delegate
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (T)Marshal.GetDelegateForFunctionPointer(func, typeof(T));
        }
        /// <summary>
        /// LoadLibraryFlags
        /// </summary>
        public enum LoadLibraryFlags : uint
        {
            /// <summary>
            /// DONT_RESOLVE_DLL_REFERENCES
            /// </summary>
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

            /// <summary>
            /// LOAD_IGNORE_CODE_AUTHZ_LEVEL
            /// </summary>
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

            /// <summary>
            /// LOAD_LIBRARY_AS_IMAGE_RESOURCE
            /// </summary>
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_APPLICATION_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DEFAULT_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_SYSTEM32
            /// </summary>
            LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_USER_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

            /// <summary>
            /// LOAD_WITH_ALTERED_SEARCH_PATH
            /// </summary>
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }
        #endregion
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
