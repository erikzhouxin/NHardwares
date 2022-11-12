using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVCtrlTemperatureInfo
    * @brief 温度信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_TEMPERATURE_INFO
    {
        public UInt32 udwRelativeFaceID;          /* 关联人脸ID，若无关联人脸，填写0xffffffff */
        public float fEnvTemperature;            /* 环境温度，单位：摄氏度  */
        public float fTemperatureThreshold;      /* 温度阈值，单位：摄氏度 */
        public float fBodyTemperature;           /* 测量体温温度，单位：摄氏度 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                      /* 保留字段 */
    }

}
