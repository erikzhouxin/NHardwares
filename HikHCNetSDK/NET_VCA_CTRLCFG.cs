using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能控制信息结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_CTRLCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VCA_CHAN, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_CTRLINFO[] struCtrlInfo;//控制信息,数组0对应设备的起始通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
