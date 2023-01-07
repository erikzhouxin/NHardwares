using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //从通道参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SLAVE_CHANNEL_PARAM
    {
        public byte byChanType;   //从通道类型，1-本机通道，2-远程通道 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    //保留
        public NET_DVR_SLAVE_CHANNEL_UNION uSlaveChannel; //从通道联合体，取值依赖于byChanType
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   //保留
    }
}
