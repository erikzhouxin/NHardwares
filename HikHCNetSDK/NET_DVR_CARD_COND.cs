using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CARD_COND
    {
        public uint dwSize;
        public uint dwCardNum; //card number, 0xffffffff means to get all card information when getting
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[64];
        }
    }
}
