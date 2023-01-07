using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP设备结构 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPDEVINFO
    {
        public uint dwEnable;/* 该IP设备是否启用 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword; /* 密码 */
        public NET_DVR_IPADDR struIP;/* IP地址 */
        public ushort wDVRPort;/* 端口号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;/* 保留 */

        public void Init()
        {
            sUserName = new byte[HikHCNetSdk.NAME_LEN];
            sPassword = new byte[HikHCNetSdk.PASSWD_LEN];
            byRes = new byte[34];
        }
    }

}
