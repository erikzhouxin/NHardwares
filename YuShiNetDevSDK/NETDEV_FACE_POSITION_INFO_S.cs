using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_POSITION_INFO_S
    {
        public Int32 dwTopLeftX;           /* 左上角X [0, 10000]  Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* 左上角Y [0, 10000]  Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* 右下角X [0, 10000]  Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* 右下角Y [0, 10000]  Lower right corner y [0, 10000] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
