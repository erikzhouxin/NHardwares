using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FIND_PICTURECOND_ADVANCE
    {
        public Int32 lChannel;//通道号
        public NET_DVR_TIME struStartTime;//开始时间
        public NET_DVR_TIME struStopTime;//结束时间
        public byte byThreshold;  //阈值，0-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
        public VCA_FIND_SNAPPIC_TYPE dwFindType;//检索类型，详见VCA_FIND_SNAPPIC_TYPE
        public NET_VCA_FIND_SNAPPIC_UNION uFindParam; //检索参数
    }
}
