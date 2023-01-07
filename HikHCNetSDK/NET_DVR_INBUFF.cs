using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    public struct NET_DVR_INBUFF
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U4)]
        public uint[] StatusList;
        public void Init()
        {
            StatusList = new uint[16];
        }
    }

}
