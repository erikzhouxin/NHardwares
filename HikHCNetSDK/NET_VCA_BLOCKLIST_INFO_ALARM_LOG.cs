using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_INFO_ALARM_LOG
    {
        public NET_VCA_BLOCKLIST_INFO struBlockListInfo; //禁止名单基本信息
        public uint dwBlockListPicID;       //禁止名单人脸子图ID，用于查找图片
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              // 保留字节
    }
}
