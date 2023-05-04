using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    public delegate void DisplayCBFun(int nPort, IntPtr pBuf, int nSize, int nWidth, int nHeight, int nStamp, int nType, int nReceaved);

    public delegate void DrawFun(int nPort, IntPtr hDc, int nUser);

    public delegate void FileEndCallback(int nPort, IntPtr pUser);

    public delegate void DecCBFun(int nPort, IntPtr pBuf, int nSize, ref PLAYM4_FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);
}
