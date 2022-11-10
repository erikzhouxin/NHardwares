using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @enum tagNETDEVPersonTimeTemplateInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_TIME_TEMPLATE_INFO_S
    {
        public UInt32 udwBeginTime;
        public UInt32 udwEndTime;
        public UInt32 udwIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
