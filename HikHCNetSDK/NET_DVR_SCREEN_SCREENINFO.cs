using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREEN_SCREENINFO
    {
        public uint dwSize;
        public byte byValid;                //是否有效
        public byte nLinkMode;              //连接方式，0-串口，1-网口
        public byte byDeviceType;           //设备型号，能力集获取
        public byte byScreenLayX;           //大屏布局-横坐标
        public byte byScreenLayY;           //大屏布局-纵坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;    /*登录用户名*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword; /*登录密码*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDevName; /*设备名称*/
        public NET_DVR_SCREEN_UNION struScreenUnion;
        public byte byInputNum;         // 输入源个数
        public byte byOutputNum;            // 输出源个数
        public byte byCBDNum;               //CBD个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 29, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
