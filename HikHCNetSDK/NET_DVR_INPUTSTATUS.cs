using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INPUTSTATUS
    {
        public ushort wInputNo;     /*信号源序号*/
        public byte byInputType;    //见NET_DVR_CAM_MODE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_INPUTSTATUS_UNION struStatusUnion;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
