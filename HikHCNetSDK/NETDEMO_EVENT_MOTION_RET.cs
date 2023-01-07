using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //移动侦测结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_MOTION_RET
    {
        public uint dwMotDetNo;//移动侦测通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[HikHCNetSdk.SEARCH_EVENT_INFO_LEN];
        }
    }


}
