using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OVERLAY_CHANNEL
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byChannel;/*叠加的通道*/
        public uint dwDelayTime;/*叠加延时时间*/
        public byte byEnableDelayTime;/*是否启用叠加延时，在无退卡命令时启用*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
