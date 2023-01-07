using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*IP报警输入资源*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMINCFG_V40
    {
        public uint dwSize;  //结构体长度
        public uint dwCurIPAlarmInNum;  //当前报警输入口数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMIN_V40, ArraySubType = UnmanagedType.I1)]
        public NET_DVR_IPALARMININFO_V40[] struIPAlarmInInfo;/* IP报警输入*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
