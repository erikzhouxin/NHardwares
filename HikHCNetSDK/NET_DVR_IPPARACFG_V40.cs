using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* V40扩展IP接入配置结构 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPPARACFG_V40
    {
        public uint dwSize;/* 结构大小 */
        public uint dwGroupNum;
        public uint dwAChanNum;
        public uint dwDChanNum;
        public uint dwStartDChan;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAnalogChanEnable; /* 模拟通道是否启用，从低到高表示1-32通道，0表示无效 1有效 */

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_DEVICE_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPDEVINFO_V31[] struIPDevInfo; /* IP设备 */

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_STREAM_MODE[] struStreamMode;/* IP通道 */

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; /* 模拟通道是否启用，从低到高表示1-32通道，0表示无效 1有效 */
    }

}
