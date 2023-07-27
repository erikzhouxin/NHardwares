using System.Data.NHInterfaces;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    internal class HikPlayCtrlSdkLoader : ASdkDynamicLoader, IHikPlayCtrlSdkProxy
    {
        #region // 委托定义        
        private DCreater.PlayM4_OpenStream _PlayM4_OpenStream;
        private DCreater.PlayM4_OpenFile _PlayM4_OpenFile;
        private DCreater.PlayM4_CloseFile _PlayM4_CloseFile;
        private DCreater.PlayM4_Play _PlayM4_Play;
        private DCreater.PlayM4_InitDDraw _PlayM4_InitDDraw;
        private DCreater.PlayM4_InputData _PlayM4_InputData;
        private DCreater.PlayM4_Stop _PlayM4_Stop;
        private DCreater.PlayM4_SetStreamOpenMode _PlayM4_SetStreamOpenMode;
        private DCreater.PlayM4_RigisterDrawFun _PlayM4_RigisterDrawFun;
        private DCreater.PlayM4_SetDisplayCallBack _PlayM4_SetDisplayCallBack;
        private DCreater.PlayM4_ConvertToJpegFile _PlayM4_ConvertToJpegFile;
        private DCreater.PlayM4_CloseStream _PlayM4_CloseStream;
        private DCreater.PlayM4_ResetSourceBuffer _PlayM4_ResetSourceBuffer;
        private DCreater.PlayM4_SetTimerType _PlayM4_SetTimerType;
        private DCreater.PlayM4_GetTimerType _PlayM4_GetTimerType;
        private DCreater.PlayM4_SetDisplayBuf _PlayM4_SetDisplayBuf;
        private DCreater.PlayM4_SetPicQuality _PlayM4_SetPicQuality;
        private DCreater.PlayM4_GetCaps _PlayM4_GetCaps;
        private DCreater.PlayM4_SetDeflash _PlayM4_SetDeflash;
        private DCreater.PlayM4_GetPort _PlayM4_GetPort;
        private DCreater.PlayM4_Fast _PlayM4_Fast;
        private DCreater.PlayM4_Slow _PlayM4_Slow;
        private DCreater.PlayM4_Pause _PlayM4_Pause;
        private DCreater.PlayM4_GetCurrentFrameNum _PlayM4_GetCurrentFrameNum;
        private DCreater.PlayM4_SetCurrentFrameNum _PlayM4_SetCurrentFrameNum;
        private DCreater.PlayM4_OneByOne _PlayM4_OneByOne;
        private DCreater.PlayM4_ThrowBFrameNum _PlayM4_ThrowBFrameNum;
        private DCreater.PlayM4_PlaySound _PlayM4_PlaySound;
        private DCreater.PlayM4_StopSound _PlayM4_StopSound;
        private DCreater.PlayM4_GetLastError _PlayM4_GetLastError;
        private DCreater.PlayM4_FreePort _PlayM4_FreePort;
        private DCreater.PlayM4_SetPlayPos _PlayM4_SetPlayPos;
        private DCreater.PlayM4_GetPlayPos _PlayM4_GetPlayPos;
        private DCreater.PlayM4_RefreshPlay _PlayM4_RefreshPlay;
        private DCreater.PlayM4_GetSourceBufferRemain _PlayM4_GetSourceBufferRemain;
        private DCreater.PlayM4_GetBMP _PlayM4_GetBMP;
        private DCreater.PlayM4_GetJPEG _PlayM4_GetJPEG;
        private DCreater.PlayM4_SetFileEndCallback _PlayM4_SetFileEndCallback;
        private DCreater.PlayM4_GetPlayedTimeEx _PlayM4_GetPlayedTimeEx;
        private DCreater.PlayM4_SetPlayedTimeEx _PlayM4_SetPlayedTimeEx;
        private DCreater.PlayM4_SetDecCBStream _PlayM4_SetDecCBStream;
        private DCreater.PlayM4_SetDecodeFrameType _PlayM4_SetDecodeFrameType;
        private DCreater.PlayM4_SetDecCallBack _PlayM4_SetDecCallBack;
        private DCreater.PlayM4_SetDecCallBackExMend _PlayM4_SetDecCallBackExMend;
        private DCreater.PlayM4_GetSpecialData _PlayM4_GetSpecialData;
        private DCreater.PlayM4_GetSystemTime _PlayM4_GetSystemTime;
        private DCreater.PlayM4_VIE_SetModuConfig _PlayM4_VIE_SetModuConfig;
        private DCreater.PlayM4_VIE_GetModuConfig _PlayM4_VIE_GetModuConfig;
        private DCreater.PlayM4_VIE_GetParaConfig _PlayM4_VIE_GetParaConfig;
        private DCreater.PlayM4_VIE_SetRegion _PlayM4_VIE_SetRegion;
        private DCreater.PlayM4_SetDisplayType _PlayM4_SetDisplayType;
        private DCreater.PlayM4_VIE_SetParaConfig _PlayM4_VIE_SetParaConfig;
        #endregion 委托定义
        public HikPlayCtrlSdkLoader()
        {
            _PlayM4_OpenStream = GetDelegate<DCreater.PlayM4_OpenStream>(nameof(DCreater.PlayM4_OpenStream));
            _PlayM4_OpenFile = GetDelegate<DCreater.PlayM4_OpenFile>(nameof(DCreater.PlayM4_OpenFile));
            _PlayM4_CloseFile = GetDelegate<DCreater.PlayM4_CloseFile>(nameof(DCreater.PlayM4_CloseFile));
            _PlayM4_Play = GetDelegate<DCreater.PlayM4_Play>(nameof(DCreater.PlayM4_Play));
            _PlayM4_InitDDraw = GetDelegate<DCreater.PlayM4_InitDDraw>(nameof(DCreater.PlayM4_InitDDraw));
            _PlayM4_InputData = GetDelegate<DCreater.PlayM4_InputData>(nameof(DCreater.PlayM4_InputData));
            _PlayM4_Stop = GetDelegate<DCreater.PlayM4_Stop>(nameof(DCreater.PlayM4_Stop));
            _PlayM4_SetStreamOpenMode = GetDelegate<DCreater.PlayM4_SetStreamOpenMode>(nameof(DCreater.PlayM4_SetStreamOpenMode));
            _PlayM4_RigisterDrawFun = GetDelegate<DCreater.PlayM4_RigisterDrawFun>(nameof(DCreater.PlayM4_RigisterDrawFun));
            _PlayM4_SetDisplayCallBack = GetDelegate<DCreater.PlayM4_SetDisplayCallBack>(nameof(DCreater.PlayM4_SetDisplayCallBack));
            _PlayM4_ConvertToJpegFile = GetDelegate<DCreater.PlayM4_ConvertToJpegFile>(nameof(DCreater.PlayM4_ConvertToJpegFile));
            _PlayM4_CloseStream = GetDelegate<DCreater.PlayM4_CloseStream>(nameof(DCreater.PlayM4_CloseStream));
            _PlayM4_ResetSourceBuffer = GetDelegate<DCreater.PlayM4_ResetSourceBuffer>(nameof(DCreater.PlayM4_ResetSourceBuffer));
            _PlayM4_SetTimerType = GetDelegate<DCreater.PlayM4_SetTimerType>(nameof(DCreater.PlayM4_SetTimerType));
            _PlayM4_GetTimerType = GetDelegate<DCreater.PlayM4_GetTimerType>(nameof(DCreater.PlayM4_GetTimerType));
            _PlayM4_SetDisplayBuf = GetDelegate<DCreater.PlayM4_SetDisplayBuf>(nameof(DCreater.PlayM4_SetDisplayBuf));
            _PlayM4_SetPicQuality = GetDelegate<DCreater.PlayM4_SetPicQuality>(nameof(DCreater.PlayM4_SetPicQuality));
            _PlayM4_GetCaps = GetDelegate<DCreater.PlayM4_GetCaps>(nameof(DCreater.PlayM4_GetCaps));
            _PlayM4_SetDeflash = GetDelegate<DCreater.PlayM4_SetDeflash>(nameof(DCreater.PlayM4_SetDeflash));
            _PlayM4_GetPort = GetDelegate<DCreater.PlayM4_GetPort>(nameof(DCreater.PlayM4_GetPort));
            _PlayM4_Fast = GetDelegate<DCreater.PlayM4_Fast>(nameof(DCreater.PlayM4_Fast));
            _PlayM4_Slow = GetDelegate<DCreater.PlayM4_Slow>(nameof(DCreater.PlayM4_Slow));
            _PlayM4_Pause = GetDelegate<DCreater.PlayM4_Pause>(nameof(DCreater.PlayM4_Pause));
            _PlayM4_GetCurrentFrameNum = GetDelegate<DCreater.PlayM4_GetCurrentFrameNum>(nameof(DCreater.PlayM4_GetCurrentFrameNum));
            _PlayM4_SetCurrentFrameNum = GetDelegate<DCreater.PlayM4_SetCurrentFrameNum>(nameof(DCreater.PlayM4_SetCurrentFrameNum));
            _PlayM4_OneByOne = GetDelegate<DCreater.PlayM4_OneByOne>(nameof(DCreater.PlayM4_OneByOne));
            _PlayM4_ThrowBFrameNum = GetDelegate<DCreater.PlayM4_ThrowBFrameNum>(nameof(DCreater.PlayM4_ThrowBFrameNum));
            _PlayM4_PlaySound = GetDelegate<DCreater.PlayM4_PlaySound>(nameof(DCreater.PlayM4_PlaySound));
            _PlayM4_StopSound = GetDelegate<DCreater.PlayM4_StopSound>(nameof(DCreater.PlayM4_StopSound));
            _PlayM4_GetLastError = GetDelegate<DCreater.PlayM4_GetLastError>(nameof(DCreater.PlayM4_GetLastError));
            _PlayM4_FreePort = GetDelegate<DCreater.PlayM4_FreePort>(nameof(DCreater.PlayM4_FreePort));
            _PlayM4_SetPlayPos = GetDelegate<DCreater.PlayM4_SetPlayPos>(nameof(DCreater.PlayM4_SetPlayPos));
            _PlayM4_GetPlayPos = GetDelegate<DCreater.PlayM4_GetPlayPos>(nameof(DCreater.PlayM4_GetPlayPos));
            _PlayM4_RefreshPlay = GetDelegate<DCreater.PlayM4_RefreshPlay>(nameof(DCreater.PlayM4_RefreshPlay));
            _PlayM4_GetSourceBufferRemain = GetDelegate<DCreater.PlayM4_GetSourceBufferRemain>(nameof(DCreater.PlayM4_GetSourceBufferRemain));
            _PlayM4_GetBMP = GetDelegate<DCreater.PlayM4_GetBMP>(nameof(DCreater.PlayM4_GetBMP));
            _PlayM4_GetJPEG = GetDelegate<DCreater.PlayM4_GetJPEG>(nameof(DCreater.PlayM4_GetJPEG));
            _PlayM4_SetFileEndCallback = GetDelegate<DCreater.PlayM4_SetFileEndCallback>(nameof(DCreater.PlayM4_SetFileEndCallback));
            _PlayM4_GetPlayedTimeEx = GetDelegate<DCreater.PlayM4_GetPlayedTimeEx>(nameof(DCreater.PlayM4_GetPlayedTimeEx));
            _PlayM4_SetPlayedTimeEx = GetDelegate<DCreater.PlayM4_SetPlayedTimeEx>(nameof(DCreater.PlayM4_SetPlayedTimeEx));
            _PlayM4_SetDecCBStream = GetDelegate<DCreater.PlayM4_SetDecCBStream>(nameof(DCreater.PlayM4_SetDecCBStream));
            _PlayM4_SetDecodeFrameType = GetDelegate<DCreater.PlayM4_SetDecodeFrameType>(nameof(DCreater.PlayM4_SetDecodeFrameType));
            _PlayM4_SetDecCallBack = GetDelegate<DCreater.PlayM4_SetDecCallBack>(nameof(DCreater.PlayM4_SetDecCallBack));
            _PlayM4_SetDecCallBackExMend = GetDelegate<DCreater.PlayM4_SetDecCallBackExMend>(nameof(DCreater.PlayM4_SetDecCallBackExMend));
            _PlayM4_GetSpecialData = GetDelegate<DCreater.PlayM4_GetSpecialData>(nameof(DCreater.PlayM4_GetSpecialData));
            _PlayM4_GetSystemTime = GetDelegate<DCreater.PlayM4_GetSystemTime>(nameof(DCreater.PlayM4_GetSystemTime));
            _PlayM4_VIE_SetModuConfig = GetDelegate<DCreater.PlayM4_VIE_SetModuConfig>(nameof(DCreater.PlayM4_VIE_SetModuConfig));
            _PlayM4_VIE_GetModuConfig = GetDelegate<DCreater.PlayM4_VIE_GetModuConfig>(nameof(DCreater.PlayM4_VIE_GetModuConfig));
            _PlayM4_VIE_GetParaConfig = GetDelegate<DCreater.PlayM4_VIE_GetParaConfig>(nameof(DCreater.PlayM4_VIE_GetParaConfig));
            _PlayM4_VIE_SetRegion = GetDelegate<DCreater.PlayM4_VIE_SetRegion>(nameof(DCreater.PlayM4_VIE_SetRegion));
            _PlayM4_SetDisplayType = GetDelegate<DCreater.PlayM4_SetDisplayType>(nameof(DCreater.PlayM4_SetDisplayType));
            _PlayM4_VIE_SetParaConfig = GetDelegate<DCreater.PlayM4_VIE_SetParaConfig>(nameof(DCreater.PlayM4_VIE_SetParaConfig));
        }
        public override string GetFileFullName()
        {
            return Path.GetFullPath(Environment.Is64BitProcess ? HikHCNetSdk.DllFileNameX64 : HikHCNetSdk.DllFileNameX86);
        }
        #region // 显示实现方法
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseFile(int nPort) => _PlayM4_CloseFile.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_CloseStream(int nPort) => _PlayM4_CloseStream.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName) => _PlayM4_ConvertToJpegFile.Invoke(pBuf, nSize, nWidth, nHeight, nType, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_Fast(int nPort) => _PlayM4_Fast.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_FreePort(int nPort) => _PlayM4_FreePort.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length) => _PlayM4_GetBMP.Invoke(playHandle, data, dataLength, ref length);
        int IHikPlayCtrlSdkProxy.PlayM4_GetCaps() => _PlayM4_GetCaps.Invoke();
        uint IHikPlayCtrlSdkProxy.PlayM4_GetCurrentFrameNum(int nPort) => _PlayM4_GetCurrentFrameNum.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize) => _PlayM4_GetJPEG.Invoke(nPort, pJpeg, nBufSize, ref pJpegSize);
        int IHikPlayCtrlSdkProxy.PlayM4_GetLastError(int nPort) => _PlayM4_GetLastError.Invoke(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetPlayedTimeEx(int nPort) => _PlayM4_GetPlayedTimeEx.Invoke(nPort);
        float IHikPlayCtrlSdkProxy.PlayM4_GetPlayPos(int nPort) => _PlayM4_GetPlayPos.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetPort(ref int nPort) => _PlayM4_GetPort.Invoke(ref nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSourceBufferRemain(int nPort) => _PlayM4_GetSourceBufferRemain.Invoke(nPort);
        int IHikPlayCtrlSdkProxy.PlayM4_GetSpecialData(int nPort) => _PlayM4_GetSpecialData.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime) => _PlayM4_GetSystemTime.Invoke(nPort, ref pstSystemTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved) => _PlayM4_GetTimerType.Invoke(nPort, out pTimerType, out pReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_InitDDraw(IntPtr IntPtr) => _PlayM4_InitDDraw.Invoke(IntPtr);
        bool IHikPlayCtrlSdkProxy.PlayM4_InputData(int nPort, byte[] pBuf, uint nSize) => _PlayM4_InputData.Invoke(nPort, pBuf, nSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_OneByOne(int nPort) => _PlayM4_OneByOne.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenFile(int nPort, string sFileName) => _PlayM4_OpenFile.Invoke(nPort, sFileName);
        bool IHikPlayCtrlSdkProxy.PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize) => _PlayM4_OpenStream.Invoke(nPort, pFileHeadBuf, nSize, nBufPoolSize);
        bool IHikPlayCtrlSdkProxy.PlayM4_Pause(int nPort, bool nPause) => _PlayM4_Pause.Invoke(nPort, nPause);
        bool IHikPlayCtrlSdkProxy.PlayM4_Play(int nPort, IntPtr hWnd) => _PlayM4_Play.Invoke(nPort, hWnd);
        bool IHikPlayCtrlSdkProxy.PlayM4_PlaySound(int nPort) => _PlayM4_PlaySound.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RefreshPlay(int nPort) => _PlayM4_RefreshPlay.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_ResetSourceBuffer(int nPort) => _PlayM4_ResetSourceBuffer.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser) => _PlayM4_RigisterDrawFun.Invoke(nPort, DrawFun, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum) => _PlayM4_SetCurrentFrameNum.Invoke(nPort, nFrameNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback) => _PlayM4_SetDecCallBack.Invoke(nPort, DataCallback);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser) => _PlayM4_SetDecCallBackExMend.Invoke(nPort, DecCBFun, pDest, nDestSize, nUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecCBStream(int nPort, int nStream) => _PlayM4_SetDecCBStream.Invoke(nPort, nStream);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDecodeFrameType(int nPort, int nFrameType) => _PlayM4_SetDecodeFrameType.Invoke(nPort, nFrameType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDeflash(int nPort, bool bDeflash) => _PlayM4_SetDeflash.Invoke(nPort, bDeflash);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayBuf(int nPort, int nNum) => _PlayM4_SetDisplayBuf.Invoke(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun) => _PlayM4_SetDisplayCallBack.Invoke(nPort, DisplayCBFun);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetDisplayType(int nPort, int nType) => _PlayM4_SetDisplayType.Invoke(nPort, nType);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser) => _PlayM4_SetFileEndCallback.Invoke(nPort, feCallback, pUser);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPicQuality(int nPort, bool bHighQuality) => _PlayM4_SetPicQuality.Invoke(nPort, bHighQuality);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayedTimeEx(int nPort, int nTime) => _PlayM4_SetPlayedTimeEx.Invoke(nPort, nTime);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetPlayPos(int nPort, float fRelativePos) => _PlayM4_SetPlayPos.Invoke(nPort, fRelativePos);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetStreamOpenMode(int nPort, int nMode) => _PlayM4_SetStreamOpenMode.Invoke(nPort, nMode);
        bool IHikPlayCtrlSdkProxy.PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved) => _PlayM4_SetTimerType.Invoke(nPort, nTimerType, nReserved);
        bool IHikPlayCtrlSdkProxy.PlayM4_Slow(int nPort) => _PlayM4_Slow.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_Stop(int nPort) => _PlayM4_Stop.Invoke(nPort);
        bool IHikPlayCtrlSdkProxy.PlayM4_StopSound() => _PlayM4_StopSound.Invoke();
        bool IHikPlayCtrlSdkProxy.PlayM4_ThrowBFrameNum(int nPort, int nNum) => _PlayM4_ThrowBFrameNum.Invoke(nPort, nNum);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag) => _PlayM4_VIE_GetModuConfig.Invoke(lPort, ref pdwModuFlag);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => _PlayM4_VIE_GetParaConfig.Invoke(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable) => _PlayM4_VIE_SetModuConfig.Invoke(lPort, nModuFlag, bEnable);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig) => _PlayM4_VIE_SetParaConfig.Invoke(lPort, ref pParaConfig);
        bool IHikPlayCtrlSdkProxy.PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect) => _PlayM4_VIE_SetRegion.Invoke(lPort, lRegNum, ref pRect);
        #endregion 显示实现方法
    }
}
