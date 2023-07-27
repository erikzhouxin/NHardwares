using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    internal class HikPlayCtrlSdkDllerX64 : IHikPlayCtrlSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IHikPlayCtrlSdkProxy Instance { get; } = new HikPlayCtrlSdkDllerX64();
        private HikPlayCtrlSdkDllerX64() { }

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_OpenFile(int nPort, string sFileName);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_CloseFile(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_InitDDraw(IntPtr IntPtr);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_InputData(int nPort, byte[] pBuf, uint nSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_Stop(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetStreamOpenMode(int nPort, int nMode);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_CloseStream(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_ResetSourceBuffer(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDisplayBuf(int nPort, int nNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetPicQuality(int nPort, bool bHighQuality);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern int PlayM4_GetCaps();

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDeflash(int nPort, bool bDeflash);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_GetPort(ref int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_Fast(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_Slow(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_Pause(int nPort, bool nPause);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern uint PlayM4_GetCurrentFrameNum(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_OneByOne(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_ThrowBFrameNum(int nPort, int nNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_PlaySound(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_StopSound();

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern int PlayM4_GetLastError(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_FreePort(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetPlayPos(int nPort, float fRelativePos);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern float PlayM4_GetPlayPos(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_RefreshPlay(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern int PlayM4_GetSourceBufferRemain(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern int PlayM4_GetPlayedTimeEx(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetPlayedTimeEx(int nPort, int nTime);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDecCBStream(int nPort, int nStream);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDecodeFrameType(int nPort, int nFrameType);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern int PlayM4_GetSpecialData(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_SetDisplayType(int nPort, int nType);

        [DllImport(HikPlayCtrlSdk.DllFileNameX64)]
        public static extern bool PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
        #region // 显示实现方法
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseFile(int nPort) => PlayM4_CloseFile(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseStream(int nPort) => PlayM4_CloseStream(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName) => PlayM4_ConvertToJpegFile(pBuf, nSize, nWidth, nHeight, nType, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_Fast(int nPort) => PlayM4_Fast(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_FreePort(int nPort) => PlayM4_FreePort(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length) => PlayM4_GetBMP(playHandle, data, dataLength, ref length);
        int IHikPlayCtrlSdkProxy.PlayM4_GetCaps() => PlayM4_GetCaps();
        uint IHikPlayCtrlSdkProxy.PlayM4_GetCurrentFrameNum(int nPort) => PlayM4_GetCurrentFrameNum(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize) => PlayM4_GetJPEG(nPort, pJpeg, nBufSize, ref pJpegSize);
        int IHikPlayCtrlSdkProxy.PlayM4_GetLastError(int nPort) => PlayM4_GetLastError(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetPlayedTimeEx(int nPort) => PlayM4_GetPlayedTimeEx(nPort);
        float IHikPlayCtrlSdkProxy.PlayM4_GetPlayPos(int nPort) => PlayM4_GetPlayPos(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetPort(ref int nPort) => PlayM4_GetPort(ref nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSourceBufferRemain(int nPort) => PlayM4_GetSourceBufferRemain(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSpecialData(int nPort) => PlayM4_GetSpecialData(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime) => PlayM4_GetSystemTime(nPort, ref pstSystemTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved) => PlayM4_GetTimerType(nPort, out pTimerType, out pReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_InitDDraw(IntPtr IntPtr) => PlayM4_InitDDraw(IntPtr);
        bool IHikPlayCtrlSdkProxy.PlayM4_InputData(int nPort, byte[] pBuf, uint nSize) => PlayM4_InputData(nPort, pBuf, nSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_OneByOne(int nPort) => PlayM4_OneByOne(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenFile(int nPort, string sFileName) => PlayM4_OpenFile(nPort, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize) => PlayM4_OpenStream(nPort, pFileHeadBuf, nSize, nBufPoolSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_Pause(int nPort, bool nPause) => PlayM4_Pause(nPort, nPause);
        bool IHikPlayCtrlSdkProxy.PlayM4_Play(int nPort, IntPtr hWnd) => PlayM4_Play(nPort, hWnd);
        bool IHikPlayCtrlSdkProxy.PlayM4_PlaySound(int nPort) => PlayM4_PlaySound(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RefreshPlay(int nPort) => PlayM4_RefreshPlay(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ResetSourceBuffer(int nPort) => PlayM4_ResetSourceBuffer(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser) => PlayM4_RigisterDrawFun(nPort, DrawFun, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum) => PlayM4_SetCurrentFrameNum(nPort, nFrameNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback) => PlayM4_SetDecCallBack(nPort, DataCallback);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser) => PlayM4_SetDecCallBackExMend(nPort, DecCBFun, pDest, nDestSize, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCBStream(int nPort, int nStream) => PlayM4_SetDecCBStream(nPort, nStream);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecodeFrameType(int nPort, int nFrameType) => PlayM4_SetDecodeFrameType(nPort, nFrameType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDeflash(int nPort, bool bDeflash) => PlayM4_SetDeflash(nPort, bDeflash);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayBuf(int nPort, int nNum) => PlayM4_SetDisplayBuf(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun) => PlayM4_SetDisplayCallBack(nPort, DisplayCBFun);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayType(int nPort, int nType) => PlayM4_SetDisplayType(nPort, nType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser) => PlayM4_SetFileEndCallback(nPort, feCallback, pUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPicQuality(int nPort, bool bHighQuality) => PlayM4_SetPicQuality(nPort, bHighQuality);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayedTimeEx(int nPort, int nTime) => PlayM4_SetPlayedTimeEx(nPort, nTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayPos(int nPort, float fRelativePos) => PlayM4_SetPlayPos(nPort, fRelativePos);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetStreamOpenMode(int nPort, int nMode) => PlayM4_SetStreamOpenMode(nPort, nMode);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved) => PlayM4_SetTimerType(nPort, nTimerType, nReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_Slow(int nPort) => PlayM4_Slow(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_Stop(int nPort) => PlayM4_Stop(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_StopSound() => PlayM4_StopSound();
        bool IHikPlayCtrlSdkProxy.PlayM4_ThrowBFrameNum(int nPort, int nNum) => PlayM4_ThrowBFrameNum(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag) => PlayM4_VIE_GetModuConfig(lPort, ref pdwModuFlag);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => PlayM4_VIE_GetParaConfig(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable) => PlayM4_VIE_SetModuConfig(lPort, nModuFlag, bEnable);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => PlayM4_VIE_SetParaConfig(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect) => PlayM4_VIE_SetRegion(lPort, lRegNum, ref pRect);
        #endregion 显示实现方法
    }
    internal class HikPlayCtrlSdkDllerX86 : IHikPlayCtrlSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IHikPlayCtrlSdkProxy Instance { get; } = new HikPlayCtrlSdkDllerX86();
        private HikPlayCtrlSdkDllerX86() { }

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_OpenFile(int nPort, string sFileName);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_CloseFile(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_InitDDraw(IntPtr IntPtr);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_InputData(int nPort, byte[] pBuf, uint nSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_Stop(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetStreamOpenMode(int nPort, int nMode);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_CloseStream(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_ResetSourceBuffer(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDisplayBuf(int nPort, int nNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetPicQuality(int nPort, bool bHighQuality);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern int PlayM4_GetCaps();

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDeflash(int nPort, bool bDeflash);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_GetPort(ref int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_Fast(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_Slow(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_Pause(int nPort, bool nPause);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern uint PlayM4_GetCurrentFrameNum(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_OneByOne(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_ThrowBFrameNum(int nPort, int nNum);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_PlaySound(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_StopSound();

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern int PlayM4_GetLastError(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_FreePort(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetPlayPos(int nPort, float fRelativePos);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern float PlayM4_GetPlayPos(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_RefreshPlay(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern int PlayM4_GetSourceBufferRemain(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern int PlayM4_GetPlayedTimeEx(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetPlayedTimeEx(int nPort, int nTime);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDecCBStream(int nPort, int nStream);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDecodeFrameType(int nPort, int nFrameType);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern int PlayM4_GetSpecialData(int nPort);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_SetDisplayType(int nPort, int nType);

        [DllImport(HikPlayCtrlSdk.DllFileNameX86)]
        public static extern bool PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
        #region // 显示实现方法
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseFile(int nPort) => PlayM4_CloseFile(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseStream(int nPort) => PlayM4_CloseStream(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName) => PlayM4_ConvertToJpegFile(pBuf, nSize, nWidth, nHeight, nType, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_Fast(int nPort) => PlayM4_Fast(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_FreePort(int nPort) => PlayM4_FreePort(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length) => PlayM4_GetBMP(playHandle, data, dataLength, ref length);
        int IHikPlayCtrlSdkProxy.PlayM4_GetCaps() => PlayM4_GetCaps();
        uint IHikPlayCtrlSdkProxy.PlayM4_GetCurrentFrameNum(int nPort) => PlayM4_GetCurrentFrameNum(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize) => PlayM4_GetJPEG(nPort, pJpeg, nBufSize, ref pJpegSize);
        int IHikPlayCtrlSdkProxy.PlayM4_GetLastError(int nPort) => PlayM4_GetLastError(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetPlayedTimeEx(int nPort) => PlayM4_GetPlayedTimeEx(nPort);
        float IHikPlayCtrlSdkProxy.PlayM4_GetPlayPos(int nPort) => PlayM4_GetPlayPos(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetPort(ref int nPort) => PlayM4_GetPort(ref nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSourceBufferRemain(int nPort) => PlayM4_GetSourceBufferRemain(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSpecialData(int nPort) => PlayM4_GetSpecialData(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime) => PlayM4_GetSystemTime(nPort, ref pstSystemTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved) => PlayM4_GetTimerType(nPort, out pTimerType, out pReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_InitDDraw(IntPtr IntPtr) => PlayM4_InitDDraw(IntPtr);
        bool IHikPlayCtrlSdkProxy.PlayM4_InputData(int nPort, byte[] pBuf, uint nSize) => PlayM4_InputData(nPort, pBuf, nSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_OneByOne(int nPort) => PlayM4_OneByOne(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenFile(int nPort, string sFileName) => PlayM4_OpenFile(nPort, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize) => PlayM4_OpenStream(nPort, pFileHeadBuf, nSize, nBufPoolSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_Pause(int nPort, bool nPause) => PlayM4_Pause(nPort, nPause);
        bool IHikPlayCtrlSdkProxy.PlayM4_Play(int nPort, IntPtr hWnd) => PlayM4_Play(nPort, hWnd);
        bool IHikPlayCtrlSdkProxy.PlayM4_PlaySound(int nPort) => PlayM4_PlaySound(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RefreshPlay(int nPort) => PlayM4_RefreshPlay(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ResetSourceBuffer(int nPort) => PlayM4_ResetSourceBuffer(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser) => PlayM4_RigisterDrawFun(nPort, DrawFun, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum) => PlayM4_SetCurrentFrameNum(nPort, nFrameNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback) => PlayM4_SetDecCallBack(nPort, DataCallback);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser) => PlayM4_SetDecCallBackExMend(nPort, DecCBFun, pDest, nDestSize, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCBStream(int nPort, int nStream) => PlayM4_SetDecCBStream(nPort, nStream);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecodeFrameType(int nPort, int nFrameType) => PlayM4_SetDecodeFrameType(nPort, nFrameType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDeflash(int nPort, bool bDeflash) => PlayM4_SetDeflash(nPort, bDeflash);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayBuf(int nPort, int nNum) => PlayM4_SetDisplayBuf(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun) => PlayM4_SetDisplayCallBack(nPort, DisplayCBFun);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayType(int nPort, int nType) => PlayM4_SetDisplayType(nPort, nType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser) => PlayM4_SetFileEndCallback(nPort, feCallback, pUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPicQuality(int nPort, bool bHighQuality) => PlayM4_SetPicQuality(nPort, bHighQuality);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayedTimeEx(int nPort, int nTime) => PlayM4_SetPlayedTimeEx(nPort, nTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayPos(int nPort, float fRelativePos) => PlayM4_SetPlayPos(nPort, fRelativePos);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetStreamOpenMode(int nPort, int nMode) => PlayM4_SetStreamOpenMode(nPort, nMode);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved) => PlayM4_SetTimerType(nPort, nTimerType, nReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_Slow(int nPort) => PlayM4_Slow(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_Stop(int nPort) => PlayM4_Stop(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_StopSound() => PlayM4_StopSound();
        bool IHikPlayCtrlSdkProxy.PlayM4_ThrowBFrameNum(int nPort, int nNum) => PlayM4_ThrowBFrameNum(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag) => PlayM4_VIE_GetModuConfig(lPort, ref pdwModuFlag);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => PlayM4_VIE_GetParaConfig(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable) => PlayM4_VIE_SetModuConfig(lPort, nModuFlag, bEnable);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => PlayM4_VIE_SetParaConfig(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect) => PlayM4_VIE_SetRegion(lPort, lRegNum, ref pRect);
        #endregion 显示实现方法
    }
}
