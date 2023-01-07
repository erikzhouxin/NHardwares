using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 流信息 - 72字节长
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STREAM_INFO
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byID;      //ID数据
        public uint dwChannel;                //关联设备通道，等于0xffffffff时，表示不关联
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                //保留
        public void Init()
        {
            byID = new byte[HikHCNetSdk.STREAM_ID_LEN];
            byRes = new byte[32];
        }
    }


}
