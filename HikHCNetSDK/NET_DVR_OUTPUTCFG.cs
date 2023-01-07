using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OUTPUTCFG
    {
        public uint dwSize;
        public byte byScreenLayX;                       //大屏布局-横坐标
        public byte byScreenLayY;                       //大屏布局-纵坐标
        public ushort wOutputChanNum;                   //输出通道个数，0表示设备支持的最大输出通道个数，最大个数从能力集获取，其他值表示实际输出通道个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_OUTPUTPARAM struOutputParam; /*输出通道视频参数配置*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] sWallName;                    //电视墙名称
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
