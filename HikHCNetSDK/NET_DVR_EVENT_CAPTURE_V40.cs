﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EVENT_CAPTURE_V40
    {
        public NET_DVR_JPEGPARA struJpegPara;   // 事件抓图图片质量
        public uint dwPicInterval;   // 事件抓图时间间隔  单位为秒 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_PIC_EVENT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_REL_CAPTURE_CHAN_V40[] struRelCaptureChan;   // 数组下标 0 移动侦测触发抓图 1 视频遮挡触发抓图 2 视频丢失触发抓图,数组3表示PIR报警抓图，数组4表示无线报警抓图，数组5表示呼救报警抓图,数组6表示智能抓图
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN_CAPTURE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_REL_CAPTURE_CHAN_V40[] struAlarmInCapture;    // 报警输入触发抓图，下标0 代表报警输入1 依次类推
        public uint dwMaxGroupNum;  //设备支持的最大报警输入组数，每组16个报警输入
        public byte byCapTimes; //抓图张数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 59, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}