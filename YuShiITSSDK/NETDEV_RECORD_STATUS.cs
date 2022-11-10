using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS
    {
        public Int32 dwChannelID;                    /*Channel ID */
        public Int32 dwRecordType;
        public Int32 dwRecordStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
