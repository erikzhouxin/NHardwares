using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //移动侦测
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_MOTION_BYBIT
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byMotDetChanNo;//移动侦测通道，byMotDetChanNo[0]若置1则表示查找由通道1发生移动侦测触发的事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN - HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byMotDetChanNo = new byte[HikHCNetSdk.MAX_CHANNUM_V30];
            byRes = new byte[HikHCNetSdk.SEARCH_EVENT_INFO_LEN - HikHCNetSdk.MAX_CHANNUM_V30];
        }
    }


}
