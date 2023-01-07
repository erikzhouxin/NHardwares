using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_AREA_SMARTSEARCH_COND_UNION
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6144, ArraySubType = UnmanagedType.I1)]
        public byte[] byLen;  //结构体长度
        /*[FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64 * 96, ArraySubType = UnmanagedType.I1)]
        public byte[] byMotionScope; //侦测区域 0-96位表示64行，共有96*64个小宏块，1-是移动侦测区域，0-非移动侦测区域 
        [FieldOffsetAttribute(0)]
        public NET_DVR_TRAVERSE_PLANE_SEARCHCOND struTraversPlaneCond; //越界侦测
        [FieldOffsetAttribute(0)]
        public NET_DVR_INTRUSION_SEARCHCOND struIntrusionCond; //区域入侵
         * */
    }
}
