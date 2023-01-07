using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struDecoderSystemAbility
    {
        public byte byVGANums;//VGA显示通道个数（从1开始）
        public byte byBNCNums;//BNC显示通道个数（从9开始）
        public byte byHDMINums;//HDMI显示通道个数（从25开始）
        public byte byDVINums;//DVI显示通道个数（从29开始）

        public byte byLayerNums;//大屏拼接中，做主屏时所支持图层数
        public byte bySpartan;//畅显功能，0-不支持，1-支持
        public byte byDecType; //解码子系统类型，0-普通型,1-增强型(普通型分屏时前4窗口需使用自身资源，增强型无此限制，增强型最多可被其他子系统借16路D1解码资源
                               //增强型被大屏关联为子屏后资源可被借用，普通型则不能被借用)
        public byte byOutputSwitch;//是否支持HDMI/DVI互相切换，0-不支持，1-支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 39, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byDecoderType; //解码板类型  0-普通解码板 1-万能解码板
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 152, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
