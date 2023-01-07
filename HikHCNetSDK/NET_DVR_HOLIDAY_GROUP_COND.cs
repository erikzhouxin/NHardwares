using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDAY_GROUP_COND
    {
        public uint dwSize;
        public uint dwHolidayGroupNumber; //Holiday group number 
        public ushort wLocalControllerID; //On the controller serial number [1, 64]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[106];
        }
    }


}
