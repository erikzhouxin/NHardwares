using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /****************************DS9000新增结构(begin)******************************/
    /*EMAIL参数结构*/
    //与原结构体有差异
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struReceiver
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sName;/* 收件人姓名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_EMAIL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sAddress;/* 收件人地址 */
    }
}
