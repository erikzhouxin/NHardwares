using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BIGSCREENASSOCIATECFG
    {
        public uint dwSize;
        public byte byEnableBaseMap;//使能底图显示
        public byte byAssociateBaseMap;//关联的底图序号，0代表不关联
        public byte byEnableSpartan;//大屏畅显使能，1-开，0-关
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
