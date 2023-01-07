using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_SDK_REGION_THERMOMETRY
    {
        public float fMaxTemperature;//最高温度,精确到小数点后一位(-40-1000),（浮点数+100）*10 */
        public float fMinTemperature;//最低温度,精确到小数点后一位(-40-1000),（浮点数+100）*10 */
        public float fAverageTemperature;//平均温度,精确到小数点后一位(-40-1000),（浮点数+100）*10 */
        public float fTemperatureDiff;//温差,精确到小数点后一位(-40-1000),（浮点数+100）*10 */
        public NET_VCA_POLYGON struRegion;//区域、线（当规则标定类型为“框”或者“线”的时候生效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
