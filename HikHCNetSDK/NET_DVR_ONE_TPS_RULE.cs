﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通统计参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_TPS_RULE
    {
        public byte byEnable;                   //是否使能车道交通规则参数
        public byte byLaneID;                   //车道ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwCalcType;                 //统计参数类型ITS_TPS_TYPE
        public NET_VCA_SIZE_FILTER struSizeFilter; //尺寸过滤器 
        public NET_VCA_POLYGON struVitrualLoop;    //虚拟线圈
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        public NET_DVR_HANDLEEXCEPTION_V30 struHandleType;  //处理方式,一般为处理是否上传中心，其他功能不需要
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                         //保留字节
    }



}
