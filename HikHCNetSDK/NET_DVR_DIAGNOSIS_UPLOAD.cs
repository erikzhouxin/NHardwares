using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DIAGNOSIS_UPLOAD
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.STREAM_ID_LEN)]
        public string sStreamID;    // 流ID，长度小于32个字节
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string sMonitorIP;  // 监控点ip
        public uint dwChanIndex;  // 监控点通道号  
        public uint dwWidth;  // 图像宽度
        public uint dwHeight;  // 图像高度
        public NET_DVR_TIME struCheckTime;  // 检测时间(合并日期和时间字段)，格式：2012-08-06 13:00:00
        public byte byResult;  ///0-未检测 1-正常 2-异常 3-登录失败 4-取流异常
        public byte bySignalResult; // 视频丢失检测结果 0-未检测 1-正常 2-异常
        public byte byBlurResult;  // 图像模糊检测结果，0-未检测 1-正常 2-异常
        public byte byLumaResult;  // 图像过亮检测结果，0-未检测 1-正常 2-异常
        public byte byChromaResult;  // 偏色检测结果，0-未检测 1-正常 2-异常
        public byte bySnowResult;  // 噪声干扰检测结果，0-未检测 1-正常 2-异常
        public byte byStreakResult;  // 条纹干扰检测结果，0-未检测 1-正常 2-异常
        public byte byFreezeResult;  // 画面冻结检测结果，0-未检测 1-正常 2-异常
        public byte byPTZResult;  // 云台检测结果，0-未检测 1-正常 2-异常
        public byte byContrastResult;     //对比度异常检测结果，0-未检测，1-正常，2-异常
        public byte byMonoResult;         //黑白图像检测结果，0-未检测，1-正常，2-异常
        public byte byShakeResult;        //视频抖动检测结果，0-未检测，1-正常，2-异常
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string sSNapShotURL; //图片URL地址
        public byte byFlashResult;        //视频剧变检测结果，0-未检测，1-正常，2-异常
        public byte byCoverResult;        //视频遮挡检测结果，0-未检测，1-正常，2-异常
        public byte bySceneResult;        //场景变更检测结果，0-未检测，1-正常，2-异常
        public byte byDarkResult;         //图像过暗检测结果，0-未检测，1-正常，2-异常
        public byte byStreamType;       //码流类型，0-无效，1-未知，2-国标类型，3-非国标类型
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 59, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
