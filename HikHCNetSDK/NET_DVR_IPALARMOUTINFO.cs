using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* 报警输出参数 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMOUTINFO
    {
        public byte byIPID;/* IP设备ID取值1- MAX_IP_DEVICE */
        public byte byAlarmOut;/* 报警输出号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;/* 保留 */

        public void Init()
        {
            byRes = new byte[18];
        }
    }

}
