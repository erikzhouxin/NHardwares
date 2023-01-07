using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_COND
    {
        public Int32 lChannel; //通道号
        public uint dwGroupNo; //分组号
        public byte byType; //名单标志：0-全部，1-允许名单，2-禁止名单
        public byte byLevel; //禁止名单等级，0-全部，1-低，2-中，3-高
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  //保留
        public NET_VCA_HUMAN_ATTRIBUTE struAttribute; //人员信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
