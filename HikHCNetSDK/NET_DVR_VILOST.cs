﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //信号丢失报警(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VILOST
    {
        public byte byEnableHandleVILost;/* 是否处理信号丢失报警 */
        public NET_DVR_HANDLEEXCEPTION strVILostHandleType;/* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
    }
}