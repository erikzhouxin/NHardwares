using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_SDK_POINT_THERMOMETRY
    {
        public float fPointTemperature;/*点测温当前温度, 当标定为0-点时生效。精确到小数点后一位(-40-1000),（浮点数+100）*10 */
        public NET_VCA_POINT struPoint;//点测温坐标（当规则标定类型为“点”的时候生效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
