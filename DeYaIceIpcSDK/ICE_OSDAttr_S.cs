using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// osd叠加信息结构体
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_OSDAttr_S
    {
        //video
        /// <summary>
        /// 叠加位置(0左上，1右上，2左下，3右下，4上居中，5下居中)
        /// </summary>
        public uint u32OSDLocationVideo;
        /// <summary>
        /// 颜色(十六进制RGB颜色值，格式为0x00bbggrr)
        /// </summary>
        public uint u32ColorVideo;
        /// <summary>
        /// 是否叠加日期时间(0不叠加 1叠加)
        /// </summary>
        public uint u32DateVideo;
        /// <summary>
        /// 是否叠加授权信息(0不叠加 1叠加)
        /// </summary>
        public uint u32License;
        /// <summary>
        /// 是否叠加自定义信息(0不叠加 1叠加)
        /// </summary>
        public uint u32CustomVideo;
        /// <summary>
        /// 自定义信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szCustomVideo;

        //jpeg
        /// <summary>
        /// 叠加位置(0左上，1右上，2左下，3右下，4上居中，5下居中)
        /// </summary>
        public uint u32OSDLocationJpeg;
        /// <summary>
        /// 颜色(十六进制RGB颜色值，格式为0x00bbggrr)
        /// </summary>
        public uint u32ColorJpeg;
        /// <summary>
        /// 是否叠加日期时间(0不叠加 1叠加)
        /// </summary>
        public uint u32DateJpeg;
        /// <summary>
        /// 是否叠加算法信息(0不叠加 1叠加)
        /// </summary>
        public uint u32Algo;
        /// <summary>
        /// 是否叠加设备ID(预留，暂未使用)
        /// </summary>
        public uint u32DeviceID;
        /// <summary>
        /// 设备ID(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szDeviceID;
        /// <summary>
        /// 是否叠加设备名称(预留，暂未使用)	
        /// </summary>
        public uint u32DeviceName;
        /// <summary>
        /// 设备名称(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szDeviceName;
        /// <summary>
        /// 是否叠加地点信息(预留，暂未使用)
        /// </summary>
        public uint u32CamreaLocation;
        /// <summary>
        /// 地点信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szCamreaLocation;
        /// <summary>
        /// 是否叠加子地点信息(预留，暂未使用)
        /// </summary>
        public uint u32SubLocation;
        /// <summary>
        /// 子地点信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSubLocation;
        /// <summary>
        /// 是否叠加相机方向(预留，暂未使用)
        /// </summary>
        public uint u32ShowDirection;
        /// <summary>
        /// 相机方向(预留，暂未使用)
        /// </summary>
        public uint u32CameraDirection;
        /// <summary>
        /// 是否叠加自定义信息(1叠加 0不叠加)	
        /// </summary>
        public uint u32CustomJpeg;

        /// <summary>
        /// 图片信息显示模式（0，多行显示，1，单行显示,默认0）
        /// </summary>
        public uint u32ItemDisplayMode;
        /// <summary>
        /// 日期显示模式（0，xxxx/xx/xx   1，xxxx年xx月xx日，默认0）
        /// </summary>
        public uint u32DateMode;
        /// <summary>
        /// OSD 背景色（0背景全透明，1，背景黑色，默认0）
        /// </summary>
        public uint u32BgColor;
        /// <summary>
        /// 字体大小（0:小，1:中 2:大,默认为中，在540P 以下，中和大会转换为小）
        /// </summary>
        public uint u32FontSize;
        /// <summary>
        /// 自定义信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string szCustomJpeg;
        /// <summary>
        /// 视频自定义信息，每行最多64字节（包含换行符），最多6行，数组长度为64*6
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 384)]
        public string szCustomVideo6;
        /// <summary>
        /// 抓拍图自定义信息，每行最多64字节（包含换行符），最多6行，数组长度为64*6
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 384)]
        public string szCustomJpeg6;
    }
}
