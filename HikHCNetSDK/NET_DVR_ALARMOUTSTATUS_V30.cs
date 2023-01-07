using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*************************动环报警管理主机日志查找 end***********************************************/

    //报警输出状态(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMOUTSTATUS_V30
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMOUT_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] Output;

        public void Init()
        {
            Output = new byte[HikHCNetSdk.MAX_ALARMOUT_V30];
        }
    }

}
