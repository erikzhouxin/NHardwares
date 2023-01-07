using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NAS_MOUNT_PARAM
    {
        public byte byMountType; //0～保留,1~NFS, 2~ SMB/CIFS
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_MOUNT_PARAM_UNION uMountParam;
    }
}
