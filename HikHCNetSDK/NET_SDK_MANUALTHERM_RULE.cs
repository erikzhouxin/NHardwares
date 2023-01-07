using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_SDK_MANUALTHERM_RULE
    {
        public byte byRuleID;//规则ID 0-表示无效，从1开始 （list内部判断数据有效性）
        public byte byEnable;//是否启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] szRuleName;//规则名称
        public byte byRuleCalibType;//规则标定类型 0-点，1-框，2-线
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_SDK_POINT_THERMOMETRY struPointTherm;//点测温，当标定为0-点时生效
        public NET_SDK_REGION_THERMOMETRY struRegionTherm; //区域测温，当标定为1-框、2-线时生效。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
