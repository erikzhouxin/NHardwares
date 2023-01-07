using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道图象结构
    //移动侦测(子结构)(按组方式扩展)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_RECORDCHAN
    {
        public uint dwMaxRecordChanNum;   //设备支持的最大关联录像通道数-只读
        public uint dwCurRecordChanNum;   //当前实际已配置的关联录像通道数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint dwRelRecordChan;     /* 实际触发录像通道，按值表示,采用紧凑型排列，从下标0 - MAX_CHANNUM_V30-1有效，如果中间遇到0xffffffff,则后续无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;          //保留
    }
}
