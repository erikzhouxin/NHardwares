using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //本地盘组信息配置扩展
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_HDGROUP_V40
    {
        public uint dwHDGroupNo;       /*盘组号(不可设置) 1-MAX_HD_GROUP*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRelRecordChan;  //触发的录像通道，按值表示，遇到0xffffffff时后续视为无效    
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                /* 保留 */
    }

}
