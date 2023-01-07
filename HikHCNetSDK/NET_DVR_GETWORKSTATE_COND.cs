using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_GETWORKSTATE_COND
    {
        public uint dwSize;  //结构体长度
        public byte byFindHardByCond; /*0-查找全部磁盘(但一次最多只能查找33个)，此时dwFindHardStatusNum无效*/
        public byte byFindChanByCond;  /*0-查找全部通道，此时dwFindChanNum无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留	
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.U4)]
        public uint[] dwFindHardStatus; /*要查找的硬盘号，按值表示，该值采用顺序排列， 遇到0xffffffff则认为后续无效 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwFindChanNo; /*要查找的通道号，按值表示，该值采用顺序排列， 遇到0xffffffff则认为后续无效 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }

}
