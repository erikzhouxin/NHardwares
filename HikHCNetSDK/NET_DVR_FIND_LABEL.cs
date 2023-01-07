using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //标签搜索结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FIND_LABEL
    {
        public uint dwSize;          // 结构体大小
        public int lChannel;        // 查找的通道
        public NET_DVR_TIME struStartTime;  // 开始时间
        public NET_DVR_TIME struStopTime;   // 结束时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LABEL_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLabelName;   //  录像标签名称 如果标签名称为空，则搜索起止时间所有标签
        public byte byDrawFrame;        //0:不抽帧，1：抽帧
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 39, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }
}
