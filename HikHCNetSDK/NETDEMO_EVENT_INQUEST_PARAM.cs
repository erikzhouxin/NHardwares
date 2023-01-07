using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //审讯事件搜索条件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_INQUEST_PARAM
    {
        public byte byRoomIndex;    //审讯室编号,从1开始
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 299, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
        public void Init()
        {
            byRes = new byte[299];
        }
    }


}
