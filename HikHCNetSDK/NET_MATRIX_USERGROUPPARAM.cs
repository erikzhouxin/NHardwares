using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //最多255个用户组
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_USERGROUPPARAM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sGroupName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = UnmanagedType.U2)]
        public ushort[] wUserMember;  /*包含的用户成员*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = UnmanagedType.U2)]
        public ushort[] wResorceGroupMember; /*包含的资源组成员*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byPermission;//权限，数组0-ptz权限、切换权限、查询权限
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
