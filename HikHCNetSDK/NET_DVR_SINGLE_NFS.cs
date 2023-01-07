using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //nfs结构配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_SINGLE_NFS
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sNfsHostIPAddr;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNfsDirectory;

        public void Init()
        {
            this.sNfsDirectory = new byte[HikHCNetSdk.PATHNAME_LEN];
        }
    }
}
