using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MULTI_CARD_GROUP_CFG_V50
    {
        public byte byEnable; //是否启用该多重卡组参数，0-不启用，1-启用
        public byte byEnableOfflineVerifyMode; //是否启用主机离线时验证方式（超级密码代替远程开门），1-启用，0-不启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwTemplateNo; //启用多重卡功能的计划模板编号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.GROUP_COMBINATION_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_GROUP_COMBINATION_INFO_V50[] struGroupCombination; //群组组合参数
    }
}
