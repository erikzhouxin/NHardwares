using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能侦测查找条件 ，通道号按值表示
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_VCADETECT_BYVALUE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30 - 1, ArraySubType = UnmanagedType.U4)]
        public uint[] dwChanNo;// 触发通道号,按值表示，0xffffffff无效，且后续数据也表示无效值
        public byte byAll;//0-表示不是全部，1-表示全部。
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 47, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            dwChanNo = new uint[HikHCNetSdk.MAX_CHANNUM_V30 - 1];
            byRes = new byte[47];
        }
    }


}
