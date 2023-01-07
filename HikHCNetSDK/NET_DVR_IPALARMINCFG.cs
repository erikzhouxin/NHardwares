using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP报警输入配置结构 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMINCFG
    {
        public uint dwSize;/* 结构大小 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;/* IP报警输入 */
    }

}
