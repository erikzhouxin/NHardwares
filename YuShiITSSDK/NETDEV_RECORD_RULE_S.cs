using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_RULE_S
    {
        public Int32 udwPreRecordTime;           /* 0,5,10,20,30,60 */
        public Int32 udwPostRecordTime;           /*5，10,30,60，120,300,600 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
