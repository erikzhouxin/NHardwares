using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //试用版信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRIAL_VERSION_CFG
    {
        public uint dwSize;
        public ushort wReserveTime; //试用期剩余时间，0xffff表示无效，单位：天
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 62, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
