using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_REDAREACFG
    {
        public uint dwSize;
        public uint dwCorrectEnable; //是否开启校正功能，0-关闭，1-开启
        public uint dwCorrectLevel; //校正级别，1(校正度最低)-10(校正度最高),默认为5
        public uint dwAreaNum; //校正区域个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_REDAREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_RECT[] struLaneRect; //校正区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }
}
