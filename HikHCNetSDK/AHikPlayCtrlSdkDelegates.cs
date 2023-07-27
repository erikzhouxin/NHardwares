using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nPort"></param>
    /// <param name="pBuf"></param>
    /// <param name="nSize"></param>
    /// <param name="nWidth"></param>
    /// <param name="nHeight"></param>
    /// <param name="nStamp"></param>
    /// <param name="nType"></param>
    /// <param name="nReceaved"></param>
    public delegate void DisplayCBFun(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReceaved);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nPort"></param>
    /// <param name="hDc"></param>
    /// <param name="nUser"></param>
    public delegate void DrawFun(int nPort, IntPtr hDc, int nUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nPort"></param>
    /// <param name="pUser"></param>
    public delegate void FileEndCallback(int nPort, IntPtr pUser);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nPort"></param>
    /// <param name="pBuf"></param>
    /// <param name="nSize"></param>
    /// <param name="pFrameInfo"></param>
    /// <param name="nReserved1"></param>
    /// <param name="nReserved2"></param>
    public delegate void DecCBFun(int nPort, IntPtr pBuf, int nSize, ref PLAYM4_FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);

    internal partial class DCreater
    {
        public delegate bool PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize);
        public delegate bool PlayM4_OpenFile(int nPort, string sFileName);
        public delegate bool PlayM4_CloseFile(int nPort);
        public delegate bool PlayM4_Play(int nPort, IntPtr hWnd);
        public delegate bool PlayM4_InitDDraw(IntPtr IntPtr);
        public delegate bool PlayM4_InputData(int nPort, byte[] pBuf, uint nSize);
        public delegate bool PlayM4_Stop(int nPort);
        public delegate bool PlayM4_SetStreamOpenMode(int nPort, int nMode);
        public delegate bool PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser);
        public delegate bool PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun);
        public delegate bool PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);
        public delegate bool PlayM4_CloseStream(int nPort);
        public delegate bool PlayM4_ResetSourceBuffer(int nPort);
        public delegate bool PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved);
        public delegate bool PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved);
        public delegate bool PlayM4_SetDisplayBuf(int nPort, int nNum);
        public delegate bool PlayM4_SetPicQuality(int nPort, bool bHighQuality);
        public delegate int PlayM4_GetCaps();
        public delegate bool PlayM4_SetDeflash(int nPort, bool bDeflash);
        public delegate bool PlayM4_GetPort(ref int nPort);
        public delegate bool PlayM4_Fast(int nPort);
        public delegate bool PlayM4_Slow(int nPort);
        public delegate bool PlayM4_Pause(int nPort, bool nPause);
        public delegate uint PlayM4_GetCurrentFrameNum(int nPort);
        public delegate bool PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum);
        public delegate bool PlayM4_OneByOne(int nPort);
        public delegate bool PlayM4_ThrowBFrameNum(int nPort, int nNum);
        public delegate bool PlayM4_PlaySound(int nPort);
        public delegate bool PlayM4_StopSound();
        public delegate int PlayM4_GetLastError(int nPort);
        public delegate bool PlayM4_FreePort(int nPort);
        public delegate bool PlayM4_SetPlayPos(int nPort, float fRelativePos);
        public delegate float PlayM4_GetPlayPos(int nPort);
        public delegate bool PlayM4_RefreshPlay(int nPort);
        public delegate int PlayM4_GetSourceBufferRemain(int nPort);
        public delegate bool PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length);
        public delegate bool PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize);
        public delegate bool PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser);
        public delegate int PlayM4_GetPlayedTimeEx(int nPort);
        public delegate bool PlayM4_SetPlayedTimeEx(int nPort, int nTime);
        public delegate bool PlayM4_SetDecCBStream(int nPort, int nStream);
        public delegate bool PlayM4_SetDecodeFrameType(int nPort, int nFrameType);
        public delegate bool PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback);
        public delegate bool PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser);
        public delegate int PlayM4_GetSpecialData(int nPort);
        public delegate bool PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime);
        public delegate bool PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable);
        public delegate bool PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag);
        public delegate bool PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
        public delegate bool PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect);
        public delegate bool PlayM4_SetDisplayType(int nPort, int nType);
        public delegate bool PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
    }
}
