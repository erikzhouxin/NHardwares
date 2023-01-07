using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_PARA
    {
        public uint dwSize;   //结构大小
        public NET_VCA_BLOCKLIST_INFO struBlockListInfo;  //禁止名单基本参数
        public uint dwRegisterPicNum;  //禁止名单图个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HUMAN_PICTURE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_PICMODEL_RESULT[] struRegisterPic;  //禁止名单图片信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
