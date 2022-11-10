using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_POSITION_INFO_S
    {
        public Int32 dwTopLeftX;           /* Upper left corner X [0, 10000]  */
        public Int32 dwTopLeftY;           /* Upper left corner Y [0, 10000]  */
        public Int32 dwBottomRightX;       /* Lower right corner x [0, 10000] */
        public Int32 dwBottomRightY;       /* Lower right corner y [0, 10000] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
