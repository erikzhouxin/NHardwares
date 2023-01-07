using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HDGROUP_CFG
    {
        public uint dwSize;
        public uint dwHDGroupCount;/*盘组总数(不可设置)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HD_GROUP, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_HDGROUP[] struHDGroupAttr;//硬盘相关操作都需要重启才能生效
    }

}
