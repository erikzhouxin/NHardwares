using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIXMANAGE_ABIILITY
    {
        public uint dwSize;
        public uint dwMaxCameraNum;//最大Camera数量
        public uint dwMaxMonitorNum;//最大监视器数量
        public ushort wMaxMatrixNum;//最大矩阵数量
        public ushort wMaxSerialNum;//串口数量
        public ushort wMaxUser;//最大用户数
        public ushort wMaxResourceArrayNum;//最大资源组数
        public ushort wMaxUserArrayNum;//最大用户组数
        public ushort wMaxTrunkNum;//最大干线数
        public byte nStartUserNum;//起始用户号
        public byte nStartUserGroupNum;//起始用户组号
        public byte nStartResourceGroupNum;//起始资源组号
        public byte nStartSerialNum;//起始串口号
        public uint dwMatrixProtoNum;     /*有效的矩阵协议数目，从0开始*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MATRIX_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PROTO_TYPE_EX[] struMatrixProto;/*最大协议列表长度*/
        public uint dwKeyBoardProtoNum;     /*有效的键盘协议数目，从0开始*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MATRIX_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PROTO_TYPE_EX[] struKeyBoardProto;/*最大协议列表长度*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
