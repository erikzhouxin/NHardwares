using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //禁止名单信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_BLOCKLIST_INFO
    {
        public uint dwSize;//结构大小
        public uint dwRegisterID;//名单注册ID号（只读）
        public uint dwGroupNo;//分组号
        public byte byType;//名单标志：0-全部，1-允许名单，2-禁止名单
        public byte byLevel;//禁止名单等级，0-全部，1-低，2-中，3-高
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public NET_VCA_HUMAN_ATTRIBUTE struAttribute;//人员信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRemark;//备注信息
        public uint dwFDDescriptionLen;//人脸库描述数据长度
        public IntPtr pFDDescriptionBuffer;//人脸库描述数据指针
        public uint dwFCAdditionInfoLen;//抓拍库附加信息长度
        public IntPtr pFCAdditionInfoBuffer;//抓拍库附加信息数据指针（FCAdditionInfo中包含相机PTZ坐标）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留
    }
}
