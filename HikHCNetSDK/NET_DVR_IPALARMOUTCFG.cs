using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP报警输出配置结构 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMOUTCFG
    {
        public uint dwSize; /* 结构大小 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo;/* IP报警输出 */

        public void Init()
        {
            struIPAlarmOutInfo = new NET_DVR_IPALARMOUTINFO[HikHCNetSdk.MAX_IP_ALARMOUT];
            for (int i = 0; i < HikHCNetSdk.MAX_IP_ALARMOUT; i++)
            {
                struIPAlarmOutInfo[i].Init();
            }
        }
    }

}
