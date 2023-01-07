using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //从通道参数配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SLAVE_CHANNEL_CFG
    {
        public uint dwSize;   //结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SLAVE_CHANNEL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SLAVE_CHANNEL_PARAM[] struChanParam;//从通道参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
