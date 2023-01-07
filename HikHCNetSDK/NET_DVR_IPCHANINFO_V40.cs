using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPCHANINFO_V40
    {
        public byte byEnable;               /* 该通道是否在线 */
        public byte byRes1;
        public ushort wIPID;                  //IP设备ID
        public uint dwChannel;              //通道号
        public byte byTransProtocol;        //传输协议类型0-TCP，1-UDP
        public byte byTransMode;            //传输码流模式 0－主码流 1－子码流
        public byte byFactoryType;          /*前端设备厂家类型,通过接口获取*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 241, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
