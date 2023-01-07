using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //违规检测线参数结构
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_VIOLATION_DETECT_LINE
    {
        public NET_ITC_LINE struLaneLine; //车道线参数
        public NET_ITC_LINE struStopLine; //停止线参数
        public NET_ITC_LINE struRedLightLine; //闯红灯触发线参数
        public NET_ITC_LINE struCancelLine; //直行触发位置取消线
        public NET_ITC_LINE struWaitLine; //待行区停止线参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_LINE[] struRes;
    }

}
