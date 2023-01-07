using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能侦测查找条件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_VCADETECT_BYBIT
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byChan;//触发智能侦测的通道号，按数组下标表示，byChan[0]若置1则表示查找由通道1发生移动侦测触发的事件 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
        public void Init()
        {
            byChan = new byte[256];
            byRes = new byte[44];
        }
    }


}
