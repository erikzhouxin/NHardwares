using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_REL_CAPTURE_CHAN_V40
    {
        public uint dwMaxRelCaptureChanNum;  //最大可触发的关联通道数-只读属性
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwChanNo; //触发的关联抓图通道号，按值表示，采用紧凑型排列,0xffffffff表示后续无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
