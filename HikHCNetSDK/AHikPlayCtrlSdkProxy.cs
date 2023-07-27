using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// 海康播放控制代理
    /// </summary>
    public interface IHikPlayCtrlSdkProxy
    {
        bool PlayM4_OpenStream(int nPort, byte[] pFileHeadBuf, uint nSize, uint nBufPoolSize);
        bool PlayM4_OpenFile(int nPort, string sFileName);
        bool PlayM4_CloseFile(int nPort);
        bool PlayM4_Play(int nPort, IntPtr hWnd);
        bool PlayM4_InitDDraw(IntPtr IntPtr);
        bool PlayM4_InputData(int nPort, byte[] pBuf, uint nSize);
        bool PlayM4_Stop(int nPort);
        bool PlayM4_SetStreamOpenMode(int nPort, int nMode);
        bool PlayM4_RigisterDrawFun(int nPort, DrawFun DrawFun, int nUser);
        bool PlayM4_SetDisplayCallBack(int nPort, DisplayCBFun DisplayCBFun);
        bool PlayM4_ConvertToJpegFile(byte[] pBuf, int nSize, int nWidth, int nHeight, int nType, string sFileName);
        bool PlayM4_CloseStream(int nPort);
        bool PlayM4_ResetSourceBuffer(int nPort);
        bool PlayM4_SetTimerType(int nPort, int nTimerType, int nReserved);
        bool PlayM4_GetTimerType(int nPort, out int pTimerType, out int pReserved);
        bool PlayM4_SetDisplayBuf(int nPort, int nNum);
        bool PlayM4_SetPicQuality(int nPort, bool bHighQuality);
        int PlayM4_GetCaps();
        bool PlayM4_SetDeflash(int nPort, bool bDeflash);
        bool PlayM4_GetPort(ref int nPort);
        bool PlayM4_Fast(int nPort);
        bool PlayM4_Slow(int nPort);
        bool PlayM4_Pause(int nPort, bool nPause);
        uint PlayM4_GetCurrentFrameNum(int nPort);
        bool PlayM4_SetCurrentFrameNum(int nPort, uint nFrameNum);
        bool PlayM4_OneByOne(int nPort);
        bool PlayM4_ThrowBFrameNum(int nPort, int nNum);
        bool PlayM4_PlaySound(int nPort);
        bool PlayM4_StopSound();
        int PlayM4_GetLastError(int nPort);
        bool PlayM4_FreePort(int nPort);
        bool PlayM4_SetPlayPos(int nPort, float fRelativePos);
        float PlayM4_GetPlayPos(int nPort);
        bool PlayM4_RefreshPlay(int nPort);
        int PlayM4_GetSourceBufferRemain(int nPort);
        bool PlayM4_GetBMP(int playHandle, byte[] data, int dataLength, ref int length);
        bool PlayM4_GetJPEG(int nPort, IntPtr pJpeg, int nBufSize, ref int pJpegSize);
        bool PlayM4_SetFileEndCallback(int nPort, FileEndCallback feCallback, IntPtr pUser);
        int PlayM4_GetPlayedTimeEx(int nPort);
        bool PlayM4_SetPlayedTimeEx(int nPort, int nTime);
        bool PlayM4_SetDecCBStream(int nPort, int nStream);
        bool PlayM4_SetDecodeFrameType(int nPort, int nFrameType);
        bool PlayM4_SetDecCallBack(int nPort, DecCBFun DataCallback);
        bool PlayM4_SetDecCallBackExMend(int nPort, DecCBFun DecCBFun, IntPtr pDest, int nDestSize, int nUser);
        int PlayM4_GetSpecialData(int nPort);
        bool PlayM4_GetSystemTime(int nPort, ref PLAYM4_SYSTEM_TIME pstSystemTime);
        bool PlayM4_VIE_SetModuConfig(int lPort, PLAYM4_VIE_MODULES nModuFlag, bool bEnable);
        bool PlayM4_VIE_GetModuConfig(int lPort, ref PLAYM4_VIE_MODULES pdwModuFlag);
        bool PlayM4_VIE_GetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
        bool PlayM4_VIE_SetRegion(int lPort, int lRegNum, ref PLAYM4_RECT pRect);
        bool PlayM4_SetDisplayType(int nPort, int nType);
        bool PlayM4_VIE_SetParaConfig(int lPort, ref PLAYM4_VIE_PARACONFIG pParaConfig);
    }
}
