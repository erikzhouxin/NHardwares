﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图片命名
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PICTURE_NAME
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PICNAME_MAXITEM, ArraySubType = UnmanagedType.I1)]
        public byte[] byItemOrder;  /*	桉数组定义文件命名的规则 */
        public byte byDelimiter;        /*分隔符，一般为'_'*/
    }


}
