using System;
using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct PACKET_INFO
    {
        public int nPacketType;     // packet type
                                    // 0:  file head
                                    // 1:  video I frame
                                    // 2:  video B frame
                                    // 3:  video P frame
                                    // 10: audio frame
                                    // 11: private frame only for PS


        //      [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public IntPtr pPacketBuffer;
        public uint dwPacketSize;
        public int nYear;
        public int nMonth;
        public int nDay;
        public int nHour;
        public int nMinute;
        public int nSecond;
        public uint dwTimeStamp;
    }
}
