using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_RULE_S
    {
        public Int32 udwPreRecordTime;           /* 警前预录时间，单位秒,取值：0,5,10,20,30,60 */
        public Int32 udwPostRecordTime;           /* 警后录像时间，单位秒,取值：5，10,30,60，120,300,600 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
