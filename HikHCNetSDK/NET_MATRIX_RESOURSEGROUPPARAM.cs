using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //最多255个资源组
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_RESOURSEGROUPPARAM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byGroupName;
        public byte byGroupType;/*0-摄像机CAM组，1-监视器MON组*/
        public byte byRes1;
        public ushort wMemNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.U4)]
        public uint[] dwGlobalId;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
