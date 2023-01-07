using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //查找返回结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SEARCH_EVENT_RET_V40
    {
        public ushort wMajorType;            //主类型
        public ushort wMinorType;            //次类型
        public NET_DVR_TIME struStartTime;    //事件开始的时间
        public NET_DVR_TIME struEndTime;   //事件停止的时间，脉冲事件时和开始时间一样
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U2)]
        public ushort[] wChan;    //触发的通道号，0xffff表示后续无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public UNION_EVENT_RET uSeniorRet;
    }
}
