using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_RULE_CFG
    {
        public uint dwSize;              //结构大小
        public byte byEnable;             // 是否激活规则;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       // 保留字节 
        public NET_VCA_POLYGON struPolygon;            // 多边形
        public NET_DVR_PDC_ENTER_DIRECTION struEnterDirection;    // 流量进入方向
    }


}
