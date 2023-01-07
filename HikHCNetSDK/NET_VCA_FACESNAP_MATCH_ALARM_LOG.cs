using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACESNAP_MATCH_ALARM_LOG
    {
        public uint dwSize;             // 结构大小
        public float fSimilarity; //相似度，[0.001,1]
        public NET_VCA_FACESNAP_INFO_ALARM_LOG struSnapInfoLog; //抓拍信息
        public NET_VCA_BLOCKLIST_INFO_ALARM_LOG struBlockListInfoLog; //禁止名单信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              // 保留字节
    }
}
