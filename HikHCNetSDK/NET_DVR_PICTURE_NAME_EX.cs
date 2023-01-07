using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图片命名扩展 2013-09-27
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PICTURE_NAME_EX
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PICNAME_MAXITEM, ArraySubType = UnmanagedType.I1)]
        public byte[] byItemOrder;  /*	桉数组定义文件命名的规则 */
        public byte byDelimiter;                    /*分隔符，一般为'_'*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                      /*保留*/
    }


}
