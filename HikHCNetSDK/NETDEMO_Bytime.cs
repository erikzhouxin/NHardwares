using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct bytime
    {
        public uint dwChannel;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/*请求视频用户名*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 密码 */
        public NET_DVR_TIME struStartTime;/* 按时间回放的开始时间 */
        public NET_DVR_TIME struStopTime;/* 按时间回放的结束时间 */
    }
}
