using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频综合平台软件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct tagVEDIOPLATLOG
    {
        public byte bySearchCondition;//搜索条件，0-按槽位号搜索，1-按序列号搜索 2-按MAC地址进行搜索
        public byte byDevSequence;//槽位号，0-79：对应子系统的槽位号；
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;//序列号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMacAddr;//MAC地址
    }
}
