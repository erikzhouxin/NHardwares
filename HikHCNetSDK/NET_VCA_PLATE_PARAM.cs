using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*wMinPlateWidth:该参数默认配置为80像素；该参数的配置对于车牌海康威视车牌识别说明文档 
    识别有影响，如果设置过大，那么如果场景中出现小车牌就会漏识别；如果场景中车牌宽度普遍较大，可以把该参数设置稍大，便于减少对虚假车牌的处理。在标清情况下建议设置为80， 在高清情况下建议设置为120
    wTriggerDuration － 外部触发信号持续帧数量，其含义是从触发信号开始识别的帧数量。该值在低速场景建议设置为50～100；高速场景建议设置为15～25；移动识别时如果也有外部触发，设置为15～25；具体可以根据现场情况进行配置
    */
    //车牌可动态修改参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PLATE_PARAM
    {
        public NET_VCA_RECT struSearchRect;//搜索区域(归一化)
        public NET_VCA_RECT struInvalidateRect;//无效区域，在搜索区域内部 (归一化)
        public ushort wMinPlateWidth;//车牌最小宽度
        public ushort wTriggerDuration;//触发持续帧数
        public byte byTriggerType;//触发模式, VCA_TRIGGER_TYPE
        public byte bySensitivity;//灵敏度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，置0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byCharPriority;// 汉字优先级
    }
}
