using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //多屏服务器能力集
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENSERVER_ABILITY
    {
        public uint dwSize;             /*结构长度*/
        public byte byIsSupportScreenNum; /*所支持大屏控制器的数目*/
        public byte bySerialNums;           //串口个数
        public byte byMaxInputNums;
        public byte byMaxLayoutNums;
        public byte byMaxWinNums;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byMaxScreenLayX;//大屏布局-最大横坐标大屏数
        public byte byMaxScreenLayY;//大屏布局-最大纵坐标大屏数
        public ushort wMatrixProtoNum; /*有效的大屏协议数目*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SCREEN_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PROTO_TYPE[] struScreenProto;/*最大协议列表*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
