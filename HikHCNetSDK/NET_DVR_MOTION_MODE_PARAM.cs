using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MOTION_MODE_PARAM
    {
        public NET_DVR_MOTION_SINGLE_AREA struMotionSingleArea; //普通模式下的单区域设
        public NET_DVR_MOTION_MULTI_AREA struMotionMultiArea; //专家模式下的多区域设置	
    }
}
