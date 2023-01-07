using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MULTI_CARD_CFG_V50
    {
        public uint dwSize;
        public byte byEnable; //是否启用多重卡功能，0-不启用，1-启用
        public byte bySwipeIntervalTimeout; //刷卡间隔超时时间，1-255s，默认10s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_MULTI_CARD_GROUP_NUM_20, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MULTI_CARD_GROUP_CFG_V50[] struGroupCfg; //群组刷卡参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
