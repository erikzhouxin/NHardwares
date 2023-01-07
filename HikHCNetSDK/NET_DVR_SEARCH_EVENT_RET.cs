using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //查找返回结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SEARCH_EVENT_RET
    {
        public ushort wMajorType;//主类型MA
        public ushort wMinorType;//次类型
        public NET_DVR_TIME struStartTime;//事件开始的时间
        public NET_DVR_TIME struEndTime;//事件停止的时间，脉冲事件时和开始时间一样
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byChan;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public SEARCH_EVENT_RET uSeniorRet;

        public void Init()
        {
            byChan = new byte[HikHCNetSdk.MAX_CHANNUM_V30];
            byRes = new byte[36];
        }
    }


}
