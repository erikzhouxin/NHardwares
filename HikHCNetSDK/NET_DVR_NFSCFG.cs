using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NFSCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NFS_DISK, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_NFS[] struNfsDiskParam;

        public void Init()
        {
            this.struNfsDiskParam = new NET_DVR_SINGLE_NFS[HikHCNetSdk.MAX_NFS_DISK];

            for (int i = 0; i < HikHCNetSdk.MAX_NFS_DISK; i++)
            {
                struNfsDiskParam[i].Init();
            }
        }
    }
}
